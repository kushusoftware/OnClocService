#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.UserRegistry;

public class SystemsUserDevice
{
    [Display(Name = "User Device ID"), Key]
    public Guid SystemsUserDeviceID { get; set; }
    public Guid SystemsUserId { get; set; }

    // Properties
    public string CPUArchitecture { get; set; }
    public string DeviceModel { get; set; }
    public string DeviceType { get; set; }
    public string DeviceVendor { get; set; }
    public string EngineName { get; set; }
    public string EngineVersion { get; set; }
    public string OperatingSystemName { get; set; }
    public string OperatingSystemVersion { get; set; }
    public string UA { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsUserId))] 
    public SystemsUser SystemsUser { get; set; }

    // Navigation
    public ICollection<SystemsUserDeviceLogin> SystemsUserDeviceLogins { get; set; }
}

public class SystemsUserDeviceLogin
{
    [Display(Name = "User Device Login ID"), Key]
    public Guid SystemsUserDeviceLoginID { get; set; }
    public Guid SystemsUserDeviceId { get; set; }

    // Properties
    public DateTime LoginTime { get; set; }
    public DateTime LogoutTime { get; set; }
    public double Duration { get; set; }
    public string TimeZone { get; set; }
    public string PublicIP { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string BrowserUniqueID { get; set; }
    public string BrowserMajor { get; set; }
    public string BrowserName { get; set; }
    public string BrowserVersion { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsUserDeviceId))] 
    public SystemsUserDevice SystemsUserDevice { get; set; }

}
