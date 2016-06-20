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
    public partial class Passenger : Form
    {

        public Passenger()
        {
            InitializeComponent();
            fillPassenger();
            fillForm();
            fillGender();
            seat_button2.Enabled = false;
            this.Show();
        }

        //changed this to private
        private static List<int> adultList = new List<int>();
        private static List<int> childrenList = new List<int>();
        private static List<int> infantsList = new List<int>();
        private static int acount;
        private static int ccount;
        private static int icount;


        /// <summary>
        /// stores the passengers in list so the form can loop back to 
        /// add their information to our database
        /// </summary>
        private void fillPassenger()
        {
            acount = PassengerContainer.getAdultPassengers();
            ccount = PassengerContainer.getChildPassengers();
            icount = PassengerContainer.getInfantPassengers();

            //adult group
            if(acount != 0)
            {
                int count = 0;
                if (acount > count)
                {
                    while (count < acount)
                    {
                        adultList.Add(count);
                        count++;
                    }
                }
            }

            //child group
            if (ccount != 0)
            {
                int index = 0;
                if (ccount > index)
                {
                    while (index < ccount)
                    {
                        childrenList.Add(index);
                        index++;
                    }
                }
            }

            if (icount != 0)
            {
                int track = 0;
                if (acount > track)
                {
                    while (track < icount)
                    {
                        infantsList.Add(track);
                        track++;
                    }
                }
            }
        }

        /// <summary>
        /// function Preapares the form to display the type of passenger in the label and adds the passenger from the list 
        /// to add their information and removes the passenger from the list. 
        /// When all the passengers have been proccessed the form is cleared to state passengers done and enables seat selection button.
        /// </summary>
        private void fillForm()
        {
            if(adultList.Count() != 0)
            {
                int remove = Math.Min(adultList.Count, 1); //item to remove
                int adisplay = adultList.ElementAt(0) + 1; //get passenger number

                pass_header.Text = "Adult Passenger #" + adisplay.ToString(); //changes header to currenter passeger type and #
                age_textBox1.Text = "Adult";  //changes textbox to current passenger type

                //refreshes form textbox and label accordingly 
                age_textBox1.Refresh();
                pass_header.Refresh();

                //removes the person we just used to insert to database
                adultList.RemoveRange(0, remove);
            }
            else if(childrenList.Count() != 0)
            {
                int remove = Math.Min(childrenList.Count, 1);
                int adisplay = childrenList.ElementAt(0) + 1;

                pass_header.Text = "Child Passenger #" + adisplay.ToString();
                age_textBox1.Text = "Child";

                age_textBox1.Refresh();
                pass_header.Refresh();

                childrenList.RemoveRange(0, remove);
            }
            else if (infantsList.Count() != 0)
            {
                int remove = Math.Min(infantsList.Count, 1);
                int adisplay = infantsList.ElementAt(0) + 1;
   
                pass_header.Text = "Infant Passenger #" + adisplay.ToString();
                age_textBox1.Text = "Infant";

                age_textBox1.Refresh();
                pass_header.Refresh();

                infantsList.RemoveRange(0, remove);
            }
            else
            {
                fillDone();
            }

        }

        /// <summary>
        /// Displays Passenger's done in the form and disables add button and enables seat button to allow the user
        /// to proceed to the next form.
        /// </summary>
        private void fillDone()
        {

            pass_header.Text = "Passengers Done";
            add_button1.Enabled = false;
            seat_button2.Enabled = true;
        }

        /// <summary>
        /// This function clears all the boxes and labels to be able to add a new passenger information
        /// </summary>
        private void clearBoxes()
        {
            fname_textBox1.Clear();
            Mname_textBox2.Clear();
            lname_textBox3.Clear();
            age_textBox1.Clear();
            gender_comboBox2.SelectedIndex = -1;
            birthDateCalender.Value = System.DateTime.Now;
        }

        /// <summary>
        /// Fills gender combobox with male and female.
        /// </summary>
        private void fillGender()
        {
            gender_comboBox2.Items.Add("Male");
            gender_comboBox2.Items.Add("Female");
        }

        /// <summary>
        /// Add Passenger button calls the query with the information provided by the user to add to database
        /// and calls clearboxes and fillform to prepare form for the next passenger(s).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(fname_textBox1.ToString() == "")
            {
                MessageBox.Show("Please enter a first name");
            }
            else if (lname_textBox3.ToString() == "")
            {
                MessageBox.Show("Please enter a last name");
            }
            else if(age_textBox1.ToString() == "")
            {
                MessageBox.Show("Please enter an age");
            }
            else
            {
                if (fname_textBox1.ToString().All(char.IsLetter))
                {
                    MessageBox.Show("Please enter a correct first name");
                    fname_textBox1.Text = "";
                }
                else if (lname_textBox3.ToString().All(char.IsLetter))
                {
                    MessageBox.Show("Please enter a correct last name");
                    lname_textBox3.Text = "";
                }
                else if(age_textBox1.ToString().All(char.IsDigit))
                {
                    MessageBox.Show("Error. Please enter an actual age");
                    age_textBox1.Text = "";
                }
                else
                {
                    SQLConnection.Instance.OpenConnection();

                    string date = DateTime.Parse(birthDateCalender.Text).ToString("yyyy-MM-dd");
                    string agender = gender_comboBox2.Text.ToString();
                    char letter = agender[0];
                    string getAge = age_textBox1.Text.ToString();
                    char age = getAge[0];

                    MySqlCommand SelectCommand = new MySqlCommand("insert into Passenger values('', '" + fname_textBox1.Text + "', '" + Mname_textBox2.Text + "', '" + lname_textBox3.Text + "', '" + age + "','" + letter + "' ,'" + date + "','', '" + AccountP.getAccountID() + "', '" + FlightP.getFlightNumber() + "', '', '' ); ", SQLConnection.Instance.GetConnection());

                    SelectCommand.ExecuteNonQuery();

                    SQLConnection.Instance.CloseConnection();

                    //clear
                    //load label second passenger until list empty
                    clearBoxes();
                    fillForm();
                }
            }
        }

        /// <summary>
        /// Seat button Calls the class Passenger Container that will save all the passengers in a list to use for the seat form.
        /// The seat form is created and Passenger's form is closed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seat_button2_Click(object sender, EventArgs e)
        {
            //fill passenger list in class
            //PassengerContainer.loadPassengers(FlightP.getFlightNumber(), AccountP.getAccountID());
            PassengerContainer.loadPassengers(FlightP.getFlightNumber(), AccountP.getAccountID());
            Price.loadPrices(FlightP.getFlightNumber());
            Price.resetDiscount();
            Seating nfseat = new Seating();
            this.Close();
        }


    }
}


            //else if(Mname_textBox2.ToString().All(char.IsLetter) || Mname_textBox2.ToString() != "")
            //{
            //    MessageBox.Show("You have input an incorrect middle name");
            //    Mname_textBox2.Text = ""; 
            //}