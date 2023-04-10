using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
     [Table(Name = "ContactDetails")]
   public class ContactDetailsDal
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int ContactCustID { get; set; }
         
         [Column]
         public string HouseID { get; set; }
         [Column]
         public string Street1 { get; set; }
         [Column]
         public string Steet2 { get; set; }
         [Column]
         public string Town { get; set; }
         [Column]
         public string City { get; set; }
         [Column]
         public string County { get; set; }
         [Column]
         public string email { get; set; }
         [Column]
         public int TelNo { get; set; }
         [Column]
         public int Mobile { get; set; } 



    }
}
