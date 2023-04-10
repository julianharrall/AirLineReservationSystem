using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;

namespace AirLineReservationSystem
{
    public partial class FlightTabTest : Form
    {
        AirlineReservationDAL.AirlineReservation ar;
        //AirlineReservationDAL.AirlineReservation ar;
        Administration adf;// To allow closure of administration form          
        DateTimePicker pickerIn, pickerOut;        
        private DateTimePicker cellDateTimePicker;
        DateTime dateTimeDefault = new DateTime(9999, 01, 1, 12, 0, 0);
        String firstAirport;
        DataGridViewComboBoxColumn cmb;
        Table<AirlineReservationDAL.Flight> ft;
        Table<AirlineReservationDAL.Airport> aprts;
        Table<AirlineReservationDAL.Destination> cntry;
        Table<AirlineReservationDAL.Aircraft> acrft;
        ComboBox cmbx, cmba, cmbt;
        String selectedArpt, selectedDest, selectedAcftType;
        Boolean selectedArptBN, selectedDestBN, selectedAcftTypeB;
        int selectedArptX, selectedArptY;
        int selectedDestX, selectedDestY;
        int selectedAcftTypeX, selectedAcftTypeY;

        public string Checkdependency { get; set; }
        public List<string> lstFlightDependencies { get; set; }

        public bool ReseedFlightTable { get; set; }

        public FlightTabTest(Administration ad): this()
        {
            InitializeComponent();
            adf = ad;
            
            //ar = new AirlineReservationDAL.AirlineReservation();  
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CreateMyBorderlessWindow();


            this.cellDateTimePicker = new DateTimePicker();
            this.cellDateTimePicker.MinDate = DateTime.Now;
            this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            this.cellDateTimePicker.Visible = false;
            this.dgvFlights.Controls.Add(cellDateTimePicker);

            //ft = ar.GetTable<AirlineReservationDAL.Flight>();
            aprts = ar.GetTable<AirlineReservationDAL.Airport>();
            cntry = ar.GetTable<AirlineReservationDAL.Destination>();
            acrft = ar.GetTable<AirlineReservationDAL.Aircraft>();
            //datagridCombo(); jh

                        
            dgvFlights.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvFlights_DataBindingComplete);

            dgvFlights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvFlights.ReadOnly = false;        

            FormDateTimePicker(); // add DateTimePickers (Outward and Inward) to Form

            // add eventhandlers for both DateTimePickers when value changes
            pickerIn.ValueChanged += new EventHandler(pickerIn_ValueChanged);
            pickerOut.ValueChanged += new EventHandler(pickerOut_ValueChanged);

            populateCombos();

            lstFlightDependencies = (List<string>)CheckFlightDependencies();

            RefreshGrid();


        }

        private IEnumerable CheckFlightDependencies()
        {
            var AllFlights = from bk in ar.Booking
                              join fl in ar.Flight
                              on bk.FlightNumber equals fl.FlightNumber                              
                              select fl.FlightNum;

            IEnumerable AllFlightsDistinct = AllFlights.Distinct().ToList();

            return AllFlightsDistinct;
        }        

