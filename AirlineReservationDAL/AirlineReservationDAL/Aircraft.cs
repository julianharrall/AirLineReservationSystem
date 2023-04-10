using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;



namespace AirlineReservationDAL
{
    [Table(Name = "Aircraft")]
    public class Aircraft
    {       
         #region "Constructor"
        public Aircraft()
         {
             _flightAcft = new EntitySet<Flight>(OnFlightAcftAdded, OnFlightAcftRemoved);
         }
        #endregion "Constructor"

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int AircraftNumber { get; set; }
        #endregion "Map Primary Key"

        #region "Maping 1:M Flight Relationship"
        private EntitySet<Flight> _flightAcft = new EntitySet<Flight>();

        [Association(Name = "FK_Flight_Aircraft", Storage = "_flightAcft", OtherKey = "AircraftNumber", ThisKey = "AircraftNumber")]
        public ICollection<Flight> _flightAcfts
        {
            get { return _flightAcft; }
            set { _flightAcft.Assign(value); }
        }

        #endregion "Maping 1:M Flight Relationship"

         

        #region "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"

        private void OnFlightAcftAdded(Flight addFlight)
        {
            addFlight.AircraftNumb = this;
        }

        private void OnFlightAcftRemoved(Flight removeFlight)
        {
            removeFlight.AircraftNumb = null;
        }

        #endregion "Delegate methods to handle synchronization with Flight table - called whenever item added/removed from its collection"
        
        #region "Columns"
        [Column] public string SeatCapacity { get; set; }
        [Column] public string AircraftType { get; set; }
        [Column] public Byte[] AImage { get; set; }
        #endregion "Columns"

    }
    
}
