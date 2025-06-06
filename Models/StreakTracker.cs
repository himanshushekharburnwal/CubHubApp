using SQLite;
using System;

namespace CubHubApp.Models
{
    public class StreakTracker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CurrentStreakDays { get; set; }

        public int LongestStreakDays { get; set; }

        public DateTime LastStudyDate { get; set; }
    }
}
