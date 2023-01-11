namespace Watchlist.Data
{
    public static class DataConstants
    {
        public static class User
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class Genre
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class Movie
        {
            public const int TitleMinLenght = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const decimal MinRating = 0.00m;
            public const decimal MaxRating = 10.00m;
            public const string RatingMinRange = "0.00";
            public const string RatingMaxRange = "10.00";
        }
    }
}
