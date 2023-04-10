using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using AirlineReservationDAL;
using System.IO;
using IronPdf;
using System.Drawing.Printing;
using System.Data.Linq;

namespace AirLineReservationSystem
{
    /// <summary>
    /// https://www.c-sharpcorner.com/UploadFile/f4f047/generating-pdf-file-using-C-Sharp/
    /// </summary>
    public partial class Confirmation : Form
    {

        AirlineReservationDAL.AirlineReservation ar;
        Table<AirlineReservationDAL.Booking> bk;
        Form1 f;
        Administration ad;
        ContextMenu cm;
        public string _name { get; set; }
        public int _maxHeight { get; set; }
        public string _pdfpw { get; set; }
        public Confirmation()
        {
            InitializeComponent(); 
        }
        public Confirmation(ReserveFlight rf)
        {
            InitializeComponent();

            //lblConfirmFlight.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent

            if (ar is null)
                ar = new AirlineReservationDAL.AirlineReservation();
            if (bk is null)
                bk = ar.GetTable<AirlineReservationDAL.Booking>();            

            if (cm is null)
            {
                cm = new ContextMenu();
                MenuItem mnuItemNew = new MenuItem();
                mnuItemNew.Text = "Admin";
                cm.MenuItems.Add(mnuItemNew);
                this.ContextMenu = cm;
                mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
            }

            GenerateTable();

            CheckReservationNum();
        }   
        public void CheckReservationNum()
        {
            if (!string.IsNullOrEmpty(FlightCustDetails.ReservationNum))
            {
                lblReservationNum.Text = $"{ FlightCustDetails.ReservationNum} (Click To Print)";
                lblReservationNum.Click += LblReservationNum_Click;
                lblBookFlightBack.Enabled = false;
                lblConfirmFlight.Text = "CLICK FOR A NEW BOOKING";

                AddFlightDetails();                    
            }
        }

