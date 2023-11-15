using System;
namespace BackEnd.Models
{
	public class AccountingSeatModel
    {
        public int SeatId { get; set; }
        public int AccountId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Currency { get; set; } = null!;
        public decimal SeatValue { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; } = null!;
    }
}

