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
    public partial class Remove_Passenger : Form
    {
        public Remove_Passenger()
        {
            InitializeComponent();
            passenger_delete.Enabled = false;
            fillComboBox();
            this.Show();
        }

        private static string firstName, lastName, Age, name, strAge;
        private static int PassengerID;

        private static int adult = 0;
        private static int child = 0;
        private static int infant = 0;

        private void fillPassenger()
        {
            PassengerID = PassengerInfo.accessPassenger();
            PassengerInfo.LoadPassengerInfo(PassengerID);
            firstName = PassengerInfo.passengerObject[0].getFirstName();
            lastName = PassengerInfo.passengerObject[0].getLastName();
            Age = PassengerInfo.passengerObject[0].getAge();

            if(Age == "Adult")
            {
                adult++;
            }
            else if(Age == "Children")
            {
                child++;
            }
            else
            {
                infant++;
            }

            name = PassengerID + " " + firstName + " " + lastName + " " + Age;
            remove_comboBox1.Items.Add(name);
        }

        private void fillComboBox()
        {
            while(!PassengerInfo.emptyPassenger())
            {
                fillPassenger();
                PassengerInfo.removePassengers();
            }
        }

        private void passenger_delete_Click(object sender, EventArgs e)
        {
            int passNum;

            string display = remove_comboBox1.Text;
            string[] strArr = null;
            char[] splitchar = { ' ' };
            strArr = display.Split(splitchar);

            passNum = Convert.ToInt32(strArr[0]);
            strAge = strArr[3];


            if (strAge == "Adult" && (child == 1 || infant == 1))
            {
                MessageBox.Show("Child or Infant must fly with one adult");
            }
            else if (adult == 1 && ((child + infant) == 0))
            {
                MessageBox.Show("Click on Remove Reservation on reservation changes.");
                passenger_delete.Enabled = false;
            }
            else
            {
                changePayment(passNum);

                SQLConnection.Instance.OpenConnection();

                ResetSeat(passNum);
                deletePassenger(passNum);

                MessageBox.Show("Successfully Removed Passenger and refunded Payment.");
                SQLConnection.Instance.CloseConnection();
                //find the seat and set to 0
                //then delete
                //reduce payment
                MessageBox.Show("Confirmationn of Changes Emailed send shortly.");
                Passenger_Changes.fillEmail();

                RefreshForm();
                
            }
        }


        private void RefreshForm()
        {

            adult = 0;
            child = 0;
            infant = 0;

            remove_comboBox1.SelectedIndex = -1;
            remove_comboBox1.Items.Clear();
            PassengerInfo.loadPassengersReserve(ReserveP.getTicketID());
            fillComboBox(); 
            //remove_comboBox1.Refresh(); 
        }


        private void ResetSeat(int num)
        {
            int seatID;
            MySqlCommand reset = new MySqlCommand("Select SeatID from Passenger where PassengerID = '"+ num +"';", SQLConnection.Instance.GetConnection());
            seatID = Convert.ToInt32(reset.ExecuteScalar());

            MySqlCommand findseat = new MySqlCommand("UPDATE Seat Set Available = 0 where SeatID = '"+ seatID +"';", SQLConnection.Instance.GetConnection());
            findseat.ExecuteNonQuery(); 
        }


        private void deletePassenger(int num)
        {
            MySqlCommand deletePass = new MySqlCommand("DELETE from Passenger where PassengerID = '"+ num +"';", SQLConnection.Instance.GetConnection());
            deletePass.ExecuteNonQuery();
        }


        private void changePayment(int num)
        {
            string ticket = ReserveP.getTicketID();
            int total = Price.getReserveAmount(ticket);
            int fareID = Price.getReserveFareID(ticket);
            string seatclass;

            SQLConnection.Instance.OpenConnection();

            MySqlCommand sclass = new MySqlCommand("Select Class from Passenger where PassengerID = '" + num + "';", SQLConnection.Instance.GetConnection());
            seatclass = (string)sclass.ExecuteScalar();

            seatclass = getClassName(seatclass);

            int flight;
            MySqlCommand findflight = new MySqlCommand("Select FlightID from Fare where FareID = '"+ fareID +"';", SQLConnection.Instance.GetConnection());
            flight = Convert.ToInt32(findflight.ExecuteScalar());

            int subtotal;
            MySqlCommand findClass = new MySqlCommand("Select "+ seatclass +" from Flight where FlightID = '"+ flight +"';", SQLConnection.Instance.GetConnection());
            subtotal = Convert.ToInt32(findClass.ExecuteScalar());
            
            total = total - subtotal;

            MySqlCommand updateFare = new MySqlCommand("UPDATE Fare set Amount = '" + total + "' where FareID = '" + fareID + "';", SQLConnection.Instance.GetConnection());
            updateFare.ExecuteNonQuery();

            SQLConnection.Instance.CloseConnection();
        }

        public string getClassName(string sc)
        {
            if(sc == "F")
            {
                sc = "FirsClassPrice";
            }
            else if(sc == "B")
            {
                sc = "BusinessPrice";
            }
            else
            {
                sc = "EconomicPrice";
            }

            return sc;
        }


        private void remove_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            passenger_delete.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account check = new Account();
            this.Close();
        }


    }
}
