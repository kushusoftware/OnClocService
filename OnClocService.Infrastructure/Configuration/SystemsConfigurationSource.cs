using Microsoft.Extensions.Configuration;
using OnClocService.Infrastructure.Providers;

namespace OnClocService.Infrastructure.Configuration;

internal sealed class SystemsConfigurationSource(string connectionString) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder configBuilder) => new SystemsConfigurationProvider(connectionString);
}
