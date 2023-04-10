using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.Linq;
using System.Collections;


namespace AirLineReservationSystem
{
    public partial class AircraftTab : Form
    {

        DataGridViewButtonColumn btn;
        
        AirlineReservationDAL.AirlineReservation ar;
        Administration adf;// To allow closure of administration form
        Image arcrftImage;
        string txtAircraftImage;
        List<string> showimage = new List<string>();        
        public Form aircrftImageFrm { get; set; }
        Table<AirlineReservationDAL.Aircraft> acrft;
        int selectedAcftTypeX, selectedAcftTypeY;
        ComboBox cmbx;
        byte[] AircraftImageBytes ;
        Image aircraftImageFromBtyes;
        public Button saveImage { get; set; }
        public Button CancelImage { get; set; }
        public Button Change { get; set; }

        public string Checkdependency  { get; set; }

        Boolean selectedAcftTypeB;      
        string initvalue_cmbx;
        ComboBox cmb_can;

        public List<string> lstAircraftDependencies { get; set; }

        string selectedValueImage;
        string fileimagename;
        string ShowAircraftImageName;

        public AircraftTab(Administration ad)
        {
            InitializeComponent();
            adf = ad;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            ar = new AirlineReservationDAL.AirlineReservation();           
            CreateMyBorderlessWindow();    
            dgvAircraftList.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;

            acrft = ar.GetTable<AirlineReservationDAL.Aircraft>();

            lstAircraftDependencies = (List<string>)CheckAircraftDependencies();

            
            
            RefreshGrid();
        }

        private IEnumerable CheckAircraftDependencies()
        {      
                var AllAircraft = from bk in ar.Booking
                                  join fl in ar.Flight
                                  on bk.FlightNumber equals fl.FlightNumber
                                  join arc in ar.Aircraft
                                  on fl.AircraftNumber equals arc.AircraftNumber
                                  select arc.AircraftType;

                IEnumerable AllAircraftDistinct = AllAircraft.Distinct().ToList();

                return AllAircraftDistinct;            
        }


        public AircraftTab()
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

