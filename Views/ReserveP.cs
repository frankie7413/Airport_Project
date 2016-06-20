using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class ReserveP
    {
        //private static int ReserveID;  //store the most recent made flight 
        private static string ticketID; //only saves ticket number when 
                                    //updateing reservations for now

        private static int flightID;

        private static int tempID;
        private static int numberofReserves;

        public static string getPassenger()
        {
            string pstr;
           
            string firstname, midname, lastname, age, gender, birthdate;
            DateTime birth;
            tempID = PassengerContainer.accessPassenger();

            DataSet dsPassenger = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand passData = new MySqlCommand();
            MySqlDataAdapter daPass = new MySqlDataAdapter("select * from Passenger where PassengerID = '"+ tempID +"';", SQLConnection.Instance.GetConnection());
            daPass.Fill(dsPassenger);

            SQLConnection.Instance.CloseConnection();

            DataRow dataRow = dsPassenger.Tables[0].Rows[0];
            firstname = (string)dataRow[1];
            midname = (string)dataRow[2];
            lastname = (string)dataRow[3];
            age = (string)dataRow[4];
            gender = (string)dataRow[5];
            birth = (DateTime)dataRow[6];

            PassengerContainer.removePassengers();

            string date = birth.ToString("d");
            birthdate = DateTime.Parse(date).ToString("MM-dd-yyyy");

            if(string.IsNullOrEmpty(midname))
            {
                midname = " ";
            }
            else
            {
                midname = " " + midname + " ";
            }

            age = getAge(age);

            pstr = firstname + midname +  lastname + "\nAge: "+ age + " Gender: " + gender + " Birthdate: " + birthdate;

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
            MySqlCommand findRow = new MySqlCommand("select Row from Seat where SeatID = '"+ seat +"';", SQLConnection.Instance.GetConnection());
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
            
            if(cname == "F")
            {
                cname = "First Class";
            }
            else if(cname == "B")
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



        ////reserve
        //public static void setReserveID(int res)
        //{
        //    ReserveID = res;
        //}

        //public static int getReserveID()
        //{
        //    return ReserveID;
        //}

        //if empty returns true if not empty returns false
        public static bool isEmptyReseve()
        {
            bool found = true;
            int check;

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findReserves = new MySqlCommand("select count(AccountID) from Reserve where AccountID = '" + AccountP.getAccountID() + "';", SQLConnection.Instance.GetConnection());
            check = Convert.ToInt32(findReserves.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();

            if (check != 0)
            {
                found = false;
                numberofReserves = check;
            }

            return found;
        }

        public static int getNumberOfReserves()
        {
            return numberofReserves;
        }


        //ticket 
        public static void setTicketID(string ticket)
        {
            ticketID = ticket;
        }

        public static string getTicketID()
        {
            return ticketID;
        }


        public static string getReserveDate(string ticket)
        {
            DateTime reserveDate;
            SQLConnection.Instance.OpenConnection();
            MySqlCommand findDate = new MySqlCommand("Select dateReserve from Reserve where ticketNo = '"+ ticket +"';", SQLConnection.Instance.GetConnection());
            reserveDate = (DateTime)findDate.ExecuteScalar();

            string date = reserveDate.ToString("MM-dd-yyyy");

            SQLConnection.Instance.CloseConnection();

            return date;
        }



        //find flight from reservation
        public static void setFlightNumber(string ticket)
        {
            SQLConnection.Instance.OpenConnection();
            MySqlCommand flight = new MySqlCommand("Select FlightID from Reserve where ticketNo = '"+ ticket +"';", SQLConnection.Instance.GetConnection());
            flightID = Convert.ToInt32(flight.ExecuteScalar());
            SQLConnection.Instance.CloseConnection();
        }

        public static int getFlightNumber()
        {
            return flightID;
        }


    }
}
