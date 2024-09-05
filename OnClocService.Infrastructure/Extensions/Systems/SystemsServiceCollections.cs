using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Domain.Interfaces.UserRegistry;
using OnClocService.Infrastructure.Configuration;
using OnClocService.Infrastructure.DataStorage;
using OnClocService.Infrastructure.Extensions.Systems;
using OnClocService.Infrastructure.Handlers.Systems;
using OnClocService.Infrastructure.Handlers.UserRegistry;
using OnClocService.Infrastructure.Providers;
using OnClocService.Infrastructure.Services.Systems;
using OnClocService.Infrastructure.Services.UserRegistry;
using System.Reflection;
using System.Text;

namespace OnClocService.Infrastructure.Extensions.Systems;

public static class SystemsServiceCollections
{
    private const string DefaultConnection = nameof(DefaultConnection);
    private const string DevEnvironmentConnection = nameof(DevEnvironmentConnection);

    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(SystemsServiceCollections)));


        services.AddScoped<IApplicationOptionsService, ApplicationOptionsHandler>();
        services.AddScoped<ApplicationOptionsService>();

        services.AddScoped<IBusinessOptionsService, BusinessOptionsHandler>();
        services.AddScoped<BusinessOptionsService>();

        services.AddScoped<IEmailOptionsService, EmailOptionsHandler>();
        services.AddScoped<EmailOptionsService>();

        services.AddScoped<ILicenseOptionsService, LicenseOptionsHandler>();
        services.AddScoped<LicenseOptionsService>();

        services.AddScoped<ISupportOptionsService, SupportOptionsHandler>();
        services.AddScoped<SupportOptionsService>();

        services.AddScoped<IPageManagerService, PageServiceHandler>();
        services.AddScoped<PageManagerService>();

        services.AddScoped<IEmailManagerService, EmailServiceHandler>();
        services.AddScoped<EmailManagerService>();
    }

    public static void AddOnClocAuthenticationServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IUserContextService, UserServiceHandler>();
        services.AddScoped<UserContextService>();

        services.AddScoped<ITokenManagerService, TokenServiceHandler>();
        services.AddScoped<TokenManagerService>();

        services.AddScoped<IAuthenticationManagerService, AuthenticationServiceHandler>();
        services.AddScoped<AuthenticationManagerService>();

        services.AddSingleton<ITicketStore, TicketServiceHandler>();
        services.AddSingleton<TicketManagerService>();
        services.AddOptions<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme)
            .Configure<ITicketStore>((options, store) =>
            {
                options.SessionStore = store;
            });
    }

    public static void AddOnClocAuthorizationServices(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build());

        services.AddScoped<IAuthorizationHandler, AuthorizationServiceHandler>();

        services.AddSingleton<IAuthorizationPolicyProvider, SystemsPermissionPolicyProvider>();

        services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareHandler>();
    }

    public static void AddOnClocJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IJwtOptionsService, JwtOptionsHandler>();
        builder.Services.AddScoped<JwtOptionsService>();

        var jwtOptionsSection = builder.Configuration.GetSection("Jwt");
        var jwtOptions = jwtOptionsSection.Get<SystemsJwtOptions>();
        if (jwtOptions != null)
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtkey = Encoding.Default.GetBytes(jwtOptions.Key);
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtkey),
                        ClockSkew = TimeSpan.Zero
                    };
                });

        builder.Services.AddIdentity<SystemsUser, SystemsRole>()
            .AddRoles<SystemsRole>()
            .AddEntityFrameworkStores<OnClocDataStorageContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.Name = "OnClocService.Session";
            options.IOTimeout = TimeSpan.FromMinutes(1);
            options.IdleTimeout = TimeSpan.FromMinutes(5);
        });

        builder.Services.AddControllers();
    }

    public static void AddPortalCookieConfiguration(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.LogoutPath = "/Identity/Account/Logout";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        });
    }

    public static void AddBasicInfrastructure(this WebApplicationBuilder builder)
    {
        var connectionStringName = DefaultConnection;
        if (builder.Environment.IsDevelopment())
        {
            connectionStringName = DevEnvironmentConnection;
        }
        ConfigurationManager configurationManager = builder.Configuration;

        // Add Database Connection
        var connectionStrg = configurationManager.GetConnectionString(connectionStringName) ??
            throw new InvalidOperationException("connection string is invalid", new Exception("check the settings or string name"));

        // Add Database Context
        IServiceCollection services = builder.Services;
        services.AddDbContext<OnClocDataStorageContext>(options => options.UseSqlServer(connectionStrg,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("OnClocService.Portal");
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            }).EnableSensitiveDataLogging());

        // Systems Settings
        services.Configure<SystemsApplicationOptions>(configurationManager.GetSection("Application"));

        services.Configure<SystemsBusinessOptions>(configurationManager.GetSection("Business"));

        services.Configure<SystemsEmailOptions>(configurationManager.GetSection("Email"));

        services.Configure<SystemsIdentityOptions>(configurationManager.GetSection("Identity"));

        services.Configure<SystemsJwtOptions>(configurationManager.GetSection("Jwt"));

        services.Configure<SystemsLicenseOptions>(configurationManager.GetSection("License"));

        services.Configure<SystemsSupportOptions>(configurationManager.GetSection("Support"));

        // Identity Options
        var identityOptionsSection = configurationManager.GetSection("Identity");
        var identityOptions = identityOptionsSection.Get<SystemsIdentityOptions>();
        if (identityOptions != null)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Default User Settings
                options.SignIn.RequireConfirmedAccount = bool.Parse(identityOptions.RequireConfirmedAccount);
                options.User.RequireUniqueEmail = bool.Parse(identityOptions.RequireUniqueEmail);
                options.User.AllowedUserNameCharacters = identityOptions.AllowedUserNameCharacters;
                // Default Password settings
                options.Password.RequireDigit = bool.Parse(identityOptions.RequireDigit);
                options.Password.RequireUppercase = bool.Parse(identityOptions.RequireUppercase);
                options.Password.RequireLowercase = bool.Parse(identityOptions.RequireLowercase);
                options.Password.RequireNonAlphanumeric = bool.Parse(identityOptions.RequireNonAlphanumeric);
                options.Password.RequiredLength = int.Parse(identityOptions.RequiredLength);
                options.Password.RequiredUniqueChars = int.Parse(identityOptions.RequiredUniqueChars);
                // Default Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(int.Parse(identityOptions.DefaultLockoutTimeSpan));
                options.Lockout.MaxFailedAccessAttempts = int.Parse(identityOptions.MaxFailedAccessAttempts);
                options.Lockout.AllowedForNewUsers = bool.Parse(identityOptions.AllowedForNewUsers);
            });
        }
    }

    /// <summary>
    /// initialize the project database
    /// </summary>
    /// <param name="Configuration Manager"></param>
    public static void AddInitialInfrastructure(this WebApplicationBuilder builder)
    {
        var connectionStringName = DefaultConnection;
        if (builder.Environment.IsDevelopment())
        {
            connectionStringName = DevEnvironmentConnection;
        }
        ConfigurationManager configurationManager = builder.Configuration;
        IConfigurationBuilder configurationBuilder = configurationManager;
        var connectionStrg = configurationManager.GetConnectionString(connectionStringName) ??
            throw new InvalidOperationException("connection string is invalid", new Exception("check the settings or string name"));
        if (connectionStrg != null) configurationBuilder.Add(new SystemsConfigurationSource(connectionStrg));
    }
}
