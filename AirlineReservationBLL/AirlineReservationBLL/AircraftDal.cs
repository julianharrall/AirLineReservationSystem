using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;


namespace AirlineReservationDAL
{
    [Table(Name = "Aircraft")]
    public class AircraftDal
    {
        [Column(IsPrimaryKey = true)]
        public string AircraftType { get; set; }

        [Column]
        public string SeatCapacity { get; set; }
        [Column]
        public string SerialNumber { get; set; }
        [Column]
        public int SeatTotal { get; set; }
    }
    
}
