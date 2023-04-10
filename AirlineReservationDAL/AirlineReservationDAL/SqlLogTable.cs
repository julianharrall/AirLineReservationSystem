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

    [Table(Name = "SqlLogTable")]
    public class SqlLogTable
    {
        #region "Columns"
        [Column] public DateTime? LogDate { get; set; }
        [Column] public string LogText { get; set; } 
        
        #endregion "Columns"
    }
}
