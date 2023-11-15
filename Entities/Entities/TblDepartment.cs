using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public byte DepartmentId { get; set; }
        public string DepartmentDescription { get; set; } = null!;

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
