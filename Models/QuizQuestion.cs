using SQLite;
using System;

namespace CubHubApp.Models
{
    public class QuizQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int LearningGoalId { get; set; }  // Which topic/goal it belongs to

        [NotNull]
        public string QuestionText { get; set; }

        [NotNull]
        public string OptionA { get; set; }

        [NotNull]
        public string OptionB { get; set; }

        [NotNull]
        public string OptionC { get; set; }

        [NotNull]
        public string OptionD { get; set; }

        [NotNull]
        public string CorrectOption { get; set; }  // e.g. "A", "B"

        public string Explanation { get; set; }  // Explanation for answer
    }
}
