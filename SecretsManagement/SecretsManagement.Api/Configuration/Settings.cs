namespace SecretsManagement.Api.Configuration;

public class Settings
{
    public const string SectionName = "Settings";
    public AppDataBaseSetting AppDataBaseSetting { get; set; } = default!;
    public AppEmailSetting AppEmailSetting { get; set; } = default!;
}