namespace BankAccount;

public class Account
{
    String accountHolderName;
    decimal balance;
    private bool isOverdrawn;
    
    public Account(string accountHolderName, decimal initialBalance, bool isOverdrawn)
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
    
    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        balance += amount;
    }
    
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }
        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }   
    
    public bool IsOverdrawn()
    {
        return balance < 0;
    }
    
    public void Transfer(Account targetAccount, decimal amount)
    {
        if (targetAccount == null)
        {
            throw new ArgumentNullException(nameof(targetAccount), "Target account cannot be null.");
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