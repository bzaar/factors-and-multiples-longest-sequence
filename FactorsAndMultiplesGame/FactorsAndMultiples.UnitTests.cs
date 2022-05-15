using NUnit.Framework;

namespace FactorsAndMultiplesGame
{
    public class FactorsAndMultiplesUnitTests
    {
        [Test]
        [TestCase(44, "88 1 2 4 11 22")]
        [TestCase(55, "1 5 11")]
        public void Test1(int n, string expected)
        {
            string actual = string.Join(" ", FactorsAndMultiples.Get(n));
            Assert.AreEqual(expected, actual);
        }
    }
}