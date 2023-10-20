using Bank.Commons;
using Bank.Data;
using Bank.Models;

namespace Bank.Logic
{
    public class BankAccount
    {
        public string AddNew(string Name, decimal balance)
        {
            var newAccount = new Account
            {
                Name = Name,
                Balance = balance,
                AccountNumber = Helper.GenerateAccountNumber()
            };
            Context.Accounts.Add(newAccount);

            return newAccount.Id;
        }

        public Account GetAccount(string depositorId)
        {
            Account account = new Account();
            foreach (var item in Context.Accounts)
            {
                if (item.Id.Equals(depositorId))
                {
                    return account = item;
                }
            }

            return account;
        }

        public void Deposit(decimal amount, string depositorId, string desc)
        {
            if (amount <= 0)
                throw new Exception($"Invalid amount!");

            var account = GetAccount(depositorId);
            if(account == null)
                throw new Exception($"No match for account id {depositorId}");

            account.Balance += amount;
            Context.Transactions.Add(new Models.Transaction
            {
                Description = desc,
                TransactionAmount = amount,
                AccountId = depositorId,
                TransactionType = TransactionTypes.Deposit.ToString()
            });

        }

        public void Withdrawal(decimal amount, string withdrawerId, string desc)
        {
            if (amount <= 0)
                throw new Exception($"Invalid amount!");

            var account = GetAccount(withdrawerId);
            if (account == null)
                throw new Exception($"No match for account id {withdrawerId}");

            if(account.Balance <= amount)
                throw new Exception($"Insufficient funds!");

            account.Balance -= amount;
            Context.Transactions.Add(new Models.Transaction
            {
                Description = desc,
                TransactionAmount = amount,
                AccountId = withdrawerId,
                TransactionType = TransactionTypes.Withdrawal.ToString()
            });
        }

        public void Transfer(decimal amount, string senderId, string receiverId, string desc)
        {
            Withdrawal(amount, senderId, desc);
            Deposit(amount, receiverId, desc);

            Context.Transfers.Add(new TransactionTransfer
            {
                AccountId = senderId,
                RecieverId = receiverId,
                TransactionAmount = amount,
                Description = desc,
                TransactionType = TransactionTypes.Transfers.ToString()
            });
        }
    }
}