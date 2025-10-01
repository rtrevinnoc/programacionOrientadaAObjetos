using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence;
using WebApi.Mapping;
using WebApi.Models.Configuration;
using WebApi.Models.Helpers.DateTimes;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddOData(options => { options.Count().Filter().OrderBy().Expand().Select().SetMaxTop(100); }
    )
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection String 
var dbConnection = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<ProgramacionOrientadaAObjetosContext>(options =>
{
    options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection));
});


// Cors Configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
    });
});

// builder.Services.AddCors();

// Mapping Services
builder.Services.AddAutoMapper(expression => expression.AddProfile(new MappingProfile()));

builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProgramacionOrientadaAObjetosContext>();
    db.Database.Migrate();
}

app.UseCors(
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
