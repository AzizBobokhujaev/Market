using Contracts.Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<DataContext>(builder => builder.UseSqlite(configuration.GetConnectionString("Default"))); //.UseLazyLoadingProxies()

   
    
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
    
    public static void ConfigureRouting(this IServiceCollection services) =>
        services.AddRouting(x=>x.LowercaseUrls = true);
    
    }
}