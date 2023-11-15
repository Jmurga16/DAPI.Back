using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblAccountingSeat
    {
        public TblAccountingSeat()
        {
            TblReports = new HashSet<TblReport>();
            TblSeatApprovals = new HashSet<TblSeatApproval>();
        }

        public int SeatId { get; set; }
        public int AccountId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Currency { get; set; } = null!;
        public decimal SeatValue { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; } = null!;

        public virtual TblAccountCatalog Account { get; set; } = null!;
        public virtual TblCustomer Customer { get; set; } = null!;
        public virtual ICollection<TblReport> TblReports { get; set; }
        public virtual ICollection<TblSeatApproval> TblSeatApprovals { get; set; }
    }
}
