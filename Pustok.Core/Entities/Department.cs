using Pustok.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = [];
    }
}
