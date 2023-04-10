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

    [Table(Name = "FlightPriceDetails")]
  public  class FlightPriceDetails
    {

        #region "Map Primary Key"
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int FlightPriceDetailsID { get; set; }
        #endregion "Map Primary Key"

        //ALTER TABLE FlightPriceDetails ADD CONSTRAINT uc_FlightPriceDetailsFK UNIQUE(FlightNumberFK);
        #region "Maping 1:1 (M:1) Flight Relationship"
        [Column]
        private string FlightNumberFK;
        private EntityRef<Flight> _FlightNumberFK = new EntityRef<Flight>();

        [Association(Name = "FK_FlightPriceDetails_Flight", IsForeignKey = true, Storage = "_FlightNumberFK", ThisKey = "FlightNumberFK")]
        public Flight FlightPDFK 
        {
            get { return _FlightNumberFK.Entity; }
            set { _FlightNumberFK.Entity = value; }
        }
        #endregion "Maping 1:1 (M:1) Flight Relationship"

       

     
        #region "Columns"
        [Column]
        public decimal Business { get; set; }
        [Column]
        public decimal First { get; set; }
        [Column] public Decimal Economy { get; set; }  
        #endregion "Columns"
    }
}
