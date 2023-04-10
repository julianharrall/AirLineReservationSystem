using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLineReservationSystem.Admin
{
    public partial class AdminRestoreDBLogin : Form
    {
        public bool AdminRestoreDBAccess { get; set; }
        public AdminRestoreDBLogin()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Dock = DockStyle.Fill;
        }

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

        private void btDbEnter_Click(object sender, EventArgs e)
        {
            string adbp = ConfigurationManager.AppSettings["apd"];
            string p = EncryptDecrypt.StringCipher.DecryptIT(adbp);

            string pw = txtPassword.Text;


            //if (p == pw) AdminDBAccess = true;
            if (pw == p)
                AdminRestoreDBAccess = true;
            else AdminRestoreDBAccess = false;

            Close();
        }

        private void btnDbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
