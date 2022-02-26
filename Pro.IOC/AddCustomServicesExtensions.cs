using Pro.DataAccess.UnitOfWork;
using Pro.Services.Api;
using Pro.Services.Api.Contract;
using Pro.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Pro.DataAccess;
using Pro.Services;
using Pro.Services.Service;

namespace Pro.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
           services.AddScoped<IApplicationOwnerManager, ApplicationOwnerManager>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IjwtService, jwtService>();
            return services;
        }
    }
}
