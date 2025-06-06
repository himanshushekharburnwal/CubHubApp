using SQLite;
using System;

namespace CubHubApp.Models
{
    public class DailyFocusLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime Date { get; set; }  // Day of focus

        public int FocusMinutes { get; set; }  // Total minutes student focused studying

        public int DistractionCount { get; set; }  // Times distracted (e.g. reels)

        public int ShortQuizzesCompleted { get; set; }  // Number of quizzes done that day
    }
}
