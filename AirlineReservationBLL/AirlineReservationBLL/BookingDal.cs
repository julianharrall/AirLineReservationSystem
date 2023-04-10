using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
     [Table(Name = "Booking")]
    public class BookingDal
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int BookingID { get; set; }

         [Column]
         public string Class { get; set; }
         [Column]
         public string FlightNumber { get; set; }
         [Column]
         public string BookingType { get; set; }
         [Column]
         public string Cost { get; set; }
         [Column]
         public string TicketType { get; set; }
         [Column]
         public int PassengerCount { get; set; }
         [Column]
         public int PaymentID { get; set; } 
    }
}
