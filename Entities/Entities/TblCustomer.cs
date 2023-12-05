using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblAccountingSeats = new HashSet<TblAccountingSeat>();
            TblAllocations = new HashSet<TblAllocation>();
        }

        public int CustomerId { get; set; }
        public byte IdType { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool Active { get; set; }

        public virtual TblIdType IdTypeNavigation { get; set; } = null!;
        public virtual ICollection<TblAccountingSeat> TblAccountingSeats { get; set; }
        public virtual ICollection<TblAllocation> TblAllocations { get; set; }
    }
}
