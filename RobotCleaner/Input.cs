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

        public Input(string[] args)
        {
            ParseStartPosition(args[1]);
        }

        private void ParseStartPosition(string startPos)
        {
            string[] startPositions = startPos.Split(" ");
            startX = Int32.Parse(startPositions[0]);
            startY = Int32.Parse(startPositions[1]);
        }

        public int GetStartX()
        {
            return startX;
        }
        public int GetStartY()
        {
            return startY;
        }
    }
}