        public bool CheckReturnDependency(string aeroP)
        {
            foreach (var item in lstFlightDependencies)
            {
                if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public FlightTabTest()
        {
            if(ar is null)  
            ar = new AirlineReservationDAL.AirlineReservation();
            if(ft is null)  
            ft = ar.GetTable<AirlineReservationDAL.Flight>();
            
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvFlights.CurrentCell.Value = cellDateTimePicker.Value.ToString();//convert the date as per your format
            cellDateTimePicker.Visible = false;
        }

        public void datagridCombo()
        {
            //https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridviewcomboboxcell(v=vs.110).aspx
            int AllAirportsCount = (from ap in ar.Airport select new { ap.AirportName }).Count();
            cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Airport";
            cmb.Name = "cmb";
            cmb.ValueMember = "AirportName";
            cmb.DisplayMember = "AirportName";
            cmb.DataPropertyName = "Airport";
            cmb.DropDownWidth = 110;
            cmb.Width = 110;
            cmb.MaxDropDownItems = AllAirportsCount;
            cmb.FlatStyle = FlatStyle.Popup;

            //var qry = from a in ft
            //          select new
            //          {
            //              a.Airport.AirportName
            //          }.ToString();

            //List<string> listarprt = qry.ToList();


            var qry = from a in ft
                      select new
                      {
                          a.Airport.AirportName
                      };


            var AllAirports = from ap in ar.Airport select new { ap.AirportName };
            var AllAirportsString = from ap in ar.Airport select new { ap.AirportName }.ToString();
            List<string> allarprts = AllAirportsString.ToList();
            //firstAirport = listarprt.ElementAt(2); ;// First().AirportName.ToString();//allarprts.ElementAt(2);//            
            firstAirport = qry.First().AirportName.ToString();//allarprts.ElementAt(2);//
            cmb.DataSource = AllAirports;

        }

       


        // show date values when value changed - as default is blank
        void pickerOut_ValueChanged(object sender, EventArgs e)
        {
            // only change date format if blank
            if (pickerOut.CustomFormat == " ")
            {
                pickerOut.Format = DateTimePickerFormat.Custom;
                pickerOut.CustomFormat = "dd/MM/yyyy - HH:mm";
            }

            // ensure Outward date is always less than Inward
            if (pickerIn.CustomFormat == "dd/MM/yyyy - HH:mm")
            {
                if (pickerOut.Value >= pickerIn.Value)
                {
                    pickerOut.CustomFormat = " ";
                }
            }
            

        }

        // show date values when value changed - as default is blank
        void pickerIn_ValueChanged(object sender, EventArgs e)
        {
            // only change date format if blank
            if (pickerIn.CustomFormat == " ")
            {
                pickerIn.Format = DateTimePickerFormat.Custom;
                pickerIn.CustomFormat = "dd/MM/yyyy - HH:mm";
            }

            // ensure Inward date is always greater than Outward
            if (pickerOut.CustomFormat == "dd/MM/yyyy - HH:mm")
            {
                if (pickerOut.Value >= pickerIn.Value)
                {
                    pickerIn.CustomFormat = " ";
                }
            }
        }
               

        void dgvFlights_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //throw new NotImplementedException();
            dgvFlights.ClearSelection();
        }

        // remove the entire system menu:
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

        public void CreateMyBorderlessWindow()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        private void FlightB_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf = null;
            this.Close();
        }

