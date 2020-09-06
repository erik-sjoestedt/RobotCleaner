using System;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input(args);
            ILocationCounter counter = new NaiveLocationCounter(
                input.GetStartX(),
                input.GetStartY(),
                input.GetMoveCommands()
            );
            Console.Write("=> Cleaned: " + counter.CountDistinct().ToString());
        }
    }
}
