using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Salary).HasPrecision(10,2).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(1024);

            builder.ToTable(x => x.HasCheckConstraint("CK_Employee_Salary", "[Salary]>0"));
        }
    }
}
