public class Customer
{
    private readonly string pinCode = "1234"; // Readonly field for PIN code
    public Person Person { get; }
    public BankAccount Account { get; }

    public Customer(Person person, decimal initialBalance)
    {
        Person = person;
        Account = new BankAccount();
        Account.Deposit(initialBalance);
    }

    public bool Authenticate(string pin)
    {
        return pin == pinCode;
    }
}