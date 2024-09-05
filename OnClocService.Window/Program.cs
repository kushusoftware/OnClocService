using OnClocService.Infrastructure.Extensions.Systems;
using OnClocService.Window.Extensions.Systems;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddBasicInfrastructure();

builder.Services.AddOnClocAuthenticationServices();

builder.Services.AddOnClocAuthorizationServices();

builder.AddOnClocJwtAuthentication();

builder.AddWindowPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.UseSecurityCredentials();

app.Run();
