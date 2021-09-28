using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> fileInfos = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles(@"..\..\..\");

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = fileInfo.Length / 1024.0;

                if (!fileInfos.ContainsKey(extension))
                {
                    fileInfos.Add(extension, new Dictionary<string, double>());
                }

                fileInfos[extension].Add(name, size);
            }

            List<string> lines = new List<string>();

            foreach (var extension in fileInfos.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                lines.Add(extension.Key);

                foreach (var (name, size) in extension.Value.OrderBy(x => x.Value))
                {
                    lines.Add($"--{name} - {size:F3}kb" + Environment.NewLine);
                }
            }

            string path = Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop)
                + @"\report.txt";
            File.WriteAllLines(path, lines);
        }
    }
}
