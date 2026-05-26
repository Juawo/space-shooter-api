using System.ComponentModel.DataAnnotations;

namespace SpaceShooterApi.Models;

public class GameVersion
{
    [Key]
    public  Guid Id { get; set; }
    [Required]
    [StringLength(20)]
    public required string CurrentVersion  { get; set; }
    [Required]
    [StringLength(500)] 
    public required string DownloadUrl { get; set; }
    public bool IsMandatory { get; set; } = false;
    public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;

    public GameVersion()
    {
        
    }
    public GameVersion(string currentVersion, string downloadUrl, bool isMandatory)
    {
        CurrentVersion = currentVersion;
        DownloadUrl = downloadUrl;
        IsMandatory = isMandatory;
    }
}