namespace Shapes
{
    internal class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get => this.width; set => this.width = value; }

        public double Height { get => this.height; set => this.height = value; }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return this.Width * 2 + this.Height * 2;
        }

        public override string Draw()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.Draw());

            //for (int i = 0; i < this.Height; i++)
            //{
            //    if (i == 0 || i == this.Height - 1)
            //    {
            //        sb.AppendLine(new string('*', (int) this.Width));
            //    }
            //    else
            //    {
            //        sb.AppendLine("*" + new string(' ', (int) this.Width - 2) + "*");
            //    }
            //}

            //return sb.ToString();

            return base.Draw() + this.GetType().Name;
        }
    }
}