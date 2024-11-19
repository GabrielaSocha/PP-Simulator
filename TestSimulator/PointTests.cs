using Simulator;


namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        var point = new Point(5, 10);
        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString()
    {
        var point = new Point(3, 7);
        Assert.Equal("(3, 7)", point.ToString());
    }

    [Theory]
    [InlineData(Direction.Up, 5, 6)]
    [InlineData(Direction.Down, 5, 4)]
    [InlineData(Direction.Left, 4, 5)]
    [InlineData(Direction.Right, 6, 5)]
    public void Next_ShouldReturnCorrectNextPoint(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(5, 5);
        var result = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData((Direction)99)] // Invalid direction
    public void Next_InvalidDirection_ShouldThrowInvalidOperationException(Direction direction)
    {
        var point = new Point(5, 5);
        Assert.Throws<InvalidOperationException>(() => point.Next(direction));
    }

    [Theory]
    [InlineData(Direction.Up, 6, 6)]
    [InlineData(Direction.Down, 4, 4)]
    [InlineData(Direction.Left, 4, 6)]
    [InlineData(Direction.Right, 6, 4)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(5, 5);
        var result = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData((Direction)99)] // Invalid direction
    public void NextDiagonal_InvalidDirection_ShouldThrowInvalidOperationException(Direction direction)
    {
        var point = new Point(5, 5);
        Assert.Throws<InvalidOperationException>(() => point.NextDiagonal(direction));
    }
}
