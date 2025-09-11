using Xunit;
using GitLabGenerateTests;

namespace GitLabGenerateTests.Test
{
    public class OptionTests
    {
        // Strike price
        [Fact]
        public void StrikePrice_DefaultValue_Is100()
        {
            var option = new Option();
            Assert.Equal(100.0, option.StrikePrice);
        }

        [Fact]
        public void StrikePrice_CanBeSetToPositiveValue()
        {
            var option = new Option { StrikePrice = 150.5 };
            Assert.Equal(150.5, option.StrikePrice);
        }

        [Fact]
        public void StrikePrice_CanBeSetToZero()
        {
            var option = new Option { StrikePrice = 0.0 };
            Assert.Equal(0.0, option.StrikePrice);
        }

        [Fact]
        public void ExpirationDate_DefaultValue_IsThreeMonthsFromNow()
        {
            var now = DateTime.Now;
            var option = new Option();
            var expected = now.AddMonths(3);
            Assert.InRange(option.ExpirationDate, expected.AddSeconds(-1), expected.AddSeconds(1));
        }

        // Expiration date
        [Fact]
        public void ExpirationDate_CanBeSetToFutureDate()
        {
            var futureDate = DateTime.Now.AddYears(1);
            var option = new Option { ExpirationDate = futureDate };
            Assert.Equal(futureDate, option.ExpirationDate);
        }
        
        [Fact]
        public void ExpirationDate_CanBeSetToNow()
        {
            var now = DateTime.Now;
            var option = new Option { ExpirationDate = now };
            Assert.InRange(option.ExpirationDate, now.AddSeconds(-1), now.AddSeconds(1));
        }
        
        // Option Type
        [Fact]
        public void OptionType_DefaultValue_IsCall()
        {
            var option = new Option();
            Assert.Equal("call", option.OptionType);
        }

        [Fact]
        public void OptionType_CanBeSetToPut()
        {
            var option = new Option { OptionType = "put" };
            Assert.Equal("put", option.OptionType);
        }

        [Fact]
        public void OptionType_CanBeSetToInvalidString()
        {
            var option = new Option { OptionType = "invalid" };
            Assert.Equal("invalid", option.OptionType);
        }
        
        [Fact]
        public void OptionType_CanBeSetToEmptyString()
        {
            var option = new Option { OptionType = "" };
            Assert.Equal("", option.OptionType);
        }

        [Fact]
        public void OptionType_CanBeSetToNull()
        {
            var option = new Option { OptionType = null };
            Assert.Null(option.OptionType);
        }
        
        // Premium
        [Fact]
        public void Premium_DefaultValue_IsFive()
        {
            var option = new Option();
            Assert.Equal(5.0, option.Premium);
        }

        [Fact]
        public void Premium_CanBeSetToPositiveValue()
        {
            var option = new Option { Premium = 12.5 };
            Assert.Equal(12.5, option.Premium);
        }

        [Fact]
        public void Premium_CanBeSetToZero()
        {
            var option = new Option { Premium = 0.0 };
            Assert.Equal(0.0, option.Premium);
        }

        [Fact]
        public void Premium_CanBeSetToNegativeValue()
        {
            var option = new Option { Premium = -3.0 };
            Assert.Equal(-3.0, option.Premium);
        }
        
        // Underlying Asset
        [Fact]
        public void UnderlyingAsset_DefaultValue_IsAAPL()
        {
            var option = new Option();
            Assert.Equal("AAPL", option.UnderlyingAsset);
        }

        [Fact]
        public void UnderlyingAsset_CanBeSetToDifferentTicker()
        {
            var option = new Option { UnderlyingAsset = "GOOG" };
            Assert.Equal("GOOG", option.UnderlyingAsset);
        }

        [Fact]
        public void UnderlyingAsset_CanBeSetToEmptyString()
        {
            var option = new Option { UnderlyingAsset = "" };
            Assert.Equal("", option.UnderlyingAsset);
        }

        [Fact]
        public void UnderlyingAsset_CanBeSetToNull()
        {
            var option = new Option { UnderlyingAsset = null };
            Assert.Null(option.UnderlyingAsset);
        }
        
