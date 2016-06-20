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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            reserve_button.Enabled = false;
            getData();
            getLabel();
            filltext();
            this.Show();
        }


        /// <summary>
        /// When Flight button is clicked the account form is closed
        /// and flight form is created to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flight_button_Click(object sender, EventArgs e)  
        {
            this.Close();
            Flight flight = new Flight();
        }

        /// <summary>
        /// Update Account is clicked closes account form
        /// and opes account update form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_account_Click(object sender, EventArgs e)  
        {          
            this.Close();
            Account_Update account = new Account_Update();  
        }

        /// <summary>
        /// This function save the account variables to display in account_update form 
        /// for user to change easily
        /// </summary>
        public void getData()  //save account information to use in account_update form
        {
            AccountP.loadAccount();
        }


        private void filltext()
        {

            string midName;
            if (string.IsNullOrEmpty(AccountP.accountObject[0].getMidName()))
            {
                midName = " ";
            }
            else
            {
                midName = AccountP.accountObject[0].getMidName();
            }

            account_richtextbox.Text = "Account Information Below: \n";
            account_richtextbox.Text += "FirstName: " + AccountP.accountObject[0].getFirstName() + "\nMidName: " + midName + 
                "\nLastName: " +AccountP.accountObject[0].getLastName() +"\n";
            account_richtextbox.Text += "Address: " + AccountP.accountObject[0].getAddress() + "\nCity: " + AccountP.accountObject[0].getCity()
                + "\nState: " + AccountP.accountObject[0].getState() + "\nZipcode: " + AccountP.accountObject[0].getZipCode() + "\n";
            account_richtextbox.Text += "Phone: " + AccountP.accountObject[0].getPhone() + "\nContact Email: " + Customer.getEmail();

            setReserveStatus();
        }


        private void setReserveStatus()
        {
            //checks if user has reservations made 
            if(!ReserveP.isEmptyReseve())
            {
                reserve_button.Enabled = true;
            }

        }


        /// <summary>
        /// Changes the Label in account form to display the Account owner's
        /// first and last name
        /// </summary>
        private void getLabel()
        {
            account_label.Text += AccountP.getAccountName();
        }

        private void reserve_button_Click(object sender, EventArgs e)
        {
            //create a new form
            Reserve_Update change = new Reserve_Update();
            this.Close();
        }

        private void logoff_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are now logged off");
            this.Close();
        }


    }
}
