namespace Airline_Semester_Project_attempt4
{
    partial class Seating_Update
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
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.pass_info_label = new System.Windows.Forms.Label();
            this.next_seat_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.economicclass_button = new System.Windows.Forms.Button();
            this.businessclass_button = new System.Windows.Forms.Button();
            this.firstclass_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(28, 165);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(3000, 3);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 3);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(1374, 3);
            this.lineSeparator1.TabIndex = 13;
            // 
            // pass_info_label
            // 
            this.pass_info_label.AutoSize = true;
            this.pass_info_label.Font = new System.Drawing.Font("Lucida Bright", 15F);
            this.pass_info_label.Location = new System.Drawing.Point(22, 103);
            this.pass_info_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pass_info_label.Name = "pass_info_label";
            this.pass_info_label.Size = new System.Drawing.Size(102, 34);
            this.pass_info_label.TabIndex = 12;
            this.pass_info_label.Text = "label2";
            // 
            // next_seat_button
            // 
            this.next_seat_button.Location = new System.Drawing.Point(1278, 428);
            this.next_seat_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.next_seat_button.Name = "next_seat_button";
            this.next_seat_button.Size = new System.Drawing.Size(124, 30);
            this.next_seat_button.TabIndex = 1;
            this.next_seat_button.Text = "Next";
            this.next_seat_button.UseVisualStyleBackColor = true;
            this.next_seat_button.Click += new System.EventHandler(this.next_seat_button_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 20F);
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seating";
            // 
            // economicclass_button
            // 
            this.economicclass_button.BackColor = System.Drawing.Color.GhostWhite;
            this.economicclass_button.Location = new System.Drawing.Point(1000, 190);
            this.economicclass_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.economicclass_button.Name = "economicclass_button";
            this.economicclass_button.Size = new System.Drawing.Size(402, 198);
            this.economicclass_button.TabIndex = 9;
            this.economicclass_button.Text = "Economic";
            this.economicclass_button.UseVisualStyleBackColor = false;
            this.economicclass_button.Click += new System.EventHandler(this.economicclass_button_Click);
            // 
            // businessclass_button
            // 
            this.businessclass_button.BackColor = System.Drawing.Color.GhostWhite;
            this.businessclass_button.Location = new System.Drawing.Point(519, 190);
            this.businessclass_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.businessclass_button.Name = "businessclass_button";
            this.businessclass_button.Size = new System.Drawing.Size(402, 198);
            this.businessclass_button.TabIndex = 8;
            this.businessclass_button.Text = "Business";
            this.businessclass_button.UseVisualStyleBackColor = false;
            this.businessclass_button.Click += new System.EventHandler(this.businessclass_button_Click);
            // 
            // firstclass_button
            // 
            this.firstclass_button.BackColor = System.Drawing.Color.GhostWhite;
            this.firstclass_button.Location = new System.Drawing.Point(28, 190);
            this.firstclass_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstclass_button.Name = "firstclass_button";
            this.firstclass_button.Size = new System.Drawing.Size(402, 198);
            this.firstclass_button.TabIndex = 7;
            this.firstclass_button.Text = "First Class ";
            this.firstclass_button.UseVisualStyleBackColor = false;
            this.firstclass_button.Click += new System.EventHandler(this.firstclass_button_Click_1);
            // 
            // Seating_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 481);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.pass_info_label);
            this.Controls.Add(this.next_seat_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.economicclass_button);
            this.Controls.Add(this.businessclass_button);
            this.Controls.Add(this.firstclass_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Seating_Update";
            this.Text = "Seating_Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LineSeparator lineSeparator1;
        private System.Windows.Forms.Label pass_info_label;
        private System.Windows.Forms.Button next_seat_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button economicclass_button;
        private System.Windows.Forms.Button businessclass_button;
        private System.Windows.Forms.Button firstclass_button;
    }
}