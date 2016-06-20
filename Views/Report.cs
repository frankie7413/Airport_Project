using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Semester_Project_attempt4
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            fillComboBox();
            this.Show();
        }

        private void fillComboBox()
        {

            string num_of_pass, num_of_seats, num_of_reserves;
            num_of_pass = "Number of Passengers Created";
            num_of_seats = "Number of Seats Availabe";
            num_of_reserves = "Number of Reserves";

            report_comboBox1.Items.Add(num_of_pass);
            report_comboBox1.Items.Add(num_of_seats);
            report_comboBox1.Items.Add(num_of_reserves);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in Progress");
        }




    }
}
