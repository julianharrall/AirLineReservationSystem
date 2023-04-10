using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
    [Table(Name = "Destination")]
   public class DestinationDal
    {
        [Column(IsPrimaryKey = true)]
        public int Country { get; set; }

        [Column]
        public string Airport { get; set; }
        [Column]
        public string Gate { get; set; }
        [Column]
        public string DestinationType { get; set; }
    }
}
