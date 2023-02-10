using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class ChildRepository:IChildRepository
    {
        private readonly IContext _context;
        public ChildRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Child> AddAsync(string name, string childId, DateTime dateOfBirth, int parentId)
        {
            var newChild = new Child { Name = name, DateOfBirth = dateOfBirth, ChildId = childId, ParentId=parentId };
            var result = _context.Children.Add(newChild);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteAsync(string childId)
        {
            var child = await GetByTzAsync(childId);
            _context.Children.Remove(child);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAllAsync()
        {
            return await _context.Children.Include(p=>p.Parent).ToListAsync();
        }

        public async Task<Child> GetByTzAsync(string childId)
        {
            return await _context.Children.Include(p => p.Parent).FirstOrDefaultAsync(p => p.ChildId == childId);
        }

        //הסתמכתי על כך שבעדכון חיב משהו אחד קים וזה  ה- איידי
        public async Task<Child> UpdateAsync(int id, string name, string childId, DateTime dateOfBirth, int parentId)
        {
            var updatedChild = _context.Children.Update(new Child { Id = id, Name = name, DateOfBirth = dateOfBirth, ChildId = childId , ParentId=parentId});
            await _context.SaveChangesAsync();
            return updatedChild.Entity;
        }
    }
}
