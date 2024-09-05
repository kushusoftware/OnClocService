using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Core.Repositories;
using OnClocService.Domain.Helpers;
using OnClocService.Infrastructure.DataStorage;
using OnClocService.Infrastructure.DataStorage.ProjectRegistry;
using OnClocService.Infrastructure.DataStorage.Systems;
using OnClocService.Infrastructure.DataStorage.TicketRegistry;

namespace OnClocService.Infrastructure.Providers;

internal sealed class SystemsConfigurationProvider(string connectionString) : ConfigurationProvider
{
    public override async void Load()
    {
        string _InitializerUser = "systems@on-cloc.app";
        DateTime _InitializerDate = DateTime.UtcNow;
        // Build a Dictionary of the Current App LogSettings
        var settingsDictionary = new Dictionary<string, string?>();
        // Generate a Data Context & Seed the Database
        using var systemsDataContext = new OnClocDataStorageContext(CreateContextOptions(connectionString));
        if (systemsDataContext.Database.EnsureCreated())
        {
            Guid defaultBusinessId = Guid.NewGuid();
            // Add Default Roles
            await SeedDefaultUserRoles(systemsDataContext);
            /// Add Default Systems Modules
            await SeedDefaultSystemsModules(systemsDataContext);
            // Add Default Functional Roles
            await SeedDefaultFunctionalRoles(systemsDataContext);
            // Initialize the Database
            await SystemsDataInitializer.Initialize(systemsDataContext);
            await ProjectRegistryDataInitializer.Initialize(systemsDataContext);
            await TicketRegistryDataInitializer.Initialize(systemsDataContext);
            // Seed Default Systems App LogSettings
            await CreateAndSaveDefaultValues(systemsDataContext, _InitializerUser, _InitializerDate, defaultBusinessId);
            // Grant Module Role Permissions
            await GrantModuleRolePermissions(systemsDataContext, _InitializerUser, _InitializerDate);
            // Add Default Super Admin
            SystemsRole superAdminRole = GetRoleByOcsName(systemsDataContext, SysRole.SuperAdmin);
            await AddSuperAdminToRoleAsync(systemsDataContext, superAdminRole, defaultBusinessId);
            // Add Deafult Operator
            SystemsRole operatorRole = GetRoleByOcsName(systemsDataContext, SysRole.Operator);
            await AddOperatorToRoleAsync(systemsDataContext, operatorRole, defaultBusinessId);
        }
        else
        {
            // Retreive Default Systems LogSettings
            List<SystemsSettings> systemsSettings = [];
            systemsSettings = [.. systemsDataContext.SystemsSettings];
            if (systemsSettings.Count > 0)
            {
                foreach (var appSetting in systemsSettings)
                {
                    settingsDictionary.Add(appSetting.Id, appSetting.Value);
                }
            }
            // Retrieve Default Business LogSettings
        }
        Data = settingsDictionary;
    }

