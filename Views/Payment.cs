using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Airline_Semester_Project_attempt4
{
    public partial class Payment : Form
    {
        private int totalPayment;
        private int totalDiscount;

        public Payment()
        {
            InitializeComponent();
            getTotalDiscount();
            fillCards();
            getClass();
            getTotal();
            this.Show();
        }

        //variables to save the amount of passeners in each type of class
        private int FirstClassCount;
        private int BusinessCount;
        private int EconomicCount;
        private int discount = 10;

        /// <summary>
        /// Querys to find the amount of each type of passengers
        /// for example how many first class passengers were selected for the passenger 
        /// in this specific flight
        /// </summary>
        private void getClass()
        {
            SQLConnection.Instance.OpenConnection();

            MySqlCommand findFirstClass = new MySqlCommand("select count(Class) from Passenger where FlightID = '" + FlightP.getFlightNumber() + "' and AccountID = '" + AccountP.getAccountID() + "' and Class = 'F';", SQLConnection.Instance.GetConnection());
            MySqlCommand findBusinessClass = new MySqlCommand("select count(Class) from Passenger where FlightID = '" + FlightP.getFlightNumber() + "' and AccountID = '" + AccountP.getAccountID() + "' and Class = 'B';", SQLConnection.Instance.GetConnection());
            MySqlCommand findEconomicClass = new MySqlCommand("select count(Class) from Passenger where FlightID = '" + FlightP.getFlightNumber() + "' and AccountID = '" + AccountP.getAccountID() + "' and Class = 'E';", SQLConnection.Instance.GetConnection());

            FirstClassCount = Convert.ToInt32(findFirstClass.ExecuteScalar());
            BusinessCount = Convert.ToInt32(findBusinessClass.ExecuteScalar());
            EconomicCount = Convert.ToInt32(findEconomicClass.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();
        }


        /// <summary>
        /// Calculates the total for the passenger's flight
        /// </summary>
        private void getTotal()
        {
           totalPayment = (FirstClassCount * Price.getFirstClassPrice() + (BusinessCount * Price.getBusinessPrice()) + (EconomicCount * Price.getEconomicPrice()) - totalDiscount);
           total_textBox.Text = "$ " + totalPayment.ToString();
        }


        private void getTotalDiscount()
        {

          totalDiscount = Price.getDiscount() * discount;
          discount_textBox1.Text = "$ " + totalDiscount;
        }

        private void fillCards()
        {
            string master, visa, discover, american_express;
            master = "Master Card";
            visa = "Visa";
            discover = "Discovery";
            american_express = "American Express";

            cardtype_comboBox1.Items.Add(master);
            cardtype_comboBox1.Items.Add(visa);
            cardtype_comboBox1.Items.Add(discover);
            cardtype_comboBox1.Items.Add(american_express);

            cardtype_comboBox1.Text = master;
        }

        /// <summary>
        /// Saves the user's payment information into the database.
        /// Closes the Form and goes to reservation form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_payment_button_Click(object sender, EventArgs e)
        {
            if(cardnum_textbox.ToString() == "")
            {
                MessageBox.Show("Please enter the last 4 digit of the card number");
            }
            else if(cardowner_textBox1.ToString() == "")
            {
                MessageBox.Show("Please enter the owner of the card");
            }
             else if (cvc_textbox.ToString() == "")
             {
                 MessageBox.Show("Please enter the cvc");
             }
             else
             {
                if(cardnum_textbox.ToString().All(char.IsDigit) || cardnum_textbox.TextLength != 4)
                {
                    MessageBox.Show("Please enter a valid card owner");
                    cardnum_textbox.Text = "";
                }
                else if(cardowner_textBox1.ToString().All(char.IsLetter)) //PROBLEM. cardowner is allowing numbers
                {
                    MessageBox.Show("Please enter a correct card owner");
                    cardowner_textBox1.Text = "";
                }
                else if (cvc_textbox.ToString().All(char.IsDigit) || cvc_textbox.TextLength != 3)
                {
                    MessageBox.Show("Please enter a correct cvc");
                    cvc_textbox.Text = "";
                }
                else
                {
                    SQLConnection.Instance.OpenConnection();

                    string date = DateTime.Parse(carddateTimePicker1.Text).ToString("yyyy-MM-dd"); //shortens the selected date to date format in the database

                    MySqlCommand insertPayment = new MySqlCommand("insert into Fare values ('','" + totalPayment + "', '" + cardtype_comboBox1.Text + "', '" + cardnum_textbox.Text + "', '" + cardowner_textBox1.Text + "' , '" + date + "', '" + cvc_textbox.Text + "', '" + AccountP.getAccountID() + "', '" + FlightP.getFlightNumber() + "'); ", SQLConnection.Instance.GetConnection());
                    insertPayment.ExecuteNonQuery();

                    MySqlCommand findFareID = new MySqlCommand("Select FareID from Fare where Amount = '" + totalPayment + "' and FlightID = '" + FlightP.getFlightNumber() + "';", SQLConnection.Instance.GetConnection());

                    Price.setPaymentID(Convert.ToInt32(findFareID.ExecuteScalar()));
                    Price.setCharge(totalPayment);

                    SQLConnection.Instance.CloseConnection();

                    this.Close();
                    Reserve rs = new Reserve();
                }
             }

        }

    }
}
