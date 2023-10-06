using System;

// Клас BankAccount з подіями та методами для роботи з балансом
class BankAccount
{
    private decimal balance;

    public delegate void BalanceChangedHandler(decimal newBalance);
    public event BalanceChangedHandler BalanceChangedDeposit;
    public event BalanceChangedHandler BalanceChangedDepositWithdraw;

    public void Deposit(decimal amount)
    {
        balance += amount;
        BalanceChangedDeposit?.Invoke(balance);
    }

    public void Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            BalanceChangedDepositWithdraw?.Invoke(balance);
        }
        else
        {
            Console.WriteLine("Недостатньо коштiв на рахунку.");
        }
    }
}

// Клас AccountMonitor для виведення балансу на консоль при зміні
class AccountMonitor
{
    public void OnBalanceChanged(decimal newBalance)
    {
        Console.WriteLine($"Новий баланс: {newBalance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        AccountMonitor monitor = new AccountMonitor();

        // Підписка на події
        account.BalanceChangedDeposit += monitor.OnBalanceChanged;
        account.BalanceChangedDepositWithdraw += monitor.OnBalanceChanged;

        // Внесення коштів і зняття грошей
        account.Deposit(1000);
        account.Withdraw(500);
        account.Withdraw(600);

        Console.ReadKey();
    }
}
