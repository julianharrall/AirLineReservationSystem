using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

using System.Data.Linq;
using System.Reflection;
using System.IO;

namespace AirLineReservationSystem
{
    public partial class BookFlightTest : Form
    {
        public VScrollBar vScroller { get; set; }

        AirlineReservationDAL.AirlineReservation ar;
        //AirlineReservationDAL.AirlineReservation ar;       
        FindFlight ff;
        ReserveFlight rf;
        Passenger_Details pd;
        bool initialdate; // flag set when intial date is set when entering BookFlight
        ContextMenu cm;
        Administration ad;

        public bool flightExists { get; set; }
        public IQueryable<AirlineReservationDAL.Flight> IQFlight { get; set; }
        public RadioButton Rb { get; set; }
        public static string strRBSelectFlightInt { get; set; }
        String CurrYear { get; set; }
        String CurrentYear { get; set; }
        String CurrMonth { get; set; }
        String currDay { get; set; }
        String CurrDate { get; set; }
        string currM { get; set; }
        int daysInMonth { get; set; }
        int month { get; set; }
        public List<AirlineReservationDAL.Flight> iqFlights  { get; set; }

        Table<AirlineReservationDAL.Flight> ft { get; set; }

        //public List<string> FlightNumbsList { get; set; }

        public DateTime DtStart { get; set; }      

        public TableLayoutPanel tlpanel { get; set; }

        public int NumAdults { get; set; }
        public int NumChildren { get; set; }

        //BookFlightCalender bfc { get; set; }

        public BookFlightTest(FindFlight f)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            DtStart = f.dtStart;             
            
            setBackgroundImage(f.CountryDestination);
            ff = f;            
            
            this.WindowState = FormWindowState.Maximized;
            
            // Admin Context Menu
            if (cm is null)
            {
                cm = new ContextMenu();
                MenuItem mnuItemNew = new MenuItem();
                mnuItemNew.Text = "Admin";
                cm.MenuItems.Add(mnuItemNew);
                this.ContextMenu = cm;
                mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
            }

            NumAdults = ff.intNumbAdults;
            NumChildren = ff.intNumbChildren;

            tlpanel = new TableLayoutPanel();

            GenerateTable(f.DtDepartureTime,8);            
        }

        private void RbSelectFlight_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radb = sender as RadioButton;
                strRBSelectFlightInt = radb.Name;
                FlightCustDetails.FlightNum = radb.Name;

                string ticketType = "";
                if (ff is null)
                {
                    ticketType = FlightCustDetails.FlightType;
                }
                else
                {
                    ticketType = ff.cmbTicketType;
                }               

