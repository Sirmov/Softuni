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

            // Problem 8
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));

            // Problem 9
            //Console.WriteLine(GetBooksByAuthor(db, "R"));

            // Problem 10
            //int lengthCheck = 12;
            //int booksCount = CountBooks(db, lengthCheck);
            //Console.WriteLine($"There are {booksCount} books with longer title than {lengthCheck} symbols");

            // Problem 11
            //Console.WriteLine(CountCopiesByAuthor(db));

            // Problem 12
            //Console.WriteLine(GetTotalProfitByCategory(db));

            // Problem 13
            //Console.WriteLine(GetMostRecentBooks(db));

            // Problem 14
            //IncreasePrices(db);

            // Problem 15
            //Console.WriteLine(RemoveBooks(db));
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

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(b => b.Title
                    .Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return JoinOnNewLine(bookTitles, (bt) => bt);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .OrderBy(b => b.BookId)
                .AsEnumerable()
                .Where(b => b.Author.LastName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            return JoinOnNewLine(books, (b) => $"{b.Title} ({b.AuthorName})");
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            return JoinOnNewLine(authors, (a) => $"{a.Name} - {a.BookCopies}");
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            return JoinOnNewLine(categories, (c) => $"{c.Name} ${c.Profit:F2}");
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder output = new StringBuilder();

            foreach (var category in categories)
            {
                output.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    output.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();
            int removedCount = books.Count;

            context.RemoveRange(books);
            context.SaveChanges();

            return removedCount;
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
