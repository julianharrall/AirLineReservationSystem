namespace AirLineReservationSystem
{
    partial class FlightTabTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightTabTest));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchFlights = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbReseed = new System.Windows.Forms.CheckBox();
            this.btnAddtestFlights = new System.Windows.Forms.Button();
            this.txtBusiness = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtEconomy = new System.Windows.Forms.TextBox();
            this.lblFirstPrice = new System.Windows.Forms.Label();
            this.lblEconomy = new System.Windows.Forms.Label();
            this.lblBusinessPrice = new System.Windows.Forms.Label();
            this.lblOut = new System.Windows.Forms.Label();
            this.lblIn = new System.Windows.Forms.Label();
            this.tbxFlightNo = new System.Windows.Forms.TextBox();
            this.lblFlightNum = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cmbAircraft = new System.Windows.Forms.ComboBox();
            this.lblAircraft = new System.Windows.Forms.Label();
            this.cmbAirport = new System.Windows.Forms.ComboBox();
            this.lblDestMessage = new System.Windows.Forms.Label();
            this.lblAirport = new System.Windows.Forms.Label();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.FlightE_Click = new System.Windows.Forms.Label();
            this.FlightFMF_Click = new System.Windows.Forms.Label();
            this.FlightB_Click = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchFlights);
            this.groupBox2.Controls.Add(this.dgvFlights);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(600, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(761, 565);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search/Modify Flight";
            // 
            // btnSearchFlights
            // 
            this.btnSearchFlights.Location = new System.Drawing.Point(31, 522);
            this.btnSearchFlights.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchFlights.Name = "btnSearchFlights";
            this.btnSearchFlights.Size = new System.Drawing.Size(83, 36);
            this.btnSearchFlights.TabIndex = 20;
            this.btnSearchFlights.Text = "List";
            this.btnSearchFlights.UseVisualStyleBackColor = true;
            this.btnSearchFlights.Click += new System.EventHandler(this.btnSearchFlights_Click);
            // 
            // dgvFlights
            // 
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Location = new System.Drawing.Point(31, 36);
            this.dgvFlights.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.RowHeadersWidth = 51;
            this.dgvFlights.Size = new System.Drawing.Size(712, 479);
            this.dgvFlights.TabIndex = 0;
            this.dgvFlights.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlights_CellClick);
            this.dgvFlights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlights_CellContentClick);
            this.dgvFlights.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlights_CellDoubleClick);
            this.dgvFlights.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlights_CellFormatting);
            this.dgvFlights.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFlights_CellMouseDoubleClick);
            this.dgvFlights.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFlights_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbReseed);
            this.groupBox4.Controls.Add(this.btnAddtestFlights);
            this.groupBox4.Controls.Add(this.txtBusiness);
            this.groupBox4.Controls.Add(this.txtFirst);
            this.groupBox4.Controls.Add(this.txtEconomy);
            this.groupBox4.Controls.Add(this.lblFirstPrice);
            this.groupBox4.Controls.Add(this.lblEconomy);
            this.groupBox4.Controls.Add(this.lblBusinessPrice);
            this.groupBox4.Controls.Add(this.lblOut);
            this.groupBox4.Controls.Add(this.lblIn);
            this.groupBox4.Controls.Add(this.tbxFlightNo);
            this.groupBox4.Controls.Add(this.lblFlightNum);
            this.groupBox4.Controls.Add(this.cmbDestination);
            this.groupBox4.Controls.Add(this.lblDestination);
            this.groupBox4.Controls.Add(this.cmbAircraft);
            this.groupBox4.Controls.Add(this.lblAircraft);
            this.groupBox4.Controls.Add(this.cmbAirport);
            this.groupBox4.Controls.Add(this.lblDestMessage);
            this.groupBox4.Controls.Add(this.lblAirport);
            this.groupBox4.Controls.Add(this.btnAddFlight);
            this.groupBox4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(4, 76);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(580, 565);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add Flight";
            // 
            // cbReseed
            // 
            this.cbReseed.AutoSize = true;
            this.cbReseed.Location = new System.Drawing.Point(330, 512);
            this.cbReseed.Name = "cbReseed";
            this.cbReseed.Size = new System.Drawing.Size(102, 32);
            this.cbReseed.TabIndex = 43;
            this.cbReseed.Text = "Reseed";
            this.cbReseed.UseVisualStyleBackColor = true;
            this.cbReseed.CheckedChanged += new System.EventHandler(this.cbReseed_CheckedChanged);
            // 
            // btnAddtestFlights
            // 
            this.btnAddtestFlights.Location = new System.Drawing.Point(330, 460);
            this.btnAddtestFlights.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddtestFlights.Name = "btnAddtestFlights";
            this.btnAddtestFlights.Size = new System.Drawing.Size(219, 37);
            this.btnAddtestFlights.TabIndex = 42;
            this.btnAddtestFlights.Text = "ADD TEST FLIGHTS";
            this.btnAddtestFlights.UseVisualStyleBackColor = true;
            this.btnAddtestFlights.Click += new System.EventHandler(this.btnAddtestFlights_Click);
            // 
            // txtBusiness
            // 
            this.txtBusiness.Location = new System.Drawing.Point(367, 153);
            this.txtBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusiness.Name = "txtBusiness";
            this.txtBusiness.Size = new System.Drawing.Size(161, 35);
            this.txtBusiness.TabIndex = 41;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(367, 239);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(161, 35);
            this.txtFirst.TabIndex = 40;
            // 
            // txtEconomy
            // 
            this.txtEconomy.Location = new System.Drawing.Point(367, 327);
            this.txtEconomy.Margin = new System.Windows.Forms.Padding(4);
            this.txtEconomy.Name = "txtEconomy";
            this.txtEconomy.Size = new System.Drawing.Size(161, 35);
            this.txtEconomy.TabIndex = 39;
            // 
            // lblFirstPrice
            // 
            this.lblFirstPrice.AutoSize = true;
            this.lblFirstPrice.Location = new System.Drawing.Point(363, 207);
            this.lblFirstPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstPrice.Name = "lblFirstPrice";
            this.lblFirstPrice.Size = new System.Drawing.Size(111, 28);
            this.lblFirstPrice.TabIndex = 38;
            this.lblFirstPrice.Text = "First Price";
            // 
            // lblEconomy
            // 
            this.lblEconomy.AutoSize = true;
            this.lblEconomy.Location = new System.Drawing.Point(363, 295);
            this.lblEconomy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEconomy.Name = "lblEconomy";
            this.lblEconomy.Size = new System.Drawing.Size(144, 28);
            this.lblEconomy.TabIndex = 37;
            this.lblEconomy.Text = "Economy Price";
            // 
            // lblBusinessPrice
            // 
            this.lblBusinessPrice.AutoSize = true;
            this.lblBusinessPrice.Location = new System.Drawing.Point(363, 121);
            this.lblBusinessPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPrice.Name = "lblBusinessPrice";
            this.lblBusinessPrice.Size = new System.Drawing.Size(145, 28);
            this.lblBusinessPrice.TabIndex = 36;
            this.lblBusinessPrice.Text = "Business Price";
            // 
            // lblOut
            // 
            this.lblOut.AutoSize = true;
            this.lblOut.Location = new System.Drawing.Point(44, 295);
            this.lblOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(107, 28);
            this.lblOut.TabIndex = 27;
            this.lblOut.Text = "Departure";
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Location = new System.Drawing.Point(51, 386);
            this.lblIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(77, 28);
            this.lblIn.TabIndex = 26;
            this.lblIn.Text = "Arrival";
            // 
            // tbxFlightNo
            // 
            this.tbxFlightNo.Location = new System.Drawing.Point(51, 68);
            this.tbxFlightNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFlightNo.Name = "tbxFlightNo";
            this.tbxFlightNo.Size = new System.Drawing.Size(161, 35);
            this.tbxFlightNo.TabIndex = 25;
            // 
            // lblFlightNum
            // 
            this.lblFlightNum.AutoSize = true;
            this.lblFlightNum.Location = new System.Drawing.Point(45, 36);
            this.lblFlightNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlightNum.Name = "lblFlightNum";
            this.lblFlightNum.Size = new System.Drawing.Size(146, 28);
            this.lblFlightNum.TabIndex = 24;
            this.lblFlightNum.Text = "Flight Number";
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(51, 239);
            this.cmbDestination.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(160, 36);
            this.cmbDestination.TabIndex = 23;
            this.cmbDestination.Click += new System.EventHandler(this.cmbDestination_Click);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(45, 207);
            this.lblDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(116, 28);
            this.lblDestination.TabIndex = 22;
            this.lblDestination.Text = "Destination";
            // 
            // cmbAircraft
            // 
            this.cmbAircraft.FormattingEnabled = true;
            this.cmbAircraft.Location = new System.Drawing.Point(368, 68);
            this.cmbAircraft.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAircraft.Name = "cmbAircraft";
            this.cmbAircraft.Size = new System.Drawing.Size(160, 36);
            this.cmbAircraft.TabIndex = 21;
            this.cmbAircraft.Click += new System.EventHandler(this.cmbAircraft_Click);
            // 
            // lblAircraft
            // 
            this.lblAircraft.AutoSize = true;
            this.lblAircraft.Location = new System.Drawing.Point(363, 36);
            this.lblAircraft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(90, 28);
            this.lblAircraft.TabIndex = 20;
            this.lblAircraft.Text = "Aircraft";
            // 
            // cmbAirport
            // 
            this.cmbAirport.FormattingEnabled = true;
            this.cmbAirport.Location = new System.Drawing.Point(51, 153);
            this.cmbAirport.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAirport.Name = "cmbAirport";
            this.cmbAirport.Size = new System.Drawing.Size(160, 36);
            this.cmbAirport.TabIndex = 19;
            this.cmbAirport.Click += new System.EventHandler(this.cmbAirpot_Click);
            // 
            // lblDestMessage
            // 
            this.lblDestMessage.AutoSize = true;
            this.lblDestMessage.Location = new System.Drawing.Point(169, 469);
            this.lblDestMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestMessage.Name = "lblDestMessage";
            this.lblDestMessage.Size = new System.Drawing.Size(0, 28);
            this.lblDestMessage.TabIndex = 18;
            // 
            // lblAirport
            // 
            this.lblAirport.AutoSize = true;
            this.lblAirport.Location = new System.Drawing.Point(45, 121);
            this.lblAirport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirport.Name = "lblAirport";
            this.lblAirport.Size = new System.Drawing.Size(82, 28);
            this.lblAirport.TabIndex = 15;
            this.lblAirport.Text = "Airport";
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Location = new System.Drawing.Point(49, 489);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(100, 36);
            this.btnAddFlight.TabIndex = 14;
            this.btnAddFlight.Text = "ADD";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // FlightE_Click
            // 
            this.FlightE_Click.AutoSize = true;
            this.FlightE_Click.BackColor = System.Drawing.Color.Transparent;
            this.FlightE_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlightE_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.FlightE_Click.Location = new System.Drawing.Point(1255, 660);
            this.FlightE_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FlightE_Click.Name = "FlightE_Click";
            this.FlightE_Click.Size = new System.Drawing.Size(52, 29);
            this.FlightE_Click.TabIndex = 51;
            this.FlightE_Click.Text = "Exit";
            this.FlightE_Click.Click += new System.EventHandler(this.FlightE_Click_Click);
            // 
            // FlightFMF_Click
            // 
            this.FlightFMF_Click.AutoSize = true;
            this.FlightFMF_Click.BackColor = System.Drawing.Color.Transparent;
            this.FlightFMF_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlightFMF_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.FlightFMF_Click.Location = new System.Drawing.Point(595, 660);
            this.FlightFMF_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FlightFMF_Click.Name = "FlightFMF_Click";
            this.FlightFMF_Click.Size = new System.Drawing.Size(155, 29);
            this.FlightFMF_Click.TabIndex = 49;
            this.FlightFMF_Click.Text = "Find My Flight";
            this.FlightFMF_Click.Click += new System.EventHandler(this.FlightFMF_Click_Click);
            // 
            // FlightB_Click
            // 
            this.FlightB_Click.AutoSize = true;
            this.FlightB_Click.BackColor = System.Drawing.Color.Transparent;
            this.FlightB_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlightB_Click.ForeColor = System.Drawing.Color.Maroon;
            this.FlightB_Click.Location = new System.Drawing.Point(49, 660);
            this.FlightB_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FlightB_Click.Name = "FlightB_Click";
            this.FlightB_Click.Size = new System.Drawing.Size(58, 29);
            this.FlightB_Click.TabIndex = 50;
            this.FlightB_Click.Text = "Back";
            this.FlightB_Click.Click += new System.EventHandler(this.FlightB_Click_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(16, 15);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(277, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            // 
            // FlightTabTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 751);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.FlightE_Click);
            this.Controls.Add(this.FlightFMF_Click);
            this.Controls.Add(this.FlightB_Click);
            this.Controls.Add(this.pictureBox5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightTabTest";
            this.Text = "FightTab";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlightTabTest_Paint);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label FlightE_Click;
        private System.Windows.Forms.Label FlightFMF_Click;
        private System.Windows.Forms.Label FlightB_Click;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Label lblDestMessage;
        private System.Windows.Forms.Label lblAirport;
        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Button btnSearchFlights;
        private System.Windows.Forms.Label lblFlightNum;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ComboBox cmbAircraft;
        private System.Windows.Forms.Label lblAircraft;
        private System.Windows.Forms.ComboBox cmbAirport;
        private System.Windows.Forms.TextBox tbxFlightNo;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.Label lblBusinessPrice;
        private System.Windows.Forms.TextBox txtBusiness;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtEconomy;
        private System.Windows.Forms.Label lblFirstPrice;
        private System.Windows.Forms.Label lblEconomy;
        private System.Windows.Forms.Button btnAddtestFlights;
        private System.Windows.Forms.CheckBox cbReseed;
    }
}