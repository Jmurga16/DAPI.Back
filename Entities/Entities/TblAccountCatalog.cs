using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblAccountCatalog
    {
        public TblAccountCatalog()
        {
            TblAccountingSeats = new HashSet<TblAccountingSeat>();
            TblReports = new HashSet<TblReport>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public bool Conversion { get; set; }

        public virtual ICollection<TblAccountingSeat> TblAccountingSeats { get; set; }
        public virtual ICollection<TblReport> TblReports { get; set; }
    }
}
