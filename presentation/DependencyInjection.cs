using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces;
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
            
            // Removed legacy service registrations (UserService, ProductGroupService, ProductCategoryService, ProductService)
            return services;
        }
    }
} 