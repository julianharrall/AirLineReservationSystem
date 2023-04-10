using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
     [Table(Name = "Archive")]
    public class ArchiveDal
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int ArchiveID { get; set; }

         [Column]
         public string SeatCapacity { get; set; }
    }
}
