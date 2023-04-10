using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Linq;

namespace AirLineReservationSystem
{
    public partial class BookFlight : Form
    {
        AirlineReservationDAL.AirlineReservation ar;       
        FindFlight ff;
        ReserveFlight rf;
        Passenger_Details pd;
        bool initialdate; // flag set when intial date is set when entering BookFlight

        enum Months { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
        String CurrYear;        
        String CurrentYear;
        String CurrMonth;
        String currDay;
        String CurrDate;
        string currM;        
        int daysInMonth;
        int month;              
        string phaseweekYear;    
        bool rbRepeatCnt; // stop program flow from going twice into rbm_CheckedChanged
        bool rbDetailsRepeatCnt = true; // stop program flow from going twice into rbmDetails_CheckedChanged
        bool lblBackClick;
        bool lblForwardClick;      
        String TransitionString;      
        Table<AirlineReservationDAL.Flight> ft;
        bool InTransitionPhase;      
        string labelHolder = null;

        public DateTime DtStart { get; set; }

        public BookFlight(FindFlight f)
        {
            InitializeComponent();
            ar = new AirlineReservationDAL.AirlineReservation();
            DtStart = f.dtStart;
            //now = DateTime.Now;
            //CurrYear = now.ToString("yyyy");
            //CurrentYear =  now.ToString("yyyy");
            //CurrMonth=now.ToString("MMM");
            CurrYear = DtStart.ToString("yyyy");
            CurrentYear = DtStart.ToString("yyyy");
            CurrMonth = DtStart.ToString("MMM");
            currDay = DtStart.DayOfWeek.ToString(); //currDay = now.DayOfWeek.ToString();          
            CurrDate = DtStart.ToString("dd"); //CurrDate = now.ToString("dd");           
            currM = CurrMonth.Substring(0, 3);

            month = DtStart.Month;//month = System.DateTime.Now.Month;
            daysInMonth = System.DateTime.DaysInMonth(Convert.ToInt32(CurrYear), month);
                      
            setCalendar(CurrMonth);
            setBackgroundImage(f.CountryDestination);
            ff = f;            
            lblBack.Click += new EventHandler(lblBack_Click);
            lblForward.Click += new EventHandler(lblForward_Click);
            this.WindowState = FormWindowState.Maximized;
            rbm.Checked = false;
            radioButtonEvent();
            radioButtonEventDetails();
            setInitialDate();        

            Transition(); // call just in case you are straight into Transition

            GetFlightDetails(new DateTime(2015, 03, 01, 12, 00, 00)); //{01/03/2015 00:00:00}

            int x = NumberOfFlights(new DateTime(2015, 03, 01, 12, 00, 00));
        }

        public void GetFlightDetails(DateTime fldt)
        {
            ft = ar.GetTable<AirlineReservationDAL.Flight>();
            var qry = from b in ft
                      where DateTime.Compare(b.DepartureDateTime.Value, fldt) >= 0//where b.DepartureDateTime == fldt
                      select new { b.FlightNum, b.AircraftNumb.AircraftType, b.Business, b.First, b.Economy, b.Airport.AirportName, b.Destination.Country, b.DepartureDateTime, b.ArrivalDateTime };
            foreach (var v in qry)
            {
                Console.WriteLine("First={0} Economy = {1} Business={2} Destination={3}", v.First, v.Economy, v.Business, v.Country);
            }

            //FlNum, ArNum, Bus, Fir, Eco, Apname, Dest;
            //DateTime DepT, ArrT;
        }

        // number of flights equal to or greater than passed in date
        public int NumberOfFlights(DateTime dt)
        {
            return ar.GetTable<AirlineReservationDAL.Flight>().Count(x => x.DepartureDateTime >= dt);

        }             
        
        // sets initial date i.e. todays date YMD
        public void setInitialDate()
        {
            initialdate = true;
            lblYear.Text = CurrYear.ToString();
            lblconfirm.Text = currDay.Substring(0, 3) +" " + lblm1.Text.ToString() + "" + lbl1.Text.ToString();
        }

