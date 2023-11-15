using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblAllocation
    {
        public int AllocationId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }

        public virtual TblCustomer Customer { get; set; } = null!;
        public virtual TblEmployee Employee { get; set; } = null!;
    }
}
