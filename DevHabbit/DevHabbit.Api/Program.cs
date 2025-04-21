
using DevHabbit.Api.Database;
using DevHabbit.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //options.ReturnHttpNotAcceptable = true;
    // enable Accept: Application/Xml in header of request!
})
    .AddNewtonsoftJson()
    .AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
        npgSqlOptions => npgSqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Application))
    .UseUpperSnakeCaseNamingConvention());

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName))
    .WithTracing(tracing => tracing.AddHttpClientInstrumentation().AddAspNetCoreInstrumentation().AddNpgsql())
    .WithMetrics(metrics =>
        metrics.AddHttpClientInstrumentation().AddAspNetCoreInstrumentation().AddRuntimeInstrumentation())
    .UseOtlpExporter();

builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeScopes = true;
    options.IncludeFormattedMessage = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigrationsAsync();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
