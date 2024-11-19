using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)] 
    [InlineData(15, 1, 10, 10)] 
    [InlineData(1, 1, 10, 1)] 
    [InlineData(10, 1, 10, 10)] 
    public void Limiter_ShouldReturnClampedValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 3, 10, '_', "Hello")]
    [InlineData("hello world", 3, 5, '_', "Hello")]
    [InlineData("hi", 5, 10, '_', "Hi___")]
    [InlineData("    hi    ", 5, 10, '_', "Hi___")]
    [InlineData("a", 2, 4, '_', "A_")]
    [InlineData("apple", 3, 5, '_', "Apple")]
    public void Shortener_ShouldProcessStringCorrectly(string value, int min, int max, char placeholder, string expected)
    {

        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal(expected, result);
    }
}

