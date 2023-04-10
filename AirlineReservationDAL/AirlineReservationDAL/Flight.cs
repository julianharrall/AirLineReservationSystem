using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;


namespace AirlineReservationDAL
{

    #pragma warning disable 0169        // disable never used warnings for fields that are being used by LINQ

    [Table(Name = "Flight")]
    public class Flight
    {
        #region "Constructor"
        public Flight()
        {
            // Construct the EntitySet by passing in these two delegate methods. 
            // Since the methods are instance methods, you'll need to do this in Flight's constructor:
            _Booking = new EntitySet<Booking>(OnBookingAdded, OnBookingRemoved);
        }
        #endregion "Constructor"

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int FlightNumber { get; set; }
        #endregion "Map Primary Key"

        #region "Maping M:1 Destination Relationship"
        [Column]
        public int? DestID; 
        private EntityRef<Destination> _DestID = new EntityRef<Destination>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Destination 
        //inside the EntityRef _DestID, which we then use as the backing field for our Destination property.
        //Set Flight's DestID property up as an Association so that we can retrieve the Destination instance that this Flight is associated with 
        [Association(Name = "FK_Flight_Destination", IsForeignKey = true, Storage = "_DestID", ThisKey = "DestID")]
        public Destination Destination
        {
            get { return _DestID.Entity; }
            set
            {
                Destination priorDest = _DestID.Entity;
                Destination newDest = value;

                // Don't do anything if the new Destination is the same as the old Destination
                if (newDest != priorDest)
                {
                    // remove this Flight from our prior Destination's list of Flights
                    _DestID.Entity = null;

                    if (priorDest != null)                    
                        priorDest.Flights.Remove(this);
                   
                    // set Destination to the new value
                    _DestID.Entity = newDest;

                    // add this flight to the new Destination's list of flights
                    if (newDest != null)                    
                        newDest.Flights.Add(this);                    
                }
            }
        }
        #endregion "Maping M:1 Destination Relationship"  
    
        #region "Maping M:1 Airport Relationship"
        [Column]
        public int? AirportID;
        private EntityRef<Airport> _AirportID = new EntityRef<Airport>();

        //The Association attribute tells LINQ to SQL to place an instance of the appropriate Destination 
        //inside the EntityRef _DestID, which we then use as the backing field for our Destination property.
        //Set Flight's DestID property up as an Association so that we can retrieve the Destination instance that this Flight is associated with 
        [Association(Name = "FK_Flight_Airport", IsForeignKey = true, Storage = "_AirportID", ThisKey = "AirportID")]
        public Airport Airport
        {
            get { return _AirportID.Entity; }
            set
            {
                Airport priorAirport = _AirportID.Entity;
                Airport newAirport = value;

                // Don't do anything if the new Destination is the same as the old Destination
                if (newAirport != priorAirport)
                {
                    // remove this Flight from our prior Destination's list of Flights
                    _AirportID.Entity = null;

                    if (priorAirport != null)
                        priorAirport.AptFlights.Remove(this);

                    // set Destination to the new value
                    _AirportID.Entity = newAirport;

                    // add this flight to the new Destination's list of flights
                    if (newAirport != null)
                        newAirport.AptFlights.Add(this);
                }
            }
        }
        #endregion "Maping M:1 Airport Relationship"

        #region "Maping M:1 Aircraft Relationship"
        [Column]
        public int? AircraftNumber;
        private EntityRef<Aircraft> _AircraftNumber = new EntityRef<Aircraft>();

        [Association(Name = "FK_Flight_Aircraft", IsForeignKey = true, Storage = "_AircraftNumber", ThisKey = "AircraftNumber")]
        public Aircraft AircraftNumb
        {
            get { return _AircraftNumber.Entity; }
            set 
            {
                Aircraft priorAircraft = _AircraftNumber.Entity;
                Aircraft newAircraft = value;

                if (newAircraft != priorAircraft)
                {
                    _AircraftNumber.Entity = null;

                    if (priorAircraft != null)
                        priorAircraft._flightAcfts.Remove(this);

                    _AircraftNumber.Entity = newAircraft;

                    if (newAircraft != null)
                        newAircraft._flightAcfts.Add(this);
                }                
            }
        }
        #endregion "Maping M:1 Aircraft Relationship"

        #region "Maping 1:M Booking Relationship"       
        private EntitySet<Booking> _Booking = new EntitySet<Booking>();

        [Association(Name = "FK_Booking_Flight", Storage = "_Booking", OtherKey = "FlightNumber", ThisKey = "FlightNumber")]
        public ICollection<Booking> Bookings
        {
            get { return _Booking; }
            set { _Booking.Assign(value); }
        }

        #endregion "Maping 1:M Booking Relationship"

        #region "Delegate methods to handle synchronization with Booking table - called whenever item added/removed from its collection"
        private void OnBookingAdded(Booking addedBooking)
        {
            addedBooking.Flight = this;
        }

        private void OnBookingRemoved(Booking removedBooking)
        {
            removedBooking.Flight = null;
        }

        #endregion "Delegate methods to handle synchronization with Booking table - called whenever item added/removed from its collection"

        #region "Columns"
        [Column] public string FlightNum { get; set; }
        [Column] public DateTime? OutDateTime { get; set; }
        [Column] public DateTime? InDateTime { get; set; }       
        [Column] public decimal Business { get; set; }
        [Column] public decimal First { get; set; }
        [Column] public decimal Economy { get; set; }
        [Column] public int Seats { get; set; }
        #endregion "Columns"
    }
}
