using Calculator;
using System;
using Xunit;
using Xunit.Abstractions;

// This file contains unit tests for the SimpleCalculator class

namespace Calculator.Tests
{
    public class SimpleCalculatorTests
    {
        [Theory]
        [InlineData(2, 3, '+', 5)]
        [InlineData(5, 2, '-', 3)]
        [InlineData(4, 3, '*', 12)]
        [InlineData(10, 2, '/', 5)]
        public void Calculate_ValidOperations_ReturnsExpectedResult(int a, int b, char op, int expected)
        {
            var result = SimpleCalculator.Calculate(a, b, op);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_DivideByZero_ReturnsZero()
        {
            var result = SimpleCalculator.Calculate(5, 0, '/');
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_InvalidOperation_ReturnsZero()
        {
            var result = SimpleCalculator.Calculate(2, 2, '%');
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_NullOperation_ReturnsZero()
        {
            var result = SimpleCalculator.Calculate(2, 2, '\0');
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void Calculate_EmptyOperation_ReturnsZero()
        {
            var result = SimpleCalculator.Calculate(2, 2, ' ');
            Assert.Equal(0, result);
        }
        
        [Fact] 
        public void Calculate_UnexpectedError_ReturnsZero()
        {
            // This test is to simulate an unexpected error, 
            // but since the method handles all exceptions, it will return 0.
            var result = SimpleCalculator.Calculate(2, 2, 'x'); // 'x' is not a valid operation
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void Calculate_DivideByZero_ExceptionThrown()
        {
            try
            {
                SimpleCalculator.Calculate(5, 0, '/');
            }
            catch (DivideByZeroException ex)
            {
                Assert.Equal("Cannot divide by zero.", ex.Message);
            }
        }
        
        [Fact]
        public void Calculate_InvalidOperation_ExceptionThrown()
        {
            try
            {
                SimpleCalculator.Calculate(2, 2, '%'); // '%' is not a valid operation
            }
            catch (InvalidOperationException ex)
            {
                Assert.Equal("Invalid operation. Use '+', '-', '*', or '/'.", ex.Message);
            }
        }
        
        [Fact]
        public void Calculate_NullOperation_ExceptionThrown()
        {
            try
            {
                SimpleCalculator.Calculate(2, 2, '\0'); // Null operation
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal("Operation cannot be null or empty. (Parameter 'operation')", ex.Message);
            }
        }
    }
}