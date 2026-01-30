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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ICloudinaryService cloudinaryService, IDepartmentRepository departmentRepository )
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _departmentRepository = departmentRepository;
        }

        public async Task<ResultDto> CreateAsync(EmployeeCreateDto dto)
        {
            var isexistDepartment = await _departmentRepository.AnyAsync(x=>x.Id == dto.DepartmentId);
            if(!isexistDepartment)
            {
                throw new NotFoundException("Department not found");
            }
            var employee = _mapper.Map<Employee>(dto);

            var imagePath = await _cloudinaryService.FileUploadAsync(dto.Image);

            employee.ImagePath = imagePath;
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return new ResultDto();
        }

        public async Task<ResultDto> DeleteAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) 
            {
                throw new NotFoundException("Employee not found!");
            }
            
            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveChangesAsync();
            await _cloudinaryService.FileDeleteAsync(employee.ImagePath);
            return new ResultDto();
        }

        public async Task<ResultDto<List<EmployeeGetDto>>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAll(false).Include(x => x.Department).ToListAsync();
            var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);
            return new()
            {
                Data = dtos
            };

        }

        public async Task<ResultDto<EmployeeGetDto>> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new NotFoundException("Employee not found!");
            }
            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return new() { Data = dto, Message = "Get By id is Successfuly" };
        }

        public async Task<ResultDto> UpdateAsync(EmployeeUpdateDto dto)
        {
            var isexistDepartment = await _departmentRepository.AnyAsync(x => x.Id == dto.DepartmentId);
            if (!isexistDepartment)
            {
                throw new NotFoundException("Department not found");
            }
            var isexistEmployee = await _employeeRepository.GetByIdAsync(dto.Id);
            if (isexistEmployee == null) 
            {
                throw new NotFoundException("Employee not found!");
            }


            isexistEmployee = _mapper.Map(dto, isexistEmployee);

            if(dto.Image is { })
            {
                await _cloudinaryService.FileDeleteAsync(isexistEmployee.ImagePath);
                var newImagePath = await _cloudinaryService.FileUploadAsync(dto.Image);
                isexistEmployee.ImagePath = newImagePath;
            }
            _employeeRepository.Update(isexistEmployee);
            await _employeeRepository.SaveChangesAsync();
            return new("Update is successfully");
        }
    }
}
