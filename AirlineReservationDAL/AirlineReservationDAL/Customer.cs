using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlineReservationDAL
{
    #pragma warning disable 0169        // disable never used warnings for fields that are being used by LINQ

   [Table(Name = "Customer")]
   public class Customer
   {
        #region "Constructor"
        public Customer()
        {
            // Construct the EntitySet by passing in these two delegate methods. 
            // Since the methods are instance methods, you'll need to do this in Customer's constructor:
            //_Booking = new EntitySet<Booking>(OnBookingAdded, OnBookingRemoved);
        }
        #endregion "Constructor"

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int CustID { get; set; }
        #endregion "Map Primary Key"

        #region "Maping M:1 Booking Relationship"
        [Column]
        public int? BookingID;
        private EntityRef<Booking> _BookingID = new EntityRef<Booking>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Destination 
        //inside the EntityRef _DestID, which we then use as the backing field for our Destination property.
        //Set Flight's DestID property up as an Association so that we can retrieve the Destination instance that this Flight is associated with 
        [Association(Name = "FK_Customer_Booking", IsForeignKey = true, Storage = "_BookingID", ThisKey = "BookingID")]
        public Booking Booking
        {
            get { return _BookingID.Entity; }
            set
            {
                Booking priorBook = _BookingID.Entity;
                Booking newBook = value;

                // Don't do anything if the new Destination is the same as the old Destination
                if (newBook != priorBook)
                {
                    // remove this Flight from our prior Destination's list of Flights
                    _BookingID.Entity = null;

                    if (priorBook != null)
                        priorBook.Customers.Remove(this);

                    // set Destination to the new value
                    _BookingID.Entity = newBook;

                    // add this flight to the new Destination's list of flights
                    if (newBook != null)
                        newBook.Customers.Add(this);
                }
            }
        }
        #endregion "Maping M:1 Booking Relationship"  

        #region "Columns"
        [Column] public string CustType { get; set; }
        [Column] public string CustFirstName { get; set; }       
        [Column] public string Gender { get; set; }
        [Column] public string CustLastName { get; set; }         
       
        #endregion "Columns"
   }
}
