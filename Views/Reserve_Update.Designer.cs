namespace Airline_Semester_Project_attempt4
{
    partial class Reserve_Update
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
            this.label2 = new System.Windows.Forms.Label();
            this.reservations_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reservations_comboBox1 = new System.Windows.Forms.ComboBox();
            this.submit_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel_button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservations ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label2.Location = new System.Drawing.Point(21, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scheduled Flights:";
            // 
            // reservations_richTextBox1
            // 
            this.reservations_richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.reservations_richTextBox1.Location = new System.Drawing.Point(28, 177);
            this.reservations_richTextBox1.Name = "reservations_richTextBox1";
            this.reservations_richTextBox1.ReadOnly = true;
            this.reservations_richTextBox1.Size = new System.Drawing.Size(1195, 342);
            this.reservations_richTextBox1.TabIndex = 3;
            this.reservations_richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label3.Location = new System.Drawing.Point(840, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Reservation: ";
            // 
            // reservations_comboBox1
            // 
            this.reservations_comboBox1.FormattingEnabled = true;
            this.reservations_comboBox1.Location = new System.Drawing.Point(1101, 17);
            this.reservations_comboBox1.Name = "reservations_comboBox1";
            this.reservations_comboBox1.Size = new System.Drawing.Size(121, 28);
            this.reservations_comboBox1.TabIndex = 1;
            this.reservations_comboBox1.SelectedIndexChanged += new System.EventHandler(this.reservations_comboBox1_SelectedIndexChanged);
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(1101, 74);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(123, 37);
            this.submit_button.TabIndex = 2;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label4.Location = new System.Drawing.Point(829, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Update Reservation:";
            // 
            // cancel_button1
            // 
            this.cancel_button1.Location = new System.Drawing.Point(1100, 134);
            this.cancel_button1.Name = "cancel_button1";
            this.cancel_button1.Size = new System.Drawing.Size(123, 37);
            this.cancel_button1.TabIndex = 3;
            this.cancel_button1.Text = "Back";
            this.cancel_button1.UseVisualStyleBackColor = true;
            this.cancel_button1.Click += new System.EventHandler(this.cancel_button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label5.Location = new System.Drawing.Point(960, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Account:";
            // 
            // Reserve_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 531);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancel_button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.reservations_comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reservations_richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reserve_Update";
            this.Text = "Reservations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox reservations_richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox reservations_comboBox1;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancel_button1;
        private System.Windows.Forms.Label label5;
    }
}