        // Quantity
        [Fact]
        public void Quantity_DefaultValue_IsOneHundred()
        {
            var option = new Option();
            Assert.Equal(100, option.Quantity);
        }

        [Fact]
        public void Quantity_CanBeSetToPositiveValue()
        {
            var option = new Option { Quantity = 250 };
            Assert.Equal(250, option.Quantity);
        }

        [Fact]
        public void Quantity_CanBeSetToZero()
        {
            var option = new Option { Quantity = 0 };
            Assert.Equal(0, option.Quantity);
        }

        [Fact]
        public void Quantity_CanBeSetToNegativeValue()
        {
            var option = new Option { Quantity = -50 };
            Assert.Equal(-50, option.Quantity);
        }
        
        // Currency
        [Fact]
        public void Currency_DefaultValue_IsUSD()
        {
            var option = new Option();
            Assert.Equal("USD", option.Currency);
        }

        [Fact]
        public void Currency_CanBeSetToDifferentCurrency()
        {
            var option = new Option { Currency = "EUR" };
            Assert.Equal("EUR", option.Currency);
        }

        [Fact]
        public void Currency_CanBeSetToEmptyString()
        {
            var option = new Option { Currency = "" };
            Assert.Equal("", option.Currency);
        }

        [Fact]
        public void Currency_CanBeSetToNull()
        {
            var option = new Option { Currency = null };
            Assert.Null(option.Currency);
        }
        
        // IsAmerican
        [Fact]
        public void IsAmerican_DefaultValue_IsTrue()
        {
            var option = new Option();
            Assert.True(option.IsAmerican);
        }

        [Fact]
        public void IsAmerican_CanBeSetToFalse()
        {
            var option = new Option { IsAmerican = false };
            Assert.False(option.IsAmerican);
        }

        [Fact]
        public void IsAmerican_CanBeSetBackToTrue()
        {
            var option = new Option { IsAmerican = false };
            option.IsAmerican = true;
            Assert.True(option.IsAmerican);
        }
        
        // ImpliedVolatility
        [Fact]
        public void ImpliedVolatility_DefaultValue_IsPointTwo()
        {
            var option = new Option();
            Assert.Equal(0.2, option.ImpliedVolatility);
        }

        [Fact]
        public void ImpliedVolatility_CanBeSetToPositiveValue()
        {
            var option = new Option { ImpliedVolatility = 0.35 };
            Assert.Equal(0.35, option.ImpliedVolatility);
        }

        [Fact]
        public void ImpliedVolatility_CanBeSetToZero()
        {
            var option = new Option { ImpliedVolatility = 0.0 };
            Assert.Equal(0.0, option.ImpliedVolatility);
        }

        [Fact]
        public void ImpliedVolatility_CanBeSetToNegativeValue()
        {
            var option = new Option { ImpliedVolatility = -0.1 };
            Assert.Equal(-0.1, option.ImpliedVolatility);
        }
        
        // RiskFreeRate
        [Fact]
        public void RiskFreeRate_DefaultValue_IsPointZeroOne()
        {
            var option = new Option();
            Assert.Equal(0.01, option.RiskFreeRate);
        }

        [Fact]
        public void RiskFreeRate_CanBeSetToPositiveValue()
        {
            var option = new Option { RiskFreeRate = 0.05 };
            Assert.Equal(0.05, option.RiskFreeRate);
        }

        [Fact]
        public void RiskFreeRate_CanBeSetToZero()
        {
            var option = new Option { RiskFreeRate = 0.0 };
            Assert.Equal(0.0, option.RiskFreeRate);
        }

        [Fact]
        public void RiskFreeRate_CanBeSetToNegativeValue()
        {
            var option = new Option { RiskFreeRate = -0.02 };
            Assert.Equal(-0.02, option.RiskFreeRate);
        }
        
        // TradeDate
        [Fact]
        public void TradeDate_DefaultValue_IsCloseToNow()
        {
            var option = new Option();
            Assert.True((DateTime.Now - option.TradeDate).TotalSeconds < 1);
        }

