using System;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace AirLineReservationSystem
{
    public partial class Passenger_Details : Form
    {
        AirlineReservationDAL.AirlineReservation ar;
        //AirlineReservationDAL.AirlineReservation ar;
        ReserveFlight rf;
        Administration ad;
        ContextMenu cm;
        public BookFlightTest bft { get; set; }
        
        public List<string> txtBoxValues { get; set; }

        public static List<TextBox> TextBoxCollFirstNames { get; set; }
        public static List<TextBox> TextBoxCollLastNames { get; set; }
        public static List<ComboBox> ComboBoxCollGenders { get; set; }

        public static List<TextBox> TextBoxCollChildFirstNames { get; set; }
        public static List<TextBox> TextBoxCollChildLastNames { get; set; }
        public static List<ComboBox> ComboBoxCollChildGenders { get; set; }

        public ComboBox Gender { get; set; }
        public ComboBox GenderChildren { get; set; }
        public string FlightNo { get; set; }


        //public Passenger_Details(BookFlight f)
        //public Passenger_Details(BookFlightGrid f)
        //{
        //    InitializeComponent();
        //     ar = new AirlineReservationDAL.AirlineReservation();

        //    if (cm is null)
        //    {
        //        cm = new ContextMenu();
        //        MenuItem mnuItemNew = new MenuItem();
        //        mnuItemNew.Text = "Admin";
        //        cm.MenuItems.Add(mnuItemNew);
        //        this.ContextMenu = cm;
        //        mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
        //    }

        //}

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

        public void cancelCode()
        {
            //txtPassword.Text = "";
            //txtUsername.Text = "";
            //loginDetails(false);
        }

        void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad = null;
            ar = null;
            rf = null;
            cm = null;
            bft = null;       
    }

        public Passenger_Details(BookFlightTest _bft)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();

            setBackgroundImage("Passport");
            
            //_ = FlightCustDetails.FlightAirport;
            List<string> list = FindFlight.FlightStats;

            if (cm is null)
            {
                cm = new ContextMenu();
                MenuItem mnuItemNew = new MenuItem();
                mnuItemNew.Text = "Admin";
                cm.MenuItems.Add(mnuItemNew);
                this.ContextMenu = cm;
                mnuItemNew.Click += new EventHandler(mnuItemNew_Click);
            }

            txtBoxValues = new List<string>();

            TextBoxCollFirstNames = new List<TextBox> { };
            TextBoxCollLastNames = new List<TextBox> { };
            ComboBoxCollGenders = new List<ComboBox> { };

            TextBoxCollChildFirstNames = new List<TextBox> { };
            TextBoxCollChildLastNames = new List<TextBox> { };
            ComboBoxCollChildGenders = new List<ComboBox> { };

            //FlightCustDetails.Adults.Clear();
            //FlightCustDetails.Children.Clear();

            bft = _bft;

            FlightNo = BookFlightTest.strRBSelectFlightInt;


            //UpdateChanges();

            GenerateTable(bft.NumAdults, bft.NumChildren);           

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


        public void CreateMyBorderlessWindow()
        {
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        private void Passenger_Details_Load(object sender, EventArgs e)
        {
            CreateMyBorderlessWindow();            
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            UpdateChanges();
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        public void UpdateChanges()
        {
            FlightCustDetails.Adults.Clear();
            FlightCustDetails.Children.Clear();
            //        FindFlight.FlightStats.Add()
            //        TextBoxCollFirstNames 
            //TextBoxCollLastNames
            //ComboBoxCollGenders 

            //TextBoxCollChildFirstNames 
            //TextBoxCollChildLastNames 
            //ComboBoxCollChildGenders
           
            string FirstNamesAdult = "";
            string FirstNamesChild = "";
            for (int i = 0; i < TextBoxCollFirstNames.Count; i++)
            {
                FlightCustDetails.Adults.Add(TextBoxCollFirstNames[i].Text.Trim());
            }

            for (int i = 0; i < TextBoxCollLastNames.Count; i++)
            {
                FlightCustDetails.Adults[i] = FlightCustDetails.Adults[i].Trim() + " " + TextBoxCollLastNames[i].Text.Trim();
            }

            for (int i = 0; i < ComboBoxCollGenders.Count; i++)
            {
                FlightCustDetails.Adults[i] = FlightCustDetails.Adults[i].Trim() + " " + ComboBoxCollGenders[i].Text.Trim();
            }

            for (int i = 0; i < TextBoxCollChildFirstNames.Count; i++)
            {
                FlightCustDetails.Children.Add(TextBoxCollChildFirstNames[i].Text.Trim());
            }

            for (int i = 0; i < TextBoxCollChildLastNames.Count; i++)
            {
                FlightCustDetails.Children[i] = FlightCustDetails.Children[i].Trim() + " " + TextBoxCollChildLastNames[i].Text.Trim();
            }

            for (int i = 0; i < ComboBoxCollChildGenders.Count; i++)
            {
                FlightCustDetails.Children[i] = FlightCustDetails.Children[i].Trim() + " " + ComboBoxCollChildGenders[i].Text.Trim();
            }
        }

        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            bool PassengerDetailsOK = CheckPassengerDetails();

            if (PassengerDetailsOK)
            {
                //FlightCustDetails.Adults.Clear();
                //FlightCustDetails.Children.Clear();                

                //string FirstNamesAdult = "";
                //string FirstNamesChild = "";
                //for (int i = 0; i < TextBoxCollFirstNames.Count; i++)                
                //{                   
                //    FlightCustDetails.Adults.Add(TextBoxCollFirstNames[i].Text);
                //}

                //for (int i = 0; i < TextBoxCollLastNames.Count; i++)
                //{
                //    FlightCustDetails.Adults[i] = FlightCustDetails.Adults[i] + " " + TextBoxCollLastNames[i].Text;                    
                //}

                //for (int i = 0; i < ComboBoxCollGenders.Count; i++)
                //{
                //    FlightCustDetails.Adults[i] = FlightCustDetails.Adults[i] + " " + ComboBoxCollGenders[i].Text;                    
                //}

                //for (int i = 0; i < TextBoxCollChildFirstNames.Count; i++)
                //{
                //    FlightCustDetails.Children.Add(TextBoxCollChildFirstNames[i].Text);                   
                //}

                //for (int i = 0; i < TextBoxCollChildLastNames.Count; i++)
                //{                    
                //    FlightCustDetails.Children[i] = FlightCustDetails.Children[i] + " " + TextBoxCollChildLastNames[i].Text;
                //}

                //for (int i = 0; i < ComboBoxCollChildGenders.Count; i++)
                //{         
                //    FlightCustDetails.Children[i] = FlightCustDetails.Children[i] + " " + ComboBoxCollChildGenders[i].Text;
                //}

                UpdateChanges();

                rf = new ReserveFlight(this);
                rf.MdiParent = this.ParentForm;
                rf.FormClosed += new FormClosedEventHandler(rf_FormClosed);
                this.Dock = DockStyle.Fill;
                rf.Show();
            }
            
        }

        private bool CheckPassengerDetails()
        {
            int cntGender = ComboBoxCollGenders.Count;
            int cntSurname = TextBoxCollLastNames.Count;
            int cntFirstName = TextBoxCollFirstNames.Count;
            int cntError = 0;
            if (cntGender > 0)
            { 
                if (cntGender == cntSurname && cntGender == cntFirstName)
                {
                    // loop through all collections and make sure they have text
                    cntError = cntError + CheckCollCount(TextBoxCollFirstNames);
                    cntError = cntError + CheckCollCount(TextBoxCollLastNames);
                    cntError = cntError + CheckCollCount(ComboBoxCollGenders);
                    cntError = cntError + CheckCollCount(TextBoxCollChildFirstNames);
                    cntError = cntError + CheckCollCount(TextBoxCollChildLastNames);
                    cntError = cntError + CheckCollCount(ComboBoxCollChildGenders);

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

        public int CheckCollCount(List<ComboBox> lst)
        {
            int cntError = 0;
            foreach (var item in lst)
            {
                if (string.IsNullOrWhiteSpace(item.Text))
                    cntError++;
            }
            return cntError;
        }

        void rf_FormClosed(object sender, FormClosedEventArgs e)
        {
            rf = null;
        }       

        private void GenerateTable(int nAdults, int nChildren)
        {
            // Main TableLayoutPanel which contains 2 rows - each row contains another TableLayoutPanel 
            TableLayoutPanel tbLtPnMain = new TableLayoutPanel();
            tbLtPnMain.ColumnCount = 2;
            tbLtPnMain.BackColor = Color.FromArgb(150, 0, 0, 0); // Transparent
            tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLtPnMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLtPnMain.Width = 925;
            tbLtPnMain.Height = 450;
            tbLtPnMain.Location = new Point(55, 95);
            //tbLtPnMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            //
            TableLayoutPanel tbLtPnMainAdults = new TableLayoutPanel();
            tbLtPnMainAdults.Anchor = AnchorStyles.None;
            tbLtPnMainAdults.RowCount = 2;
            tbLtPnMainAdults.BackColor = Color.FromArgb(150, 50, 50, 75); // Transparent
            tbLtPnMainAdults.Width = 415;
            tbLtPnMainAdults.Height = 425;
            tbLtPnMainAdults.Location = new Point(50, 70);
            //tbLtPnMainAdults.AutoScroll = true;
            tbLtPnMainAdults.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                       
            TableLayoutPanel tbLtPnRowsAdults = new TableLayoutPanel();
            tbLtPnRowsAdults.AutoScroll = true;
            tbLtPnRowsAdults.RowCount = nAdults;
            tbLtPnRowsAdults.Width = 415;
            tbLtPnRowsAdults.Height = 380;
            tbLtPnRowsAdults.ColumnCount = 3;
            for (int i = 0; i < nAdults; i++)
            {
                tbLtPnRowsAdults.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
                tbLtPnRowsAdults.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                TextBox txbx = new TextBox() { Text = "", BackColor = Color.LightGray, ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left };
                TextBoxCollFirstNames.Add(txbx);               
                tbLtPnRowsAdults.Controls.Add(txbx, 0, i);
                               
                tbLtPnRowsAdults.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                TextBox txbxSurname = new TextBox() { Text = "", BackColor = Color.LightGray, ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left };
                TextBoxCollLastNames.Add(txbxSurname); 
                tbLtPnRowsAdults.Controls.Add(txbxSurname, 1, i);
                               
                tbLtPnRowsAdults.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                Gender = new ComboBox();
                ComboBoxCollGenders.Add(Gender);
                //Gender.TextChanged += Gender_TextChanged;
                
                Gender.BackColor = Color.LightGray;
                Gender.Items.Add("Male");
                Gender.Items.Add("Female");
                Gender.Font = new Font("Comic Sans", 10);
                Gender.DropDownStyle = ComboBoxStyle.DropDownList;
                tbLtPnRowsAdults.Controls.Add(Gender);
                //tbLtPnRowsAdults.Controls.Add(new TextBox() { Text = "", ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left }, 2, i);

            }            

            TableLayoutPanel tbLtPnMainChildren = new TableLayoutPanel();
            tbLtPnMainChildren.Anchor = AnchorStyles.None;
            tbLtPnMainChildren.RowCount = 2;
            tbLtPnMainChildren.BackColor = Color.FromArgb(150, 50, 50, 50); // Transparent
            tbLtPnMainChildren.Width = 415;
            tbLtPnMainChildren.Height = 425;
            tbLtPnMainChildren.Location = new Point(525, 70);
            //tbLtPnMainChildren.AutoScroll = true;
            tbLtPnMainChildren.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;

            TableLayoutPanel tbLtPnRowsChildren = new TableLayoutPanel();            
            tbLtPnRowsChildren.AutoScroll = true;
            tbLtPnRowsChildren.RowCount = nChildren;
            tbLtPnRowsChildren.Width = 415;
            tbLtPnRowsChildren.Height = 380;
            tbLtPnRowsChildren.ColumnCount = 3; 
            for (int i = 0; i < nChildren; i++)
            {   
                tbLtPnRowsChildren.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
                tbLtPnRowsChildren.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                TextBox tbxChildFirstNames = new TextBox() { Text = "", BackColor = Color.LightGray, ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left };
                TextBoxCollChildFirstNames.Add(tbxChildFirstNames);
                tbLtPnRowsChildren.Controls.Add(tbxChildFirstNames, 0, i);
                               
                tbLtPnRowsChildren.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                TextBox tbxChildLastNames = new TextBox() { Text = "", BackColor = Color.LightGray, ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left };
                TextBoxCollChildLastNames.Add(tbxChildLastNames);   
                tbLtPnRowsChildren.Controls.Add(tbxChildLastNames, 1, i);
                                
                tbLtPnRowsChildren.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
                GenderChildren = new ComboBox();
                ComboBoxCollChildGenders.Add(GenderChildren);
                GenderChildren.BackColor = Color.LightGray;
                GenderChildren.Items.Add("Male");
                GenderChildren.Items.Add("Female");
                GenderChildren.Font = new Font("Comic Sans", 10);
                GenderChildren.DropDownStyle = ComboBoxStyle.DropDownList;
                tbLtPnRowsChildren.Controls.Add(GenderChildren);

                //tbLtPnRowsChildren.Controls.Add(new ComboBox() { Text = "", ForeColor = Color.Black, Font = new Font("Comic Sans", 10), TextAlign = HorizontalAlignment.Left }, 2, i);

            }

            if (FlightCustDetails.Adults.Count > 0)
                PopultatePassengerList();

            TableLayoutPanel tlpHeadingsAdults = Headings();
            TableLayoutPanel tlpHeadingsChildren = Headings();

            tbLtPnMainAdults.Controls.Add(tlpHeadingsAdults);
            tbLtPnMainChildren.Controls.Add(tlpHeadingsChildren);

            tbLtPnMainAdults.Controls.Add(tbLtPnRowsAdults);
            tbLtPnMainChildren.Controls.Add(tbLtPnRowsChildren);

            tbLtPnMain.Controls.Add(tbLtPnMainAdults);
            tbLtPnMain.Controls.Add(tbLtPnMainChildren);

            //tbLtPnMain.VerticalScroll.Enabled = true;
            //tbLtPnMain.AutoScroll = true;
            tbLtPnMain.BackColor = Color.Transparent;

            this.Controls.Add(tbLtPnMain);

        }

        private void PopultatePassengerList()
        {            
            //for (int i = 0; i < TextBoxCollFirstNames.Count; i++)
            for (int i = 0; i < FlightCustDetails.Adults.Count; i++)
            {                
                string fn = FlightCustDetails.Adults[i].ToString();
                
                TextBoxCollFirstNames[i].Text = fn.Substring(0, fn.IndexOf(' ') - 0).Trim();//FirstNamesArray[j].Text;
                           
            }
            //for (int i = 0; i < TextBoxCollLastNames.Count; i++)
            for (int i = 0; i < FlightCustDetails.Adults.Count; i++)
            {
                string fnl = FlightCustDetails.Adults[i].ToString();                
                TextBoxCollLastNames[i].Text = fnl.Substring(TextBoxCollFirstNames[i].Text.Length + 1, fnl.LastIndexOf(' ') - fnl.IndexOf(' ')).Trim();
            }
            //for (int i = 0; i < ComboBoxCollGenders.Count; i++)
            for (int i = 0; i < FlightCustDetails.Adults.Count; i++)
            {
                string fng = FlightCustDetails.Adults[i].ToString();
                int xl = fng.Length;
                int yl = fng.LastIndexOf(' ');
                string d = ComboBoxCollGenders[i].DisplayMember;
                string v = ComboBoxCollGenders[i].ValueMember;
                string t = ComboBoxCollGenders[i].Text.Trim();
                string maleFemale = fng.Substring(fng.LastIndexOf(' ') + 1);
                //ComboBoxCollGenders[i].SelectedValue = maleFemale;
                //ComboBoxCollGenders[i].DisplayMember = maleFemale;
                ComboBoxCollGenders[i].Text = maleFemale;
                //ComboBoxCollGenders[i].ValueMember = maleFemale;

            }

            //for (int i = 0; i < TextBoxCollChildFirstNames.Count; i++)
            for (int i = 0; i < FlightCustDetails.Children.Count; i++)
            {
                string fnc = FlightCustDetails.Children[i].ToString();
                TextBoxCollChildFirstNames[i].Text = fnc.Substring(0, fnc.IndexOf(' ') - 0).Trim();//FirstNamesArray[j].Text;

            }
            //for (int i = 0; i < TextBoxCollChildLastNames.Count; i++)
            for (int i = 0; i < FlightCustDetails.Children.Count; i++)
            {
                string fncl = FlightCustDetails.Children[i].ToString();
                //TextBoxCollChildLastNames[i].Text = fncl.Substring(TextBoxCollChildLastNames[i].Text.Length + 1, fncl.LastIndexOf(' ') - fncl.IndexOf(' '));
                TextBoxCollChildLastNames[i].Text = fncl.Substring(fncl.IndexOf(' '), fncl.LastIndexOf(' ') - fncl.IndexOf(' ')).Trim();
            }

            //for (int i = 0; i < ComboBoxCollChildGenders.Count; i++)
            for (int i = 0; i < FlightCustDetails.Children.Count; i++)
            {
                string fng = FlightCustDetails.Children[i].ToString();
                int xl = fng.Length;
                int yl = fng.LastIndexOf(' ');
                string d = ComboBoxCollChildGenders[i].DisplayMember;
                string v = ComboBoxCollChildGenders[i].ValueMember;
                string t = ComboBoxCollChildGenders[i].Text.Trim();
                string maleFemale = fng.Substring(fng.LastIndexOf(' ') + 1);             
                ComboBoxCollChildGenders[i].Text = maleFemale;        

            }
        }

        private void Gender_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxbxSurname_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox val = (TextBox)sender;
            //string txtSurname = val.Text;
            //txtBoxValues.Add(txtSurname);
        }

        private void Txbx_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox val = (TextBox)sender;
            //string txtFirstName = val.Text;
            //txtBoxValues.Add(txtFirstName);
            //if(!string.IsNullOrEmpty(txbxSurname.Text) && !string.IsNullOrEmpty(txbx.Text))
            //{
            //    txtBoxValues.Add(txbxSurname.Text + " " + txbxSurname.Text + Gender.SelectedText);
            //}
        }

        private void TxbxSurname_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        public TableLayoutPanel Headings()
        {
            TableLayoutPanel tlpHeadings = new TableLayoutPanel();
            //tlpHeadings.Location = new Point(100, 70);
            tlpHeadings.BorderStyle = BorderStyle.None;
            tlpHeadings.BackColor = Color.Transparent;
            //tlpHeadings.ColumnStyles.
            tlpHeadings.ColumnCount = 3;
            tlpHeadings.RowCount = 1;
            tlpHeadings.Width = 405;
            tlpHeadings.Height = 20;
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));

            Label txtfFirstName = new Label();
            txtfFirstName.BackColor = Color.Transparent;
            txtfFirstName.BorderStyle = BorderStyle.None;
            txtfFirstName.ForeColor = Color.White;
            txtfFirstName.Text = "First Name";
            txtfFirstName.TextAlign = ContentAlignment.MiddleLeft;
            txtfFirstName.Font = new Font("Comic Sans", 12);
            tlpHeadings.Controls.Add(txtfFirstName, 0, 0);

            Label txtfSecondName = new Label();
            txtfSecondName.BackColor = Color.Transparent;
            txtfSecondName.BorderStyle = BorderStyle.None;
            txtfSecondName.ForeColor = Color.White;
            txtfSecondName.Text = "Last Name";
            txtfSecondName.TextAlign = ContentAlignment.MiddleLeft;
            txtfSecondName.Font = new Font("Comic Sans", 12);
            tlpHeadings.Controls.Add(txtfSecondName, 1, 0);

            Label txtfGender = new Label();
            txtfGender.BackColor = Color.Transparent;
            txtfGender.BorderStyle = BorderStyle.None;
            txtfGender.ForeColor = Color.White;
            txtfGender.Text = "Gender";
            txtfGender.TextAlign = ContentAlignment.MiddleLeft;
            txtfGender.Font = new Font("Comic Sans", 12);
            tlpHeadings.Controls.Add(txtfGender, 2, 0);

            return tlpHeadings;
        }

        private void tlpPassDetail_Paint(object sender, PaintEventArgs e)
        {
            //tlpPassDetail.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void setBackgroundImage(string BackgroundImge)
        {
            string filename = "";

            string dir = Path.GetDirectoryName(Application.ExecutablePath);

            filename = Path.Combine("../../Resources/", BackgroundImge + ".jpg");
            this.BackgroundImage = Image.FromFile(filename);

        }

        
    }
}
