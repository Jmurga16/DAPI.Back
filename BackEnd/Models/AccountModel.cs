using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class AccountModel
    { 
        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountCode { get; set; } = String.Empty;
        public string AccountType { get; set; } = null!;
        public int Conversion { get; set; }
        public bool Active { get; set; }
    }
}

