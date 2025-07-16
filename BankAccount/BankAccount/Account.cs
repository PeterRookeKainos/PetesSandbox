namespace BankAccount;

public class Account
{
    String accountHolderName;
    double balance;
    private bool isOverdrawn;
    
    public Account(string accountHolderName, double initialBalance, bool isOverdrawn)
    {
        this.accountHolderName = accountHolderName;
        this.balance = initialBalance;
        this.isOverdrawn = isOverdrawn;
    }
    
    public string AccountHolderName
    {
        get { return accountHolderName; }
        set { accountHolderName = value; }
    }
    
    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }
    
    public void Deposit(double amount)
    {
        if (amount <= 0 && amount < double.MaxValue)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        if (amount > balance)
        {
            isOverdrawn = false;      
        }
        balance += amount;
    }
    
    public void Withdraw(double amount)
    {
        if (amount <= 0 && amount < double.MaxValue)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (amount > balance)
        {
            isOverdrawn = true;
        }
        balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }   
    
    public bool IsOverdrawn()
    {
        return balance < 0;
    }
    
    public void Transfer(Account targetAccount, double amount)
    {
        if (amount <= 0 && amount < double.MaxValue)
        {
            throw new ArgumentException("Transfer amount must be positive.");
        }
        if (targetAccount == null)
        {
            throw new ArgumentNullException(nameof(targetAccount), "Target account cannot be null.");
        }
        if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient funds for transfer.");
        }
        if (targetAccount.Equals(this))
        {
            throw new InvalidOperationException("Cannot transfer to your own account.");
        }
        Withdraw(amount);
        targetAccount.Deposit(amount);
    }
    
    public void Clear()
    {
        balance = 0;
    }
    
    public override string ToString()
    {
        return $"Account Holder: {accountHolderName}, Balance: {balance:C}";
    }
}