using System;
using System.Windows.Forms;
using System.Configuration;
using AirlineReservationDAL;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AirLineReservationSystem
{
    public partial class ReserveFlight : Form
    {
        AirlineReservationDAL.AirlineReservation ar;        
        Form1 f;
        Administration ad;
        ContextMenu cm;

        public Confirmation _confirm { get; set; }
        public static List<TextBox> AddressTextBoxDetails { get; set; }
        public static List<object> CardTextBoxDetails { get; set; }
        public ReserveFlight(Passenger_Details p)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            
            if (cm is null)
            {
                cm = new ContextMenu();
                MenuItem mnuItemNew = new MenuItem();
                mnuItemNew.Text = "Admin";
                cm.MenuItems.Add(mnuItemNew);
                this.ContextMenu = cm;
                mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
            }

            //if(AddressTextBoxDetails is null)   
            AddressTextBoxDetails = new List<TextBox>() { };
            AddressTextBoxDetails.Clear();  
            //if(CardTextBoxDetails is null)  
            CardTextBoxDetails = new List<object>() { };
            CardTextBoxDetails.Clear();

            // Build TableLayoutPanel with set columns and rows
            GenerateTable(2, 6);
            //populateFields();                    
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
                { MessageBox.Show("Try again sucker"); return; }
            }
        }

        public void CreateMyBorderlessWindow()
        {
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }
        private void ReserveFlight_Load(object sender, EventArgs e)
        {
            CreateMyBorderlessWindow();            
        }
        public void cancelCode()
        {
            //txtPassword.Text = "";
            //txtUsername.Text = "";
            //loginDetails(false);
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {
            UpdateCurrentChanges();
            this.Close();            
        }
        private bool CheckReservationDetails()
        {
            int cntAddressDetails = AddressTextBoxDetails.Count;
            int cntCardDetails = CardTextBoxDetails.Count;
            
            int cntError = 0;
            if (cntAddressDetails > 0 && cntCardDetails > 0)
            {                
                // loop through all collections and make sure they have text
                cntError = cntError + CheckCollCount(AddressTextBoxDetails);
                cntError = cntError + CheckCollCount(CardTextBoxDetails);                

                if (cntError == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }

        }
        public int CheckCollCount(List<TextBox> lst)
        {
            int cntError = 0;
            foreach (var item in lst)
            {
                if (string.IsNullOrWhiteSpace(item.Text))
                    cntError++;
            }
            return cntError;
        }
        public int CheckCollCount(List<object> lst)
        {
            int cntError = 0;
            foreach (var item in lst)
            {               
                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)item).Text))
                        cntError++;
                }                
            }
            return cntError;
        }
        private void UpdateCurrentChanges()
        {          
            FlightCustDetails.AddressDetails.Clear();
            FlightCustDetails.CardDetails.Clear();

            for (int i = 0; i < AddressTextBoxDetails.Count; i++)
            {
                FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[i].Text);
            }

            for (int i = 0; i < CardTextBoxDetails.Count; i++)
            {
                if (CardTextBoxDetails[i] is TextBox)
                {
                    FlightCustDetails.CardDetails.Add(((TextBox)CardTextBoxDetails[i]).Text);
                }
                else
                {
                    FlightCustDetails.CardDetails.Add(((DateTimePicker)CardTextBoxDetails[i]).Value.ToString());
                    //((DateTimePicker)expiry).Value = Convert.ToDateTime(FlightCustDetails.CardDetails[5]);
                }
            }           

        }
        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            bool ReservationDetailsOK = CheckReservationDetails();

            if (ReservationDetailsOK)
            {
                //FlightCustDetails.AddressDetails.Clear();
                //FlightCustDetails.CardDetails.Clear();

                //for (int i = 0; i < AddressTextBoxDetails.Count; i++)
                //{
                //    FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[i].Text);
                //}

                //for (int i = 0; i < CardTextBoxDetails.Count; i++)
                //{
                //    if (CardTextBoxDetails[i] is TextBox)
                //    {
                //        FlightCustDetails.CardDetails.Add(((TextBox)CardTextBoxDetails[i]).Text);
                //    }
                //    else
                //    {
                //        FlightCustDetails.CardDetails.Add(((DateTimePicker)CardTextBoxDetails[i]).Value.ToString());
                //        //((DateTimePicker)expiry).Value = Convert.ToDateTime(FlightCustDetails.CardDetails[5]);
                //    }
                //}

                UpdateCurrentChanges();

                _confirm = new Confirmation(this);
                _confirm.MdiParent = this.ParentForm;
                _confirm.FormClosed += new FormClosedEventHandler(ReserveFlight_FormClosed);
                this.Dock = DockStyle.Fill;
                _confirm.Show();
            }

            /*
            if (CheckFields())
            {
                //populateFields();
                populateLists();
                
                _confirm = new Confirmation(this);
                _confirm.MdiParent = this.ParentForm;
                //_confirm.FormClosed += new FormClosedEventHandler(ReserveFlight_FormClosed);
                this.Dock = DockStyle.Fill;
                _confirm.Show();
            }
            else
            {
                return;
            }

            */
             
        }
        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
            ar = null;
            f = null; ;
            cm = null;
            _confirm = null;
        }

       

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            f=null;
        }

        private void tlpConfirmFlight_Paint(object sender, PaintEventArgs e)
        {
            //tlpConfirmFlight.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void setBackgroundImage(string CntryDest)
        {
            string filename = "";

            string dir = Path.GetDirectoryName(Application.ExecutablePath);



            filename = Path.Combine("../../Resources/", CntryDest + ".jpg");
            this.BackgroundImage = Image.FromFile(filename);
        }
        private void RecalculateColumnStyles(TableLayoutPanel tlp)
        {
            var cols = tlp.ColumnCount;
            var pct = tlp.Width / tlp.ColumnCount;
            tlp.SuspendLayout();
            tlp.ColumnStyles.Clear();
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            //tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
            //tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
         
            //tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
            //for (var i = 0; i < cols; i++)
            //{
            //    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pct));
            //}
            tlp.ResumeLayout();

            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 35f));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            //tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            //tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));

            /*
            var rows = tlp.RowCount;
            var pctrows = tlp.Height / tlp.RowCount;
            tlp.SuspendLayout();
            tlp.RowStyles.Clear();
            for (var i = 0; i < rows; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, pctrows));
            }
            */
            tlp.ResumeLayout();
        }
        private void GenerateTable(int cols, int rows)
        {
            // Main TableLayoutPanel which contains 2 columns - each row contains another TableLayoutPanel 
            // Main TableLayoutPanel which contains 2 rows - each row contains another TableLayoutPanel 
            TableLayoutPanel tbLtPnMain = new TableLayoutPanel();
            tbLtPnMain.ColumnCount = cols;
            tbLtPnMain.RowCount = rows;
            tbLtPnMain.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            //tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            //tbLtPnMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            
            // ####### Testing #######
            //tbLtPnMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;


            //Set dimenesions of main table
            tbLtPnMain.Width = 625;
            tbLtPnMain.Height = 350;
            tbLtPnMain.Location = new Point(215, 120);
            RecalculateColumnStyles(tbLtPnMain);            

            TableLayoutPanel cardNumberTP = new TableLayoutPanel();
            cardNumberTP.Width = 225;
            cardNumberTP.Height = 27;  
            tbLtPnMain.ColumnCount = 2;
            tbLtPnMain.RowCount = 1;

            TextBox cardNumber1 = new TextBox();
            cardNumber1.KeyPress += CardNumber1_KeyPress;
            cardNumber1.Font = new Font("Arial", 13);
            cardNumber1.Multiline = true;
            cardNumber1.Size = new Size(50, 27);
            cardNumber1.MaxLength = 4;
            TextBox cardNumber2 = new TextBox();
            cardNumber2.KeyPress += CardNumber2_KeyPress;
            cardNumber2.Font = new Font("Arial", 13);
            cardNumber2.Multiline = true;
            cardNumber2.Size = new Size(50, 27);
            cardNumber2.MaxLength = 4;
            TextBox cardNumber3 = new TextBox();
            cardNumber3.KeyPress += CardNumber3_KeyPress;
            cardNumber3.Font = new Font("Arial", 13);
            cardNumber3.Multiline = true;
            cardNumber3.Size = new Size(50, 27);
            cardNumber3.MaxLength = 4;
            TextBox cardNumber4 = new TextBox();
            cardNumber4.KeyPress += CardNumber4_KeyPress;
            cardNumber4.Font = new Font("Arial", 13);
            cardNumber4.Multiline = true;
            cardNumber4.Size = new Size(50, 27);
            cardNumber4.MaxLength = 4;

            cardNumberTP.Controls.Add(cardNumber1,0,0);
            cardNumberTP.Controls.Add(cardNumber2,1,0);
            cardNumberTP.Controls.Add(cardNumber3, 2, 0);
            cardNumberTP.Controls.Add(cardNumber4, 3, 0);   

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

            DateTimePicker expiry = new DateTimePicker();
            expiry.Size = new Size(75, 50);

            //CardTextBoxDetails.Add((TextBox)expiry)
            
            expiry.ShowUpDown = true;            
            expiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            expiry.CustomFormat = "MM/yy";
            expiry.Font = new Font("Arial", 13);
            
            Label CardNum = new Label();            
            CardNum.BackColor = Color.Transparent;// Transparent
            CardNum.Text = "Card Number";
            CardNum.Size = new Size(175, 31);
            CardNum.Font = new Font("Arial", 13);
            CardNum.ForeColor = System.Drawing.Color.White;

            TableLayoutPanel addressTP = new TableLayoutPanel();
            addressTP.Width = 225;
            addressTP.Height = 100;
            addressTP.ColumnCount = 1;
            addressTP.RowCount = 2;

            TextBox address1 = new TextBox();
            address1.MaxLength = 26;
            address1.KeyPress += Address1_KeyPress; 
            address1.Multiline = true;
            address1.Size = new Size(300, 27);
            address1.Font = new Font("Arial", 13);
            TextBox address2 = new TextBox();
            address2.MaxLength = 26;
            address2.KeyPress += Address1_KeyPress;
            address2.Multiline = true;
            address2.Size = new Size(300, 27);
            address2.Font = new Font("Arial", 13);
            TextBox address3 = new TextBox();
            address2.MaxLength = 26;
            address3.KeyPress += Address1_KeyPress;
            address3.Multiline = true;
            address3.Size = new Size(300, 27);
            address3.Font = new Font("Arial", 13);            
            
            addressTP.Controls.Add(address1, 0, 0);
            addressTP.Controls.Add(address2, 0, 1);
            addressTP.Controls.Add(address3, 0, 1);

            Label Address = new Label();
            Address.BackColor = Color.Transparent;// Transparent
            Address.Text = "Address";
            Address.Size = new Size(175, 31);
            Address.Font = new Font("Arial", 13);
            Address.ForeColor = System.Drawing.Color.White;            

            Label NameOnCard = new Label();
            NameOnCard.BackColor = Color.Transparent;// Transparent
            NameOnCard.Text = "Name on Card";
            NameOnCard.Size = new Size(175, 31);
            NameOnCard.Font = new Font("Arial", 13);
            NameOnCard.ForeColor = System.Drawing.Color.White;

            Label HouseNameNumb = new Label();
            HouseNameNumb.BackColor = Color.Transparent;// Transparent
            HouseNameNumb.Text = "House Name/Number";
            HouseNameNumb.Size = new Size(275, 31);
            HouseNameNumb.Font = new Font("Arial", 13);
            HouseNameNumb.ForeColor = System.Drawing.Color.White;

            TextBox houseNameNumb = new TextBox();
            houseNameNumb.MaxLength = 26;
            houseNameNumb.KeyPress += HouseNameNumb_KeyPress;
            houseNameNumb.Multiline = true;
            houseNameNumb.Size = new Size(300, 27);
            houseNameNumb.Font = new Font("Arial", 13);

            Label PostCode = new Label();
            PostCode.BackColor = Color.Transparent;// Transparent
            PostCode.Text = "Post/Zip Code";
            PostCode.Size = new Size(275, 31);
            PostCode.Font = new Font("Arial", 13);
            PostCode.ForeColor = System.Drawing.Color.White;

            TextBox postcode = new TextBox();
            postcode.MaxLength = 10;
            postcode.KeyPress += Postcode_KeyPress;
            postcode.Multiline = true;
            postcode.Size = new Size(150, 27);
            postcode.Font = new Font("Arial", 13);     
            
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

            TextBox nameOnCard = new TextBox();
            nameOnCard.MaxLength = 26;
            nameOnCard.KeyPress += NameOnCard_KeyPress;
            nameOnCard.Multiline = true;
            nameOnCard.Size = new Size(300, 27);
            nameOnCard.Font = new Font("Arial", 13);                                   
                                  
            TextBox csv = new TextBox();            
            csv.KeyPress += Csv_KeyPress;
            csv.MaxLength = 3;
            csv.Size = new Size(75, 27);
            csv.Multiline = true;
            csv.Font = new Font("Arial", 13);

            if (FlightCustDetails.AddressDetails.Count > 0)
            {
                houseNameNumb.Text = FlightCustDetails.AddressDetails[0];
                address1.Text = FlightCustDetails.AddressDetails[1];
                address2.Text = FlightCustDetails.AddressDetails[2];
                address3.Text = FlightCustDetails.AddressDetails[3];
                postcode.Text = FlightCustDetails.AddressDetails[4];
            }

            
            if (FlightCustDetails.CardDetails.Count > 0)
            {
                nameOnCard.Text = FlightCustDetails.CardDetails[0];
                cardNumber1.Text = FlightCustDetails.CardDetails[1];
                cardNumber2.Text = FlightCustDetails.CardDetails[2];
                cardNumber3.Text = FlightCustDetails.CardDetails[3];
                cardNumber4.Text = FlightCustDetails.CardDetails[4];
                ((DateTimePicker)expiry).Value = Convert.ToDateTime(FlightCustDetails.CardDetails[5]);
                csv.Text = FlightCustDetails.CardDetails[6];
            }            

            if (CardTextBoxDetails.Count == 0)
            {
                CardTextBoxDetails.Add(nameOnCard);
                CardTextBoxDetails.Add(cardNumber1);
                CardTextBoxDetails.Add(cardNumber2);
                CardTextBoxDetails.Add(cardNumber3);
                CardTextBoxDetails.Add(cardNumber4);
                CardTextBoxDetails.Add(expiry);                
                CardTextBoxDetails.Add(csv);
                
            }            

            if (AddressTextBoxDetails.Count == 0)
            {
                AddressTextBoxDetails.Add(houseNameNumb);
                AddressTextBoxDetails.Add(address1);
                AddressTextBoxDetails.Add(address2);
                AddressTextBoxDetails.Add(address3);
                AddressTextBoxDetails.Add(postcode);
                
            }   

            csvexpiry.Controls.Add(expiry, 0, 0);
            csvexpiry.Controls.Add(csv, 1, 0);
            labelRows.Controls.Add(l,1,0);
            labelRows.Controls.Add(exp, 0, 0);

            //if(FlightCustDetails.CardDetails.Count > 0 && FlightCustDetails.AddressDetails.Count > 0)
            //PopultateReservationList();

            // Add child controls to TableLayoutPanel and specify rows and column  
            tbLtPnMain.Controls.Add(labelRows, 0, 4);
            tbLtPnMain.Controls.Add(NameOnCard, 0, 0);
            tbLtPnMain.Controls.Add(HouseNameNumb, 1, 0);
            tbLtPnMain.Controls.Add(nameOnCard, 0, 1);
            tbLtPnMain.Controls.Add(houseNameNumb, 1, 1);
            tbLtPnMain.Controls.Add(CardNum, 0, 2);
            tbLtPnMain.Controls.Add(addressTP, 1, 3);
            tbLtPnMain.Controls.Add(Address, 1, 2);
            tbLtPnMain.Controls.Add(cardNumberTP, 0, 3);
            tbLtPnMain.Controls.Add(PostCode, 1, 4);
            tbLtPnMain.Controls.Add(postcode, 1, 5);
            tbLtPnMain.Controls.Add(csvexpiry, 0, 5);            

            this.Controls.Add(tbLtPnMain);
        }
        private void Address1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\x20]+$");
        }
        private void Postcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\x20]+$") && !char.IsDigit(e.KeyChar);
        }
        private void HouseNameNumb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\x20]+$") && !char.IsDigit(e.KeyChar);
        }
        private void CardNumber4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        private void CardNumber3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        private void CardNumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        private void CardNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        private void NameOnCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\x20]+$");
        }
        private void Csv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// Populate the static Lists for Card and Address detail        
        /// </summary>
        private void populateLists()
        {            
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[0].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[1].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[2].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[3].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[4].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[5].ToString());
            FlightCustDetails.CardDetails.Add(CardTextBoxDetails[6].ToString());
                
            FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[0].Text);
            FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[1].Text);
            FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[2].Text);
            FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[3].Text);
            FlightCustDetails.AddressDetails.Add(AddressTextBoxDetails[4].Text);       
        }

        private void populateFields()
        {                            
            ((TextBox)CardTextBoxDetails[0]).Text = FlightCustDetails.CardDetails[0].ToString();
            ((TextBox)CardTextBoxDetails[1]).Text = FlightCustDetails.CardDetails[1].ToString();
            ((TextBox)CardTextBoxDetails[2]).Text = FlightCustDetails.CardDetails[2].ToString();
            ((TextBox)CardTextBoxDetails[3]).Text = FlightCustDetails.CardDetails[3].ToString();
            ((TextBox)CardTextBoxDetails[4]).Text = FlightCustDetails.CardDetails[4].ToString();
            ((TextBox)CardTextBoxDetails[5]).Text = FlightCustDetails.CardDetails[5].ToString();
            //((TextBox)CardTextBoxDetails[6]).Text = FlightCustDetails.CardDetails[6].ToString();

            string test = FlightCustDetails.AddressDetails[0].ToString();

            AddressTextBoxDetails[0].Text = test;//FlightCustDetails.AddressDetails[0].ToString();
            AddressTextBoxDetails[1].Text = FlightCustDetails.AddressDetails[1].ToString();
            AddressTextBoxDetails[2].Text = FlightCustDetails.AddressDetails[2].ToString();
            AddressTextBoxDetails[3].Text = FlightCustDetails.AddressDetails[3].ToString();
            AddressTextBoxDetails[4].Text = FlightCustDetails.AddressDetails[4].ToString();            
        }

        /// <summary>
        /// Check there is the required data in all fields
        /// to enable to move to next tab
        /// </summary>
        /// <returns></returns>
        public bool CheckFields()
        {
            bool output = true;

            TextBox tb0 = (TextBox)CardTextBoxDetails[0];
            TextBox tb1 = (TextBox)CardTextBoxDetails[1];
            TextBox tb2 = (TextBox)CardTextBoxDetails[2];
            TextBox tb3 = (TextBox)CardTextBoxDetails[3];
            TextBox tb4 = (TextBox)CardTextBoxDetails[4];

            if(string.IsNullOrEmpty(tb0.Text) || string.IsNullOrEmpty(tb1.Text) ||
               string.IsNullOrEmpty(tb2.Text) || string.IsNullOrEmpty(tb3.Text) ||
               string.IsNullOrEmpty(tb4.Text))
            {
                output = false;
            }


            if (CardTextBoxDetails[0].ToString().Trim().Length == 0 || 
               CardTextBoxDetails[1].ToString().Trim().Length == 0 ||
               CardTextBoxDetails[2].ToString().Trim().Length == 0 ||
               CardTextBoxDetails[3].ToString().Trim().Length == 0 ||
               CardTextBoxDetails[4].ToString().Trim().Length == 0 ||
               CardTextBoxDetails[5].ToString().Trim().Length == 0)
            {
                output = false;  
            }
            
            if(string.IsNullOrEmpty(AddressTextBoxDetails[0].Text) ||
                string.IsNullOrEmpty(AddressTextBoxDetails[4].Text))
            {
                output = false;
            }
           
            if(string.IsNullOrEmpty(AddressTextBoxDetails[1].Text) &&
                string.IsNullOrEmpty(AddressTextBoxDetails[2].Text) &&
                string.IsNullOrEmpty(AddressTextBoxDetails[3].Text) )
            {
                output = false;
            }

            return output;  
        }
        private void ReserveFlight_FormClosed(object sender, FormClosedEventArgs e)
        {
            _confirm = null;
        }

        
    }
}
