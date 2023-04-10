namespace AirLineReservationSystem
{
    partial class AirportTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirportTab));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnArprtList = new System.Windows.Forms.Button();
            this.dgvAirports = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblAirportMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbltxtAirportGate = new System.Windows.Forms.Label();
            this.lbltxtAirportName = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblAirportName = new System.Windows.Forms.Label();
            this.lblAirportGate = new System.Windows.Forms.Label();
            this.btnAddAirport = new System.Windows.Forms.Button();
            this.txtAirportName = new System.Windows.Forms.TextBox();
            this.txtAirportGate = new System.Windows.Forms.TextBox();
            this.AirportE_Click = new System.Windows.Forms.Label();
            this.AirportFMF_Click = new System.Windows.Forms.Label();
            this.AirportB_Click = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirports)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnArprtList);
            this.groupBox5.Controls.Add(this.dgvAirports);
            this.groupBox5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox5.Location = new System.Drawing.Point(633, 73);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(718, 565);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search/Modify Airport";
            // 
            // btnArprtList
            // 
            this.btnArprtList.Location = new System.Drawing.Point(25, 517);
            this.btnArprtList.Margin = new System.Windows.Forms.Padding(4);
            this.btnArprtList.Name = "btnArprtList";
            this.btnArprtList.Size = new System.Drawing.Size(80, 34);
            this.btnArprtList.TabIndex = 2;
            this.btnArprtList.Text = "List";
            this.btnArprtList.UseVisualStyleBackColor = true;
            this.btnArprtList.Click += new System.EventHandler(this.btnArprtList_Click);
            // 
            // dgvAirports
            // 
            this.dgvAirports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAirports.Location = new System.Drawing.Point(25, 36);
            this.dgvAirports.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAirports.Name = "dgvAirports";
            this.dgvAirports.RowHeadersWidth = 51;
            this.dgvAirports.Size = new System.Drawing.Size(671, 474);
            this.dgvAirports.TabIndex = 0;
            this.dgvAirports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAirports_CellClick);
            this.dgvAirports.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAirports_CellMouseDoubleClick);
            this.dgvAirports.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAirports_DataBindingComplete_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblAirportMessage);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.lbltxtAirportGate);
            this.groupBox6.Controls.Add(this.lbltxtAirportName);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.lblAirportName);
            this.groupBox6.Controls.Add(this.lblAirportGate);
            this.groupBox6.Controls.Add(this.btnAddAirport);
            this.groupBox6.Controls.Add(this.txtAirportName);
            this.groupBox6.Controls.Add(this.txtAirportGate);
            this.groupBox6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox6.Location = new System.Drawing.Point(9, 73);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(602, 565);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Add Airport";
            // 
            // lblAirportMessage
            // 
            this.lblAirportMessage.AutoSize = true;
            this.lblAirportMessage.Location = new System.Drawing.Point(217, 455);
            this.lblAirportMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportMessage.Name = "lblAirportMessage";
            this.lblAirportMessage.Size = new System.Drawing.Size(0, 28);
            this.lblAirportMessage.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 481);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 28);
            this.label1.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(184, 455);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 28);
            this.label13.TabIndex = 38;
            // 
            // lbltxtAirportGate
            // 
            this.lbltxtAirportGate.AutoSize = true;
            this.lbltxtAirportGate.Location = new System.Drawing.Point(301, 277);
            this.lbltxtAirportGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltxtAirportGate.Name = "lbltxtAirportGate";
            this.lbltxtAirportGate.Size = new System.Drawing.Size(0, 28);
            this.lbltxtAirportGate.TabIndex = 37;
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
            this.label23.Location = new System.Drawing.Point(171, 482);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 28);
            this.label23.TabIndex = 35;
            // 
            // lblAirportName
            // 
            this.lblAirportName.AutoSize = true;
            this.lblAirportName.Location = new System.Drawing.Point(45, 63);
            this.lblAirportName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportName.Name = "lblAirportName";
            this.lblAirportName.Size = new System.Drawing.Size(140, 28);
            this.lblAirportName.TabIndex = 30;
            this.lblAirportName.Text = "Airport Name";
            // 
            // lblAirportGate
            // 
            this.lblAirportGate.AutoSize = true;
            this.lblAirportGate.Location = new System.Drawing.Point(45, 245);
            this.lblAirportGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirportGate.Name = "lblAirportGate";
            this.lblAirportGate.Size = new System.Drawing.Size(131, 28);
            this.lblAirportGate.TabIndex = 29;
            this.lblAirportGate.Text = "Airport Gate";
            // 
            // btnAddAirport
            // 
            this.btnAddAirport.Location = new System.Drawing.Point(49, 475);
            this.btnAddAirport.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAirport.Name = "btnAddAirport";
            this.btnAddAirport.Size = new System.Drawing.Size(100, 36);
            this.btnAddAirport.TabIndex = 28;
            this.btnAddAirport.Text = "ADD";
            this.btnAddAirport.UseVisualStyleBackColor = true;
            this.btnAddAirport.Click += new System.EventHandler(this.btnAddAirport_Click);
            // 
            // txtAirportName
            // 
            this.txtAirportName.Location = new System.Drawing.Point(51, 95);
            this.txtAirportName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAirportName.Name = "txtAirportName";
            this.txtAirportName.Size = new System.Drawing.Size(132, 35);
            this.txtAirportName.TabIndex = 27;
            // 
            // txtAirportGate
            // 
            this.txtAirportGate.Location = new System.Drawing.Point(51, 277);
            this.txtAirportGate.Margin = new System.Windows.Forms.Padding(4);
            this.txtAirportGate.Name = "txtAirportGate";
            this.txtAirportGate.Size = new System.Drawing.Size(132, 35);
            this.txtAirportGate.TabIndex = 26;
            // 
            // AirportE_Click
            // 
            this.AirportE_Click.AutoSize = true;
            this.AirportE_Click.BackColor = System.Drawing.Color.Transparent;
            this.AirportE_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirportE_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.AirportE_Click.Location = new System.Drawing.Point(1260, 658);
            this.AirportE_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AirportE_Click.Name = "AirportE_Click";
            this.AirportE_Click.Size = new System.Drawing.Size(52, 29);
            this.AirportE_Click.TabIndex = 51;
            this.AirportE_Click.Text = "Exit";
            this.AirportE_Click.Click += new System.EventHandler(this.AirportE_Click_Click);
            // 
            // AirportFMF_Click
            // 
            this.AirportFMF_Click.AutoSize = true;
            this.AirportFMF_Click.BackColor = System.Drawing.Color.Transparent;
            this.AirportFMF_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirportFMF_Click.ForeColor = System.Drawing.Color.DarkRed;
            this.AirportFMF_Click.Location = new System.Drawing.Point(600, 658);
            this.AirportFMF_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AirportFMF_Click.Name = "AirportFMF_Click";
            this.AirportFMF_Click.Size = new System.Drawing.Size(155, 29);
            this.AirportFMF_Click.TabIndex = 49;
            this.AirportFMF_Click.Text = "Find My Flight";
            this.AirportFMF_Click.Click += new System.EventHandler(this.AirportFMF_Click_Click);
            // 
            // AirportB_Click
            // 
            this.AirportB_Click.AutoSize = true;
            this.AirportB_Click.BackColor = System.Drawing.Color.Transparent;
            this.AirportB_Click.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirportB_Click.ForeColor = System.Drawing.Color.Maroon;
            this.AirportB_Click.Location = new System.Drawing.Point(55, 658);
            this.AirportB_Click.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AirportB_Click.Name = "AirportB_Click";
            this.AirportB_Click.Size = new System.Drawing.Size(58, 29);
            this.AirportB_Click.TabIndex = 50;
            this.AirportB_Click.Text = "Back";
            this.AirportB_Click.Click += new System.EventHandler(this.AirportB_Click_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // AirportTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 751);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.AirportE_Click);
            this.Controls.Add(this.AirportFMF_Click);
            this.Controls.Add(this.AirportB_Click);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AirportTab";
            this.Load += new System.EventHandler(this.AirportTab_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AirportTab_Paint);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirports)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label AirportE_Click;
        private System.Windows.Forms.Label AirportFMF_Click;
        private System.Windows.Forms.Label AirportB_Click;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAirports;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblAirportName;
        private System.Windows.Forms.Label lblAirportGate;
        private System.Windows.Forms.Button btnAddAirport;
        private System.Windows.Forms.TextBox txtAirportName;
        private System.Windows.Forms.TextBox txtAirportGate;
        private System.Windows.Forms.Label lbltxtAirportGate;
        private System.Windows.Forms.Label lbltxtAirportName;
        private System.Windows.Forms.Label lblAirportMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnArprtList;
    }
}