using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Exceptions;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(DepartmentCreateDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department == null)
            {
                throw new NotFoundException("Department not found!");
            }
            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<DepartmentGetDto>> GetAllAsync()
        {
            var departments = await _repository.GetAll().Include(x=>x.Employees).ToListAsync();
            var dtos = _mapper.Map<List<DepartmentGetDto>>(departments);
            return dtos;
        }

        public async Task<DepartmentGetDto?> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new NotFoundException("Department not found!");
            }
            var dto = _mapper.Map<DepartmentGetDto>(employee);
            return dto;
        }

        public async Task UpdateAsync(DepartmentUpdateDto dto)
        {
            var isexistDepartment = await _repository.GetByIdAsync(dto.Id);
            if (isexistDepartment == null)
            {
                throw new NotFoundException("Department not found!");
            }
            isexistDepartment = _mapper.Map(dto, isexistDepartment);
            _repository.Update(isexistDepartment);
            await _repository.SaveChangesAsync();
        }
    }
}
