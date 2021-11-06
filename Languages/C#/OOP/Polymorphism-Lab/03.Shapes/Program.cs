using System;

namespace Shapes
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5, 5);
            Circle circle = new Circle(6);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
        }
    }
}