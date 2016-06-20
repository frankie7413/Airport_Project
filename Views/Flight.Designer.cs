namespace Airline_Semester_Project_attempt4
{
    partial class Flight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.search_query_button = new System.Windows.Forms.Button();
            this.Depart_combobox = new System.Windows.Forms.ComboBox();
            this.Arrival_combobox = new System.Windows.Forms.ComboBox();
            this.Depart_Date = new System.Windows.Forms.DateTimePicker();
            this.result_datagrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.SFlight = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.adult_comboBox1 = new System.Windows.Forms.ComboBox();
            this.child_comboBox2 = new System.Windows.Forms.ComboBox();
            this.infant_comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.lineSeparator2 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.lineSeparator3 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.result_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 20F);
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search - One Way";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // search_query_button
            // 
            this.search_query_button.Location = new System.Drawing.Point(694, 160);
            this.search_query_button.Name = "search_query_button";
            this.search_query_button.Size = new System.Drawing.Size(75, 23);
            this.search_query_button.TabIndex = 7;
            this.search_query_button.Text = "Search";
            this.search_query_button.UseVisualStyleBackColor = true;
            this.search_query_button.Click += new System.EventHandler(this.search_query_button_Click);
            // 
            // Depart_combobox
            // 
            this.Depart_combobox.FormattingEnabled = true;
            this.Depart_combobox.Location = new System.Drawing.Point(19, 78);
            this.Depart_combobox.Name = "Depart_combobox";
            this.Depart_combobox.Size = new System.Drawing.Size(242, 21);
            this.Depart_combobox.Sorted = true;
            this.Depart_combobox.TabIndex = 1;
            this.Depart_combobox.SelectedIndexChanged += new System.EventHandler(this.Depart_combobox_SelectedIndexChanged);
            // 
            // Arrival_combobox
            // 
            this.Arrival_combobox.FormattingEnabled = true;
            this.Arrival_combobox.Location = new System.Drawing.Point(331, 78);
            this.Arrival_combobox.Name = "Arrival_combobox";
            this.Arrival_combobox.Size = new System.Drawing.Size(242, 21);
            this.Arrival_combobox.Sorted = true;
            this.Arrival_combobox.TabIndex = 2;
            this.Arrival_combobox.SelectedIndexChanged += new System.EventHandler(this.Arrival_combobox_SelectedIndexChanged);
            // 
            // Depart_Date
            // 
            this.Depart_Date.Location = new System.Drawing.Point(694, 79);
            this.Depart_Date.MaxDate = new System.DateTime(2016, 2, 12, 0, 0, 0, 0);
            this.Depart_Date.Name = "Depart_Date";
            this.Depart_Date.Size = new System.Drawing.Size(200, 20);
            this.Depart_Date.TabIndex = 3;
            this.Depart_Date.Value = new System.DateTime(2014, 12, 8, 0, 0, 0, 0);
            this.Depart_Date.ValueChanged += new System.EventHandler(this.Depart_Date_ValueChanged);
            // 
            // result_datagrid
            // 
            this.result_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.result_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_datagrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.result_datagrid.Location = new System.Drawing.Point(0, 242);
            this.result_datagrid.Name = "result_datagrid";
            this.result_datagrid.Size = new System.Drawing.Size(1223, 154);
            this.result_datagrid.TabIndex = 6;
            this.result_datagrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result_datagrid_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(5, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Results";
            // 
            // SFlight
            // 
            this.SFlight.Location = new System.Drawing.Point(1020, 80);
            this.SFlight.Name = "SFlight";
            this.SFlight.Size = new System.Drawing.Size(75, 23);
            this.SFlight.TabIndex = 8;
            this.SFlight.Text = "Select";
            this.SFlight.UseVisualStyleBackColor = true;
            this.SFlight.Click += new System.EventHandler(this.SFlight_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label5.Location = new System.Drawing.Point(16, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Adult*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label6.Location = new System.Drawing.Point(195, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Child (2 - 11)*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label7.Location = new System.Drawing.Point(384, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Infant";
            // 
            // adult_comboBox1
            // 
            this.adult_comboBox1.FormattingEnabled = true;
            this.adult_comboBox1.Location = new System.Drawing.Point(19, 162);
            this.adult_comboBox1.Name = "adult_comboBox1";
            this.adult_comboBox1.Size = new System.Drawing.Size(121, 21);
            this.adult_comboBox1.TabIndex = 4;
            this.adult_comboBox1.SelectedIndexChanged += new System.EventHandler(this.adult_comboBox1_SelectedIndexChanged);
            // 
            // child_comboBox2
            // 
            this.child_comboBox2.FormattingEnabled = true;
            this.child_comboBox2.Location = new System.Drawing.Point(198, 162);
            this.child_comboBox2.Name = "child_comboBox2";
            this.child_comboBox2.Size = new System.Drawing.Size(121, 21);
            this.child_comboBox2.TabIndex = 5;
            // 
            // infant_comboBox3
            // 
            this.infant_comboBox3.FormattingEnabled = true;
            this.infant_comboBox3.Location = new System.Drawing.Point(387, 162);
            this.infant_comboBox3.Name = "infant_comboBox3";
            this.infant_comboBox3.Size = new System.Drawing.Size(121, 21);
            this.infant_comboBox3.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label9.Location = new System.Drawing.Point(978, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "* field must be filled in";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(0, 0);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(350, 2);
            this.lineSeparator1.TabIndex = 19;
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(0, 0);
            this.lineSeparator2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(350, 2);
            this.lineSeparator2.TabIndex = 20;
            // 
            // lineSeparator3
            // 
            this.lineSeparator3.Location = new System.Drawing.Point(30, 203);
            this.lineSeparator3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator3.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator3.Name = "lineSeparator3";
            this.lineSeparator3.Size = new System.Drawing.Size(1137, 2);
            this.lineSeparator3.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label10.Location = new System.Drawing.Point(695, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Search Flights";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label11.Location = new System.Drawing.Point(1017, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Select Flight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Depart Airport*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label3.Location = new System.Drawing.Point(328, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Arrival Airport*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label8.Location = new System.Drawing.Point(691, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "Date*";
            // 
            // Flight
            // 
            this.AcceptButton = this.SFlight;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1223, 396);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lineSeparator3);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.result_datagrid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.infant_comboBox3);
            this.Controls.Add(this.child_comboBox2);
            this.Controls.Add(this.adult_comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SFlight);
            this.Controls.Add(this.Depart_Date);
            this.Controls.Add(this.Arrival_combobox);
            this.Controls.Add(this.Depart_combobox);
            this.Controls.Add(this.search_query_button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Flight";
            this.Text = "Flights";
            ((System.ComponentModel.ISupportInitialize)(this.result_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search_query_button;
        private System.Windows.Forms.ComboBox Depart_combobox;
        private System.Windows.Forms.ComboBox Arrival_combobox;
        private System.Windows.Forms.DateTimePicker Depart_Date;
        private System.Windows.Forms.DataGridView result_datagrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SFlight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox adult_comboBox1;
        private System.Windows.Forms.ComboBox child_comboBox2;
        private System.Windows.Forms.ComboBox infant_comboBox3;
        private System.Windows.Forms.Label label9;
        private LineSeparator lineSeparator1;
        private LineSeparator lineSeparator2;
        private LineSeparator lineSeparator3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}

