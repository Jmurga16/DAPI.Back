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
        public byte RoleId { get; set; }
        public byte DepartmentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Identification { get; set; }
        public byte Genre { get; set; }
        public string Username { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual TblDepartment Department { get; set; } = null!;
        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblAllocation> TblAllocations { get; set; }
        public virtual ICollection<TblLog> TblLogs { get; set; }
    }
}
