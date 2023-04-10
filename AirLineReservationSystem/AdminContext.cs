using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AirLineReservationSystem
{
    public partial class AdminContext : Form
    {
        Administration ad;
        Form f;

        public AdminContext(Form f)
        {
            InitializeComponent();
            f = new Form1();

        }

        private void lblEnter_Click(object sender, EventArgs e)
        {
            string au = ConfigurationManager.AppSettings["aun"];
            string ap = ConfigurationManager.AppSettings["apd"];
            //lblDecrypt.Text = EncryptDecrypt.StringCipher.DecryptIT(au);
            string a = EncryptDecrypt.StringCipher.DecryptIT(au);
            string p = EncryptDecrypt.StringCipher.DecryptIT(ap);
            string ut = txtPassword.Text;
            string at = txtUsername.Text;
            bool tempflag = true;
            if (tempflag)//if (a == at && p == ut)
            {
                ad = new Administration(this);
                //ad = new Admin.AdminMainForm();

                ad.MdiParent = this.MdiParent;
                ad.FormClosed += new FormClosedEventHandler(ad_FormClosed);
                ad.WindowState = FormWindowState.Maximized;
                ad.Dock = DockStyle.Fill;
                ad.Show();
                this.Close();

                cancelCode();
            }
            else
            { MessageBox.Show("Try again sucker"); return; }

        }

        public void cancelCode()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            loginDetails(false);
        }

        public void loginDetails(bool tf)
        {
            lblPassword.Visible = tf;
            lblUsername.Visible = tf;
            txtUsername.Visible = tf;
            txtPassword.Visible = tf;

            lblCancel.Visible = tf;
            lblEnter.Visible = tf;
            //labelExit.Visible = !tf;
            label2.Visible = !tf;
        }      

        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
            //throw new NotImplementedException();
        }
    }
}
