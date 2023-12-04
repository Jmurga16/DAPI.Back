using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblAllocations = new HashSet<TblAllocation>();
            TblLogs = new HashSet<TblLog>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<TblAllocation> TblAllocations { get; set; }
        public virtual ICollection<TblLog> TblLogs { get; set; }
    }
}
