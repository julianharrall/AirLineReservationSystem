namespace AirLineReservationSystem
{
    partial class BookingTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingTab));
            this.Booking_FMF_Click = new System.Windows.Forms.Label();
            this.BookingB_Click = new System.Windows.Forms.Label();
            this.BookingE_Click = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBookingList = new System.Windows.Forms.Button();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbxResNum = new System.Windows.Forms.ComboBox();
            this.cmbxFlightNum = new System.Windows.Forms.ComboBox();
            this.cmbxCountry = new System.Windows.Forms.ComboBox();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxPassname = new System.Windows.Forms.TextBox();
            this.lblAirportMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbltxtAirportName = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblAirportName = new System.Windows.Forms.Label();
            this.lblAirportGate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Booking_FMF_Click
            // 
            this.Booking_FMF_Click.AutoSize = true;
            this.Booking_FMF_Click.BackColor = System.Drawing.Color.Transparent;
            this.Booking_FMF_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Booking_FMF_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.Booking_FMF_Click.Location = new System.Drawing.Point(600, 658);
            this.Booking_FMF_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Booking_FMF_Click.Name = "Booking_FMF_Click";
            this.Booking_FMF_Click.Size = new System.Drawing.Size(155, 29);
            this.Booking_FMF_Click.TabIndex = 50;
            this.Booking_FMF_Click.Text = "Find My Flight";
            this.Booking_FMF_Click.Click += new System.EventHandler(this.Booking_FMF_Click_Click);
            // 
            // BookingB_Click
            // 
            this.BookingB_Click.AutoSize = true;
            this.BookingB_Click.BackColor = System.Drawing.Color.Transparent;
            this.BookingB_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookingB_Click.ForeColor = System.Drawing.Color.Maroon;
            this.BookingB_Click.Location = new System.Drawing.Point(55, 658);
            this.BookingB_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BookingB_Click.Name = "BookingB_Click";
            this.BookingB_Click.Size = new System.Drawing.Size(58, 29);
            this.BookingB_Click.TabIndex = 51;
            this.BookingB_Click.Text = "Back";
            this.BookingB_Click.Click += new System.EventHandler(this.BookingB_Click_Click);
            // 
            // BookingE_Click
            // 
            this.BookingE_Click.AutoSize = true;
            this.BookingE_Click.BackColor = System.Drawing.Color.Transparent;
            this.BookingE_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookingE_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.BookingE_Click.Location = new System.Drawing.Point(1260, 658);
            this.BookingE_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BookingE_Click.Name = "BookingE_Click";
            this.BookingE_Click.Size = new System.Drawing.Size(52, 29);
            this.BookingE_Click.TabIndex = 52;
            this.BookingE_Click.Text = "Exit";
            this.BookingE_Click.Click += new System.EventHandler(this.BookingE_Click_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnBookingList);
            this.groupBox5.Controls.Add(this.dgvBookings);
            this.groupBox5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox5.Location = new System.Drawing.Point(457, 80);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(899, 565);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search/Delete Booking";
            // 
            // btnBookingList
            // 
            this.btnBookingList.Location = new System.Drawing.Point(25, 517);
            this.btnBookingList.Margin = new System.Windows.Forms.Padding(4);
            this.btnBookingList.Name = "btnBookingList";
            this.btnBookingList.Size = new System.Drawing.Size(80, 34);
            this.btnBookingList.TabIndex = 2;
            this.btnBookingList.Text = "List";
            this.btnBookingList.UseVisualStyleBackColor = true;
            this.btnBookingList.Click += new System.EventHandler(this.btnBookingList_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(25, 36);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.Size = new System.Drawing.Size(847, 474);
            this.dgvBookings.TabIndex = 0;
            this.dgvBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookings_CellContentClick);
            this.dgvBookings.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBookings_CellMouseDoubleClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnClear);
            this.groupBox6.Controls.Add(this.cmbxResNum);
            this.groupBox6.Controls.Add(this.cmbxFlightNum);
            this.groupBox6.Controls.Add(this.cmbxCountry);
            this.groupBox6.Controls.Add(this.lblDepartureDate);
            this.groupBox6.Controls.Add(this.btnSearch);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.txbxPassname);
            this.groupBox6.Controls.Add(this.lblAirportMessage);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.lbltxtAirportName);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.lblAirportName);
            this.groupBox6.Controls.Add(this.lblAirportGate);
            this.groupBox6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox6.Location = new System.Drawing.Point(16, 80);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(410, 565);
            this.groupBox6.TabIndex = 56;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search Booking (* WildCard)";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(288, 499);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 57);
            this.btnClear.TabIndex = 55;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbxResNum
            // 
            this.cmbxResNum.FormattingEnabled = true;
            this.cmbxResNum.Location = new System.Drawing.Point(51, 77);
            this.cmbxResNum.Name = "cmbxResNum";
            this.cmbxResNum.Size = new System.Drawing.Size(211, 36);
            this.cmbxResNum.TabIndex = 54;
            this.cmbxResNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbxResNum_KeyPress);
            // 
            // cmbxFlightNum
            // 
            this.cmbxFlightNum.FormattingEnabled = true;
            this.cmbxFlightNum.Location = new System.Drawing.Point(50, 161);
            this.cmbxFlightNum.Name = "cmbxFlightNum";
            this.cmbxFlightNum.Size = new System.Drawing.Size(212, 36);
            this.cmbxFlightNum.TabIndex = 53;
            this.cmbxFlightNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbxFlightNum_KeyPress);
            // 
            // cmbxCountry
            // 
            this.cmbxCountry.FormattingEnabled = true;
            this.cmbxCountry.Location = new System.Drawing.Point(50, 355);
            this.cmbxCountry.Name = "cmbxCountry";
            this.cmbxCountry.Size = new System.Drawing.Size(212, 36);
            this.cmbxCountry.TabIndex = 52;
            this.cmbxCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbxCountry_KeyPress);
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDepartureDate.Location = new System.Drawing.Point(45, 420);
            this.lblDepartureDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(156, 28);
            this.lblDepartureDate.TabIndex = 47;
            this.lblDepartureDate.Text = "Departure Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(288, 428);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 58);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 323);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 28);
            this.label4.TabIndex = 44;
            this.label4.Text = "Country";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 223);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 28);
            this.label2.TabIndex = 42;
            this.label2.Text = "Passenger Name";
            // 
            // txbxPassname
            // 
            this.txbxPassname.Location = new System.Drawing.Point(50, 255);
            this.txbxPassname.Margin = new System.Windows.Forms.Padding(4);
            this.txbxPassname.Name = "txbxPassname";
            this.txbxPassname.Size = new System.Drawing.Size(212, 35);
            this.txbxPassname.TabIndex = 41;
            this.txbxPassname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbxPassname_KeyPress);
            // 
            // lblAirportMessage
            // 
            this.lblAirportMessage.AutoSize = true;
            this.lblAirportMessage.Location = new System.Drawing.Point(216, 428);
            this.lblAirportMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportMessage.Name = "lblAirportMessage";
            this.lblAirportMessage.Size = new System.Drawing.Size(0, 28);
            this.lblAirportMessage.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 420);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 28);
            this.label1.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(183, 394);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 28);
            this.label13.TabIndex = 38;
            // 
            // lbltxtAirportName
            // 
            this.lbltxtAirportName.AutoSize = true;
            this.lbltxtAirportName.Location = new System.Drawing.Point(301, 95);
            this.lbltxtAirportName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltxtAirportName.Name = "lbltxtAirportName";
            this.lbltxtAirportName.Size = new System.Drawing.Size(0, 28);
            this.lbltxtAirportName.TabIndex = 36;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(170, 421);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 28);
            this.label23.TabIndex = 35;
            // 
            // lblAirportName
            // 
            this.lblAirportName.AutoSize = true;
            this.lblAirportName.Location = new System.Drawing.Point(46, 45);
            this.lblAirportName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportName.Name = "lblAirportName";
            this.lblAirportName.Size = new System.Drawing.Size(202, 28);
            this.lblAirportName.TabIndex = 30;
            this.lblAirportName.Text = "Reservation Number";
            this.lblAirportName.Click += new System.EventHandler(this.lblAirportName_Click);
            // 
            // lblAirportGate
            // 
            this.lblAirportGate.AutoSize = true;
            this.lblAirportGate.Location = new System.Drawing.Point(46, 129);
            this.lblAirportGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportGate.Name = "lblAirportGate";
            this.lblAirportGate.Size = new System.Drawing.Size(146, 28);
            this.lblAirportGate.TabIndex = 29;
            this.lblAirportGate.Text = "Flight Number";
            // 
            // BookingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 751);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BookingE_Click);
            this.Controls.Add(this.BookingB_Click);
            this.Controls.Add(this.Booking_FMF_Click);
            this.Name = "BookingTab";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BookingTab_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Booking_FMF_Click;
        private System.Windows.Forms.Label BookingB_Click;
        private System.Windows.Forms.Label BookingE_Click;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBookingList;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblAirportMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbltxtAirportName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblAirportName;
        private System.Windows.Forms.Label lblAirportGate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxPassname;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.ComboBox cmbxCountry;
        private System.Windows.Forms.ComboBox cmbxFlightNum;
        private System.Windows.Forms.ComboBox cmbxResNum;
        private System.Windows.Forms.Button btnClear;
    }
}