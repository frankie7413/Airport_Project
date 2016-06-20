namespace Airline_Semester_Project_attempt4
{
    partial class Payment
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cardnum_textbox = new System.Windows.Forms.TextBox();
            this.cvc_textbox = new System.Windows.Forms.TextBox();
            this.next_payment_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.total_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.carddateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cardowner_textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lineSeparator1 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.lineSeparator2 = new Airline_Semester_Project_attempt4.LineSeparator();
            this.cardtype_comboBox1 = new System.Windows.Forms.ComboBox();
            this.discount_textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 20F);
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label3.Location = new System.Drawing.Point(58, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card No (Last 4 digits)*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label4.Location = new System.Drawing.Point(54, 370);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Expiration Date*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label5.Location = new System.Drawing.Point(58, 447);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "CVC Number(3)*";
            // 
            // cardnum_textbox
            // 
            this.cardnum_textbox.Location = new System.Drawing.Point(306, 248);
            this.cardnum_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cardnum_textbox.Name = "cardnum_textbox";
            this.cardnum_textbox.Size = new System.Drawing.Size(298, 26);
            this.cardnum_textbox.TabIndex = 3;
            // 
            // cvc_textbox
            // 
            this.cvc_textbox.Location = new System.Drawing.Point(306, 444);
            this.cvc_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cvc_textbox.Name = "cvc_textbox";
            this.cvc_textbox.Size = new System.Drawing.Size(298, 26);
            this.cvc_textbox.TabIndex = 6;
            // 
            // next_payment_button
            // 
            this.next_payment_button.Location = new System.Drawing.Point(506, 568);
            this.next_payment_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.next_payment_button.Name = "next_payment_button";
            this.next_payment_button.Size = new System.Drawing.Size(112, 35);
            this.next_payment_button.TabIndex = 7;
            this.next_payment_button.Text = "Next";
            this.next_payment_button.UseVisualStyleBackColor = true;
            this.next_payment_button.Click += new System.EventHandler(this.next_payment_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label6.Location = new System.Drawing.Point(58, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total: ";
            // 
            // total_textBox
            // 
            this.total_textBox.Location = new System.Drawing.Point(306, 95);
            this.total_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.total_textBox.Name = "total_textBox";
            this.total_textBox.ReadOnly = true;
            this.total_textBox.Size = new System.Drawing.Size(298, 26);
            this.total_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label2.Location = new System.Drawing.Point(58, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Card Type*:";
            // 
            // carddateTimePicker1
            // 
            this.carddateTimePicker1.Location = new System.Drawing.Point(306, 367);
            this.carddateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.carddateTimePicker1.Name = "carddateTimePicker1";
            this.carddateTimePicker1.Size = new System.Drawing.Size(298, 26);
            this.carddateTimePicker1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label7.Location = new System.Drawing.Point(58, 308);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Card Owner*";
            // 
            // cardowner_textBox1
            // 
            this.cardowner_textBox1.Location = new System.Drawing.Point(306, 305);
            this.cardowner_textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cardowner_textBox1.Name = "cardowner_textBox1";
            this.cardowner_textBox1.Size = new System.Drawing.Size(298, 26);
            this.cardowner_textBox1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label9.Location = new System.Drawing.Point(490, 645);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "* field must be filled in";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(58, 68);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(3000, 3);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 3);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(560, 3);
            this.lineSeparator1.TabIndex = 20;
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(58, 529);
            this.lineSeparator2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(3000, 3);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 3);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(560, 3);
            this.lineSeparator2.TabIndex = 21;
            // 
            // cardtype_comboBox1
            // 
            this.cardtype_comboBox1.FormattingEnabled = true;
            this.cardtype_comboBox1.Location = new System.Drawing.Point(306, 188);
            this.cardtype_comboBox1.Name = "cardtype_comboBox1";
            this.cardtype_comboBox1.Size = new System.Drawing.Size(298, 28);
            this.cardtype_comboBox1.TabIndex = 2;
            // 
            // discount_textBox1
            // 
            this.discount_textBox1.Location = new System.Drawing.Point(306, 140);
            this.discount_textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.discount_textBox1.Name = "discount_textBox1";
            this.discount_textBox1.ReadOnly = true;
            this.discount_textBox1.Size = new System.Drawing.Size(298, 26);
            this.discount_textBox1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.label8.Location = new System.Drawing.Point(58, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "Discount: ";
            // 
            // Payment
            // 
            this.AcceptButton = this.next_payment_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 677);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.discount_textBox1);
            this.Controls.Add(this.cardtype_comboBox1);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cardowner_textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.carddateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.total_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.next_payment_button);
            this.Controls.Add(this.cvc_textbox);
            this.Controls.Add(this.cardnum_textbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cardnum_textbox;
        private System.Windows.Forms.TextBox cvc_textbox;
        private System.Windows.Forms.Button next_payment_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox total_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker carddateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cardowner_textBox1;
        private System.Windows.Forms.Label label9;
        private LineSeparator lineSeparator1;
        private LineSeparator lineSeparator2;
        private System.Windows.Forms.ComboBox cardtype_comboBox1;
        private System.Windows.Forms.TextBox discount_textBox1;
        private System.Windows.Forms.Label label8;
    }
}