        //click events for radiobuttons date selection
        public void radioButtonEvent()
        {
            rbm.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbtu.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbwe.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbth.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbfr.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbsa.CheckedChanged += new EventHandler(rbm_CheckedChanged);
            rbsu.CheckedChanged += new EventHandler(rbm_CheckedChanged);
        }

        //click events for radiobuttons flight selection
        public void radioButtonEventDetails()
        {
            rb1.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb2.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb3.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb4.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb5.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb6.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb7.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb8.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
            rb9.CheckedChanged += new EventHandler(rbmDetails_CheckedChanged);
        }                   

        public String DayMonthDate(RadioButton rb)
        {
            String DateVal;

            switch (rb.Name)
            {
                case "rbm":
                    DateVal = lblMonday.Text.ToString() + " " + lblm1.Text.ToString() + " " + lbl1.Text.ToString();
                    break;
                case "rbtu":
                    DateVal = lblTuesday.Text.ToString() + " " + lblm2.Text.ToString() + " " + lbl2.Text.ToString();
                    break;
                case "rbwe":
                    DateVal = lblWednesday.Text.ToString() + " " + lblm3.Text.ToString() + " " + lbl3.Text.ToString();
                    break;
                case "rbth":
                    DateVal = lblThursday.Text.ToString() + " " + lblm4.Text.ToString() + " " + lbl4.Text.ToString();
                    break;
                case "rbfr":
                    DateVal = lblFriday.Text.ToString() + " " + lblm5.Text.ToString() + " " + lbl5.Text.ToString();
                    break;
                case "rbsa":
                    DateVal = lblSaturday.Text.ToString() + " " + lblm6.Text.ToString() + " " + lbl6.Text.ToString();
                    break;
                case "rbsu":
                    DateVal = lblSunday.Text.ToString() + " " + lblm7.Text.ToString() + " " + lbl7.Text.ToString();
                    break;
                default:
                    DateVal = "None";
                    break;
            }

            return DateVal;

        }
        
        int MonthLength(DateTime d)
        {            
            int dateOnly = d.Month;
            int yearonly =d.Year;  
            return  DateTime.DaysInMonth(yearonly, dateOnly); 
        }

        // click event for radiobutton flight selection
        void rbmDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetailsRepeatCnt == false )
            {
                rbDetailsRepeatCnt = true;
                return;
            }

            var ctrl = (Control)sender;
            string cbname = ctrl.Name;
            string FlightType;

            switch (cbname)
            {
                case "rb1":
                    FlightType = "Flight1";
                    break;
                case "rb4":
                    FlightType = "Flight2";
                    break;
                case "rb7":
                    FlightType = "Flight3";
                    break;
                case "rb2":
                    FlightType = "Flight1";
                    break;
                case "rb5":
                    FlightType = "Flight2";
                    break;
                case "rb8":
                    FlightType = "Flight3";
                    break;
                case "rb3":
                    FlightType = "Flight1";
                    break;
                case "rb6":
                    FlightType = "Flight2";
                    break;
                case "rb9":
                    FlightType = "Flight3";
                    break;
                default:
                    FlightType = "None";
                    break;
            }

            string TravelType;
            string FlightTravelType;

            switch (cbname)
                {
                    case "rb1":
                        TravelType = " Economy";
                        break;
                    case "rb4":
                        TravelType =  " Economy";
                        break;
                    case "rb7":
                        TravelType =   " Economy";
                        break;
                    case "rb2":
                        TravelType = "Business";
                        break;
                    case "rb5":
                        TravelType = "Business";
                        break;
                    case "rb8":
                        TravelType = "Business";
                        break;
                    case "rb3":
                        TravelType = "First";
                        break;
                    case "rb6":
                        TravelType = "First";
                        break;
                    case "rb9":
                        TravelType = "First";
                        break;
                    default:
                        TravelType = "None";
                        break;
                }

            FlightTravelType = FlightType + " " + TravelType;
            MessageBox.Show(lblconfirm.Text.ToString() + " " + FlightTravelType);
                    
