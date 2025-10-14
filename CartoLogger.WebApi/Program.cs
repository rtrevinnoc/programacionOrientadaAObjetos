using CartoLogger.Persistence;
using Microsoft.EntityFrameworkCore;
using CartoLogger.Domain;


var builder = WebApplication.CreateBuilder(args);

// OpenApi webapi infomation and statistics
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

var connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<CartoLoggerDbContext>(options => {
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

var app = builder.Build();

// Configure development endpoints (Swagger)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "Weather Forecast")
    );
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
