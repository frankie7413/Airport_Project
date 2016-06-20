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
    public partial class Seating_Update : Form
    {
        public Seating_Update()
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
            PassengerInfo.setPassengerID(PassengerInfo.accessPassenger());
            PassengerInfo.LoadPassengerInfo(PassengerInfo.getPassengerID());
            pass_info_label.Text = "Passenger: " + PassengerInfo.passengerObject[0].getFirstName() + " " + PassengerInfo.passengerObject[0].getLastName();
        }

        /// <summary>
        /// Gets prices for the label to display in the form
        /// </summary>
        private void fillPrices()
        {
            economicclass_button.Text += " ($" + Price.getEconomicPrice() + ")";
            businessclass_button.Text += " ($" + Price.getBusinessPrice() + ")";
            firstclass_button.Text += " ($" + Price.getFirstClassPrice() + ")";
        }

        /// <summary>
        /// enables seat button
        /// </summary>
        private void checkStatus()
        {
            next_seat_button.Enabled = true;
        }

        private void firstclass_button_Click_1(object sender, EventArgs e)
        {
            if (firstclass_button.BackColor == Color.GhostWhite)
            {
                firstclass_button.BackColor = Color.Beige;
                businessclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;
                checkStatus();
                Seat.setClassSeat("F");

            }
            else if (firstclass_button.BackColor == Color.Yellow)
            {
                firstclass_button.BackColor = Color.GhostWhite;
                businessclass_button.BackColor = Color.GhostWhite;
                economicclass_button.BackColor = Color.GhostWhite;

            }
        }

        private void businessclass_button_Click(object sender, EventArgs e)
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

        private void economicclass_button_Click(object sender, EventArgs e)
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

        private void next_seat_button_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Seat_Available_Update nfp = new Seat_Available_Update();
        }


    }
}
