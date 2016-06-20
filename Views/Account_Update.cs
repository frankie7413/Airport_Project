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
    public partial class Account_Update : Form
    {

        public Account_Update()
        {
            InitializeComponent();
            fillVariables();
            fillText();
            fillComboBox();
            this.Show();
        }

        private string FirstName, MidName, LastName, Address, State, Phone, City;
        private int Zipcode;


        /// <summary>
        /// Fills the variables for this form so user can change whichever textbox 
        /// they desire 
        /// </summary>
        private void fillVariables()
        {
            FirstName = AccountP.accountObject[0].getFirstName();
            MidName = AccountP.accountObject[0].getMidName();
            LastName = AccountP.accountObject[0].getLastName();
            Address = AccountP.accountObject[0].getAddress();
            State = AccountP.accountObject[0].getState();
            Phone = AccountP.accountObject[0].getPhone();
            City = AccountP.accountObject[0].getCity();
            Zipcode = AccountP.accountObject[0].getZipCode();
        }


        /// <summary>
        /// Fills the textboxes in the form to display 
        /// the variable names of the account
        /// </summary>
        private void fillText()
        {
            fname_textBox1.Text = FirstName;
            Mname_textBox2.Text = MidName;
            Lname_textBox3.Text = LastName;
            address_textBox4.Text = Address;
            state_combobox.Text = State;
            zip_textBox6.Text = Zipcode.ToString();
            phone_textBox7.Text = Phone;
            city_textBox8.Text = City;
        }

        /// <summary>
        /// Save is click the functions check to see which textboxes where change
        /// and if they were change runs a query to change the account at that specific variable
        /// accordingly. After running the if statement, account form is called again with the new variable changes appearing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_button_Click(object sender, EventArgs e)
        {
            SQLConnection.Instance.OpenConnection();

            if (fname_textBox1.Text != FirstName)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set FirstName = '" + fname_textBox1.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (Mname_textBox2.Text != MidName)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set MidName = '" + Mname_textBox2.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (Lname_textBox3.Text != LastName)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set LastName = '" + Lname_textBox3.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (address_textBox4.Text != Address)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Address = '" + address_textBox4.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (state_combobox.Text != State)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set State = '" + state_combobox.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (zip_textBox6.Text != Zipcode.ToString())
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Zipcode = '" + zip_textBox6.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();

            }

            if (phone_textBox7.Text != Phone)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Phone = '" + phone_textBox7.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            if (city_textBox8.Text != City)
            {
                MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set City = '" + city_textBox8.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
                SelectCommand.ExecuteNonQuery();
            }

            MessageBox.Show("Changes Successful");

            SQLConnection.Instance.CloseConnection();

            this.Close();

            Account reset = new Account();
        }

        private void fillComboBox()
        {
            state_combobox.Items.Add("AL");
            state_combobox.Items.Add("AK");
            state_combobox.Items.Add("AZ");
            state_combobox.Items.Add("AR");
            state_combobox.Items.Add("CA");
            state_combobox.Items.Add("CO");
            state_combobox.Items.Add("CT");
            state_combobox.Items.Add("DE");
            state_combobox.Items.Add("FL");
            state_combobox.Items.Add("GA");
            state_combobox.Items.Add("HI");
            state_combobox.Items.Add("ID");
            state_combobox.Items.Add("IL");
            state_combobox.Items.Add("IN");
            state_combobox.Items.Add("IA");
            state_combobox.Items.Add("KS");
            state_combobox.Items.Add("KY");
            state_combobox.Items.Add("LA");
            state_combobox.Items.Add("ME");
            state_combobox.Items.Add("MD");
            state_combobox.Items.Add("MA");
            state_combobox.Items.Add("MI");
            state_combobox.Items.Add("MN");
            state_combobox.Items.Add("MS");
            state_combobox.Items.Add("MO");
            state_combobox.Items.Add("MT");
            state_combobox.Items.Add("NE");
            state_combobox.Items.Add("NV");
            state_combobox.Items.Add("NH");
            state_combobox.Items.Add("NJ");
            state_combobox.Items.Add("NM");
            state_combobox.Items.Add("NY");
            state_combobox.Items.Add("NC");
            state_combobox.Items.Add("ND");
            state_combobox.Items.Add("OH");
            state_combobox.Items.Add("OK");
            state_combobox.Items.Add("OR");
            state_combobox.Items.Add("PA");
            state_combobox.Items.Add("RI");
            state_combobox.Items.Add("SC");
            state_combobox.Items.Add("SD");
            state_combobox.Items.Add("TN");
            state_combobox.Items.Add("TX");
            state_combobox.Items.Add("UT");
            state_combobox.Items.Add("VT");
            state_combobox.Items.Add("VA");
            state_combobox.Items.Add("WA");
            state_combobox.Items.Add("WV");
            state_combobox.Items.Add("WI");
            state_combobox.Items.Add("WY");
            state_combobox.Text = "AL";
        }

        /// <summary>
        /// If cancel is clicked the form closes and calls account 
        /// making no changes to the account variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Account reset = new Account();
        }

    }
}




            //SQLConnection.Instance.OpenConnection();

            //if (fname_textBox1.ToString().All(char.IsLetter) || fname_textBox1.ToString() != "")
            //{
            //    MessageBox.Show("Please enter a correct first name");
            //    fname_textBox1.Text = "";
            //}
            //else
            //{
            //    if (fname_textBox1.Text != FirstName)
            //    {
            //        MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set FirstName = '" + fname_textBox1.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //        SelectCommand.ExecuteNonQuery();
            //    }
            //}

            //if (Mname_textBox2.ToString().All(char.IsLetter) || Mname_textBox2.ToString() != "")
            //{
            //    MessageBox.Show("Please enter a correct middle name");
            //    Mname_textBox2.Text = "";
            //}
            //else
            //{
            //    if (Mname_textBox2.Text != MidName)
            //    {
            //        MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set MidName = '" + Mname_textBox2.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //        SelectCommand.ExecuteNonQuery();
            //    }
            //}

            //if (Lname_textBox3.ToString().All(char.IsLetter) || Lname_textBox3.ToString() != "")
            //{
            //    MessageBox.Show("Please enter a correct last name");
            //    Lname_textBox3.Text = "";
            //}
            //else
            //{
            //    if (Lname_textBox3.Text != LastName)
            //    {
            //        MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set LastName = '" + Lname_textBox3.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //        SelectCommand.ExecuteNonQuery();
            //    }
            //}

            //if (address_textBox4.Text != Address)
            //{
            //    MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Address = '" + address_textBox4.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //    SelectCommand.ExecuteNonQuery();
            //}

            //if (state_combobox.Text != State)
            //{
            //    MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set State = '" + state_combobox.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //    SelectCommand.ExecuteNonQuery();
            //}

            ////if (state_textBox5.Text != State)
            ////{
            ////    MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set State = '" + state_textBox5.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            ////    SelectCommand.ExecuteNonQuery();
            ////}

            //if (zip_textBox6.ToString().All(char.IsDigit) || zip_textBox6.TextLength != 5 || zip_textBox6.ToString() != "")
            //{
            //    MessageBox.Show("Please enter a correct zip code");
            //    zip_textBox6.Text = "";
            //}
            //else
            //{
            //    if (zip_textBox6.Text != Zipcode.ToString())
            //    {
            //        MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Zipcode = '" + zip_textBox6.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //        SelectCommand.ExecuteNonQuery();
            //    }
            //}

            //if (phone_textBox7.ToString().All(c => char.IsDigit(c) || c == '-') || phone_textBox7.TextLength != 12 || phone_textBox7.ToString() != "")
            //{
            //    MessageBox.Show("Please enter a correct phone number");
            //    phone_textBox7.Text = "";
            //}
            //else
            //{
            //    if (phone_textBox7.Text != Phone)
            //    {
            //        MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set Phone = '" + phone_textBox7.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //        SelectCommand.ExecuteNonQuery();
            //    }
            //}


            //if (city_textBox8.Text != City)
            //{
            //    MySqlCommand SelectCommand = new MySqlCommand("UPDATE Account Set City = '" + city_textBox8.Text + "' where AccountID = '" + AccountP.getAccountID() + "'; ", SQLConnection.Instance.GetConnection());
            //    SelectCommand.ExecuteNonQuery();
            //}

            //MessageBox.Show("Changes Successful");

            //SQLConnection.Instance.CloseConnection();

            //this.Close();

            //Account reset = new Account();