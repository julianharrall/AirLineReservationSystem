using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineReservationSystem
{
    public static class FlightCustDetails
    {

        public static List<string> Adults { get; set; } = new List<string>();
        public static List<string> Children { get; set; } = new List<string>();
     
        public static List<string> CardDetails { get; set; } = new List<string>();
        public static List<string> AddressDetails { get; set; } = new List<string>();


        public static string FlightNum { get; set; }
        public static string FlightOut { get; set; }
        public static string FlightIn { get; set; }
        public static string FlightType { get; set; }
        public static string FlightAirport { get; set; }
        public static string FlightCountry { get; set; }
        public static string CardAuthReference { get; set; }    
        public static string FlightCost { get; set; }
        public static string ReservationNum { get; set; }

        public static void ClearFields()
        {
            ReservationNum = "";
            CardDetails.Clear();
            AddressDetails.Clear();
            Adults.Clear();
            Children.Clear();
            FlightNum = "";
            FlightOut = "";
            FlightIn = "";
            FlightType = "";
            FlightAirport = "";
            FlightCountry = "";
            FlightCost = "";
        }

    }
}
