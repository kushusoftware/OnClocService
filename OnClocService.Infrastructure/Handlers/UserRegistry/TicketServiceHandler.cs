#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnClocService.Core.Entities.Systems;
using OnClocService.Infrastructure.DataStorage;
using System.Security.Claims;
using UAParser;

namespace OnClocService.Infrastructure.Handlers.UserRegistry;

public class TicketServiceHandler(IServiceScopeFactory serviceScopeFactory) : ITicketStore
{
    private readonly IServiceScopeFactory _ServiceScopeFactory = serviceScopeFactory;

    public async Task RemoveAsync(string ticketKey)
    {
        using var scope = _ServiceScopeFactory.CreateAsyncScope();
        var _StorageContext = scope.ServiceProvider.GetService<OnClocDataStorageContext>();
        if (Guid.TryParse(ticketKey, out var id))
        {
            var ticket = await _StorageContext.SystemsAuthenticationTickets.SingleOrDefaultAsync(t => t.TicketID == id);
            if (ticket is not null)
            {
                _StorageContext.SystemsAuthenticationTickets.Remove(ticket);
                await _StorageContext.SaveChangesAsync();
            }
        }
    }

    public async Task RenewAsync(string ticketKey, AuthenticationTicket ticket)
    {
        using var scope = _ServiceScopeFactory.CreateAsyncScope();
        var _StorageContext = scope.ServiceProvider.GetService<OnClocDataStorageContext>();
        if (Guid.TryParse(ticketKey, out var id))
        {
            var authenticationTicket = await _StorageContext.SystemsAuthenticationTickets.FindAsync(id);
            if (authenticationTicket != null)
            {
                authenticationTicket.Value = SerializeToBytes(ticket);
                authenticationTicket.LastActivity = DateTimeOffset.UtcNow;
                authenticationTicket.Expires = ticket.Properties.ExpiresUtc;
                _StorageContext.SystemsAuthenticationTickets.Update(authenticationTicket);
                await _StorageContext.SaveChangesAsync();
            }
        }
    }

    public async Task<AuthenticationTicket> RetrieveAsync(string ticketKey)
    {
        using var scope = _ServiceScopeFactory.CreateAsyncScope();
        var _StorageContext = scope.ServiceProvider.GetService<OnClocDataStorageContext>();
        if (Guid.TryParse(ticketKey, out var id))
        {
            var authenticationTicket = await _StorageContext.SystemsAuthenticationTickets.FindAsync(id);
            if (authenticationTicket != null)
            {
                authenticationTicket.LastActivity = DateTimeOffset.UtcNow;
                await _StorageContext.SaveChangesAsync();

                return DeserializeFromBytes(authenticationTicket.Value);
            }
        }

        return null;
    }

    public async Task<string> StoreAsync(AuthenticationTicket ticket)
    {
        var userId = string.Empty;
        var ticketId = Guid.NewGuid();
        // Get user Details
        using var scope = _ServiceScopeFactory.CreateAsyncScope();
        var _StorageContext = scope.ServiceProvider.GetService<OnClocDataStorageContext>();
        if (ticket.AuthenticationScheme == JwtBearerDefaults.AuthenticationScheme)
        {
            var principal = ticket.Principal;
            userId = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        }
        // Clear Existing Tickets
        var existingTickets = await _StorageContext.SystemsAuthenticationTickets.Where(t => t.UserId == userId).ToListAsync();
        if (existingTickets.Count > 0) 
        {
            _StorageContext.SystemsAuthenticationTickets.RemoveRange(existingTickets);
            await _StorageContext.SaveChangesAsync();
        }
        // Create Authentication Ticket
        var systemsTicket = new SystemsAuthenticationTicket()
        {
            TicketID = ticketId,
            UserId = userId,
            LastActivity = DateTimeOffset.UtcNow,
            Value = SerializeToBytes(ticket)
        };
        // Add Ticket Expiry
        var expiresUtc = ticket.Properties.ExpiresUtc;
        if (expiresUtc.HasValue)
        {
            systemsTicket.Expires = expiresUtc.Value;
        }
        // Add Remote User Data
        var _HttpContextAccessor = scope.ServiceProvider.GetService<IHttpContextAccessor>();
        var httpContext = _HttpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            // Add Client Info
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress;
            if (remoteIpAddress != null) { systemsTicket.RemoteIpAddress = remoteIpAddress.ToString(); }

            var userAgent = httpContext.Request.Headers.UserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                var uaParser = await Parser.GetDefaultAsync();
                var osInfo = uaParser.ParseOS(userAgent);
                var deviceInfo = uaParser.ParseDevice(userAgent);
                var userAgentInfo = uaParser.ParseUserAgent(userAgent);
                systemsTicket.DeviceFamily = deviceInfo.Family;
                systemsTicket.DeviceModel = $"{deviceInfo.Brand}, {deviceInfo.Model}";
                systemsTicket.OperatingSystemFamily = osInfo.Family;
                systemsTicket.OperatingSystemVersion = $"{osInfo.Major}.{osInfo.Minor}.{osInfo.Patch}";
                systemsTicket.UserAgentFamily = userAgentInfo.Family;
                systemsTicket.UserAgentVersion = $"{userAgentInfo.Version}, {userAgentInfo.Major}.{userAgentInfo.Minor}.{userAgentInfo.Patch}";
            }
        }

        _StorageContext.SystemsAuthenticationTickets.Add(systemsTicket);
        await _StorageContext.SaveChangesAsync();
        return ticketId.ToString();
    }

    private static byte[] SerializeToBytes(AuthenticationTicket ticket) => TicketSerializer.Default.Serialize(ticket);

    private static AuthenticationTicket DeserializeFromBytes(byte[] source) => TicketSerializer.Default.Deserialize(source) ?? null!;
}
