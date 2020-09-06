using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotCleaner
{
    public class NaiveLocationCounter: ILocationCounter
    {
        private readonly Dictionary<string, int> locations = new Dictionary<string, int>();

        public NaiveLocationCounter(int startX, int startY, List<MoveCommand> moves)
        {
            this.LoadLocations(startX, startY, moves);
        }

        private void LoadLocations(int startX, int startY, List<MoveCommand> moves)
        {
            int x = startX;
            int y = startY;
            int steps;
            Visit(x, y);
            for (int i = 0; i < moves.Count; i++)
            {
                steps = moves[i].GetNumSteps();
                switch (moves[i].GetDirection())
                {
                    case Direction.N:
                        MoveVertically(x, y, y + steps);
                        y += steps;
                        break;
                    case Direction.W:
                        MoveHorizontally(x - steps, y, x);
                        x -= steps;
                        break;
                    case Direction.S:
                        MoveVertically(x, y - steps, y);
                        y -= steps;
                        break;
                    case Direction.E:
                        MoveHorizontally(x, y, x + steps);
                        x += steps;
                        break;
                }
            }
        }

        private void MoveHorizontally(int x, int y, int newX)
        {
            for (; x <= newX; x++)
            {
                Visit(x, y);
            }
        }
        private void MoveVertically(int x, int y, int newY)
        {
            for (; y <= newY; y++)
            {
                Visit(x, y);
            }
        }

        private void Visit(int x, int y)
        {
            locations.TryAdd(LocationString(x, y), 1);
        }

        private string LocationString(int x, int y)
        {
            return x.ToString() + "," + y.ToString();
        }

        public int CountDistinct()
        {
            return locations.Values.Count;
        }
    }
}
