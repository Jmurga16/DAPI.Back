using System;
namespace BackEnd.Models
{
	public class AccountModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public bool Conversion { get; set; }
    }
}

