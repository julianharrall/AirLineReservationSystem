using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
    [Table(Name = "Flight")]
    public class FlightDal
    {
        [Column(IsPrimaryKey = true)]
        public int FlightNumber { get; set; }

        [Column]
        public string AircraftType { get; set; }
        [Column]
        public string TravelClass { get; set; }
        [Column]
        public string Country { get; set; }      
        [Column]
        public DateTime OutwardDate { get; set; }
        [Column]
        public DateTime InwardDate { get; set; }
        [Column]
        public decimal OutwardTime { get; set; }
        [Column]
        public decimal InwardTime { get; set; }
    }
}
