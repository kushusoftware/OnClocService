
using Microsoft.Extensions.DependencyInjection;
using OnClocService.Domain.Interfaces.TicketRegistry;
using OnClocService.Infrastructure.Handlers.TicketRegistry;
using OnClocService.Infrastructure.Services.TicketRegistry;

namespace OnClocService.Infrastructure.Extensions.TicketRegistry;

public static class TicketRegistryServiceCollections
{
    public static void AddTaskRegistryServices(this IServiceCollection services)
    {
        services.AddScoped<ITicketRegistryService, TicketRegistryHandler>();
        services.AddScoped<TicketRegistryService>();
    }
}