            rbDetailsRepeatCnt = false;
        }

        void FlightCheck(string flightDetails)
        {
            GetFlightDetails(new DateTime(2015, 03, 01, 12, 00, 00)); //{01/03/2015 00:00:00}
        }

        // returns true you when you are moving from one year to another
        bool Transition()
        {    
            TransitionString = lblm1.Text.ToString().Trim() + " " + lblm2.Text.ToString().Trim() + " " + lblm3.Text.ToString().Trim() + " " + lblm4.Text.ToString().Trim()
                + " " + lblm5.Text.ToString().Trim() + " " + lblm6.Text.ToString().Trim() + " " + lblm7.Text.ToString().Trim();

            if ((TransitionString.Contains("Dec") & TransitionString.Contains("Jan")) || lbl1.Text.Trim() == "1")
            {
                InTransitionPhase = true; // set this when in transition phase
                if (labelHolder == null)
                    labelHolder = lbl1.Text;
                return true;
            }
            else
            {
                //InTransitionPhase = false;
                return false;
            }              
        }

        // when moving to or still in transition - set the year
        string TrasitionYear(Label lb)
        {
            if (lblBackClick & (Convert.ToInt16(lb.Text) > 22 & Convert.ToInt16(lb.Text) < 32))
            {
                lblBackClick = false;
                CurrYear = (Convert.ToInt16(CurrYear) - 1).ToString(); //CurrTransitionYear
                labelHolder = lb.Text;
            }
            else if (lblBackClick & Convert.ToInt16(lb.Text) < 7)
            {
                lblBackClick = false;
                CurrYear = CurrYear.ToString();
                labelHolder = lb.Text;
            }
            else if (lblForwardClick & Convert.ToInt16(lb.Text) < 7)
            {
                lblForwardClick = false;
                CurrYear = (Convert.ToInt16(CurrYear) + 1).ToString();
                labelHolder = lb.Text;
            }
            else if (lblForwardClick & (Convert.ToInt16(lb.Text) > 22 & Convert.ToInt16(lb.Text) < 32))
            {
                lblForwardClick = false;
                CurrYear = CurrYear.ToString();
                labelHolder = lb.Text;
            }
            else // moving in Transition
            {               
                lblForwardClick = false;
                lblBackClick = false;
                if (Convert.ToInt16(labelHolder) < 7 & (Convert.ToInt16(lb.Text) > 22 & Convert.ToInt16(lb.Text) < 32))
                {
                    labelHolder = lb.Text;
                    CurrYear = (Convert.ToInt16(CurrYear) - 1).ToString();
                }
                else if ((Convert.ToInt16(labelHolder) > 22 & Convert.ToInt16(labelHolder) < 32) & Convert.ToInt16(lb.Text) < 7)
                {
                    labelHolder = lb.Text;
                    CurrYear = (Convert.ToInt16(CurrYear) + 1).ToString();  
                }  
                else
                    CurrYear = CurrYear.ToString();
            }
            return CurrYear;
        }

         // when moving out of transition - set the year
        string OutTrasitionYear(Label lb, String lbhold)
        {
           if (Convert.ToInt16(lb.Text) < 7 & (Convert.ToInt16(lbhold) > 22 & Convert.ToInt16(lbhold) < 32))
               CurrYear = (Convert.ToInt16(CurrYear) + 1).ToString(); 
            return CurrYear;
        }                  
                 
