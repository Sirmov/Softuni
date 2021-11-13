using System;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; set; }

        public void Draw()
        {
            StringBuilder sb = new StringBuilder();

            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;

            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb);
        }
    }
}
