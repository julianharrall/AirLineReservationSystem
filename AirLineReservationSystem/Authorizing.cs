using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace AirLineReservationSystem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=9lClG0PK83U
    /// https://www.youtube.com/watch?v=pXCjFRFOF9A
    /// https://www.youtube.com/watch?v=bb5TaLbq9aM
    /// </summary>
    public partial class Authorizing : Form
    {
        
        public System.Windows.Forms.Timer authorizeTimer { get; set; }
        public bool authorised { get; set; }
        public int counter { get; set; } = 0;

        public static int Authorised { get; set; }

        public static int secondsCount = 0;
      
        public Authorizing()
        {
            InitializeComponent();            
        }
               
      
        private void Authorizing_Load(object sender, EventArgs e)
        {
            authorizeTimer = new System.Windows.Forms.Timer();
            authorizeTimer.Interval = 1000; // 1 second 
            authorizeTimer.Tick += AuthorizeTimer_Tick;
            authorizeTimer.Start();

            // Create random number between 1 and 3
            // i.e. 1 or 2 (1 = Authorised)
            Random rnd = new Random();
            Authorised = rnd.Next(1, 3);
        }

        /// <summary>
        /// Event method that is called on every tick of Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorizeTimer_Tick(object sender, EventArgs e)
        {
            counter++;          

            // After 15 seconds
            if (counter == 15)
            {
                authorizeTimer.Stop();
                
                AuthResult aure = new AuthResult();

                // As soon as the AuthResult form is displayed/shown
                // i.e. aure.ShowDialog(), then hides this current form
                aure.Shown += (s, args) => 
                {
                    this.Hide();
                };

                // When AuthResult form closed then
                // close and dispose of this hidden form
                aure.Closed += (s, args) =>
                {
                    this.Close();
                    this.Dispose();
                };


                // Display/show AuthResult form
                aure.ShowDialog();  
                
            }

        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
