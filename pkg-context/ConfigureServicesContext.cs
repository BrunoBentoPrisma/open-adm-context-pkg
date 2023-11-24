using pkg_context.Factories.Factories;
using pkg_context.Factories.Interfaces;

namespace pkg_context;

public static class ConfigureServicesContext
{
    public static IServiceCollection Inject(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IFactoryContext, Factory>();
        services.AddScoped<FactoryByClientKey>();
        services.AddScoped<FactoryByPath>();
        services.AddScoped<PartnerRepository>();
        services.AddScoped<IPartnerRepository, CachedPartner>();

        return services;
    }

    public static IServiceCollection InjectContext(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<OpenAdmContext>(opt => opt.UseNpgsql(stringConnection));

        return services;
    }
}
