using CubHubApp.Models;
using CubHubApp.Services.Interfaces;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CubHubApp.Services.Implementations
{
    public class DatabaseService : IDataBaseService
    {
        private static SQLiteAsyncConnection Database;
        private static readonly string DatabaseFilename = "CubHub.db3";

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

        public async Task<SQLiteAsyncConnection> GetDbConnection()
        {
            if (Database != null)
                return Database;

            try
            {
                Database = new SQLiteAsyncConnection(DatabasePath);
                await CreateTables(); // Create tables if DB is new
                return Database;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to open connection: {ex.Message}");
                return null;
            }
        }

        public Task<int> ExecuteSql(string sql)
        {
            return Database.ExecuteAsync(sql);
        }

        public async Task CreateTables()
        {
            try
            {
                var db = await GetDbConnection();

                // Register all table models here
                await db.CreateTableAsync<Student>();
                await db.CreateTableAsync<LearningGoal>();
                await db.CreateTableAsync<StudyNote>();
                await db.CreateTableAsync<AiChatHistory>();
                await db.CreateTableAsync<QuizQuestion>();
                await db.CreateTableAsync<QuizAttempt>();
                await db.CreateTableAsync<DailyFocusLog>();
                await db.CreateTableAsync<NotificationLog>();
                await db.CreateTableAsync<StreakTracker>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to create tables: {ex.Message}");
            }
        }

        public async Task<bool> TableExists(string tableName)
        {
            try
            {
                var db = await GetDbConnection();
                var result = await db.ExecuteScalarAsync<int>(
                    $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}'");
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] TableExists check failed: {ex.Message}");
                return false;
            }
        }

        public async Task DeleteDatabase()
        {
            try
            {
                if (File.Exists(DatabasePath))
                {
                    Database = null;
                    File.Delete(DatabasePath);
                    Console.WriteLine("[DB] Database deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to delete database: {ex.Message}");
            }
        }
    }
}
