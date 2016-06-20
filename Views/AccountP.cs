using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class AccountP
    {
        //stores user accountID
        private static int accountID;

        //variables to store inside accountP object 
        private static string FirstName, MidName, LastName, Address, State, Phone, City;
        private int Zipcode;


        public static AccountP[] accountObject = new AccountP[1];

        public static void setAccountID(int account)
        {
            accountID = account;
        }

        public static int getAccountID()
        {
            return accountID;
        }

        public static void loadAccount()
        {
            DataSet dsAccount = new DataSet();

            SQLConnection.Instance.OpenConnection();

            MySqlCommand AccountData = new MySqlCommand("select * from Account where accountID = '"+ accountID +"';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daAccount = new MySqlDataAdapter(AccountData);
            daAccount.Fill(dsAccount);

            SQLConnection.Instance.CloseConnection();

            accountObject[0] = new AccountP();
            DataRow dataRow = dsAccount.Tables[0].Rows[0];

            accountObject[0].setFirstName((string)dataRow[2]);
            accountObject[0].setMidName((string)dataRow[3]);
            accountObject[0].setLastName((string)dataRow[4]);
            accountObject[0].setAddress((string)dataRow[5]);
            accountObject[0].setState((string)dataRow[6]);
            accountObject[0].setZipCode(Convert.ToInt32(dataRow[7]));
            accountObject[0].setPhone((string)dataRow[8]);
            accountObject[0].setCity((string)dataRow[9]);
        }

        //return string with frist and last name
        public static string getAccountName()
        {
            string fullname;

            fullname = " "+ FirstName + " " + LastName;

            return fullname;
        }


        //firstname
        public void setFirstName(string first)
        {
            FirstName = first;
        }

        public string getFirstName()
        {
            return FirstName;
        }

        //midname
        public void setMidName(string mid)
        {
            MidName = mid;
        }

        public string getMidName()
        {
            return MidName;
        }

        //lastname
        public void setLastName(string last)
        {
            LastName = last;
        }

        public string getLastName()
        {
            return LastName;
        }

        //Address
        public void setAddress(string adr)
        {
            Address = adr;
        }

        public string getAddress()
        {
            return Address;
        }


        //state
        public void setState(string st)
        {
            State = st;
        }

        public string getState()
        {
            return State;
        }

        //zipconde int
        public void setZipCode(int zip)
        {
            Zipcode = zip;
        }

        public int getZipCode()
        {
            return Zipcode;
        }

        //phone string 
        public void setPhone(string ph)
        {
            Phone = ph;
        }

        public string getPhone()
        {
            return Phone;
        }

        //city 
        public void setCity(string ct)
        {
            City = ct;
        }

        public string getCity()
        {
            return City;
        }

    }
}
