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
using System.Windows;


namespace Airline_Semester_Project_attempt4
{
    public partial class Reserve_Update : Form
    {
        public Reserve_Update()
        {
            InitializeComponent();
            submit_button.Enabled = false;
            fillReserveBox();
            fillGrid();
            this.Show();
        }

        private static List<string> flightsList = new List<string>();
        private static int fnumber;
        private static string tnumber;

        private void fillReserveBox()
        {
            string ticket;
            int flightNum;
            string name;

            SQLConnection.Instance.OpenConnection();

            MySqlCommand findSlots = new MySqlCommand("Select * from Reserve where AccountID = '" + AccountP.getAccountID() + "';", SQLConnection.Instance.GetConnection());
            MySqlDataReader myReader;

            myReader = findSlots.ExecuteReader();

            while (myReader.Read())
            {
                ticket = myReader.GetString("ticketNo");
                flightNum = myReader.GetInt32("FlightID");

                name = ticket + " " + flightNum;

                reservations_comboBox1.Items.Add(ticket);
                flightsList.Add(name);
            }

            myReader.Close();

            SQLConnection.Instance.CloseConnection();
            
        }

        private void removeFlight()
        {
            int remove = Math.Min(flightsList.Count, 1);
            flightsList.RemoveRange(0, remove);
        }

        private bool emptyFlight()
        {
            bool found = false;

            if (flightsList.Count() == 0)
            {
                found = true;
            }

            return found;
        }

        private void accesssFlight()
        {
            string display = "";

            if (flightsList.Count != 0)
            {
                display = flightsList.ElementAt(0);
                string[] strArr = null;
                char[] splitchar = { ' ' };
                strArr = display.Split(splitchar);

                tnumber = strArr[0];
                fnumber = Convert.ToInt32(strArr[1]);
            }
        }


        private void fillGrid()
        {
            accesssFlight();
            PassengerInfo.loadPassengersReserve(tnumber);
            FlightContainer.loadFlight(fnumber);
            fillText();
        }

        private void fillText()
        {
            int numofpassengers = 0;
            int maxofpassengers = PassengerInfo.getNumPassengers();

            reservations_richTextBox1.Text += "Ticket: " + tnumber + " Date Reserved: " + ReserveP.getReserveDate(tnumber) +"\nFlignt number is: " + fnumber + " Airline is " + FlightContainer.flightObject[0].getAirline() +
                " from " + FlightContainer.flightObject[0].getDepart() +  
                " to "+ FlightContainer.flightObject[0].getArrive() + "\nPrice: $"+ Price.getReserveAmount(tnumber);
            reservations_richTextBox1.Text += " Showing " + maxofpassengers + " Passenger(s) information: \n";

            while(numofpassengers < maxofpassengers)
            {
                reservations_richTextBox1.Text += "\nPassenger: " + PassengerInfo.getPassenger();
                reservations_richTextBox1.Text += "\nSeat Information: " + PassengerInfo.getSeatInfo()+ "\n";

                numofpassengers++;
            }

            removeFlight();

            if(!emptyFlight())
            {
                fillGrid();
            }
        }

        private void reservations_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            submit_button.Enabled = true;
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            //string ticket = reservations_comboBox1.Text;
            //MessageBox.Show(ticket);
            ReserveP.setTicketID(reservations_comboBox1.Text);
            Reserve_Changes alter = new Reserve_Changes();
            this.Close();
        }

        private void cancel_button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Account refresh = new Account();
        }




       

    }
}
