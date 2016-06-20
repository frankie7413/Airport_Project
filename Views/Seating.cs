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
    public partial class Seating : Form
    {
        //public static string classSeat; ///

        public Seating()
        {       
            InitializeComponent();
            next_seat_button.Enabled = false;
            getPassenger();      
            fillPrices();
            this.Show();
        }

        /// <summary>
        /// Gets passsenger first and last name to display in the label of the form.
        /// </summary>
        private void getPassenger()
        {
            PassengerContainer.setPassengerID(PassengerContainer.accessPassenger());

            string FirstName, LastName;

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findFirst = new MySqlCommand("select FirstName from Passenger where PassengerID = '" + PassengerContainer.getPassengerID() + "';", SQLConnection.Instance.GetConnection());
            FirstName = (string)findFirst.ExecuteScalar();

            MySqlCommand findLast = new MySqlCommand("select LastName from Passenger where PassengerID = '" + PassengerContainer.getPassengerID() + "';", SQLConnection.Instance.GetConnection());
            LastName = (string)findLast.ExecuteScalar();

            pass_info_label.Text = "Passenger: " + FirstName + " " + LastName;

            SQLConnection.Instance.CloseConnection();
        }

        /// <summary>
        /// Gets prices for the label to display in the form
        /// </summary>
        private void fillPrices()
        {
            economicclass_button.Text += " ($" + Price.getEconomicPrice() + ")";
            businessclass_button.Text += " ($" + Price.getBusinessPrice() +")";
            firstclass_button.Text += " ($" + Price.getFirstClassPrice() + ")";
        }

        /// <summary>
        /// enables seat button
        /// </summary>
        private void checkStatus()
        {
                next_seat_button.Enabled = true;    
        }

        /// <summary>
        /// checks if button is pressed and saves classSeat to use in seat available form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstclass_button_Click(object sender, EventArgs e)
        {
            if (firstclass_button.BackColor == Color.GhostWhite)
            {
                firstclass_button.BackColor = Color.Beige;
                businessclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;
                checkStatus();
                Seat.setClassSeat("F");

            }
            else if(firstclass_button.BackColor == Color.Yellow)
            {
                firstclass_button.BackColor = Color.GhostWhite;
                businessclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;

            }
            
        }

        /// <summary>
        /// checks if button is pressed and saves classSeat to use in seat available form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void middleclass_button_Click(object sender, EventArgs e)
        {
            if (businessclass_button.BackColor == Color.GhostWhite)
            {
                businessclass_button.BackColor = Color.Beige;
                firstclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;
                checkStatus();
                Seat.setClassSeat("B");
            }
            else if (businessclass_button.BackColor == Color.Yellow)
            {
                businessclass_button.BackColor = Color.GhostWhite;
                firstclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;
            }
        }

        /// <summary>
        /// checks if button is pressed and saves classSeat to use in seat available form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularclass_button_Click(object sender, EventArgs e)
        {
            if (economicclass_button.BackColor == Color.GhostWhite)
            {
                economicclass_button.BackColor = Color.Beige;
                firstclass_button.BackColor = Color.GhostWhite;
                businessclass_button.BackColor = Color.GhostWhite;
                checkStatus();
                Seat.setClassSeat("E");
            }
            else if (economicclass_button.BackColor == Color.Yellow)
            {
                economicclass_button.BackColor = Color.GhostWhite;
                firstclass_button.BackColor = Color.GhostWhite;
                businessclass_button.BackColor = Color.GhostWhite;
            }
        }

        /// <summary>
        /// Next Seat button is click coses the form and opens the seat available 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_seat_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Seat_Available nfp = new Seat_Available();
        }
    }
}
