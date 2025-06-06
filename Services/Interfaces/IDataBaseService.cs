using SQLite;
using System.Threading.Tasks;

namespace CubHubApp.Services.Interfaces
{
    public interface IDataBaseService
    {
        Task<SQLiteAsyncConnection> GetDbConnection();

        Task<int> ExecuteSql(string sql);

        Task CreateTables();

        Task<bool> TableExists(string tableName);

        Task DeleteDatabase();
    }
}
