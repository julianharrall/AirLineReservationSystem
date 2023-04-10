namespace AirLineReservationSystem
{
    partial class AuthResult
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
            this.lblAuthorised = new System.Windows.Forms.Label();
            this.lblDecline = new System.Windows.Forms.Label();
            this.btnPrintClose = new System.Windows.Forms.Button();
            this.lblAuthNumb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAuthorised
            // 
            this.lblAuthorised.AutoSize = true;
            this.lblAuthorised.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorised.ForeColor = System.Drawing.Color.Black;
            this.lblAuthorised.Location = new System.Drawing.Point(67, 16);
            this.lblAuthorised.Name = "lblAuthorised";
            this.lblAuthorised.Size = new System.Drawing.Size(354, 152);
            this.lblAuthorised.TabIndex = 1;
            this.lblAuthorised.Text = "Your Credit Card has\r\n   been Authorised\r\nPlease Print your Flight\r\n     Details " +
    "below";
            this.lblAuthorised.Click += new System.EventHandler(this.lblAuthorised_Click);
            // 
            // lblDecline
            // 
            this.lblDecline.AutoSize = true;
            this.lblDecline.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecline.ForeColor = System.Drawing.Color.Red;
            this.lblDecline.Location = new System.Drawing.Point(67, 16);
            this.lblDecline.Name = "lblDecline";
            this.lblDecline.Size = new System.Drawing.Size(351, 152);
            this.lblDecline.TabIndex = 2;
            this.lblDecline.Text = "Your Credit Card has\r\n    been Declined\r\nPlease try again or use\r\n  another Credi" +
    "t Card";
            this.lblDecline.Click += new System.EventHandler(this.lblDecline_Click);
            // 
            // btnPrintClose
            // 
            this.btnPrintClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintClose.ForeColor = System.Drawing.Color.Black;
            this.btnPrintClose.Location = new System.Drawing.Point(135, 223);
            this.btnPrintClose.Name = "btnPrintClose";
            this.btnPrintClose.Size = new System.Drawing.Size(197, 45);
            this.btnPrintClose.TabIndex = 3;
            this.btnPrintClose.Text = "Close";
            this.btnPrintClose.UseVisualStyleBackColor = true;
            this.btnPrintClose.Click += new System.EventHandler(this.btnPrintClose_Click);
            // 
            // lblAuthNumb
            // 
            this.lblAuthNumb.AutoSize = true;
            this.lblAuthNumb.Location = new System.Drawing.Point(88, 179);
            this.lblAuthNumb.MaximumSize = new System.Drawing.Size(300, 100);
            this.lblAuthNumb.MinimumSize = new System.Drawing.Size(300, 25);
            this.lblAuthNumb.Name = "lblAuthNumb";
            this.lblAuthNumb.Size = new System.Drawing.Size(300, 25);
            this.lblAuthNumb.TabIndex = 4;
            // 
            // AuthResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 284);
            this.ControlBox = false;
            this.Controls.Add(this.lblAuthNumb);
            this.Controls.Add(this.btnPrintClose);
            this.Controls.Add(this.lblDecline);
            this.Controls.Add(this.lblAuthorised);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthResult";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthResult";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthResult_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorised;
        private System.Windows.Forms.Label lblDecline;
        private System.Windows.Forms.Button btnPrintClose;
        private System.Windows.Forms.Label lblAuthNumb;
    }
}