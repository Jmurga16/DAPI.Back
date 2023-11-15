using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblReport
    {
        public int ReportId { get; set; }
        public int SeatId { get; set; }
        public int AccountId { get; set; }
        public string InitialBalance { get; set; } = null!;
        public string Debts { get; set; } = null!;
        public string Credits { get; set; } = null!;
        public string FinalBalance { get; set; } = null!;

        public virtual TblAccountCatalog Account { get; set; } = null!;
        public virtual TblAccountingSeat Seat { get; set; } = null!;
    }
}
