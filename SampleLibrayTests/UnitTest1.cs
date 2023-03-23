using Sample.Library;
using System.Diagnostics.CodeAnalysis;

namespace SampleLibrayTests
{
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        [Fact]
        public void CalculatorSumTest()
        {
            using (ICalculator calculator = new Calculator())
            {
                var expected = 3;
                var value = calculator.sum(1, 2);
                Assert.Equal(expected, value);
                Assert.True(expected == value);
            }
        }

        [Fact]
        public void NullCalculatorSumTest()
        {
            ICalculator calculator = null;
            var expected = 3;
            var value = calculator?.sum(1, 2);
            Assert.NotEqual(expected, value);
            Assert.False(expected == value);
            int? integer = 1;
            if (integer.HasValue)
            {
                var integer2 = integer.Value;
            }
        }
    }
}