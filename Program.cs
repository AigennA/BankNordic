using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        var customer = new Customer(
            new Person("Agge Jacobsson", "19920309-1234"),
            1000m // Starting balance
        );

        // BANKNORDIC building-style design
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
        Console.WriteLine("\nWelcome to BANKNORDIC!");

        // PIN animation before login
        Console.Write("\nStarting PIN verification");
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
            Console.Write("Enter your 4-digit PIN: ");
            Console.ResetColor();

            string pinInput = Console.ReadLine();

            if (pinInput.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: PIN must be exactly 4 digits!");
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
                Console.WriteLine("\n✅ PIN accepted! Welcome " + customer.Person.Name + "!");
                Console.ResetColor();
                isLoggedIn = true;
            }
            else
            {
                attempts++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Incorrect PIN! {maxAttempts - attempts} attempts left.");
                Console.ResetColor();
            }
        }

        if (!isLoggedIn)
        {
            Console.WriteLine("Too many failed attempts. ATM is locked.");
            return;
        }

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nWelcome {customer.Person.Name}!");

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("┌────────────┐");
            Console.WriteLine("│   MENU     │");
            Console.WriteLine("└────────────┘");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. [+] Deposit");
            Console.WriteLine("2. [-] Withdraw");
            Console.WriteLine("3. [=] Show Balance");
            Console.WriteLine("4. [X] Logout");
            Console.WriteLine("5. [Q] Exit");

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nChoose an option (1-5): ");
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
                        Console.WriteLine("\nLogging out...");
                        running = false;
                        break;
                    case 5:
                        Console.WriteLine("\nExiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-5.");
                        PressAnyKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1-5.");
                PressAnyKey();
            }
        }

        Console.WriteLine($"\nThank you for using BANKNORDIC, {customer.Person.Name}!");
        PressAnyKey();
    }

    private static void HandleDeposit(BankAccount account)
    {
        decimal amount = GetAmount("Enter deposit amount: ");
        account.Deposit(amount);
        Console.WriteLine($"Deposit successful. New balance: {account.Balance:C}");
        PressAnyKey();
    }

    private static void HandleWithdrawal(BankAccount account)
    {
        decimal amount = GetAmount("Enter withdrawal amount: ");
        if (account.Withdraw(amount))
        {
            Console.WriteLine($"Withdrawal successful. New balance: {account.Balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
        }
        PressAnyKey();
    }

    private static void ShowBalance(BankAccount account)
    {
        Console.WriteLine($"Current balance: {account.Balance:C}");
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
            Console.WriteLine("Invalid amount. Try again.");
        }
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