        // click event for radiobuttons date selection
        // this is called without an initial manual selection as it defaults to first radio button
        void rbm_CheckedChanged(object sender, EventArgs e)
        {
            if (initialdate)
            {
                initialdate = false;
                setinitialday(currDay);
                phaseweekYear = lblconfirm.Text;
            }     

            if (rbRepeatCnt == false)
            {
                rbRepeatCnt = true;
                //labelHolder = lbl1.Text;
                return;
            }                 

            if (rbm.Checked)
            {
                //labelHolder = lbl1.Text;
                if (Transition())
                {                   
                    TrasitionYear(lbl1);
                    lblYear.Text = CurrYear;
                }
                else if(InTransitionPhase)
                {
                    InTransitionPhase = false; // set to false so that know are out of transition completely
                    OutTrasitionYear(lbl1, labelHolder);
                    lblYear.Text = CurrYear;
                    //todo: need to someow know wht date is coming from intrasition i.e. wether is 1-7 or 23-31
                }
                   
                else
                    lblYear.Text = CurrYear;

                lblconfirm.Text = DayMonthDate(rbm);
                //lblconfirm.Text = lblMonday.Text.ToString() + " " + lblm1.Text.ToString().Trim() + "" + lbl1.Text.ToString();               
            }
            if (rbtu.Checked)
            {
                rbRepeatCnt = false;
                //labelHolder = lbl2.Text;
                if (Transition())
                {
                    TrasitionYear(lbl2);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbtu);
                //lblconfirm.Text = lblTuesday.Text.ToString() + " " + lblm2.Text.ToString().Trim() + "" + lbl2.Text.ToString();                              
            }
            if (rbwe.Checked) 
            {
                rbRepeatCnt = false;
                //labelHolder = lbl3.Text;
                if (Transition())
                {
                    TrasitionYear(lbl3);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbwe);
                //lblconfirm.Text = lblWednesday.Text.ToString() + " " + lblm3.Text.ToString().Trim() + "" + lbl3.Text.ToString();                
            }
            if (rbth.Checked) 
            {
                rbRepeatCnt = false;
                //labelHolder = lbl4.Text;
                if (Transition())
                {
                    TrasitionYear(lbl4);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbth);
               // lblconfirm.Text = lblThursday.Text.ToString() + " " + lblm4.Text.ToString().Trim() + "" + lbl4.Text.ToString();               
            }
            if (rbfr.Checked) 
            {
                rbRepeatCnt = false;
                //labelHolder = lbl5.Text;
                if (Transition())
                {
                    TrasitionYear(lbl5);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbfr);
                //lblconfirm.Text = lblFriday.Text.ToString() + " " + lblm5.Text.ToString().Trim() + "" + lbl5.Text.ToString();              
            }
            if (rbsa.Checked) 
            {
                rbRepeatCnt = false;
                //labelHolder = lbl6.Text;
                if (Transition())
                {
                    TrasitionYear(lbl6);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbsa);
                //lblconfirm.Text = lblSaturday.Text.ToString() + " " + lblm6.Text.ToString().Trim() + "" + lbl6.Text.ToString();               
            }
            if (rbsu.Checked)
            {
                rbRepeatCnt = false;
                //labelHolder = lbl7.Text;
                if (Transition())
                {
                    TrasitionYear(lbl7);
                    lblYear.Text = CurrYear;
                }
                else
                    lblYear.Text = CurrYear;
                lblconfirm.Text = DayMonthDate(rbsu);
                //lblconfirm.Text = lblSunday.Text.ToString() + " " + lblm7.Text.ToString().Trim() + "" + lbl7.Text.ToString();              
            }          
        }      

