namespace Entities.Entities
{
    public partial class TblAccountCatalog
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountCode { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public int Conversion { get; set; }
        public bool Active { get; set; }
    }
}
