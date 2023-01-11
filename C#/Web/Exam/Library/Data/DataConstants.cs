namespace Library.Data
{
    public static class DataConstants
    {
        public static class ApplicationUser
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLenght = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;

            public const decimal MinRating = 0.00m;
            public const decimal MaxRating = 10.00m;
            public const string RatingMinRange = "0.00";
            public const string RatingMaxRange = "10.00";
        }

        public static class Category
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
