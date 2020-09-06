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
            MoveCommand[] moves =
            {
                new MoveCommand(Direction.N, 2),
                new MoveCommand(Direction.S, 2),
            };

            NaiveLocationCounter counter = new NaiveLocationCounter(0, 0, moves);

            Assert.AreEqual(3, counter.CountDistinct());
        }
    }
}
