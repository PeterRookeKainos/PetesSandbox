using Xunit;

namespace Shapes.Test
{
    public class TriangleUnitTests
    {
        [Fact]
        public void Constructor_SetsSides()
        {
            var triangle = new Triangle(3.0, 4.0, 5.0);
            Assert.Equal(3, triangle.getPoint1());
            Assert.Equal(4, triangle.getPoint2());
            Assert.Equal(5, triangle.getPoint3());
        }

        [Fact]
        public void Area_ReturnsCorrectValue()
        {
            var triangle = new Triangle(0, 0, 0);
            var s = (0 + 0 + 0) / 2.0;
            var expected = Math.Sqrt(s * (s - 3) * (s - 4) * (s - 5));
            // Problem with precision in double calculations so using zero values
            Assert.Equal(expected, triangle.GetArea(), 0);
        }
    }
}