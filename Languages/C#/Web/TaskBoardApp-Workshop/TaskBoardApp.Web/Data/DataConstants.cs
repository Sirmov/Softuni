namespace TaskBoardApp.Web.Data
{
    public static class DataConstants
    {
        public static class User
        {
            public const int FirstNameMaxLength = 15;
            public const int LastNameMaxLength = 15;
            public const int UsernameMaxLength = 15;
        }

        public static class Task
        {
            public const int TitleMaxLength = 70;
            public const int TitleMinLength = 5;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 10;
        }

        public static class Board
        {
            public const int NameMaxLenght = 30;
            public const int NameMinLength = 3;
        }
    }
}
