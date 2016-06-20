namespace Airline_Semester_Project_attempt4
{
    partial class Account
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
            this.account_label = new System.Windows.Forms.Label();
            this.update_account = new System.Windows.Forms.Button();
            this.flight_button = new System.Windows.Forms.Button();
            this.reserve_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.account_richtextbox = new System.Windows.Forms.RichTextBox();
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logoff_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // account_label
            // 
            this.account_label.AutoSize = true;
            this.account_label.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.account_label.Location = new System.Drawing.Point(12, 9);
            this.account_label.Name = "account_label";
            this.account_label.Size = new System.Drawing.Size(171, 20);
            this.account_label.TabIndex = 0;
            this.account_label.Text = "Account Information:";
            // 
            // update_account
            // 
            this.update_account.Location = new System.Drawing.Point(611, 12);
            this.update_account.Name = "update_account";
            this.update_account.Size = new System.Drawing.Size(83, 23);
            this.update_account.TabIndex = 1;
            this.update_account.Text = "Update";
            this.update_account.UseVisualStyleBackColor = true;
            this.update_account.Click += new System.EventHandler(this.update_account_Click);
            // 
            // flight_button
            // 
            this.flight_button.Location = new System.Drawing.Point(837, 9);
            this.flight_button.Name = "flight_button";
            this.flight_button.Size = new System.Drawing.Size(83, 23);
            this.flight_button.TabIndex = 2;
            this.flight_button.Text = "Flights";
            this.flight_button.UseVisualStyleBackColor = true;
            this.flight_button.Click += new System.EventHandler(this.flight_button_Click);
            // 
            // reserve_button
            // 
            this.reserve_button.Location = new System.Drawing.Point(611, 58);
            this.reserve_button.Name = "reserve_button";
            this.reserve_button.Size = new System.Drawing.Size(83, 23);
            this.reserve_button.TabIndex = 3;
            this.reserve_button.Text = "View Reserve";
            this.reserve_button.UseVisualStyleBackColor = true;
            this.reserve_button.Click += new System.EventHandler(this.reserve_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label1.Location = new System.Drawing.Point(409, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "View Previous Reservations:";
            // 
            // account_richtextbox
            // 
            this.account_richtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.account_richtextbox.Location = new System.Drawing.Point(16, 97);
            this.account_richtextbox.Margin = new System.Windows.Forms.Padding(2);
            this.account_richtextbox.Name = "account_richtextbox";
            this.account_richtextbox.ReadOnly = true;
            this.account_richtextbox.Size = new System.Drawing.Size(923, 213);
            this.account_richtextbox.TabIndex = 8;
            this.account_richtextbox.Text = "";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(33, 86);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(887, 2);
            this.lineSeparator1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label2.Location = new System.Drawing.Point(456, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Update Account Info: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label3.Location = new System.Drawing.Point(699, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search for Flights:";
            // 
            // logoff_button
            // 
            this.logoff_button.Location = new System.Drawing.Point(837, 55);
            this.logoff_button.Name = "logoff_button";
            this.logoff_button.Size = new System.Drawing.Size(75, 23);
            this.logoff_button.TabIndex = 11;
            this.logoff_button.Text = "Log Off";
            this.logoff_button.UseVisualStyleBackColor = true;
            this.logoff_button.Click += new System.EventHandler(this.logoff_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label4.Location = new System.Drawing.Point(760, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sign Off:";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(953, 318);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logoff_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.account_richtextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.reserve_button);
            this.Controls.Add(this.flight_button);
            this.Controls.Add(this.update_account);
            this.Controls.Add(this.account_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Account";
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label account_label;
        private System.Windows.Forms.Button update_account;
        private System.Windows.Forms.Button flight_button;
        private System.Windows.Forms.Button reserve_button;
        private LineSeparator lineSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox account_richtextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button logoff_button;
        private System.Windows.Forms.Label label4;
    }
}