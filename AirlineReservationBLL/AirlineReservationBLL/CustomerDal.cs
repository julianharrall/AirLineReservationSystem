using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
    [Table(Name = "Customer")]
   public class CustomerDal
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int CustID { get; set; }
        
        [Column]
        public string CustFirstName { get; set; }
        [Column]
        public string DOB { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Gender { get; set; }
        [Column]
        public string CustLastName { get; set; }
        [Column]
        public string ContactID { get; set; }
        [Column]
        public string CustomerType { get; set; }
        [Column]
        public int ArchiveID { get; set; } 
    }
}