    /// <summary>
    /// seed the default systems modules of the application
    /// </summary>
    /// <param name="context">On-Cloc database context to use</param>
    /// <returns>number of records saved to the database</returns>
    private static async Task<int> SeedDefaultSystemsModules(OnClocDataStorageContext context)
    {
        var systemsModules = new SystemsModule[]
        {
            new()  { SystemsModuleID ="M0100", Index=1, Name= "Dashboard", IsDefaultModule=true, Title="Service Dashboard", Description="Service Performance Overview", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-monitor-dashboard" },
            new()  { SystemsModuleID ="M0200", Index=2, Name= "Tickets", AspArea="TicketRegistry", Title="Service Tickets", Description= "Manage Tickets, Inquiries, Feedback", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-ticket-account" },
            new()  { SystemsModuleID ="M0300", Index=3, Name= "Projects", AspArea="ProjectRegistry", Title="Project Registry", Description= "Manage Projects, Jobs, Technicians, Spare parts", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-toolbox" },
            new()  { SystemsModuleID ="M0400", Index=4, Name= "Tasks", AspArea="TaskRegistry", Title="Tasks", Description= "Manage Tasks, Task spares, Job Checklists,", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-wrench-clock" },
            new()  { SystemsModuleID ="M0500", Index=5, Name= "Equipment", AspArea="EquipmentRegistry", Title="Equipment", Description= "Manage Equipment, Spare Parts", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-cog" },
            new()  { SystemsModuleID ="M0600", Index=6, Name= "Technicians", AspArea="TechnicianRegistry", Title="Technicians", Description= "Manage Technicians, Certifications", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-account-hard-hat" },
            new()  { SystemsModuleID ="M0700", Index=7, Name= "Travel", AspArea="TravelRegistry", Title="Travel", Description= "Manage Travel Plans, Travel Costs", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-plane-train" },
            new()  { SystemsModuleID ="M0800", Index=8, Name= "Customers", AspArea="CustomerRegistry", Title="Customers", Description="Manage Customers, Customer Equipment", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-face-agent" },
            new()  { SystemsModuleID ="M0900", Index=9, Name= "Payments", AspArea="PaymentRegistry", Title="Payments", Description="Manage Sending and Receiving Payments", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-cash-multiple" },
            new()  { SystemsModuleID ="M1000", Index=10, Name= "Users", AspArea="UserRegistry", Title="User Registry", Description= "Manage Users, Access Privileges, SysPolicy", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-account-circle-outline" },
            new()  { SystemsModuleID ="M1100", Index=11, Name= "Systems", AspArea="Systems", Title="System Management", Description= "Manage System LogSettings, Company Info", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-server" },
            new()  { SystemsModuleID ="M1200", Index=12, Name= "Identity", AspArea="Identity", Title="User & Role Management", Description= "Manage User Authentication, System SysRoles", ModuleImageFile="on-cloc-icon.png", IconClass="mdi mdi-badge-account", ShowInMenu=false },
        };
        await context.SystemsModules.AddRangeAsync(systemsModules);
        return context.SaveChanges();
    }

    /// <summary>
    /// seed default user roles
    /// </summary>
    /// <param name="context">database context to use</param>
    /// <returns>number of records saved to the database</returns>
    private static async Task<int> SeedDefaultUserRoles(OnClocDataStorageContext context)
    {
        var systemsRoles = new SystemsRole[]
        {
            new(){ Name = SysRole.SuperAdmin, NormalizedName = SysRole.SuperAdmin.ToUpper(), RoleDescription = "Systems Administrators", IsSystemRole = true },
            new(){ Name = SysRole.LogAuditor, NormalizedName = SysRole.LogAuditor.ToUpper(), RoleDescription = "Performance Auditors", IsSystemRole = true },
            new(){ Name = SysRole.RemoteUser, NormalizedName = SysRole.RemoteUser.ToUpper(), RoleDescription = "Remote Access Users", IsSystemRole = true },
            new(){ Name = SysRole.Operator, NormalizedName = SysRole.Operator.ToUpper(), RoleDescription = "Systems Operators", IsSystemRole = false },
            new(){ Name = SysRole.Manager, NormalizedName = SysRole.Manager.ToUpper(), RoleDescription = "Business Managers", IsSystemRole = false },
            new(){ Name = SysRole.Supervisor, NormalizedName = SysRole.Supervisor.ToUpper(), RoleDescription = "Business Supervisors", IsSystemRole = false },
            new(){ Name = SysRole.BasicUser, NormalizedName = SysRole.BasicUser.ToUpper(), RoleDescription = "Basic Users", IsSystemRole = false }
        };
        await context.Roles.AddRangeAsync(systemsRoles);
        return context.SaveChanges();
    }

    /// <summary>
    /// seed default functional roles
    /// </summary>
    /// <param name="context">database context to use</param>
    /// <returns>number of records saved to the database</returns>
    private static async Task<int> SeedDefaultFunctionalRoles(OnClocDataStorageContext context)
    {
        var systemsFunctionalRoles = new SystemsFunctionalRole[]
        {
            new(){ FunctionalRoleId = Guid.NewGuid(), Name = "Administrator", Description = "Manage Records", CreatedBy = "systems@on-cloc.app", ModifiedBy = "systems@on-cloc.app" },
            new(){ FunctionalRoleId = Guid.NewGuid(), Name = "Auditor", Description = "Audit System", CreatedBy = "systems@on-cloc.app", ModifiedBy = "systems@on-cloc.app" },
            new(){ FunctionalRoleId = Guid.NewGuid(), Name = "Authorizer", Description = "Authorize Records", CreatedBy = "systems@on-cloc.app", ModifiedBy = "systems@on-cloc.app" },
            new(){ FunctionalRoleId = Guid.NewGuid(), Name = "Inputter", Description = "LoginRequest Records", CreatedBy = "systems@on-cloc.app", ModifiedBy = "systems@on-cloc.app" },
            new(){ FunctionalRoleId = Guid.NewGuid(), Name = "Observer", Description = "Observe Records", CreatedBy = "systems@on-cloc.app", ModifiedBy = "systems@on-cloc.app" }
        };
        await context.SystemsFunctionalRoles.AddRangeAsync(systemsFunctionalRoles);
        return context.SaveChanges();
    }

    /// <summary>
    /// create and save the default application configuration settings 
    /// </summary>
    /// <param name="context">database context to use</param>
    /// <returns>dictionary of application settings</returns>
    private static async Task<Dictionary<string, string?>> CreateAndSaveDefaultValues(OnClocDataStorageContext context, string initializerUser, DateTime initializerDate, Guid defaultBusinessId)
    {
        // Create Default City
        var cityId = Guid.NewGuid();
        var systemsCity = new SystemsCity()
        {
            SystemCityID = cityId,
            CityName = "Kampala",
            CityDescription = "Kampala City",
            SystemsCountryId = "UG"
        };
        await context.SystemsCities.AddAsync(systemsCity);
        context.SaveChanges();
        // Create Default Business Contact
        var contactDetailsId = Guid.NewGuid();
        var contactDetails = new SystemsContactDetail()
        { 
            SystemsContactDetailID = contactDetailsId,
            SystemsCountryId = "UG",
            SystemCityId = cityId,
            PhysicalAddress = "7 Spring Close",
            StreetName = "5th Street, Industrial Area",
            PostalCode = "P.O.Box 25349",
            EmailAddress = "info@engsol.co.ug",
            PrimaryPhone = "+256200301800",
            WebsiteUrl = "www.engsol.co.ug",
            IsPrimaryContact = true,
            CreatedBy = initializerUser,
            CreatedDate = initializerDate,
            ModifiedBy = initializerUser,
            ModifiedDate = initializerDate,
        };
        await context.SystemsContactDetails.AddAsync(contactDetails);
        context.SaveChanges();
        // Create Default Business
        var systemsBusiness = new SystemsBusinessProfile()
        {
            SystemsBusinessID = defaultBusinessId,
            SystemsContactDetailId = contactDetailsId,
            SystemsBusinessFullname = "Engineering Solutions (U) Ltd",
            SystemsBusinessShortname = "ServPal",
            SystemsBusinessLogoUrl = "img/layout/servpal-logo-black.png",
            InvoiceNumberPrefix = "ESL-INV",
            QuoteNumberPrefix = "ESL-QTN",
            CreatedBy = initializerUser,
            CreatedDate = initializerDate,
            ModifiedBy = initializerUser,
            ModifiedDate = initializerDate,
        };
        await context.SystemsBusinessProfiles.AddAsync(systemsBusiness);
        context.SaveChanges();
        // Create Deafult Business Currency
        var businessCurrency = new SystemsBusinessCurrency()
        {
            SystemsBusinessProfileId = defaultBusinessId,
            SystemsCurrencyId = "UGX",
            IsBaseCurrency = true,
        };
        await context.SystemsBusinessCurrencies.AddAsync(businessCurrency);
        context.SaveChanges();
        // Create Default Business License
        var systemsBusinessLicence = new SystemsBusinessLicense()
        {
            SystemsBusinessLicenseID = Guid.NewGuid(),
            SystemsBusinessProfileId = defaultBusinessId,
            LicenseName = "Evaluation License",
            LicenseStart = initializerDate,
            LicenseExpiry = initializerDate.AddDays(30),
            LicenseKey = string.Concat(["LIC", new Random(256).Next().ToString(), new Random(404801).Next().ToString()]),
            CreatedBy = initializerUser,
            CreatedDate = initializerDate,
            ModifiedBy = initializerUser,
            ModifiedDate = initializerDate,
        };
        await context.SystemsBusinessLicenses.AddAsync(systemsBusinessLicence);
        context.SaveChanges();
        // Create Default Configurations
        var systemSettings = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
        {
            ["Application:FullName"] = "On-Cloc Service",
            ["Application:ShortName"] = "ON-CLOC",
            ["Application:Slogan"] = "Service on the clock...",
            ["Application:Version"] = "version 2.1.0",
            ["Application:DefaultPageSize"] = "10",
            ["Application:IconUrl"] = "img/layout/oncloc-service-icon.png",
            ["Application:LogoUrl"] = "img/layout/oncloc-service-banner.png",
            ["Application:Copyright"] = "Kushu Software, WHITE-MARE TECHNOLOGY",
            ["Application:CopyrightUrl"] = "https://kushu-software.com/",
            ["Email:FromAddress"] = "no-reply@on-cloc.app",
            ["Email:FromName"] = "On-Cloc Service | No Reply",
            ["Email:Username"] = "775123001@smtp-brevo.com",
            ["Email:Password"] = "xUQANC8hmrg0VIkM",
            ["Email:Host"] = "smtp-relay.brevo.com",
            ["Email:Port"] = "587",
            ["Email:UseSsl"] = "true",
            ["Identity:RequireDigit"] = "true",
            ["Identity:RequireLowercase"] = "true",
            ["Identity:RequireNonAlphanumeric"] = "true",
            ["Identity:RequireUppercase"] = "true",
            ["Identity:RequiredLength"] = "6",
            ["Identity:RequiredUniqueChars"] = "1",
            ["Identity:DefaultLockoutTimeSpan"] = "5",
            ["Identity:MaxFailedAccessAttempts"] = "5",
            ["Identity:AllowedForNewUsers"] = "true",
            ["Identity:RequireConfirmedAccount"] = "true",
            ["Identity:RequireConfirmedPhoneNumber"] = "false",
            ["Identity:AllowedUserNameCharacters"] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+",
            ["Identity:RequireUniqueEmail"] = "true",
            ["Jwt:Issuer"] = "https://portal.on-cloc.wmt.lan",
            ["Jwt:Audience"] = "https://portal.on-cloc.wmt.lan",
            ["Jwt:DurationMinutes"] = "30",
            ["Jwt:Key"] = "a6800fdd0ddb9a8790606be90bbe7cb1d6cc30f201d92e20e9027ab847d7080f-7s7y2s4t4e0m1s8P@s$w0rd",
            ["Support:Phone"] = "(+256) 762 645751",
            ["Support:Email"] = "support@on-cloc.app",
            ["Support:LearnUrl"] = "https://learn.on-cloc.app/",
            ["Business:ID"] = defaultBusinessId.ToString(),
            ["Business:FullName"] = systemsBusiness.SystemsBusinessFullname,
            ["Business:ShortName"] = systemsBusiness.SystemsBusinessShortname,
            ["Business:LogoUrl"] = systemsBusiness.SystemsBusinessLogoUrl,
            ["License:Name"] = systemsBusinessLicence.LicenseName,
            ["License:Active"] = systemsBusinessLicence.LicenseStart.ToString(),
            ["License:Expiry"] = systemsBusinessLicence.LicenseExpiry.ToString(),
            ["License:Key"] = systemsBusinessLicence.LicenseKey
        };
        context.SystemsSettings.AddRange(
            [.. systemSettings.Select(static kvp => new SystemsSettings(kvp.Key, kvp.Value))]
        );
        await context.SaveChangesAsync();
        return systemSettings;
    }

    /// <summary>
    /// entroll the default business admin into the Business Admin role
    /// </summary>
    /// <param name="context">database context to use</param>
    /// <param name="role">role to enroll the user into</param>
    /// <returns>completed task</returns>
    private static async Task AddOperatorToRoleAsync(OnClocDataStorageContext context, SystemsRole role, Guid defaultBusinessId)
    {
        var operatorAdmin = new SystemsUser
        {
            Id = Guid.NewGuid(),
            SystemsBusinessProfileId = defaultBusinessId,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = "ops.admin@wmt.group",
            FirstName = "Admin",
            LastName = "Operator",
            Email = "ops.admin@wmt.group",
            PhoneNumber = "+256756440180",
            AvatorFileUrl = "img/profile/pictures/face11.jpg",
            NormalizedUserName = "OPS.ADMIN@WMT.GROUP",
            NormalizedEmail = "OPS.ADMIN@WMT.GROUP",
            IsBuiltInSystemsUser = false,
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        if (context.Users.All(u => u.Email != operatorAdmin.Email))
        {
            // Add Default Business Admin
            operatorAdmin.PasswordHash = GetHashedPassword(operatorAdmin, "123P@ssw0rd");
            await context.Users.AddAsync(operatorAdmin);
            if (context.SaveChanges() == 1)
            {
                // Add Default Business Admin to Role
                context.UserRoles.Add(new SystemsUserRole { RoleId = role.Id, UserId = operatorAdmin.Id });
                await context.SaveChangesAsync();
                // Add Super Admin to User UserClaims
                await GrantPageUserPermissions(context, operatorAdmin.Id);
            }
        }
    }

    /// <summary>
    /// entroll the default super admin into the Super Admin role
    /// </summary>
    /// <param name="context">database context to use</param>
    /// <param name="role">role to enroll the user into</param>
    /// <returns>completed task</returns>
    private static async Task AddSuperAdminToRoleAsync(OnClocDataStorageContext context, SystemsRole role, Guid defaultBusinessId)
    {
        var superAdmin = new SystemsUser
        {
            Id = Guid.NewGuid(),
            SystemsBusinessProfileId = defaultBusinessId,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = "sys.admin@wmt.group",
            FirstName = "Super",
            LastName = "Administrator",
            Email = "sys.admin@wmt.group",
            PhoneNumber = "+256756440180",
            AvatorFileUrl = "img/profile/pictures/face12.jpg",
            NormalizedUserName = "SYS.ADMIN@WMT.GROUP",
            NormalizedEmail = "SYS.ADMIN@WMT.GROUP",
            IsBuiltInSystemsUser = true,
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        if (context.Users.All(u => u.Email == superAdmin.Email))
        {
            // Add Default Super Admin
            superAdmin.PasswordHash = GetHashedPassword(superAdmin, "999P@ssw0rd");
            await context.Users.AddAsync(superAdmin);
            // Create New DB Context and Add User Role UserClaims
            if (context.SaveChanges() == 1)
            {
                // Add Super Admin to Role
                context.UserRoles.Add(new SystemsUserRole { RoleId = role.Id, UserId = superAdmin.Id });
                await context.SaveChangesAsync();
                // Add Super Admin to User UserClaims
                await GrantPageUserPermissions(context, superAdmin.Id);
            }
        }
    }

    private static async Task<int> GrantPageUserPermissions(OnClocDataStorageContext context, Guid userId)
    {
        // Get User from Context
        var user = await context.Users.FirstAsync(u => u.Id == userId);
        var allUserClaims = user.UserClaims;
        var allUserRoles = user.UserRoles;
        var pagePermission = SystemsPermissionHelper.GetPagePermission();

        List<SystemsUserClaim> userClaims = [];
        // Process All User Roles
        foreach (var role in allUserRoles)
        {
            string? roleName = role.Role.Name;
            if (roleName != null)
            {
                // Get All Policy Names for the Role
                var allPolicyNames = SystemsDataRepository.GetAllowedPoliciesForRole(roleName);
                foreach (var policyName in allPolicyNames)
                {
                    if (allUserClaims == null)
                    {
                        var userClaim = SystemsPermissionHelper.GeneratePermissionUserClaim(user.Id, policyName, pagePermission);
                        userClaims.Add(userClaim);
                    }
                    else
                    {
                        if (!allUserClaims.Any(uc => uc.UserId == userId && uc.ClaimType == policyName && uc.ClaimValue == pagePermission))
                        {
                            var userClaim = SystemsPermissionHelper.GeneratePermissionUserClaim(user.Id, policyName, pagePermission);
                            userClaims.Add(userClaim);
                        }
                    }
                }
            }
        }
        await context.UserClaims.AddRangeAsync(userClaims);
        return context.SaveChanges();
    }

    /// <summary>
    /// give a role full permissions to the listed modules
    /// </summary>
    /// <param name="context">database context to be used</param>
    /// <param name="role">systems role to assign permissions</param>
    /// <param name="allAllowedModules">list of all allowed modules</param>
    /// <returns>number of role permissions granted to role</returns>
    private static async Task<int> GrantModuleRolePermissions(OnClocDataStorageContext context, string initializerUser, DateTime initializerDate)
    {
        var policyName = SysPolicy.Observer;
        List<SystemsRoleClaim> roleClaims = [];
        List<SystemsRoleFunctionalRole> roleFunctionalRoles = [];
        // Get All Registered Roles
        var allRoles = context.Roles;
        foreach (var role in allRoles)
        {
            string? roleName = role.Name;
            if (roleName == null) continue;
            // Get All RoleClaims for the Role
            var allRoleClaims = role.RoleClaims;
            // Get All Allowed Modules for the Role
            var allowedModules = SystemsDataRepository.GetAllowedModulesForRole(roleName);
            foreach (string moduleName in allowedModules)
            {
                // Get Module Permission
                var modulePermission = SystemsPermissionHelper.GetModulePermission(moduleName);
                if (allRoleClaims == null)
                {
                    SystemsRoleClaim roleClaim = SystemsPermissionHelper.GeneratePermissionRoleClaim(role.Id, policyName, modulePermission);
                    roleClaims.Add(roleClaim);
                }
                else
                {
                    if (!allRoleClaims.Any(rc => rc.RoleId == role.Id && rc.ClaimType == policyName && rc.ClaimValue == modulePermission))
                    {
                        SystemsRoleClaim roleClaim = SystemsPermissionHelper.GeneratePermissionRoleClaim(role.Id, policyName, modulePermission);
                        roleClaims.Add(roleClaim);
                    }
                }
            }

            // Get All Functional Roles for the Role
            var allowedFunctionalRoleNames = SystemsDataRepository.GetAllowedPoliciesForRole(roleName);
            foreach (var functionalRoleName in allowedFunctionalRoleNames)
            {
                var funtionalRole = context.SystemsFunctionalRoles.AsNoTracking().Single(fr => fr.Name == functionalRoleName);
                SystemsRoleFunctionalRole roleFunctionalRole = new()
                {
                    RoleFunctionalRoleId = Guid.NewGuid(),
                    RoleId = role.Id,
                    FunctionalRoleId = funtionalRole.FunctionalRoleId,
                    CreatedBy = initializerUser,
                    CreatedDate = initializerDate,
                    ModifiedBy = initializerUser,
                    ModifiedDate = initializerDate,
                };
                roleFunctionalRoles.Add(roleFunctionalRole);
            }
        }
        await context.RoleClaims.AddRangeAsync(roleClaims);
        await context.SystemsRoleFunctionalRoles.AddRangeAsync(roleFunctionalRoles);
        return context.SaveChanges();
    }

    /// <summary>
    /// generate a hased user password
    /// </summary>
    /// <param name="user">user to create the password for</param>
    /// <param name="password">plain text password to be hashed</param>
    /// <returns></returns>
    private static string GetHashedPassword(SystemsUser user, string password)
    {
        return new PasswordHasher<SystemsUser>().HashPassword(user, password);
    }

    private static SystemsRole GetRoleByOcsName(OnClocDataStorageContext context, string roleName)
    {
        return context.Roles.First(r => r.Name == roleName);
    }

    /// <summary>
    /// create data context options from teh connection string
    /// </summary>
    /// <param name="connectionString">database connection string to use</param>
    /// <returns>database context options</returns>
    private static DbContextOptions<OnClocDataStorageContext> CreateContextOptions(string connectionString)
    {
        return new DbContextOptionsBuilder<OnClocDataStorageContext>()
            .UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            })
            .Options;
    }
}