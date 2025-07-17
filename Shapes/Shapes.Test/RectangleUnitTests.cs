using Xunit;

namespace Shapes.Test
{
    public class RectangleUnitTests
    {
        [Fact]
        public void Constructor_SetsWidthAndHeight()
        {
            var rectangle = new Rectangle(4, 5);
            Assert.Equal(4, rectangle.Width);
            Assert.Equal(5, rectangle.Height);
        }

        [Fact]
        public void Area_ReturnsCorrectValue()
        {
            var rectangle = new Rectangle(3, 6);
            Assert.Equal(18, rectangle.GetArea());
        }

        [Fact]
        public void Constructor_ThrowsOnNegativeWidth()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(-1, 5));
        }

        [Fact]
        public void Constructor_ThrowsOnNegativeHeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(4, -2));
        }
    }
}