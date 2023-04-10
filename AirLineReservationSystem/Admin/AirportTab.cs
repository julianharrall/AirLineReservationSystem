using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AirLineReservationSystem
{
    public partial class AirportTab : Form
    {
        Administration adf;// To allow closure of administration form    
        AirlineReservationDAL.AirlineReservation ar;

        public List<string> lstAirportDependencies { get; set; }
        public bool boolListAirports { get; set; }
        public static bool boolEnterAirports { get; set; }
        public string Checkdependency { get; set; }

        public AirportTab( Administration ad)
        {
            InitializeComponent();
            adf = ad;
            ar = new AirlineReservationDAL.AirlineReservation();
            

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CreateMyBorderlessWindow();

            dgvAirports.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;

            //RefreshGrid();


            lstAirportDependencies = (List<string>)CheckAirportDependencies(); 

            boolEnterAirports = true;


        }        

        private IEnumerable CheckAirportDependencies()
        {
            var AllAirports = from bk in ar.Booking
                              join fl in ar.Flight
                              on bk.FlightNumber equals fl.FlightNumber
                              join arp in ar.Airport
                              on fl.AirportID equals arp.AirportID
                              select arp.AirportName;

            IEnumerable AllAirportsDistinct = AllAirports.Distinct().ToList(); ;

            return AllAirportsDistinct;
        }

        public bool CheckReturnDependency(string aeroP)
        {
            foreach (var item in lstAirportDependencies)
            {
                if (item.Trim().ToLower() == aeroP.Trim().ToLower())
                {
                    return true;
                }
            }

            return false;
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

        private void AirportTab_Load(object sender, EventArgs e)
        {
            //AirlineReservationDAL.AirlineReservation ar = new AirlineReservationDAL.AirlineReservation();
            //var AllAirports = from ac in ar.Airport select new { ac.AirportGate,ac.AirportName};

            //dgvAirports.DataSource = AllAirports;
        }

        private void AirportB_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf = null;
            this.Close();           
        }

        private void AirportE_Click_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AirportFMF_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }

        private void btnAddAirport_Click(object sender, EventArgs e)
        {
            lblAirportMessage.Text = "";

          

            int AirportFlag = 0;
            AirlineReservationDAL.Airport arprt = new AirlineReservationDAL.Airport { AirportGate=txtAirportGate.Text,AirportName=txtAirportName.Text};
            if (String.IsNullOrEmpty(txtAirportName.Text)) { lbltxtAirportName.Text = "Please Enter Airport Name"; AirportFlag += 1; }
            else lbltxtAirportName.Text = "";
            if (String.IsNullOrEmpty(txtAirportGate.Text)) { lbltxtAirportGate.Text = "Please Enter Aircraft Gate"; AirportFlag += 1; }
            else lbltxtAirportGate.Text = "";
         

            if (AirportFlag > 0) return;

            try
            {
                ar.Airport.InsertOnSubmit(arprt);
                ar.SubmitChanges();
                
                ListAirports();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                lblAirportMessage.Text = ex.Message.ToString();
            }
            finally
            {
                //arcrftImage = null;
                txtAirportName.Text = "";
                txtAirportGate.Text = "";                
            }     
        }

        private void btnArprtList_Click(object sender, EventArgs e)
        {
            ListAirports();
        }

        private void RefreshGrid()
        {
            if (dgvAirports.ColumnCount > 0)
            {
                dgvAirports.DataSource = null;
                dgvAirports.Refresh();
                dgvAirports.ClearSelection();
            }
        }

        private void ListAirports()
        {
            RefreshGrid();

            lstAirportDependencies = (List<string>)CheckAirportDependencies();

            var AllAirports = from ap in ar.Airport select new { ap.AirportName, ap.AirportGate };

            dgvAirports.DataSource = AllAirports;

            for (int x = 0; x < dgvAirports.RowCount; x++)
            {
                Checkdependency = dgvAirports.Rows[x].Cells[0].Value.ToString().Trim();
                foreach (var item in lstAirportDependencies)
                {
                    if (item.Trim().ToLower() == Checkdependency.Trim().ToLower())
                    {
                        //dgvAirports.Rows[x].Cells[2].ReadOnly = true;
                        dgvAirports.Rows[x].Cells[0].ReadOnly = true;
                        dgvAirports.Rows[x].Cells[1].ReadOnly = true;
                        dgvAirports.Rows[x].Cells[0].Style.BackColor = Color.LightGray;
                        dgvAirports.Rows[x].Cells[1].Style.BackColor = Color.LightGray;
                        //dgvAircraftList.Rows[x].Cells[2].Style.BackColor = Color.Red;                        
                    }

                }

            }
        }

       
        private void DeleteAirport(string aprtName)
        {
            AirlineReservationDAL.Airport apt = ar.Airport.Single(ap => ap.AirportName == aprtName);

            ar.Airport.DeleteOnSubmit(apt);
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

        private void dgvAirports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 & e.RowIndex != -1)
            {
                string val1 = dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
                string airportname = dgvAirports.Rows[e.RowIndex].Cells[0].Value.ToString();
                string colName = dgvAirports.Columns[e.ColumnIndex].Name.ToString();

                // Dont allow changes to AirportName
                if (colName == "AirportName")
                {
                    return;
                }

                if (CheckReturnDependency(airportname))
                    return;

                dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.DarkSlateGray;
                dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
                dgvAirports.Refresh();
                
                string val2;
                if (dgvAirports[e.ColumnIndex, e.RowIndex].Value == null) // no current value
                    val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvAirports[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString().Trim() + " (Edit/Change Value)");
                else
                    val2 = Microsoft.VisualBasic.Interaction.InputBox("\nOK to confirm change\n\n Cancel to cancel request and exit", dgvAirports[e.ColumnIndex, e.RowIndex].OwningColumn.Name.ToString().Trim() + " (Edit/Change Value)", dgvAirports[e.ColumnIndex, e.RowIndex].Value.ToString().Trim());

                //if (val2.Length == 0) MessageBox.Show("cancel"); // Cancel change

                if (val2.Length != 0 && val1 != val2)
                {
                    //add to database                   
                    
                    try
                    {
                        AirlineReservationDAL.Airport arp = ar.Airport.Single(a => a.AirportName == airportname);

                        if (colName == "AirportName")
                        {  
                            arp.AirportName = val2;
                        }
                        else if (colName == "AirportGate")
                        { 
                            arp.AirportGate = val2;
                        }
                        else MessageBox.Show("Error with reading Airport Column Header", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        DialogResult dialogResult = MessageBox.Show("Confirm " + "new " + colName + " value change from: " + val1 + " to: " + val2, "Confirm Changes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ar.SubmitChanges();
                            ListAirports();
                            //MessageBox.Show("New " + colName + " value changed: " + val2);
                        }                      
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                        throw ex;
                    }
                }               
                
                dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Maroon;
                dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                dgvAirports.Refresh();               

            }

           
        }

        private void dgvAirports_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aeroP = dgvAirports.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

            if (CheckReturnDependency(aeroP))
                return;

            if (e.ColumnIndex == -1 && e.RowIndex != -1)
            {
                //string aeroP = dgvAirports.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();


                if (CheckReturnDependency(aeroP))
                    return;


                int ri = e.RowIndex + 1;
                //dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgvAirports.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;

                if (MessageBox.Show("## DELETE AIRPORT " + aeroP + " ##", " DELETING AIRPORT " + aeroP, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("## ARE YOU SURE YOU WISH TO DELETE AIRPORT " + aeroP + " !!!! ##", " DELETING AIRPORT " + aeroP + " CONFIRMATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("AIRCRAFT" + aeroP + " DELETED");
                        DeleteAirport(aeroP);
                        ListAirports();
                        return;
                    }

                // Deletion Cancelled
                //dgvAirports.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Maroon;
                //dgvAirports.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                ListAirports();

            }
            else if ((e.RowIndex != -1))
            {
                MessageBox.Show(dgvAirports.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
            }
        }

        private void dgvAirports_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAirports.ClearSelection();
        }

        private void AirportTab_Paint(object sender, PaintEventArgs e)
        {
            if (!boolEnterAirports )
            {
                RefreshGrid();
            //    boolEnterAirports = false;

            }
            //else
            //{
            //    boolEnterAirports = false;
            //}
        }
    }
}
