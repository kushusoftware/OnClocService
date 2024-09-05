using OnClocService.Core.Entities.TicketRegistry;

namespace OnClocService.Infrastructure.DataStorage.TicketRegistry;

internal static class TicketRegistryDataInitializer
{
    internal static async Task Initialize(OnClocDataStorageContext _StorageContext)
    {
        // Default Service Ticket Category
        var serviceTicketCategories = new ServiceTicketCategory[]
        {
            new() { CategoryName ="Service Booking", CategoryDescription ="Schedule Specific Services", ColourCode ="#F2F2F2" },
            new() { CategoryName ="End-User Support", CategoryDescription ="Require Technical Assistance", ColourCode ="#FFF2CC" },
            new() { CategoryName ="Business Inquiry", CategoryDescription ="Request Business Information", ColourCode ="#BFE4FF" },
            new() { CategoryName ="Technical Visit", CategoryDescription ="Require Site Visit or Review", ColourCode ="#FFCCCC" },
            new() { CategoryName ="Training Support", CategoryDescription ="Require Technical Training", ColourCode ="#BBFFDA" }
        };
        await _StorageContext.ServiceTicketCategories.AddRangeAsync(serviceTicketCategories);
        _StorageContext.SaveChanges();
        // Default Service Ticket Priority Level
        var serviceTicketPriorities = new ServiceTicketPriorityLevel[]
        {
            new() { PriorityLevel ="High", ColourCode ="#FF6666", EscalationTime =TimeSpan.FromHours(1), AllowEscalation =true, PriorityIndex =5, IsDefault =false },
            new() { PriorityLevel ="Normal", ColourCode ="#FFD966", EscalationTime =TimeSpan.FromHours(3), AllowEscalation =true, PriorityIndex =3, IsDefault =true },
            new() { PriorityLevel ="Low", ColourCode ="#BFBFBF", EscalationTime =TimeSpan.FromHours(6), AllowEscalation =false, PriorityIndex =1, IsDefault =false },
        };
        await _StorageContext.ServiceTicketPriorityLevels.AddRangeAsync(serviceTicketPriorities);
        _StorageContext.SaveChanges();
        // Default Service Ticket Status
        var serviceTicketStatus = new ServiceTicketStatus[]
        {
            new() { Status ="Open", ColourCode ="#FF0000" },
            new() { Status ="Assigned", ColourCode ="#00B0F0" },
            new() { Status ="In Progress", ColourCode ="#FFC000" },
            new() { Status ="Pending 3rd Party Action", ColourCode ="#7030A0" },
            new() { Status ="Pending Client Response", ColourCode ="#E2CFF1" },
            new() { Status ="Closed", ColourCode ="#BBFFDA" },
        };
        await _StorageContext.ServiceTicketStatuses.AddRangeAsync(serviceTicketStatus);
        _StorageContext.SaveChanges();
    }
}
