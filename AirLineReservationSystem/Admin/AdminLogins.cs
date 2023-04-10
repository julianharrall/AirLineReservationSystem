using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AirLineReservationSystem.Admin
{
    public partial class AdminLogins : Form
    {

        public string LoginName { get; set; }
        public AdminLogins(string name)
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            LoginName = name;
            lblLoginName.Text = LoginName;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Dock = DockStyle.Fill;
        }

        public bool AdminDBAccess { get; set; }

        public void CreateMyBorderlessWindow()
        {
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;

        }

        ////You can't hide it, but you can disable it by overriding the CreateParams property of the form.
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        // remove the entire system menu
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
            string adbp = ConfigurationManager.AppSettings["adbpd"];
            string p = EncryptDecrypt.StringCipher.DecryptIT(adbp);

            string pw = txtPassword.Text;


            //if (p == pw) AdminDBAccess = true;
            if (pw == p)
                AdminDBAccess = true;
            else AdminDBAccess = false;

            Close();

        }
    }
}
