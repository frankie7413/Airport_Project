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
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Airline_Semester_Project_attempt4
{
    public partial class Reserve : Form
    {
        public Reserve()
        {
            InitializeComponent();
            fillGrid();
            fillLabels();
            fillText();
            this.Show();
        }

        private string ticket;
        private string username;

        private string RandomStr()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", "");
            rStr = rStr.Substring(0, 5);
            rStr = rStr.ToUpper();
            return rStr;
        }

        public void fillLabels()
        {
            reserve_textBox1.ReadOnly = true;
            reserve_textBox1.Text = RandomStr();
            ticket = reserve_textBox1.Text;
            flight_label.Text = "From " + FlightP.getDepName() + " to " + FlightP.getArrName();
            reserve_label.Text += AccountP.getAccountName();
            payment_textBox2.Text = "$ " + Price.getCharge().ToString();
            
        }

        private void fillGrid()
        {
            PassengerContainer.loadPassengers(FlightP.getFlightNumber(), AccountP.getAccountID());
        }

        private void logoff_button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void account_button2_Click(object sender, EventArgs e)
        {
            resetFlight();
            this.Close();
            Account ac = new Account();
        }


        private void resetFlight()
        {
            int zero = 0;
            FlightP.setFlightNumber(zero);

        }


        private void fillText()
        {
            int numofpassengers = 0;
            int maxofpassengers = PassengerContainer.getNumPassenger();

            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "Showing "+ maxofpassengers + " Passenger(s) information: \n";

            while(numofpassengers < maxofpassengers)
            {
                richTextBox1.Text += "\nPassenger: " + ReserveP.getPassenger();

                richTextBox1.Text += "\nSeat Information: "+ ReserveP.getSeatInfo() + "\n";

                numofpassengers++;
            }

            SQLConnection.Instance.OpenConnection();

            insertReserve();
            insertTicket();

            SQLConnection.Instance.CloseConnection();

            fillEmail();

            MessageBox.Show("Email Confirmation of Reservation send shortly.");
        }


        private void insertReserve()
        {
            //pass on further 
            DateTime dateTime = DateTime.UtcNow.Date;
            string today = dateTime.ToString("d");
            string date = DateTime.Parse(today).ToString("yyyy-MM-dd");
            //Price.setPaymentID(AccountP.getAccountID());

            MySqlCommand reserveFlight = new MySqlCommand("insert into Reserve values('','" + date + "', '" + ticket + "', '" + AccountP.getAccountID() + "' , '" + Price.getPaymentID() + "', '" + FlightP.getFlightNumber() +"' );", SQLConnection.Instance.GetConnection());
            reserveFlight.ExecuteNonQuery();     
        }


        private void insertTicket()
        {

            //for all passengers you insert ticket number 
            MySqlCommand saveReserve = new MySqlCommand("Update Passenger Set TicketID = '"+ ticket +"' where FlightID = '"+ FlightP.getFlightNumber() +"' and AccountID = '"+ AccountP.getAccountID() +"';", SQLConnection.Instance.GetConnection());
            saveReserve.ExecuteNonQuery();
        }


        private void fillEmail()
        {

            if (string.IsNullOrEmpty(Customer.getUserName()))
            {

                Customer.setUserName(AccountP.getAccountID());
                username = Customer.getUserName();
            }
            else
            {
                username = Customer.getUserName();
            }

            //MessageBox.Show(Customer.getEmail());

            SendEmail(Customer.getEmail());
        }


        private void SendEmail(string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "airlinenorthwest@gmail.com";
            string password = "egkqycqgxiggelhh";

            string subject = "Reservation Confirmation";
            string body = "Hi,\nThis email to confirm that you have created a reservation" + reserve_label.Text;
            body += "\nReservation Code: " + reserve_textBox1.Text + " Payment: " + payment_textBox2.Text + " Flight: " + flight_label.Text + "\n "+ richTextBox1.Text;


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
