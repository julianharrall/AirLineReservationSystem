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

    #pragma warning disable 0169  // disable never used warnings for fields that are being used by LINQ

    [Table(Name = "Booking")]
    public class Booking
    {
        #region "Constructor"
        public Booking()
        {
            // Construct the EntitySet by passing in these two delegate methods. 
            // Since the methods are instance methods, you'll need to do this in Destination's constructor:
            _Customer = new EntitySet<Customer>(OnCustomerAdded, OnCustomerRemoved);

            //if (ar is null)
            //ar = new AirlineReservationDAL.AirlineReservation();
        }
        #endregion "Constructor" 

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int BookingID { get; set; }
        #endregion "Map Primary Key"      
               
        #region "Maping 1:M Customer Relationship"
        private EntitySet<Customer> _Customer = new EntitySet<Customer>();

        [Association(Name = "FK_Customer_Booking", Storage = "_Customer", OtherKey = "BookingID", ThisKey = "BookingID")]
        public ICollection<Customer> Customers
        {
            get { return _Customer; }
            set { _Customer.Assign(value); }
        }
        #endregion "Maping 1:M Customer Relationship"   

        #region "Delegate methods to handle synchronization with Customer table - called whenever item added/removed from its collection"
        private void OnCustomerAdded(Customer addedCustomer)
        {
            addedCustomer.Booking = this;
        }

        private void OnCustomerRemoved(Customer removedCustomer)
        {
            removedCustomer.Booking = null;
        }

        #endregion "Delegate methods to handle synchronization with Customer table - called whenever item added/removed from its collection"

        #region "Maping M:1 Payment Relationship"
        [Column]
        public int? PaymentID;
        private EntityRef<Payment> _PaymentID = new EntityRef<Payment>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Payment 
        //inside the EntityRef _PaymentID, which we then use as the backing field for our Payment property.
        //Set Booking's PaymentID property up as an Association so that we can retrieve the Payment instance that this Booking is associated with 
        [Association(Name = "FK_Booking_Payment", IsForeignKey = true, Storage = "_PaymentID", ThisKey = "PaymentID")]
        public Payment Payment
        {
            get { return _PaymentID.Entity; }
            set
            {
                Payment priorPayment = _PaymentID.Entity;
                Payment newPayment = value;

                // Don't do anything if the new Payment is the same as the old Payment
                if (newPayment != priorPayment)
                {
                    // remove this Booking from our prior Payment's list of Bookings
                    _PaymentID.Entity = null;

                    if (priorPayment != null)
                        priorPayment.Bookings.Remove(this);

                    // set Payment to the new value
                    _PaymentID.Entity = newPayment;

                    // add this Booking to the new Payment's list of Bookings
                    if (newPayment != null)
                        newPayment.Bookings.Add(this);
                }
            }
        }
        #endregion "Maping M:1 Payment Relationship"  

        #region "Maping M:1 Flight Relationship"
        //Add a private field that maps to the foreign key column.
        [Column] 
        public int? FlightNumber; 
        // An entity class on the manyside of a one-to-many relationship stores its associated one entity class in a class member of type EntityRef<T>
        // where type t is the type of the associated entity class. Booking is Many side of the one-to-many relationship with Flight
        private EntityRef<Flight> _FlightNumber = new EntityRef<Flight>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Destination 
        //inside the EntityRef _FlightNumber, which we then use as the backing field for our Flight property.
        //Set Booking's _FlightNumber property up as an Association so that we can retrieve the Flight instance that this Booking is associated with 
        [Association(Name = "FK_Booking_Flight", IsForeignKey = true, Storage = "_FlightNumber", ThisKey = "FlightNumber")]
        public Flight Flight
        {
            get { return _FlightNumber.Entity; }
            set
            {
                Flight priorFlight = _FlightNumber.Entity;
                Flight newFlight = value;

                // Don't do anything if the new Flight is the same as the old Flight
                if (newFlight != priorFlight)
                {
                    // remove this Booking from our prior Flight's list of Bookings
                    _FlightNumber.Entity = null;

                    if (priorFlight != null)                    
                        priorFlight.Bookings.Remove(this);

                    // set Destination to the new value
                    _FlightNumber.Entity = newFlight;

                    // add this flight to the new Destination's list of flights
                    if (newFlight != null)                    
                        newFlight.Bookings.Add(this);                    
                }
            }
        }


        // A Booking has one Flight, using FlightN to access the Flight for a specific Booking
        // _FlightNumber.Entity is an instance of Flight for a particuliar value
        // For each instance of Booking it will ive you the equivalent/linking details of Flight
        public Flight FlightN
         {
             get { return _FlightNumber.Entity; }
             set { _FlightNumber.Entity = value; }
         }
        #endregion "Maping M:1 Flight Relationship"          

        /*
        #region "Maping M:1 - Customer Relationship"
        //Add a private field that maps to the foreign key column.
        [Column] private int CustID;
        // An entity class on the manyside of a one-to-many relationship stores its associated one entity class in a class member of type EntityRef<T>
        // where type t is the type of the associated entity class. Booking is Many side of the one-to-many relationship with Customer
        private EntityRef<Customer> _CustID = new EntityRef<Customer>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Destination 
        //inside the EntityRef _CustID, which we then use as the backing field for our Customer property.
        //Set Booking's _CustID property up as an Association so that we can retrieve the Customer instance that this Booking is associated with 
        [Association(Name = "FK_Booking_Customer", IsForeignKey = true, Storage = "_CustID", ThisKey = "CustID")]
                

        // A Booking has one Customer, using CustomerN to access the Customer for a specific Booking
        // _CustID.Entity is an instance of Customer for a particuliar value
        // For each instance of Booking it will ive you the equivalent/linking details of Customer
        public Customer CustomerN
        {
            get { return _CustID.Entity; }
            set { _CustID.Entity = value; }
        }

        #endregion "Maping M:1 - Customer Relationship"
        */

        #region "Columns"
        [Column] public string ReservationNum { get; set; }         
        #endregion "Columns"
    }
}
