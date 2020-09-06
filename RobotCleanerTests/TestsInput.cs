using NUnit.Framework;
using RobotCleaner;
using System.Collections.Generic;

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

        [Test]
        public void TestParseTwoMoveCommands()
        {
            string[] args = { "2", "0 0", "E 1", "S 2"};

            Input input = new Input(args);
            List<MoveCommand> moveCommands = input.GetMoveCommands();

            Assert.AreEqual(moveCommands[0].GetDirection(), Direction.E);
            Assert.AreEqual(moveCommands[0].GetNumSteps(), 1);

            Assert.AreEqual(moveCommands[1].GetDirection(), Direction.S);
            Assert.AreEqual(moveCommands[1].GetNumSteps(), 2);
        }

        [Test]
        public void TestParseFourMoveCommands()
        {
            string[] args = { "4", "-4 -4", "N 2", "E 4", "S 2", "W 4",};

            Input input = new Input(args);
            List<MoveCommand> moveCommands = input.GetMoveCommands();

            Assert.AreEqual(moveCommands[0].GetDirection(), Direction.N);
            Assert.AreEqual(moveCommands[0].GetNumSteps(), 2);

            Assert.AreEqual(moveCommands[1].GetDirection(), Direction.E);
            Assert.AreEqual(moveCommands[1].GetNumSteps(), 4);

            Assert.AreEqual(moveCommands[2].GetDirection(), Direction.S);
            Assert.AreEqual(moveCommands[2].GetNumSteps(), 2);

            Assert.AreEqual(moveCommands[3].GetDirection(), Direction.W);
            Assert.AreEqual(moveCommands[3].GetNumSteps(), 4);
        }
    }
}