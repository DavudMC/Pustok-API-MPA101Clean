using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos
{
    public class EmployeeUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public decimal Salary { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
