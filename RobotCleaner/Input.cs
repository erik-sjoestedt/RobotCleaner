using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner
{
    public class Input
    {
        private int startX;
        private int startY;
        private readonly List<MoveCommand> moveCommands = new List<MoveCommand>();

        public Input(string[] args)
        {
            ParseStartPosition(args[1]);
            ParseMoveCommands(args);
        }

        private void ParseStartPosition(string startPos)
        {
            string[] startPositions = startPos.Split(" ");
            startX = Int32.Parse(startPositions[0]);
            startY = Int32.Parse(startPositions[1]);
        }

        private void ParseMoveCommands(string[] args)
        {
            int numCommands = Int32.Parse(args[0]);
            // move commands start at 2nd index
            for (int i = 2; i < numCommands + 2; i++)
            {
                string[] moveCommandArgs = args[i].Split(" ");
                Direction direction;
                int numSteps = Int32.Parse(moveCommandArgs[1]);
                switch (moveCommandArgs[0])
                {
                    case "N":
                        direction = Direction.E;
                        break;
                    case "W":
                        direction = Direction.W;
                        break;
                    case "S":
                        direction = Direction.S;
                        break;
                    case "E":
                        direction = Direction.E;
                        break;
                    default:
                        throw new Exception("Direction not supported");
                }
                moveCommands.Add(new MoveCommand(direction, numSteps));
            }
        }

        public int GetStartX()
        {
            return startX;
        }
        public int GetStartY()
        {
            return startY;
        }

        public List<MoveCommand> GetMoveCommands() { 
            return moveCommands; 
        }
    }

    public struct MoveCommand
    {
        private Direction direction;
        private int numSteps;

        public MoveCommand(Direction direction, int numSteps)
        {
            this.direction = direction;
            this.numSteps = numSteps;
        }

        public Direction GetDirection() {
            return direction;
        }

        public int GetNumSteps() {
            return numSteps;
        }
    }

    public enum Direction
    {
        N, W, S, E
    }
}