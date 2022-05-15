using NUnit.Framework;

namespace FactorsAndMultiplesGame;

public class FactorsAndMultiplesUnitTests
{
    [Test]
    [TestCase(44, "88 1 2 4 11 22")]
    [TestCase(55, "1 5 11")]
    [TestCase(50, "100 1 2 5 10 25")]
    public void Test1(int n, string expected)
    {
        string actual = string.Join(" ", _factorsAndMultiples.Get(n));
        Assert.AreEqual(expected, actual);
    }
    
    private readonly FactorsAndMultiples _factorsAndMultiples = new (100);
}
