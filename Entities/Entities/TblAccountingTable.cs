using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TblAccountingTable
    {
        public TblAccountingTable()
        {
            TblAccountCatalogs = new HashSet<TblAccountingTable>();

            TblAccountingSeats = new HashSet<TblAccountingSeat>();
        }

        public int ID { get; set; }
        public decimal MONTO { get; set; }
        public string Currency { get; set; } = null!;
        public int ID_CUENTA { get; set; }
        public string DESCRIPCION { get; set; } = null!;
        public int ID_ASIENTO { get; set; }

        public virtual ICollection<TblAccountingTable> TblAccountCatalogs { get; set; }

        public virtual ICollection<TblAccountingSeat> TblAccountingSeats { get; set; }
    }
}
