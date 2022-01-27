




public static class DIApiExtensions
{
    public static IServiceCollection UseTransientAPI(this IServiceCollection services)
    {
        services.AddTransient<A_Transient>();
        return services;
    }
    public static IServiceCollection UseSingletonAPI(this IServiceCollection services)
    {
        services.AddSingleton<B_Singleton>();
        return services;
    }
    public static IServiceCollection UseScopedAPI(this IServiceCollection services)
    {
        services.AddScoped<C_Scoped>();
        return services;
    }

    public static WebApplication MapTransientApi(this WebApplication app)
    {
        app.MapGet("/Transient", (A_Transient A) =>
        {
            var r = A.Id;
            return Results.Ok(r);
        });
        return app;
    }

    public static WebApplication MapSingletonApi(this WebApplication app)
    {
        app.MapGet("/Singleton", (B_Singleton B) =>
        {
            var r = B.Id;
            return Results.Ok(r);
        });
        return app;
    }

    public static WebApplication MapScopedApi(this WebApplication app)
    {
        app.MapGet("/Scoped", (C_Scoped C) =>
        {
            var r = C.Id;
            return Results.Ok(r);
        });
        return app;
    }
}