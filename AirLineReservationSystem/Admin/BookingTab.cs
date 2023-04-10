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
    public partial class BookingTab : Form
    {
        Administration adf;// To allow closure of administration form    
        AirlineReservationDAL.AirlineReservation ar;
        Table<AirlineReservationDAL.Destination> dest;
        Table<AirlineReservationDAL.Flight> flt;
        Table<AirlineReservationDAL.Booking> bkg;

        DateTimePicker pickerOut;
        //DateTimePicker? pickerOut;    
        //DateTime dateTimeDefault = new DateTime(9999, 01, 1, 12, 0, 0);
        public BookingTab(Administration ad)
        {
            InitializeComponent();
            adf = ad;
            ar = new AirlineReservationDAL.AirlineReservation();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CreateMyBorderlessWindow();

            FormDateTimePicker(); // add DateTimePickers (Outward and Inward) to Form

            pickerOut.ValueChanged += new EventHandler(pickerOut_ValueChanged);
            pickerOut.Enter += PickerOut_Enter;

            bkg = ar.GetTable<AirlineReservationDAL.Booking>();
            flt = ar.GetTable<AirlineReservationDAL.Flight>();
            dest = ar.GetTable<AirlineReservationDAL.Destination>();
            populateCountries();
            populateFlightNum();
            populateReservationNum();

            pickerOut.Format = DateTimePickerFormat.Custom;
            pickerOut.CustomFormat = "dd/MM/yyyy";

            SetDatetImePickerOutDefault();

            dgvBookings.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;

            

            //RefreshGrid();
        }

        public BookingTab()
        {
            
        }

        private void PickerOut_Enter(object sender, EventArgs e)
        {
            if (pickerOut.Value == DateTimePicker.MaximumDateTime)
            {
                pickerOut.Value = DateTime.Now;
                //pickerOut.Value = DateTimePicker.MaximumDateTime;
                //pickerOut.CustomFormat = " ";
                //pickerOut.Format = DateTimePickerFormat.Custom;
            }
            
        }

        private void pickerOut_ValueChanged(object sender, EventArgs e)
        {
            
            // only change date format if blank
            if (pickerOut.CustomFormat == " ")
            {
                pickerOut.Format = DateTimePickerFormat.Custom;
                pickerOut.CustomFormat = "dd/MM/yyyy";
            }
            

            
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

        private void Booking_FMF_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }

        private void BookingB_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf = null;
            this.Close();
        }

        private void BookingE_Click_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBookingList_Click(object sender, EventArgs e)
        {
            ListBookings();
        }

        private IEnumerable BookingInfo()
        {
            var AllBookingGrid = from bk in ar.Booking
                                 join py in ar.Payment
                                 on bk.PaymentID equals py.PaymentID
                                 join cust in ar.Customer
                                 on bk.BookingID equals cust.BookingID
                                 join fl in ar.Flight
                                 on bk.FlightNumber equals fl.FlightNumber
                                 join dest in ar.Destination
                                 on fl.DestID equals dest.DestID
                                 join arp in ar.Airport
                                 on fl.AirportID equals arp.AirportID
                                 join acft in ar.Aircraft
                                 on fl.AircraftNumber equals acft.AircraftNumber
                                 select new
                                 {
                                     bk.ReservationNum,
                                     py.NameOnCard,
                                     py.CardNumber,
                                     py.Amount,
                                     py.Expiry,
                                     py.CSV,
                                     cust.Gender,
                                     cust.CustLastName,
                                     cust.CustFirstName,
                                     cust.CustType,
                                     dest.Airport,
                                     dest.Country,
                                     dest.Gate,
                                     arp.AirportGate,
                                     arp.AirportName,
                                     acft.SeatCapacity,
                                     fl.Seats,
                                     acft.AircraftType,
                                     fl.FlightNum,
                                     fl.OutDateTime,
                                     fl.InDateTime
                                 };

            return AllBookingGrid.Distinct();//.ToList();

        }

        private void RefreshGrid()
        {
            if (dgvBookings.ColumnCount > 0)
            {
                dgvBookings.DataSource = null;
                dgvBookings.Refresh();
                dgvBookings.ClearSelection();
            }
        }

        private void ListBookings()
        {
            RefreshGrid();

            var AllBookingGrid = BookingInfo();

           
            dgvBookings.DataSource = AllBookingGrid;
        }
               
       
        private void DeleteBookingEF(string ResNum)
        {
            AirlineReservationDAL.Booking bkg = ar.Booking.Single(bk => bk.ReservationNum == ResNum);

            ar.Booking.DeleteOnSubmit(bkg);
            try
            {
                ar.SubmitChanges();
                MessageBox.Show("Booking: " + bkg.ReservationNum + "Successfully Deleted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }

        }
        
        private void DeleteBooking(string ResNum)
        {
            var command = $"sp_DeleteBooking '" + ResNum + "'";

            var affectedDatas = ar.ExecuteCommand(command);           

            try
            {
                ar.SubmitChanges();
                MessageBox.Show("Booking: " + ResNum + " Successfully Deleted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }

        }

        private void dgvBookings_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex != -1)
            {
                string bookP = dgvBookings.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                int ri = e.RowIndex + 1;
                //dgvAircraftList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                dgvBookings.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;

                if (MessageBox.Show("## DELETE BOOKING " + bookP + " ##", " DELETING BOOKING " + bookP, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("## ARE YOU SURE YOU WISH TO DELETE BOOKING " + bookP + " !!!! ##", " DELETING BOOKING " + bookP + " CONFIRMATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("AIRCRAFT" + aeroP + " DELETED");
                        DeleteBooking(bookP);
                        ListBookings();
                        return;
                    }

                // Deletion Cancelled
                //dgvAirports.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Maroon;
                //dgvAirports.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                ListBookings();

            }
            else if ((e.RowIndex != -1))
            {
                MessageBox.Show(dgvBookings.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
            }
        }

        private void lblAirportName_Click(object sender, EventArgs e)
        {

        }

        private void populateCountries()
        {
            
            var qryCountry = from ds in dest select new { ds.Country };
            cmbxCountry.DataSource = qryCountry;
            cmbxCountry.ValueMember = "Country";
            cmbxCountry.DisplayMember = "Country";
            cmbxCountry.SelectedIndex = -1;
        }

        private void populateFlightNum()
        {

            var qryFlight = from fl in flt select new { fl.FlightNum };
            cmbxFlightNum.DataSource = qryFlight;
            cmbxFlightNum.ValueMember = "FlightNum";
            cmbxFlightNum.DisplayMember = "FlightNum";
            cmbxFlightNum.SelectedIndex = -1;
        }
        
        private void populateReservationNum()
        {

            var qryBooking = from bk in bkg select new { bk.ReservationNum };
            cmbxResNum.DataSource = qryBooking;
            cmbxResNum.ValueMember = "ReservationNum";
            cmbxResNum.DisplayMember = "ReservationNum";
            cmbxResNum.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBookings.Rows.Clear();
            dgvBookings.Refresh();

            var AllBookingGrid2 = from bk in ar.Booking
                                  join py in ar.Payment
                                  on bk.PaymentID equals py.PaymentID
                                  join cust in ar.Customer
                                  on bk.BookingID equals cust.BookingID
                                  join fl in ar.Flight
                                  on bk.FlightNumber equals fl.FlightNumber
                                  join dest in ar.Destination
                                  on fl.DestID equals dest.DestID
                                  join arp in ar.Airport
                                  on fl.AirportID equals arp.AirportID
                                  join acft in ar.Aircraft
                                  on fl.AircraftNumber equals acft.AircraftNumber
                                  select new
                                  {
                                      bk.ReservationNum,
                                      py.NameOnCard,
                                      py.CardNumber,
                                      py.Amount,
                                      py.Expiry,
                                      py.CSV,
                                      cust.Gender,
                                      cust.CustLastName,
                                      cust.CustFirstName,
                                      cust.CustType,
                                      dest.Airport,
                                      dest.Country,
                                      dest.Gate,
                                      arp.AirportGate,
                                      arp.AirportName,
                                      acft.SeatCapacity,
                                      acft.AircraftType,
                                      fl.FlightNum,
                                      fl.OutDateTime,
                                      fl.InDateTime
                                  };


            List<string> stringListArray = new List<string>();



            string resnum = cmbxResNum.Text;
            string fnum =  cmbxFlightNum.Text;
            string cntry = cmbxCountry.Text;
            string psngr = txbxPassname.Text;
                        
            if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum) 
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))                
             {
                var qry = from res in AllBookingGrid2
                where res.ReservationNum.Contains(resnum)
                && res.FlightNum.Contains(fnum)
                && res.Country.Contains(cntry)
                && (res.CustFirstName.Contains(psngr)
                || res.CustLastName.Contains(psngr)
                && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString()))
                select res;
                                
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry) 
                          && (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                          select res;
                               
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry)
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry)
                          && res.ReservationNum.Contains(resnum)
                          select res;
                                
                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                          select res;
                
                dgvBookings.DataSource = qry;
            }           
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                            && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                            && res.Country.Contains(cntry)
                            && (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr)
                            && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString()))
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry)
                            && (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                            
                          select res;
                                
                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry)
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          select res;
                
                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry) &&
                          (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                            && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry) &&
                          (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry)
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                            && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }            
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where (res.CustFirstName.Contains(psngr)
                            || res.CustLastName.Contains(psngr))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)                          
                          && res.Country.Contains(cntry)
                          && ((res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr))
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString()))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)                          
                          && (res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString()))
                          select res;

                dgvBookings.DataSource = qry;
            }            
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          && (res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString()))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
                && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
                && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)                          
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
               && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
               && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
               && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
               && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.ReservationNum.Contains(resnum)
                          && res.FlightNum.Contains(fnum)
                          && (res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
               && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
               && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
               && !string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
               && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry)
                          && (res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
               && string.IsNullOrEmpty(cntry) && !string.IsNullOrEmpty(psngr)
               && (pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          && (res.CustFirstName.Contains(psngr)
                          || res.CustLastName.Contains(psngr))
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (!string.IsNullOrEmpty(resnum) && string.IsNullOrEmpty(fnum)
               && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
               && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.Country.Contains(cntry)
                          && res.ReservationNum.Contains(resnum)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
               && string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
               && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }
            else if (string.IsNullOrEmpty(resnum) && !string.IsNullOrEmpty(fnum)
              && !string.IsNullOrEmpty(cntry) && string.IsNullOrEmpty(psngr)
              && !(pickerOut.Value == DateTimePicker.MaximumDateTime))
            {
                var qry = from res in AllBookingGrid2
                          where res.FlightNum.Contains(fnum)
                          && res.Country.Contains(cntry)
                          && res.OutDateTime >= Convert.ToDateTime(pickerOut.Value.ToShortDateString())
                          select res;

                dgvBookings.DataSource = qry;
            }



            //pickerOut.Value



            /*
             txtAirportName.text 
            txtAirportGate
            txbxPassname            
            txbxCountry
             */
        }

        private void FormDateTimePicker()
        {           
           
            pickerOut = new DateTimePicker();
            //pickerOut.MinDate = DateTime.Now;
            pickerOut.Format = DateTimePickerFormat.Custom;
            pickerOut.CustomFormat = " ";
            pickerOut.CalendarTitleBackColor = Color.Blue;
            pickerOut.CalendarTitleForeColor = Color.Blue;

            pickerOut.CalendarForeColor = Color.Blue;
            pickerOut.SetBounds(39, 370, 150, 75);
            groupBox6.Controls.Add(pickerOut);            
            this.Controls.Add(groupBox6);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbxResNum.Text = "";
            cmbxFlightNum.Text = "";
            txbxPassname.Text = "";
            cmbxCountry.Text = "";
            //pickerOut.Value = DateTimePicker.MaximumDateTime;

            SetDatetImePickerOutDefault();
        }   
        
        /// <summary>
        /// Set DateTime pickerOut value to the default
        /// maximum value 31/12/9998
        /// </summary>
        private void SetDatetImePickerOutDefault()
        {
            pickerOut.Value = DateTimePicker.MaximumDateTime;
            pickerOut.CustomFormat = " ";
            pickerOut.Format = DateTimePickerFormat.Custom;
        }

        

        private void cmbxFlightNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void cmbxResNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void cmbxCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void txbxPassname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dgvBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BookingTab_Paint(object sender, PaintEventArgs e)
        {
            AirportTab.boolEnterAirports = false;
            RefreshGrid(); 
        }
    }
}
