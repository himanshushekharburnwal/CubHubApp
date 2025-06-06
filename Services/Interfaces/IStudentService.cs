using CubHubApp.Models;
using System.Threading.Tasks;

namespace CubHubApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> IsEmailTakenAsync(string email);
        Task<bool> RegisterStudentAsync(Student student, string plainPassword);
        Task<Student> GetStudentByEmailAsync(string email);
    }
}
