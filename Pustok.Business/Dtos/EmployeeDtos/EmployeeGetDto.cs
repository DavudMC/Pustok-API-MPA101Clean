using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos
{
    public class EmployeeGetDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
    }
}
