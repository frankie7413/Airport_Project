using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class FlightContainer
    {

        private static int flightNo;  //user for dataset and other functions 
        private static string airline, departID, arriveID;


        //public static FlightP[] flightObject = new FlightP[1];
        public static FlightContainer[] flightObject = new FlightContainer[1];

        public static void loadFlight(int number)
        {
            DataSet dsFlight = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand flightData = new MySqlCommand("select * from Flight where FlightID = '" + number + "';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daFlight = new MySqlDataAdapter(flightData);
            daFlight.Fill(dsFlight);

            SQLConnection.Instance.CloseConnection();

            flightObject[0] = new FlightContainer();
            DataRow dataRow = dsFlight.Tables[0].Rows[0];

            flightObject[0].setFlightNo(Convert.ToInt32(dataRow[0]));
            flightObject[0].setDepart((string)dataRow[1]);
            flightObject[0].setArrive((string)dataRow[2]);
            flightObject[0].setAirline((string)dataRow[3]);
        }


        ////dataset functions 
        //FlightID 	departID 	arriveID 	airline

        //flight number for dataset
        public void setFlightNo(int flight)
        {
            flightNo = flight;
        }

        public int getFlightNo()
        {
            return flightNo;
        }

        //departure city
        public void setDepart(string dep)
        {
            departID = dep;
        }

        public string getDepart()
        {
            return departID;
        }

        //arrival city
        public void setArrive(string arr)
        {
            arriveID = arr;
        }

        public string getArrive()
        {
            return arriveID;
        }

        //airline
        public void setAirline(string air)
        {
            airline = air;
        }

        public string getAirline()
        {
            return airline;
        }


    }
}
