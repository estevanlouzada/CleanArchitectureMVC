using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraInstructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(OptionsServiceCollectionExtensions =>
            OptionsServiceCollectionExtensions.UseSqlServer(configuration
            .GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            service.AddScoped<ICategoryRespository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();


            return service;

        }
    }
}
