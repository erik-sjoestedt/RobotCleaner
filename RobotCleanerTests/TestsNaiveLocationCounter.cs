using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RobotCleaner;

namespace RobotCleanerTests
{
    class TestsNaiveLocationCounter
    {
        [Test]
        public void TestCountThreeDistinctMoves()
        {
            List<MoveCommand> moves = new List<MoveCommand>
            {
                new MoveCommand(Direction.N, 2),
                new MoveCommand(Direction.S, 2),
            };

            NaiveLocationCounter counter = new NaiveLocationCounter(0, 0, moves);

            Assert.AreEqual(3, counter.CountDistinct());
        }

        [Test]
        public void TestCountFourDistinctMoves()
        {
            List<MoveCommand> moves = new List<MoveCommand>
            {
                new MoveCommand(Direction.N, 2),
                new MoveCommand(Direction.E, 4),
                new MoveCommand(Direction.S, 2),
                new MoveCommand(Direction.W, 4),
            };

            NaiveLocationCounter counter = new NaiveLocationCounter(4, -4, moves);

            Assert.AreEqual(12, counter.CountDistinct());
        }
    }
}
