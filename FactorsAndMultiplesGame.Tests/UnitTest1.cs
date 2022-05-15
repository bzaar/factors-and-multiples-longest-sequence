using NUnit.Framework;

namespace FactorsAndMultiplesGame.Tests
{
    public class Tests
    {
        [Test]
        [TestCase(44, "88 1 2 4 11 22")]
        public void Test1(int n, string expected)
        {
            string actual = string.Join(" ", Program.GetFactorsAndMultiples(n));
            Assert.AreEqual(expected, actual);
        }
    }
}