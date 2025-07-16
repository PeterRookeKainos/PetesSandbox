## Introduction

You are a .NET Core developer for the Cradock Marine Bank. You
will create a C# class named `Account` that represents a customer's bank account.

## The Challenge

The class `Account` represents a bank account that has a name and a balance. An `Account` object can be used as follows.

```
Account waltersAccount = new Account("Walter White", 100.00);
Account saulsAccount = new Account("Saul Goodman", 1000000.00);

Console.WriteLine("Intial state");
Console.WriteLine("Initial balance of Walter's account is " + waltersAccount.Balance); // Balance should be 100.00
Console.WriteLine("Initial balance of Saul's account is " + saulsAccount.Balance); // Balance should be 1000000.00

waltersAccount.Withdrawal(20);
Console.WriteLine(waltersAccount); // Output should be "Account {Name: "Walter White", Balance: 80.0}"
saulsAccount.Deposit(200);
Console.WriteLine(saulsAccount); // Output should be "Account {Name: "Saul Goodman", Balance: 1000200.00}"
```

The `Account` class constructor has two parameters: the account name and the initial balance. Both parameters are mandatory.
All balances, withdrawals and deposits are presumed to be all in the same currency.

You have three tasks

### 1. Show the current balance

Write a console application that:

1. Creates an account with a balance of 1000.0
2. Prints just the initial balance as 1000.00. No other account information should be printed. 

The application does not need any arguments to be passed in. You can hard-code the name and initial balance inside the program itself.

### 2. Implement withdrawals and depositions

Write a console application that:

1. Creates an account with a balance of 1000.0
2. Crreates a second account with the balance 0.0
3. Withdraw 100.0 from the first account
4. Deposits 100.0 in the second account. 
5. Print account information for both accounts using the `ToString` method as shown in the sample above.
   
The application does not need any arguments to be passed in. You can hard-code the names and initial balances inside the program itself.

### 3. Handle overdrafts

Add the new property `IsOverdrawn` to your `Account` class. This is a boolean property that is set to true if the account balance goes less than zero.

Write a console application that:

1. Creates an account with a balance of 1000.0
2. Crreates a second account with the balance 200.0
3. Withdraw 100.0 from the first account
4. Withdraw 500.0 in the second account. 
5. Print the overdraft status (True or False) of the first account. Include the account name in the print statement.
6. Print the overdraft status (True or False) of the second account. Include the account name in the print statement.
   
The application does not need any arguments to be passed in. You can hard-code the names and initial balances inside the program itself.

## Useful Links

[Introduction to classes](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)

[Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)

[Methods](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)

[Object.ToString Method](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring?view=net-8.0)