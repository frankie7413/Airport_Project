using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class Customer
    {
        //stores customers email and customerID
        private static int customerID;
        private static string email;
        private static string Username;

        //CustomerID
        public static void setCustomerID(int customer)
        {
            customerID = customer;
        }

        public static int getCustomerID()
        {
            return customerID;
        }


        //Email
        public static void setEmail(string mail)
        {
            email = mail;
        }


        //username
        public static string getUserName()
        {
            return Username;
        }


        public static void setUserName(int customerNo)
        {
            string name;

            SQLConnection.Instance.OpenConnection();
            MySqlCommand userID = new MySqlCommand("Select UserName from Customer where CustomerID = '" + customerNo + "';", SQLConnection.Instance.GetConnection());
            name = (string)userID.ExecuteScalar();
            SQLConnection.Instance.CloseConnection();

            Username = name;
            
        }

        //checks to see if the email is stored or not. If user logs in 
        //the email is not automatically stored so this catches the email.
        public static string getEmail()
        {
            if(string.IsNullOrEmpty(email))
            {
                SQLConnection.Instance.OpenConnection();
                MySqlCommand findEmail = new MySqlCommand("select Email from Customer where CustomerID = '"+ customerID +"' ;", SQLConnection.Instance.GetConnection());
                email = (string)findEmail.ExecuteScalar();
                SQLConnection.Instance.CloseConnection();
            }
            return email;
        }

    }
}