        [Fact]
        public void TradeDate_CanBeSetToSpecificDate()
        {
            var specificDate = new DateTime(2022, 1, 1);
            var option = new Option { TradeDate = specificDate };
            Assert.Equal(specificDate, option.TradeDate);
        }

        [Fact]
        public void TradeDate_CanBeSetToFutureDate()
        {
            var futureDate = DateTime.Now.AddYears(1);
            var option = new Option { TradeDate = futureDate };
            Assert.Equal(futureDate, option.TradeDate);
        }

        [Fact]
        public void TradeDate_CanBeSetToPastDate()
        {
            var pastDate = DateTime.Now.AddYears(-1);
            var option = new Option { TradeDate = pastDate };
            Assert.Equal(pastDate, option.TradeDate);
        }
        
        // Exchange
        [Fact]
        public void Exchange_DefaultValue_IsNYSE()
        {
            var option = new Option();
            Assert.Equal("NYSE", option.Exchange);
        }

        [Fact]
        public void Exchange_CanBeSetToDifferentExchange()
        {
            var option = new Option { Exchange = "NASDAQ" };
            Assert.Equal("NASDAQ", option.Exchange);
        }

        [Fact]
        public void Exchange_CanBeSetToEmptyString()
        {
            var option = new Option { Exchange = "" };
            Assert.Equal("", option.Exchange);
        }

        [Fact]
        public void Exchange_CanBeSetToNull()
        {
            var option = new Option { Exchange = null };
            Assert.Null(option.Exchange);
        }
        
        // Status
        [Fact]
        public void Status_DefaultValue_IsOpen()
        {
            var option = new Option();
            Assert.Equal("open", option.Status);
        }

        [Fact]
        public void Status_CanBeSetToClosed()
        {
            var option = new Option { Status = "closed" };
            Assert.Equal("closed", option.Status);
        }

        [Fact]
        public void Status_CanBeSetToEmptyString()
        {
            var option = new Option { Status = "" };
            Assert.Equal("", option.Status);
        }

        [Fact]
        public void Status_CanBeSetToNull()
        {
            var option = new Option { Status = null };
            Assert.Null(option.Status);
        }
        
        // Owner
        [Fact]
        public void Owner_DefaultValue_IsTraderJoe()
        {
            var option = new Option();
            Assert.Equal("TraderJoe", option.Owner);
        }

        [Fact]
        public void Owner_CanBeSetToDifferentName()
        {
            var option = new Option { Owner = "Alice" };
            Assert.Equal("Alice", option.Owner);
        }

        [Fact]
        public void Owner_CanBeSetToEmptyString()
        {
            var option = new Option { Owner = "" };
            Assert.Equal("", option.Owner);
        }

        [Fact]
        public void Owner_CanBeSetToNull()
        {
            var option = new Option { Owner = null };
            Assert.Null(option.Owner);
        }
         
        // Comments
        [Fact]
        public void Comments_DefaultValue_IsNoComments()
        {
            var option = new Option();
            Assert.Equal("No comments", option.Comments);
        }

        [Fact]
        public void Comments_CanBeSetToCustomString()
        {
            var option = new Option { Comments = "Urgent trade" };
            Assert.Equal("Urgent trade", option.Comments);
        }

        [Fact]
        public void Comments_CanBeSetToEmptyString()
        {
            var option = new Option { Comments = "" };
            Assert.Equal("", option.Comments);
        }

        [Fact]
        public void Comments_CanBeSetToNull()
        {
            var option = new Option { Comments = null };
            Assert.Null(option.Comments);
        }
         
        // Identifier
        [Fact]
        public void Identifier_DefaultValue_IsNotNullOrEmpty()
        {
            var option = new Option();
            Assert.False(string.IsNullOrEmpty(option.Identifier));
        }

        [Fact]
        public void Identifier_DefaultValue_IsValidGuid()
        {
            var option = new Option();
            Assert.True(Guid.TryParse(option.Identifier, out _));
        }

