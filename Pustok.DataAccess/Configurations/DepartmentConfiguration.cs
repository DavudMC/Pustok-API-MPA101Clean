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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

            builder.HasMany(x=>x.Employees).WithOne(x => x.Department).HasForeignKey(x=>x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
