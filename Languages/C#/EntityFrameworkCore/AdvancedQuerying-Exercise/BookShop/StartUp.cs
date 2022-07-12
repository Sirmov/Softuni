namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            // Problem 1
            //string ageRestriction = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, ageRestriction));

            // Problem 2
            //Console.WriteLine(GetGoldenBooks(db));

            // Problem 3
            //Console.WriteLine(GetBooksByPrice(db));

            // Problem 4
            //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));

            // Problem 5
            //Console.WriteLine(GetBooksByCategory(db, 'horror mystery drama'));

            // Problem 6
            //Console.WriteLine(GetBooksReleasedBefore(db , "12-04-1992"));

            // Problem 7
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return JoinOnNewLine(books, (b) => b);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            return JoinOnNewLine(books, (b) => b);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            return JoinOnNewLine(books, (b) => $"{b.Title} - ${b.Price:F2}");
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return JoinOnNewLine(books, (b) => b);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Where(b => b.BookCategories
                    .Select(bc => categories
                    .Contains(bc.Category.Name.ToLower()))
                    .Any(b => b == true))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return JoinOnNewLine(books, (b) => b);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            return JoinOnNewLine(books, (b) => $"{b.Title} - {b.EditionType} - ${b.Price:F2}");
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.Name)
                .ToList();

            return JoinOnNewLine(authors, (a) => a.Name);
        }

        private static string JoinOnNewLine<T>(IEnumerable<T> collection, Func<T, string> toString)
        {
            StringBuilder output = new StringBuilder();

            foreach (var entry in collection)
            {
                output.AppendLine(toString(entry));
            }

            return output.ToString().TrimEnd();
        }
    }
}
