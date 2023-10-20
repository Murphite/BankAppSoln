using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionTransfer : Transaction
    {
        public string RecieverId { get; set; } = "";
    }
}
