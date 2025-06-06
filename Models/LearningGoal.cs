using SQLite;
using System;

namespace CubHubApp.Models
{
    public class LearningGoal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }  // Foreign key to Student.Id

        [NotNull]
        public string Title { get; set; }  // E.g. "Master Algebra"

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }  // Deadline or target achievement date

        public bool IsCompleted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}
