using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos
{
    public class DepartmentGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<EmployeeGetDto> Employess { get; set; } = [];
    }
}