        [Fact]
        public void Identifier_CanBeSetToSpecificValue()
        {
            var customId = Guid.NewGuid().ToString();
            var option = new Option { Identifier = customId };
            Assert.Equal(customId, option.Identifier);
        }

        [Fact]
        public void Identifier_CanBeSetToNull()
        {
            var option = new Option { Identifier = null };
            Assert.Null(option.Identifier);
        }

        [Fact]
        public void Identifier_CanBeSetToEmptyString()
        {
            var option = new Option { Identifier = "" };
            Assert.Equal("", option.Identifier);
         
        }

         
        [Fact]
        public void BreakEvenPrice_ReturnsCorrectValue_ForCallOption()
        {
            var option = new Option { OptionType = "call", StrikePrice = 50, Premium = 2 };
            Assert.Equal(52, option.BreakEvenPrice);
        }

        [Fact]
        public void BreakEvenPrice_ReturnsCorrectValue_ForPutOption()
        {
            var option = new Option { OptionType = "put", StrikePrice = 50, Premium = 2 };
            Assert.Equal(48, option.BreakEvenPrice);
        }

        [Fact]
        public void IsExpired_ReturnsTrue_WhenExpirationDateInPast()
        {
            var option = new Option { ExpirationDate = DateTime.Now.AddDays(-1) };
            Assert.True(option.IsExpired);
        }

        [Fact]
        public void IsExpired_ReturnsFalse_WhenExpirationDateInFuture()
        {
            var option = new Option { ExpirationDate = DateTime.Now.AddDays(10) };
            Assert.False(option.IsExpired);
        }

        [Fact]
        public void TimeToExpiration_ReturnsZero_WhenExpirationDateIsNow()
        {
            var now = DateTime.Now;
            var option = new Option { ExpirationDate = now };
            Assert.InRange(option.TimeToExpiration, -0.001, 0.001);
        }

        [Fact]
        public void TimeToExpiration_ReturnsPositiveValue_WhenExpirationDateInFuture()
        {
            var option = new Option { ExpirationDate = DateTime.Now.AddDays(365) };
            Assert.InRange(option.TimeToExpiration, 0.99, 1.01);
        }