        void setinitialday(string currDay)
        {
            if (currDay == "Monday") { return; }
            else if (currDay == "Tuesday") 
            { 
                lblMonday.Text = "Tue";  lblTuesday.Text = "Wed"; lblWednesday.Text = "Thu";
                lblThursday.Text = "Fri"; lblFriday.Text = "Sat"; lblSaturday.Text = "Sun"; lblSunday.Text = "Mon";
            }
            else if (currDay == "Wednesday")
            {
                lblMonday.Text = "Wed"; lblTuesday.Text = "Thu"; lblWednesday.Text = "Fri";
                lblThursday.Text = "Sat"; lblFriday.Text = "Sun"; lblSaturday.Text = "Mon"; lblSunday.Text = "Tue";
            }
            else if (currDay == "Thursday")
            {
                lblMonday.Text = "Thu"; lblTuesday.Text = "Fri"; lblWednesday.Text = "Sat";
                lblThursday.Text = "Sun"; lblFriday.Text = "Mon"; lblSaturday.Text = "Tue"; lblSunday.Text = "Wed";
            }
            else if (currDay == "Friday")
            {
                lblMonday.Text = "Fri"; lblTuesday.Text = "Sat"; lblWednesday.Text = "Sun";
                lblThursday.Text = "Mon"; lblFriday.Text = "Tue"; lblSaturday.Text = "Wed"; lblSunday.Text = "Thu";
            }
            else if (currDay == "Saturday")
            {
                lblMonday.Text = "Sat"; lblTuesday.Text = "Sun"; lblWednesday.Text = "Mon";
                lblThursday.Text = "Tue"; lblFriday.Text = "Wed"; lblSaturday.Text = "Thu"; lblSunday.Text = "Fri";
            }
            else if (currDay == "Sunday")
            {
                lblMonday.Text = "Sun"; lblTuesday.Text = "Mon"; lblWednesday.Text = "Tue";
                lblThursday.Text = "Wed"; lblFriday.Text = "Thu"; lblSaturday.Text = "Fri"; lblSunday.Text = "Sat";
            }
        }

        // sets the date and month for each day of the current week
        void setCalendar(String CurrMonth)
        {
            var number = (int)((Months)Enum.Parse(typeof(Months), currM));
            Months m;

            lblm1.Text = CurrMonth;

            DateTime d = DateTime.Now;
            int daysInMonth = MonthLength(d);

            int t1 = Convert.ToInt32(CurrDate);           
            //if (t1 > 31)
            //{                
            //t1 = t1 - 31;
            //if (t1 > daysInMonth) { t1 = daysInMonth; }

            if (t1 == 1)
            {
                month = month + 1;
                if (month == 13) month = 1; // after december set to january
                m = (Months)(month);
                currM = m.ToString();
                lblm1.Text = CurrMonth;     
            }                
            //}   

            lbl1.Text = "    " + t1;
            lblm2.Text = currM;
            int t2 = t1+1;           
            if (t2 > 31)
            {
                t2 = t2 - 31;
                //if (t2 > daysInMonth) { t2 = daysInMonth; }
                if (t2 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm2.Text = currM;
                }
            }   
            lbl2.Text = "    " + t2;
            lblm3.Text = currM;            
            int t3 = t2 + 1;           
            if (t3 > 31)
            {
                t3 = t3 - 31;
                //if (t3 > daysInMonth) { t3 = daysInMonth; }

                if (t3 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm3.Text = currM;  
                }
            }   
            lbl3.Text = "    " + t3;
            lblm4.Text = currM;
            int t4 = t3 + 1;           
            if (t4 > 31)
            {
                t4 = t4 - 31;
                //if (t4 > daysInMonth) { t4 = daysInMonth; }

                if (t4 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm4.Text = currM;
                }
            }   
            lbl4.Text = "    " + t4;
            lblm5.Text = currM;
            int t5 = t4 + 1;            
            if (t5 > 31)
            {
                t5 = t5 - 31;
                //if (t5 > daysInMonth) { t5 = daysInMonth; }

                if (t5 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm5.Text = currM;
                }
            }  
            lbl5.Text = "    " + t5;
            lblm6.Text = currM;
            int t6 = t5 + 1;             
            if (t6 > 31)
            {
                t6 = t6 - 31;
                //if (t6 > daysInMonth) { t6 = daysInMonth; }

                if (t6 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm6.Text = currM;
                }
            } 
            lbl6.Text = "    " + t6;
            lblm7.Text = currM;
            int t7 = t6 + 1;           
            if (t7 > 31)
            {
                t7 = t7 - 31;
                //if (t7 > daysInMonth) { t7 = daysInMonth; }

                if (t7 == 1)
                {
                    month = month + 1;
                    if (month == 13) month = 1; // after december set to january
                    m = (Months)(month);
                    currM = m.ToString();
                    lblm7.Text = currM;
                }
            } 
            lbl7.Text = "    " + t7;
        }      

