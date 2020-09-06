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

        public NaiveLocationCounter(int startX, int startY, MoveCommand[] moves)
        {
            this.LoadLocations(startX, startY, moves);
        }

        private void LoadLocations(int startX, int startY, MoveCommand[] moves)
        {
            int x = startX;
            int y = startY;
            int newPos = x;
            bool horizontal = true;
            int steps;
            locations.TryAdd(LocationString(x, y), 1);
            for (int i = 0; i < moves.Length; i++)
            {
                steps = moves[i].GetNumSteps();
                switch (moves[i].GetDirection())
                {
                    case Direction.N:
                        newPos = y + steps;
                        horizontal = false;
                        break;
                    case Direction.W:
                        newPos = x - steps;
                        horizontal = true;
                        break;
                    case Direction.S:
                        newPos = y - steps;
                        horizontal = false;
                        break;
                    case Direction.E:
                        newPos = x + steps;
                        horizontal = true;
                        break;
                }
                if (horizontal)
                {
                    MoveHorizontally(x, y, newPos);
                    x = newPos;
                } else
                {
                    MoveVertically(x, y, newPos);
                    y = newPos;
                }
            }
        }

        private void MoveHorizontally(int x, int y, int newX)
        {
            for (; x <= newX; x++)
            {
                locations.TryAdd(LocationString(x, y), 1);
            }
        }
        private void MoveVertically(int x, int y, int newY)
        {
            for (; y <= newY; y++)
            {
                locations.TryAdd(LocationString(x, y), 1);
            }
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
