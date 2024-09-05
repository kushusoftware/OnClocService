#nullable disable

namespace OnClocService.Core.Constants;

public class LogEvent
{
    public const int GenerateItems = 1010;
    public const int ListItems = 1011;
    public const int ReadRecord = 1020;
    public const int WriteRecord = 1030;
    public const int UpdateRecord = 1040;
    public const int ApproveRecord = 1041;
    public const int DisableRecord = 1042;
    public const int DeleteRecord = 1050;
    public const int AccessPage = 2010;
    public const int GetItemNotFound = 3001;
    public const int UpdateItemNotFound = 4001;
}

public enum ActivityStatus
{
    Info,
    Warning,
    Success,
    Error
}

public enum ChangeStatus
{
    Initialized,
    Partial,
    Completed,
    Failed
}

public class SysConstant
{
    public const string Prefix = "Permit";
    public const string Separator = ".";
}

public class SysRole
{
    public const string SuperAdmin = "SuperAdmin";
    public const string LogAuditor = "LogAuditor";
    public const string RemoteUser = "RemoteUser";
    public const string Operator = "Operator";
    public const string Manager = "Manager";
    public const string Supervisor = "Supervisor";
    public const string BasicUser = "BasicUser";
}

public class SysPolicy
{
    public const string Observer = "Observer";
    public const string Inputter = "Inputter";
    public const string Authorizer = "Authorizer";
    public const string Auditor = "Auditor";
    public const string Administrator = "Administrator";
}

public class SysPrivilege
{
    public const string AccessModule = "AccessModule";
    public const string AccessPage = "AccessPage";
    public const string ReadRecord = "ReadRecord";
    public const string WriteRecord = "WriteRecord";
    public const string UpdateRecord = "UpdateRecord";
    public const string ApproveRecord = "ApproveRecord";
    public const string DisableRecord = "DisableRecord";
    public const string DeleteRecord = "DeleteRecord";
}

public class SysModule
{
    public const string Dashboard = "Dashboard";
    public const string ProjectRegistry = "ProjectRegistry";
    public const string TicketRegistry = "TicketRegistry";
    public const string TaskRegistry = "TaskRegistry";
    public const string EquipmentRegistry = "EquipmentRegistry";
    public const string TechnicianRegistry = "TechnicianRegistry";
    public const string TravelRegistry = "TravelRegistry";
    public const string CustomerRegistry = "CustomerRegistry";
    public const string PaymentRegistry = "PaymentRegistry";
    public const string UserRegistry = "UserRegistry";
    public const string Systems = "Systems";
    public const string Identity = "Identity";
}