        private void FlightE_Click_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FlightFMF_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }
        

        private void btnSearchFlights_Click(object sender, EventArgs e)
        {
            ListFlights();
        }

        private void RefreshGrid()
        {
            if (dgvFlights.ColumnCount > 0)
            {

                //dgvFlights.Columns.Remove(cmb);
                dgvFlights.DataSource = null;
                dgvFlights.Refresh();

                UpdateGridDependencies();

                dgvFlights.ClearSelection();
            }

            UpdateGridDependencies();
        }

        private void ListFlights()
        {
            RefreshGrid();           

            var qry = from b in ft
                       select new { b.FlightNum, b.AircraftNumb.AircraftType, b.Business, b.First, b.Economy, b.Seats, b.Airport.AirportName, b.Destination.Country, b.OutDateTime, b.InDateTime};
            
            dgvFlights.DataSource = qry;

            UpdateGridDependencies();

        }

        private void UpdateGridDependencies()
        {
            lstFlightDependencies = (List<string>)CheckFlightDependencies();
            for (int x = 0; x < dgvFlights.RowCount; x++)
            {
                if(dgvFlights.Rows[x].Cells[0].Value==null)
                    continue;
                Checkdependency = dgvFlights.Rows[x].Cells[0].Value.ToString().Trim();
                foreach (var item in lstFlightDependencies)
                {
                    if (item.Trim().ToLower() == Checkdependency.Trim().ToLower())
                    {
                        dgvFlights.Rows[x].Cells[2].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[0].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[1].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[0].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[1].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[2].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[3].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[4].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[5].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[3].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[4].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[5].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[6].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[7].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[8].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[6].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[7].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[8].Style.BackColor = Color.LightGray;
                        dgvFlights.Rows[x].Cells[9].ReadOnly = true;
                        dgvFlights.Rows[x].Cells[9].Style.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void dgvFlights_CellClick(object sender, DataGridViewCellEventArgs e)
        {            

            if (e.ColumnIndex != -1 & e.RowIndex != -1 & e.ColumnIndex != 0)
            {

                string val1 = dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
                string FlightNumber = dgvFlights.Rows[e.RowIndex].Cells[0].Value.ToString();
                string colName = dgvFlights.Columns[e.ColumnIndex].Name.ToString().Trim();

                if (CheckReturnDependency(FlightNumber))
                    return;

                // Do not allow xhange to Seats column
                if (colName == "Seats")
                {
                    return;
                }

                AirlineReservationDAL.Flight acft = ar.Flight.Single(a => a.FlightNum == FlightNumber);

                // Mark cell as selected
                dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.DarkSlateGray;
                dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;                
                dgvFlights.Refresh();
                UpdateGridDependencies();


                string CellType = dgvFlights.Columns[e.ColumnIndex].ValueType.ToString();
                //System.String, AirlineReservationDAL.Aircraft, AirlineReservationDAL.Airport, AirlineReservationDAL.Destination, System.Nullable`1[System.DateTime], System.Decimal
                //switch (CellType)
                //{
                //    case "System.String":
                //        cellChangeValue("String", e.RowIndex,e.ColumnIndex);
                //        break;
                //    case "System.Nullable`1[System.DateTime]":
                //        cellChangeValue("DateTime", e.RowIndex,e.ColumnIndex);
                //        //DateTime dt = DateTimePopUp((int)e.ColumnIndex, (int)e.RowIndex);
                //        CreateMyDateTimePicker();
                //        break;
                //    case "System.Decimal":
                //        cellChangeValue("Decimal", e.RowIndex, e.ColumnIndex);
                //        break;
                //    case "AirlineReservationDAL.Aircraft":
                //        cellChangeValue("Aircraft", e.RowIndex, e.ColumnIndex);
                //        break;
                //    case "AirlineReservationDAL.Airport":
                //        cellChangeValue("Airport", e.RowIndex, e.ColumnIndex);
                //        break;
                //    case "AirlineReservationDAL.Destination":
                //        cellChangeValue("Destination", e.RowIndex, e.ColumnIndex);
                //        break;
                //    default:
                //        Console.WriteLine("Default case");
                //        break;
                //}
                                                
                if (CellType.Contains("DateTime")) // "System.Nullable`1[System.DateTime]"
                {
                    //AirlineReservationDAL.Flight acft = ar.Flight.Single(a => a.FlightNum == FlightNumber);
                    DateTime dtOriginal = Convert.ToDateTime(dgvFlights[e.ColumnIndex, e.RowIndex].Value);
                    DateTime dtNew = DateTimePopUp((int)e.ColumnIndex, (int)e.RowIndex);

                    if (dtNew == dateTimeDefault)
                    {
                        dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                        dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                        dgvFlights.Refresh();
                        UpdateGridDependencies();
                        return;
                    }

                   //add to database
                    try
                    {
                        switch (colName)
                        {
                            case "OutDateTime":
                                acft.OutDateTime = dtNew;
                                break;
                            case "InDateTime":
                                acft.InDateTime = dtNew;
                                break;
                            default:
                                MessageBox.Show("Error with reading Destination Column Header", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }

                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + "\nFrom: " + dtOriginal + "\nTo: " + dtNew, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ar.SubmitChanges();
                            ListFlights();
                            //MessageBox.Show("New " + colName + " value changed: " + val2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                        throw ex;
                    }

                    
                }
                else if (colName=="AirportName")
                {
                   // MessageBox.Show("AirportName");
                    try
                    {
                        String NewAirport = AirportComboPopUp((int)e.ColumnIndex, (int)e.RowIndex);
                        if (NewAirport == "")
                        {
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                            dgvFlights.Refresh();
                            UpdateGridDependencies();
                            return;
                        }
                        AirlineReservationDAL.Airport arp = ar.Airport.Single(a => a.AirportName == NewAirport);
                        acft.Airport = arp;

                        //ar.Airport.InsertOnSubmit(arp);
                        //ar.SubmitChanges();

                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + NewAirport, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ar.SubmitChanges();
                            ListFlights();
                            //MessageBox.Show("New " + colName + " value changed: " + val2);
                        }    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                        throw ex;
                    }
                
                }
                else if (colName == "Country")
                {                    
                    try
                    {
                        String NewDest = CountryComboPopUp((int)e.ColumnIndex, (int)e.RowIndex);
                        if (NewDest == "")
                        {
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                            dgvFlights.Refresh();
                            UpdateGridDependencies();
                            return;
                        }
                        AirlineReservationDAL.Destination dest = ar.Destination.Single(d => d.Country == NewDest);
                        acft.Destination = dest;

                        //ar.Airport.InsertOnSubmit(arp);
                        //ar.SubmitChanges();

                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + NewDest, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ar.SubmitChanges();
                            ListFlights();
                            //MessageBox.Show("New " + colName + " value changed: " + val2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                        throw ex;
                    }
                }
                else if (colName == "AircraftType")
                {
                    try
                    {
                        String NewAcftType = AircraftTypeComboPopUp((int)e.ColumnIndex, (int)e.RowIndex);
                        if (NewAcftType == "")
                        {
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                            dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                            dgvFlights.Refresh();
                            UpdateGridDependencies();
                            return;
                        }
                        AirlineReservationDAL.Aircraft aType = ar.Aircraft.Single(at => at.AircraftType == NewAcftType);
                        acft.AircraftNumb = aType;

                        //ar.Airport.InsertOnSubmit(arp);
                        //ar.SubmitChanges();

                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + NewAcftType, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ar.SubmitChanges();
                            ListFlights();
                            //MessageBox.Show("New " + colName + " value changed: " + val2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                        throw ex;
                    }
                }
                else //if (dgvFlights[e.ColumnIndex, e.RowIndex].Value == null) // no current value
                {
                    string val2;
                    if (dgvFlights[e.ColumnIndex, e.RowIndex].Value == null) // no current value
                        val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvFlights[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString() + " (Edit/Change Value)");
                    else
                        val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvFlights[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString() + " (Edit/Change Value)", dgvFlights[e.ColumnIndex, e.RowIndex].Value.ToString());
                    //If the user clicks Cancel, a zero-length string is returned.

                    //if (val2.Length == 0)
                    //{

                    //    MessageBox.Show("cancel");
                    //}
                    if (val2.Length != 0 && val1 != val2)
                    {
                        // add date to db
                        dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                        dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                        dgvFlights.Refresh();
                       
                        //add to database
                        try
                        {
                            //add to database
                            //AirlineReservationDAL.Flight acft = ar.Flight.Single(a => a.FlightNum == FlightNumber);
                            //var flghts = ar.Flight.Where(f => f.FlightNum == "flt1234").Single();
                            switch (colName)
                            {
                                case "FlightNum":
                                    acft.FlightNum = val2;
                                    break;
                                case "Business":
                                    acft.Business = Convert.ToDecimal(val2);
                                    break;
                                case "Economy":
                                    acft.Economy = Convert.ToDecimal(val2);
                                    break;
                                case "First":
                                    acft.First = Convert.ToDecimal(val2);
                                    break;
                                case "OutDateTime":
                                    acft.OutDateTime = Convert.ToDateTime(val2);
                                    break;
                                case "InDateTime":
                                    acft.OutDateTime = Convert.ToDateTime(val2);
                                    break;
                                //case "AircraftNumb":
                                //    ar.Flight.Where(f => f.FlightNum == "flt1234").Single().AircraftNumb = ar.Aircraft.Single(a => a.AircraftType == val2);
                                //    break;
                                default:
                                    MessageBox.Show("Error with reading Destination Column Header", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                            }

                            DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + val2, "Confirm Changes", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ar.SubmitChanges();
                                ListFlights();
                                //MessageBox.Show("New " + colName + " value changed: " + val2);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                            throw ex;
                        }
                    }
                }
                dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                dgvFlights.Refresh();

                
            }

            UpdateGridDependencies();
        }

        private void FormDateTimePicker()
        {
            //FormDateTimePicker(pickerIn, 39, 265); // add DateTimePicker (Outward) to Form
            //FormDateTimePicker(pickerOut, 39, 340); // add DateTimePicker (Inward) to Form  
            pickerIn = new DateTimePicker();
            pickerIn.MinDate = DateTime.Now;
            pickerIn.Format = DateTimePickerFormat.Custom;
            pickerIn.CustomFormat = " ";
            pickerIn.CalendarTitleBackColor = Color.Blue;
            pickerIn.CalendarTitleForeColor = Color.Blue;

            pickerIn.CalendarForeColor = Color.Blue;
            pickerIn.SetBounds(39, 340, 200, 75);
            groupBox4.Controls.Add(pickerIn);

            this.Controls.Add(groupBox4);

            pickerOut = new DateTimePicker();
            pickerOut.MinDate = DateTime.Now;
            pickerOut.Format = DateTimePickerFormat.Custom;
            pickerOut.CustomFormat = " ";
            pickerOut.CalendarTitleBackColor = Color.Blue;
            pickerOut.CalendarTitleForeColor = Color.Blue;

            pickerOut.CalendarForeColor = Color.Blue;
            pickerOut.SetBounds(39, 265, 200, 75);
            groupBox4.Controls.Add(pickerOut);

            this.Controls.Add(groupBox4);
        }

        public String AirportComboPopUp(int colI, int rowI)
        {
            var qry = from b in aprts
                      select  b.AirportName;             

            cmba = new ComboBox();

            cmba.KeyPress += new KeyPressEventHandler(cmba_KeyPress);

            cmba.SelectedIndexChanged += new EventHandler(cmba_SelectedIndexChanged);
 
            //int i =0;
            //foreach (string x in qry)
            //{          
            //    cmbx.Items.Insert(i, x);
            //        i += 1;
            //}

            //string initvalue = dgvFlights[colI, rowI].Value.ToString();           
            //cmba.SelectedText = initvalue;
            selectedArptBN = true;
            //cmba.Text = initvalue;

            selectedArptX = colI;
            selectedArptY = rowI;

            Form f = new Form();
            f.Height = 130;
            f.Width = 170;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Controls.Add(cmba);

            cmba.Width = 110;
            cmba.Location = new Point(18, 15);
            cmba.Font = new Font("Comic Sans MS", 12);
            cmba.DataSource = qry;

            Button btnOK = new Button();
            btnOK.Width = 60;
            Button btCan = new Button();
            btCan.Width = 60;
            btnOK.Text = "OK";
            btCan.Text = "CANCEL";
            btnOK.Location = new Point(10, 63);
            btCan.Location = new Point(73, 63);
            btnOK.DialogResult = DialogResult.OK;
            btCan.DialogResult = DialogResult.Cancel;
            f.AcceptButton = btnOK;
            f.AcceptButton = btCan;

            f.StartPosition = FormStartPosition.CenterScreen;

            f.Controls.Add(btnOK);
            // Add button2 to the form.
            f.Controls.Add(btCan);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedArpt == null) return "";
                else return selectedArpt;
            }
            else return "";
        }

        void cmba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedArptBN)
            {
                string initvalue = dgvFlights[selectedArptX, selectedArptY].Value.ToString();
                cmba.Text = initvalue;
                selectedArptBN = false;
            }
            else
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                //string val = cmb.Items.ToString(); IndexOf(selectedIndex).ToString(); ;
                selectedArpt = cmb.SelectedItem.ToString(); ;
            }
        }
        
        public string CountryComboPopUp(int colI, int rowI)
        {
            var qry = from b in cntry
                      select b.Country;

            cmbx = new ComboBox();

            cmbx.KeyPress += new KeyPressEventHandler(cmbx_KeyPress);

            
            cmbx.SelectedIndexChanged += new EventHandler(cmbx_SelectedIndexChanged);       

            //int i = 0;
            //foreach (string x in qry)
            //{
            //    cmbx.Items.Insert(i, x);
            //    i += 1;
            //}
            

            //string initvalue = dgvFlights[colI, rowI].Value.ToString();
            //cmbx.Text = initvalue;

            selectedDestBN = true;
            //cmba.Text = initvalue;

            selectedDestX = colI;
            selectedDestY = rowI;
            
            Form f = new Form();
            f.Height = 130;
            f.Width = 170;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Controls.Add(cmbx);

            cmbx.Width = 110;
            cmbx.Location = new Point(18, 15);
            cmbx.Font = new Font("Comic Sans MS", 12);
            cmbx.DataSource = qry;

            Button btnOK = new Button();
            btnOK.Width = 60;
            Button btCan = new Button();
            btCan.Width = 60;
            btnOK.Text = "OK";
            btCan.Text = "CANCEL";
            btnOK.Location = new Point(10, 63);
            btCan.Location = new Point(73, 63);
            btnOK.DialogResult = DialogResult.OK;
            btCan.DialogResult = DialogResult.Cancel;
            f.AcceptButton = btnOK;
            f.AcceptButton = btCan;

            f.StartPosition = FormStartPosition.CenterScreen;

            f.Controls.Add(btnOK);
            // Add button2 to the form.
            f.Controls.Add(btCan);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedDest == null) return "";
                else return selectedDest;

            }
            else return "";


        }

        public string AircraftTypeComboPopUp(int colI, int rowI)
        {
            var qry = from a in acrft
                      select a.AircraftType;

            cmbt = new ComboBox();
                       
            cmbt.KeyPress += new KeyPressEventHandler(cmbt_KeyPress);

            cmbt.SelectedIndexChanged += new EventHandler(cmbt_SelectedIndexChanged);
            
            selectedAcftTypeB = true;
            //cmba.Text = initvalue;

            selectedAcftTypeX = colI;
            selectedAcftTypeY = rowI;

            Form f = new Form();
            f.Height = 130;
            f.Width = 170;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Controls.Add(cmbt);

            cmbt.Width = 110;
            cmbt.Location = new Point(18, 15);
            cmbt.Font = new Font("Comic Sans MS", 12);
            cmbt.DataSource = qry;

            Button btnOK = new Button();
            btnOK.Width = 60;
            Button btCan = new Button();
            btCan.Width = 60;
            btnOK.Text = "OK";
            btCan.Text = "CANCEL";
            btnOK.Location = new Point(10, 63);
            btCan.Location = new Point(73, 63);
            btnOK.DialogResult = DialogResult.OK;
            btCan.DialogResult = DialogResult.Cancel;
            f.AcceptButton = btnOK;
            f.AcceptButton = btCan;

            f.StartPosition = FormStartPosition.CenterScreen;

            f.Controls.Add(btnOK);
            // Add button2 to the form.
            f.Controls.Add(btCan);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selectedAcftType == null) return "";
                else return selectedAcftType;

            }
            else return "";

        }

        void cmbt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAcftTypeB)
            {
                string initvalue = dgvFlights[selectedAcftTypeX, selectedAcftTypeY].Value.ToString();
                cmbt.Text = initvalue;
                selectedAcftTypeB = false;
            }
            else
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                //int selectedValue = (int)cmb.SelectedValue;
                //string val = cmb.Items.ToString(); IndexOf(selectedIndex).ToString(); ;
                selectedAcftType = cmb.SelectedItem.ToString();
            }
        }

        void cmbt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedDestBN)
            {
                string initvalue = dgvFlights[selectedDestX, selectedDestY].Value.ToString();
                cmbx.Text = initvalue;
                selectedDestBN = false;
            }
            else
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                //int selectedValue = (int)cmb.SelectedValue;
                //string val = cmb.Items.ToString(); IndexOf(selectedIndex).ToString(); ;
                selectedDest = cmb.SelectedItem.ToString();
            }
        }



        void cmbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;

        }

        void cmba_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;

        }

        public DateTime DateTimePopUp(int colI, int rowI)
        {
            
            if (dgvFlights[colI, rowI].Value == null)
            {

            }
                        
            var picker = new DateTimePicker();
            picker.MinDate = DateTime.Now;
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "dd/MM/yyyy - HH:mm";
            picker.Value = Convert.ToDateTime(dgvFlights[colI, rowI].Value); // set current value
            picker.SetBounds(10, 20, 135, 100);

            Form f = new Form();           
            f.Height = 130;
            f.Width = 180;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;                
            f.Controls.Add(picker);      
                    
            Button btnOK = new Button();
            btnOK.Width= 60;
            Button btCan = new Button();
            btCan.Width= 60;
            btnOK.Text = "OK";
            btCan.Text = "Cancel";
            btnOK.Location = new Point(10, 63 );
            btCan.Location = new Point(83,63);
            btnOK.DialogResult = DialogResult.OK;            
            btCan.DialogResult = DialogResult.Cancel;

            f.AcceptButton = btnOK;
            f.AcceptButton = btCan;
            
            f.StartPosition = FormStartPosition.CenterScreen;

            f.Controls.Add(btnOK);
            // Add button2 to the form.
            f.Controls.Add(btCan);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                string currCellVal = picker.Value.ToString(); ;
                char[] c = new char[] { '/', ' ', ':' };
                string[] s = currCellVal.Split(c);
                return picker.Value = new DateTime(Convert.ToInt16(s[2]), Convert.ToInt16(s[1]), Convert.ToInt16(s[0]), Convert.ToInt16(s[3]), Convert.ToInt16(s[4]), 00);

            }
            else
                return dateTimeDefault;
        
        }

        //https://www.google.co.uk/?gws_rd=ssl#q=change+datetimepicker+on+form+to+show+date+and+time+c%23
        //http://msdn.microsoft.com/en-us/library/system.windows.forms.datetimepicker(v=vs.90).aspx
        public void CreateMyDateTimePicker()
        {
            // Create a new DateTimePicker control and initialize it.
            DateTimePicker dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.MinDate = DateTime.Now;

            // Set the MinDate and MaxDate.
            dateTimePicker1.MinDate = new DateTime(1985, 6, 20);
            dateTimePicker1.MaxDate = DateTime.Today;

            // Set the CustomFormat string.
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            // Show the CheckBox and display the control as an up-down control.
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.ShowUpDown = true;
            this.Controls.Add(dateTimePicker1);
        }


        private void DeleteFlight(string arfrftType)
        {
            AirlineReservationDAL.Flight at = ar.Flight.Single(f => f.FlightNum == arfrftType);
           
            ar.Flight.DeleteOnSubmit(at);
            try
            {
                ar.SubmitChanges();
                //MessageBox.Show("AircraftType: " + at.AircraftType + "Successfully Deleted");
                ListFlights();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }

        }

        private void dgvFlights_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 & e.RowIndex != -1)
            {


            }

        }

        internal void FlightCleanup()
        {

            Table<AirlineReservationDAL.Flight> ft = ar.GetTable<AirlineReservationDAL.Flight>();
            
            var command = $"sp_CleanUpFlights";
           
            var affectedDatas = ar.ExecuteCommand(command);
            
            try
            {
                ar.SubmitChanges();
                //MessageBox.Show("New Flight added: ");
                //ListFlights();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }
            
        }

        private void dgvFlights_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string FlightD;
            if (e.ColumnIndex == -1 & e.RowIndex != -1)
            {
                FlightD = dgvFlights.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                int ri = e.RowIndex + 1;

                if (CheckReturnDependency(FlightD))
                    return;

                //dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgvFlights.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;

                UpdateGridDependencies();   

                if (MessageBox.Show("## DELETE FLIGHT " + FlightD + " ##", " DELETING FLIGHT " + FlightD, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("## ARE YOU SURE YOU WISH TO DELETE FLIGHT " + FlightD + " !!!! ##", " DELETING FLIGHT " + FlightD + " CONFIRMATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("AIRCRAFT" + aeroP + " DELETED");
                        DeleteFlight(FlightD);
                        ListFlights();
                        return;
                    }

                // Deletion Cancelled
                //dgvFlights.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Maroon;
                //dgvFlights.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                ListFlights();

            }
        }

        private void dgvFlights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string obj = dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            //dgvFlights.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "bum";
        }

        private void dgvFlights_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab && dgvFlights.CurrentCell.ColumnIndex == 1)
            //{
            //    e.Handled = true;
            //    DataGridViewCell cell = dgvFlights.Rows[0].Cells[0];
            //    dgvFlights.CurrentCell = cell;
            //    dgvFlights.BeginEdit(true);
            //}
            
        }

        //https://www.c-sharpcorner.com/blogs/execute-store-procedure-in-entity-framework
        private void btnAddtestFlights_Click(object sender, EventArgs e)
        {
            Table<AirlineReservationDAL.Flight> ft = ar.GetTable<AirlineReservationDAL.Flight>();
            //ar.Flight.DeleteAllOnSubmit(ft);

            AdminLogin testDialog = new AdminLogin();
            //AirLineReservationSystem.Admin.AdminLogins testDialog = new AirLineReservationSystem.Admin.AdminLogins("Database");
            //AirLineReservationSystem.Admin.AdminRestoreDBLogin testDialog = new AirLineReservationSystem.Admin.AdminRestoreDBLogin();
            testDialog.Text = "Add Test Flights";
            testDialog.ShowDialog(this);

            if (!testDialog.AdminDBAccess) 
             return ;





            var command = "";
            if(ReseedFlightTable == true)
            {
                command = $"sp_CreateNewFlights 1";
            }
            else
            {
                command = $"sp_CreateNewFlights 0";
            }
            
            //var affectedDatas = context.Database.ExecuteSqlCommand(command);
            var affectedDatas = ar.ExecuteCommand(command);

            /*
            AirlineReservationDAL.Flight flt = new AirlineReservationDAL.Flight
            {
                FlightNum = tbxFlightNo.Text,
                OutDateTime = outdt,
                InDateTime = indt,
                Business = Convert.ToDecimal(txtBusiness.Text),
                First = Convert.ToDecimal(txtFirst.Text),
                Economy = Convert.ToDecimal(txtEconomy.Text)
            };
            ar.Flight.InsertOnSubmit(flt);
            */
            try
            {
                ar.SubmitChanges();
                //MessageBox.Show("New Flight added: ");
                ListFlights();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }
            


        }

        
        private void cbReseed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReseed.Checked)
            {
                ReseedFlightTable = true;
            }
            else
            {
                ReseedFlightTable = false;
            }
                   
        }

        private void FlightTabTest_Paint(object sender, PaintEventArgs e)
        {
            AirportTab.boolEnterAirports = false;
            RefreshGrid();
        }

        private void dgvFlights_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object x = e.Value;
                UpdateGridDependencies();
            }
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            DateTime outdt ;
            DateTime indt ;

            // ensure have both outward and inward date - to continue
            if (pickerOut.CustomFormat != " " && pickerIn.CustomFormat != " ")
            {
                outdt = pickerOut.Value;
                indt = pickerIn.Value;
            }
            else 
                return;

            // ensure have at least one price for Flight
            //if (txbxFlightPrice.Text.Trim().Length == 0 && txbxEconomy.Text.Trim().Length == 0 && txbxFirst.Text.Trim().Length == 0) return;          
            
            // ensure have Flight Number - to continue
            if (tbxFlightNo.Text.Trim().Length == 0) return;

            //AirlineReservationDAL.Flight at = ar.Flight.Contains(f => f.FlightNum == tbxFlightNo.Text.Trim());
           
            Table<AirlineReservationDAL.Flight> ft = ar.GetTable<AirlineReservationDAL.Flight>();
            var qry = from b in ft select b;
            bool flightNumExists = qry.Any(f => f.FlightNum == tbxFlightNo.Text.Trim());

            if (flightNumExists)
            {
                MessageBox.Show("Flight Number " + tbxFlightNo.Text.Trim() + " already exists\n\nPlease enter a new Flight Number ", "Duplicate Flight Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ensure have Airport - to continue
            if (cmbAirport.Text.Trim().Length == 0) return;
            // ensure have Destination - to continue
            if (cmbDestination.Text.Trim().Length == 0) return;
            // ensure have Aircraft - to continue
            if (cmbAircraft.Text.Trim().Length == 0) return;

            AirlineReservationDAL.Aircraft selectedAircraft = ar.Aircraft.Single(af => af.AircraftType == cmbAircraft.Text);
            int seatCapacity = Convert.ToInt32(selectedAircraft.SeatCapacity);

            //AirlineReservationDAL.Flight flt = new AirlineReservationDAL.Flight { FlightNum = tbxFlightNo.Text, FlightPrice= Convert.ToDecimal( txbxFlightPrice.Text), OutDateTime = outdt, InDateTime = indt };
            AirlineReservationDAL.Flight flt = new AirlineReservationDAL.Flight { FlightNum = tbxFlightNo.Text, OutDateTime = outdt, InDateTime = indt,
            Business= Convert.ToDecimal( txtBusiness.Text), First= Convert.ToDecimal( txtFirst.Text), Economy= Convert.ToDecimal( txtEconomy.Text), Seats = seatCapacity};
            ar.Flight.InsertOnSubmit(flt);
            
            // add to selected destination
            AirlineReservationDAL.Destination selectedDest = ar.Destination.Single(d => d.Country == cmbDestination.Text);
            selectedDest.Flights.Add(flt);
            //ar.SubmitChanges();

            // add to selected Aircraft
            //AirlineReservationDAL.Aircraft selectedAircraft = ar.Aircraft.Single(af => af.AircraftType == cmbAircraft.Text);
            selectedAircraft._flightAcfts.Add(flt);

            int seats = Convert.ToInt32(selectedAircraft.SeatCapacity);

            // add to selected Airport
            AirlineReservationDAL.Airport selectedAirport = ar.Airport.Single(a => a.AirportName == cmbAirport.Text);
            selectedAirport.AptFlights.Add(flt);          

            try
            {
                ar.SubmitChanges();
                //MessageBox.Show("New Flight added: ");
                ListFlights();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }
            finally
            {
                // blank all fields
                pickerOut.CustomFormat = " ";
                pickerIn.CustomFormat = " ";
                cmbAirport.SelectedIndex = -1;
                cmbDestination.SelectedIndex = -1;
                cmbAircraft.SelectedIndex = -1;
                tbxFlightNo.Text = "";
                txtBusiness.Text = "";
                txtEconomy.Text = "";
                txtFirst.Text = "";
            }
        }

        private void populateCombos()
        {
            populateAirport();
            populateDestination();
            populateAircraft();           
        }

        private void populateAirport()
        {
            Table<AirlineReservationDAL.Airport> ap = ar.GetTable<AirlineReservationDAL.Airport>();
            var qryApt = from a in ap select new { a.AirportName };
            cmbAirport.DataSource = qryApt;
            cmbAirport.ValueMember = "AirportName";
            cmbAirport.DisplayMember = "AirportName";
            cmbAirport.SelectedIndex = -1;
        }

        private void populateDestination()
        {
            Table<AirlineReservationDAL.Destination> ds = ar.GetTable<AirlineReservationDAL.Destination>();
            var qryDest = from d in ds select new { d.Country };
            cmbDestination.DataSource = qryDest;
            cmbDestination.ValueMember = "Country";
            cmbDestination.DisplayMember = "Country";
            cmbDestination.SelectedIndex = -1;
        }

        private void populateAircraft()
        {
            Table<AirlineReservationDAL.Aircraft> acft = ar.GetTable<AirlineReservationDAL.Aircraft>();
            var qryArcrft = from ac in acft select new { ac.AircraftType };
            cmbAircraft.DataSource = qryArcrft;
            cmbAircraft.ValueMember = "AircraftType";
            cmbAircraft.DisplayMember = "AircraftType";
            cmbAircraft.SelectedIndex = -1; 
        }

        private void cmbAirpot_Click(object sender, EventArgs e)
        {
            populateAirport();
        }

        private void cmbDestination_Click(object sender, EventArgs e)
        {
            populateDestination();
        }

        private void cmbAircraft_Click(object sender, EventArgs e)
        {
            populateAircraft();
        }

        

        private void dgvFlights_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvFlights.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            //if (e.Control is ComboBox)
            //{
            //    ComboBox comboBox = e.Control as ComboBox;
            //    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged        ;
            //}


        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            //var currentcell = dgvFlights.CurrentCellAddress;
            //var sendingCB = sender as DataGridViewComboBoxEditingControl;
            //DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dgvFlights.Rows[currentcell.Y].Cells[0];
            //cel.Value = sendingCB.EditingControlFormattedValue.ToString();
        }

       

       



        

       
    }
    
}
