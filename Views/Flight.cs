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

    public partial class Flight : Form
    {

        public Flight()
        {
            InitializeComponent();
            fillDepart();
            fillArrive();
            fillPassengers();
            SFlight.Enabled = false; //freezes flight button unless a flight is selected 
            search_query_button.Enabled = false; //freeze select until combo boxes are filled
            this.Show();
        }

        /// <summary>
        /// fillPassengers adds the passengers capacity to the combo boxes
        /// for instance adds max 6 passengers for adult combobox
        /// </summary>
        private void fillPassengers()  //fills the combo boxes for adult, child & infant comboboxes
        {

            ////adult combobox
            int adult_no = 0;
            int max_no = 10;
            int childmax_no = 6;

            while(adult_no < max_no)
            {

                adult_comboBox1.Items.Add(adult_no);
                adult_no++;
            }

            //child combobox
            int child_no = 0;
            while(child_no < childmax_no)
            {
                child_comboBox2.Items.Add(child_no);
                child_no++;
            }


            //infant combobox
            int infant_no = 0;
            while(infant_no < childmax_no)
            {
                infant_comboBox3.Items.Add(infant_no);
                infant_no++;
            }
        }

        /// <summary>
        /// Funciton calls flight table to get all the departure cities 
        /// and adds the cities to list.
        /// The cities and states are called in the departurePort to find their names to display in
        /// the combobox accordingly
        /// </summary>
        private void fillDepart()                                //fills combo box of departures with unique airports
        {
            string departname, City, State, list;   //variables to use later
           
            MySqlCommand SelectCommand = new MySqlCommand("select * from Flight;", SQLConnection.Instance.GetConnection());            
            MySqlDataReader myReader;

            List<string> departCities = new List<string>();  //list to contain airportID's

            SQLConnection.Instance.OpenConnection();

            myReader = SelectCommand.ExecuteReader();

            while(myReader.Read())
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

        /// <summary>
        /// Similar to fillDepart() but we are looking for arriveCities 
        /// and looking for city and state in arrivePort
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

        /// <summary>
        /// Search is click a query is called with the departure, arrival, date selected from the form
        /// to find matches in the flight table to display in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            ///////////////////////datagrid 
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from Flight where DepartID = '" + Doutput + "' and ArriveID = '" + Aoutput + "' and departDate = '" + date + "';", SQLConnection.Instance.GetConnection());
            MySqlCommandBuilder commandBuildder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            result_datagrid.ReadOnly = true;
            result_datagrid.DataSource = ds.Tables[0];

            SQLConnection.Instance.CloseConnection();

            SFlight.Enabled = true;
        }

        /// <summary>
        /// Flight is click the flight number selected from the user is checked to see if it was saved.
        /// Checks to see if the passenger criteria is made accordingly like 1 adult should accompany a child 
        /// or infant. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFlight_Click(object sender, EventArgs e)
        {
            //only checks if person does not click on another flight and just presses select 
            //this grabs the default selected flight to pass to passenger form
            if (FlightP.getFlightNumber() == 0) 
            {
                getFirst();
            }

            //the following checks in case the user wants to fly with only one child or an infant without an adult
            string adultCheck = adult_comboBox1.Text;
            string childCheck = child_comboBox2.Text;

            if ((adultCheck == "0") || (string.IsNullOrEmpty(adultCheck)))
            {
                MessageBox.Show("Child or Infant must travel with one adult");
            }
            else if (((adultCheck == "0") && (childCheck == "0")) || 
                ((adultCheck == "0") && (string.IsNullOrEmpty(childCheck))) 
                || ((string.IsNullOrEmpty(adultCheck)) && (childCheck == "0"))
                || ( (string.IsNullOrEmpty(adultCheck)) && (string.IsNullOrEmpty(childCheck))))
            {
                MessageBox.Show("Adult or Child must have atleast 1 passenger");
                adult_comboBox1.SelectedIndex = -1;
                child_comboBox2.SelectedIndex = -1;
            }
            else
            {
                getPassengers();
                this.Close();
                //MessageBox.Show(Start.flightNumber.ToString());
                Passenger passenger = new Passenger();
            }

            //MessageBox.Show(FlightP.getFlightNumber().ToString());

        }

        /// <summary>
        /// function saves the flight the user clicked in the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void result_datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //keeps track of the flight number to use later
            FlightP.setFlightNumber(Convert.ToInt16(result_datagrid.Rows[e.RowIndex].Cells[0].Value));
            FlightP.setAirPlaneID(Convert.ToInt16(result_datagrid.Rows[e.RowIndex].Cells[4].Value));
        }


        /// <summary>
        /// If the user did not select a different flight, this function saves the first flight 
        /// of the default selected row in the datagrid
        /// </summary>
        private void getFirst()
        {
            FlightP.setFlightNumber(Convert.ToInt16(result_datagrid.Rows[0].Cells[0].Value));
            FlightP.setAirPlaneID(Convert.ToInt16(result_datagrid.Rows[0].Cells[4].Value));
        }

        /// <summary>
        /// This function saves the number of adult, child and/or infants that were selected in the comboboxes 
        /// to use in the passenger and seat form
        /// </summary>
        private void getPassengers()
        {
            if(adult_comboBox1.SelectedItem != null)
            {
                //Start.adultPassengers = int.Parse(adult_comboBox1.SelectedItem.ToString());
                PassengerContainer.setAdultPassengers(int.Parse(adult_comboBox1.SelectedItem.ToString()));
            }

            if (child_comboBox2.SelectedItem != null)
            {
                //Start.childPassengers = int.Parse(child_comboBox2.SelectedItem.ToString());
                PassengerContainer.setChildPassengers(int.Parse(child_comboBox2.SelectedItem.ToString()));
            }

            if (infant_comboBox3.SelectedItem != null)
            {
                //Start.infantPassengers = int.Parse(infant_comboBox3.SelectedItem.ToString());
                PassengerContainer.setInfantPassengers(int.Parse(infant_comboBox3.SelectedItem.ToString()));
            }
        }



        /// <summary>
        /// The following functions check to see the user filled out the filtered search critirea and atleast filled out one passenger as adult or one child
        /// </summary>
        private int status = 0;

        private void adult_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkStatus();
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
            status++;
        }

        /// <summary>
        /// Checks to see that the correct fields have been entered to unlock the select
        /// </summary>
        void checkStatus()
        {
            int acceptance = 3;  //3 is the least number of criteria required for search to be unlocked
            if (acceptance <= status)
            {
                search_query_button.Enabled = true;
            }
            //search_query_button.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