        /// <summary>
        /// Add and commit Flight information on Confirmation form
        /// to Database tables - Booking, Payment and Customer
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void AddFlightDetails()
        {            

            // Get Booking table
            Table<AirlineReservationDAL.Booking> bk = ar.GetTable<AirlineReservationDAL.Booking>();
            // Get Booking table data
            var qry = from b in bk select b;
            // Check Reservation number doesnt already exist
            bool ResvnNumExists = qry.Any(b => b.ReservationNum == FlightCustDetails.ReservationNum.Trim());
            // If Reservation number already exists exit out of method
            if (ResvnNumExists)
            {
                MessageBox.Show("Reservation Number " + FlightCustDetails.ReservationNum.Trim() + " already exists\n\nPlease try again ", "Duplicate Reservation Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            // Add Payment details to Payment table
            AirlineReservationDAL.Payment pym = new AirlineReservationDAL.Payment
            {
                CardNumber = FlightCustDetails.CardDetails[1] + FlightCustDetails.CardDetails[2] + FlightCustDetails.CardDetails[3] + FlightCustDetails.CardDetails[4],
                NameOnCard = FlightCustDetails.CardDetails[0],
                CSV = Convert.ToInt32(FlightCustDetails.CardDetails[6]),
                Expiry = Convert.ToDateTime(FlightCustDetails.CardDetails[5]),
                Amount = Convert.ToDecimal(FlightCustDetails.FlightCost)
            };
            try
            {
                ar.Payment.InsertOnSubmit(pym);
                ar.SubmitChanges();
                //MessageBox.Show("New Payment added: ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                throw;
            }            

            // Set Reservation number for Booking table
            AirlineReservationDAL.Booking bking = new AirlineReservationDAL.Booking
            {
                ReservationNum = FlightCustDetails.ReservationNum.Trim(),
            };

            try
            {
                ar.Booking.InsertOnSubmit(bking);
                //ar.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            AirlineReservationDAL.Flight selectedFlight = ar.Flight.Single(f => f.FlightNum == FlightCustDetails.FlightNum);
            selectedFlight.Bookings.Add(bking);

            AirlineReservationDAL.Payment selectedPayment = ar.Payment.Single(p => p.PaymentID == pym.PaymentID);
            selectedPayment.Bookings.Add(bking);
                        
            try
            {                
                ar.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            // Set Adults for Customer table
            List<AirlineReservationDAL.Customer> customersA = new List<AirlineReservationDAL.Customer>();
            AirlineReservationDAL.Customer cstA;
            foreach (var item in FlightCustDetails.Adults)
            {
                customersA.Add(
                cstA = new AirlineReservationDAL.Customer
                {
                    CustFirstName = item.Substring(0, item.IndexOf(' ') - 0).Trim(),
                    CustLastName = item.Substring(item.IndexOf(' '), item.LastIndexOf(' ') - item.IndexOf(' ')).Trim(),
                    Gender = item.Substring(item.LastIndexOf(' ') + 1),
                    CustType = "A"
                });
            }

            // Set Children for Customer table
            List<AirlineReservationDAL.Customer> customersC = new List<AirlineReservationDAL.Customer>();
            AirlineReservationDAL.Customer cstC;
            foreach (var item in FlightCustDetails.Children)
            {
                customersC.Add(
                cstC = new AirlineReservationDAL.Customer
                {
                    CustFirstName = item.Substring(0, item.IndexOf(' ') - 0).Trim(),
                    CustLastName = item.Substring(item.IndexOf(' '), item.LastIndexOf(' ') - item.IndexOf(' ')).Trim(),
                    Gender = item.Substring(item.LastIndexOf(' ') + 1),
                    CustType = "C"
                });
            }    

            try
            {
                AirlineReservationDAL.Booking selectedBooking = ar.Booking.Single(b => b.ReservationNum == FlightCustDetails.ReservationNum);
                                
                foreach (var itemA in customersA)
                {
                    ar.Customer.InsertOnSubmit(itemA);
                    selectedBooking.Customers.Add(itemA);
                }

                foreach (var itemC in customersC)
                {
                    ar.Customer.InsertOnSubmit(itemC);
                    selectedBooking.Customers.Add(itemC);
                }   
                ar.SubmitChanges();                

                MessageBox.Show("Your Booking has been succesfull.\n\nYour reservation number is: " + FlightCustDetails.ReservationNum,"Booking Confirmed" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());                
            }   

        } 
        private void LblReservationNum_Click(object sender, EventArgs e)
        {
            PrintPDFFlightDetails();
        }
       
        private void PrintPDFFlightDetails()
        {
            DialogResult dresult = MessageBox.Show("Print PDF Reservation Details", "", MessageBoxButtons.YesNo);
            if (dresult == DialogResult.Yes)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult dr = fbd.ShowDialog();
                string selectedPath = "";

                _name = $"{FlightCustDetails.ReservationNum}.pdf";

                if (dr == DialogResult.OK)
                {
                    selectedPath = fbd.SelectedPath;
                }
                else return;

                while (string.IsNullOrEmpty(selectedPath))
                {                    
                    DialogResult contYN = MessageBox.Show("Do you want to Print your Reservation Details?", "", MessageBoxButtons.YesNo);

                    if (contYN == DialogResult.OK)
                    {
                        selectedPath = fbd.SelectedPath;
                    }
                    else return;

                    
                }



                _maxHeight = 100;
                _pdfpw = "sharable";

                string expiryDate2 = FlightCustDetails.CardDetails[5].Substring(8, 2);
                string expiryDate1 = FlightCustDetails.CardDetails[5].Substring(3, 3);

                string htmlAdults = "";
                string htmlChildren = "";
                int index = 0;
                StringBuilder sb;
                foreach (var item in FlightCustDetails.Adults)
                {
                    index = item.LastIndexOf(' ');
                    sb = new StringBuilder(item);
                    sb[index] = '(';
                    sb.Insert(index, ' ');
                    htmlAdults = htmlAdults.ToUpper() + @"<h4>" + sb.ToString().ToUpper() +@")</h4> </br>";
                }

                foreach (var item in FlightCustDetails.Children)
                {                   
                    index = item.LastIndexOf(' ');
                    sb = new StringBuilder(item);
                    sb[index] = '(';
                    sb.Insert(index, ' ');
                    htmlChildren = htmlChildren.ToUpper() + @"<h4>" + sb.ToString().ToUpper() + @")</h4> </br>";
                }

                Object rm = Properties.Resources.ResourceManager.GetObject("book.bmp");
                Bitmap myImage = (Bitmap)rm;
                Image image = myImage;

                imagePath = System.IO.Path.GetFullPath(@"..\..\Resources\") + @"Reservation.JPG";
                               
                var html = @"
                <html>
                <head>  
                    <style>
                        .simple-shadow{text-shadow: 1px 2px 2px red;}  ;
                        .p3 {font-family: 'Lucida Handwriting';}
                    </style> 
                </head>
                <body>               
                  <img src = """ + imagePath + @"""></img>
                </p>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Reservation No:</font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.ReservationNum.ToUpper() + @"</font></h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Number: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightNum.ToUpper() + @" </h3></br>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Country: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightCountry.ToUpper() + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Airport: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightAirport.ToUpper() + @" </h3></br>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Type: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightType.ToUpper() + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Cost: </font> <font style=""font-family:lucida handwriting;""> £" + FlightCustDetails.FlightCost + @" </h3></br></br>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Departure: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightOut + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Flight Return: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.FlightIn + @" </h3></br></br>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Name on Card: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.CardDetails[0].ToUpper() + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Card No: </font> <font style=""font-family:lucida handwriting;""> xxxx xxxx xxxx " + FlightCustDetails.CardDetails[3] + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">Expiry: </font> <font style=""font-family:lucida handwriting;""> " + expiryDate1 + expiryDate2 + @" </h3>
                <h3> <font style=""text-shadow: 1px 2px 2px gray"">CSV: </font> <font style=""font-family:lucida handwriting;""> " + FlightCustDetails.CardDetails[6] + @" </h3>
                <div style = 'page-break-after: always;' ></div>
                <h3><font style=""text-shadow: 1px 2px 2px gray""> Adults</font></h3> <font style=""font-family:lucida handwriting;""> " + htmlAdults + @"</font> 
                <h3><font style=""text-shadow: 1px 2px 2px gray""> Children</font> </h3><font style=""font-family:lucida handwriting;""> " + htmlChildren + @"</font> 
                </body> 
                </html>";            

                // Instantiate Renderer
                var Renderer = new IronPdf.ChromePdfRenderer();
                //var cover = Renderer.RenderHtmlAsPdf($"<h1> {_name} </h1>");

                //As we have a Cover Page, we're going to start the page numbers at 2.
                Renderer.RenderingOptions.FirstPageNumber = 1;

                Renderer.RenderingOptions.HtmlFooter = new IronPdf.HtmlHeaderFooter()
                {

                    MaxHeight = _maxHeight, //millimeters
                    HtmlFragment = "<center><i>{page} of {total-pages}<i></center>",
                    DrawDividerLine = true
                };

                PdfDocument Pdf = Renderer.RenderHtmlAsPdf(html);                

                _name = selectedPath + "\\" + _name;

                Pdf.SaveAs(_name);               

            }
        }
              
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
        public string imagePath { get; private set; }

        /// <summary>
        /// Log in to Admin area
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

                    //ad.Tag="FMF_Tag";
                    //Control c = (Control)"FMF_Tag"; 
                    //ad.Controls.Remove(labelToRemove);
                    ////ad = new Admin.AdminMainForm();

                    ad.MdiParent = this.MdiParent;
                    ad.FormClosed += new FormClosedEventHandler(ad_FormClosed);
                    ad.WindowState = FormWindowState.Maximized;
                    ad.Dock = DockStyle.Fill;
                    ad.Show();

                    
                }
                else
                { MessageBox.Show("The login details were not correct"); return; }
            }
        }
        public void CreateMyBorderlessWindow()
        {
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }
        private void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
            f = null;
            cm = null;
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
        private void Confirmation_Load(object sender, EventArgs e)
        {
            CreateMyBorderlessWindow();
        }

        /// <summary>
        /// Check and Authorize Credit card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            if (lblConfirmFlight.Text == "CLICK FOR A NEW BOOKING")
            {
                // Loop through all MDI forms and close them
                // Except the Default/Start/Form1
                foreach (Form frm in ParentForm.MdiChildren)
                {
                    string mdiName = frm.Name;
                    if(mdiName != "Form1")
                    { 
                        frm.Close();                        
                    }
                    
                }

                FlightCustDetails.ClearFields();

                this.Close();
            }
            else if (!string.IsNullOrEmpty(FlightCustDetails.ReservationNum))
            {
                MessageBox.Show("Your Credit Card has already been authorised",FlightCustDetails.FlightNum);
                               
                return;
            }
            else
            {
                Form auth = new Authorizing();
                auth.ShowDialog();

                CheckReservationNum();
            }

            

        }

