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
using System.Net;
using System.Net.Mail;

namespace Airline_Semester_Project_attempt4
{
    public partial class Reserve_Changes : Form 
    {
        public Reserve_Changes()
        {
            InitializeComponent();
            submit_button1.Enabled = false;
            fillLabels();
            fillComboBox();
            getPassengerInfo();
            fillText();
            this.Show();
        }

        private static string ticketID;  //can only be change by using a function

        public static void setTicketID(string ticket)
        {
            ticketID = ticket;
        }


        private void cancel_button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Account back = new Account();
        }


        private void fillLabels()
        {

            setTicketID(ReserveP.getTicketID());

            //MessageBox.Show(ticketID);

            SQLConnection.Instance.OpenConnection();

            int flight;
            MySqlCommand findFlight = new MySqlCommand("Select FlightID from Reserve where ticketNo = '"+ ticketID +"';", SQLConnection.Instance.GetConnection());
            flight = Convert.ToInt32(findFlight.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();

            FlightContainer.loadFlight(flight);

            flight_label1.Text += " #" + FlightContainer.flightObject[0].getFlightNo() + " " + FlightContainer.flightObject[0].getDepart() +
                " to " + FlightContainer.flightObject[0].getArrive() + " Price: $" + Price.getReserveAmount(ticketID);
        }


        private void getPassengerInfo()
        {
            PassengerInfo.loadPassengersReserve(ticketID);
        }
        private int countPassengers;

        private void fillText()
        {
            int numofpassengers = 0;
            countPassengers = PassengerInfo.getNumPassengers();
            int maxofpassengers = countPassengers;
            reserve_richTextBox1.ReadOnly = true;
            reserve_richTextBox1.Text = "Showing " + maxofpassengers + " Passenger(s) information: \n";

            while(numofpassengers < maxofpassengers)
            {
                reserve_richTextBox1.Text += "\nPassenger: " + PassengerInfo.getPassenger();
                reserve_richTextBox1.Text += "\nSeat Information: " + PassengerInfo.getSeatInfo() + "\n";
                numofpassengers++;
            }

            reserve_richTextBox1.Text += "\n";


        }

        private string updatePassenger = "Update Passenger(s)";
        private string removePassenger = "Remove Passenger(s)";
        private string rescheduleFlight = "Reschedule Flight";
        private string deleteReserve = "Delete Reservation";

        private void fillComboBox()
        {
            changes_comboBox1.Items.Add(updatePassenger);
            changes_comboBox1.Items.Add(removePassenger);
            changes_comboBox1.Items.Add(deleteReserve);
            changes_comboBox1.Items.Add(rescheduleFlight);

            update_label1.Text += " " + ticketID;
        }

        private void submit_button1_Click(object sender, EventArgs e)
        {
            //something

            if(changes_comboBox1.Text == updatePassenger)
            {
                PassengerInfo.loadPassengersReserve(ticketID); 
                Update_Passenger change = new Update_Passenger();
                this.Close();
            }
            else if(changes_comboBox1.Text == removePassenger)
            {
                if(countPassengers == 1)
                {
                    MessageBox.Show("Choose Remove Reservation");
                }
                else
                {
                    PassengerInfo.loadPassengersReserve(ticketID);
                    Remove_Passenger change = new Remove_Passenger();
                    this.Close();
                }

            }
            else if (changes_comboBox1.Text == rescheduleFlight)
            {
                Flight_Update set = new Flight_Update();
                this.Close();

            }
            else if(changes_comboBox1.Text == deleteReserve)
            {

                createBox();
                this.Close();
                Account check = new Account();

            }

        }

        private void changes_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            submit_button1.Enabled = true;
        }


        private static void createBox()
        {
            string boxText = "Do you want to delete Reservation?";
            string caption = "Reservation Cancellation";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(boxText, caption, button);

            if(result == DialogResult.Yes)
            {         
                deleteReservation();
                fillEmail();
            }

        }


        private static int fareID;

        private static void deleteReservation()
        {
            PassengerInfo.loadPassengersReserve(ticketID);
            fareID = Price.getReserveFareID(ticketID);

            SQLConnection.Instance.OpenConnection();

            fillPassengers();
            removeReservation(ticketID);
            removeFare(fareID);

            SQLConnection.Instance.CloseConnection();
            

            MessageBox.Show("Reservation Succesfully Removed.");
           
        }

        private static void fillPassengers()
        {
            int passID = PassengerInfo.accessPassenger();
            while(!PassengerInfo.emptyPassenger())
            {                 
                ResetSeat(passID);
                deletePassengers(passID);
                PassengerInfo.removePassengers();
            }

        }

        private static void ResetSeat(int num)
        {
            int seatID;
            MySqlCommand reset = new MySqlCommand("Select SeatID from Passenger where PassengerID = '" + num + "';", SQLConnection.Instance.GetConnection());
            seatID = Convert.ToInt32(reset.ExecuteScalar());

            MySqlCommand findseat = new MySqlCommand("UPDATE Seat Set Available = 0 where SeatID = '" + seatID + "';", SQLConnection.Instance.GetConnection());
            findseat.ExecuteNonQuery();
        }


        private static void deletePassengers(int num)
        {
            MySqlCommand remove = new MySqlCommand("DELETE from Passenger where PassengerID = '"+ num +"';", SQLConnection.Instance.GetConnection());
            remove.ExecuteNonQuery();
        }


        private static void removeReservation(string ticket)
        {
            MySqlCommand remove = new MySqlCommand("DELETE from Reserve where ticketNO = '"+ ticket +"';", SQLConnection.Instance.GetConnection());
            remove.ExecuteNonQuery();
        }

        private static void removeFare(int fare)
        {
            MySqlCommand remove = new MySqlCommand("DELETE from Fare where FareID = '" + fare + "';", SQLConnection.Instance.GetConnection());
            remove.ExecuteNonQuery();
        }


        private static void fillEmail()
        {
            //FlightContainer.loadFlight(FlightP.getFlightNumber());
            SendEmail(Customer.getEmail());
        }


        private static void SendEmail(string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "airlinenorthwest@gmail.com";
            string password = "egkqycqgxiggelhh";
            
            string subject = "Reservation Remove";
            string body = "Hi,\nThis email to confirm that reservation " + ticketID + " has been removed from your account " + AccountP.getAccountName();

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.

                    //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                    //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
