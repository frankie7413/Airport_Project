using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    class Price
    {
        private static int paymentID;
        private static int FirstClassPrice;
        private static int BusinessPrice;
        private static int EconomicPrice;
        private static int totalCharge;
        private static int totalAmount;
        private static int discount;

        public static void loadPrices(int fnumber)
        {
            DataSet dsPayment = new DataSet();

            SQLConnection.Instance.OpenConnection();
            MySqlCommand findPrices = new MySqlCommand("select * from Flight where FlightID = '" + fnumber + "';", SQLConnection.Instance.GetConnection());
            MySqlDataAdapter daPayment = new MySqlDataAdapter(findPrices);
            daPayment.Fill(dsPayment);

            SQLConnection.Instance.CloseConnection();

            DataRow dataRow = dsPayment.Tables[0].Rows[0];
            FirstClassPrice = Convert.ToInt32(dataRow[11]);
            BusinessPrice = Convert.ToInt32(dataRow[10]);
            EconomicPrice = Convert.ToInt32(dataRow[9]);
        }


        //only use from reservation forms not from payment form
        public static int getReserveAmount(string ticket)
        {
            SQLConnection.Instance.OpenConnection();

            int fareID;
            MySqlCommand findFare = new MySqlCommand("Select FareID from Reserve where ticketNo = '" + ticket + "';", SQLConnection.Instance.GetConnection());
            fareID = Convert.ToInt32(findFare.ExecuteScalar());

            MySqlCommand amount = new MySqlCommand("Select Amount from Fare where FareID = '" + fareID + "';", SQLConnection.Instance.GetConnection());
            totalAmount = Convert.ToInt32(amount.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();

            return totalAmount;
        }


        public static int getReserveFareID(string ticket)
        {
            SQLConnection.Instance.OpenConnection();

            int fareID;
            MySqlCommand findFare = new MySqlCommand("Select FareID from Reserve where ticketNo = '" + ticket + "';", SQLConnection.Instance.GetConnection());
            fareID = Convert.ToInt32(findFare.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();
            return fareID;

        }


        public static int getFirstClassPrice()
        {
            return FirstClassPrice;
        }

        public static int getBusinessPrice()
        {
            return BusinessPrice;
        }

        public static int getEconomicPrice()
        {
            return EconomicPrice;
        }


        //paymentID
        public static void setPaymentID(int account)
        {
            paymentID = account;

        }

        public static int getPaymentID()
        {
            return paymentID;
        }

        //totalprice of flight
        public static void setCharge(int total)
        {
            totalCharge = total;
        }

        public static int getCharge()
        {
            return totalCharge;
        }

        //track of discounts
        public static void resetDiscount()
        {
            discount = 0;
        }


        public static void Discount()
        {
            discount++;
        }

        public static int getDiscount()
        {
            return discount;
        }


    }
}
