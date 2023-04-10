using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;
using System.Configuration;
//http://www.codeproject.com/Articles/43025/A-LINQ-Tutorial-Mapping-Tables-to-Objects
namespace AirlineReservationDAL
{
    [Database] 
    public class AirlineReservation: DataContext
    {

        public AirlineReservation() : base(EncryptDecrypt.StringCipher.DecryptIT(ConfigurationManager.AppSettings["cs"].ToString())) { }       
        //base( "Data Source=.\\SQLEXPRESS;" +
        //                "AttachDbFilename=|DataDirectory|\\BookCatalog.mdf;" +
        //                "Integrated Security=True;User Instance=True" ) { }
                

        public Table<AircraftDal> Aircraft;
        public Table<ArchiveDal> Archive;
        public Table<BookingDal> Booking;
        public Table<ContactDetailsDal> ContactDetails;
        public Table<CustomerDal> Customer;
        public Table<DestinationDal> Destination;
        public Table<FlightDal> Flight;
        public Table<PaymentDal> Payment;
        public Table<SeatDal> Seat;


    }
     

   
}
