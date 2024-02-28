using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WMS_DbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SQLServer")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IPalletTypeRepository, PalletTypeRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPalletStatusRepository, PalletStatusRepository>();
            services.AddScoped<IPalletRepository, PalletRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<ICartonRepository, CartonRepository>();


            return services;
        }
    }
}