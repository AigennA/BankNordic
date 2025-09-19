💳  -- BANKNORDIC -- ATM Console Application in C#
🧠 Purpose
This project is an exercise in object-oriented programming (OOP) with a focus on:

Classes, objects, methods, and properties in C#

Data encapsulation using private fields and public properties/methods

Console-based input/output and control structures

Version control using Git

🚀 How to Run the Program
Clone or download the project from GitHub

Open the terminal in the project directory

Run the command: dotnet run

git remote add origin https://github.com/ditt-användarnamn/banknordic.git


🏗️ Structure
The project consists of the following classes:

Person: Contains name and personal ID number (readonly)

BankAccount: Manages balance, deposits, and withdrawals with validation

Customer: Links a person to a bank account and handles PIN authentication

Program: Main logic for the ATM, including login, menu, and user flow

🔐 Encapsulation
Encapsulation is used to protect sensitive data:

balance in BankAccount is private and accessed only via the read-only Balance property

The Deposit() and Withdraw() methods validate the amount before modifying the balance

The PIN code in Customer is private and compared using the Authenticate() method

✅ Features

Login with PIN code (max 3 attempts)

Deposit and withdrawal with amount validation

Balance displayed in currency format

Color design and clear menu interface

Option to log out or exit the program

Option Language (EN /Sv)

🏁 Final Notes
This ATM project demonstrates how to build a simple yet robust application using OOP and encapsulation in C#. It’s a great example of how to structure code, handle user input, and protect internal data.
