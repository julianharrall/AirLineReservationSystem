using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;

namespace AirlineReservationDAL
{
    [Table(Name = "Airport")]
    public class Airport
    {
        #region "Constructor"
        public Airport()
         {
             _flightApt = new EntitySet<Flight>(OnFlightAptAdded, OnFlightAptRemoved);
         }
        #endregion "Constructor"

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int AirportID { get; set; }
         #endregion "Map Primary Key"

        #region "Maping 1:M Flight Relationship"
         private EntitySet<Flight> _flightApt = new EntitySet<Flight>();

         [Association(Name = "FK_Flight_Airport", Storage = "_flightApt", OtherKey = "AirportID", ThisKey = "AirportID")]
         public ICollection<Flight> AptFlights 
         {
             get { return _flightApt; }
             set { _flightApt.Assign(value); }
         }
         #endregion "Maping 1:M Flight Relationship"   
   
        #region "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"

         private void OnFlightAptAdded(Flight addFlight)
         {
             addFlight.Airport = this;
         }

         private void OnFlightAptRemoved(Flight removeFlight)
         {
             removeFlight.Airport = null;
         }

         #endregion "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"

        #region "Columns"
        [Column] public string AirportGate { get; set; }
        [Column] public string AirportName { get; set; }
        #endregion "Columns"
    }
}
