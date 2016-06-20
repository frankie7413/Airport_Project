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
    public partial class Signup : Form
    {

        public Signup()
        {
            InitializeComponent();
            this.Show();
        }

        private string customer_username;

        /// <summary>
        /// Singup button is click creates a new customer entry in database and stores the customerID to create
        /// the account for the created customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signup_signup_button_Click(object sender, EventArgs e)
        {
            //if (DataValidation.IsBlank(signup_user_textbox.Text))
            //{
            //    MessageBox.Show("Please enter a username");
            //}
            //else if (DataValidation.IsBlank(signup_password_textbox.Text))
            //{
            //    MessageBox.Show("Please enter a password");
            //}
            //else if (DataValidation.IsBlank(signup_email_textbox.Text))
            //{
            //    MessageBox.Show("Please enter an email");
            //}
            //else if (DataValidation.IsBlank(acct_fname.Text))
            //{
            //    MessageBox.Show("Please enter an first name");
            //}
            //else if (DataValidation.IsBlank(acct_lname.Text))
            //{
            //    MessageBox.Show("Please enter a last name");
            //}
            //else if (DataValidation.IsBlank(acct_adr.Text))
            //{
            //    MessageBox.Show("Please enter an address");
            //}
            //else if (DataValidation.IsBlank(acct_zip.Text))
            //{
            //    MessageBox.Show("Please enter a zip code");
            //}
            //else if (DataValidation.IsBlank(acct_phone.Text))
            //{
            //    MessageBox.Show("Please enter a phone number");
            //}
            //else if (DataValidation.IsBlank(acct_city.Text))
            //{
            //    MessageBox.Show("Please enter a city");
            //}
            //else
            //{

            //    if (!DataValidation.IsAllLetters(acct_fname.Text))
            //    {
            //        MessageBox.Show("First name must only have letters");
            //        acct_fname.Text = "";
            //    }
            //    else if (!DataValidation.IsAllLetters(acct_lname.Text))
            //    {
            //        MessageBox.Show("Last name must only have letters");
            //        acct_lname.Text = "";
            //    }
            //    else
            //    {
            //        if (!DataValidation.IsAllDigits(acct_zip.Text) || !DataValidation.IsLength(acct_zip.Text, 5))
            //        {
            //            MessageBox.Show("Incorrect zip code. Please enter again");
            //            acct_zip.Text = "";
            //        }
            //        else if (!DataValidation.IsLength(acct_phone.Text, 12))
            //        {
            //            MessageBox.Show("Incorrect format of phone. Please enter again");
            //            acct_phone.Text = "";
            //            //!DataValidation.IsAllDigits(acct_phone.Text) ||
            //        }
            //        else if (!DataValidation.IsEmail(signup_email_textbox.Text))
            //        {
            //            MessageBox.Show("Incorrect format of email.");
            //            signup_email_textbox.Text = "";
            //        }
            //        else if (!DataValidation.IsAllLetters(acct_city.Text))
            //        {
            //            MessageBox.Show("City must only contains letters");
            //            acct_city.Text = "";
            //        }
            //        else
            //        {
                        //inserts new customer into customer table
                        MySqlCommand SelectCommand = new MySqlCommand("insert into Customer values ('','" + this.signup_user_textbox.Text + "', '" + this.signup_password_textbox.Text + "', '" + this.signup_email_textbox.Text + "'); ", SQLConnection.Instance.GetConnection());
                        Customer.setEmail(this.signup_email_textbox.Text);

                        SQLConnection.Instance.OpenConnection();  //open database connection

                        //adds cusomter to database
                        SelectCommand.ExecuteNonQuery();

                        //finds customerID of created user to be stored in variable
                        MySqlCommand findCustomer = new MySqlCommand("select CustomerID from Customer where UserName='" + this.signup_user_textbox.Text + "' and Password='" + this.signup_password_textbox.Text + "' ; ", SQLConnection.Instance.GetConnection());
                        Customer.setCustomerID(Convert.ToInt32(findCustomer.ExecuteScalar()));
                        AccountP.setAccountID(Customer.getCustomerID());


                        //creats account for customer in account table
                        MySqlCommand accountMaker = new MySqlCommand("insert into Account values ('', '" + Customer.getCustomerID() + "','" + this.acct_fname.Text + "', '" + this.acct_mid.Text +
                            "', '" + this.acct_lname.Text + "', '" + this.acct_adr.Text + "', '" + this.acct_state_comboBox1.Text + "', '" + this.acct_zip.Text + "', '" + this.acct_phone.Text + "','" + this.acct_city.Text + "'); ", SQLConnection.Instance.GetConnection());
                        accountMaker.ExecuteNonQuery();



                        SQLConnection.Instance.CloseConnection();  //closes connection with database    
                        ///get customer username 
                        Customer.setUserName(Customer.getCustomerID());
                        customer_username = Customer.getUserName();


                        SendEmail(signup_email_textbox.Text);

                        MessageBox.Show("Account Created. An email has been sent to your registered email");        //shows only if the code prior works
                        
                        this.Close();

                        Account account = new Account();
                    //}
                //}
            //}
        }


        /// <summary>
        /// Singup is clicked closes the form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signup_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendEmail(string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "airlinenorthwest@gmail.com";
            string password = "egkqycqgxiggelhh";

            string subject = "Welcome to NorthWest Airline";
            string body = "Hi,\nThis email to confirms that you have signed up an account with us. With Username: " + customer_username;


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
