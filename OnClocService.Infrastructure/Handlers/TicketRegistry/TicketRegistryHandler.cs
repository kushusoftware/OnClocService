

using Microsoft.EntityFrameworkCore;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Domain.Interfaces.TicketRegistry;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.TicketRegistry;

internal class TicketRegistryHandler(OnClocDataStorageContext storageContext) : ITicketRegistryService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;

    public async Task<IEnumerable<ServiceTicket>> GetAllServiceTickets() =>  await _StorageContext.ServiceTickets.ToListAsync();
}
