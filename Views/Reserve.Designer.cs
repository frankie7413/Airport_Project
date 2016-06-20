namespace Airline_Semester_Project_attempt4
{
    partial class Reserve
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
            this.reserve_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logoff_button1 = new System.Windows.Forms.Button();
            this.account_button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reserve_textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flight_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.payment_textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reserve_label
            // 
            this.reserve_label.AutoSize = true;
            this.reserve_label.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.reserve_label.Location = new System.Drawing.Point(18, 31);
            this.reserve_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reserve_label.Name = "reserve_label";
            this.reserve_label.Size = new System.Drawing.Size(307, 28);
            this.reserve_label.TabIndex = 0;
            this.reserve_label.Text = "Reservation for Account: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(18, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passengers:";
            // 
            // logoff_button1
            // 
            this.logoff_button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.logoff_button1.Location = new System.Drawing.Point(1094, 163);
            this.logoff_button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoff_button1.Name = "logoff_button1";
            this.logoff_button1.Size = new System.Drawing.Size(112, 35);
            this.logoff_button1.TabIndex = 2;
            this.logoff_button1.Text = "Logoff";
            this.logoff_button1.UseVisualStyleBackColor = true;
            this.logoff_button1.Click += new System.EventHandler(this.logoff_button1_Click);
            // 
            // account_button2
            // 
            this.account_button2.Location = new System.Drawing.Point(900, 163);
            this.account_button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.account_button2.Name = "account_button2";
            this.account_button2.Size = new System.Drawing.Size(112, 35);
            this.account_button2.TabIndex = 1;
            this.account_button2.Text = "Account";
            this.account_button2.UseVisualStyleBackColor = true;
            this.account_button2.Click += new System.EventHandler(this.account_button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label3.Location = new System.Drawing.Point(793, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reservation Code:";
            // 
            // reserve_textBox1
            // 
            this.reserve_textBox1.Location = new System.Drawing.Point(1058, 35);
            this.reserve_textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reserve_textBox1.Name = "reserve_textBox1";
            this.reserve_textBox1.ReadOnly = true;
            this.reserve_textBox1.Size = new System.Drawing.Size(148, 26);
            this.reserve_textBox1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(24, 220);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1195, 282);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // flight_label
            // 
            this.flight_label.AutoSize = true;
            this.flight_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.flight_label.Location = new System.Drawing.Point(20, 122);
            this.flight_label.Name = "flight_label";
            this.flight_label.Size = new System.Drawing.Size(79, 29);
            this.flight_label.TabIndex = 8;
            this.flight_label.Text = "Flight:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label1.Location = new System.Drawing.Point(827, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Payment:";
            // 
            // payment_textBox2
            // 
            this.payment_textBox2.Location = new System.Drawing.Point(1058, 95);
            this.payment_textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.payment_textBox2.Name = "payment_textBox2";
            this.payment_textBox2.ReadOnly = true;
            this.payment_textBox2.Size = new System.Drawing.Size(148, 26);
            this.payment_textBox2.TabIndex = 11;
            // 
            // Reserve
            // 
            this.AcceptButton = this.account_button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.logoff_button1;
            this.ClientSize = new System.Drawing.Size(1240, 531);
            this.Controls.Add(this.payment_textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flight_label);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.reserve_textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.account_button2);
            this.Controls.Add(this.logoff_button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reserve_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reserve";
            this.Text = "Reserve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reserve_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logoff_button1;
        private System.Windows.Forms.Button account_button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reserve_textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label flight_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox payment_textBox2;
    }
}