using Microsoft.AspNetCore.Authorization;
using OnClocService.Core.Constants;

namespace OnClocService.Core.Attributes;

public class SystemsAuthorizeAttribute(string policyName, string privilege) : AuthorizeAttribute(
    string.Concat([SysConstant.Prefix, SysConstant.Separator, policyName, SysConstant.Separator, privilege])) 
{ }
