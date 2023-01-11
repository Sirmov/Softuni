using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private decimal height;
        private decimal width;
        private decimal length;

        public Box(decimal lenght, decimal width, decimal height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        private decimal Length
        {
            get => length;

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        private decimal Width
        {
            get => width;

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        private decimal Height
        {
            get => height;

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public decimal GetSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public decimal GetLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public decimal GetVolume()
        {
            return Length * Width * Height;
        }
    }
}
