using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;

namespace AirlineReservationDAL
{

    #pragma warning disable 0169        // disable never used warnings for fields that are being used by            

    [Table(Name = "Payment")]
   public class Payment
   {

        #region "Constructor"
        public Payment()
        {
            // Construct the EntitySet by passing in these two delegate methods. 
            // Since the methods are instance methods, you'll need to do this in Destination's constructor:
            _Booking = new EntitySet<Booking>(OnBookingAdded, OnBookingRemoved);

            //if (ar is null)
            //ar = new AirlineReservationDAL.AirlineReservation();
        }
        #endregion "Constructor" 

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
       public int PaymentID { get; set; }
        #endregion "Map Primary Key"

        #region "Maping 1:M Booking Relationship"
        private EntitySet<Booking> _Booking = new EntitySet<Booking>();

        [Association(Name = "FK_Booking_Payment", Storage = "_Booking", OtherKey = "PaymentID", ThisKey = "PaymentID")]
        public ICollection<Booking> Bookings
        {
            get { return _Booking; }
            set { _Booking.Assign(value); }
        }
        #endregion "Maping 1:M Booking Relationship"  

        #region "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"
        private void OnBookingAdded(Booking addedBooking)
        {
            addedBooking.Payment = this;
        }

        private void OnBookingRemoved(Booking removedBooking)
        {
            removedBooking.Payment = null;
        }

        #endregion "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"

        #region "Columns"      
        [Column] public string NameOnCard { get; set; }
        [Column] public string CardNumber { get; set; } 
        [Column] public DateTime Expiry { get; set; }
        [Column] public decimal Amount { get; set; }
        [Column] public int CSV { get; set; }
        #endregion "Columns"

    }
}
