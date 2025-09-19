class Program
{
    static void Main()
    {
        var customer = new Customer(
            new Person("Agge Jacobsson", "19920309-1234"),
            1000m // Startsaldo
        );
        // Added Design
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("        _________");
        Console.WriteLine("       /        /\\");
        Console.WriteLine("      / BANK   /  \\");
        Console.WriteLine("     / NORDIC /    \\");
        Console.WriteLine("    /________/______\\");
        Console.WriteLine("    |        |      |");
        Console.WriteLine("    |        |      |");
        Console.WriteLine("    |________|______|");
       

        Console.ResetColor();
        Console.WriteLine("\nVälkommen till BANKNORDIC!");


        // Försök logga in tre gånger
        int attempts = 0;
        const int maxAttempts = 3;
        bool isLoggedIn = false;

        while (attempts < maxAttempts && !isLoggedIn)
        {
            Console.Write("Ange din PIN-kod (4 siffror): ");
            string pinInput = Console.ReadLine();

            // Validera att PIN-koden är 4 siffror
            if (pinInput.Length != 4)
            {
                Console.WriteLine("Fel: PIN-koden måste vara exakt 4 siffror!");
                attempts++;
                continue;
            }

            // Försök logga in
            if (customer.Authenticate(pinInput))
            {
                Console.WriteLine("Välkommen " + customer.Person.Name + "!");
                isLoggedIn = true;
            }
            else
            {
                attempts++;
                Console.WriteLine($"Felaktig PIN-kod! {maxAttempts - attempts} försök kvar.");
            }
        }

        // Om alla försök är slut
        if (!isLoggedIn)
        {
            Console.WriteLine("För många felaktiga försök. Bankomaten har låstats.");
            return;
        }

        // Huvudmenyn
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nVälkommen {customer.Person.Name}!");

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("┌────────────┐");
            Console.WriteLine("│  MENY     │");
            Console.WriteLine("└────────────┘");
            Console.WriteLine();  // Lagt till en blankrad

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. [+] Sätt in pengar");
            Console.WriteLine("2. [-] Ta ut pengar");
            Console.WriteLine("3. [=] Visa saldo");
            Console.WriteLine("4. [X] Logga ut");
            Console.WriteLine("5. [Q] Avsluta");

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nVälj ett alternativ (1-5): ");
            Console.ResetColor();
            int choice;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        HandleDeposit(customer.Account);
                        break;
                    case 2:
                        HandleWithdrawal(customer.Account);
                        break;
                    case 3:
                        ShowBalance(customer.Account);
                        break;
                    case 4:
                        Console.WriteLine("\nLoggar ut...");
                        running = false;
                        break;
                    case 5:
                        Console.WriteLine("\nAvslutar programmet...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Välj 1-5.");
                        PressAnyKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett nummer mellan 1-5.");
                PressAnyKey();
            }
        }

        // Visa avslutningsmeddelande
        Console.WriteLine($"\nTack för att du använder vår bankomat, {customer.Person.Name}!");
        PressAnyKey();
    }

    private static void HandleDeposit(BankAccount account)
    {
        decimal amount = GetAmount("Ange belopp att sätta in: ");
        account.Deposit(amount);
        Console.WriteLine($"Insättning genomförd. Nytt saldo: {account.Balance:C}");
        PressAnyKey();
    }

    private static void HandleWithdrawal(BankAccount account)
    {
        decimal amount = GetAmount("Ange belopp att ta ut: ");
        if (account.Withdraw(amount))
        {
            Console.WriteLine($"Uttag genomfört. Nytt saldo: {account.Balance:C}");
        }
        else
        {
            Console.WriteLine("Otillräckligt saldo eller ogiltigt belopp.");
        }
        PressAnyKey();
    }

    private static void ShowBalance(BankAccount account)
    {
        Console.WriteLine($"Saldo: {account.Balance:C}");
        PressAnyKey();
    }

    private static decimal GetAmount(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                return amount;
            }
            Console.WriteLine("Ogiltigt belopp. Försök igen.");
        }
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}