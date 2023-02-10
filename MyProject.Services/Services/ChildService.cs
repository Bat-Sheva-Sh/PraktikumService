using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IMapper _mapper;

        //ctor
        public ChildService(IChildRepository childRepository, IMapper mapper)
        {
            _childRepository = childRepository;
            _mapper = mapper;
        }

        public async Task<ChildDTO> AddAsync(string name, string childId, DateTime dateOfBirth, int parentId)
        {
            return _mapper.Map<ChildDTO>(await _childRepository.AddAsync(name, childId, dateOfBirth, parentId));
        }

        public async Task<ChildDTO> UpdateAsync(int id, string name, string childId, DateTime dateOfBirth, int parentId)
        {
            return _mapper.Map<ChildDTO>(await _childRepository.UpdateAsync(id, name, childId, dateOfBirth, parentId));
        }
        //לוגיקה עסקית חסרה
        public async Task DeleteAsync(string childId)
        {
            await _childRepository.DeleteAsync(childId);
        }

        //public async Task<ChildDTO> GetByIdAsync(int id)
        //{
        //    //לוגיקה עסקית
        //    var child = await _childRepository.GetByIdAsync(id);
        //    return _mapper.Map<ChildDTO>(child);
        //}

        public async Task<ChildDTO> GetByTzAsync(string childId)
        {
            //לוגיקה עסקית
            var child = await _childRepository.GetByTzAsync(childId);
            return _mapper.Map<ChildDTO>(child);
        }

        public async Task<List<ChildDTO>> GetListAsync()
        {
            return _mapper.Map<List<ChildDTO>>(await _childRepository.GetAllAsync());
        }
    }
}
