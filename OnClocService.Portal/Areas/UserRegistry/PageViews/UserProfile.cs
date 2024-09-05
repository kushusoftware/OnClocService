#nullable disable

namespace OnClocService.Portal.Areas.UserRegistry.PageViews;

public class UserProfile
{
    public string FullNames { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string AvatorFileUrl { get; set; }
    public string RoleDescriptions { get; set; }
    public List<string> FunctionalRoles { get; set; }
}
