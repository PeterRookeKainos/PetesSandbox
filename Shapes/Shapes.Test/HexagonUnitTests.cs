using Xunit;

namespace Shapes.Test
{
    public class HexagonUnitTests
    {
        [Fact]
        public void Constructor_SetsSideLength()
        {
            var hexagon = new Hexagon(3);
            Assert.Equal(3, hexagon.SideLength);
        }

        [Fact]
        public void Area_ReturnsCorrectValue()
        {
            var hexagon = new Hexagon(2);
            var expected = (3 * Math.Sqrt(3) / 2) * 4; // Area formula: (3√3/2) * side^2
            Assert.Equal(expected, hexagon.GetArea(), 5);
        }

        [Fact]
        public void Constructor_ThrowsOnNegativeSideLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Hexagon(-1));
        }
    }
}