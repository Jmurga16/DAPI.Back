using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblSeatApproval
    {
        public int ApprovalId { get; set; }
        public int SeatId { get; set; }
        public byte ApprovalStatus { get; set; }

        public virtual TblAccountingSeat Seat { get; set; } = null!;
    }
}
