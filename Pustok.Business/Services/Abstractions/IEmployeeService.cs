
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ResultDto> CreateAsync(EmployeeCreateDto dto);
        Task<ResultDto> UpdateAsync(EmployeeUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<EmployeeGetDto>> GetByIdAsync(Guid id);
        Task<ResultDto<List<EmployeeGetDto>>> GetAllAsync();
    }
}
