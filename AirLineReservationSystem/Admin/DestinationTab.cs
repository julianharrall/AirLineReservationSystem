using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace AirLineReservationSystem
{
    public partial class DestinationTab : Form
    {
        AirlineReservationDAL.AirlineReservation ar;
        DataGridViewButtonColumn btnDest;
        //AirlineReservationDAL.AirlineReservation ar;
        Administration adf;// To allow closure of administration form      
        Image destinationImage;
        string txtDestinationImage;
        public string ShowDestinationImageName { get; set; }
        List<string> showdestination = new List<string>();
        public byte[] DestinationImageBytes { get; set; }
        public Image destinationImageFromBtyes { get; set; }       
        public Form destinationImageFrm { get; set; }
        public Button ChangeDest { get; set; }        
        public Button SaveDestImage { get; set; }
        public Button CancelDestImage { get; set; }
        public ComboBox cmbx { get; set; }
        public int selectedDestTypeX { get; set; }
        public int selectedDestTypeY { get; set; }
        public Boolean selectedDestTypeB { get; set; }
        public string Checkdependency { get; set; }
        public List<string> lstDestinationDependencies { get; set; }

        public DestinationTab(Administration ad)
        {
            InitializeComponent();
            adf = ad;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            ar = new AirlineReservationDAL.AirlineReservation();       
            CreateMyBorderlessWindow();

            dgvSMDestination.AutoSizeColumnsMode =
           DataGridViewAutoSizeColumnsMode.AllCells;

            //dgvSMDestination.EditMode = DataGridViewEditMode.EditOnEnter;
            //dgvSMDestination.ReadOnly = false;
            //

            //CheckDestinationDependencies();

            lstDestinationDependencies = (List<string>)CheckDestinationDependencies();

            AirportTab.boolEnterAirports = false;
            RefreshGrid();

        }

        private IEnumerable CheckDestinationDependencies()
        {


            var AllDestination = from bk in ar.Booking
                              join fl in ar.Flight
                              on bk.FlightNumber equals fl.FlightNumber
                              join des in ar.Destination
                              on fl.DestID equals des.DestID
                              select des.Airport;


            IEnumerable AllDestinationDistinct = AllDestination.Distinct().ToList();

            return AllDestinationDistinct;


        }

        public DestinationTab()
        {
            
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

        /*
         int AircraftFlag = 0;
            AirlineReservationDAL.Aircraft arcft = new AirlineReservationDAL.Aircraft { AircraftType = txtAircraft.Text, SeatCapacity = txtSeat.Text, AImage = (byte[])new ImageConverter().ConvertTo(arcrftImage, typeof(byte[])) };
            if (String.IsNullOrEmpty(txtAircraft.Text)) { lblAircraft.Text = "Please Enter Aircraft Name"; AircraftFlag += 1; }
            else lblAircraft.Text = "";
            if (String.IsNullOrEmpty(txtSeat.Text)) { lblSeat.Text = "Please Enter Seat Capacity"; AircraftFlag += 1; }
            else lblSeat.Text = "";
            if ((picBxThumb.Image==null)) { lblImage.Text = "Please Select Image"; AircraftFlag += 1; }
            else lblImage.Text = "";

            if (AircraftFlag > 0) return;

            try
            {
                ar.Aircraft.InsertOnSubmit(arcft);
                ar.SubmitChanges();
                txtAircraft.Text = "";
                txtSeat.Text = "";
                //txtAircraftImage.Text = "";
                picBxThumb.Image = null;
                ListAircraft();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                lblAircraftMessage.Text = ex.Message.ToString();
            }
            finally
            {
                arcrftImage = null;
            }     
        */

        //TOD: add destination image
        private void btnAddDestination_Click(object sender, EventArgs e)
        {
            int destFlag = 0;
            AirlineReservationDAL.Destination dest = new AirlineReservationDAL.Destination { Country = txtCountry.Text, Airport = txtAirport.Text, Gate = txtGate.Text , DestImage = (byte[])new ImageConverter().ConvertTo(destinationImage, typeof(byte[])) };
            //Aircraft arcft = new AirlineReservationDAL.Aircraft { AircraftType = txtAircraft.Text, SeatCapacity = txtSeat.Text, AImage = (byte[])new ImageConverter().ConvertTo(arcrftImage, typeof(byte[])) };

            if (String.IsNullOrEmpty(txtAirport.Text)) { lblAirport.Text = "Please Enter Airport"; destFlag += 1; }
            else lblAirport.Text = "";
            if (String.IsNullOrEmpty(txtCountry.Text)) { lblCountry.Text = "Please Enter Country"; destFlag += 1; }
            else lblCountry.Text = "";
            if (String.IsNullOrEmpty(txtGate.Text)) { lblGate.Text = "Please Enter Gate"; destFlag += 1; }
            else lblGate.Text = "";

            if ((picDestThumb.Image == null)) { lblImage.Text = "Please Select Image"; destFlag += 1; }
            else lblImage.Text = "";

            //if (String.IsNullOrEmpty(txtAircraft.Text)) { lblAircraft.Text = "Please Enter Aircraft Name"; AircraftFlag += 1; }
            //else lblAircraft.Text = "";
            //if (String.IsNullOrEmpty(txtSeat.Text)) { lblSeat.Text = "Please Enter Seat Capacity"; AircraftFlag += 1; }
            //else lblSeat.Text = "";
            //if ((picBxThumb.Image == null)) { lblImage.Text = "Please Select Image"; AircraftFlag += 1; }
            //else lblImage.Text = "";

            if (destFlag > 0) return;

            try
            {
                ar.Destination.InsertOnSubmit(dest);
                ar.SubmitChanges();
                //lblAirport.Text = txtAirport.Text;
                //lblCountry.Text = txtCountry.Text;
                //lblGate.Text = txtGate.Text;
                //lblDestMessage.Text = "Successfully Added Destination";
                ListDestinations();

                txtAirport.Text = "";
                txtCountry.Text = "";
                txtGate.Text = "";
                picDestThumb.Image = null;

                ListDestinations();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                lblDestMessage.Text = ex.Message.ToString();
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearchDest_Click(object sender, EventArgs e)
        {
            ListDestinations();
        }

        private void RefreshGrid()
        {
            if (dgvSMDestination.ColumnCount > 0)
            {
                dgvSMDestination.Columns.Remove(btnDest);
                dgvSMDestination.DataSource = null;
                dgvSMDestination.Refresh();
                dgvSMDestination.ClearSelection();
            }

        }

        //        How are you binding to your DataGridView? 
        //One thing is that if you are using a Linq list as the datasource queried from a database and you do not have the complete object, 
        //then the properties are readonly unless you specify "with new" in the select function. 
        private void ListDestinations()
        {
            /*
            if (dgvSMDestination.ColumnCount > 0)
            {
                dgvSMDestination.DataSource = null;
                dgvSMDestination.Refresh();
            }

            btnDest = new DataGridViewButtonColumn();

            dgvSMDestination.Columns.Add(btnDest);
            btnDest.HeaderText = "DestImage";
            btnDest.Text = "Image";
            btnDest.Name = "btn";

            var AllDestinations = from ds in ar.Destination select new { ds.Airport, ds.Country, ds.Gate, ds.DestImage };

            dgvSMDestination.DataSource = AllDestinations;
            */

            RefreshGrid();

            //var AllDestination = from ds in ar.Destination select new { ds.Airport, ds.Country, ds.Gate, ds.DestImage };
            var AllDestination = from ds in ar.Destination select new { ds.Airport, ds.Country, ds.Gate};

            dgvSMDestination.DataSource = AllDestination;

            dgvSMDestination.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSMDestination.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSMDestination.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            btnDest = new DataGridViewButtonColumn();

            dgvSMDestination.Columns.Add(btnDest);
            btnDest.HeaderText = "DestImage";
            btnDest.Text = "Image";
            btnDest.Name = "btn";

            lstDestinationDependencies = (List<string>)CheckDestinationDependencies();

            for (int x = 0; x < dgvSMDestination.RowCount; x++)
            {
                Checkdependency = dgvSMDestination.Rows[x].Cells[0].Value.ToString().Trim();
                foreach (var item in lstDestinationDependencies)
                {
                    if (item.Trim().ToLower() == Checkdependency.Trim().ToLower())
                    {
                        dgvSMDestination.Rows[x].Cells[2].ReadOnly = true;
                        dgvSMDestination.Rows[x].Cells[0].ReadOnly = true;
                        dgvSMDestination.Rows[x].Cells[1].ReadOnly = true;
                        dgvSMDestination.Rows[x].Cells[0].Style.BackColor = Color.LightGray;
                        dgvSMDestination.Rows[x].Cells[1].Style.BackColor = Color.LightGray;
                        dgvSMDestination.Rows[x].Cells[3].ReadOnly = true;
                        dgvSMDestination.Rows[x].Cells[2].Style.BackColor = Color.LightGray;
                        dgvSMDestination.Rows[x].Cells[3].Style.BackColor = Color.LightGray;
                        //dgvAircraftList.Rows[x].Cells[2].Style.BackColor = Color.Red;                        
                    }

                }
            }




                //http://stackoverflow.com/questions/19159801/c-sharp-datagridviewbuttoncell-set-buttons-text   
                //http://stackoverflow.com/questions/5473031/combobox-doesnt-allow-enter-custom-text-if-databinding-is-used
            for (int x = 0; x < dgvSMDestination.RowCount; x++)
            {
                //dgvAircraftList.Rows[x].Cells[2].ToolTipText = "Click to get " + dgvAircraftList.Rows[x].Cells[0].Value.ToString().Trim() + " image";
                dgvSMDestination.Rows[x].Cells[3].Value = dgvSMDestination.Rows[x].Cells[0].Value.ToString().Trim();
            }

        }

        private void ShowDestinationImage(string destimage, int colI, int rowI)
        {
            if (showdestination.Contains(destimage)) return;

            destinationImageFrm = new Form();
            //destinationImageFrm.FormClosed += new FormClosedEventHandler(aircrftImageFrm_FormClosed);
            destinationImageFrm.FormClosed += DestinationImageFrm_FormClosed;
            destinationImageFrm.Height = 600;
            destinationImageFrm.Width = 1000;
            DestinationImageBytes = ar.Destination.First(d => d.Airport == destimage).DestImage;
            destinationImageFromBtyes = Image.FromStream(new MemoryStream(DestinationImageBytes));
            //ai.RotateFlip(RotateFlipType.Rotate90FlipX);
            destinationImageFrm.BackgroundImage = destinationImageFromBtyes;
            destinationImageFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            destinationImageFrm.Text = destimage;

            //var qry = from ac in acrft
            //          select ac.AircraftType;
            //selectedAcftTypeX = colI;
            //selectedAcftTypeY = rowI;
            //cmbx = new ComboBox();
            //cmbx.SelectedIndexChanged += new EventHandler(cmbx_SelectedIndexChanged);
            //cmbx.KeyPress += new KeyPressEventHandler(cmbx_KeyPress);

            ChangeDest = new Button();
            //cmbx.Location = new Point(3, 28);
            ChangeDest.Location = new Point(3, 3);

            SaveDestImage = new Button();
            SaveDestImage.Click += SaveDestImage_Click;
            //SaveDestImage.Click += new EventHandler(saveImage_Click);
            SaveDestImage.Location = new Point(3, 28);
            SaveDestImage.Text = "Save";
            SaveDestImage.Enabled = false;

            CancelDestImage = new Button();
            CancelDestImage.Click += CancelDestImage_Click;
            //CancelDestImage.Click += new EventHandler(CancelImage_Click);
            CancelDestImage.Location = new Point(3, 53);
            CancelDestImage.Text = "Cancel";
            CancelDestImage.Enabled = false;

            //ChangeDest.Click += new EventHandler(Change_Click);
            ChangeDest.Click += ChangeDest_Click;
            ChangeDest.Text = "Change Image";
            ChangeDest.Width = 77;
            //cmbx.Height = 30;
            //cmbx.Width = 75;           

            destinationImageFrm.Controls.Add(ChangeDest);
            destinationImageFrm.Controls.Add(cmbx);
            destinationImageFrm.Controls.Add(SaveDestImage);
            destinationImageFrm.Controls.Add(CancelDestImage);
            showdestination.Add(destimage);
            destinationImageFrm.Show();

            selectedDestTypeB = true;
            //cmbx.DataSource = qry; // putting datasource here, fires cmbx_SelectedIndexChanged
        }

        private void DestinationImageFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form destclosingfrm = (Form)sender;
            showdestination.Remove(destclosingfrm.Text);

            destclosingfrm = null;
            destinationImageFrm = null;
        }

        private void ChangeDest_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelDestImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveDestImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf = null;
            this.Close();
        }

        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }

        private void DeleteDestination(string destinationDel)
        {
            AirlineReservationDAL.Destination ds = ar.Destination.Single(d => d.Airport == destinationDel);

            ar.Destination.DeleteOnSubmit(ds);
            try
            {
                ar.SubmitChanges();
                //MessageBox.Show("AircraftType: " + at.AircraftType + "Successfully Deleted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }

        }

        private void dgvSMDestination_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string destP;
            if (e.ColumnIndex == 3 & e.RowIndex != -1)
            {
                destP = dgvSMDestination.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                if (CheckReturnDependency(destP))
                    return;

                ShowDestinationImageName = dgvSMDestination.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                ShowDestinationImage(destP, (int)e.ColumnIndex, (int)e.RowIndex);
            }


           else if (e.ColumnIndex != -1 & e.RowIndex != -1)
            {

            string val1 = dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            string airportname = dgvSMDestination.Rows[e.RowIndex].Cells[0].Value.ToString();
            string colName = dgvSMDestination.Columns[e.ColumnIndex].Name.ToString();

                if (CheckReturnDependency(airportname))
                    return;

            dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.DarkSlateGray;
            dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
            dgvSMDestination.Refresh();

           
                ////dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "test";
                ////dgvSMDestination.Refresh();

                ////dgvSMDestination.BeginEdit(true); 

                string val2;
            if (dgvSMDestination[e.ColumnIndex, e.RowIndex].Value == null) // no current value
                val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvSMDestination[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString() + " (Edit/Change Value)");
            else
                val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvSMDestination[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString() + " (Edit/Change Value)", dgvSMDestination[e.ColumnIndex, e.RowIndex].Value.ToString());

            //if (val2.Length == 0) MessageBox.Show("cancel"); // Cancel change

            if (val2.Length != 0 && val1 != val2)
            {
                try
                {
                    //add to database
                    AirlineReservationDAL.Destination dst = ar.Destination.Single(d => d.Airport == airportname);

                    switch (colName)
                    {
                        case "Airport":
                            dst.Airport = val2;
                            break;
                        case "Country":
                            dst.Country = val2;
                            break;
                        case "Gate":
                            dst.Gate = val2;
                            break;
                        default:
                            MessageBox.Show("Error with reading Destination Column Header", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }

                    DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + val2, "Confirm Changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ar.SubmitChanges();
                        ListDestinations();
                        //MessageBox.Show("New " + colName + " value changed: " + val2);
                    }      
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                    throw ex;
                }

            }
               

            // add date to db
            dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
            dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
            dgvSMDestination.Refresh();


            }

            //DataGridViewCell cell = dgvSMDestination[e.ColumnIndex, e.RowIndex];
            //dgvSMDestination.CurrentCell.ReadOnly = false;
            //dgvSMDestination.CurrentCell = cell;
            //dgvSMDestination.BeginEdit(true);
        }

        public bool CheckReturnDependency(string aeroP)
        {
            foreach (var item in lstDestinationDependencies)
            {
                if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private void dgvSMDestination_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
              string  aeroP = dgvSMDestination.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
              //string aeroP = dgvSMDestination.Columns[dgvSMDestination.CurrentCell.ColumnIndex].Name;
                int ri = e.RowIndex + 1;

                if (CheckReturnDependency(aeroP))
                    return;

                //dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgvSMDestination.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;

                if (MessageBox.Show("## DELETE " + aeroP + " AIRPORT ##", " DELETING " + aeroP + " AIRPORT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("## ARE YOU SURE YOU WISH TO DELETE " + aeroP + " AIRPORT !!!! ##", " DELETING " + aeroP + " AIRPORT CONFIRMATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("AIRPORT" + aeroP + " DELETED");
                        DeleteDestination(aeroP);
                        ListDestinations();
                        return;
                    }

                // Deletion Cancelled
                //dgvSMDestination.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Maroon;
                //dgvSMDestination.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                ListDestinations();

            }
        }

        private void dgvSMDestination_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 & e.RowIndex != -1)
            {
                string aeroP = dgvSMDestination.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                if (CheckReturnDependency(aeroP))
                    return;

                dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.DarkSlateGray;
                dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
                //dgvSMDestination.Refresh();

                //dgvSMDestination.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "test";
                //dgvSMDestination.Refresh();            

            }
        }

       
        private void dgvSMDestination_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // stop first cell from highlighting
            dgvSMDestination.ClearSelection();
        }

        
        private void btnDestImageBrowse_Click(object sender, EventArgs e)
        {
            BrowseDestImage();
        }

        private void BrowseDestImage()
        {
            
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Destination Image (jpg)";
            fdlg.Filter = "Jpg files (*.jpg*)|*.jpg*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                destinationImage = Image.FromFile(fdlg.FileName);
                txtDestinationImage = fdlg.SafeFileName;
                picDestThumb.Image = destinationImage;//getThumbnail(fdlg.FileName);
                picDestThumb.SizeMode = PictureBoxSizeMode.Zoom;
            }
           
        }

        private void DestinationTab_Paint(object sender, PaintEventArgs e)
        {
            AirportTab.boolEnterAirports = false;
            RefreshGrid();
        }
    }
    }


