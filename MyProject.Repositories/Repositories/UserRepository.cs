using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo)
        {
            if (_context.Users.Count(u => u.UserId == userId) == 1)
                throw new Exception("משתמש קיים");
            var newUser = new User { Name = name, DateOfBirth = dateOfBirth, FamilyName = familyName, Hmo = hmo, Kind = kind, UserId = userId };
            var result = _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteAsync(string userId)
        {
            var user = await GetByTzAsync(userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByTzAsync(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        //הסתמכתי על כך שבעדכון חיב משהו אחד קים וזה  ה- איידי
        public async Task<User> UpdateAsync(int id, string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo)
        {
            var updatedUser = _context.Users.Update(new User { Id = id, Name = name, DateOfBirth = dateOfBirth, FamilyName = familyName, Hmo = hmo, Kind = kind, UserId = userId });
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
