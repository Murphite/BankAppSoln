using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Account : BaseEntity
    {
        public decimal Balance { get; set; }
        public string Name { get; set; } = "";
        public string AccountNumber { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
    }
}
