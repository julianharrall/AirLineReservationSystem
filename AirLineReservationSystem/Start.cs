using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AirLineReservationSystem
{
    public partial class Start : Form
    {
        Form1 f;
    

        public Start()
        {           
            InitializeComponent();           
            f = new Form1();         
            mdiChildren();
        }

        

        public void CreateMyBorderlessWindow()
        {           
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
        }


        // remove the entire system menu:
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }
      

        public void Start_Load(object sender, EventArgs e)
        {           
            startLoad();
        }

        public void startLoad()
        {          
            f.Show();            
        }



        public void mdiChildren()
        {         
            f.MdiParent = this;
            f.FormClosed += new FormClosedEventHandler(f_FormClosed); ////http://www.youtube.com/watch?v=-4EYhC9xDHo            
            f.WindowState = FormWindowState.Maximized;
            //http://stackoverflow.com/questions/4537925/c-sharp-winforms-open-forms-inside-mainform
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
        }
        
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            f = null;
            //throw new NotImplementedException();
        }

        public void closeNow()
        {
            this.Close();
        }

        
    }
}
