using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using MediatR;
using System.Reflection;

namespace ProductApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            // Register legacy services (for backward compatibility)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            
            return services;
        }
    }
} 