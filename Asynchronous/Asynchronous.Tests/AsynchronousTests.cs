using System.Threading.Tasks;
using AsyncBreakfast;
using Xunit;

namespace Asynchronous.Tests
{
    public class BreakfastAsyncTests
    {
        [Fact]
        public async Task MakeBreakfastAsync_ShouldReturnFinalMessage()
        {
            // Arrange
            var breakfastAsync = new BreakfastAsync();

            // Act
            // Using the async method to make breakfast but awaiting the result
            // This will ensure that the asynchronous operations complete before we check the result
            // Note: The method MakeBreakfastAsync is assumed to be an async method that returns a string
            var result = await breakfastAsync.MakeBreakfast();

            // Assert
            Assert.EndsWith("Breakfast is ready!", result);
        }
    }
}