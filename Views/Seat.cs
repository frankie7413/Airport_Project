using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class Seat
    {
        //stores class and seat where passenger is going to seat. 
        private static string classSeat;
        private static int seatPassenger; //seat number for passenger

        private char seatRow;
        private int seatNumber;
        private int available;
        
        public static int seatCount;
        public static Seat[] seatObject = new Seat[60];

        /// <summary>
        /// Finds seats according to flight and seat class passed into the function. 
        /// </summary>
        /// <param name="sc"></param>
        public static void loadSeats(string sc)
        {
            seatCount = 0;
            DataSet dsSeat = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand cmSeats = new MySqlCommand("select * from Seat where FlightID = '" + FlightP.getFlightNumber() + "' and classSeat = '" + sc + "'", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daSeats = new MySqlDataAdapter(cmSeats);
            daSeats.Fill(dsSeat);

            SQLConnection.Instance.CloseConnection();

            seatCount = dsSeat.Tables[0].Rows.Count;
            for(int i = 0; i < seatCount; i++)
            {
                seatObject[i] = new Seat();
                DataRow dataRow = dsSeat.Tables[0].Rows[i];
                seatObject[i].setSeatRow(Convert.ToChar(dataRow[3]));  //gets row letter (A) to char
                seatObject[i].setSeatNumber(Convert.ToInt32(dataRow[4]));          //gets seatnumber 
                seatObject[i].setAvailable(Convert.ToInt32(dataRow[5]));           //gets if seat taken 1 for taken 0 for available

            }
        }


        //assume not full
        public static int randomSeat(string sc, int rows, int flight)
        {

            string[] array = new string[rows];

            SQLConnection.Instance.OpenConnection();
            MySqlCommand rseat = new MySqlCommand("Select * from Seat where FlightID = '" + flight + "' and classSeat = '" + sc + "';", SQLConnection.Instance.GetConnection());
            MySqlDataReader myReader;
            myReader = rseat.ExecuteReader();
            int seatID;
            int available;
            string seat;
            int i = 0;
            while (myReader.Read())
            {
                seatID = myReader.GetInt32("SeatID");
                available = myReader.GetInt32("Available");
                seat = seatID + " " + available;
                array[i] = seat;
                i++;
            }

            myReader.Close();
            //SeatID 	FlightID 	classSeat 	Row 	selectSeat 	Available
            //fill array of seats
            //run algorithm to find empty

            //int count = 0;
            bool found = false;
            Random random = new Random();
            int randomNumber = random.Next(0, rows);
            int foundSeat = 0;
            string display = "";
            while (!found)
            {
                display = array[randomNumber];
                string[] strArr = null;
                char[] splitchar = { ' ' };
                strArr = display.Split(splitchar);

                seatID = Convert.ToInt32(strArr[0]);
                available = Convert.ToInt32(strArr[1]);

                if (available == 0)
                {
                    found = true;
                    foundSeat = seatID;
                }
                else
                {
                    randomNumber = random.Next(0, rows);
                }
            }

            SQLConnection.Instance.CloseConnection();

            return foundSeat;
        }


        /// <summary>
        /// gets the seat row 
        /// </summary>
        /// <param name="r"></param>
        public void setSeatRow(char r)
        {
            seatRow = r;
        }

        /// <summary>
        /// returns seatRow
        /// </summary>
        /// <returns></returns>
        public char getSeatRow()
        {
            return seatRow;
        }

        /// <summary>
        /// sets seatNumber
        /// </summary>
        /// <param name="s"></param>
        public void setSeatNumber(int s)
        {
            seatNumber = s;
        }

        /// <summary>
        /// returns seatNumber
        /// </summary>
        /// <returns></returns>
        public int getSeatNumber()
        {
            return seatNumber;
        }

        /// <summary>
        /// sets available where 0 is available and 1 is taken
        /// </summary>
        /// <param name="a"></param>
        public void setAvailable(int a)
        {
            available = a;
        }

        /// <summary>
        /// return available
        /// </summary>
        /// <returns></returns>
        public int getAvailable()
        {
            return available;
        }


        //private string classSeat
        public static void setClassSeat(string section)
        {
            classSeat = section;
        }

        public static string getClassSeat()
        {
            return classSeat;
        }

        //private int seatPassenger
        public static void setSeatPassenger(int num)
        {
            seatPassenger = num;
        }

        public static int getSeatPassenger()
        {
            return seatPassenger;
        }

    }
}
