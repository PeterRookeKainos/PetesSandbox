namespace GitLabGenerateTests;

// Class to model derivative options contracts both call and put options
// with properties for strike price, expiration date, and option type (call or put)
// and methods to calculate intrinsic value, extrinsic value, and total value
// and override the ToString() method for easy display of option details

// used as a basis for creating unit tests in GitLab CoPilot for C#
// See https://learn.microsoft.com/en-us/training/modules/develop-unit-tests-using-github-copilot-tools/3-create-unit-tests-generate-tests-smart-action

public class Option
{
    //create instance variables for the derivative options with default values
    public double StrikePrice { get; set; } = 100.0;
    public DateTime ExpirationDate { get; set; } = DateTime.Now.AddMonths(3);
    public string OptionType { get; set; } = "call"; // can be "call" or "put"
    public double Premium { get; set; } = 5.0;
    public string UnderlyingAsset { get; set; } = "AAPL";
    public int Quantity { get; set; } = 100;
    public string Currency { get; set; } = "USD";
    public bool IsAmerican { get; set; } = true; // true for American options, false for European options
    public double ImpliedVolatility { get; set; } = 0.2; // default 20% implied volatility
    public double RiskFreeRate { get; set; } = 0.01; // default 1% risk-free interest rate
    public DateTime TradeDate { get; set; } = DateTime.Now;
    public string Exchange { get; set; } = "NYSE";
    public string Status { get; set; } = "open"; // can be "open" or "closed"
    public string Owner { get; set; } = "TraderJoe";
    public string Comments { get; set; } = "No comments";
    public string Identifier { get; set; } = Guid.NewGuid().ToString(); // unique identifier for the option contract
   
    public double BreakEvenPrice => OptionType == "call" ? StrikePrice + Premium : StrikePrice - Premium; // calculated property for break-even price
    
    public bool IsExpired => DateTime.Now > ExpirationDate; // calculated property to check if the option is expired
    
    public double TimeToExpiration => (ExpirationDate - DateTime.Now).TotalDays / 365.0; // calculated property for time to expiration in years
    
    public double IntrinsicValue(double currentPrice)
    {
        if (OptionType == "call")
        {
            return Math.Max(0, currentPrice - StrikePrice);
        }
        else // put option
        {
            return Math.Max(0, StrikePrice - currentPrice);
        }
    }
    
    public double ExtrinsicValue(double currentPrice) => Premium - IntrinsicValue(currentPrice); // calculated property for extrinsic value
    
    public double TotalValue(double currentPrice) => IntrinsicValue(currentPrice) + ExtrinsicValue(currentPrice); // total value of the option
    
    public override string ToString()
    {
        return $"{OptionType.ToUpper()} Option on {UnderlyingAsset} | Strike: {StrikePrice} | Exp: {ExpirationDate.ToShortDateString()} | Premium: {Premium} | Qty: {Quantity} | Status: {Status}";
    }

    public string GetOptionDetails()
    {
        return $"Option Details:\n" +
               $"- Type: {OptionType}\n" +
               $"- Underlying Asset: {UnderlyingAsset}\n" +
               $"- Strike Price: {StrikePrice}\n" +
               $"- Expiration Date: {ExpirationDate.ToShortDateString()}\n" +
               $"- Premium: {Premium}\n" +
               $"- Quantity: {Quantity}\n" +
               $"- Currency: {Currency}\n" +
               $"- Style: {(IsAmerican ? "American" : "European")}\n" +
               $"- Implied Volatility: {ImpliedVolatility * 100}%\n" +
               $"- Risk-Free Rate: {RiskFreeRate * 100}%\n" +
               $"- Trade Date: {TradeDate.ToShortDateString()}\n" +
               $"- Exchange: {Exchange}\n" +
               $"- Status: {Status}\n" +
               $"- Owner: {Owner}\n" +
               $"- Comments: {Comments}\n" +
               $"- Identifier: {Identifier}\n" +
               $"- Break-Even Price: {BreakEvenPrice}\n" +
               $"- Is Expired: {IsExpired}\n" +
               $"- Time to Expiration (years): {TimeToExpiration: F2}";
    }
}