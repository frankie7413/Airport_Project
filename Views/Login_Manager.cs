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
    public partial class Login_Manager : Form
    {
        public Login_Manager()
        {
            InitializeComponent();
            this.Show();
        }

        private void mlogin_button1_Click(object sender, EventArgs e)
        {

            string name = name_man_textbox.Text;
            string pass = pass_man_textbox.Text;

            if(name == "Manage" && pass == "Kanye")
            {
                MessageBox.Show("Credentials Valid");
                Report open = new Report();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials.");
            }

        }
    }
}
