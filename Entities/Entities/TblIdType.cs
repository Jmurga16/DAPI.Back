using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblIdType
    {
        public TblIdType()
        {
            TblCustomers = new HashSet<TblCustomer>();
        }

        public byte IdType { get; set; }
        public string TypeDescription { get; set; } = null!;

        public virtual ICollection<TblCustomer> TblCustomers { get; set; }
    }
}
