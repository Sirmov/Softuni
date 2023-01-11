using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>(n);

            for (int i = 0; i < n; i++)
            {
                string[] articleProperties = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = articleProperties[0];
                string content = articleProperties[1];
                string author = articleProperties[2];

                articles.Add(new Article(title, content, author));
            }

            string criteria = Console.ReadLine();
            articles = OrderByCriteria(articles, criteria);

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        static List<Article> OrderByCriteria(List<Article> list, string criteria)
        {
            switch (criteria)
            {
                case "title":
                    return list.OrderBy(x => x.Title).ToList();
                    break;

                case "content":
                    return list.OrderBy(x => x.Content).ToList();
                    break;

                case "author":
                    return list.OrderBy(x => x.Author).ToList();
                    break;
            }

            return null;
        }
    }
    

    class Article
    {
        private string title;
        private string content;
        private string author;

        public string Title { get { return title; } set { title = value; } }
        public string Content { get { return content; } set { content = value; } }
        public string Author { get { return author; } set { author = value; } }

        public Article(string title, string content, string author)
        {
            this.title = title;
            this.content = content;
            this.author = author;
        }
        
        public override string ToString()
        {
            return $"{title} - {content}: {author}";
        }
    }
}
