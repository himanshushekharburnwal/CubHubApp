using SQLite;
using System;

namespace CubHubApp.Models
{
    public class StudyNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int LearningGoalId { get; set; }  // Related Goal

        [NotNull]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModified { get; set; }
    }
}
