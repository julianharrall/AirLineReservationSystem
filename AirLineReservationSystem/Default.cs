using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace AirLineReservationSystem
{
    public partial class Form1 : Form
    {

        // child forms
        Administration ad;
        FindFlight ff;
        //Admin.AdminMainForm ad;

        public FlightTabTest ft { get; set; }


        public Form1()
        {
            InitializeComponent();
            // ensure admin login is not visible
            loginDetails(false);

            // add context menu for Admin Form
            ContextMenu cm = new ContextMenu();
            MenuItem mnuItemNew = new MenuItem();
            mnuItemNew.Text = "Admin";
            cm.MenuItems.Add(mnuItemNew);
            label1.ContextMenu = cm;
            //label1.BackColor = Color.Red;

            using(ft = new FlightTabTest())
            {
                ft.FlightCleanup();
            }
            

            mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
            
        }
        
        void mnuItemNew_Click(object sender, EventArgs e)
        {
            loginDetails(true);
            //throw new NotImplementedException();
        }

        public void CreateMyBorderlessWindow()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
        }      

        private void Default_Load(object sender, EventArgs e)
        {
            CreateMyBorderlessWindow();          
            loginDetails(false);
        }        
       
        private void label2_Click(object sender, EventArgs e)
        {       
            //http://stackoverflow.com/questions/1463513/move-one-form-to-another-winforms-c-sharp
            ff = new FindFlight();
            ff.MdiParent = this.MdiParent;
            ff.FormClosed += new FormClosedEventHandler(ff_FormClosed);            
            ff.Show();            
        }       

        void ff_FormClosed(object sender, FormClosedEventArgs e)
        {
            ff = null;
            ad = null;
            ft = null;
            
            //throw new NotImplementedException();
        }

        
        public void loginDetails(bool tf)
        {
            lblPassword.Visible = tf;
            lblUsername.Visible = tf;           
            txtUsername.Visible = tf;
            txtPassword.Visible = tf;         

            lblCancel.Visible = tf;
            lblEnter.Visible = tf;
            labelExit.Visible = !tf;
            label2.Visible = !tf;
        }      

        
        private void lblEnter_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            cancelCode();
        }

        public void cancelCode()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            loginDetails(false);
        }
        
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
        
        private void lblAdmin_Click(object sender, EventArgs e)
        {
            loginDetails(true);
        }

        private void lblEnter_Click(object sender, EventArgs e)
        {
            FlightCustDetails.ClearFields();    

            string au = ConfigurationManager.AppSettings["aun"];
            string ap = ConfigurationManager.AppSettings["apd"];
            //lblDecrypt.Text = EncryptDecrypt.StringCipher.DecryptIT(au);
           string a = EncryptDecrypt.StringCipher.DecryptIT(au);
           string p = EncryptDecrypt.StringCipher.DecryptIT(ap);
           string ut = txtPassword.Text;
           string at = txtUsername.Text;
           bool tempflag = true;
           //if (tempflag)//if (a == at && p == ut)
           if (a == at && p == ut)
           {
               ad = new Administration(this);
               //ad = new Admin.AdminMainForm();
               
               ad.MdiParent = this.MdiParent;
               ad.FormClosed += new FormClosedEventHandler(ad_FormClosed);
               ad.WindowState = FormWindowState.Maximized;
               ad.Dock = DockStyle.Fill;
               ad.Show();

               cancelCode();
           }
           else
           { MessageBox.Show("Incorrect Username or Password", "Incorrect Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
              return;
           }

          
        }

        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
            //throw new NotImplementedException();
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }


      
    }
}
