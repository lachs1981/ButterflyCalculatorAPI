using ButterflyCalculatorAPI.Endpoints;

namespace ButterflyCalculatorAPI.Tests
{
    public class MultiplyTests
    {
        [Fact]
        public void Multiplication()
        {
            // Arrange
            var op1 = 2;
            var op2 = 3;
            var expected = 6;
            // Act
            var result = MultiplyEndpoint.Multiply(op1, op2);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
