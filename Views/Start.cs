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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            Commands_button.Enabled = false;
        }

        /// <summary>
        /// Creates login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form1_login_button_Click(object sender, EventArgs e)   //calls login form
        {
            Login login = new Login();
            login.Show();
        }

        /// <summary>
        /// Creats signup form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form1_signup_button_Click(object sender, EventArgs e)  //calls Signup form
        {
            Signup signup = new Signup();
        }

        /// <summary>
        /// Prompts user if they wish to close the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_FormClosing(object sender, FormClosingEventArgs e)   //prompts user if they want to leave our program :(
        {
            DialogResult dialog = dialog = MessageBox.Show("Do you really want to close the program? :(", 
                "Exit?", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Manager create = new Login_Manager();
        }



        /// <summary>
        /// Creats the entries for seats accourding to flight
        /// Make sure to add as many rows necessary for the airplane seat capacity
        /// for instance a seat class with 30 passengers will have 5 rows 
        /// devide seat class # by 6 to get the amount of rows you need 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Commands_button_Click(object sender, EventArgs e)
        {

            SQLConnection.Instance.OpenConnection();


            int airnum = 17;
            int maxairnum = 21;

            while (airnum < maxairnum)
            {

                
                char cseat = 'F';
                
                int count = 0;
                int rows = 3;
                while (count < rows)
                {

                    if (count == 1)
                    {
                        cseat = 'B';
                    }
                    else if (count == 2)
                    {
                        cseat = 'E';
                    }


                    /* for a classseat*/
                    int i = 1;
                    int max = 7;

                    while (i < max)
                    {
                        MySqlCommand selectcommand = new MySqlCommand("insert into Seat values ('','" + airnum + "', '" + cseat + "', 'A', '" + i + "', 0 );", SQLConnection.Instance.GetConnection());
                        selectcommand.ExecuteNonQuery();
                        i++;
                    }

                    //* for b classseat*/
                    int track = 1;
                    int tmax = 7;

                    while (track < tmax)
                    {
                        MySqlCommand selectcommand = new MySqlCommand("insert into Seat values ('','" + airnum + "', '" + cseat + "', 'B', '" + track + "', 0 );", SQLConnection.Instance.GetConnection());
                        selectcommand.ExecuteNonQuery();
                        track++;
                    }

                    //* for c classseat*/
                    int ntrack = 1;
                    int ntmax = 7;

                    while (ntrack < ntmax)
                    {
                        MySqlCommand selectcommand = new MySqlCommand("insert into Seat values ('','" + airnum + "', '" + cseat + "', 'C', '" + ntrack + "', 0 );", SQLConnection.Instance.GetConnection());
                        selectcommand.ExecuteNonQuery();
                        ntrack++;
                    }

                    //* for d classseat*/
                    int mtrack = 1;
                    int mtmax = 7;

                    while (mtrack < mtmax)
                    {
                        MySqlCommand selectcommand = new MySqlCommand("insert into Seat values ('','" + airnum + "', '" + cseat + "', 'D', '" + mtrack + "', 0 );", SQLConnection.Instance.GetConnection());
                        selectcommand.ExecuteNonQuery();
                        mtrack++;
                    }

                    //only if 30 seats 
                    //* for e classseat*/
                    //int etrack = 1;
                    //int etmax = 7;

                    //while (etrack < etmax)
                    //{
                    //    MySqlCommand selectcommand = new MySqlCommand("insert into Seat values ('','" + airnum + "', '" + cseat + "', 'E', '" + etrack + "', 0 );", SQLConnection.Instance.GetConnection());
                    //    selectcommand.ExecuteNonQuery();
                    //    etrack++;
                    //}

                    count++;
                }

                airnum++;

            }
            SQLConnection.Instance.CloseConnection();

            MessageBox.Show("SQL Filled");


        }


    }
}
