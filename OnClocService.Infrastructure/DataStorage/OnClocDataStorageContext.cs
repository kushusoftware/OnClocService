using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnClocService.Core.Entities.CustomerRegistry;
using OnClocService.Core.Entities.EquipmentRegistry;
using OnClocService.Core.Entities.PaymentRegistry;
using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.TaskRegistry;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.Entities.TravelRegistry;
using OnClocService.Core.Entities.UserRegistry;

namespace OnClocService.Infrastructure.DataStorage;

public class OnClocDataStorageContext(DbContextOptions<OnClocDataStorageContext> options) : IdentityDbContext<SystemsUser, SystemsRole, Guid, SystemsUserClaim, SystemsUserRole, SystemsUserLogin, SystemsRoleClaim, SystemsUserToken>(options)
{
    // System Settings
    public DbSet<SystemsSettings> SystemsSettings => Set<SystemsSettings>();
    // Logging
    public DbSet<SystemsActivityLog> SystemsActivityLogs { get; set; }
    public DbSet<SystemsAuditEvent> SystemsAuditEvents { get; set; }
    public DbSet<SystemsChangeLog> SystemsChangeLogs { get; set; }
    // Module Pages
    public DbSet<SystemsPage> SystemsPages { get; set; }
    public DbSet<SystemsModule> SystemsModules { get; set; }
    // Countries
    public DbSet<SystemsCountry> SystemsCountries { get; set; }
    public DbSet<SystemsCountryPhoneCode> SystemsCountryPhoneCodes { get; set; }
    public DbSet<SystemsCity> SystemsCities { get; set; }
    // Currencies
    public DbSet<SystemsCurrency> SystemsCurrencies { get; set; }
    public DbSet<SystemsBusinessCurrency> SystemsBusinessCurrencies { get; set; }
    // Businesses
    public DbSet<SystemsBusinessProfile> SystemsBusinessProfiles { get; set; }
    public DbSet<SystemsBusinessLicense> SystemsBusinessLicenses { get; set; }
    // Contact Details
    public DbSet<SystemsContactDetail> SystemsContactDetails { get; set; }
     // User Authentication
    public DbSet<SystemsRefreshToken> SystemsRefreshTokens { get; set; }
    public DbSet<SystemsAuthenticationTicket> SystemsAuthenticationTickets { get; set; }
    // User Notification
    public DbSet<SystemsNotification> SystemsNotifications { get; set; }
    public DbSet<SystemsNotificationType> SystemsNotificationTypes { get; set; }
    public DbSet<SystemsUserNotification> SystemsUserNotifications { get; set; }
    // Customer Registry
    public DbSet<CustomerFeedbackQuestion> CustomerFeedbackQuestions { get; set; }
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    public DbSet<CustomerServiceRating> CustomerServiceRatings {  get; set; } 
    public DbSet<CustomerServiceTicket> CustomerServiceTickets { get; set; }
    // Equipment Registry
    public DbSet<CustomerEquipment> CustomerEquipment { get; set; }
    public DbSet<EquipmentBrand> EquipmentBrands { get; set; }
    public DbSet<EquipmentManufacturer> EquipmentManufacturers { get; set; }
    public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
    public DbSet<EquipmentCategoryGroup> EquipmentCategoryGroups { get; set; }
    public DbSet<EquipmentFamily> EquipmentFamilies { get; set; }
    public DbSet<EquipmentFamilyCategory> EquipmentFamilyCategories { get; set; }
    public DbSet<EquipmentGroup> EquipmentGroups { get; set; }
    public DbSet<StockProduct> StockProducts { get; set; }
    public DbSet<StockWarehouse> StockWarehouses { get; set; }
    // Payment Registry
    public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
    public DbSet<CustomerInvoiceTaxation> CustomerInvoiceTaxations { get; set; }
    public DbSet<CustomerPayment> CustomerPayments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<TaxationType> TaxationTypes { get; set; }
    // Project Registry
    public DbSet<JobCard> JobCards { get; set; }
    public DbSet<JobCardAllocation> JobCardsAllocations { get; set; }
    public DbSet<JobCardCategory> JobCardCategories { get; set; }
    public DbSet<JobCardCategoryClass> JobCardCategoryClasses { get; set; }
    public DbSet<JobCardClass> JobCardClasses { get; set; }
    public DbSet<JobCardClassGroup> JobCardClassGroups { get; set; }
    public DbSet<JobCardGenre> JobCardGenres { get; set; }
    public DbSet<JobCardGroup> JobCardGroups { get; set; }
    public DbSet<JobCardGroupGenre> JobCardGroupGenres { get; set; }
    public DbSet<JobCardPriorityLevel> JobCardPriorityLevels { get; set; }
    public DbSet<JobCardStatus> JobCardStatuses { get; set; }
    public DbSet<JobCardType> JobCardTypes { get; set; }
    public DbSet<JobCardTypeCategory> JobCardTypeCategories { get; set; }
    public DbSet<ServiceProject> ServiceProjects { get; set; }
    // Task Registry
    public DbSet<JobCardChecklist> JobCardChecklists { get; set; }
    public DbSet<JobCardChecklistTask> JobCardChecklistTasks { get; set; }
    public DbSet<JobCardChecklistTemplate> JobCardChecklistTemplates { get; set; }
    public DbSet<JobCardChecklistTemplateTask> JobCardChecklistTemplateTasks { get; set; }
    public DbSet<JobTask> JobTasks { get; set; }
    public DbSet<JobTaskStep> JobTaskSteps { get; set; }
    // Technician Registry
    public DbSet<ServiceDesk> ServiceDesks { get; set; }
    public DbSet<ServiceDeskProjectAllocation> ServiceDeskProjectAllocations { get; set; }
    public DbSet<ServiceDeskMember> ServiceDeskMembers { get; set; }
    public DbSet<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public DbSet<ServiceOfficerProfile> ServiceOfficerProfiles { get; set; }
    public DbSet<ServiceOfficerDesignation> ServiceOfficerDesignations { get; set; }
    // Ticket Registry
    public DbSet<ServiceTicket> ServiceTickets { get; set; }
    public DbSet<ServiceTicketAttachment> ServiceTicketAttachments { get; set; }
    public DbSet<ServiceTicketAllocation> ServiceTicketAllocations { get; set; }
    public DbSet<ServiceTicketCategory> ServiceTicketCategories { get; set; }
    public DbSet<ServiceTicketPriorityLevel> ServiceTicketPriorityLevels { get; set; }
    public DbSet<ServiceTicketStatus> ServiceTicketStatuses { get; set; }
    public DbSet<ServiceTicketTask> ServiceTicketTasks { get; set; }
    public DbSet<ServiceTicketTaskStep> ServiceTicketTaskSteps { get; set; }
    // Travel Registry
    public DbSet<JobTimeCard> JobTimeCards { get; set; }
    public DbSet<TravelEvent> TravelEvents { get; set; }
    public DbSet<TravelItenerary> TravelIteneraries { get; set; }
    public DbSet<TravelPlan> TravelPlans { get; set; }
    public DbSet<TravelPlanBooking> TravelPlanBookings { get; set; }
    // User Registry
    public DbSet<SystemsUserDevice> SystemsUserDevices { get; set; }
    public DbSet<SystemsUserDeviceLogin> SystemsUserDeviceLogins { get; set; }
    public DbSet<SystemsFunctionalRole> SystemsFunctionalRoles { get; set; }
    public DbSet<SystemsRoleFunctionalRole> SystemsRoleFunctionalRoles { get; set; }
    // Database Overides
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SystemsUser>(e =>
        {
            e.HasMany(u => u.UserClaims)
            .WithOne(u => u.User)
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();

            e.HasMany(u => u.Logins)
            .WithOne(u => u.User)
            .HasForeignKey(ul => ul.UserId)
            .IsRequired();

            e.HasMany(u => u.Tokens)
            .WithOne(u => u.User)
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();

            e.HasMany(u => u.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

            e.HasMany(u => u.SystemsUserDevices)
            .WithOne(u => u.SystemsUser)
            .HasForeignKey(ud => ud.SystemsUserDeviceID)
            .IsRequired();

            e.HasMany(u => u.SystemsActivityLogs)
            .WithOne(u => u.SystemsUser)
            .HasForeignKey(ua => ua.SystemsActivityLogID)
            .IsRequired();

            e.ToTable("SystemsUsers");
        });
        modelBuilder.Entity<SystemsRole>(e =>
        {
            e.HasMany(r => r.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

            e.HasMany(r => r.RoleClaims)
            .WithOne(r => r.Role)
            .HasForeignKey(rc => rc.RoleId)
            .IsRequired();

            e.ToTable("SystemsRoles");
        });
        modelBuilder.Entity<SystemsUserRole>(e =>
        {
            e.ToTable("SystemsUserRoles");
        });
        modelBuilder.Entity<SystemsUserClaim>(e =>
        {
            e.ToTable("SystemsUserClaims");
        });
        modelBuilder.Entity<SystemsRoleClaim>(e =>
        {
            e.ToTable("SystemsRoleClaims");
        });
        modelBuilder.Entity<SystemsUserLogin>(e =>
        {
            e.ToTable("SystemsUserLogins");
        });
        modelBuilder.Entity<SystemsUserToken>(e =>
        {
            e.ToTable("SystemsUserTokens");
        });
    }

}
