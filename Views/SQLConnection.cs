using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Airline_Semester_Project_attempt4
{

    //http://dev.mysql.com/downloads/connector/net/ if you get problems with not having Mysql.data installed

    /// <summary>
    /// Singleton class for SQLConnection so we only call it once per form and class to open, close and get
    /// connections in our sql commands to database
    /// 
    /// When applied to a class, the sealed modifier prevents other classes from inheriting from it. In the following example, class B inherits from class A, but no class can inherit from class B.
    /// class A {}    
    //sealed class B : A { }
    /// </summary>
    public sealed class SQLConnection    //singleton class takes care of our connection needs throughout each form
    {


        //you must provide your own server information here to run the program!
        //"server= <ip address>;uid=<userid>;" + "pwd=<password>;database=<mysqldatabase name>;"
        private const string myConnectionString = "server=;uid=;" +
            "pwd=;database=;";
       
        private MySqlConnection connection;

        private static readonly SQLConnection instance = new SQLConnection();

        public static SQLConnection Instance
        {
            get
            {
                return instance;
            }
        }

        static SQLConnection()
        {

        }

        // do constructor logic here
        public SQLConnection()
        {
            try
            {
                connection = new MySqlConnection(myConnectionString);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally // if connection fails, close it.
            {
                if (connection != null)
                    connection.Close();
            }

            //connection.ConnectionString = myConnectionString;
        }


        // Open connection
        public void OpenConnection()
        {
            connection.Open();
        }

        // Close connection
        public void CloseConnection()
        {
            connection.Close();
        }

        // Get the connection

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}