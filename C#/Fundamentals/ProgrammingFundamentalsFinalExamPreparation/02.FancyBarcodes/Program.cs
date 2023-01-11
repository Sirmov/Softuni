using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(@[#]+)[A-Z][A-Za-z0-9]{4,}[A-Z](@[#]+)");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                if (regex.IsMatch(barcode))
                {
                    StringBuilder productGroup = new StringBuilder();
                    bool isDefault = true;

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (char.IsDigit(barcode[j]))
                        {
                            productGroup.Append(barcode[j]);
                            isDefault = false;
                        }
                    }

                    if (isDefault)
                    {
                        productGroup.Append("00");
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
