using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public byte RoleId { get; set; }
        public string RoleDescription { get; set; } = null!;

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
