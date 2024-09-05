using Microsoft.AspNetCore.Authorization;

namespace OnClocService.Core.Requirements
{
    public class SystemsPermissionRequirement(string policyName, string privilege) : IAuthorizationRequirement
    {
        public string PolicyName = policyName;
        public string UserPrivilege = privilege;
    }
}
