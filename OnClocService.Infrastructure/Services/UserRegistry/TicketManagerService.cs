#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnClocService.Core.Entities.Systems;
using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.UserRegistry;

public class TicketManagerService(ITicketStore ticketManager)
{
    public async Task<AuthenticationTicket> RetrieveAsync(string ticketKey) => await ticketManager.RetrieveAsync(ticketKey);
    public async Task<string> StoreAsync(AuthenticationTicket authenticationTicket) => await ticketManager.StoreAsync(authenticationTicket);
    public async Task RenewAsync(string ticketKey, AuthenticationTicket authenticationTicket) => await ticketManager.RenewAsync(ticketKey, authenticationTicket);
    public async Task RemoveAsync(string ticketKey) => await ticketManager.RemoveAsync(ticketKey);
}
