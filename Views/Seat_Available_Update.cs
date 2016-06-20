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
    public partial class Seat_Available_Update : Form
    {

        private static int airplaneRows = Airplane.getNumberofRows(Seat.getClassSeat());
        private static int rowLabel = airplaneRows + 1;
        private static int airplaneTotaSeats = Airplane.getTotalSeats();
        private int flightNumber = FlightP.getFlightNumber();
        private int PassengerID = PassengerInfo.getPassengerID();

        Button[,] btnSeat = new Button[22, 12];
        Label[] label = new Label[rowLabel]; //has to be one above


        int[,] seatStatus = new int[22, 12];

        public Seat_Available_Update()
        {
            InitializeComponent();
            getLabels();
            seatfill();
            this.Show();
        }

        /// <summary>
        /// This function draws the seating chart for the seat class, 
        /// marks seats that are taken and allows user to select one. 
        /// </summary>
        private void drawPlan()
        {
            int offset = 6;

            int seatMax;
            for (int j = 1; j <= airplaneRows; j++)
            {
                seatMax = 6;

                for (int i = 1; i <= seatMax; i++)
                {
                    btnSeat[i, j] = new Button();
                    btnSeat[i, j].Width = 28;
                    btnSeat[i, j].Height = 28;
                    btnSeat[i, j].Left = (28 * i) + (28 * offset);

                    ////gap inbetween 3 rows
                    if (i > 3)
                    {
                        btnSeat[i, j].Left += 28;
                    }

                    btnSeat[i, j].Top = (28 * j) + (28);

                    //change the string to where you placed the folder at make sure to use \ for \ character
                    btnSeat[i, j].Image = Image.FromFile("C:\\Users\\frank_000\\Desktop\\Aiport_Project_\\seatDemo.png");


                    if (seatStatus[i, j] == 1)
                        btnSeat[i, j].Image = Image.FromFile("C:\\Users\\frank_000\\Desktop\\Aiport_Project_\\seatDemo2.png");

                    ///button click section
                    string buttonName = "btn";
                    buttonName += " " + j + " " + i;


                    btnSeat[i, j].Name = buttonName;
                    btnSeat[i, j].Click += new EventHandler(seat_Click);
                    //end button click


                    this.Controls.Add(btnSeat[i, j]);
                    int rowNumber = j;
                    string tooltipText = Convert.ToChar(rowNumber + 64).ToString()
                        + (i).ToString();
                    ToolTip buttonToolTip = new ToolTip();
                    buttonToolTip.SetToolTip(btnSeat[i, j], tooltipText);


                }
                ///////label stuff
                label[j] = new Label();
                label[j].Size = new System.Drawing.Size(airplaneTotaSeats, 30); //number of passengers 24,30
                char c = Convert.ToChar(64 + j);
                label[j].Text = Convert.ToString(c);
                label[j].Font = new System.Drawing.Font("Microsoft Sans Serif",
                10F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label[j].Location = new System.Drawing.Point(285, (28 * j) + (28));
                this.Controls.Add(label[j]);
            }

        }

        //variables to get location of button selected by user
        private int select_count;
        private int ilocation;
        private char jlocation;

        /// <summary>
        /// seat button slected checks to mark which buton is selected and deslected by user 
        /// and keeps count to make sure only selects one seat to enable the user to go to the next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seat_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            string s = clickedButton.Name;
            int j = Convert.ToInt16(s.Substring(3, 2));
            int i = Convert.ToInt16(s.Substring(5, 2));

            if (seatStatus[i, j] != 1)
            {
                if (seatStatus[i, j] == 0)
                {
                    seatStatus[i, j] = 2;
                    btnSeat[i, j].Image = Image.FromFile("C:\\Users\\frank_000\\Desktop\\Aiport_Project_\\seatDemo3.png");
                    select_count++;
                    ilocation = i;
                    jlocation = Convert.ToChar(j + 64);
                }
                else
                {
                    seatStatus[i, j] = 0;
                    btnSeat[i, j].Image = Image.FromFile("C:\\Users\\frank_000\\Desktop\\Aiport_Project_\\seatDemo.png");
                    select_count--;
                }

            }

        }


        /// <summary>
        /// Assigns the labels to the selected class seat in the privious form
        /// </summary>
        private void getLabels()
        {
            string labelString;

            if (Seat.getClassSeat() == "E")
            {
                labelString = "Economic Class Seats";
            }
            else if (Seat.getClassSeat() == "B")
            {
                labelString = "Business Class Seats";
            }
            else
            {
                labelString = "First Class Seats";
            }

            seat_class_label.Text = labelString;
        }


        /// <summary>
        /// Fills the form with buttons to display the seat chart
        /// </summary>
        private void seatfill()
        {
            Seat.loadSeats(Seat.getClassSeat());


            for (int i = 0; i < Seat.seatCount; i++)
            {
                char c = Seat.seatObject[i].getSeatRow();
                int r = ((int)c) - 64;

                int s = Seat.seatObject[i].getSeatNumber();
                int available = Seat.seatObject[i].getAvailable();
                seatStatus[s, r] = available;
            }

            drawPlan();
        }

        private void seat_select_button_Click_1(object sender, EventArgs e)
        {
            if (select_count > 1)
            {
                MessageBox.Show(select_count.ToString() + " seats selected. Please select only one seat");

            }
            else
            {
                SQLConnection.Instance.OpenConnection();

                MySqlCommand seatCommand = new MySqlCommand("UPDATE Seat Set Available = 1 where FlightID = '" + flightNumber + "' AND classSeat = '" + Seat.getClassSeat() + "' AND Row = '" + jlocation + "' AND selectSeat = '" + ilocation + "';", SQLConnection.Instance.GetConnection());
                MySqlCommand findseatCommand = new MySqlCommand("select SeatID from Seat where FlightID = '" + flightNumber + "' AND classSeat = '" + Seat.getClassSeat() + "' AND Row = '" + jlocation + "' AND selectSeat = '" + ilocation + "';", SQLConnection.Instance.GetConnection());

                seatCommand.ExecuteNonQuery();
                Seat.setSeatPassenger(Convert.ToInt32(findseatCommand.ExecuteScalar()));

                //passengerID carrier //check
                MySqlCommand passengerEnter = new MySqlCommand("UPDATE Passenger Set SeatID = '" + Seat.getSeatPassenger() + "'  where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                passengerEnter.ExecuteNonQuery();

                //class into passenger table
                MySqlCommand passengerClass = new MySqlCommand("UPDATE Passenger Set Class = '" + Seat.getClassSeat() + "'  where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
                passengerClass.ExecuteNonQuery();

                //updates flight to new flight
                MySqlCommand passengerFlight = new MySqlCommand("UPDATE Passenger Set FlightID = '" + flightNumber + "' where PassengerID = '" + PassengerID + "' ;", SQLConnection.Instance.GetConnection());
                passengerFlight.ExecuteNonQuery();

                SQLConnection.Instance.CloseConnection();

                //testing this
                //PassengerContainer.removePassengers();
                PassengerInfo.removePassengers();

                if (!PassengerInfo.emptyPassenger())
                {
                    this.Close();
                    Seating_Update another = new Seating_Update();
                }
                else
                {
                    Payment_Update payup = new Payment_Update();
                    this.Close();
                    //MessageBox.Show("Payment next");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seatID = Seat.randomSeat(Seat.getClassSeat(), airplaneTotaSeats, flightNumber);

            SQLConnection.Instance.OpenConnection();

            MySqlCommand seatCommand = new MySqlCommand("UPDATE Seat Set Available = 1 where SeatID = '" + seatID + "';", SQLConnection.Instance.GetConnection());
            seatCommand.ExecuteNonQuery();

            //passengerID carrier //check
            MySqlCommand passengerEnter = new MySqlCommand("UPDATE Passenger Set SeatID = '" + seatID + "'  where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
            passengerEnter.ExecuteNonQuery();

            //class into passenger table
            MySqlCommand passengerClass = new MySqlCommand("UPDATE Passenger Set Class = '" + Seat.getClassSeat() + "'  where PassengerID = '" + PassengerID + "';", SQLConnection.Instance.GetConnection());
            passengerClass.ExecuteNonQuery();

            //updates flight to new flight
            MySqlCommand passengerFlight = new MySqlCommand("UPDATE Passenger Set FlightID = '" + flightNumber + "' where PassengerID = '" + PassengerID + "' ;", SQLConnection.Instance.GetConnection());
            passengerFlight.ExecuteNonQuery();

            SQLConnection.Instance.CloseConnection();

            Price.Discount();

            PassengerInfo.removePassengers();

            if (!PassengerInfo.emptyPassenger())
            {
                this.Close();
                Seating_Update another = new Seating_Update();
            }
            else
            {
                Payment_Update payup = new Payment_Update();
                this.Close();
                //MessageBox.Show("Payment next");
            }

        }

    }
}
