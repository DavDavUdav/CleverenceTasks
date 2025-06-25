using TestTask;

namespace Task1Tests
{
    [TestFixture]
    public class DecompressionTests
    {
        [TestCase("a3b2c3d2e", "aaabbcccdde")]
        public void DecompressionTest(string inputString, string expected)
        {
            var result = Task1.Decompression(inputString);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DecompressionNullTest()
        {
            var result = Task1.Compression(null);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void DecompressionEmptyStringTest()
        {
            var result = Task1.Compression(string.Empty);
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
