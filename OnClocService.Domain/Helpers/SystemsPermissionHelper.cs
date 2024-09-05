using OnClocService.Core.Constants;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.DataModels.Systems;
using System.Security.Claims;

namespace OnClocService.Domain.Helpers;

public static class SystemsPermissionHelper
{
    public static PermissionSignature GetPermissionSignature(Claim claim)
    {
        return GetPermissionSignature(claim.Type, claim.Value);
    }

    public static PermissionSignature GetPermissionSignatureFromUserClaim(SystemsUserClaim userClaim)
    {
        var claimType = string.Empty;
        var claimValue = string.Empty;
        if (userClaim.ClaimType != null && userClaim.ClaimValue != null)
        {
            claimType = userClaim.ClaimType;
            claimValue = userClaim.ClaimValue;
        }
        return GetPermissionSignature(claimType, claimValue);
    }

    public static PermissionSignature GetPermissionSignatureFromRoleClaim(SystemsRoleClaim roleClaim)
    {
        var claimType = string.Empty;
        var claimValue = string.Empty;
        if (roleClaim.ClaimType != null && roleClaim.ClaimValue != null)
        {
            claimType = roleClaim.ClaimType;
            claimValue = roleClaim.ClaimValue;
        }
        return GetPermissionSignature(claimType, claimValue);
    }

    private static PermissionSignature GetPermissionSignature(string claimType, string claimValue)
    {
        string[] signatureText = claimValue.Split(SysConstant.Separator);
        string module = signatureText[1];
        string page = string.Empty;
        if (signatureText.Length > 2)
        {
            page = signatureText[2];
        }
        PermissionSignature signature = new()
        {
            Policy = claimType,
            Module = module,
            Page = page,
        };
        return signature;
    }

    public static SystemsUserClaim GeneratePermissionUserClaim(Guid userId, string policyName,  string pagePermission)
    {
        return new SystemsUserClaim { ClaimType = policyName, ClaimValue = pagePermission, UserId = userId };
    }

    public static string GetPagePermission()
    {
        string resourceSection = SysPrivilege.AccessPage;
        return string.Concat(
            [
                SysConstant.Prefix,
                resourceSection
            ]);
    }

    public static SystemsRoleClaim GeneratePermissionRoleClaim(Guid roleId, string policyName, string modulePermission)
    {
        return new SystemsRoleClaim { ClaimType = policyName, ClaimValue = modulePermission, RoleId = roleId };
    }

    public static string GetModulePermission(string moduleName)
    {
        string resourceSection = Get1stResourceSubSection(moduleName);
        return string.Concat(
            [
                SysConstant.Prefix,
                resourceSection
            ]);
    }

    public static string GetResourceSection(string firstResource, string secondResource)
    {
        return string.Concat(Get1stResourceSubSection(firstResource), Get2ndResourceSubSection(secondResource));
    }

    private static string Get2ndResourceSubSection(string secondResource)
    {
        return string.Concat(SysConstant.Separator, secondResource);
    }

    private static string Get1stResourceSubSection(string firstResoure)
    {
        return string.Concat(SysConstant.Separator, firstResoure);
    }
}
