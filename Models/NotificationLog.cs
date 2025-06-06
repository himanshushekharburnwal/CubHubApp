using SQLite;
using System;

namespace CubHubApp.Models
{
    public class NotificationLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string NotificationTitle { get; set; }

        public string NotificationMessage { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }
    }
}
