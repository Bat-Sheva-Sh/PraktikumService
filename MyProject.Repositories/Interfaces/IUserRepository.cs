using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByTzAsync(string userId);
        Task<User> AddAsync(string name, string userId, DateTime dateOfBirth, string familyName, string kinds , string hmo);
        Task<User> UpdateAsync(int id, string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo);
        Task DeleteAsync(string userId);
    }
}
