namespace AirLineReservationSystem
{
    partial class AircraftTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AircraftTab));
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnArcftList = new System.Windows.Forms.Button();
            this.dgvAircraftList = new System.Windows.Forms.DataGridView();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblAircraftMessage = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblAircraft = new System.Windows.Forms.Label();
            this.picBxThumb = new System.Windows.Forms.PictureBox();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAddAircraft = new System.Windows.Forms.Button();
            this.txtSeat = new System.Windows.Forms.TextBox();
            this.txtAircraft = new System.Windows.Forms.TextBox();
            this.AircraftE_Click = new System.Windows.Forms.Label();
            this.AircraftFMF_Click = new System.Windows.Forms.Label();
            this.AircraftB_Click = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircraftList)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnArcftList);
            this.groupBox8.Controls.Add(this.dgvAircraftList);
            this.groupBox8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox8.Location = new System.Drawing.Point(648, 73);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(701, 571);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Search/Modify Aircraft";
            // 
            // btnArcftList
            // 
            this.btnArcftList.Location = new System.Drawing.Point(21, 523);
            this.btnArcftList.Margin = new System.Windows.Forms.Padding(4);
            this.btnArcftList.Name = "btnArcftList";
            this.btnArcftList.Size = new System.Drawing.Size(80, 34);
            this.btnArcftList.TabIndex = 1;
            this.btnArcftList.Text = "List";
            this.btnArcftList.UseVisualStyleBackColor = true;
            this.btnArcftList.Click += new System.EventHandler(this.btnArcftList_Click);
            // 
            // dgvAircraftList
            // 
            this.dgvAircraftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAircraftList.Location = new System.Drawing.Point(21, 36);
            this.dgvAircraftList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAircraftList.Name = "dgvAircraftList";
            this.dgvAircraftList.RowHeadersWidth = 51;
            this.dgvAircraftList.Size = new System.Drawing.Size(656, 480);
            this.dgvAircraftList.TabIndex = 0;
            this.dgvAircraftList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAircraftList_CellClick);
            this.dgvAircraftList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAircraftList_CellEnter);
            this.dgvAircraftList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAircraftList_CellMouseDoubleClick);
            this.dgvAircraftList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAircraftList_DataBindingComplete);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblAircraftMessage);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Controls.Add(this.lblImage);
            this.groupBox9.Controls.Add(this.lblSeat);
            this.groupBox9.Controls.Add(this.lblAircraft);
            this.groupBox9.Controls.Add(this.picBxThumb);
            this.groupBox9.Controls.Add(this.btnImageBrowse);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.btnAddAircraft);
            this.groupBox9.Controls.Add(this.txtSeat);
            this.groupBox9.Controls.Add(this.txtAircraft);
            this.groupBox9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox9.Location = new System.Drawing.Point(16, 73);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(597, 571);
            this.groupBox9.TabIndex = 53;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Add Aircraft";
            // 
            // lblAircraftMessage
            // 
            this.lblAircraftMessage.AutoSize = true;
            this.lblAircraftMessage.Location = new System.Drawing.Point(205, 466);
            this.lblAircraftMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAircraftMessage.Name = "lblAircraftMessage";
            this.lblAircraftMessage.Size = new System.Drawing.Size(0, 28);
            this.lblAircraftMessage.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(172, 492);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 28);
            this.label23.TabIndex = 24;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(360, 367);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(0, 28);
            this.lblImage.TabIndex = 23;
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Location = new System.Drawing.Point(361, 198);
            this.lblSeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(0, 28);
            this.lblSeat.TabIndex = 22;
            // 
            // lblAircraft
            // 
            this.lblAircraft.AutoSize = true;
            this.lblAircraft.Location = new System.Drawing.Point(361, 101);
            this.lblAircraft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(0, 28);
            this.lblAircraft.TabIndex = 21;
            // 
            // picBxThumb
            // 
            this.picBxThumb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBxThumb.Location = new System.Drawing.Point(51, 318);
            this.picBxThumb.Margin = new System.Windows.Forms.Padding(4);
            this.picBxThumb.Name = "picBxThumb";
            this.picBxThumb.Size = new System.Drawing.Size(132, 127);
            this.picBxThumb.TabIndex = 20;
            this.picBxThumb.TabStop = false;
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Location = new System.Drawing.Point(53, 274);
            this.btnImageBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(132, 36);
            this.btnImageBrowse.TabIndex = 19;
            this.btnImageBrowse.Text = "Browse";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 466);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 28);
            this.label13.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 242);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 28);
            this.label14.TabIndex = 17;
            this.label14.Text = "Image";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(47, 149);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 28);
            this.label15.TabIndex = 16;
            this.label15.Text = "Seat Capacity";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(47, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 28);
            this.label16.TabIndex = 15;
            this.label16.Text = "Aircraft Type";
            // 
            // btnAddAircraft
            // 
            this.btnAddAircraft.Location = new System.Drawing.Point(51, 485);
            this.btnAddAircraft.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAircraft.Name = "btnAddAircraft";
            this.btnAddAircraft.Size = new System.Drawing.Size(100, 36);
            this.btnAddAircraft.TabIndex = 14;
            this.btnAddAircraft.Text = "ADD";
            this.btnAddAircraft.UseVisualStyleBackColor = true;
            this.btnAddAircraft.Click += new System.EventHandler(this.btnAddAircraft_Click);
            // 
            // txtSeat
            // 
            this.txtSeat.Location = new System.Drawing.Point(52, 181);
            this.txtSeat.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(132, 35);
            this.txtSeat.TabIndex = 13;
            // 
            // txtAircraft
            // 
            this.txtAircraft.Location = new System.Drawing.Point(52, 92);
            this.txtAircraft.Margin = new System.Windows.Forms.Padding(4);
            this.txtAircraft.Name = "txtAircraft";
            this.txtAircraft.Size = new System.Drawing.Size(132, 35);
            this.txtAircraft.TabIndex = 11;
            // 
            // AircraftE_Click
            // 
            this.AircraftE_Click.AutoSize = true;
            this.AircraftE_Click.BackColor = System.Drawing.Color.Transparent;
            this.AircraftE_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AircraftE_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.AircraftE_Click.Location = new System.Drawing.Point(1267, 661);
            this.AircraftE_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AircraftE_Click.Name = "AircraftE_Click";
            this.AircraftE_Click.Size = new System.Drawing.Size(52, 29);
            this.AircraftE_Click.TabIndex = 51;
            this.AircraftE_Click.Text = "Exit";
            this.AircraftE_Click.Click += new System.EventHandler(this.AircraftE_Click_Click);
            // 
            // AircraftFMF_Click
            // 
            this.AircraftFMF_Click.AutoSize = true;
            this.AircraftFMF_Click.BackColor = System.Drawing.Color.Transparent;
            this.AircraftFMF_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AircraftFMF_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.AircraftFMF_Click.Location = new System.Drawing.Point(607, 661);
            this.AircraftFMF_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AircraftFMF_Click.Name = "AircraftFMF_Click";
            this.AircraftFMF_Click.Size = new System.Drawing.Size(155, 29);
            this.AircraftFMF_Click.TabIndex = 49;
            this.AircraftFMF_Click.Tag = "FMF_Tag";
            this.AircraftFMF_Click.Text = "Find My Flight";
            this.AircraftFMF_Click.Click += new System.EventHandler(this.AircraftFMF_Click_Click_1);
            // 
            // AircraftB_Click
            // 
            this.AircraftB_Click.AutoSize = true;
            this.AircraftB_Click.BackColor = System.Drawing.Color.Transparent;
            this.AircraftB_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AircraftB_Click.ForeColor = System.Drawing.Color.Maroon;
            this.AircraftB_Click.Location = new System.Drawing.Point(61, 661);
            this.AircraftB_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AircraftB_Click.Name = "AircraftB_Click";
            this.AircraftB_Click.Size = new System.Drawing.Size(58, 29);
            this.AircraftB_Click.TabIndex = 50;
            this.AircraftB_Click.Text = "Back";
            this.AircraftB_Click.Click += new System.EventHandler(this.AircraftB_Click_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(277, 62);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 52;
            this.pictureBox3.TabStop = false;
            // 
            // AircraftTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 751);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.AircraftE_Click);
            this.Controls.Add(this.AircraftFMF_Click);
            this.Controls.Add(this.AircraftB_Click);
            this.Controls.Add(this.pictureBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AircraftTab";
            //this.Activated += new System.EventHandler(this.AircraftTab_Activated);
            //this.Load += new System.EventHandler(this.AircraftTab_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AircraftTab_Paint);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircraftList)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnArcftList;
        private System.Windows.Forms.DataGridView dgvAircraftList;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblAircraft;
        private System.Windows.Forms.PictureBox picBxThumb;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAddAircraft;
        private System.Windows.Forms.TextBox txtSeat;
        private System.Windows.Forms.TextBox txtAircraft;
        private System.Windows.Forms.Label AircraftE_Click;
        private System.Windows.Forms.Label AircraftFMF_Click;
        private System.Windows.Forms.Label AircraftB_Click;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblAircraftMessage;
        private System.Windows.Forms.Label label23;
    }
}