using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblLog
    {
        public int LogId { get; set; }
        public int EmployeeId { get; set; }
        public string? LogDescription { get; set; }
        public DateTime DateTime { get; set; }

        public virtual TblEmployee Employee { get; set; } = null!;
    }
}
