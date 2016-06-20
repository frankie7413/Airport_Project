using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class FlightP
    {
        private static int flightNumber;  //track of user flight
        private static string depName, arrName;
        private static int airplaneID;

        ///user generated variables to keep track

        //flight number track of user selected 
        public static void setFlightNumber(int flight)
        {
            flightNumber = flight;
        }

        public static int getFlightNumber()
        {
            return flightNumber;
        }

        //one way - departure city name
        public static void setDepName(string dep)
        {
            depName = dep;
        }

        public static string getDepName()
        {
            return depName;
        }

        //one way - arrival city name
        public static void setArrName(string arr)
        {
            arrName = arr;
        }

        public static string getArrName()
        {
            return arrName;
        }

        //airplaneID
        public static void setAirPlaneID(int plane)
        {
            airplaneID = plane;
        }

        public static int getAirPlaneID()
        {
            return airplaneID;
        }


    }
}
