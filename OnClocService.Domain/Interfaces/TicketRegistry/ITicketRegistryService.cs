

using OnClocService.Core.Entities.TicketRegistry;

namespace OnClocService.Domain.Interfaces.TicketRegistry;

public interface ITicketRegistryService
{
    Task<IEnumerable<ServiceTicket>> GetAllServiceTickets();

}
