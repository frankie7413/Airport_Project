using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class PassengerInfo
    {
        private static List<int> passengerList = new List<int>(); 
        public static PassengerInfo[] passengerObject = new PassengerInfo[1];
        private static int passengerCount;
        private static int PassengerID;

        //not sure if we should even do this for ppl who want to schedule same flight again not worth
        public static void loadPassengersReserve(string ticket)
        {
            DataSet dsPasssenger = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findPassengers = new MySqlCommand("select * from Passenger where TicketID = '" + ticket + "';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daPassenger = new MySqlDataAdapter(findPassengers);
            daPassenger.Fill(dsPasssenger);

            SQLConnection.Instance.CloseConnection();

            passengerCount = dsPasssenger.Tables[0].Rows.Count;
            for (int i = 0; i < passengerCount; i++)
            {
                DataRow dataRow = dsPasssenger.Tables[0].Rows[i];

                passengerList.Add((Convert.ToInt32(dataRow[0])));

            }

        }

        public static void LoadPassengerInfo(int passNumber)
        {

            DataSet dsPasssenger = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findPassengers = new MySqlCommand("select * from Passenger where PassengerID = '" + passNumber + "';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daPassenger = new MySqlDataAdapter(findPassengers);
            daPassenger.Fill(dsPasssenger);

            SQLConnection.Instance.CloseConnection();

            passengerObject[0] = new PassengerInfo();
            DataRow dataRow = dsPasssenger.Tables[0].Rows[0];

            passengerObject[0].setFirstName((string)dataRow[1]);
            passengerObject[0].setMidName((string)dataRow[2]);
            passengerObject[0].setLastName((string)dataRow[3]);
            passengerObject[0].setAge((string)dataRow[4]);
            passengerObject[0].setGender((string)dataRow[5]);
            passengerObject[0].setDate((DateTime)dataRow[6]);
        }


        public static int getNumPassengers()
        {
            return passengerCount;
        }


        /// <summary>
        /// Removes the first passenger from the list.
        /// </summary>
        public static void removePassengers()
        {
            int remove = Math.Min(passengerList.Count, 1);
            passengerList.RemoveRange(0, remove);
        }

        /// <summary>
        /// Checks to see if the list is empty. 
        /// </summary>
        /// <returns></returns>
        public static bool emptyPassenger()
        {
            bool found = false;

            if (passengerList.Count() == 0)
            {
                found = true;
            }

            return found;
        }

        /// <summary>
        /// Acceses the first passsenger if the list is not empty
        /// </summary>
        /// <returns></returns>
        public static int accessPassenger()
        {
            int display = 0;

            if (passengerList.Count != 0)
            {
                display = passengerList.ElementAt(0);
            }

            return display;
        }



        ///passsenger information
        private static string firstName, midName, lastName, Age, Gender;
        private static DateTime birthday;

        //first
        public void setFirstName(string first)
        {
            firstName = first;
        }

        public string getFirstName()
        {
            return firstName;
        }

        //mid
        public void setMidName(string mid)
        {
            midName = mid;
        }

        public string getMidName()
        {
            return midName;
        }

        //last
        public void setLastName(string last)
        {
            lastName = last;
        }

        public string getLastName()
        {
            return lastName;
        }

        //age

        public void setAge(string a)
        {
            Age = fillAge(a);
        }


        public string getAge()
        {
            return Age;
        }

        //gender
        public void setGender(string g)
        {
            Gender = fillGender(g);
        }

        public string getGender()
        {
            return Gender;
        }

        //date
        public void setDate(DateTime time)
        {
            birthday = time;
        }

        public string getDate()
        {
            string date = birthday.ToString();
            return date;
            
        }

        private string fillAge(string age_change)
        {
            if(age_change == "A")
            {
                age_change = "Adult";
            }
            else if (age_change == "C")
            {
                age_change = "Children";
            }
            else
            {
                age_change = "Infant";
            }

            return age_change;
        }

        private string fillGender(string gender_change)
        {

            if(gender_change == "M")
            {
                gender_change = "Male";
            }
            else
            {
                gender_change = "Female";
            }

            return gender_change;
        }


        private static int tempID;

        public static string getPassenger()
        {
            string pstr;

            string firstname, midname, lastname, age, gender, birthdate;
            DateTime birth;
            tempID = accessPassenger();

            DataSet dsPassenger = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand passData = new MySqlCommand();
            MySqlDataAdapter daPass = new MySqlDataAdapter("select * from Passenger where PassengerID = '" + tempID + "';", SQLConnection.Instance.GetConnection());
            daPass.Fill(dsPassenger);

            SQLConnection.Instance.CloseConnection();

            DataRow dataRow = dsPassenger.Tables[0].Rows[0];
            firstname = (string)dataRow[1];
            midname = (string)dataRow[2];
            lastname = (string)dataRow[3];
            age = (string)dataRow[4];
            gender = (string)dataRow[5];
            birth = (DateTime)dataRow[6];

            removePassengers();

            string date = birth.ToString("d");
            birthdate = DateTime.Parse(date).ToString("MM-dd-yyyy");

            if (string.IsNullOrEmpty(midname))
            {
                midname = " ";
            }
            else
            {
                midname = " " + midname + " ";
            }

            age = getAge(age);

            pstr = firstname + midname + lastname + "\nAge: " + age + " Gender: " + gender + " Birthdate: " + birthdate;

            return pstr;
        }


        public static string getSeatInfo()
        {
            string fstr, cseat, row;
            int seat, select;
            SQLConnection.Instance.OpenConnection();

            ///get class where passenger seats and get setID
            MySqlCommand findClass = new MySqlCommand("select Class from Passenger where PassengerID = '" + tempID + "';", SQLConnection.Instance.GetConnection());
            MySqlCommand findSeat = new MySqlCommand("select SeatID from Passenger where PassengerID = '" + tempID + "';", SQLConnection.Instance.GetConnection());
            cseat = (string)findClass.ExecuteScalar();
            seat = Convert.ToInt32(findSeat.ExecuteScalar());

            //get the row and seat where passenger is seating at
            MySqlCommand findRow = new MySqlCommand("select Row from Seat where SeatID = '" + seat + "';", SQLConnection.Instance.GetConnection());
            MySqlCommand findselect = new MySqlCommand("select selectSeat from Seat where SeatID = '" + seat + "';", SQLConnection.Instance.GetConnection());
            row = (string)findRow.ExecuteScalar();
            select = Convert.ToInt32(findselect.ExecuteScalar());

            //getAirline name
            fstr = "\nSeat type: " + getClassName(cseat) + " \nRow: " + row + " Seat: " + select + "\n";

            SQLConnection.Instance.CloseConnection();

            return fstr;
        }


        private static string getClassName(string cname)
        {

            if (cname == "F")
            {
                cname = "First Class";
            }
            else if (cname == "B")
            {
                cname = "Business Class";
            }
            else
            {
                cname = "Economic Class";
            }

            return cname;
        }


        private static string getAge(string anum)
        {

            if (anum == "A")
            {
                anum = "Adult";
            }
            else if (anum == "C")
            {
                anum = "Child";
            }
            else
            {
                anum = "Infant";
            }

            return anum;
        }


        //private static int PassengerID;
        public static void setPassengerID(int pass)
        {
            PassengerID = pass;
        }

        public static int getPassengerID()
        {
            return PassengerID;
        }




    }
}
