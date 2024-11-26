using ButterflyCalculatorAPI.Endpoints;

namespace ButterflyCalculatorAPI.Tests
{
    public class DivideTests
    {
        [Fact]
        public void Division()
        {
            // Arrange
            var op1 = 6;
            var op2 = 2;
            var expected = 3;

            // Act
            var result = DivideEndpoint.Divide(op1, op2);

            // Assert

            Assert.Equal(expected, result);
        }
        [Fact]
        public void DivisionByZero()
        {
            // Arrange
            var op1 = 6;
            var op2 = 0;
            // Act
            var result = DivideEndpoint.Divide(op1, op2);
            // Assert
            Assert.Equal(double.PositiveInfinity, result);
        }
    }
}