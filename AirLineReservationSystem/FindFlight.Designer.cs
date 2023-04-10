namespace AirLineReservationSystem
{
    partial class FindFlight
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cmbxTicketTypes = new System.Windows.Forms.ComboBox();
            this.cmbxChildren = new System.Windows.Forms.ComboBox();
            this.cmbAdults = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbOneWay = new System.Windows.Forms.RadioButton();
            this.rdReturn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBookFlightBack = new System.Windows.Forms.Label();
            this.lblConfirmFlight = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(303, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find My Flight";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 66);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.MinDate = new System.DateTime(2016, 1, 2, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2016, 1, 3, 8, 19, 58, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(431, 66);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.MinDate = new System.DateTime(2016, 1, 2, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.Value = new System.DateTime(2016, 1, 3, 8, 20, 19, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // cmbxTicketTypes
            // 
            this.cmbxTicketTypes.FormattingEnabled = true;
            this.cmbxTicketTypes.Location = new System.Drawing.Point(237, 41);
            this.cmbxTicketTypes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbxTicketTypes.Name = "cmbxTicketTypes";
            this.cmbxTicketTypes.Size = new System.Drawing.Size(160, 24);
            this.cmbxTicketTypes.TabIndex = 5;
            this.cmbxTicketTypes.SelectedIndexChanged += new System.EventHandler(this.cmbxTicketTypes_SelectedIndexChanged);
            // 
            // cmbxChildren
            // 
            this.cmbxChildren.FormattingEnabled = true;
            this.cmbxChildren.Location = new System.Drawing.Point(389, 46);
            this.cmbxChildren.Margin = new System.Windows.Forms.Padding(4);
            this.cmbxChildren.Name = "cmbxChildren";
            this.cmbxChildren.Size = new System.Drawing.Size(115, 24);
            this.cmbxChildren.TabIndex = 6;
            this.cmbxChildren.SelectedIndexChanged += new System.EventHandler(this.cmbxChildren_SelectedIndexChanged);
            // 
            // cmbAdults
            // 
            this.cmbAdults.FormattingEnabled = true;
            this.cmbAdults.Location = new System.Drawing.Point(119, 46);
            this.cmbAdults.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAdults.Name = "cmbAdults";
            this.cmbAdults.Size = new System.Drawing.Size(115, 24);
            this.cmbAdults.TabIndex = 7;
            this.cmbAdults.SelectedIndexChanged += new System.EventHandler(this.cmbAdults_SelectedIndexChanged);
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(536, 55);
            this.cmbTo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(160, 24);
            this.cmbTo.TabIndex = 8;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            this.cmbTo.SelectionChangeCommitted += new System.EventHandler(this.cmbTo_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbOneWay);
            this.groupBox1.Controls.Add(this.rdReturn);
            this.groupBox1.Controls.Add(this.cmbTo);
            this.groupBox1.Location = new System.Drawing.Point(312, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(795, 149);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(87, 68);
            this.cmbFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(160, 24);
            this.cmbFrom.TabIndex = 18;
            this.cmbFrom.SelectedIndexChanged += new System.EventHandler(this.cmbFrom_SelectedIndexChanged);
            this.cmbFrom.SelectionChangeCommitted += new System.EventHandler(this.cmbFrom_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(532, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(83, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "From";
            // 
            // rbOneWay
            // 
            this.rbOneWay.AutoSize = true;
            this.rbOneWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOneWay.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbOneWay.Location = new System.Drawing.Point(392, 103);
            this.rbOneWay.Margin = new System.Windows.Forms.Padding(4);
            this.rbOneWay.Name = "rbOneWay";
            this.rbOneWay.Size = new System.Drawing.Size(99, 24);
            this.rbOneWay.TabIndex = 10;
            this.rbOneWay.Text = "One Way";
            this.rbOneWay.UseVisualStyleBackColor = true;
            this.rbOneWay.CheckedChanged += new System.EventHandler(this.rbOneWay_CheckedChanged);
            // 
            // rdReturn
            // 
            this.rdReturn.AutoSize = true;
            this.rdReturn.Checked = true;
            this.rdReturn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdReturn.Location = new System.Drawing.Point(296, 101);
            this.rdReturn.Margin = new System.Windows.Forms.Padding(4);
            this.rdReturn.Name = "rdReturn";
            this.rdReturn.Size = new System.Drawing.Size(86, 28);
            this.rdReturn.TabIndex = 11;
            this.rdReturn.TabStop = true;
            this.rdReturn.Text = "Return";
            this.rdReturn.UseVisualStyleBackColor = true;
            this.rdReturn.CheckedChanged += new System.EventHandler(this.rdReturn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(312, 231);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(795, 171);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(532, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Return";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(197, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Outgoing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 48);
            this.label4.TabIndex = 13;
            this.label4.Text = "When do you \r\nwant to go?";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmbxChildren);
            this.groupBox3.Controls.Add(this.cmbAdults);
            this.groupBox3.Location = new System.Drawing.Point(399, 410);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(611, 112);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(399, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Children";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(141, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Adults";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Who is going?";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cmbxTicketTypes);
            this.groupBox4.Location = new System.Drawing.Point(399, 544);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(611, 105);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(27, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 48);
            this.label10.TabIndex = 14;
            this.label10.Text = "Which kind of ticket\r\nwould you like?";
            // 
            // lblBookFlightBack
            // 
            this.lblBookFlightBack.AutoSize = true;
            this.lblBookFlightBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBookFlightBack.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookFlightBack.ForeColor = System.Drawing.Color.White;
            this.lblBookFlightBack.Location = new System.Drawing.Point(61, 693);
            this.lblBookFlightBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookFlightBack.Name = "lblBookFlightBack";
            this.lblBookFlightBack.Size = new System.Drawing.Size(150, 29);
            this.lblBookFlightBack.TabIndex = 32;
            this.lblBookFlightBack.Text = "Back (Ctrl F6)";
            this.lblBookFlightBack.Click += new System.EventHandler(this.lblBookFlightBack_Click);
            // 
            // lblConfirmFlight
            // 
            this.lblConfirmFlight.AutoSize = true;
            this.lblConfirmFlight.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmFlight.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmFlight.ForeColor = System.Drawing.Color.White;
            this.lblConfirmFlight.Location = new System.Drawing.Point(607, 693);
            this.lblConfirmFlight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmFlight.Name = "lblConfirmFlight";
            this.lblConfirmFlight.Size = new System.Drawing.Size(175, 29);
            this.lblConfirmFlight.TabIndex = 31;
            this.lblConfirmFlight.Text = "Select My Flight";
            this.lblConfirmFlight.Click += new System.EventHandler(this.lblConfirmFlight_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(1267, 693);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(52, 29);
            this.lblExit.TabIndex = 33;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // FindFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AirLineReservationSystem.Properties.Resources.cloud_creatures1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1387, 736);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblBookFlightBack);
            this.Controls.Add(this.lblConfirmFlight);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1405, 787);
            this.MinimumSize = new System.Drawing.Size(1405, 787);
            this.Name = "FindFlight";
            this.Text = "FindFlight";
            this.Load += new System.EventHandler(this.FindFlight_Load);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.FindFlight_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cmbxTicketTypes;
        private System.Windows.Forms.ComboBox cmbxChildren;
        private System.Windows.Forms.ComboBox cmbAdults;
        private System.Windows.Forms.ComboBox cmbTo;
        //private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.RadioButton rbOneWay;
        private System.Windows.Forms.RadioButton rdReturn;
        private System.Windows.Forms.Label lblBookFlightBack;
        private System.Windows.Forms.Label lblConfirmFlight;
        private System.Windows.Forms.Label lblExit;
    }
}