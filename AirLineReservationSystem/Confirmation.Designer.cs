namespace AirLineReservationSystem
{
    partial class Confirmation
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
            this.lblExit = new System.Windows.Forms.Label();
            this.lblBookFlightBack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfirmFlight = new System.Windows.Forms.Label();
            this.lblReservationNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(1268, 690);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(52, 29);
            this.lblExit.TabIndex = 37;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblBookFlightBack
            // 
            this.lblBookFlightBack.AutoSize = true;
            this.lblBookFlightBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBookFlightBack.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookFlightBack.ForeColor = System.Drawing.Color.White;
            this.lblBookFlightBack.Location = new System.Drawing.Point(62, 690);
            this.lblBookFlightBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookFlightBack.Name = "lblBookFlightBack";
            this.lblBookFlightBack.Size = new System.Drawing.Size(150, 29);
            this.lblBookFlightBack.TabIndex = 36;
            this.lblBookFlightBack.Text = "Back (Ctrl F6)";
            this.lblBookFlightBack.Click += new System.EventHandler(this.lblBookFlightBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(304, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 47);
            this.label1.TabIndex = 38;
            this.label1.Text = "Confirm My Flight";
            // 
            // lblConfirmFlight
            // 
            this.lblConfirmFlight.AutoSize = true;
            this.lblConfirmFlight.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmFlight.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmFlight.ForeColor = System.Drawing.Color.IndianRed;
            this.lblConfirmFlight.Location = new System.Drawing.Point(475, 687);
            this.lblConfirmFlight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmFlight.Name = "lblConfirmFlight";
            this.lblConfirmFlight.Size = new System.Drawing.Size(489, 32);
            this.lblConfirmFlight.TabIndex = 39;
            this.lblConfirmFlight.Text = "CLICK TO PAY AND CONFIRM BOOKING";
            this.lblConfirmFlight.Click += new System.EventHandler(this.lblConfirmFlight_Click);
            // 
            // lblReservationNum
            // 
            this.lblReservationNum.AutoSize = true;
            this.lblReservationNum.BackColor = System.Drawing.Color.Transparent;
            this.lblReservationNum.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationNum.ForeColor = System.Drawing.Color.IndianRed;
            this.lblReservationNum.Location = new System.Drawing.Point(645, 34);
            this.lblReservationNum.MaximumSize = new System.Drawing.Size(500, 47);
            this.lblReservationNum.MinimumSize = new System.Drawing.Size(500, 47);
            this.lblReservationNum.Name = "lblReservationNum";
            this.lblReservationNum.Size = new System.Drawing.Size(500, 47);
            this.lblReservationNum.TabIndex = 40;
            //this.lblReservationNum.Click += new System.EventHandler(this.lblReservationNum_Click_1);
            // 
            // Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AirLineReservationSystem.Properties.Resources.holiday;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1387, 736);
            this.Controls.Add(this.lblReservationNum);
            this.Controls.Add(this.lblConfirmFlight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblBookFlightBack);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1405, 787);
            this.MinimumSize = new System.Drawing.Size(1405, 787);
            this.Name = "Confirmation";
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.Confirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblBookFlightBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConfirmFlight;
        private System.Windows.Forms.Label lblReservationNum;
    }
}