using NUnit.Framework;
using RobotCleaner;

namespace RobotCleanerTests
{
    public class TestsInput
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestParseStartPosition()
        {
            string[] args = { "0", "4 5" };

            Input input = new Input(args);

            Assert.AreEqual(input.GetStartX(), 4);
            Assert.AreEqual(input.GetStartY(), 5);
        }

        [Test]
        public void TestParseStartPositionNegativeX()
        {
            string[] args = { "0", "-4 5" };

            Input input = new Input(args);

            Assert.AreEqual(input.GetStartX(), -4);
            Assert.AreEqual(input.GetStartY(), 5);
        }
    }
}