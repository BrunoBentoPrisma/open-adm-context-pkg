namespace pkg_context;

public static class ConfigureServicesContext
{
    public static IServiceCollection Inject(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IFactory, Factory>();
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
