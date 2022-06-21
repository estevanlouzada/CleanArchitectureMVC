using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;


namespace CleanArchitecture.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraInstructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(OptionsServiceCollectionExtensions =>
            OptionsServiceCollectionExtensions.UseSqlServer(configuration
            .GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // adding mediator handler by dependecy injection 
            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchitecture.Application");
            service.AddMediatR(myhandlers);

            service.AddScoped<ICategoryRespository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddAutoMapper(typeof(DomainToDTOProfile));

            return service;

        }
    }
}
