#nullable disable

namespace OnClocService.Domain.DataModels.Systems;

public class ModulePage
{
    public string FileName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}

public class ModulePageLinks
{
    public string ModuleName { get; set; }
    public IDictionary<string, ModulePage> ModulePages { get; set; } = new Dictionary<string, ModulePage>();
}

public class ActionMessage
{
    public string Message { get; set; }
    public string InnerMessage { get; set; }
}

public class ModuleTheme
{
    public required string ModuleShortName { get; set; }
    public string ModuleImgUrl { get; set; }
    public required string ModuleMainClass { get; set; }
    public bool IsParentMenuItem { get; set; }
    public bool IsVisibleMenuItem { get; set; }
}

public class PredictedPageIdentifier
{
    public int Index { get; set; }
    public string Id { get; set; }
}

public class PredictedSubModuleIdentifier
{
    public int Index { get; set; }
    public string Id { get; set; }
}