                foreach (var item in iqFlights)
                {
                    if (item.FlightNum == radb.Name )                       
                        if (ticketType == "Business")
                        {
                            decimal busCost = item.Business * NumAdults;
                            FlightCustDetails.FlightCost = busCost.ToString();
                            break;
                        }
                        else if(ticketType == "Economy")
                        {
                            decimal ecoCost = item.Economy * NumAdults;
                            FlightCustDetails.FlightCost = ecoCost.ToString();
                            break;
                        }
                        else
                        {
                            decimal firstCost = item.First * NumAdults;
                            FlightCustDetails.FlightCost = firstCost.ToString();
                            break;
                        }                        
                }
            }
        }

        /// <summary>
        /// Admin Access
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    ad.MdiParent = this.MdiParent;
                    ad.FormClosed += new FormClosedEventHandler(ad_FormClosed);
                    ad.WindowState = FormWindowState.Maximized;
                    ad.Dock = DockStyle.Fill;
                    ad.Show();
                    
                }
                else
                { MessageBox.Show("Try again"); return; }
            }
        }             
        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
        }
               
        /// <summary>
        /// Form has a lot of controls and it has 
        /// a massive amount of flicker, on startup.
        /// the below is a fix
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        } 

        //https://softwaredevelopmentforecm.wordpress.com/2011/01/18/dynamically-generating-a-tablelayoutpanel/
        private void GenerateTable(DateTime dt, int columnCount)
        {
            // Main TableLayoutPanel which contains 2 rows - each row contains another TableLayoutPanel 
            TableLayoutPanel tbLtPnMain = new TableLayoutPanel();
            tbLtPnMain.RowCount = 2;          
            tbLtPnMain.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnMain.Width = 1000;
            tbLtPnMain.Height = 450;
            tbLtPnMain.Location = new Point(50, 70);
            //tbLtPnMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            
            //int xnumflights = NumberOfFlights(new DateTime(2022, 06, 25, 12, 00, 00));
            int xnumflights = NumberOfFlights(dt);            

            DateTime dtFindFlight = ff.dateTimePicker1.Value;
            DateTime dtReturnFlight = ff.dateTimePicker2.Value;
            string CountryNameDest = ff.CountryDestination.ToString();
            string AirportName = ff.AirportName.ToString();
            string TicketType = ff.cmbTicketType.ToString();            
            int numbAdults = NumAdults;
            int numChildren = NumChildren;

            iqFlights = GetFlightDetails(dtFindFlight, dtReturnFlight, CountryNameDest, AirportName);            
            int countFlights = iqFlights.Count;

            if(countFlights == 0)
            {
                FlightCustDetails.ClearFields();
                return;
            }
                      
            //Clear out the existing controls, we are generating a new table layout
            tlpanel.Controls.Clear();

            //Clear out the existing row and column styles
            tlpanel.ColumnStyles.Clear();
            tlpanel.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            tlpanel.ColumnCount = columnCount;
            tlpanel.RowCount = xnumflights;
            
            tlpanel.ColumnCount = columnCount;       
                     
            int rownum = 0; 
            foreach (var item in iqFlights)
            {
                //tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
               
                tlpanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));                
                tlpanel.Controls.Add(new Label() { Text = item.FlightNum.Trim(), ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft}, 0, rownum);
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));  
                if((numbAdults + numChildren)  > item.Seats)
                    tlpanel.Controls.Add(new Label() { Text = item.Seats.ToString().Trim(), ForeColor = Color.IndianRed, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 1, rownum);
                else
                    tlpanel.Controls.Add(new Label() { Text = item.Seats.ToString().Trim(), ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 1, rownum);
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
                tlpanel.Controls.Add(new Label() { Text = item.OutDateTime.Value.ToString().Substring(0,16)  , ForeColor = Color.White, Font = new Font("Comic Sans",10), TextAlign = ContentAlignment.MiddleLeft, Width = 150 }, 2, rownum);
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
                tlpanel.Controls.Add(new Label() { Text = item.InDateTime.Value.ToString().Substring(0, 16), ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft, Width = 150 }, 3, rownum);
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                tlpanel.Controls.Add(new Label() { Text = item.Airport.AirportName, ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 4, rownum);
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                tlpanel.Controls.Add(new Label() { Text = item.Destination.Country, ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 5, rownum);
                
                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // new
                if (TicketType == "Business")
                {
                    int BusCostAdults = (ff.intNumbAdults * Convert.ToInt32(item.Business));
                    //FlightCustDetails.FlightCost = BusCostAdults.ToString();
                    string BusCostText = "£" + BusCostAdults.ToString() + " (£" + item.Business.ToString() + ")";
                    tlpanel.Controls.Add(new Label() {Width=1000, Text = BusCostText, ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 6, rownum); // new
                }
                else if (TicketType == "First")
                {
                    int FirstCostAdults = (ff.intNumbAdults * Convert.ToInt32(item.First));
                    //FlightCustDetails.FlightCost = FirstCostAdults.ToString();
                    string FirstCostText = "£" + FirstCostAdults.ToString() + " (£" + item.First.ToString() + ")";
                    tlpanel.Controls.Add(new Label() { Width = 1000, Text = FirstCostText, ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 6, rownum); // new
                }
                else
                {
                    int EcoCostAdults = (ff.intNumbAdults * Convert.ToInt32(item.Economy));
                    //FlightCustDetails.FlightCost = EcoCostAdults.ToString();
                    string EcoCostText = "£" + EcoCostAdults.ToString() + " (£" + item.Economy.ToString() + ")";
                    tlpanel.Controls.Add(new Label() { Text = EcoCostText, ForeColor = Color.White, Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft }, 6, rownum); // new
                }

                tlpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));
                if ((numbAdults + numChildren) < item.Seats)
                    Rb = new RadioButton() {Name = item.FlightNum.Trim(), Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft };
                else
                    Rb = new RadioButton() { Enabled = false, Name = item.FlightNum.Trim(), Font = new Font("Comic Sans", 10), TextAlign = ContentAlignment.MiddleLeft };
                Rb.CheckedChanged += RbSelectFlight_CheckedChanged;
                if(flightExists && Rb.Name == FlightCustDetails.FlightNum)
                {
                    Rb.Checked = true;
                }
                //Rb.Name = item.FlightNum.Trim();                
                tlpanel.Controls.Add(Rb, 7, rownum);

                rownum++;
            }
                       
            //https://www.c-sharpcorner.com/uploadfile/mahesh/tablelayoutpanel-in-C-Sharp/?msclkid=df2e1efacf5811ecaaabe1b5252425d2
            TableLayoutPanel tlpHeadings = new TableLayoutPanel();
            //tlpHeadings.Location = new Point(100, 70);
            tlpHeadings.BorderStyle = BorderStyle.None;
            tlpHeadings.BackColor = Color.Transparent;    
            //tlpHeadings.ColumnStyles.
            tlpHeadings.ColumnCount = columnCount;
            tlpHeadings.RowCount = 1;
            tlpHeadings.Width = 1000;
            tlpHeadings.Height = 25;
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F)); // new
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));

            Label txtfltNumb = new Label();
            txtfltNumb.BackColor = Color.Transparent;
            txtfltNumb.BorderStyle = BorderStyle.None;
            txtfltNumb.ForeColor = Color.White;
            txtfltNumb.Text = "Flight Number";
            txtfltNumb.TextAlign = ContentAlignment.MiddleLeft;
            //txtfltNumb.Size = new Size(200, 30);
            txtfltNumb.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtfltNumb, 0, 0);

            Label txtSeatsAvaliable = new Label();
            txtSeatsAvaliable.BackColor = Color.Transparent;
            txtSeatsAvaliable.BorderStyle = BorderStyle.None;
            txtSeatsAvaliable.ForeColor = Color.White;
            txtSeatsAvaliable.Text = "Seats";
            txtSeatsAvaliable.TextAlign = ContentAlignment.MiddleLeft;
            //txtfltNumb.Size = new Size(200, 30);
            txtSeatsAvaliable.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtSeatsAvaliable, 1, 0);

            Label txtDeparture = new Label();
            txtDeparture.BackColor = Color.Transparent;
            txtDeparture.BorderStyle = BorderStyle.None;
            txtDeparture.ForeColor = Color.White;
            txtDeparture.Text = "Depart";
            txtDeparture.TextAlign = ContentAlignment.MiddleLeft; ;
            //txtDeparture.Size = new Size(200, 30);
            txtDeparture.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtDeparture, 2, 0);

            Label txtArrival = new Label();
            txtArrival.BackColor = Color.Transparent;
            txtArrival.BorderStyle = BorderStyle.None;
            txtArrival.ForeColor = Color.White;
            txtArrival.Text = "Return";
            txtArrival.TextAlign = ContentAlignment.MiddleLeft; 
            txtArrival.Size = new Size(200, 30);
            txtArrival.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtArrival, 3, 0);

            Label txtAirport = new Label();
            txtAirport.BackColor = Color.Transparent;
            txtAirport.BorderStyle = BorderStyle.None;
            txtAirport.ForeColor = Color.White;
            txtAirport.Text = "Airport";
            txtAirport.TextAlign = ContentAlignment.MiddleLeft; ;
            //txtAirport.Size = new Size(200, 30);
            txtAirport.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtAirport, 4, 0);

            Label txtDestination = new Label();
            txtDestination.BackColor = Color.Transparent; 
            txtDestination.BorderStyle = BorderStyle.None;
            txtDestination.ForeColor = Color.White;
            txtDestination.Text = "Destination";
            txtDestination.TextAlign = ContentAlignment.MiddleLeft; ;
            //txtDestination.Size = new Size(200, 30);
            txtDestination.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txtDestination, 5, 0);

            Label txttCost = new Label();
            txttCost.BackColor = Color.Transparent;
            txttCost.BorderStyle = BorderStyle.None;
            txttCost.ForeColor = Color.White;
            txttCost.Text = TicketType;
            txttCost.TextAlign = ContentAlignment.MiddleLeft; ;
            //txttCost.Size = new Size(900, 50);
            txttCost.Font = new Font("Comic Sans", 13);
            tlpHeadings.Controls.Add(txttCost, 6, 0);            

            tlpanel.VerticalScroll.Enabled = true;
            tlpanel.AutoScroll = true;  
            tlpanel.BackColor = Color.Transparent;
            
            tlpanel.Width = 950;
            tlpanel.Height = 400;
            //tlpanel.Location = new Point(100, 100);

            tbLtPnMain.Controls.Add(tlpHeadings);
            tbLtPnMain.Controls.Add(tlpanel);
        
            this.Controls.Add(tbLtPnMain);         
        }       
        public List<AirlineReservationDAL.Flight> GetFlightDetails(DateTime fldt, DateTime flrtdt, string countryDest, string airportName )
        {
            ft = ar.GetTable<AirlineReservationDAL.Flight>();
            /*
            var qry = from b in ft
                          //where DateTime.Compare(b.OutDateTime.Value, fldt) >= 0//where b.OutDateTime == fldt
                      where b.InDateTime >= fldt
                      select new { b.FlightNum, b.AircraftNumb.AircraftType, b.Business, b.First, b.Economy, b.Airport.AirportName, b.Destination.Country, b.OutDateTime, b.InDateTime };
            */
            IQFlight = from f in ft
                       where f.OutDateTime >= fldt
                       & f.InDateTime <= flrtdt
                       & f.Destination.Country == countryDest
                       & f.Airport.AirportName == airportName
                       & f.Seats > 0
                       select f;

            List<AirlineReservationDAL.Flight> flights = IQFlight.ToList();

            if (!string.IsNullOrEmpty(FlightCustDetails.FlightNum))            
            {                
                foreach(AirlineReservationDAL.Flight flight in flights)
                {
                    if(flight.FlightNum == FlightCustDetails.FlightNum)
                    {
                        flightExists = true;
                        break;
                    }
                    else
                    {
                        flightExists = false;                        
                    }
                }
            }
            else
            {
                flightExists = false;
            }           

            return flights;
        }

        // number of flights equal to or greater than passed in date
        public int NumberOfFlights(DateTime dt)
        {
            return ar.GetTable<AirlineReservationDAL.Flight>().Count(x => x.OutDateTime >= dt );
        }             
       
        /// <summary>
        /// FYI
        /// </summary>
        /// <param name="CntryDest"></param>
        private void setBackgroundImage(string CntryDest)
        {
            /*
             * // This works using images as embedded resources - please leave
            switch (CntryDest)
            {
                case "Cyprus":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.cyprus);
                    break;
                case "France":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.france);
                    break;
                case "Hungary":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.hungary);
                    break;
                case "Italy":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.italy);
                    break;
                case "Spain":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.spain);
                    break;
                case "Portugal":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.portugal);
                    break;
                case "Russia":
                    this.BackgroundImage = (Image)(AirLineReservationSystem.Properties.Resources.Russia);
                    break;
                default:
                    this.BackgroundImage = null;
                    break;
            }
            */

            string filename = "";

            string dir = Path.GetDirectoryName(Application.ExecutablePath);           

            filename = Path.Combine("../../Resources/", CntryDest + ".jpg");
            this.BackgroundImage = Image.FromFile(filename);
        }
        private void FindFlight_Load(object sender, EventArgs e)
        {
            // Remove the control box so the form will only display client area i.e. Create a Borderless Window
            this.ControlBox = false;           
        }
        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {
            strRBSelectFlightInt = "";
            ar.Connection.Close();
            this.Close();
        }
        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {           
            // open new form
            if (!String.IsNullOrEmpty(strRBSelectFlightInt))
            {
                pd = new Passenger_Details(this);
                pd.MdiParent = this.ParentForm;
                pd.FormClosed += new FormClosedEventHandler(pd_FormClosed);
                this.Dock = DockStyle.Fill;                

                foreach (var item in iqFlights)
                {
                    if(item.FlightNum == FlightCustDetails.FlightNum)
                    {
                        FlightCustDetails.FlightOut = item.OutDateTime.ToString();
                        FlightCustDetails.FlightIn = item.InDateTime.ToString();
                    }
                } 

                pd.Show();
            }
        }
        void pd_FormClosed(object sender, FormClosedEventArgs e)
        {
            rf = null;
            ff = null;
            pd = null;
            ad = null;
            cm = null;
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
               
    }
}