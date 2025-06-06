using SQLite;
using System;

namespace CubHubApp.Models
{
    public class QuizAttempt
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int QuizQuestionId { get; set; }

        public string SelectedOption { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime AttemptDate { get; set; }
    }
}
