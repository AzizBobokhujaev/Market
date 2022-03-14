﻿using System;
using System.Runtime.CompilerServices;
using System.Text;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Replication;
using Repository;
using Service;

namespace Market.Extensions
{
    public static class ServiceRegistrations
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => options.AddPolicy("Policy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())); 
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration) => 
        //services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultSqlServer"))); //.UseLazyLoadingProxies()
        services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultPostgres"))); //.UseLazyLoadingProxies()

   
    
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILoggerManager,LoggerManager>();
        }

        /// <summary>
        /// Configure Identity service 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            //services.AddIdentityCore<IdentityRole<int>>().AddEntityFrameworkStores<DataContext>();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;

            });
        }
    
         public static void ConfigureRouting(this IServiceCollection services) =>
            services.AddRouting(x=>x.LowercaseUrls = true);
         
         public static void ConfigureLoggerService(this IServiceCollection services) =>
             services.AddScoped<ILoggerManager, LoggerManager>();

         public static void ConfigureAuthentication(this IServiceCollection services,IConfiguration configuration)
         {
             services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = configuration["JWT:ValidAudience"],
                     ValidIssuer = configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                 };
             });
         }

         

    }
}