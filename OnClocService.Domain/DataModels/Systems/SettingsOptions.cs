#nullable disable

namespace OnClocService.Domain.DataModels.Systems;

public sealed class SystemsLicenseOptions
{
    public string Name { get; set; }

    public string Active { get; set; }

    public string Expiry { get; set; }

    public string Key { get; set; }
}

public sealed class SystemsBusinessOptions
{
    public string ID { get; set; }

    public string FullName { get; set; }

    public string ShortName { get; set; }

    public string LogoUrl { get; set; }
}

public sealed class SystemsApplicationOptions
{
    public required string FullName { get; set; }

    public required string ShortName { get; set; }

    public required string Slogan { get; set; }

    public required string Version { get; set; }

    public required string DefaultPageSize { get; set; }

    public required string IconUrl { get; set; }

    public required string LogoUrl { get; set; }

    public required string Copyright { get; set; }

    public required string CopyrightUrl { get; set; }
}

public sealed class SystemsSupportOptions
{
    public required string Phone { get; set; }

    public required string Email { get; set; }

    public required string LearnUrl { get; set; }
}

public sealed class SystemsEmailOptions
{
    public required string FromAddress { get; set; }

    public required string FromName { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public required string Host { get; set; }

    public required string Port { get; set; }

    public required string UseSsl { get; set; }
}

public sealed class SystemsJwtOptions
{
    public required string Key { get; set; }

    public required string Issuer { get; set; }

    public required string Audience { get; set; }

    public required string DurationMinutes { get; set; }
}

public sealed class SystemsIdentityOptions
{
    public required string RequireDigit { get; set; }

    public required string RequireLowercase { get; set; }

    public required string RequireNonAlphanumeric { get; set; }

    public required string RequireUppercase { get; set; }

    public required string RequiredLength { get; set; }

    public required string RequiredUniqueChars { get; set; }

    public required string DefaultLockoutTimeSpan { get; set; }

    public required string MaxFailedAccessAttempts { get; set; }

    public required string AllowedForNewUsers { get; set; }

    public required string RequireConfirmedAccount { get; set; }

    public required string RequireConfirmedPhoneNumber { get; set; }

    public required string AllowedUserNameCharacters { get; set; }

    public required string RequireUniqueEmail { get; set; }
}