        /// <summary>
        /// Create and populate controls 
        /// on Confirmation form
        /// </summary>
        private void GenerateTable()
        {
            // Main TableLayoutPanel which contains 2 columns - each row contains another TableLayoutPanel 
            // Main TableLayoutPanel which contains 2 rows - each row contains another TableLayoutPanel 
            TableLayoutPanel tbLtPnMain = new TableLayoutPanel();
            tbLtPnMain.ColumnCount = 3;
            tbLtPnMain.RowCount = 3;
            //tbLtPnMain.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tbLtPnMain.RowStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tbLtPnMain.RowStyles.Add(new ColumnStyle(SizeType.Percent, 96F));
            tbLtPnMain.RowStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tbLtPnMain.Width = 915;
            tbLtPnMain.Height = 490;
            tbLtPnMain.Location = new Point(55, 65);
            //tbLtPnMain.BackColor = Color.Red;
            //tbLtPnMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            //
            TableLayoutPanel tbLtPnFlightDetails = new TableLayoutPanel();
            tbLtPnFlightDetails.VerticalScroll.Enabled = true;
            tbLtPnFlightDetails.HorizontalScroll.Enabled = true;
            tbLtPnFlightDetails.AutoScroll = true;
            //tbLtPnFlightDetails.Anchor = AnchorStyles.None;
            tbLtPnFlightDetails.RowCount = 22;
            tbLtPnFlightDetails.ColumnCount = 3;
            tbLtPnFlightDetails.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnFlightDetails.Width = 325;
            tbLtPnFlightDetails.Height = 600;           
            //tbLtPnFlightDetails.Location = new Point(-10, 0);

            TableLayoutPanel tbLtPnPassengers = new TableLayoutPanel();
            tbLtPnPassengers.VerticalScroll.Enabled = true;
            tbLtPnPassengers.HorizontalScroll.Enabled = true;
            tbLtPnPassengers.AutoScroll = true;
            tbLtPnPassengers.Anchor = AnchorStyles.None;
            tbLtPnPassengers.ColumnCount = 2;
            tbLtPnPassengers.RowCount = ((FlightCustDetails.Adults.Count + FlightCustDetails.Children.Count));//+ 1;
            tbLtPnPassengers.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnPassengers.Width = 325;
            tbLtPnPassengers.Height = 600;
            //tbLtPnPassengers.Location = new Point(50, 70);
            //tbLtPnPassengers.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            tbLtPnPassengers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            tbLtPnPassengers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));

            List<string> AdultChild = new List<string>();
            AdultChild.AddRange(FlightCustDetails.Adults);
            AdultChild.AddRange(FlightCustDetails.Children);
            //AdultChild.Add("");

            int labelCnt = 1;   
            // Adds 3 rows for each Adult and Child entry
            for (int i = 0; i < tbLtPnPassengers.RowCount ; i++)
            {
                tbLtPnPassengers.RowStyles.Add(new RowStyle( SizeType.Absolute, 15f));
                tbLtPnPassengers.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
                tbLtPnPassengers.RowStyles.Add(new RowStyle(SizeType.Absolute, 55f));
                
                Label lblPassengerName = new Label();
                lblPassengerName.BackColor = Color.Transparent;// Transparent
                lblPassengerName.Text = "Name";
                lblPassengerName.Size = new Size(150, 31);
                lblPassengerName.Font = new Font("Arial", 13);
                lblPassengerName.ForeColor = System.Drawing.Color.White;

                Label lblPassengerGender = new Label();
                lblPassengerGender.BackColor = Color.Transparent;// Transparent
                lblPassengerGender.Text = "Gender";
                lblPassengerGender.Size = new Size(150, 31);
                lblPassengerGender.Font = new Font("Arial", 13);
                lblPassengerGender.ForeColor = System.Drawing.Color.White;                

                TextBox txbxPassengerGender = new TextBox();
                // get pos of 2nd space in string i.e. start of gender string
                int pos= AdultChild[i].Split(' ').Take(2).Sum(a => a.Length + 1) - 1;
                txbxPassengerGender.Text =  AdultChild[i].Substring(pos);
                txbxPassengerGender.Enabled = false;
                txbxPassengerGender.MaxLength = 26;
                txbxPassengerGender.Multiline = true;
                txbxPassengerGender.Size = new Size(150, 31);
                txbxPassengerGender.Font = new Font("Arial", 13);

                TextBox txbxPassengerName = new TextBox();
                txbxPassengerName.Text = AdultChild[i].Substring(0,pos);
                txbxPassengerName.Enabled = false;
                txbxPassengerName.MaxLength = 26;
                txbxPassengerName.Multiline = true;
                txbxPassengerName.Size = new Size(150, 31);
                txbxPassengerName.Font = new Font("Arial", 13);


                //int pos = AdultChild[i].Split(' ').Take(2).Sum(a => a.Length + 1) - 1;

                tbLtPnPassengers.Controls.Add(lblPassengerName, 0, labelCnt);
                tbLtPnPassengers.Controls.Add(txbxPassengerName, 0, labelCnt + 1);
                tbLtPnPassengers.Controls.Add(lblPassengerGender, 1, labelCnt);
                tbLtPnPassengers.Controls.Add(txbxPassengerGender, 1, labelCnt + 1);

                labelCnt = labelCnt + 3;           

            }

            AdultChild.Clear();

            TableLayoutPanel tbLtPnPayment = new TableLayoutPanel();
            tbLtPnPayment.Anchor = AnchorStyles.None;
            tbLtPnPayment.RowCount = 7;
            tbLtPnPayment.ColumnCount = 3;
            tbLtPnPayment.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnPayment.Width = 325;
            tbLtPnPayment.Height = 600;
            //tbLtPnPayment.Location = new Point(125, 70);
            //tbLtPnPayment.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            //tbLtPnPayment.BackColor = Color.Red;

            tbLtPnPayment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5f));
            tbLtPnPayment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85f));
            tbLtPnPayment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));

            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnPayment.RowStyles.Add(new RowStyle(SizeType.Percent, 26f));

            tbLtPnFlightDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
            tbLtPnFlightDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90));
            tbLtPnFlightDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));

            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 2f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
            tbLtPnFlightDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));       

            Label FlightNoLbl = new Label();
            FlightNoLbl.BackColor = Color.Transparent;// Transparent
            FlightNoLbl.Text = "FlightNo";
            FlightNoLbl.Size = new Size(150, 31);
            FlightNoLbl.Font = new Font("Arial", 13);
            FlightNoLbl.ForeColor = System.Drawing.Color.White;

            Label AirportLbl = new Label();
            AirportLbl.BackColor = Color.Transparent;// Transparent
            AirportLbl.Text = "Airport";
            AirportLbl.Size = new Size(150, 31);
            AirportLbl.Font = new Font("Arial", 13);
            AirportLbl.ForeColor = System.Drawing.Color.White;

            Label CountrtyLbl = new Label();
            CountrtyLbl.BackColor = Color.Transparent;// Transparent
            CountrtyLbl.Text = "Country";
            CountrtyLbl.Size = new Size(150, 31);
            CountrtyLbl.Font = new Font("Arial", 13);
            CountrtyLbl.ForeColor = System.Drawing.Color.White;

            Label FlightTYpeLbl = new Label();
            FlightTYpeLbl.BackColor = Color.Transparent;// Transparent
            FlightTYpeLbl.Text = "FlightType";
            FlightTYpeLbl.Size = new Size(150, 31);
            FlightTYpeLbl.Font = new Font("Arial", 13);
            FlightTYpeLbl.ForeColor = System.Drawing.Color.White;

            Label FlightCostLbl = new Label();
            FlightCostLbl.BackColor = Color.Transparent;// Transparent
            FlightCostLbl.Text = "FlightCost";
            FlightCostLbl.Size = new Size(150, 31);
            FlightCostLbl.Font = new Font("Arial", 13);
            FlightCostLbl.ForeColor = System.Drawing.Color.White;

            Label FlightINLbl = new Label();
            FlightINLbl.BackColor = Color.Transparent;// Transparent
            FlightINLbl.Text = "Flight Return";
            FlightINLbl.Size = new Size(150, 31);
            FlightINLbl.Font = new Font("Arial", 13);
            FlightINLbl.ForeColor = System.Drawing.Color.White;

            Label FlightOUTLbl = new Label();
            FlightOUTLbl.BackColor = Color.Transparent;// Transparent
            FlightOUTLbl.Text = "Flight Departure";
            FlightOUTLbl.Size = new Size(150, 31);
            FlightOUTLbl.Font = new Font("Arial", 13);
            FlightOUTLbl.ForeColor = System.Drawing.Color.White;

            TextBox FlightNumTxbx = new TextBox();
            FlightNumTxbx.Enabled = false;
            FlightNumTxbx.MaxLength = 26;
            FlightNumTxbx.Multiline = true;
            FlightNumTxbx.Size = new Size(300, 27);
            FlightNumTxbx.Font = new Font("Arial", 13);

            TextBox AirportTxbx = new TextBox();
            AirportTxbx.Enabled = false;
            AirportTxbx.MaxLength = 26;
            AirportTxbx.Multiline = true;
            AirportTxbx.Size = new Size(300, 27);
            AirportTxbx.Font = new Font("Arial", 13);

            TextBox CountryTxbx = new TextBox();
            CountryTxbx.Enabled = false;
            CountryTxbx.MaxLength = 26;
            CountryTxbx.Multiline = true;
            CountryTxbx.Size = new Size(300, 27);
            CountryTxbx.Font = new Font("Arial", 13);

            TextBox FlightTYpeTxbx = new TextBox();
            FlightTYpeTxbx.Enabled = false;
            FlightTYpeTxbx.MaxLength = 26;
            FlightTYpeTxbx.Multiline = true;
            FlightTYpeTxbx.Size = new Size(300, 27);
            FlightTYpeTxbx.Font = new Font("Arial", 13);

            TextBox FlightCostTxbx = new TextBox();
            FlightCostTxbx.Enabled = false;
            FlightCostTxbx.MaxLength = 26;
            FlightCostTxbx.Multiline = true;
            FlightCostTxbx.Size = new Size(300, 27);
            FlightCostTxbx.Font = new Font("Arial", 13);

            TextBox FlightINTxbx = new TextBox();
            FlightINTxbx.Enabled = false;
            FlightINTxbx.MaxLength = 26;
            FlightINTxbx.Multiline = true;
            FlightINTxbx.Size = new Size(300, 27);
            FlightINTxbx.Font = new Font("Arial", 13);

            TextBox FlightOUTTxbx = new TextBox();
            FlightOUTTxbx.Enabled = false;
            FlightOUTTxbx.MaxLength = 26;
            FlightOUTTxbx.Multiline = true;
            FlightOUTTxbx.Size = new Size(300, 27);
            FlightOUTTxbx.Font = new Font("Arial", 13);
            
            FlightNumTxbx.Text = FlightCustDetails.FlightNum;
            AirportTxbx.Text = FlightCustDetails.FlightAirport;
            CountryTxbx.Text = FlightCustDetails.FlightCountry;
            FlightTYpeTxbx.Text = FlightCustDetails.FlightType;
            FlightCostTxbx.Text = "£" + FlightCustDetails.FlightCost;
            FlightINTxbx.Text = FlightCustDetails.FlightIn;
            FlightOUTTxbx.Text = FlightCustDetails.FlightOut;

            TableLayoutPanel csvexpiry = new TableLayoutPanel();
            csvexpiry.BackColor = Color.Transparent;// Transparent
            csvexpiry.Width = 150;
            csvexpiry.Height = 100;
            csvexpiry.ColumnCount = 2;
            csvexpiry.RowCount = 2;

            TableLayoutPanel labelRows = new TableLayoutPanel();
            labelRows.BackColor = Color.Transparent;// Transparent
            labelRows.Width = 150;
            labelRows.Height = 100;
            labelRows.ColumnCount = 2;
            labelRows.RowCount = 1;

            Label NameOnCard = new Label();
            NameOnCard.BackColor = Color.Transparent;// Transparent
            NameOnCard.Text = "Name on Card";
            NameOnCard.Size = new Size(175, 31);
            NameOnCard.Font = new Font("Arial", 13);
            NameOnCard.ForeColor = System.Drawing.Color.White;

            Label l = new Label();
            l.BackColor = Color.Transparent;// Transparent
            l.Text = "CSV";
            l.Size = new Size(75, 31);
            l.Font = new Font("Arial", 13);
            l.ForeColor = System.Drawing.Color.White;

            Label exp = new Label();
            exp.BackColor = Color.Transparent;// Transparent
            exp.Text = "Expiry";
            exp.Size = new Size(75, 31);
            exp.Font = new Font("Arial", 13);
            exp.ForeColor = System.Drawing.Color.White;

            Label CardNum = new Label();
            CardNum.BackColor = Color.Transparent;// Transparent
            CardNum.Text = "Card Number";
            CardNum.Size = new Size(175, 31);
            CardNum.Font = new Font("Arial", 13);
            CardNum.ForeColor = System.Drawing.Color.White;

            TextBox nameOnCard = new TextBox();
            nameOnCard.Enabled = false;
            nameOnCard.MaxLength = 26;           
            nameOnCard.Multiline = true;
            nameOnCard.Size = new Size(300, 27);
            nameOnCard.Font = new Font("Arial", 13);

            TableLayoutPanel cardNumberTP = new TableLayoutPanel();
            cardNumberTP.Width = 225;
            cardNumberTP.Height = 27;
            
            //cardNumberTP.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            //cardNumberTP.BackColor = Color.Red;

            TextBox cardNumber1 = new TextBox();    
            cardNumber1.Enabled = false;
            cardNumber1.Font = new Font("Arial", 13);
            cardNumber1.Multiline = true;
            cardNumber1.Size = new Size(50, 27);
            cardNumber1.MaxLength = 4;
            TextBox cardNumber2 = new TextBox();
            cardNumber2.Enabled = false;
            cardNumber2.Font = new Font("Arial", 13);
            cardNumber2.Multiline = true;
            cardNumber2.Size = new Size(50, 27);
            cardNumber2.MaxLength = 4;
            TextBox cardNumber3 = new TextBox();
            cardNumber3.Enabled = false;
            cardNumber3.Font = new Font("Arial", 13);
            cardNumber3.Multiline = true;
            cardNumber3.Size = new Size(50, 27);
            cardNumber3.MaxLength = 4;
            TextBox cardNumber4 = new TextBox();
            cardNumber4.Enabled = false;
            cardNumber4.Font = new Font("Arial", 13);
            cardNumber4.Multiline = true;
            cardNumber4.Size = new Size(50, 27);
            cardNumber4.MaxLength = 4;

            cardNumber1.Text = FlightCustDetails.CardDetails[1];
            cardNumber2.Text = FlightCustDetails.CardDetails[2];
            cardNumber3.Text = FlightCustDetails.CardDetails[3];
            cardNumber4.Text = FlightCustDetails.CardDetails[4];

            cardNumberTP.Controls.Add(cardNumber1, 0, 0);
            cardNumberTP.Controls.Add(cardNumber2, 1, 0);
            cardNumberTP.Controls.Add(cardNumber3, 2, 0);
            cardNumberTP.Controls.Add(cardNumber4, 3, 0);

            //tbLtPnPayment.Controls.Add(cardNumberTP,0,2);    

            nameOnCard.Text = FlightCustDetails.CardDetails[0];

            //tbLtPnPayment.Controls.Add(nameOnCard, 0, 1);

            TextBox csv = new TextBox();
            csv.Enabled = false;
            csv.MaxLength = 3;
            csv.Size = new Size(75, 27);
            csv.Multiline = true;
            csv.Font = new Font("Arial", 13);

            csv.Text = FlightCustDetails.CardDetails[6];

            //tbLtPnPayment.Controls.Add(csv, 1, 3);

            DateTimePicker expiry = new DateTimePicker();
            expiry.Enabled = false;
            expiry.Size = new Size(75, 50);
            //expiry.ShowUpDown = true;
            expiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            expiry.CustomFormat = "MM/yy";
            expiry.Font = new Font("Arial", 13);

            ((DateTimePicker)expiry).Value = Convert.ToDateTime(FlightCustDetails.CardDetails[5]);
            //expiry.Text = FlightCustDetails.CardDetails[5];

            csvexpiry.Controls.Add(expiry, 0, 0);
            csvexpiry.Controls.Add(csv, 1, 0);
            labelRows.Controls.Add(l, 1, 0);
            labelRows.Controls.Add(exp, 0, 0);


            tbLtPnFlightDetails.Controls.Add(FlightNoLbl, 1, 1);
            tbLtPnFlightDetails.Controls.Add(FlightNumTxbx, 1, 2);
            tbLtPnFlightDetails.Controls.Add(CountrtyLbl, 1, 4);
            tbLtPnFlightDetails.Controls.Add(CountryTxbx, 1, 5);
            tbLtPnFlightDetails.Controls.Add(AirportLbl, 1, 7);
            tbLtPnFlightDetails.Controls.Add(AirportTxbx, 1, 8);
            tbLtPnFlightDetails.Controls.Add(FlightTYpeLbl, 1, 10);
            tbLtPnFlightDetails.Controls.Add(FlightTYpeTxbx, 1, 11);
            tbLtPnFlightDetails.Controls.Add(FlightCostLbl, 1, 13);
            tbLtPnFlightDetails.Controls.Add(FlightCostTxbx, 1, 14);
            tbLtPnFlightDetails.Controls.Add(FlightOUTLbl, 1, 16);
            tbLtPnFlightDetails.Controls.Add(FlightOUTTxbx, 1, 17);
            tbLtPnFlightDetails.Controls.Add(FlightINLbl, 1, 19);
            tbLtPnFlightDetails.Controls.Add(FlightINTxbx, 1, 20);

            tbLtPnPayment.Controls.Add(NameOnCard, 1, 1);
            tbLtPnPayment.Controls.Add(nameOnCard, 1, 2);
            tbLtPnPayment.Controls.Add(CardNum, 1, 3);
            tbLtPnPayment.Controls.Add(cardNumberTP, 1, 4);
            tbLtPnPayment.Controls.Add(labelRows, 1, 5);
            tbLtPnPayment.Controls.Add(csvexpiry, 1, 6);

            //this.Controls.Add(tbLtPnPassengers);
            //this.Controls.Add(tbLtPnPayment);
            tbLtPnMain.Controls.Add(tbLtPnFlightDetails, 0, 1);
            tbLtPnMain.Controls.Add(tbLtPnPassengers, 1, 1);
            tbLtPnMain.Controls.Add(tbLtPnPayment, 2, 1);
            tbLtPnMain.BackColor = Color.Transparent;
            this.Controls.Add(tbLtPnMain);


        }

        
    }
}
