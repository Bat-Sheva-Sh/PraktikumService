using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllAsync();
        //Task<Child> GetByIdAsync(int id);
        Task<Child> GetByTzAsync(string childId);
        Task<Child> AddAsync(string name, string childId, DateTime dateOfBirth, int parentId);
        Task<Child> UpdateAsync(int id, string name, string childId, DateTime dateOfBirth, int parentId);
        Task DeleteAsync(string childId);
    }
}
