public class BankAccount
{
    private decimal balance;
    public decimal Balance => balance;

    public void Deposit(decimal amount) // Method to deposit money
    {
        if (amount > 0)
            balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }
}