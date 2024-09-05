using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnClocService.Core.Constants;
using OnClocService.Core.Repositories;
using OnClocService.Core.Requirements;
using OnClocService.Infrastructure.Services.UserRegistry;

namespace OnClocService.Infrastructure.Handlers.UserRegistry;

public class AuthorizationServiceHandler(ILogger<AuthorizationServiceHandler> logger) : AuthorizationHandler<SystemsPermissionRequirement>
{
    private readonly ILogger<AuthorizationServiceHandler> _Logger = logger;
    private const string AUTH_KEY = nameof(AUTH_KEY);

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SystemsPermissionRequirement requirement)
    {
        var user = context.User;
        if (user != null)
        {
            string policyName = requirement.PolicyName;
            string privilege = requirement.UserPrivilege;
            // Check Permission Requirements
            if (!context.HasFailed)
            {
                _Logger.LogWarning("Evaluating authorization requirement for >= {privilege}", privilege);
                var claims = user.Claims.ToList();
                if (claims.Any(c => c.Type == policyName && c.Value.Contains(SysPrivilege.AccessPage, StringComparison.OrdinalIgnoreCase)))
                {
                    var allowedPrivileges = SystemsDataRepository.GetAllowedPrivilegesForPolicy(policyName);
                    if (allowedPrivileges.Any(p => p.Equals(privilege, StringComparison.OrdinalIgnoreCase)))
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            else
            {
                await Task.Yield();
            }
        }
        return;
    }
}
