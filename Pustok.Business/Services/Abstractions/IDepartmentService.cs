using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResultDto> CreateAsync(DepartmentCreateDto dto);
        Task<ResultDto> UpdateAsync(DepartmentUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<DepartmentGetDto>> GetByIdAsync(Guid id);
        Task<ResultDto<List<DepartmentGetDto>>> GetAllAsync();
    }
}
