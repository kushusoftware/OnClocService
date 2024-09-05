

using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Domain.Interfaces.TicketRegistry;

namespace OnClocService.Infrastructure.Services.TicketRegistry;

public class TicketRegistryService(ITicketRegistryService ticketRegistry)
{
    public async Task<IEnumerable<ServiceTicket>> GetServiceTickets() => await ticketRegistry.GetAllServiceTickets();
}
