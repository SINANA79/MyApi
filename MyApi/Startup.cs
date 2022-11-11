using Autofac.Core;
using AutoMapper;
using Common;
using ElmahCore.Mvc;
using Entities.Post;
using MyApi.Models;
using WebFramework.Configuration;
using WebFramework.CustomMapping;
using WebFramework.Middlewares;

public class Startup
{
    public IConfiguration Configuration { get; }

    private readonly SiteSettings _siteSetting;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;




        _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
    }
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        AutoMapperConfiguration.InitializeAutoMapper();

        services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

        services.AddDbContext(Configuration);

        services.AddCustomIdentity(_siteSetting.IdentitySettings);

        services.AddController();

        services.AddAuthorization();

        services.AddCustomApiVersioning();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddElmah(Configuration, _siteSetting);
        services.AddJwtAuthentication(_siteSetting.JwtSettings);
        return services.BuildAutofacServiceProvider();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCustomExceptionHandler();
        // Configure the HTTP request pipeline.
        app.UseHsts(env);

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseElmah();
        app.UseHttpsRedirection();
    }
}

