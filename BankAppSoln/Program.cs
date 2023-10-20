using Bank.Logic;

// See https://aka.ms/new-console-template for more information


string loggedInUserId = string.Empty;
bool continueOperation = true;
while (continueOperation)
{
    Console.Clear();
    Console.WriteLine("Welcome to our Countries Bank");
    Console.WriteLine("-----------------------------");
    Console.WriteLine();

    Console.WriteLine("Bank operations");
    Console.WriteLine(@"
1. Create Account
2. Make Deposit
3. Make Withdrawal
4. Make Transfer
5. Get Transaction History
6. Get Registered Accounts
7. Exit
");

    Console.WriteLine("Enter an operation number");
    int choice = Convert.ToInt32(Console.ReadLine());
    BankAccount bankAccountLogic = new BankAccount();

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter an account name");
            var name = Console.ReadLine();
            Console.WriteLine("Make an initial deposit (Optional)?");
            var balance = decimal.Parse(Console.ReadLine());
            loggedInUserId = bankAccountLogic.AddNew(name, balance);
            break;

        case 2:
            Console.WriteLine("Enter an amount to deposit");
            var amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter a note");
            var note = Console.ReadLine();
            bankAccountLogic.Deposit(amount, loggedInUserId, note);
            break;

        case 7:
            Environment.Exit(0);
        break;
    }
}



