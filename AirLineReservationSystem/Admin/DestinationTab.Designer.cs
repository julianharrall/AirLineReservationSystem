namespace AirLineReservationSystem
{
    partial class DestinationTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DestinationTab));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dgvSMDestination = new System.Windows.Forms.DataGridView();
            this.btnSearchDest = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.picDestThumb = new System.Windows.Forms.PictureBox();
            this.btnDestImageBrowse = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDestMessage = new System.Windows.Forms.Label();
            this.lblGate = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblAirport = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddDestination = new System.Windows.Forms.Button();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtGate = new System.Windows.Forms.TextBox();
            this.txtAirport = new System.Windows.Forms.TextBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblConfirmFlight = new System.Windows.Forms.Label();
            this.lblBookFlightBack = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMDestination)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDestThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dgvSMDestination);
            this.groupBox10.Controls.Add(this.btnSearchDest);
            this.groupBox10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox10.Location = new System.Drawing.Point(654, 84);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(698, 565);
            this.groupBox10.TabIndex = 54;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Search/Modify Destination";
            // 
            // dgvSMDestination
            // 
            this.dgvSMDestination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSMDestination.Location = new System.Drawing.Point(29, 36);
            this.dgvSMDestination.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSMDestination.Name = "dgvSMDestination";
            this.dgvSMDestination.RowHeadersWidth = 51;
            this.dgvSMDestination.Size = new System.Drawing.Size(648, 464);
            this.dgvSMDestination.TabIndex = 14;
            this.dgvSMDestination.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSMDestination_CellClick);
            this.dgvSMDestination.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSMDestination_CellDoubleClick);
            this.dgvSMDestination.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSMDestination_CellMouseDoubleClick);
            this.dgvSMDestination.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSMDestination_DataBindingComplete);
            // 
            // btnSearchDest
            // 
            this.btnSearchDest.Location = new System.Drawing.Point(29, 507);
            this.btnSearchDest.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchDest.Name = "btnSearchDest";
            this.btnSearchDest.Size = new System.Drawing.Size(88, 36);
            this.btnSearchDest.TabIndex = 13;
            this.btnSearchDest.Text = "List";
            this.btnSearchDest.UseVisualStyleBackColor = true;
            this.btnSearchDest.Click += new System.EventHandler(this.btnSearchDest_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lblImage);
            this.groupBox11.Controls.Add(this.picDestThumb);
            this.groupBox11.Controls.Add(this.btnDestImageBrowse);
            this.groupBox11.Controls.Add(this.label14);
            this.groupBox11.Controls.Add(this.lblDestMessage);
            this.groupBox11.Controls.Add(this.lblGate);
            this.groupBox11.Controls.Add(this.lblCountry);
            this.groupBox11.Controls.Add(this.lblAirport);
            this.groupBox11.Controls.Add(this.label9);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Controls.Add(this.label7);
            this.groupBox11.Controls.Add(this.btnAddDestination);
            this.groupBox11.Controls.Add(this.txtCountry);
            this.groupBox11.Controls.Add(this.txtGate);
            this.groupBox11.Controls.Add(this.txtAirport);
            this.groupBox11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox11.Location = new System.Drawing.Point(15, 84);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(616, 565);
            this.groupBox11.TabIndex = 53;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Add Destination";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(544, 293);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(0, 28);
            this.lblImage.TabIndex = 24;
            // 
            // picDestThumb
            // 
            this.picDestThumb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDestThumb.Location = new System.Drawing.Point(328, 251);
            this.picDestThumb.Margin = new System.Windows.Forms.Padding(4);
            this.picDestThumb.Name = "picDestThumb";
            this.picDestThumb.Size = new System.Drawing.Size(132, 127);
            this.picDestThumb.TabIndex = 23;
            this.picDestThumb.TabStop = false;
            // 
            // btnDestImageBrowse
            // 
            this.btnDestImageBrowse.Location = new System.Drawing.Point(330, 207);
            this.btnDestImageBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnDestImageBrowse.Name = "btnDestImageBrowse";
            this.btnDestImageBrowse.Size = new System.Drawing.Size(132, 36);
            this.btnDestImageBrowse.TabIndex = 22;
            this.btnDestImageBrowse.Text = "Browse";
            this.btnDestImageBrowse.UseVisualStyleBackColor = true;
            this.btnDestImageBrowse.Click += new System.EventHandler(this.btnDestImageBrowse_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(324, 175);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 28);
            this.label14.TabIndex = 21;
            this.label14.Text = "Image";
            // 
            // lblDestMessage
            // 
            this.lblDestMessage.AutoSize = true;
            this.lblDestMessage.Location = new System.Drawing.Point(171, 485);
            this.lblDestMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestMessage.Name = "lblDestMessage";
            this.lblDestMessage.Size = new System.Drawing.Size(0, 28);
            this.lblDestMessage.TabIndex = 10;
            // 
            // lblGate
            // 
            this.lblGate.AutoSize = true;
            this.lblGate.Location = new System.Drawing.Point(260, 363);
            this.lblGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGate.Name = "lblGate";
            this.lblGate.Size = new System.Drawing.Size(0, 28);
            this.lblGate.TabIndex = 9;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(261, 207);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(0, 28);
            this.lblCountry.TabIndex = 8;
            // 
            // lblAirport
            // 
            this.lblAirport.AutoSize = true;
            this.lblAirport.Location = new System.Drawing.Point(261, 92);
            this.lblAirport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirport.Name = "lblAirport";
            this.lblAirport.Size = new System.Drawing.Size(0, 28);
            this.lblAirport.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 322);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 28);
            this.label9.TabIndex = 6;
            this.label9.Text = "Gate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "Country";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 28);
            this.label7.TabIndex = 4;
            this.label7.Text = "Airport";
            // 
            // btnAddDestination
            // 
            this.btnAddDestination.Location = new System.Drawing.Point(52, 507);
            this.btnAddDestination.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDestination.Name = "btnAddDestination";
            this.btnAddDestination.Size = new System.Drawing.Size(100, 36);
            this.btnAddDestination.TabIndex = 3;
            this.btnAddDestination.Text = "ADD";
            this.btnAddDestination.UseVisualStyleBackColor = true;
            this.btnAddDestination.Click += new System.EventHandler(this.btnAddDestination_Click);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(51, 207);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(132, 35);
            this.txtCountry.TabIndex = 2;
            //this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            // 
            // txtGate
            // 
            this.txtGate.Location = new System.Drawing.Point(51, 354);
            this.txtGate.Margin = new System.Windows.Forms.Padding(4);
            this.txtGate.Name = "txtGate";
            this.txtGate.Size = new System.Drawing.Size(132, 35);
            this.txtGate.TabIndex = 1;
            // 
            // txtAirport
            // 
            this.txtAirport.Location = new System.Drawing.Point(52, 84);
            this.txtAirport.Margin = new System.Windows.Forms.Padding(4);
            this.txtAirport.Name = "txtAirport";
            this.txtAirport.Size = new System.Drawing.Size(132, 35);
            this.txtAirport.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExit.Location = new System.Drawing.Point(1265, 667);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(52, 29);
            this.lblExit.TabIndex = 51;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblConfirmFlight
            // 
            this.lblConfirmFlight.AutoSize = true;
            this.lblConfirmFlight.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmFlight.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmFlight.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConfirmFlight.Location = new System.Drawing.Point(605, 667);
            this.lblConfirmFlight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmFlight.Name = "lblConfirmFlight";
            this.lblConfirmFlight.Size = new System.Drawing.Size(155, 29);
            this.lblConfirmFlight.TabIndex = 49;
            this.lblConfirmFlight.Text = "Find My Flight";
            this.lblConfirmFlight.Click += new System.EventHandler(this.lblConfirmFlight_Click);
            // 
            // lblBookFlightBack
            // 
            this.lblBookFlightBack.AutoSize = true;
            this.lblBookFlightBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBookFlightBack.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookFlightBack.ForeColor = System.Drawing.Color.Maroon;
            this.lblBookFlightBack.Location = new System.Drawing.Point(60, 667);
            this.lblBookFlightBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookFlightBack.Name = "lblBookFlightBack";
            this.lblBookFlightBack.Size = new System.Drawing.Size(58, 29);
            this.lblBookFlightBack.TabIndex = 50;
            this.lblBookFlightBack.Text = "Back";
            this.lblBookFlightBack.Click += new System.EventHandler(this.lblBookFlightBack_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(15, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(277, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            // 
            // DestinationTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 722);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblConfirmFlight);
            this.Controls.Add(this.lblBookFlightBack);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DestinationTab";
            this.ShowIcon = false;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DestinationTab_Paint);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMDestination)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDestThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dgvSMDestination;
        private System.Windows.Forms.Button btnSearchDest;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblDestMessage;
        private System.Windows.Forms.Label lblGate;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblAirport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddDestination;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtGate;
        private System.Windows.Forms.TextBox txtAirport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblConfirmFlight;
        private System.Windows.Forms.Label lblBookFlightBack;
        private System.Windows.Forms.PictureBox picDestThumb;
        private System.Windows.Forms.Button btnDestImageBrowse;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblImage;
    }
}