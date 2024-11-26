using ButterflyCalculatorAPI.Endpoints;

namespace ButterflyCalculatorAPI.Tests
{
    public class AddTests
    {
        [Fact]
        public void Addition()
        {
            // Arrange
            var op1 = 2;
            var op2 = 3;
            var expected = 5;

            // Act
            var result = AddEndpoint.Add(op1, op2);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
