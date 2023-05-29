using Amazon;
using SecretsManagement.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
var env_region = Environment.GetEnvironmentVariable("Region");

var appName = builder.Environment.ApplicationName;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddSecretsManager(region: RegionEndpoint.GetBySystemName(env_region),
    configurator: options =>
    { 
        options.SecretFilter = entry => entry.Name.StartsWith($"{env}_BaseMicroservice_");
        options.KeyGenerator = (_, s) => s
            .Replace($"{env}_BaseMicroservice_", string.Empty)
            .Replace("__", ":");
        options.PollingInterval = TimeSpan.FromSeconds(10);
    });

builder.Services.Configure<Settings>(
    builder.Configuration.GetSection(Settings.SectionName));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

//using Amazon;
//using SecretsManagement.Api.Configuration;

//var builder = WebApplication.CreateBuilder(args);

//var env = builder.Environment.EnvironmentName;
//var appName = builder.Environment.ApplicationName;

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Configuration.AddSecretsManager(region: RegionEndpoint.USWest2,
//    configurator: options =>
//    {
//        options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}_");
//        options.KeyGenerator = (_, s) => s
//            .Replace($"{env}_{appName}_", string.Empty)
//            .Replace("__", ":");
//        options.PollingInterval = TimeSpan.FromSeconds(10);
//    });

//builder.Services.Configure<DatabaseSettings>(
//    builder.Configuration.GetSection(DatabaseSettings.SectionName));

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

//app.Run();
