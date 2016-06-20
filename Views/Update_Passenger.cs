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
    public partial class Update_Passenger : Form
    {
        public Update_Passenger()
        {
            InitializeComponent();
            fillPassenger();
            fillText();
            this.Show();
        }


        private static string firstName, midName, lastName, Age, gender, birthdate;
        private static int PassengerID;

        private void fillPassenger()
        {
            PassengerID = PassengerInfo.accessPassenger();
            PassengerInfo.LoadPassengerInfo(PassengerID);
            firstName =  PassengerInfo.passengerObject[0].getFirstName();
            midName = PassengerInfo.passengerObject[0].getMidName();
            lastName = PassengerInfo.passengerObject[0].getLastName();
            Age = PassengerInfo.passengerObject[0].getAge();
            gender = PassengerInfo.passengerObject[0].getGender();
            birthdate = PassengerInfo.passengerObject[0].getDate();
        }

        private void fillText()
        {
            pass_label1.Text ="Passenger: " + firstName + " " + lastName;
            fname_textBox1.Text = firstName;
            Mname_textBox2.Text = midName;
            lname_textBox3.Text = lastName;
            age_textBox1.Text = Age;
            gender_comboBox2.Text = gender;
            birthDateCalender.Text = birthdate;
            gender_comboBox2.Items.Add("Male");
            gender_comboBox2.Items.Add("Female");
        }


        private void RefreshForm()
        {
            pass_label1.Refresh();
            fname_textBox1.Refresh();
            Mname_textBox2.Refresh();
            lname_textBox3.Refresh();
            age_textBox1.Refresh();
        }

        private void clearForm()
        {
            fname_textBox1.Clear();
            Mname_textBox2.Clear();
            lname_textBox3.Clear();
            age_textBox1.Clear();
            gender_comboBox2.SelectedIndex = -1;
            //birthDateCalender.Value = System.DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkChanges();

            PassengerInfo.removePassengers();

            if (!PassengerInfo.emptyPassenger())
            {
                clearForm();
                fillPassenger();
                fillText();
                RefreshForm();
            }
            else
            {
                MessageBox.Show("Confirmationn of Changes Emailed send shortly.");
                Passenger_Changes.fillEmail();
                this.Close();
                Reserve_Update back2back = new Reserve_Update();
            }

        }


        private void checkChanges()
        {
            SQLConnection.Instance.OpenConnection();

            if (fname_textBox1.Text != firstName)
            {
                MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set FirstName = '" + fname_textBox1.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                selected.ExecuteNonQuery();
            }

            if (Mname_textBox2.Text != midName)
            {
                MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set MidName = '" + Mname_textBox2.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                selected.ExecuteNonQuery();
            }

            if (lname_textBox3.Text != lastName)
            {
                MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set LastName = '" + lname_textBox3.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                selected.ExecuteNonQuery();
            }

            if (gender_comboBox2.Text != gender)
            {
                string agender = gender_comboBox2.Text;
                char letter = agender[0];

                MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set Gender = '" + letter + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                selected.ExecuteNonQuery();
            }

            if (birthDateCalender.Text != birthdate)
            {
                string date = DateTime.Parse(birthDateCalender.Text).ToString("yyyy-MM-dd");
                MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set BirthDate = '" + date + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                selected.ExecuteNonQuery();
            }

            SQLConnection.Instance.CloseConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Account back = new Account();
        }
        
    }
}


//if (fname_textBox1.ToString().All(char.IsLetter) || fname_textBox1.ToString() != "")
//{
//    MessageBox.Show("Please enter a correct first name");
//    fname_textBox1.Text = "";
//}
//else
//{
//    if (fname_textBox1.Text != firstName)
//    {
//        MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set FirstName = '" + fname_textBox1.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
//        selected.ExecuteNonQuery();
//    }
//}


//if (Mname_textBox2.ToString().All(char.IsLetter) || Mname_textBox2.ToString() != "")
//{
//    MessageBox.Show("Please enter a correct middle name");
//    fname_textBox1.Text = "";
//}
//else
//{
//    if (Mname_textBox2.Text != midName)
//    {
//        MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set MidName = '" + Mname_textBox2.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
//        selected.ExecuteNonQuery();
//    }
//}

//if (lname_textBox3.ToString().All(char.IsLetter) || lname_textBox3.ToString() != "")
//{
//    MessageBox.Show("Please enter a correct middle name");
//    fname_textBox1.Text = "";
//}
//else
//{
//    if (lname_textBox3.Text != lastName)
//    {
//        MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set LastName = '" + lname_textBox3.Text + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
//        selected.ExecuteNonQuery();
//    }
//}

//if (gender_comboBox2.Text != gender)
//{
//    string agender = gender_comboBox2.Text;
//    char letter = agender[0];

//    MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set Gender = '" + letter + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
//    selected.ExecuteNonQuery();
//}

//if(birthDateCalender.ToString() == DateTimePicker.MaximumDateTime.ToString())
//{
//    MessageBox.Show("Your birthday cannot be today!");
//    birthDateCalender.Text = "";
//}
//else
//{
//    if (birthDateCalender.Text != birthdate)
//    {
//        string date = DateTime.Parse(birthDateCalender.Text).ToString("yyyy-MM-dd");
//        MySqlCommand selected = new MySqlCommand("UPDATE Passenger Set BirthDate = '" + date + "' where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
//        selected.ExecuteNonQuery();
//    }
//}
