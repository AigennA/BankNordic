# BankNordic
# ATM Application

An object-oriented ATM application built with C# demonstrating fundamental OOP concepts and encapsulation.

## Features

* PIN-based login with three attempts
* Deposit functionality
* Withdrawal functionality
* Balance display
* Error handling and validation
* Clear menu structure in English

## Technical Details

* Built with C# and .NET Core
* Implements object-oriented principles:
  * Encapsulation through private fields and public properties/methods
  * Composition between Customer, Person and BankAccount classes
  * Validation and error handling
  * Read-only properties for immutable data

## Installation and Running

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/atm.git
   ```
2. Navigate to the project:
   ```bash
   cd atm
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Class Structure

The application consists of three main classes:
### BankAccount
- Manages account balance
- Private `balance` field
- Public methods for deposit and withdrawal
- Read-only `Balance` property

### Person
- Stores personal information
- Read-only properties for name and social security number
- Validation of social security number format

### Customer
- Combines Person and BankAccount
- Handles PIN authentication
- Private `pinCode` field

## OOP Concepts Implemented

* **Encapsulation**: All fields are private and exposed through controlled methods and properties
* **Composition**: Customer class contains both Person and BankAccount
* **Validation**: All inputs are validated before acceptance
* **Error Handling**: Clear error messages in English
* **Read-only**: Person information and PIN code are immutable after creation

## Version History

* 1.0.0: Initial version with basic functionality
* 1.1.0: Improved error handling and PIN validation
* 1.2.0: Added read-only properties and improved code structure

## Requirements Met

* ✓ PIN-based authentication
* ✓ Menu-based interaction
* ✓ Deposit, withdrawal and balance check functions
* ✓ Validation of all transactions
* ✓ Clear separation of responsibilities between classes
* ✓ Robust error handling
* ✓ Documentation in English
