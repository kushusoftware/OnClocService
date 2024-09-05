

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Validators.UserRegistry;

namespace OnClocService.Infrastructure.Extensions.Systems;

public static class ValidationCollections
{
    public static void AddOnClocFluentValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<LoginRequest>, LoginValidator>();
    }
}
