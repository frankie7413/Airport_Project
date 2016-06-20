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
    public partial class Flight_Update : Form
    {
        public Flight_Update()
        {
            InitializeComponent();
            search_query_button.Enabled = false;
            SFlight.Enabled = false;
            fillArrive();
            fillDepart();
            this.Show();
        }
        /// <summary>
        /// don't allow user to pick same flight again
        /// clear reservation seats from previous flight
        /// load passengers to pick new seat on this flight
        /// keep same ticket 
        /// </summary>



        private void fillArrive()
        {
            string arrivename, City, State, list;   //variables to use later

            MySqlCommand SelectCommand = new MySqlCommand("select * from Flight;", SQLConnection.Instance.GetConnection());  //projecting through flight table to find all airportID's 
            MySqlDataReader myReader;

            List<string> arriveCities = new List<string>();  //list to contain airportID's

            SQLConnection.Instance.OpenConnection();

            myReader = SelectCommand.ExecuteReader();

            while (myReader.Read())                         //fills list with airportID's 
            {
                arrivename = myReader.GetString("ArriveID");
                arriveCities.Add(arrivename);

            }

            myReader.Close();
            arriveCities = arriveCities.Distinct().ToList();   //only leaves unique airportID's in list 

            foreach (string value in arriveCities)            //goes through each airportID to retrieve city and state for combobox
            {

                MySqlCommand findCity = new MySqlCommand("select City from Arriveport where ArriveID = '" + value + "';", SQLConnection.Instance.GetConnection());  //retrieves city
                MySqlCommand findState = new MySqlCommand("select State from Arriveport where ArriveID = '" + value + "';", SQLConnection.Instance.GetConnection());  //retrieves state
                City = (string)findCity.ExecuteScalar();
                State = (string)findState.ExecuteScalar();

                list = City + ", " + State + " (" + value + ")";

                Arrival_combobox.Items.Add(list);

            }

            SQLConnection.Instance.CloseConnection();
        }

        private void fillDepart()                                
        {
            string departname, City, State, list;   //variables to use later

            MySqlCommand SelectCommand = new MySqlCommand("select * from Flight;", SQLConnection.Instance.GetConnection());
            MySqlDataReader myReader;

            List<string> departCities = new List<string>();  //list to contain airportID's

            SQLConnection.Instance.OpenConnection();

            myReader = SelectCommand.ExecuteReader();

            while (myReader.Read())
            {
                departname = myReader.GetString("DepartID");
                departCities.Add(departname);
            }

            myReader.Close();
            departCities = departCities.Distinct().ToList();  //makes sure to only pass distinct cities no repeats

            foreach (string value in departCities)            //goes through each airportID to retrieve city and state for combobox
            {

                MySqlCommand findCity = new MySqlCommand("select City from DepartPort where DepartID = '" + value + "';", SQLConnection.Instance.GetConnection());  //retrieves city
                MySqlCommand findState = new MySqlCommand("select State from DepartPort where DepartID = '" + value + "';", SQLConnection.Instance.GetConnection());  //retrieves state

                City = (string)findCity.ExecuteScalar();
                State = (string)findState.ExecuteScalar();

                list = City + ", " + State + " (" + value + ")";

                Depart_combobox.Items.Add(list);

            }

            SQLConnection.Instance.CloseConnection();
        }


        private void search_query_button_Click(object sender, EventArgs e)
        {
            //some formatting to enter into query
            string date = DateTime.Parse(Depart_Date.Text).ToString("yyyy-MM-dd"); //shortens the selected date to date format in the database

            string Ainput = Arrival_combobox.Text;
            string Aoutput = Ainput.Split(new char[] { '(', ')' })[1]; //retrieves airportID from string

            string Dinput = Depart_combobox.Text;
            string Doutput = Dinput.Split(new char[] { '(', ')' })[1]; //retrieves airportID from string

            FlightP.setDepName(Doutput); //saves city names for use later
            FlightP.setArrName(Aoutput);

            SQLConnection.Instance.OpenConnection();

            //datagrid 
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from Flight where DepartID = '" + Doutput + "' and ArriveID = '" + Aoutput + "' and departDate = '" + date + "';", SQLConnection.Instance.GetConnection());
            MySqlCommandBuilder commandBuildder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            result_datagrid.ReadOnly = true;
            result_datagrid.DataSource = ds.Tables[0];

            SQLConnection.Instance.CloseConnection();

            SFlight.Enabled = true;

        }

        private void SFlight_Click(object sender, EventArgs e)
        {

            if (FlightP.getFlightNumber() == 0)
            {
                getFirst();
            }

            int newflight = FlightP.getFlightNumber();

            ReserveP.setFlightNumber(ReserveP.getTicketID());
            int oldflight = ReserveP.getFlightNumber();

            //MessageBox.Show("Selected: 3:" + newflight.ToString() + " Reservation: 1:" + oldflight.ToString());

            //keep user from entering same flight again
            if (newflight == oldflight)
            {
                MessageBox.Show("Please select a different flight.");
                Arrival_combobox.SelectedIndex = -1;
                Depart_Date.Value = System.DateTime.Now;
                int zero = 0;
                FlightP.setFlightNumber(zero);
            }
            else
            {
                // clear reservation seats from previous flight
                // load passengers to pick new seat on this flight

                clearSeats();
                PassengerInfo.loadPassengersReserve(ReserveP.getTicketID());
                Price.loadPrices(FlightP.getFlightNumber());
                Price.resetDiscount();
                Seating_Update newseats = new Seating_Update();
                this.Close();
            }
        }


        private void result_datagrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FlightP.setFlightNumber(Convert.ToInt32(result_datagrid.Rows[e.RowIndex].Cells[0].Value));
            FlightP.setAirPlaneID(Convert.ToInt32(result_datagrid.Rows[e.RowIndex].Cells[4].Value));
        }




        private void getFirst()
        {
            FlightP.setFlightNumber(Convert.ToInt32(result_datagrid.Rows[0].Cells[0].Value));
            FlightP.setAirPlaneID(Convert.ToInt32(result_datagrid.Rows[0].Cells[4].Value));
        }





        private static void clearSeats()
        {
            PassengerInfo.loadPassengersReserve(ReserveP.getTicketID());

            SQLConnection.Instance.OpenConnection();

            fillPassengers();

            SQLConnection.Instance.CloseConnection();
            //MessageBox.Show("Reservation Succesfully Removed.");
        }

        private static void fillPassengers()
        {
            while (!PassengerInfo.emptyPassenger())
            {
                ResetSeat(PassengerInfo.accessPassenger());
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




        //////////////////////checking to enable buttons//////////////////////////////////////

        private int status = 0;

        private void checkStatus()
        {

            int acceptance = 2; 
            if (acceptance <= status)
            {
                search_query_button.Enabled = true;
            }

        }

        private void Depart_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            status++;
        }

        private void Arrival_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            status++;
        }

        private void Depart_Date_ValueChanged(object sender, EventArgs e)
        {
            checkStatus();
        }







    }
}
