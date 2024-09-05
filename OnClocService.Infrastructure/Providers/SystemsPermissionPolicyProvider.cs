using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using OnClocService.Core.Constants;
using OnClocService.Core.Repositories;
using OnClocService.Core.Requirements;

namespace OnClocService.Infrastructure.Providers;

internal class SystemsPermissionPolicyProvider(IOptions<AuthorizationOptions> authorizationOptions) : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider FallbackAuthorizationPolicyProvider = new(authorizationOptions);

    public async Task<AuthorizationPolicy?> GetPolicyAsync(string policy)
    {
        var permissionString = policy.Split(SysConstant.Separator);
        string policyName = permissionString[1];
        string privilege = permissionString[2];

        var allPolicies = SystemsDataRepository.GetAllPolicies();
        if (!allPolicies.Any(p => p.Equals(policyName, StringComparison.OrdinalIgnoreCase)))
        {
            return await FallbackAuthorizationPolicyProvider.GetPolicyAsync(policyName);
        }
        // List Policy Required Roles
        var requiredRoles = SystemsDataRepository.GetAllowedRolesForPolicy(policyName);
        // List Policy Permission Requirements
        List<SystemsPermissionRequirement> policyRequirements = GetPermissionRequirements(policyName, privilege);
        // Build New Policy
        var policyBuilder = new AuthorizationPolicyBuilder();
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.RequireRole(requiredRoles);
        policyBuilder.RequireClaim(policyName);
        foreach (var policyRequirement in policyRequirements)
        {
            policyBuilder.AddRequirements(policyRequirement);
        }
        return await Task.FromResult(policyBuilder.Build());
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        var policyBuilder = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
        policyBuilder.RequireAuthenticatedUser();
        return Task.FromResult(policyBuilder.Build());
    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => FallbackAuthorizationPolicyProvider.GetFallbackPolicyAsync();

    private static List<SystemsPermissionRequirement> GetPermissionRequirements(string policyName, string privilege)
    {
        List<SystemsPermissionRequirement> permissionRequirements = [];
        List<string> requiredPrivileges = [];
        requiredPrivileges.AddRange(SystemsDataRepository.GetAllowedPrivilegesForPolicy(SysPolicy.Observer));
        if (policyName != SysPolicy.Observer)
        {
            requiredPrivileges.AddRange(SystemsDataRepository.GetAllowedPrivilegesForPolicy(policyName));
        }
        foreach (var requiredPrivilege in requiredPrivileges)
        {
            if (requiredPrivilege == SysPrivilege.AccessPage || requiredPrivilege == SysPrivilege.ReadRecord || requiredPrivilege == privilege)
            {
                permissionRequirements.Add(new SystemsPermissionRequirement(policyName, requiredPrivilege));
            }
        }
        return permissionRequirements;
    }
}
