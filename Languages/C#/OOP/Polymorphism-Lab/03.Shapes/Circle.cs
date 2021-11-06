﻿using System;

namespace Shapes
{
    internal class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get => radius; set => radius = value; }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.Draw());

            //double rIn = this.Radius - 0.4;
            //double rOut = this.Radius + 0.4;

            //for (double y = this.Radius; y >= -this.Radius; --y)
            //{
            //    for (double x = -this.Radius; x < rOut; x += 0.5)
            //    {
            //        double value = x * x + y * y;

            //        if (value >= rIn * rIn && value <= rOut * rOut)
            //        {
            //            sb.Append('*');
            //        }
            //        else
            //        {
            //            sb.Append(' ');
            //        }
            //    }

            //    sb.AppendLine();
            //}

            //return sb.ToString();

            return base.Draw() + this.GetType().Name;
        }
    }
}