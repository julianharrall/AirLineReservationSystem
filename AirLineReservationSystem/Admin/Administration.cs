using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
//TODO: Need to ensure all changes to fields are cascaded to other tables e.g. seats

namespace AirLineReservationSystem
{
    public partial class Administration : Form
    {
        FindFlight ff;
        Form1 frm1;
        Form frm;
        AirlineReservationDAL.AirlineReservation ar;       
        //DataGridViewButtonColumn btn;
        string ConnectionString;
        bool removeLabels;
                        
        public Administration(Form1 f)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            adminLabelEvents();
            frm1 = f;
            ConnectionString = ar.Connection.ConnectionString.ToString();
            setUpTabControl();
        }

        public Administration(Form f, bool remove = false)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            adminLabelEvents();
            frm = f;
            removeLabels = remove;
            ConnectionString = ar.Connection.ConnectionString.ToString();
            setUpTabControl();

        }

        public void AdminClose()
        {
            this.Close();
        }

        private void setUpTabControl()
        {
            //AircraftTab2 art = new AircraftTab2(this);
            AircraftTab art = new AircraftTab(this);
            art.Name = "AircraftTab";
            DataBaseTab dt = new DataBaseTab(this);
            dt.Name = "AircraftTab";          
            //FlightTab ft = new FlightTab(this);
            FlightTabTest ft = new FlightTabTest(this);
            ft.Name = "FlightTab";
            BookingTab bt = new BookingTab(this);
            bt.Name = "BookingTab";
            //CustomerTab ct = new CustomerTab(this);
            DestinationTab dst = new DestinationTab(this);
            dst.Name = "DestinationTab";
            AirportTab at = new AirportTab(this);
            at.Name = "AirportTab";

            if (removeLabels)
            {
                art.Controls.Remove(art.Controls["AircraftFMF_Click"]);
                dst.Controls.Remove(dst.Controls["lblConfirmFlight"]);
                dt.Controls.Remove(dt.Controls["Database_FMF_Click"]);
                at.Controls.Remove(at.Controls["AirportFMF_Click"]);
                ft.Controls.Remove(ft.Controls["FlightFMF_Click"]);
                bt.Controls.Remove(bt.Controls["Booking_FMF_Click"]);
                //ct.Controls.Remove(ct.Controls["CustomerFMF_Click"]);
            }
                      
            addtabs(at, "Airport");
            addtabs(art, "Aircraft");
            addtabs(dst, "Destination");
            addtabs(ft, "Flight");
            addtabs(bt, "Booking");
            //addtabs(ct, "Customer");             
            addtabs(dt, "Database");       
            TabControl.Dock = DockStyle.Fill;
        }

        public void addtabs(Form f, string nme)
        {
            TabPage tp = new TabPage();
            tp.Text = nme;
            f.TopLevel = false;
            f.Parent = tp;
            f.Visible = true;
            TabControl.TabPages.Add(tp);                       
        }

        public void adminLabelEvents()
        {
            //AircraftFMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //AircraftB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //AircraftE_Click.Click += new EventHandler(lblExit_Click);
            //AirportB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //AirportE_Click.Click += new EventHandler(lblExit_Click);
            //AirportFMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //FlightB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //FlightE_Click.Click += new EventHandler(lblExit_Click);
            //FlightFMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //Booking_FMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //BookingB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //BookingE_Click.Click += new EventHandler(lblExit_Click);
            //CustomerFMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //CustomerB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //CustomerE_Click.Click += new EventHandler(lblExit_Click);
            //Database_FMF_Click.Click += new EventHandler(lblConfirmFlight_Click);
            //DatabaseB_Click.Click += new EventHandler(lblBookFlightBack_Click);
            //DatabaseE_Click.Click += new EventHandler(lblExit_Click);

          
        }

        public void CreateMyBorderlessWindow()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            // NB: This line of code loads data into the 'airlineReservationDataSet.Booking' table. You can move, or remove it, as needed.
            //this.bookingTableAdapter.Fill(this.airlineReservationDataSet.Booking);
            CreateMyBorderlessWindow();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void lblBookFlightBack_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        public void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            // ensure Admin form is closed as do not want to make it possible to navigate back
            foreach (Form a in this.MdiParent.MdiChildren)
            {
                // MessageBox.Show(a.Text);
                if (a.Text == "Administration") a.Close();
            }

            //http://stackoverflow.com/questions/1463513/move-one-form-to-another-winforms-c-sharp
            showFindFlight();
        }

        public void showFindFlight()
        {
            Form fflt = Application.OpenForms["FindFlight"];

            if (fflt != null)
            {
                //lblConfirmFlight
                fflt.Close();
            }

           
            ff = new FindFlight();
            //ff.MdiParent = this.MdiParent;
            if (frm1.MdiParent != null)
            {

                ff.MdiParent = frm1.MdiParent;
                ff.FormClosed += new FormClosedEventHandler(ff_FormClosed);
                ff.Show();
            }
            //else
            //    Form frm1.MdiParent = new frm1.MdiParent();
                
           
        }

        void ff_FormClosed(object sender, FormClosedEventArgs e)
        {            
            ar.Connection.Close();
            ff = null;
            //throw new NotImplementedException();
        }

        private void cbxFlightNo_MouseClick(object sender, MouseEventArgs e)
        {
            var FlightNumbers = from fn in ar.Booking select fn.FlightN;
            //cbxFlightNo.DisplayMember = "FlightNumber";
            //cbxFlightNo.ValueMember = "BookingID";
            //cbxFlightNo.DataSource = FlightNumbers;
            //cbxFlightNo.SelectedIndex = -1;
        }
        
        /*
        private void cbxCost_MouseClick(object sender, MouseEventArgs e)
        {
            var FlightCosts = from fn in ar.Booking select fn.Cost;
            //cbxCost.DisplayMember = "Cost";
            //cbxCost.ValueMember = "BookingID";
            //cbxCost.DataSource = FlightCosts;
            //cbxCost.SelectedIndex = -1;
        }

        
        private void cbxPassCount_MouseClick(object sender, MouseEventArgs e)
        {
            //var PassengerCounts = from fn in ar.Booking select fn.PassengerCount;
            //cbxPassCount.DisplayMember = "PassengerCount";
            //cbxPassCount.ValueMember = "BookingID";
            //cbxPassCount.DataSource = PassengerCounts;
            //cbxPassCount.SelectedIndex = -1;
        }

        private void cbxClass_MouseClick(object sender, MouseEventArgs e)
        {
            //var BookClass = from fn in ar.Booking select fn.Class;
            //cbxClass.DisplayMember = "Class";
            //cbxClass.ValueMember = "BookingID";
            //cbxClass.DataSource = BookClass;
            //cbxClass.SelectedIndex = -1;
        }

        private void cbxBookType_MouseClick(object sender, MouseEventArgs e)
        {
            //var BookType = from fn in ar.Booking select fn.BookingType;
            //cbxBookType.DisplayMember = "BookingType";
            //cbxBookType.ValueMember = "BookingID";
            //cbxBookType.DataSource = BookType;
            //cbxBookType.SelectedIndex = -1;
        }

        private void cbxTicketType_MouseClick(object sender, MouseEventArgs e)
        {
            //var BookTickType = from fn in ar.Booking select fn.TicketType;
            //cbxTicketType.DisplayMember = "TicketType";
            //cbxTicketType.ValueMember = "BookingID";
            //cbxTicketType.DataSource = BookTickType;
            //cbxTicketType.SelectedIndex = -1;
        }
        */

        //http://stackoverflow.com/questions/17815570/two-related-comboboxes-in-c-sharp-populating-from-database
        private void btnBookingSearch_Click(object sender, EventArgs e)
        {
            //string tickType;

            //if (!String.IsNullOrEmpty(cbxFlightNo.GetItemText(this.cbxFlightNo.SelectedItem)))
            //{
            //    string fltNo = cbxFlightNo.GetItemText(this.cbxFlightNo.SelectedItem).Trim();
            //    varSql = SqlString + " where bk.FlightN=" + "'" + fltNo + "'";
            //}
            //else
            //{
            //    if (!String.IsNullOrEmpty(cbxTicketType.GetItemText(this.cbxTicketType.SelectedItem)))
            //    {
            //        tickType = cbxTicketType.GetItemText(this.cbxTicketType.SelectedItem).Trim();

            //        if (!SqlString.ToLower().Contains("where"))
            //        {
            //            //TType = "and TicketType= " + "'" + tickType + "'";
            //            SqlString += " where bk.TicketType=" + "'" + tickType + "'";
            //        }


            //        //var BookingsSql = from bk in ar.Booking 
            //        //                  orderby bk descending
            //        //                  where bk.TicketType == tickType
            //        //                  select bk; 


            //    }
            //}

            //Picks up textbox values typed in - if needed
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxFlightNo.Text));
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxCost.Text));            
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxPassCount.Text));
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxClass.Text));
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxBookType.Text));
            //MessageBox.Show(cbxFlightNo.GetItemText(this.cbxTicketType.Text));

            
        }

            
       

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage tp= e.TabPage;
            int xe = e.TabPageIndex;
            
            string tabPageName = e.TabPage.Name.ToString();//e.TabPage.Controls[e.TabPageIndex-1].Name;
            switch (tabPageName)
            {
                case "DestinationTab":
                    MessageBox.Show("Destination Tab");
                    break;
                case "AircraftTab":
                    MessageBox.Show("Aircraft Tab");
                    break;
                case "AirportTab":
                    MessageBox.Show("Airport Tab");
                    break;
                case "FlightTab":
                    MessageBox.Show("Flight Tab");
                    break;
                case "CustomerTab":
                    MessageBox.Show("Customer Tab");
                    break;
                case "BookingsTab":
                    MessageBox.Show("Bookings Tab");
                    break;
                case "tpDatabase":                    
                    break;
                default:
                    Console.WriteLine("Tab Page Problem");
                    break;
            }

        }

        private void AddImageColumn()
        {
            //var AllAircraft = from ac in ar.Aircraft select new { ac.AircraftType, ac.SeatCapacity };

            //dataGridView1.DataSource = AllAircraft.ToList();
            //btn = new DataGridViewButtonColumn();

            //dataGridView1.Columns.Add(btn);
            //btn.HeaderText = "AImage";
            //btn.Text = "Image";
            //btn.Name = "btn";
        }

        private void btnSearchDest_Click(object sender, EventArgs e)
        {
            //var AllDestinations = from ac in ar.Destination select ac;
            //dgvSMDestination.DataSource = AllDestinations;
        }

      
       
        private bool DatabaseTab()
        {
            AdminLogin testDialog = new AdminLogin();
            //AirLineReservationSystem.Admin.AdminLogins testDialog = new AirLineReservationSystem.Admin.AdminLogins("Database");
            //AirLineReservationSystem.Admin.AdminRestoreDBLogin testDialog = new AirLineReservationSystem.Admin.AdminRestoreDBLogin();

            testDialog.ShowDialog(this);

            if (testDialog.AdminDBAccess) return true;
            else return false;
        }

        

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "Database")
            {
                if (!DatabaseTab())
                {
                    e.Cancel = true;
                }

            }

        }

       

       

       
             
      

    }
}
    

