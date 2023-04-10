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
    public partial class AdminPassword : Form
    {
        public AdminPassword()
        {
            InitializeComponent();
        }

        public bool AdminDBAccess { get; set; }

        private void btnCanLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDbEnter_Click(object sender, EventArgs e)
        {
            //string adbp = ConfigurationManager.AppSettings["adbpd"];
            //string p = EncryptDecrypt.StringCipher.DecryptIT(adbp);

            //string pw = txtPassword.Text;

            string au = ConfigurationManager.AppSettings["aun"];
            string ap = ConfigurationManager.AppSettings["apd"];
            //lblDecrypt.Text = EncryptDecrypt.StringCipher.DecryptIT(au);
            string a = EncryptDecrypt.StringCipher.DecryptIT(au);
            string p = EncryptDecrypt.StringCipher.DecryptIT(ap);
            string ut = txtPassword.Text;
            string at = txtUsername.Text;

            if (a == at && p == ut)//f (p == pw)
                AdminDBAccess = true;
            //if (pw == "") AdminDBAccess = true;
            else AdminDBAccess = false;

            Close();

        }
    }
}
