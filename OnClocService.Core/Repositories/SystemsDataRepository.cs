using OnClocService.Core.Constants;

namespace OnClocService.Core.Repositories;

public static class SystemsDataRepository
{
    public static List<string> GetAllowedModulesForRole(string roleName) => roleName switch
    {
        SysRole.SuperAdmin => [
            SysModule.Dashboard,
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.EquipmentRegistry,
            SysModule.TechnicianRegistry,
            SysModule.TravelRegistry,
            SysModule.CustomerRegistry,
            SysModule.PaymentRegistry,
            SysModule.UserRegistry,
            SysModule.Systems,
            SysModule.Identity
            ],
        SysRole.LogAuditor => [
            SysModule.Dashboard,
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.EquipmentRegistry,
            SysModule.TechnicianRegistry,
            SysModule.TravelRegistry,
            SysModule.CustomerRegistry,
            SysModule.PaymentRegistry,
            SysModule.UserRegistry,
            SysModule.Systems,
            SysModule.Identity
            ],
        SysRole.RemoteUser => [
            SysModule.Dashboard,
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.EquipmentRegistry,
            SysModule.TravelRegistry,
            SysModule.PaymentRegistry
            ],
        SysRole.Operator => [
            SysModule.Dashboard,
            SysModule.EquipmentRegistry,
            SysModule.TechnicianRegistry,
            SysModule.CustomerRegistry,
            SysModule.UserRegistry
            ],
        SysRole.Manager => [
            SysModule.Dashboard,
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.EquipmentRegistry,
            SysModule.TechnicianRegistry,
            SysModule.TravelRegistry,
            SysModule.CustomerRegistry,
            SysModule.PaymentRegistry
            ],
        SysRole.Supervisor => [
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.TravelRegistry,
            SysModule.PaymentRegistry
            ],
        SysRole.BasicUser => [
            SysModule.ProjectRegistry,
            SysModule.TicketRegistry,
            SysModule.TaskRegistry,
            SysModule.TravelRegistry,
            SysModule.PaymentRegistry
            ],
        _ => []
    };

    public static List<string> GetAllowedPoliciesForRole(string roleName) => roleName switch
    {
        SysRole.SuperAdmin => [
            SysPolicy.Observer,
            SysPolicy.Administrator
        ],
        SysRole.LogAuditor => [
            SysPolicy.Observer,
            SysPolicy.Auditor
        ],
        SysRole.RemoteUser => [
            SysPolicy.Observer,
            SysPolicy.Inputter
        ],
        SysRole.Operator => [
            SysPolicy.Observer,
            SysPolicy.Administrator
        ],
        SysRole.Manager => [
            SysPolicy.Observer,
            SysPolicy.Inputter,
            SysPolicy.Authorizer
        ],
        SysRole.Supervisor => [
            SysPolicy.Observer,
            SysPolicy.Authorizer
        ],
        SysRole.BasicUser => [
            SysPolicy.Observer,
            SysPolicy.Inputter
        ],
        _ => []
    };

    public static List<string> GetAllowedPrivilegesForPolicy(string policyName)
    {
        List<string> allowedPrivileges = [];
        allowedPrivileges.AddRange(GetPrivilegesForPolicy(SysPolicy.Observer));
        if (policyName != SysPolicy.Observer)
        {
            allowedPrivileges.AddRange(GetPrivilegesForPolicy(policyName));
        }
        return allowedPrivileges;
    }

    private static string[] GetPrivilegesForPolicy(string policyName) => policyName switch
    {
        SysPolicy.Administrator => [
             SysPrivilege.WriteRecord,
             SysPrivilege.UpdateRecord,
             SysPrivilege.DeleteRecord
            ],
        SysPolicy.Auditor => [
             SysPrivilege.DisableRecord,
             SysPrivilege.DeleteRecord
            ],
        SysPolicy.Authorizer => [
            SysPrivilege.ApproveRecord,
            SysPrivilege.DisableRecord
            ],
        SysPolicy.Inputter => [
            SysPrivilege.WriteRecord,
            SysPrivilege.UpdateRecord
            ],
        SysPolicy.Observer => [
            SysPrivilege.AccessPage,
            SysPrivilege.ReadRecord
            ],
        _ => []
    };

    public static List<string> GetAllowedRolesForPolicy(string policyName) => policyName switch
    {
        SysPolicy.Observer => [
                SysRole.BasicUser,
                SysRole.Supervisor,
                SysRole.Manager,
                SysRole.Operator,
                SysRole.RemoteUser,
                SysRole.LogAuditor,
                SysRole.SuperAdmin
            ],
        SysPolicy.Inputter => [
                SysRole.BasicUser,
                SysRole.Manager,
                SysRole.RemoteUser
            ],
        SysPolicy.Authorizer => [
                SysRole.Supervisor,
                SysRole.Manager
            ],
        SysPolicy.Auditor => [
                SysRole.LogAuditor
            ],
        SysPolicy.Administrator => [
                SysRole.Operator,
                SysRole.SuperAdmin
            ],
        _ => []
    };

    public static List<string> GetAllPolicies()
    {
        return [
            SysPolicy.Observer,
            SysPolicy.Inputter,
            SysPolicy.Authorizer,
            SysPolicy.Auditor,
            SysPolicy.Administrator
            ];
    }

    public static List<string> GetAllPrivileges()
    {
        return [
            SysPrivilege.AccessModule,
            SysPrivilege.AccessPage,
            SysPrivilege.ReadRecord,
            SysPrivilege.WriteRecord,
            SysPrivilege.UpdateRecord,
            SysPrivilege.ApproveRecord,
            SysPrivilege.DisableRecord,
            SysPrivilege.DeleteRecord
            ];
    }
}
