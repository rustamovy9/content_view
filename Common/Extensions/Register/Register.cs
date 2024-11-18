using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Common.DataAccess;
using WebAPI.Common.FileService;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Common.Validation;

namespace WebAPI.Common.Extensions.Register;

public static class Register
{
    public static void RegisterDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BaseDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));
        
        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));

        builder.Services.AddDbContext<AppQueryDbContext>(x =>
        {
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine);
        });
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    { 
        services.AddScoped(typeof(IGenericAddRepository<>), typeof(GenericAddRepository<>));
        services.AddScoped(typeof(IGenericUpdateRepository<>), typeof(GenericUpdateRepository<>));
        services.AddScoped(typeof(IGenericDeleteRepository<>), typeof(GenericDeleteRepository<>));
        services.AddScoped(typeof(IGenericFindRepository<>), typeof(GenericFindRepository<>));

        services.AddSingleton<IFileService, FileService.FileService>();
        
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        return services;
    }
    
}