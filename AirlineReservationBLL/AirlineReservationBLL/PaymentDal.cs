using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AirlineReservationDAL
{
    [Table(Name = "Payment")]
   public class PaymentDal
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int PaymentID { get; set; }

        [Column]
        public string BookingRef { get; set; }
        [Column]
        public string CardType { get; set; }
        [Column]
        public int CardNumber { get; set; } 
        [Column]
        public DateTime Expiry { get; set; }
        [Column]
        public decimal Amount { get; set; }
        [Column]
        public int BillingAddress { get; set; }
       
       
    }
}
