namespace SecretsManagement.Api.Configuration;
public class AppEmailSetting
{
    public string EmailFrom { get; set; } = default!;
    public string SmtpHost { get; set; } = default!;
    public string SmtpPort { get; set; } = default!;
    public string SmtpUser { get; set; } = default!;
    public string SmtpPass { get; set; } = default!;
}
