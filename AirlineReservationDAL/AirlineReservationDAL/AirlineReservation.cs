using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.Data.Linq;
using System.Configuration;
//http://www.codeproject.com/Articles/43025/A-LINQ-Tutorial-Mapping-Tables-to-Objects
//http://www.codeproject.com/Articles/46422/A-LINQ-Tutorial-Adding-Updating-Deleting-Data
//http://msdn.microsoft.com/en-us/library/bb425822.aspx
namespace AirlineReservationDAL
{

//  NOTES:
//  If you create a strongly typed DataContext to your database, it gives you a single point of entry that makes it easy to access your data. 
//  This class will handle connecting to the database and declaring each of the tables you'll be connecting to.
//  Note: You can omit the M:M join tables (e.g., BookAuthor) from your DataContext as they're only used behind the scenes to hook up M:M relationships
//  Create a class for your database that extends DataContext, and give it the [Database] attribute to denote that this class maps to a database.
//  If you use class name different than your database name, specify database's name using attribute's Name parameter ([Database (Name="BookCatalog")]). 
//  If the names are the same, as they are here, you can omit the Name parameter:
             
    [Database] 
    public class AirlineReservation: DataContext
    {
        #region "Constructor calls base() with encrypted connection string"
        //public AirlineReservation() : base(EncryptDecrypt.StringCipher.DecryptIT(ConfigurationManager.AppSettings["cs"].ToString())) { }
        public AirlineReservation() : base(ConfigurationManager.AppSettings["cs"].ToString()) { }
        #endregion "Constructor calls base() with connection string"

        // Represent each table you want to connect to as a Table<T> collection of the class type that you are about to create for it.         
        #region "Map/Declare  Tables"        
        public Table<Aircraft> Aircraft;
        public Table<Airport> Airport;  
        public Table<Booking> Booking;
        //public Table<CustomerBooking> CustomerBooking;  
        //public Table<ContactDetails> ContactDetails;  
        public Table<Customer> Customer;  
        public Table<Destination> Destination;
        public Table<Flight> Flight;
        public Table<Payment> Payment;
       
        //public Table<FlightPriceDetails> FlightPriceDetails;
        public Table<SqlLogTable> SqlLogTable;
        #endregion "Map/Declare  Tables"

        // Create static DataContext for removing M:M Join records 
        private static DataContext contextForRemovedRecords = null;

        // Deleting a record always requires direct access to a DataContext. 
        // Can handle this with a static method on the DataContext that: 
        // Retrieves the DataContext instance to use and Deletes the record from that DataContext instance.
        // The method uses Generics so that it can take any record. 
        // Creates a static DataContext instance (contextForRemovedRecords) and uses it in RemoveRecord().
        // Defers submitting the changes for contextForRemovedRecords until the next time SubmitChanges() is called on a AirlineReservation instance
        // Adds a new method CancelChanges() (not part of standard LINQ to SQL) to allow users to cancel the changes.
        public static void RemoveRecord<T>(T recordToRemove) where T : class
        {
            // Use the static contextForRemovedRecords
            if (contextForRemovedRecords == null)
                contextForRemovedRecords = new AirlineReservation();

            Table<T> tableData = contextForRemovedRecords.GetTable<T>();
            var deleteRecord = tableData.SingleOrDefault(record => record == recordToRemove);
            if (deleteRecord != null)
            {
                tableData.DeleteOnSubmit(deleteRecord);
            }
        }

        // NEW method (not part of LINQ to SQL) to cancel changes
        public void CancelChanges()
        {
            contextForRemovedRecords = null;
        }

        // Override DataContext's SubmitChanges() to handle any removed records
        public new void SubmitChanges()
        {
            if (contextForRemovedRecords != null)
            {
                contextForRemovedRecords.SubmitChanges();
            }
            base.SubmitChanges();
        }

        public void setDBtoSingleUser()
        {
            this.ExecuteCommand("Use Master ALTER DATABASE[AirlineReservation] SET Single_User WITH Rollback Immediate" +
                 " ALTER DATABASE[AirlineReservation] SET Multi_User");
        }

       


    }
   
}
