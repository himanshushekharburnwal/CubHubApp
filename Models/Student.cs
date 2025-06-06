using SQLite;
using System;

namespace CubHubApp.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, NotNull]
        public string Email { get; set; }  // Make sure to lowercase during registration/login

        [NotNull]
        public string Name { get; set; }

        // Secure storage
        [NotNull]
        public string PasswordHash { get; set; }

        [NotNull]
        public string PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }

        public string BoardType { get; set; }  // CBSE, State Board, IIT-JEE etc.

        public int Grade { get; set; }  // 12, 11, etc.

        public string ProfileImageUrl { get; set; }

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        public DateTime LastLogin { get; set; } = DateTime.MinValue;  // Will update on login

        public bool IsActive { get; set; } = true;
    }
}
