using Simulator;


namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetPropertiesCorrectly()
    {
        int x1 = 2, y1 = 3, x2 = 5, y2 = 6;
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Theory]
    [InlineData(2, 3, 2, 6)]
    [InlineData(2, 3, 5, 3)]
    public void Constructor_InvalidCoordinates_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_PointBased_ShouldSetPropertiesCorrectly()
    {
        var p1 = new Point(1, 2);
        var p2 = new Point(4, 5);
        var rectangle = new Rectangle(p1, p2);
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(2, rectangle.Y1);
        Assert.Equal(4, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);
    }

    [Theory]
    [InlineData(3, 4, true)]
    [InlineData(2, 3, true)]
    [InlineData(5, 6, true)]
    [InlineData(6, 4, false)]
    public void Contains_ShouldReturnCorrectResult(int x, int y, bool expected)
    {
        var rectangle = new Rectangle(2, 3, 5, 6);
        var point = new Point(x, y);
        var result = rectangle.Contains(point);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString()
    {
        var rectangle = new Rectangle(2, 3, 5, 6);
        var result = rectangle.ToString();
        Assert.Equal("(2, 3):(5, 6)", result);
    }
}
