using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetListAsync();

        Task<UserDTO> GetByTzAsync(string userId);

        Task<UserDTO> AddAsync(string name, string userId, DateTime dateOfBirth, string familyName,  string kind, string hmo);

        Task<UserDTO> UpdateAsync(int id, string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo);

        Task DeleteAsync(string userId);
    }
}