        void lblForward_Click(object sender, EventArgs e)
        {           

            lblForwardClick = true;
            lblBackClick = false;

            Months m;//= (Months)1;

            Months y = (Months)Enum.Parse(typeof(Months), currM);

            var number = (int)((Months)Enum.Parse(typeof(Months), currM));
            
            int t1 = Convert.ToInt32(lbl1.Text);
            t1 = t1 + 7;
            if (t1 > 31)
            {
                t1 = t1 - 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm1.Text));
                if (number == 12) number = 0;
                m = (Months)(number + 1);
                currM = m.ToString();
                lblm1.Text = m.ToString();    
            

            }            
            lbl1.Text = "     " + t1;//mondayF++;

            int monthx = System.DateTime.Now.Month;
            daysInMonth = 31;// System.DateTime.DaysInMonth(2015, monthx);

            int t2 = Convert.ToInt32(lbl2.Text);
            t2 = t2 + 7;
            if (t2 > daysInMonth) 
                {
                    t2 = t2 - daysInMonth;
                    //CurrMonth = now.ToString("MMM");
                    currM = CurrMonth.Substring(0, 3);
                    number = (int)((Months)Enum.Parse(typeof(Months), lblm2.Text));
                    if (number == 12) number = 0;
                    m = (Months)(number + 1);
                    currM = m.ToString();
                    lblm2.Text = m.ToString();                   
                }            
            lbl2.Text = "     " + t2;

            month = System.DateTime.Now.Month;
            daysInMonth = 31;// System.DateTime.DaysInMonth(2015, month);

            int t3 = Convert.ToInt32(lbl3.Text);
            t3 = t3 + 7;
            if (t3 > daysInMonth) 
                {
                    t3 = t3 - daysInMonth;
                    number = (int)((Months)Enum.Parse(typeof(Months), lblm3.Text));
                    if (number == 12) number = 0;
                    m = (Months)(number + 1);
                    currM = m.ToString();
                    lblm3.Text = m.ToString();                  
                }            
            lbl3.Text = "     " + t3;

            month = System.DateTime.Now.Month;
            daysInMonth = 31;// System.DateTime.DaysInMonth(2015, month);

            int t4 = Convert.ToInt32(lbl4.Text);
            t4 = t4 + 7;
            if (t4 > daysInMonth)
            {
                t4 = t4 - daysInMonth;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm4.Text));
                if (number == 12) number = 0;
                m = (Months)(number + 1);
                currM = m.ToString();
                lblm4.Text = m.ToString();                
            }            
            lbl4.Text = "     " + t4;

            month = System.DateTime.Now.Month;
            daysInMonth = 31;//System.DateTime.DaysInMonth(2015, month);

            int t5 = Convert.ToInt32(lbl5.Text);
            t5 = t5 + 7;
            if (t5 > daysInMonth)
            {
                t5 = t5 - daysInMonth;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm5.Text));
                if (number == 12) number = 0;
                m = (Months)(number + 1);
                currM = m.ToString();
                lblm5.Text = m.ToString();                
            }            
            lbl5.Text = "     " + t5;

            month = System.DateTime.Now.Month;
            daysInMonth = 31;// System.DateTime.DaysInMonth(2015, month);

            int t6 = Convert.ToInt32(lbl6.Text);
            t6 = t6 + 7;
            if (t6 > daysInMonth)
            {
                t6 = t6 - daysInMonth;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm6.Text));
                if (number == 12) number = 0;
                m = (Months)(number + 1);
                currM = m.ToString();
                lblm6.Text = m.ToString();                
            }            
            lbl6.Text = "     " + t6;

            month = System.DateTime.Now.Month;
            daysInMonth = 31;// System.DateTime.DaysInMonth(2015, month);

            int t7 = Convert.ToInt32(lbl7.Text);
            t7 = t7 + 7;
            if (t7 > daysInMonth)
            {
                t7 = t7 - daysInMonth;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm7.Text));
                if (number == 12) number = 0;
                m = (Months)(number + 1);
                currM = m.ToString();
                lblm7.Text = m.ToString();
            }
            else
            {
                lblm7.Text = currM;
            }
            lbl7.Text = "     " + t7;
      
            rbm.Checked = true;
            rbm_CheckedChanged(sender, e);
        }

        void lblBack_Click(object sender, EventArgs e)
        {
            string day, month, year;
            DateTime thisDay = DateTime.Today;            
            day = thisDay.Day.ToString();
            month = DateTime.Now.ToString("MMM"); 
            year = thisDay.Year.ToString();
           
            // not allow you to go back to dates in the past
            if (day == lbl1.Text.ToString().Trim() & month == lblm1.Text.ToString().Trim() & year == lblYear.Text.ToString().Trim())
                return;
            
            lblBackClick = true;
            lblForwardClick = false;

            Months m;//= (Months)1;

            Months y = (Months)Enum.Parse(typeof(Months), currM);

            var number = (int)((Months)Enum.Parse(typeof(Months), currM));
          
            int t1 = Convert.ToInt32(lbl1.Text);
            t1 = t1 - 7;
            if (t1 < 1) 
            { 
                t1 = t1 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm1.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm1.Text = m.ToString();     
  
                
            }
            lbl1.Text = "     " + t1;//mondayF++;

            int t2 = Convert.ToInt32(lbl2.Text);
            t2 = t2 - 7;
            if (t2 < 1) 
            { 
                t2 = t2 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm2.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm2.Text = m.ToString();  
            }
            lbl2.Text = "     " + t2;

            int t3 = Convert.ToInt32(lbl3.Text);
            t3 = t3 - 7;
            if (t3 < 1) 
            { 
                t3 = t3 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm3.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm3.Text = m.ToString();  

            }
            lbl3.Text = "     " + t3;

            int t4 = Convert.ToInt32(lbl4.Text);
            t4 = t4 - 7;
            if (t4 < 1) 
            { 
                t4 = t4 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm4.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm4.Text = m.ToString();  
            }
            lbl4.Text = "     " + t4;

            int t5 = Convert.ToInt32(lbl5.Text);
            t5 = t5 - 7;
            if (t5 < 1) 
            { 
                t5 = t5 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm5.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm5.Text = m.ToString();  
            }
            lbl5.Text = "     " + t5;

            int t6 = Convert.ToInt32(lbl6.Text);
            t6 = t6 - 7;
            if (t6 < 1)
            { 
                t6 = t6 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm6.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm6.Text = m.ToString();  
            }
            lbl6.Text = "     " + t6;

            int t7 = Convert.ToInt32(lbl7.Text);
            t7 = t7 - 7;
            if (t7 < 1) 
            { 
                t7 = t7 + 31;
                number = (int)((Months)Enum.Parse(typeof(Months), lblm7.Text));
                if (number == 1) number = 13;
                m = (Months)(number - 1);
                currM = m.ToString();
                lblm7.Text = m.ToString();  
            }
            lbl7.Text = "     " + t7;          

            rbm.Checked = true;
            rbm_CheckedChanged(sender, e);           
        }

        private void setBackgroundImage(string CntryDest)
        {
            string d = @"C:\Users\jules\Documents\Visual Studio 2010\Projects\C#\AirLineReservationSystemEntityFramework\AirLineReservationSystem\Resources\";
            this.BackgroundImage = Image.FromFile(d + "" + CntryDest + ".jpg");

        }

        //public struct FlightDetails
        //{
        //    public string dest1;
        //    public string dest2;
        //    public DateTime Date1;
        //    public DateTime Date2;
        //    public string route;
        //    public int adults;
        //    public int children;
        //    public string ticketType;
        //}          

        private void FindFlight_Load(object sender, EventArgs e)
        {
            // Remove the control box so the form will only display client area i.e. Create a Borderless Window
            this.ControlBox = false;
        }

        private void lblBookFlightBack_Click(object sender, EventArgs e)
        {
            ar.Connection.Close();
            this.Close();
        }

        private void lblConfirmFlight_Click(object sender, EventArgs e)
        {
            // open new form           
            //rf = new ReserveFlight(this);
            pd = new Passenger_Details(this);
            pd.MdiParent = this.ParentForm;
            pd.FormClosed += new FormClosedEventHandler(pd_FormClosed);
            this.Dock = DockStyle.Fill;
            pd.Show();  
        }

        void pd_FormClosed(object sender, FormClosedEventArgs e)
        {
            rf = null;
            //throw new NotImplementedException();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1.Checked == true)
            {
                rb2.Checked = false;
                rb3.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
            }

            lblFlight.Text = lblFlight1.Text;
            lbltype.Text = lblEco.Text;
            lblPrice.Text = lblprice1.Text;
               
        }       

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3.Checked == true)
            {
                rb2.Checked = false;
                rb1.Checked = false;
                rb5.Checked = false;
                rb4.Checked = false;
                rb8.Checked = false;
                rb7.Checked = false;
            }

            lblFlight.Text = lblFlight1.Text;
            lbltype.Text = lblFirst.Text;
            lblPrice.Text = lblprice3.Text;
               
        }

        private void rb2_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rb2.Checked == true)
            {
                rb1.Checked = false;
                rb3.Checked = false;
                rb6.Checked = false;
                rb4.Checked = false;
                rb9.Checked = false;
                rb7.Checked = false;
            }

            lblFlight.Text = lblFlight1.Text;
            lbltype.Text = lblBus.Text;
            lblPrice.Text = lblprice2.Text;
        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4.Checked == true)
            {
                rb5.Checked = false;
                rb6.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb8.Checked = false;
                rb7.Checked = false;
            }

            lblFlight.Text = lblFlight2.Text;
            lbltype.Text = lblEco.Text;
            lblPrice.Text = lblprice4.Text;
        }

        private void rb5_CheckedChanged(object sender, EventArgs e)
        {
            if (rb5.Checked == true)
            {
                rb4.Checked = false;
                rb6.Checked = false;
                rb1.Checked = false;
                rb3.Checked = false;
                rb8.Checked = false;
                rb7.Checked = false;
            }
            lblFlight.Text = lblFlight2.Text;
            lbltype.Text = lblBus.Text;
            lblPrice.Text = lblprice5.Text;
        }

        private void rb6_CheckedChanged(object sender, EventArgs e)
        {
            if (rb6.Checked == true)
            {
                rb4.Checked = false;
                rb5.Checked = false;
                rb8.Checked = false;
                rb7.Checked = false;
                rb2.Checked = false;
                rb1.Checked = false;
            }

            lblFlight.Text = lblFlight2.Text;
            lbltype.Text = lblFirst.Text;
            lblPrice.Text = lblprice6.Text;
        }

        private void rb7_CheckedChanged(object sender, EventArgs e)
        {
            if (rb7.Checked == true)
            {
                rb8.Checked = false;
                rb9.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
            }

            lblFlight.Text = lblFlight3.Text;
            lbltype.Text = lblEco.Text;
            lblPrice.Text = lblprice7.Text;
        }

        private void rb8_CheckedChanged(object sender, EventArgs e)
        {
            if (rb8.Checked == true)
            {
                rb7.Checked = false;
                rb9.Checked = false;
                rb4.Checked = false;
                rb6.Checked = false;
                rb1.Checked = false;
                rb3.Checked = false;
            }

            lblFlight.Text = lblFlight3.Text;
            lbltype.Text = lblBus.Text;
            lblPrice.Text = lblprice8.Text;
        }

        private void rb9_CheckedChanged(object sender, EventArgs e)
        {
            if (rb9.Checked == true)
            {
                rb7.Checked = false;
                rb8.Checked = false;
                rb2.Checked = false;
                rb1.Checked = false;
                rb5.Checked = false;
                rb4.Checked = false;
            }

            lblFlight.Text = lblFlight3.Text;
            lbltype.Text = lblFirst.Text;
            lblPrice.Text = lblprice9.Text;
        }

        
      

       



    }
}
