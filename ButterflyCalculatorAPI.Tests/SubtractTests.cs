using ButterflyCalculatorAPI.Endpoints;

namespace ButterflyCalculatorAPI.Tests
{
    public class SubtractTests
    {
        [Fact]
        public void Subtraction()
        {
            // Arrange
            var op1 = 6;
            var op2 = 2;
            var expected = 4;
            // Act
            var result = SubtractEndpoint.Subtract(op1, op2);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
