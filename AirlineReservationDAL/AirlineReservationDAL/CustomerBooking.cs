using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;

namespace AirlineReservationDAL
{

    #pragma warning disable 0169  // disable never used warnings for fields that are being used by LINQ

    [Table(Name = "CustomerBooking")]
    public class CustomerBooking
    {
        #region "Maping M:1 Booking Relationship"
        [Column(IsPrimaryKey = true, Name = "BookID")] 
        private int cstBkBookID; 
        private EntityRef<Booking> _Booking = new EntityRef<Booking>();
        [Association(Name = "FK_CustomerBooking_Booking1", IsForeignKey = true, Storage = "_Booking", ThisKey = "cstBkBookID")]
        public Booking Bookings  
        {
            get { return _Booking.Entity; }
            set 
            { 
                Booking priorBooking=  _Booking.Entity ;
                Booking newBooking = value;

                if (newBooking != priorBooking)
                {
                    _Booking.Entity = null;
                    if (priorBooking != null)
                        priorBooking.CustomerBookings.Remove(this);

                    _Booking.Entity = newBooking;
                    newBooking.CustomerBookings.Add(this);
                }   
            }
         }
         #endregion "Maping M:1 Booking Relationship"

        #region "Maping M:1 Customer Relationship"
        [Column(IsPrimaryKey = true, Name = "CustomerID")]
        private int cstBkCustomerId;
        private EntityRef<Customer> _Customer = new EntityRef<Customer>();
        [Association(Name = "FK_CustomerBooking_Customer1", IsForeignKey = true, Storage = "_Customer", ThisKey = "cstBkCustomerId")]
         public Customer Customers 
         {
             get { return _Customer.Entity; }
             set 
             { 
                 Customer priorCustomer =  _Customer.Entity;
                 Customer newCustomer = value;

                 if (newCustomer != priorCustomer)
                 {
                     _Customer.Entity = null;
                     if (priorCustomer != null)
                         priorCustomer.CustomerBookings.Remove(this);

                     _Customer.Entity = newCustomer;
                     newCustomer.CustomerBookings.Add(this);
                 }
             }
         }
         #endregion "Maping M:1 Customer Relationship"    

        // Delete the record from the database - Remove the CustomerBookings instance from Booking and Customer.   
        public void Remove()
        {         
            AirlineReservation.RemoveRecord(this);

            Booking priorBooking = Bookings;
            priorBooking.CustomerBookings.Remove(this);         

            Customer priorCustomer = Customers;
            priorCustomer.CustomerBookings.Remove(this);           
        }

   

    }
}
