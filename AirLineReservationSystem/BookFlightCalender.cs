using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirLineReservationSystem
{
    public class BookFlightCalender
    {
        string DayOfWeekstring { get; set; }
        DateTime dtnow { get; set; }
        DateTime dtmove { get; set; }
        string day1 { get; set; }
        string day2 { get; set; }
        string day3 { get; set; }
        string day4 { get; set; }
        string day5 { get; set; }
        string day6 { get; set; }
        string day7 { get; set; }
        bool forwardbool { get; set; }
        bool backbool { get; set; }

        public string textBox1 { get; set; }
        public string textBox2 { get; set; }
        public string textBox3 { get; set; }
        public string textBox4 { get; set; }
        public string textBox5 { get; set; }
        public string textBox6 { get; set; }
        public string textBox7 { get; set; }
        public string textBox8 { get; set; }
        public string textBox9 { get; set; }
        public string textBox10 { get; set; }
        public string textBox11 { get; set; }
        public string textBox12 { get; set; }
        public string textBox13 { get; set; }
        public string textBox14 { get; set; }
        public string textBox15 { get; set; }
        public string textBox16 { get; set; }
        public string textBox17 { get; set; }
        public string textBox18 { get; set; }
        public string textBox19 { get; set; }
        public string textBox20 { get; set; }
        public string textBox21 { get; set; }
        public string textBox22 { get; set; }
        public string textBox23 { get; set; }

        public BookFlightCalender()
        {
            DateTime dt = new DateTime();
            dt.DayOfWeek.ToString();
            dt.Day.ToString();

           
            DateTime dtmove;

            dtnow = DateTime.Now;
            dtnow.ToString();
            int Daystring = dtnow.Day;
            DayOfWeekstring = dtnow.DayOfWeek.ToString();
            int Monthstring = dtnow.Month;
            string Yearstring = dtnow.Year.ToString();

            dtmove = dtnow;

            textBox22 = dtmove.Year.ToString();

           
            ForwardDateTime();
        }

        public void ForwardClick()
        {
            dtnow = dtnow.AddDays(1);
            ForwardDateTime();
        }

        public void ForwardDateTime()
        {
            forwardbool = true;

            textBox14 = dtnow.ToString("MMMM");
            textBox21 = dtnow.Day.ToString();
            textBox22 = dtnow.Year.ToString();
            day1 = dtnow.DayOfWeek.ToString();

            if (backbool)
                dtnow = dtnow.AddDays(7);
            else
                dtnow = dtnow.AddDays(1);

            textBox13 = dtnow.ToString("MMMM");
            textBox20 = dtnow.Day.ToString();
            day2 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(1);
            textBox12 = dtnow.ToString("MMMM");
            textBox19 = dtnow.Day.ToString();
            day3 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(1);
            textBox11 = dtnow.ToString("MMMM");
            textBox18 = dtnow.Day.ToString();
            day4 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(1);
            textBox10 = dtnow.ToString("MMMM");
            textBox17 = dtnow.Day.ToString();
            day5 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(1);
            textBox9 = dtnow.ToString("MMMM");
            textBox16 = dtnow.Day.ToString();
            day6 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(1);
            textBox8 = dtnow.ToString("MMMM");
            textBox15 = dtnow.Day.ToString();
            textBox23 = dtnow.Year.ToString();
            day7 = dtnow.DayOfWeek.ToString();

            textBox1 = day1;
            textBox2 = day2;
            textBox3 = day3;
            textBox4 = day4;
            textBox5 = day5;
            textBox6 = day6;
            textBox7 = day7;

            backbool = false;
        }


        private void Back_Click(object sender, EventArgs e)
        {
            backbool = true;

            if (forwardbool)
                dtnow = dtnow.AddDays(-6);
            else
                dtnow = dtnow.AddDays(0);

            dtnow = dtnow.AddDays(-1);
            textBox8 = dtnow.ToString("MMMM");
            textBox15 = dtnow.Day.ToString();
            textBox23 = dtnow.Year.ToString();
            day1 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox9 = dtnow.ToString("MMMM");
            textBox16 = dtnow.Day.ToString();
            day2 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox10 = dtnow.ToString("MMMM");
            textBox17 = dtnow.Day.ToString();
            day3 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox11 = dtnow.ToString("MMMM");
            textBox18 = dtnow.Day.ToString();
            day4 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox12 = dtnow.ToString("MMMM");
            textBox19 = dtnow.Day.ToString();
            day5 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox13 = dtnow.ToString("MMMM");
            textBox20 = dtnow.Day.ToString();
            day6 = dtnow.DayOfWeek.ToString();
            dtnow = dtnow.AddDays(-1);
            textBox14 = dtnow.ToString("MMMM");
            textBox21 = dtnow.Day.ToString();
            textBox22 = dtnow.Year.ToString();
            day7 = dtnow.DayOfWeek.ToString();



            textBox1 = day7;
            textBox2 = day6;
            textBox3 = day5;
            textBox4 = day4;
            textBox5 = day3;
            textBox6 = day2;
            textBox7 = day1;

            forwardbool = false;
        }
    }
}
