using System;

namespace AuthorProblem
{
    [Author("Nikola")]
    public class StartUp
    {
        [Author("Sirmov")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
