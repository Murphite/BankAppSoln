using Bank.Models;

namespace Bank.Data
{
    public static class Context
    {
        public static IList<Account> Accounts { get; set; } = new List<Account>();
        public static IList<Transaction> Transactions { get; set; } = new List<Transaction>();
        public static IList<TransactionTransfer> Transfers { get; set; } = new List<TransactionTransfer>();
    }
}