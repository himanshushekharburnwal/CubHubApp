using SQLite;
using System;

namespace CubHubApp.Models
{
    public class AiChatHistory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        [NotNull]
        public string Question { get; set; }

        [NotNull]
        public string Answer { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