        [Fact]
        public void IntrinsicValue_ReturnsZero_WhenCallOptionOutOfTheMoney()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100 };
            Assert.Equal(0, option.IntrinsicValue(90));
        }

        [Fact]
        public void IntrinsicValue_ReturnsCorrectValue_WhenCallOptionInTheMoney()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100 };
            Assert.Equal(20, option.IntrinsicValue(120));
        }

        [Fact]
        public void IntrinsicValue_ReturnsZero_WhenPutOptionOutOfTheMoney()
        {
            var option = new Option { OptionType = "put", StrikePrice = 100 };
            Assert.Equal(0, option.IntrinsicValue(110));
        }

        [Fact]
        public void IntrinsicValue_ReturnsCorrectValue_WhenPutOptionInTheMoney()
        {
            var option = new Option { OptionType = "put", StrikePrice = 100 };
            Assert.Equal(15, option.IntrinsicValue(85));
        }

        [Fact]
        public void ExtrinsicValue_ReturnsCorrectValue_WhenIntrinsicValueIsZero()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100, Premium = 5 };
            Assert.Equal(5, option.ExtrinsicValue(90));
        }

        [Fact]
        public void ExtrinsicValue_ReturnsCorrectValue_WhenIntrinsicValueIsPositive()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100, Premium = 5 };
            Assert.Equal(-5, option.ExtrinsicValue(110));
        }

        [Fact]
        public void TotalValue_ReturnsSumOfIntrinsicAndExtrinsicValue()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100, Premium = 5 };
            var currentPrice = 110;
            var expected = option.IntrinsicValue(currentPrice) + option.ExtrinsicValue(currentPrice);
            Assert.Equal(expected, option.TotalValue(currentPrice));
        }
         
         
         
        
        [Fact]
        public void IntrinsicValue_CallOption_InTheMoney_ReturnsCorrectValue()
        {
            var option = new Option { OptionType = "call", StrikePrice = 100 };
            double currentPrice = 120;
            Assert.Equal(20, option.IntrinsicValue(currentPrice));
        }

        [Fact]
        public void IntrinsicValue_PutOption_InTheMoney_ReturnsCorrectValue()
        {
            var option = new Option { OptionType = "put", StrikePrice = 100 };
            double currentPrice = 80;
            Assert.Equal(20, option.IntrinsicValue(currentPrice));
        }
        
        [Fact]
        public void ToString_ReturnsExpectedFormat_ForCallOption()
        {
            var option = new Option
            {
                OptionType = "call",
                UnderlyingAsset = "AAPL",
                StrikePrice = 150,
                ExpirationDate = new DateTime(2025, 12, 31),
                Premium = 10,
                Quantity = 50,
                Status = "open"
            };
            var expected = "CALL Option on AAPL | Strike: 150 | Exp: 31/12/2025 | Premium: 10 | Qty: 50 | Status: open";
            Assert.Equal(expected, option.ToString());
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat_ForPutOption()
        {
            var option = new Option
            {
                OptionType = "put",
                UnderlyingAsset = "MSFT",
                StrikePrice = 200,
                ExpirationDate = new DateTime(2026, 1, 15),
                Premium = 7.5,
                Quantity = 10,
                Status = "closed"
            };
            var expected = "PUT Option on MSFT | Strike: 200 | Exp: 15/01/2026 | Premium: 7.5 | Qty: 10 | Status: closed";
            Assert.Equal(expected, option.ToString());
        }

        [Fact]
        public void GetOptionDetails_IncludesAllRelevantFields()
        {
            var option = new Option
            {
                OptionType = "call",
                UnderlyingAsset = "TSLA",
                StrikePrice = 300,
                ExpirationDate = new DateTime(2025, 6, 30),
                Premium = 12,
                Quantity = 5,
                Currency = "EUR",
                IsAmerican = false,
                ImpliedVolatility = 0.35,
                RiskFreeRate = 0.03,
                TradeDate = new DateTime(2025, 1, 1),
                Exchange = "NASDAQ",
                Status = "open",
                Owner = "Alice",
                Comments = "Speculative",
                Identifier = "custom-id-123"
            };
            var details = option.GetOptionDetails();
            Assert.Contains("Type: call", details);
            Assert.Contains("Underlying Asset: TSLA", details);
            Assert.Contains("Strike Price: 300", details);
            Assert.Contains("Expiration Date: 6/30/2025", details);
            Assert.Contains("Premium: 12", details);
            Assert.Contains("Quantity: 5", details);
            Assert.Contains("Currency: EUR", details);
            Assert.Contains("Style: European", details);
            Assert.Contains("Implied Volatility: 35%", details);
            Assert.Contains("Risk-Free Rate: 3%", details);
            Assert.Contains("Trade Date: 1/1/2025", details);
            Assert.Contains("Exchange: NASDAQ", details);
            Assert.Contains("Status: open", details);
            Assert.Contains("Owner: Alice", details);
            Assert.Contains("Comments: Speculative", details);
            Assert.Contains("Identifier: custom-id-123", details);
            Assert.Contains("Break-Even Price:", details);
            Assert.Contains("Is Expired:", details);
            Assert.Contains("Time to Expiration (years):", details);
        }

        [Fact]
        public void ToString_HandlesEmptyOrNullFields()
        {
            var option = new Option
            {
                OptionType = "",
                UnderlyingAsset = null,
                Status = null
            };
            var result = option.ToString();
            Assert.Contains(" Option on ", result);
            Assert.Contains("Status: ", result);
        }

        [Fact]
        public void GetOptionDetails_HandlesEmptyOrNullFields()
        {
            var option = new Option
            {
                OptionType = null,
                UnderlyingAsset = "",
                Comments = null
            };
            var details = option.GetOptionDetails();
            Assert.Contains("Type: ", details);
            Assert.Contains("Underlying Asset: ", details);
            Assert.Contains("Comments: ", details);
        }
    }
}