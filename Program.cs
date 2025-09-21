using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

class Program
{
    // Store language texts
    static Dictionary<string, string> texts;

    static void Main()
    {
        // Language selection
        Console.WriteLine("Choose language / Välj språk:");
        Console.WriteLine("1. English");
        Console.WriteLine("2. Svenska");
        Console.Write("\nSelect (1-2): ");
        string langChoice = Console.ReadLine();

        if (langChoice == "2")
        {
            texts = new Dictionary<string, string>
            {
                { "Welcome to BankNORDIC", "Välkommen till BANKNORDIC!" }, //Here spellings corrected
                { "startingPin", "Startar PIN-kontroll" },
                { "enterPin", "Ange din 4-siffriga PIN: " },
                { "pinError", "Fel: PIN måste vara exakt 4 siffror!" },
                { "pinAccepted", "PIN godkänd! Välkommen " },
                { "pinIncorrect", "Fel PIN! Försök kvar: " },
                { "tooMany", "För många felaktiga försök. Bankomaten är låst." },
                { "menuTitle", "Meny" },
                { "deposit", "1. [+] Insättning" },
                { "withdraw", "2. [-] Uttag" },
                { "balance", "3. [=] Visa saldo" },
                { "logout", "4. [X] Logga ut" },
                { "exit", "5. [Q] Avsluta" },
                { "chooseOption", "Välj ett alternativ (1-5): " },
                { "loggingOut", "Loggar ut..." },
                { "exiting", "Avslutar programmet..." },
                { "invalidChoice", "Ogiltigt val. Välj 1-5." },
                { "invalidInput", "Ogiltig inmatning. Ange ett nummer mellan 1-5." },
                { "thankYou", "Tack för att du använder BANKNORDIC, " },
                { "enterDeposit", "Ange insättningsbelopp: " },
                { "depositOk", "Insättning lyckades. Nytt saldo: " },
                { "enterWithdraw", "Ange uttagsbelopp: " },
                { "withdrawOk", "Uttag lyckades. Nytt saldo: " },
                { "withdrawFail", "Otillräckliga medel eller ogiltigt belopp." },
                { "currentBalance", "Nuvarande saldo: " },
                { "invalidAmount", "Ogiltigt belopp. Försök igen." },
                { "pressKey", "Tryck på valfri tangent för att fortsätta..." }
            };
        }
        else
        {
            texts = new Dictionary<string, string>
            {
                { "Welcome to BankNORDIC", "Welcome to BANKNORDIC!" }, //Here spellings corrected
                { "startingPin", "Starting PIN verification" },
                { "enterPin", "Enter your 4-digit PIN: " },
                { "pinError", "Error: PIN must be exactly 4 digits!" },
                { "pinAccepted", "PIN accepted! Welcome " },
                { "pinIncorrect", "Incorrect PIN! Attempts left: " },
                { "tooMany", "Too many failed attempts. ATM is locked." },
                { "menuTitle", "Menu" },
                { "deposit", "1. [+] Deposit" },
                { "withdraw", "2. [-] Withdraw" },
                { "balance", "3. [=] Show Balance" },
                { "logout", "4. [X] Logout" },
                { "exit", "5. [Q] Exit" },
                { "chooseOption", "Choose an option (1-5): " },
                { "loggingOut", "Logging out..." },
                { "exiting", "Exiting program..." },
                { "invalidChoice", "Invalid choice. Please select 1-5." },
                { "invalidInput", "Invalid input. Please enter a number between 1-5." },
                { "thankYou", "Thank you for using BANKNORDIC, " },
                { "enterDeposit", "Enter deposit amount: " },
                { "depositOk", "Deposit successful. New balance: " },
                { "enterWithdraw", "Enter withdrawal amount: " },
                { "withdrawOk", "Withdrawal successful. New balance: " },
                { "withdrawFail", "Insufficient funds or invalid amount." },
                { "currentBalance", "Current balance: " },
                { "invalidAmount", "Invalid amount. Try again." },
                { "pressKey", "Press any key to continue..." }
            };
        }

        var customer = new Customer(
            new Person("Agge Jacobsson", "19920309-1234"),
            1000m // Starting balance
        );

        // BANKNORDIC building design
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
        Console.WriteLine("\n" + texts["Welcome to BankNORDIC"]); // Corrected spelling here

        // PIN animation before login
        Console.Write("\n" + texts["startingPin"]);
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine("\n");

        int attempts = 0;
        const int maxAttempts = 3;
        bool isLoggedIn = false;

        while (attempts < maxAttempts && !isLoggedIn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(texts["enterPin"]);
            Console.ResetColor();

            string pinInput = Console.ReadLine();

            if (pinInput.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(texts["pinError"]);
                Console.ResetColor();
                attempts++;
                continue;
            }

            Console.Write("Verifying");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }

            if (customer.Authenticate(pinInput))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + texts["pinAccepted"] + customer.Person.Name + "!");
                Console.ResetColor();
                isLoggedIn = true;
            }
            else
            {
                attempts++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{texts["pinIncorrect"]}{maxAttempts - attempts}");
                Console.ResetColor();
            }
        }

        if (!isLoggedIn)
        {
            Console.WriteLine(texts["tooMany"]);
            return;
        }

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("=====================================");
            Console.WriteLine($"    Welcome {customer.Person.Name}!");
            Console.WriteLine("=====================================\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine($"║           {texts["menuTitle"],-23}║");
            Console.WriteLine("╠══════════════════════════════════╣");
            Console.WriteLine($"║  {texts["deposit"],-30}║");
            Console.WriteLine($"║  {texts["withdraw"],-30}║");
            Console.WriteLine($"║  {texts["balance"],-30}║");
            Console.WriteLine($"║  {texts["logout"],-30}║");
            Console.WriteLine($"║  {texts["exit"],-30}║");
            Console.WriteLine("╚══════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n " + texts["chooseOption"]);
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
                        Console.WriteLine("\n" + texts["loggingOut"]);
                        running = false;
                        break;
                    case 5:
                        Console.WriteLine("\n" + texts["exiting"]);
                        return;
                    default:
                        Console.WriteLine(texts["invalidChoice"]);
                        PressAnyKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine(texts["invalidInput"]);
                PressAnyKey();
            }
        }

        Console.WriteLine($"\n{texts["thankYou"]}{customer.Person.Name}!");
        PressAnyKey();
    }

    private static void HandleDeposit(BankAccount account)
    {
        decimal amount = GetAmount(texts["enterDeposit"]);
        account.Deposit(amount);
        Console.WriteLine($"{texts["depositOk"]}{account.Balance:C}");
        PressAnyKey();
    }

    private static void HandleWithdrawal(BankAccount account)
    {
        decimal amount = GetAmount(texts["enterWithdraw"]);
        if (account.Withdraw(amount))
        {
            Console.WriteLine($"{texts["withdrawOk"]}{account.Balance:C}");
        }
        else
        {
            Console.WriteLine(texts["withdrawFail"]);
        }
        PressAnyKey();
    }

    private static void ShowBalance(BankAccount account)
    {
        Console.WriteLine($"{texts["currentBalance"]}{account.Balance:C}");
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
            Console.WriteLine(texts["invalidAmount"]);
        }
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\n" + texts["pressKey"]);
        Console.ReadKey();
    }
}
