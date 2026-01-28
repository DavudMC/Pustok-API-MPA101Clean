
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto dto);
        Task UpdateAsync(EmployeeUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<EmployeeGetDto?> GetByIdAsync(Guid id);
        Task<List<EmployeeGetDto>> GetAllAsync();
    }
}