        private void AircraftE_Click_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AircraftB_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender,e);
            adf = null;
            this.Close();       
        }       
               
        private void btnArcftList_Click(object sender, EventArgs e)
        {
            ListAircraft();
        }

        private void RefreshGrid()
        {
            if (dgvAircraftList.ColumnCount > 0)
            {
                dgvAircraftList.Columns.Remove(btn);
                dgvAircraftList.DataSource = null;                
                dgvAircraftList.ClearSelection();
                dgvAircraftList.Refresh();
            }
        }

        private void ListAircraft()
        {
            RefreshGrid();


            var AllAircraft = from ac in ar.Aircraft select new { ac.AircraftType, ac.SeatCapacity };

            dgvAircraftList.DataSource = AllAircraft;

            dgvAircraftList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvAircraftList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
           
            btn = new DataGridViewButtonColumn();

            dgvAircraftList.Columns.Add(btn);
            btn.HeaderText = "AImage";
            btn.Text = "Image";
            btn.Name = "btn";

            //http://stackoverflow.com/questions/19159801/c-sharp-datagridviewbuttoncell-set-buttons-text   
            //http://stackoverflow.com/questions/5473031/combobox-doesnt-allow-enter-custom-text-if-databinding-is-used

            lstAircraftDependencies = (List<string>)CheckAircraftDependencies();

            for (int x = 0; x < dgvAircraftList.RowCount; x++)
            {
                Checkdependency = dgvAircraftList.Rows[x].Cells[0].Value.ToString().Trim();
                foreach (var item in lstAircraftDependencies)
                {
                    if(item.Trim().ToLower() == Checkdependency.Trim().ToLower())
                    {
                        dgvAircraftList.Rows[x].Cells[2].ReadOnly = true;
                        dgvAircraftList.Rows[x].Cells[0].ReadOnly = true;
                        dgvAircraftList.Rows[x].Cells[1].ReadOnly = true;
                        dgvAircraftList.Rows[x].Cells[0].Style.BackColor = Color.LightGray;
                        dgvAircraftList.Rows[x].Cells[1].Style.BackColor = Color.LightGray;
                        //dgvAircraftList.Rows[x].Cells[2].Style.BackColor = Color.Red;                        
                    }

                }
                //dgvAircraftList.Rows[x].Cells[2].ToolTipText = "Click to get " + dgvAircraftList.Rows[x].Cells[0].Value.ToString().Trim() + " image";
                dgvAircraftList.Rows[x].Cells[2].Value = dgvAircraftList.Rows[x].Cells[0].Value.ToString().Trim();
                
            }

        }

        public bool CheckReturnDependency(string aeroP)
        {
            foreach (var item in lstAircraftDependencies)
            {
                if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private void dgvAircraftList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string aeroP;
            if (e.ColumnIndex == 2 & e.RowIndex != -1)
            {
                aeroP = dgvAircraftList.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                ShowAircraftImageName = dgvAircraftList.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                //Type b = dgvAircraftList.Rows[e.RowIndex].Cells[0].GetType();

                if (CheckReturnDependency(aeroP))
                    return;

                //foreach (var item in lstAircraftDependencies)
                //{
                //    if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                //    {
                //        return;
                //    }
                //}

                ShowAircraftImage(aeroP, (int)e.ColumnIndex, (int)e.RowIndex);
            }
            else if ((e.ColumnIndex != -1 & e.RowIndex != -1) & e.ColumnIndex != 0)
            {
                string val1 = dgvAircraftList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
                string aircraftname = dgvAircraftList.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                string colName = dgvAircraftList.Columns[e.ColumnIndex].Name.ToString().Trim();

                if (CheckReturnDependency(aircraftname))
                    return;
                //foreach (var item in lstAircraftDependencies)
                //{
                //    if (item.Trim().ToLower() == aircraftname.Trim().ToLower())
                //    {
                //        return;
                //    }
                //}

                dgvAircraftList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.DarkSlateGray;
                dgvAircraftList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
                dgvAircraftList.Refresh();
                                
                string val2;
                if (dgvAircraftList[e.ColumnIndex, e.RowIndex].Value == null) // no current value
                    val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvAircraftList[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString().Trim() + " (Edit/Change Value)");
                else
                    val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvAircraftList[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString().Trim() + " (Edit/Change Value)", dgvAircraftList[e.ColumnIndex, e.RowIndex].Value.ToString().Trim());

                //if (val2.Length == 0) MessageBox.Show("cancel");

                if (val2.Length != 0 && val1 != val2)
                {
                    //add to database
                    try
                    {
                        //add to database
                        AirlineReservationDAL.Aircraft acft = ar.Aircraft.Single(a => a.AircraftType == aircraftname);
                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + val2, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            acft.SeatCapacity = val2.Trim();
                            ar.SubmitChanges();
                            ListAircraft();
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
                    dgvAircraftList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                    dgvAircraftList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                    dgvAircraftList.Refresh();
               

            }
            else if (e.ColumnIndex == 0 & e.RowIndex != -1)
            {
                //MessageBox.Show("YOU CANNOT CHANGE THE AIRCRAFT NAME!!!");
                return;
            }           
        }

        private void DeleteAircraft(string arfrftType)
        {
            AirlineReservationDAL.Aircraft at = ar.Aircraft.Single(a => a.AircraftType == arfrftType);

            ar.Aircraft.DeleteOnSubmit(at);
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

        private void ShowAircraftImage(string planeimage, int colI, int rowI)
        {
            if (showimage.Contains(planeimage)) return;            

            aircrftImageFrm = new Form();
            aircrftImageFrm.FormClosed += new FormClosedEventHandler(aircrftImageFrm_FormClosed);
            aircrftImageFrm.Height = 1300;
            aircrftImageFrm.Width = 500;
            AircraftImageBytes = ar.Aircraft.First(a => a.AircraftType == planeimage).AImage;
            aircraftImageFromBtyes = Image.FromStream(new MemoryStream(AircraftImageBytes));
            //ai.RotateFlip(RotateFlipType.Rotate90FlipX);
            aircrftImageFrm.BackgroundImage = aircraftImageFromBtyes;
            aircrftImageFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            aircrftImageFrm.Text = planeimage;

            //var qry = from ac in acrft
            //          select ac.AircraftType;
            //selectedAcftTypeX = colI;
            //selectedAcftTypeY = rowI;
            //cmbx = new ComboBox();
            //cmbx.SelectedIndexChanged += new EventHandler(cmbx_SelectedIndexChanged);
            //cmbx.KeyPress += new KeyPressEventHandler(cmbx_KeyPress);
            
            Change = new Button();
            //cmbx.Location = new Point(3, 28);
            Change.Location = new Point(3, 3);            

            saveImage = new Button();
            saveImage.Click += new EventHandler(saveImage_Click);
            saveImage.Location = new Point(3, 28);
            saveImage.Text = "Save";
            saveImage.Enabled = false;

            CancelImage = new Button();
            CancelImage.Click += new EventHandler(CancelImage_Click);
            CancelImage.Location = new Point(3, 53);
            CancelImage.Text = "Cancel";
            CancelImage.Enabled = false;
           
            Change.Click += new EventHandler(Change_Click);            
            Change.Text = "Change Image";
            Change.Width = 77;
            //cmbx.Height = 30;
            //cmbx.Width = 75;           
           
            aircrftImageFrm.Controls.Add(Change);
            //aircrftImageFrm.Controls.Add(cmbx);
            aircrftImageFrm.Controls.Add(saveImage);
            aircrftImageFrm.Controls.Add(CancelImage);  
            showimage.Add(planeimage);
            aircrftImageFrm.Show();

            selectedAcftTypeB = true;
            //cmbx.DataSource = qry; // putting datasource here, fires cmbx_SelectedIndexChanged
        }

        void CancelImage_Click(object sender, EventArgs e)
        {
            //Change.Enabled = false;
            saveImage.Enabled = false;
            CancelImage.Enabled = false;
            //initvalue_cmbx = dgvAircraftList[selectedAcftTypeX, selectedAcftTypeY].Value.ToString();
            //cmb_can.Text = initvalue_cmbx;

            //AircraftImageBytes = ar.Aircraft.First(a => a.AircraftType == initvalue_cmbx).AImage;
            //aircraftImageFromBtyes = Image.FromStream(new MemoryStream(AircraftImageBytes));
            aircrftImageFrm.BackgroundImage = aircraftImageFromBtyes;
        }

        void saveImage_Click(object sender, EventArgs e)
        {
            saveImage.Enabled = false;
            CancelImage.Enabled = false;
            Change.Enabled = false;
           
            byte[] image = System.IO.File.ReadAllBytes(fileimagename);
            AirlineReservationDAL.Aircraft acft = ar.Aircraft.Single(a => a.AircraftType == ShowAircraftImageName);

            try
            {
                acft.AircraftType = txtAircraftImage;
                acft.AImage = image;
                ar.SubmitChanges();
                aircrftImageFrm.Text = txtAircraftImage;
                ListAircraft();

                showimage.Add(txtAircraftImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Change_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //byte[] AircraftImageBytes = ar.Aircraft.First(a => a.AircraftType == "B737").AImage;
            //Image aircraftImageFromBtyes = Image.FromStream(new MemoryStream(AircraftImageBytes));
            //aircrftImageFrm.BackgroundImage = aircraftImageFromBtyes;
            saveImage.Enabled = true;
            CancelImage.Enabled = true;

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Aircraft Image (jpg)";
            fdlg.Filter = "Jpg files (*.jpg*)|*.jpg*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string ffff = fdlg.FileName;
                arcrftImage = Image.FromFile(fdlg.FileName);
                fileimagename = fdlg.FileName;
                //txtAircraftImage = fdlg.SafeFileName;
                txtAircraftImage = System.IO.Path.GetFileNameWithoutExtension(fdlg.SafeFileName);
                //picBxThumb.Image = arcrftImage;//getThumbnail(fdlg.FileName);
                //picBxThumb.SizeMode = PictureBoxSizeMode.Zoom;

                aircrftImageFrm.BackgroundImage = arcrftImage;
            }              
        }

        private void ChangeAircraftImage(string planeimage)       
        {
            var qry = from ac in acrft
                      select ac.AircraftType;

            ComboBox  cmbx = new ComboBox();
            cmbx.SelectedIndexChanged += new EventHandler(cmbx_SelectedIndexChanged);
            cmbx.KeyPress += new KeyPressEventHandler(cmbx_KeyPress);                       
        }

        void cmbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAcftTypeB)
            {
                cmb_can = (ComboBox)sender;
                int selectedIndex = cmb_can.SelectedIndex;
                //int selectedValue = (int)cmb.SelectedValue;
                //string val = cmb.Items.ToString(); IndexOf(selectedIndex).ToString(); ;
                //selectedAcftType = cmb.SelectedItem.ToString();
                selectedAcftTypeB = false;

                initvalue_cmbx = dgvAircraftList[selectedAcftTypeX, selectedAcftTypeY].Value.ToString();
                cmb_can.Text = initvalue_cmbx;
            }
            else
            {

                Change.Enabled = true;
                CancelImage.Enabled = true;
                //if (selectedAcftTypeB)
                //{
                //    string initvalue = dgvFlights[selectedAcftTypeX, selectedAcftTypeY].Value.ToString();
                //    cmbx.Text = initvalue;
                //    selectedAcftTypeB = false;
                //}
                //else
                //{
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                selectedValueImage = cmb.SelectedValue.ToString();
                //string val = cmb.Items.ToString(); //IndexOf(selectedIndex).ToString(); ;
                //    selectedAcftType = cmb.SelectedItem.ToString();
                //}

                AircraftImageBytes = ar.Aircraft.First(a => a.AircraftType == selectedValueImage).AImage;
                aircraftImageFromBtyes = Image.FromStream(new MemoryStream(AircraftImageBytes));
            }           
        }

        void browseImage_Click(object sender, EventArgs e)
        {
            BrowseForImage(); 
        }

        void aircrftImageFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form arcftclosingfrm = (Form)sender;
            showimage.Remove(arcftclosingfrm.Text);

            arcftclosingfrm = null;
            aircrftImageFrm = null;
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            BrowseForImage();
        }


        private void BrowseForImage()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Aircraft Image (jpg)";
            fdlg.Filter = "Jpg files (*.jpg*)|*.jpg*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                arcrftImage = Image.FromFile(fdlg.FileName);
                txtAircraftImage = fdlg.SafeFileName;
                picBxThumb.Image = arcrftImage;//getThumbnail(fdlg.FileName);
                picBxThumb.SizeMode = PictureBoxSizeMode.Zoom;
            }  
        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
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
        }

       

        private void AircraftFMF_Click_Click_1(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }
               

        
        private void dgvAircraftList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvAircraftList.BeginEdit(true);  
        }

        private void dgvAircraftList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                string aeroP = dgvAircraftList.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                if (CheckReturnDependency(aeroP))
                    return;
                //foreach (var item in lstAircraftDependencies)
                //{
                //    if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                //    {
                //        return;
                //    }
                //}

                int ri = e.RowIndex + 1;
                //dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;


                    if (MessageBox.Show("## DELETE AIRCRAFT " + aeroP + " ##", " DELETING AIRCRAFT " + aeroP, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("## ARE YOU SURE YOU WISH TO DELETE AIRCRAFT " + aeroP + " !!!! ##", " DELETING AIRCRAFT " + aeroP + " CONFIRMATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("AIRCRAFT" + aeroP + " DELETED");
                        DeleteAircraft(aeroP);
                        ListAircraft();
                        return;
                    }
              
                ListAircraft();

            }
        }

       
       

        private void AircraftTab_Paint(object sender, PaintEventArgs e)
        {
            AirportTab.boolEnterAirports = false;
            RefreshGrid();
        }

       

        private void dgvAircraftList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAircraftList.ClearSelection();
        } 

    }
}
