using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class PassengerContainer
    {

        private static List<int> passengerList = new List<int>(); //check 2
        private static int passengerCount;  //took static off
        private static int AdultPassengers;
        private static int ChildPassengers;
        private static int InfantPassengers;
        private static int PassengerID;

        /// <summary>
        /// Finds the Passengers accourding to the acocuntID and FlightID from the user and loads the passengers into a list.
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="account"></param>
        public static void loadPassengers(int flight, int account)
        {
            passengerCount = 0;
            DataSet dsPasssenger = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findPassengers = new MySqlCommand("select * from Passenger where FlightID = '" + flight + "' and AccountID = '" + account + "';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daPassenger = new MySqlDataAdapter(findPassengers);
            daPassenger.Fill(dsPasssenger);

            SQLConnection.Instance.CloseConnection();

            passengerCount = dsPasssenger.Tables[0].Rows.Count;
            for(int i = 0; i< passengerCount; i++)
            {
                DataRow dataRow = dsPasssenger.Tables[0].Rows[i];

                passengerList.Add((Convert.ToInt32(dataRow[0])));
              
            }
        }

        ///passsenger information
        //private static string firstName, midName, lastName, Age, Gender, seatClass;
        //private static DateTime birthday;



        public static int getNumPassenger()
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

            if(passengerList.Count() == 0)
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


        //private int adultPassengers;
        public static void setAdultPassengers(int adult)
        {
            AdultPassengers = adult;
        }

        public static int getAdultPassengers()
        {
            return AdultPassengers;
        }

        //private int childPassengers;
        public static void setChildPassengers(int child)
        {
            ChildPassengers = child;
        }

        public static int getChildPassengers()
        {
            return ChildPassengers;
        }

        //private int infantPassengers;
        public static void setInfantPassengers(int infant)
        {
            InfantPassengers = infant;
        }

        public static int getInfantPassengers()
        {
            return InfantPassengers;
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
