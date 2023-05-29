namespace SecretsManagement.Api.Configuration;

public class AppDataBaseSetting
{
    public string DefaultServer { get; set; } = default!;
    public string DefaultPort { get; set; } = default!;
    public string DefaultDatabase { get; set; } = default!;
    public string DefaultDatabaseUser { get; set; } = default!;
    public string DefaultDatabasePass { get; set; } = default!;
    public string DefaultAppSchema { get; set; } = default!;
    public string DefaultmicroserviceSchema { get; set; } = default!;
}
