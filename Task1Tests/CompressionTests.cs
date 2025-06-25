using TestTask;

namespace Task1Tests
{
    [TestFixture]
    public class CompressionTests
    {
        [TestCase("aaabbcccdde", "a3b2c3d2e")]
        [TestCase("abc", "abc")]
        public void Compression_ValidInput_ReturnCompressedString(string inputString, string expected)
        {
            var result = Task1.Compression(inputString);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Compression_NullInput_ReturnEmptyString()
        {
            var result = Task1.Compression(null);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Compression_EmptyStringInput_ReturnEmptyString()
        {
            var result = Task1.Compression(string.Empty);
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
