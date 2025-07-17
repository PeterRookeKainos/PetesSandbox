using Xunit;

namespace Asynchronous.Tests
{
    public class BreakfastTests
    {
        [Fact]
        public void MakeBreakfast_ShouldReturnFinalMessage()
        {
            // Arrange
            var breakfast = new Breakfast();

            // Act
            var result = breakfast.MakeBreakfast();

            // Assert
            Assert.EndsWith("Breakfast is ready!", result);
        }
    }
}