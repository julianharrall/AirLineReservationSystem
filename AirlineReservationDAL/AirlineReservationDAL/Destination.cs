using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;

namespace AirlineReservationDAL
{
   [Table(Name = "Destination")]
   public class Destination
   {
        //AirlineReservationDAL.AirlineReservation ar;

       #region "Constructor"
        public Destination()
        {
            // Construct the EntitySet by passing in these two delegate methods. 
            // Since the methods are instance methods, you'll need to do this in Destination's constructor:
            _flight = new EntitySet<Flight>(OnFlightAdded, OnFlightRemoved);
        }
       #endregion "Constructor" 

       #region "Map Primary Key"
        [Column(IsPrimaryKey = true,  IsDbGenerated = true )]
       public int DestID { get; set; } 
       #endregion "Map Primary Key"

       #region "Maping 1:M Flight Relationship"
       private EntitySet<Flight> _flight = new EntitySet<Flight>();

       [Association(Name = "FK_Flight_Destination", Storage = "_flight", OtherKey = "DestID", ThisKey = "DestID")]
       public ICollection<Flight> Flights
       {
           get { return _flight; }
           set { _flight.Assign(value); }
       }
       #endregion "Maping 1:M Flight Relationship"      

       #region "Columns"
       [Column] public string Airport { get; set; }
       [Column] public string Gate { get; set; }      
       [Column] public string Country { get; set; }
       [Column] public Byte[] DestImage { get; set; }
        
        #endregion "Columns"

       #region "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"
       private void OnFlightAdded(Flight addedFlight)
       {
           addedFlight.Destination = this;
       }

       private void OnFlightRemoved(Flight removedFlight)
       {
           removedFlight.Destination = null;
       }

       #endregion "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"

       #region "Update a Destination Method"
        //public void UpdateSingleDestination(string newDestination, string currentDestination)
        //{           
        //    Destination ds = ar.Destination.Single(d => d.Country == currentDestination);
        //    ds.Country = newDestination;
        //    ar.SubmitChanges();
        //}
        #endregion "Update a Destination Method"

       #region "Add new Destination Method"
        //public void AddNewDestination(string cntry, string arprt, string destType, string gte)
        //{
        //    Destination ds = new Destination { Country = cntry, Airport = arprt, DestinationType = destType, Gate = gte };          
        //    ar.Destination.InsertOnSubmit(ds);
        //    ar.SubmitChanges();
        //}
        #endregion "Add new Destination Method"

       #region "Delete a Destination Method"
        //public void DeleteDestination(string currentDest)
        //{
        //    Destination ds = ar.Destination.Single(d => d.Country == currentDest);
        //    ar.Destination.DeleteOnSubmit(ds);
        //    ar.SubmitChanges();
        //}
        #endregion "Delete a Destination Method"
    }
}
