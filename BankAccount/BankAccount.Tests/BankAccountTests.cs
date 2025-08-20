namespace BankAccount.Tests;

using System;
using Xunit;


public class AccountTests
{
    [Fact]
    public void Constructor_InitializesProperties()
    {
        var account = new Account("John Doe", 100.00, false);
        Assert.Equal("John Doe", account.AccountHolderName);
        Assert.Equal(100.00, account.Balance);
    }

    [Fact]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        var account = new Account("Jane", 50.00, false);
        account.Deposit(25.00);
        Assert.Equal(75.00, account.Balance);
    }

    [Theory]
    [InlineData(0.00)]
    [InlineData(-10.00)]
    public void Deposit_NonPositiveAmount_Throws(double amount)
    {
        var account = new Account("Jane", 50.00, false);
        Assert.Throws<ArgumentException>(() => account.Deposit(amount));
    }

    [Fact]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var account = new Account("Jane", 100.00, false);
        account.Withdraw(40.00);
        Assert.Equal(60.00, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Withdraw_NonPositiveAmount_Throws(double amount)
    {
        var account = new Account("Jane", 100.00, false);
        Assert.Throws<ArgumentException>(() => account.Withdraw(amount));
    }

    [Fact]
    public void Withdraw_InsufficientFunds_Throws()
    {
        var accountJane = new Account("Jane", 10.00, false);
        var accountBob = new Account("Bob", 0.00, false);
        Assert.Throws<InvalidOperationException>(() => accountJane.Transfer(accountBob, 100.00));
    }

    [Fact]
    public void GetBalance_ReturnsCurrentBalance()
    {
        var account = new Account("Jane", 80.00, false);
        Assert.Equal(80.00, account.GetBalance());
    }

    [Fact]
    public void IsOverdrawn_ReturnsTrueIfNegativeBalance()
    {
        var account = new Account("Jane", -10.00, true);
        Assert.True(account.IsOverdrawn());
    }

    [Fact]
    public void IsOverdrawn_ReturnsFalseIfNonNegativeBalance()
    {
        var account = new Account("Jane", 0.0, false);
        Assert.False(account.IsOverdrawn());
    }

    [Fact]
    public void Transfer_ValidAmount_TransfersFunds()
    {
        var source = new Account("A", 100.00, false);
        var target = new Account("B", 50.00, false);
        source.Transfer(target, 30.00);
        Assert.Equal(70.00, source.Balance);
        Assert.Equal(80.00, target.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Transfer_NonPositiveAmount_Throws(double amount)
    {
        var source = new Account("A", 100.00, false);
        var target = new Account("B", 50.00, false);
        Assert.Throws<ArgumentException>(() => source.Transfer(target, amount));
    }

    [Fact]
    public void Transfer_NullTarget_Throws()
    {
        var source = new Account("A", 100.00, false);
        Assert.Throws<ArgumentNullException>(() => source.Transfer(null, 10.00));
    }

    [Fact]
    public void Transfer_InsufficientFunds_Throws()
    {
        var source = new Account("A", 10.00, false);
        var target = new Account("B", 50.00, false);
        Assert.Throws<InvalidOperationException>(() => source.Transfer(target, 20.00));
    }

    [Fact]
    public void Transfer_ToSelf_Throws()
    {
        var account = new Account("A", 100.00, false);
        Assert.Throws<InvalidOperationException>(() => account.Transfer(account, 10.00));
    }

    [Fact]
    public void Clear_SetsBalanceToZero()
    {
        var account = new Account("Jane", 100.00, false);
        account.Clear();
        Assert.Equal(0.0, account.Balance);
    }

    [Fact]
    public void ToString_ReturnsExpectedFormat()
    {
        var account = new Account("Jane", 123.45, false);
        var result = account.ToString();
        Assert.Contains("Jane", result);
        Assert.Contains("123.45", result);
    }
}