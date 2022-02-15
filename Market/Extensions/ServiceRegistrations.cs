using System;
using System.Runtime.CompilerServices;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;

namespace Market.Extensions
{
    public static class ServiceRegistrations
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => options.AddPolicy("Policy", builder =>
                builder.WithOrigins("https://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod())); 
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DataContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Default"))); //.UseLazyLoadingProxies()

   
    
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoggerManager,LoggerManager>();
        }

        //
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>().AddEntityFrameworkStores<DataContext>();
            //services.AddIdentityCore<Role>().AddEntityFrameworkStores<DataContext>();
        }
    
         public static void ConfigureRouting(this IServiceCollection services) =>
            services.AddRouting(x=>x.LowercaseUrls = true);
         
         public static void ConfigureLoggerService(this IServiceCollection services) =>
             services.AddScoped<ILoggerManager, LoggerManager>();

         
         
    }
}