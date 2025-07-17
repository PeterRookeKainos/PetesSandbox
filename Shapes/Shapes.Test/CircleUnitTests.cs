using Xunit;

namespace Shapes.Test
{
    public class CircleUnitTests
    {
        [Fact]
        public void Constructor_SetsRadius()
        {
            var circle = new Circle(5);
            Assert.Equal(5, circle.GetRadius());
        }

        [Fact]
        public void Area_ReturnsCorrectValue()
        {
            var circle = new Circle(2);
            var expected = Math.PI * 4;
            Assert.Equal(expected, circle.GetArea(), 0);
        }

        [Fact]
        public void Constructor_ThrowsOnNegativeRadius()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }
    }
}