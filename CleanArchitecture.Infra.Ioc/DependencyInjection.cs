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
using CleanArchitecture.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Domain.Account;

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

            // services from identity 
            service.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            // our services 
            service.AddScoped<IAuthenticate, AuthenticateService>();
            service.AddScoped <ISeedUserRoleInitial , SeedUserRoleInitial>();

            //cookie services redirect to account login 
            service.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            service.AddScoped<ICategoryRespository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddAutoMapper(typeof(DomainToDTOProfile));

            return service;

        }
    }
}
