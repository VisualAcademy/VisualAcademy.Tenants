using System.ComponentModel.DataAnnotations;

namespace VisualAcademy.Models; 
public class TenantModel {
    public long Id { get; set; }

    [Display(Name = "Name")]
    public string? Name { get; set; } = null!;

    [Display(Name = "Connection String")]
    public string? ConnectionString { get; set; }

    [Display(Name = "Authentication Header")]
    public string? AuthenticationHeader { get; set; }

    [Display(Name = "Account ID")]
    public string? AccountID { get; set; }

    [Display(Name = "Global Search Connection String")]
    public string? GSConnectionString { get; set; }

    [Display(Name = "Report Writer URL")]
    public string? ReportWriterURL { get; set; }

    [Display(Name = "Badge Photo Type")]
    public string? BadgePhotoType { get; set; }

    [Display(Name = "Portal Name")]
    public string? PortalName { get; set; }
}
