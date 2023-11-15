using System;
namespace BackEnd.Models
{
	public class AccountingTableModel
    {
        public int ID { get; set; }
        public decimal MONTO { get; set; }
        public string Currency { get; set; } = null!;
        public int ID_CUENTA { get; set; }
        public string DESCRIPCION { get; set; } = null!;
        public int ID_ASIENTO { get; set; }
    }
}

