namespace Airline_Semester_Project_attempt4
{
    partial class Login
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
            this.login_username_text = new System.Windows.Forms.Label();
            this.login_password_text = new System.Windows.Forms.Label();
            this.login_user_textbox = new System.Windows.Forms.TextBox();
            this.login_pass_textbox = new System.Windows.Forms.TextBox();
            this.login_login_button = new System.Windows.Forms.Button();
            this.login_cancel_button = new System.Windows.Forms.Button();
            this.login_title = new System.Windows.Forms.Label();
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.lineSeparator2 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.SuspendLayout();
            // 
            // login_username_text
            // 
            this.login_username_text.AutoSize = true;
            this.login_username_text.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.login_username_text.Location = new System.Drawing.Point(85, 112);
            this.login_username_text.Name = "login_username_text";
            this.login_username_text.Size = new System.Drawing.Size(78, 16);
            this.login_username_text.TabIndex = 0;
            this.login_username_text.Text = "Username:";
            // 
            // login_password_text
            // 
            this.login_password_text.AutoSize = true;
            this.login_password_text.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.login_password_text.Location = new System.Drawing.Point(87, 177);
            this.login_password_text.Name = "login_password_text";
            this.login_password_text.Size = new System.Drawing.Size(76, 16);
            this.login_password_text.TabIndex = 1;
            this.login_password_text.Text = "Password:";
            // 
            // login_user_textbox
            // 
            this.login_user_textbox.Location = new System.Drawing.Point(233, 109);
            this.login_user_textbox.Name = "login_user_textbox";
            this.login_user_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_user_textbox.TabIndex = 1;
            // 
            // login_pass_textbox
            // 
            this.login_pass_textbox.Location = new System.Drawing.Point(233, 177);
            this.login_pass_textbox.Name = "login_pass_textbox";
            this.login_pass_textbox.PasswordChar = '*';
            this.login_pass_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_pass_textbox.TabIndex = 2;
            // 
            // login_login_button
            // 
            this.login_login_button.Location = new System.Drawing.Point(47, 301);
            this.login_login_button.Name = "login_login_button";
            this.login_login_button.Size = new System.Drawing.Size(75, 23);
            this.login_login_button.TabIndex = 3;
            this.login_login_button.Text = "Login";
            this.login_login_button.UseVisualStyleBackColor = true;
            this.login_login_button.Click += new System.EventHandler(this.login_login_button_Click);
            // 
            // login_cancel_button
            // 
            this.login_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.login_cancel_button.Location = new System.Drawing.Point(322, 301);
            this.login_cancel_button.Name = "login_cancel_button";
            this.login_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.login_cancel_button.TabIndex = 4;
            this.login_cancel_button.Text = "Cancel";
            this.login_cancel_button.UseVisualStyleBackColor = true;
            this.login_cancel_button.Click += new System.EventHandler(this.login_cancel_button_Click);
            // 
            // login_title
            // 
            this.login_title.AutoSize = true;
            this.login_title.Font = new System.Drawing.Font("Lucida Bright", 20F);
            this.login_title.Location = new System.Drawing.Point(12, 9);
            this.login_title.Name = "login_title";
            this.login_title.Size = new System.Drawing.Size(89, 32);
            this.login_title.TabIndex = 6;
            this.login_title.Text = "Login";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(47, 66);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(350, 2);
            this.lineSeparator1.TabIndex = 7;
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(47, 226);
            this.lineSeparator2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(350, 2);
            this.lineSeparator2.TabIndex = 8;
            // 
            // Login
            // 
            this.AcceptButton = this.login_login_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.login_cancel_button;
            this.ClientSize = new System.Drawing.Size(452, 359);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.login_title);
            this.Controls.Add(this.login_cancel_button);
            this.Controls.Add(this.login_login_button);
            this.Controls.Add(this.login_pass_textbox);
            this.Controls.Add(this.login_user_textbox);
            this.Controls.Add(this.login_password_text);
            this.Controls.Add(this.login_username_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_username_text;
        private System.Windows.Forms.Label login_password_text;
        private System.Windows.Forms.TextBox login_user_textbox;
        private System.Windows.Forms.TextBox login_pass_textbox;
        private System.Windows.Forms.Button login_login_button;
        private System.Windows.Forms.Button login_cancel_button;
        private System.Windows.Forms.Label login_title;
        private LineSeparator lineSeparator1;
        private LineSeparator lineSeparator2;
    }
}