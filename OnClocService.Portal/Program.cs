using OnClocService.Infrastructure.Extensions.Systems;
using OnClocService.Infrastructure.Extensions.TicketRegistry;
using OnClocService.Portal.Areas.Systems.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddInitialInfrastructure();

builder.AddBasicInfrastructure();

builder.AddOnClocJwtAuthentication();

builder.Services.AddInfrastructureServices();

builder.Services.AddPortalCookieConfiguration();

builder.Services.AddOnClocAuthenticationServices();

builder.Services.AddOnClocAuthorizationServices();

builder.Services.AddOnClocFluentValidators();

builder.Services.AddTaskRegistryServices();

builder.AddPortalPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.UseSecurityCredentials();

app.Run();
