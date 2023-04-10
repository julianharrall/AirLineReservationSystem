namespace AirLineReservationSystem
{
    partial class BookFlightTest
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
            this.lblBookFlightBack = new System.Windows.Forms.Label();
            this.lblConfirmFlight = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBookFlightBack
            // 
            this.lblBookFlightBack.AutoSize = true;
            this.lblBookFlightBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBookFlightBack.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookFlightBack.ForeColor = System.Drawing.Color.White;
            this.lblBookFlightBack.Location = new System.Drawing.Point(57, 693);
            this.lblBookFlightBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookFlightBack.Name = "lblBookFlightBack";
            this.lblBookFlightBack.Size = new System.Drawing.Size(150, 29);
            this.lblBookFlightBack.TabIndex = 30;
            this.lblBookFlightBack.Text = "Back (Ctrl F6)";
            this.lblBookFlightBack.Click += new System.EventHandler(this.lblBookFlightBack_Click);
            // 
            // lblConfirmFlight
            // 
            this.lblConfirmFlight.AutoSize = true;
            this.lblConfirmFlight.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmFlight.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmFlight.ForeColor = System.Drawing.Color.White;
            this.lblConfirmFlight.Location = new System.Drawing.Point(603, 693);
            this.lblConfirmFlight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmFlight.Name = "lblConfirmFlight";
            this.lblConfirmFlight.Size = new System.Drawing.Size(192, 29);
            this.lblConfirmFlight.TabIndex = 23;
            this.lblConfirmFlight.Text = "Passenger Details ";
            this.lblConfirmFlight.Click += new System.EventHandler(this.lblConfirmFlight_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(1263, 693);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(52, 29);
            this.lblExit.TabIndex = 34;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
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
            this.label1.Size = new System.Drawing.Size(285, 47);
            this.label1.TabIndex = 35;
            this.label1.Text = "Select My Flight";
            // 
            // BookFlightTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1387, 736);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblBookFlightBack);
            this.Controls.Add(this.lblConfirmFlight);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1405, 787);
            this.MinimumSize = new System.Drawing.Size(1405, 787);
            this.Name = "BookFlightTest";
            this.Text = "SelectFlight";
            this.Load += new System.EventHandler(this.FindFlight_Load);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.BookFlightTest_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label lblBookFlightBack;
        private System.Windows.Forms.Label lblConfirmFlight;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label label1;
    }
}