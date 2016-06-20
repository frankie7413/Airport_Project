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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Show();      
        }

        private bool correct = false;

        private void login_login_button_Click(object sender, EventArgs e)
        {
            //searches customer table if user credentials exist
            MySqlCommand SelectCommand = new MySqlCommand("select * from Customer where UserName='" + this.login_user_textbox.Text + "' and Password='" + this.login_pass_textbox.Text + "' ; ", SQLConnection.Instance.GetConnection());
            MySqlDataReader myReader;

            //opens our connection string 
            SQLConnection.Instance.OpenConnection();

            myReader = SelectCommand.ExecuteReader();
            bool found = false;

            //reads to find user credentials entered 
            while (myReader.Read())
            {
                found = true;
            }

            //if credentials found we save the users account number to use in our other forms 
            if (found)
            {

                myReader.Close();   //need to close reader to use executeSacalar()

                //finds thes customerID which is the same as customer ID 
                MySqlCommand findCustomer = new MySqlCommand("select CustomerID from Customer where UserName='" + this.login_user_textbox.Text + "' and Password='" + this.login_pass_textbox.Text + "' ; ", SQLConnection.Instance.GetConnection());
                AccountP.setAccountID((Convert.ToInt32(findCustomer.ExecuteScalar())));     //saving user account number to use in other forms 
                Customer.setCustomerID(AccountP.getAccountID()); //since both are the same
                correct = true;
                MessageBox.Show("Loged in Successful.");

            }
            else
            {
                MessageBox.Show("User does not exist.");

            }

            SQLConnection.Instance.CloseConnection();


            //control flow if credentials are valid will let user proceed to next form or remain in form to enter valid credentials
            if (correct)
            {
                this.Close();
                Account account = new Account();
            }
            else
            {
                login_user_textbox.Clear();
                login_pass_textbox.Clear();
            }
            ////bool valid = IsValid(login_user_textbox.Text, login_pass_textbox.Text);

            //if (valid)
            //{
            //    //searches customer table if user credentials exist
            //    MySqlCommand SelectCommand = new MySqlCommand("select * from Customer where UserName='" + this.login_user_textbox.Text + "' and Password='" + this.login_pass_textbox.Text + "' ; ", SQLConnection.Instance.GetConnection());
            //    MySqlDataReader myReader;

            //    //opens our connection string 
            //    SQLConnection.Instance.OpenConnection();

            //    myReader = SelectCommand.ExecuteReader();
            //    bool found = false;




            //    //reads to find user credentials entered 
            //    while (myReader.Read())
            //    {
            //        found = true;
            //    }


            //    //string welcomeMsg = LoginResult(found);

            //    //myReader.Close();

            //    //MessageBox.Show(welcomeMsg);

            //    //if credentials found we save the users account number to use in our other forms 
            //    if (found)
            //    {

            //        myReader.Close();   //need to close reader to use executeSacalar()

            //        //LoginProcess();

            //        //finds thes customerID which is the same as customer ID 
            //        MySqlCommand findCustomer = new MySqlCommand("select CustomerID from Customer where UserName='" + this.login_user_textbox.Text + "' and Password='" + this.login_pass_textbox.Text + "' ; ", SQLConnection.Instance.GetConnection());
            //        AccountP.setAccountID((int)findCustomer.ExecuteScalar());     //saving user account number to use in other forms 
            //        Customer.setCustomerID(AccountP.getAccountID()); //since both are the same
            //        correct = true;
            //        MessageBox.Show("Loged in Successful.");

            //    }
            //    else
            //    {
            //        MessageBox.Show("User does not exist.");

            //    }

            //    SQLConnection.Instance.CloseConnection();


            //    //control flow if credentials are valid will let user proceed to next form or remain in form to enter valid credentials
            //    if (correct)
            //    {
            //        this.Close();
            //        Account account = new Account();
            //    }
            //    else
            //    {
            //        login_user_textbox.Clear();
            //        login_pass_textbox.Clear();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Invalid user name/password");
            //}
        }

        private void login_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public bool IsValid(string username, string password)
        //{
        //    bool valid = true;

        //    if (DataValidation.IsBlank(username) || DataValidation.IsBlank(password))
        //        valid = false;
        //    else if (!DataValidation.IsLength(username, 6) || DataValidation.IsLength(password, 6))
        //        valid = false;
        //    else if (username == password)
        //        valid = false;
        //    else if (username.Contains("@") || username.Contains("#") || username.Contains("$"))
        //        valid = false;
        //    else
        //        valid = true;

        //    return valid;
        //}

    }
}
