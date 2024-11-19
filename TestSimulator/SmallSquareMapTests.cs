using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 10;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(4, 4, 5, true)]
    [InlineData(5, 5, 5, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 8, Direction.Left, -1, 8)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);

        if (map.Exist(new Point(expectedX, expectedY)))
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        else
            Assert.Equal(point, nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 8, Direction.Left, -1, 9)]
    [InlineData(19, 19, Direction.Right, 20, 18)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextDiagonalPoint = map.NextDiagonal(point, direction);

        if (map.Exist(new Point(expectedX, expectedY)))
            Assert.Equal(new Point(expectedX, expectedY), nextDiagonalPoint);
        else
            Assert.Equal(point, nextDiagonalPoint);
    }
}
