using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class Airplane
    {
        private static int column = 6;
        private static int total;

        public static int getNumberofRows(string section)
        {
            int num;
            string sname = getClassName(section);

            SQLConnection.Instance.OpenConnection();
            MySqlCommand findRows = new MySqlCommand("select "+ sname +" from Airplane where AirplaneID = '"+ FlightP.getAirPlaneID() +"';", SQLConnection.Instance.GetConnection());
            num = Convert.ToInt16(findRows.ExecuteScalar());
            total = num;
            num = num / column;
            SQLConnection.Instance.CloseConnection();

            return num;
        }



        public static int getTotalSeats()
        {
            return total;
        }

        private static string getClassName(string cname)
        {

            if (cname == "F")
            {
                cname = "First";
            }
            else if (cname == "B")
            {
                cname = "Business";
            }
            else
            {
                cname = "Econ";
            }

            return cname;
        }



    }
}
