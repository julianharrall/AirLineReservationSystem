using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLineReservationSystem
{
    public partial class AuthResult : Form
    {

        //public static string ReservationNum { get; set; }
        public AuthResult()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Card authorised
            if (Authorizing.Authorised == 1 )
            {
                // Create random string as Flight Reservation number
                var generator = new RandomGenerator();
                var randomNumber = generator.RandomNumber(5, 100);
                var randomString = generator.RandomString(10);
                var randomPassword = generator.RandomPassword();

                lblAuthNumb.Font = new Font("Arial", 18);
                lblAuthNumb.ForeColor = Color.Red;
                lblAuthNumb.Width = 400;
                lblAuthNumb.Height = 200;
                lblAuthNumb.Text = "FLR-" + randomPassword.ToString();

                //lblReservationNum
                
                FlightCustDetails.ReservationNum = lblAuthNumb.Text;

;               lblDecline.Hide();  
            }
            else // Card declined
            {
                btnPrintClose.Text = "Close";
                btnPrintClose.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                lblAuthorised.Hide();   
            }

        }




        private void btnPrintClose_Click(object sender, EventArgs e)
        {
            if (Authorizing.Authorised == 1)
            {

            }


                this.Close();
        }

        private void lblDecline_Click(object sender, EventArgs e)
        {

        }

        private void lblAuthorised_Click(object sender, EventArgs e)
        {

        }

        private void AuthResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
