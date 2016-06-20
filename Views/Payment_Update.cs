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
    public partial class Payment_Update : Form
    {
        public Payment_Update()
        {
            InitializeComponent();
            getTotalDiscount();
            getClass();
            getNewTotal();    
            getOldTotal();
            this.Show();
        }


        private int totalPayment;
        private int FirstClassCount;
        private int BusinessCount;
        private int EconomicCount;
        private string ticket = ReserveP.getTicketID();
        private int discount = 10;
        private int totalDiscount;

        private void getClass()
        {
            SQLConnection.Instance.OpenConnection();
            

            MySqlCommand findFirstClass = new MySqlCommand("select count(Class) from Passenger where TicketID = '"+ ticket +"' and Class = 'F';", SQLConnection.Instance.GetConnection());
            MySqlCommand findBusinessClass = new MySqlCommand("select count(Class) from Passenger where TicketID = '" + ticket + "' and Class = 'B';", SQLConnection.Instance.GetConnection());
            MySqlCommand findEconomicClass = new MySqlCommand("select count(Class) from Passenger where TicketID = '" + ticket + "' and Class = 'E';", SQLConnection.Instance.GetConnection());

            FirstClassCount = Convert.ToInt32(findFirstClass.ExecuteScalar());
            BusinessCount = Convert.ToInt32(findBusinessClass.ExecuteScalar());
            EconomicCount = Convert.ToInt32(findEconomicClass.ExecuteScalar());

            SQLConnection.Instance.CloseConnection();
        }

        private void getNewTotal()
        {
            totalPayment = (FirstClassCount * Price.getFirstClassPrice() + (BusinessCount * Price.getBusinessPrice()) + (EconomicCount * Price.getEconomicPrice()) - totalDiscount);
            newtotal_textBox.Text = "$ " + totalPayment.ToString();
        
        }

        private void getTotalDiscount()
        {
            totalDiscount = Price.getDiscount() * discount;
            discount_textBox1.Text = "$ " + totalDiscount;
        }

        private void getOldTotal()
        {
            oldtotal_textBox1.Text = "$ " + Price.getReserveAmount(ticket).ToString();
        }




        private void next_payment_button_Click(object sender, EventArgs e)
        {
            int fareID = Price.getReserveFareID(ticket);

            SQLConnection.Instance.OpenConnection();

            MySqlCommand updateFare = new MySqlCommand("UPDATE Fare set Amount = '"+ totalPayment +"' where FareID = '"+ fareID +"';", SQLConnection.Instance.GetConnection());
            updateFare.ExecuteNonQuery();

            MySqlCommand updateReserve = new MySqlCommand("UPDATE Reserve set FlightID = '" + FlightP.getFlightNumber() + "' where ticketNo = '" + ticket + "';", SQLConnection.Instance.GetConnection());
            updateReserve.ExecuteNonQuery();

            SQLConnection.Instance.CloseConnection();

            fillEmail();
            MessageBox.Show("Email Confirmation of Flight Change will be shortly send");

            Account back = new Account();
            this.Close();

        }



        private void fillEmail()
        {
            FlightContainer.loadFlight(FlightP.getFlightNumber());
            SendEmail(Customer.getEmail());
        }


        private void SendEmail(string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "airlinenorthwest@gmail.com";
            string password = "egkqycqgxiggelhh";

            string subject = "Reservation Flight Change";
            string body = "Hi,\nThis email to confirm that reservation" + ReserveP.getTicketID() + "has had the flight change to Airline " 
                + FlightContainer.flightObject[0].getAirline() +
                " from " + FlightContainer.flightObject[0].getDepart() +
                " to " + FlightContainer.flightObject[0].getArrive() +
                "\nPrice: $" + Price.getReserveAmount(ReserveP.getTicketID());

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
