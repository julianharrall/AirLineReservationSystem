using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
     [Table(Name = "Seat")]
   public class SeatDal
    {
         [Column(IsPrimaryKey = true)]
         public int SeatType { get; set; }

         [Column]
         public string Priority { get; set; }
         [Column]
         public string Size { get; set; }
         [Column]
         public string Position { get; set; }
         [Column]
         public int FirtsClassSeats { get; set; }
         [Column]
         public int EconomySeats { get; set; }
         [Column]
         public int BusinessSeats { get; set; }
    }
}
