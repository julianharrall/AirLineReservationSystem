using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace AirLineReservationSystem
{
    public partial class FindFlight : Form
    {
        AirlineReservationDAL.AirlineReservation ar;
        //AirlineReservationDAL.AirlineReservation ar;

        FlightDetails fd;
        BookFlightTest bf;
        Administration ad;

        public static List<string> FlightStats { get; set; }
        public DateTime DtDepartureTime { get; set; }
        public bool AdminDBAccess { get; set; }
        public DateTime dtStart { get; set; }
        public DateTime dtEnd { get; set; }

        public Boolean dtfirtstime2; // ensure start date starts at todays date and extends to return date

        public string cmbTicketType { get; set; }
        public int intNumbAdults { get; set; }
        public int intNumbChildren { get; set; }


        public FindFlight()
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            Populate();

            FlightStats = new List<string>();

            // start and return date starts at todays date
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now;
            dtfirtstime2 = true;
            //DtDepartureTime = dateTimePicker1.Value;

            ContextMenu cm = new ContextMenu();
            MenuItem mnuItemNew = new MenuItem();
            mnuItemNew.Text = "Admin";
            cm.MenuItems.Add(mnuItemNew);
            this.ContextMenu = cm;
            mnuItemNew.Click += new EventHandler(mnuItemNew_Click);

            
        }

       

        void mnuItemNew_Click(object sender, EventArgs e)
        {
            AdminPassword testDialog = new AdminPassword();

            testDialog.ShowDialog(this);

            if (testDialog.AdminDBAccess)
            {
                string au = ConfigurationManager.AppSettings["aun"];
                string ap = ConfigurationManager.AppSettings["apd"];
                //lblDecrypt.Text = EncryptDecrypt.StringCipher.DecryptIT(au);
                string a = EncryptDecrypt.StringCipher.DecryptIT(au);
                string p = EncryptDecrypt.StringCipher.DecryptIT(ap);
                //string ut = txtPassword.Text;
                //string at = txtUsername.Text;
                bool tempflag = true;
                if (tempflag)//if (a == at && p == ut)
                {
                    ad = new Administration(this, true);

                    //ad.Tag="FMF_Tag";
                    //Control c = (Control)"FMF_Tag"; 
                    //ad.Controls.Remove(labelToRemove);
                    ////ad = new Admin.AdminMainForm();

                    ad.MdiParent = this.MdiParent;
                    ad.FormClosed += new FormClosedEventHandler(ad_FormClosed);
                    ad.WindowState = FormWindowState.Maximized;
                    ad.Dock = DockStyle.Fill;
                    ad.Show();

                    cancelCode();
                }
                else
                { MessageBox.Show("Please Try again"); return; }
            }
        }

        //private bool DatabaseTab()
        //{
        //    AdminLogin testDialog = new AdminLogin();

        //    testDialog.ShowDialog(this);

        //    if (testDialog.AdminDBAccess) return true;
        //    else return false;
        //}

        public void cancelCode()
        {
            //txtPassword.Text = "";
            //txtUsername.Text = "";
            //loginDetails(false);
        }

        //private void btDbEnter_Click(object sender, EventArgs e)
        //{
        //    string adbp = ConfigurationManager.AppSettings["adbpd"];
        //    string p = EncryptDecrypt.StringCipher.DecryptIT(adbp);

        //    string pw = txtPassword.Text;


        //    //if (p == pw) AdminDBAccess = true;
        //    if (pw == "") AdminDBAccess = true;
        //    else AdminDBAccess = false;

        //    Close();

        //}

        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;            
            bf = null;
        }      

        public string CountryDestination { get; set; }

        public bool pEconomyClass { get; set; } = false;
        public bool pBusinessClass { get; set; } = false;
        public bool pFirstClass { get; set; } = false;

        public string AirportName { get; set; }

        public struct FlightDetails
        {
            public string dest1;
            public string dest2;
            public DateTime Date1;
            public DateTime Date2;
            public string route;
            public int adults;
            public int children;
            public string ticketType;           
        }

        public void Populate()
        {
            // stop comboxes from being edited
            cmbTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            //var Alldestinations = from d in ar.Destination select d;
            var Homedestinations = from hd in ar.Destination select hd;
               
            cmbTo.DisplayMember = "Country";
            cmbTo.ValueMember = "DestID";
            cmbTo.DataSource = Homedestinations;
            cmbTo.SelectedIndex = -1;

            var AllAirports = from aa in ar.Airport select aa;
                //ar.Destination.Select; //Where(d => d.DestinationType == ("Away"));
            cmbFrom.DisplayMember = "AirportName";
            cmbFrom.ValueMember = "AirportID";
            cmbFrom.DataSource = AllAirports;
            cmbFrom.SelectedIndex = -1;

            cmbxChildren.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdults.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxChildren.Items.Add(0);
            for (int x = 1; x < 5; x++)
            {
                cmbAdults.Items.Add(x);
                cmbxChildren.Items.Add(x);
            }
            cmbxChildren.SelectedIndex = 0;
            cmbAdults.SelectedIndex = 0;

            cmbxTicketTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxTicketTypes.Items.Add("Economy");
            cmbxTicketTypes.Items.Add("Business");
            cmbxTicketTypes.Items.Add("First");
            cmbxTicketTypes.SelectedIndex = 0;

           
        }

        private void FindFlight_Load(object sender, EventArgs e)
        {
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;            
        }       

        private void btnFindFlightExit_Click(object sender, EventArgs e)
        {
            ar.Connection.Close();
            this.Close();         
        }                      

        private void btnFindFlight_Click(object sender, EventArgs e)
        {          
            
        }            

        private void rbOneWay_CheckedChanged(object sender, EventArgs e)
        {          
            dateTimePicker2.Enabled = false;

            
        }

        private void rdReturn_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = true;

           
        }

        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            // check you have selected a starting destination and store value
            if (cmbFrom.SelectedIndex != -1)
            { 
                fd.dest1 = cmbFrom.Text;
                //FlightStats.Add(cmbFrom.Text);
                FlightCustDetails.FlightAirport = cmbFrom.Text; 
            }
            else
            {
                MessageBox.Show("Please Select the Airport you wish to travel from");
                return;
            }

            // check you have selected a finishing destination and store value
            if (cmbTo.SelectedIndex != -1)
            {
                fd.dest2 = cmbTo.Text;
                //FlightStats.Add(cmbTo.Text);
                FlightCustDetails.FlightCountry = cmbTo.Text;   
            }
            else
            {
                MessageBox.Show("Please Select the destination Airport");
                return;
            }


           

             dtStart = dateTimePicker1.Value;
             dtEnd = dateTimePicker2.Value;

            if (DateTime.Compare(dtEnd, dtStart) == -1 & fd.route != "One Way")
            {
                MessageBox.Show("Your Return date needs to be after your Outgoing date!");
                return;
            }
                 

            // if route is not One Way - continue
            // else store store start date
            if (fd.route != "One Way")
            {
                fd.Date1 = dtStart;
                fd.Date2 = dtEnd;
                //FlightStats.Add(dtStart.ToShortDateString());
                //FlightStats.Add(dtEnd.ToShortDateString());
                //FlightCustDetails.FlightOut = dtStart.ToShortDateString();
                //FlightCustDetails.FlightIn = dtEnd.ToShortDateString();
            }
            else
            {
                fd.Date1 = dtStart;
                //FlightStats.Add(dtStart.ToShortDateString());
                //FlightCustDetails.FlightOut = dtStart.ToShortDateString();
            }


            // store number of adults (default 1) and children (default 0)
            fd.adults = Convert.ToInt32(cmbAdults.Text);
            fd.children = Convert.ToInt32(cmbxChildren.Text);
            //FlightStats.Add(cmbAdults.Text);
            //FlightStats.Add(cmbxChildren.Text);


            // store ticket type
            fd.ticketType = cmbxTicketTypes.Text;
            FlightStats.Add(cmbxTicketTypes.Text);
            FlightCustDetails.FlightType = cmbxTicketTypes.Text;

            //Control.ControlCollection c = this.Controls;

            // Check if any Adults have been removed
            if(intNumbAdults < FlightCustDetails.Adults.Count)
            {
                int removeAdults = FlightCustDetails.Adults.Count - intNumbAdults;
                //FlightCustDetails.Adults.Remove(FlightCustDetails.Adults[FlightCustDetails.Adults.Count-1]);
                //FlightCustDetails.Adults.RemoveAt(rows.Count - 1)
                for (int i = 0; i < removeAdults; i++)
                {
                    FlightCustDetails.Adults.RemoveAt(FlightCustDetails.Adults.Count - 1);
                }
            }

            

            // Check if any Children have been removed
            if (intNumbChildren < FlightCustDetails.Children.Count)
            {
                int removeChildren = FlightCustDetails.Children.Count - intNumbChildren;
                //FlightCustDetails.Children.Remove(FlightCustDetails.Children[FlightCustDetails.Children.Count - 1]);
                for (int i = 0; i < removeChildren; i++)
                {
                    FlightCustDetails.Children.RemoveAt(FlightCustDetails.Children.Count - 1);
                }
            }
            



            // open new form           
            bf = new BookFlightTest(this);
            bf.MdiParent = this.ParentForm;
            bf.FormClosed += new FormClosedEventHandler(bf_FormClosed);         
            this.Dock = DockStyle.Fill;

            bf.Show();       
        }

        void bf_FormClosed(object sender, FormClosedEventArgs e)
        {
            bf = null;
            //throw new NotImplementedException();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {
            FlightCustDetails.ClearFields();
            this.Close();

        }
              

        private void cmbTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FlightCustDetails.FlightNum = "";
            CountryDestination = this.cmbTo.GetItemText(this.cmbTo.SelectedItem);
        }

        private void cmbFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FlightCustDetails.FlightNum = "";
            AirportName = this.cmbFrom.GetItemText(this.cmbFrom.SelectedItem);
        }



        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FlightCustDetails.FlightNum = "";
            if (dtfirtstime2)
            {
                if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    //dateTimePicker1.MinDate = dateTimePicker1.Value;
                    //dateTimePicker1.MaxDate = dateTimePicker1.Value;
                    
                    dateTimePicker2.Value = dateTimePicker1.Value;
                     
                }
            }
            DtDepartureTime = dateTimePicker1.Value;
            //FlightCustDetails.FlightOut = DtDepartureTime.ToLongDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FlightCustDetails.FlightNum = "";
            // ensure start date starts at todays date and extends to return date
            if (dtfirtstime2)
            {
                if (dateTimePicker2.Value < DateTime.Now)
                {
                    
                    dateTimePicker1.MinDate = dateTimePicker2.Value;
                    dateTimePicker1.MaxDate = dateTimePicker2.Value;
                }
                else if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    
                    dateTimePicker1.Value = dateTimePicker2.Value;

                    //dateTimePicker1.MaxDate = dateTimePicker2.Value;
                    //dateTimePicker1.MinDate = DateTime.Now;
                }
            }

            //FlightCustDetails.FlightIn = dateTimePicker2.Value.ToLongDateString();
        }

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbxTicketTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FlightCustDetails.FlightNum = "";
            cmbTicketType = this.cmbxTicketTypes.GetItemText(this.cmbxTicketTypes.SelectedItem);
            FlightCustDetails.FlightType = cmbTicketType;
        }

        private void cmbAdults_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FlightCustDetails.FlightNum = "";
            //FlightCustDetails.Adults.Clear();
            intNumbAdults = Convert.ToInt32(this.cmbAdults.GetItemText(this.cmbAdults.SelectedItem));
            
        }

        //Form has a lot of controls and it has a massive amount of flicker, on startup.
        // the below is a fix
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void cmbxChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FlightCustDetails.FlightNum = "";
            intNumbChildren = Convert.ToInt32(this.cmbxChildren.GetItemText(this.cmbxChildren.SelectedItem));
        }

        
    }
}
