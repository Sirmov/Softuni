using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleProperties = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Article article = new Article
            (
                articleProperties[0],
                articleProperties[1],
                articleProperties[2]
            );

            for (int i = 0; i < n; i++)
            {
                List<string> commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string command = commandArgs[0];
                commandArgs.RemoveAt(0);
                string arg = string.Join(' ', commandArgs);

                switch (command)
                {
                    case "Edit:":
                        article.Edit(arg);
                        break;
                    case "ChangeAuthor:":
                        article.ChangeAuthor(arg);
                        break;
                    case "Rename:":
                        article.Rename(arg);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        private string title;
        private string content;
        private string author;

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.title = title;
            this.content = content;
            this.author = author;
        }

        public void Edit(string newContent)
        {
            content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            title = newTitle;
        }

        public override string ToString()
        {
            return $"{title} - {content}: {author}";
        }

        
    }
}
