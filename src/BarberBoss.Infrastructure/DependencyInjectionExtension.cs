using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Expenses;
using BarberBoss.Infrastructure.DataAccess;
using BarberBoss.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BarberBoss.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUniteOfWork, UniteOfWork>();
        services.AddScoped<IInvoicingReadOnlyRepository, InvoicingRepository>();
        services.AddScoped<IInvoicingWriteOnlyRepository, InvoicingRepository>();
        services.AddScoped<IInvoicingUpdateOnlyRepository, InvoicingRepository>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 35);
        var serverVersion = new MySqlServerVersion(new Version());

        services.AddDbContext<BarberBossDbContext>(config => config.UseMySql(connectionString, serverVersion));

    }
}
