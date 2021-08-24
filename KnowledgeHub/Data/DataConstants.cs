namespace KnowledgeHub.Data
{
    public static class DataConstants
    {
        public class Video
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
            public const int DescriptionMinLength = 20;
        }

        public class Course
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
            public const int DescriptionMinLength = 30;
        }

        public class Topic
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 20;
            public const int DescriptionMinLength = 20;
        }

        public class Person
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;
        }

        public class User
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 40;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }
    }

}
