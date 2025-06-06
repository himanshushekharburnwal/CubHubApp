using CubHubApp.Helper;
using CubHubApp.Models;
using CubHubApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubHubApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IDataBaseService _dataBaseService;
        public StudentService(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
            
        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            var db = await _dataBaseService.GetDbConnection();
            var normalizedEmail = email.ToLowerInvariant();
            var student = await db.Table<Student>()
                .Where(s => s.Email == normalizedEmail)
                .FirstOrDefaultAsync();
            return student;

        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            var db = await _dataBaseService.GetDbConnection();
            var normalizedEmail = email.ToLowerInvariant();
            var existing = await db.Table<Student>()
                .Where(s => s.Email == normalizedEmail)
                .FirstOrDefaultAsync();
            return existing != null;
        }

        public async Task<bool> RegisterStudentAsync(Student student, string plainPassword)
        {
            var db = await _dataBaseService.GetDbConnection();

            var normalizedEmail = student.Email.ToLowerInvariant();

            if (await IsEmailTakenAsync(normalizedEmail))
                return false;

            var (hash, salt) = PasswordHelper.CreatePasswordHash(plainPassword);

            student.Email = normalizedEmail;
            student.PasswordHash = hash;
            student.PasswordSalt = salt;
            student.DateRegistered = DateTime.UtcNow;
            student.LastLogin = DateTime.UtcNow;
            student.IsActive = true;

            var result = await db.InsertAsync(student);
            return result > 0;
        }
    }
}
