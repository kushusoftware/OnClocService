#nullable disable

using System.ComponentModel.DataAnnotations;

namespace OnClocService.Domain.DataModels.Systems;

public class EmailRecepients
{
    [EmailAddress]
    public required string To { get; set; }

    [EmailAddress]
    public string Cc { get; set; }

    [EmailAddress]
    public string Bcc { get; set; }
}
