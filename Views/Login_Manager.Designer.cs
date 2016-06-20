namespace Airline_Semester_Project_attempt4
{
    partial class Login_Manager
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
            this.lineSeparator2 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.login_title = new System.Windows.Forms.Label();
            this.pass_man_textbox = new System.Windows.Forms.TextBox();
            this.name_man_textbox = new System.Windows.Forms.TextBox();
            this.login_password_text = new System.Windows.Forms.Label();
            this.login_username_text = new System.Windows.Forms.Label();
            this.mlogin_button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(65, 358);
            this.lineSeparator2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(3000, 3);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 3);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(525, 3);
            this.lineSeparator2.TabIndex = 15;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(65, 112);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(3000, 3);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 3);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(525, 3);
            this.lineSeparator1.TabIndex = 14;
            // 
            // login_title
            // 
            this.login_title.AutoSize = true;
            this.login_title.Font = new System.Drawing.Font("Lucida Bright", 20F);
            this.login_title.Location = new System.Drawing.Point(13, 24);
            this.login_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_title.Name = "login_title";
            this.login_title.Size = new System.Drawing.Size(127, 45);
            this.login_title.TabIndex = 13;
            this.login_title.Text = "Login";
            // 
            // pass_man_textbox
            // 
            this.pass_man_textbox.Location = new System.Drawing.Point(345, 282);
            this.pass_man_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pass_man_textbox.Name = "pass_man_textbox";
            this.pass_man_textbox.PasswordChar = '*';
            this.pass_man_textbox.Size = new System.Drawing.Size(148, 26);
            this.pass_man_textbox.TabIndex = 2;
            // 
            // name_man_textbox
            // 
            this.name_man_textbox.Location = new System.Drawing.Point(345, 178);
            this.name_man_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.name_man_textbox.Name = "name_man_textbox";
            this.name_man_textbox.Size = new System.Drawing.Size(148, 26);
            this.name_man_textbox.TabIndex = 1;
            // 
            // login_password_text
            // 
            this.login_password_text.AutoSize = true;
            this.login_password_text.Location = new System.Drawing.Point(125, 282);
            this.login_password_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_password_text.Name = "login_password_text";
            this.login_password_text.Size = new System.Drawing.Size(78, 20);
            this.login_password_text.TabIndex = 11;
            this.login_password_text.Text = "Password";
            // 
            // login_username_text
            // 
            this.login_username_text.AutoSize = true;
            this.login_username_text.Location = new System.Drawing.Point(123, 182);
            this.login_username_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_username_text.Name = "login_username_text";
            this.login_username_text.Size = new System.Drawing.Size(83, 20);
            this.login_username_text.TabIndex = 9;
            this.login_username_text.Text = "Username";
            // 
            // mlogin_button1
            // 
            this.mlogin_button1.Location = new System.Drawing.Point(74, 457);
            this.mlogin_button1.Name = "mlogin_button1";
            this.mlogin_button1.Size = new System.Drawing.Size(112, 35);
            this.mlogin_button1.TabIndex = 16;
            this.mlogin_button1.Text = "Login";
            this.mlogin_button1.UseVisualStyleBackColor = true;
            this.mlogin_button1.Click += new System.EventHandler(this.mlogin_button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(381, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Login_Manager
            // 
            this.AcceptButton = this.mlogin_button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(649, 574);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mlogin_button1);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.login_title);
            this.Controls.Add(this.pass_man_textbox);
            this.Controls.Add(this.name_man_textbox);
            this.Controls.Add(this.login_password_text);
            this.Controls.Add(this.login_username_text);
            this.Name = "Login_Manager";
            this.Text = "Login_Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LineSeparator lineSeparator2;
        private LineSeparator lineSeparator1;
        private System.Windows.Forms.Label login_title;
        private System.Windows.Forms.TextBox pass_man_textbox;
        private System.Windows.Forms.TextBox name_man_textbox;
        private System.Windows.Forms.Label login_password_text;
        private System.Windows.Forms.Label login_username_text;
        private System.Windows.Forms.Button mlogin_button1;
        private System.Windows.Forms.Button button2;
    }
}