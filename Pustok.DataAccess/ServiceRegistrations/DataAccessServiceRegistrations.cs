using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DataAccess.Contexts;
using Pustok.DataAccess.Repositories.Abstractions;
using Pustok.DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistrations
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(_configuration.GetConnectionString("Default")));
            return services;
        }
    }
}
