using BankAccount;

namespace bankAccount;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Account aliceAccount = new Account("Alice", 1000, false);
            Account bobAccount = new Account("Bob", 500, false);
            Account oscarAccount = new Account("Oscar", 500, false);

            Console.WriteLine($"{aliceAccount.AccountHolderName} has a balance of {aliceAccount.GetBalance()}");
            Console.WriteLine($"{bobAccount.AccountHolderName} has a balance of {bobAccount.GetBalance()}");

            aliceAccount.Deposit(200);
            Console.WriteLine($"{aliceAccount.AccountHolderName} deposited 200. New balance: {aliceAccount.GetBalance()}");

            bobAccount.Withdraw(300);
            Console.WriteLine($"{bobAccount.AccountHolderName} withdrew 300. New balance: {bobAccount.GetBalance()}");
            
            // extra operations to transfer (not in the specification)
            aliceAccount.Transfer(bobAccount, 400);
            Console.WriteLine($"{aliceAccount.AccountHolderName} transferred 400 to {bobAccount.AccountHolderName}. New balance: {aliceAccount.GetBalance()}");
            Console.WriteLine($"{bobAccount.AccountHolderName} received the transfer. New balance: {bobAccount.GetBalance()}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}