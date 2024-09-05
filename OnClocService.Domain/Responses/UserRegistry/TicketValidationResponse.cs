#nullable disable

using Microsoft.AspNetCore.Authentication;
using OnClocService.Domain.Responses.Systems;

namespace OnClocService.Domain.Responses.UserRegistry;

public class TicketValidationResponse : SystemsResponse
{
    public AuthenticationTicket AuthenticationTicket { get; set; }
    public bool AllowRefresh => AuthenticationTicket.Properties.AllowRefresh ?? false;
}