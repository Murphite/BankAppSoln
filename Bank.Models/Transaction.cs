namespace Bank.Models
{
    public class Transaction : BaseEntity
    {
        public string AccountId { get; set; } = "";
        public decimal TransactionAmount { get; set; }
        public string Description { get; set; } = "";

        public string TransactionType { get; set; } = "";

        public Account Account { get; set; }
    }
}