/*
 * Design Time fatory used to instance a the app's subclassed DbContext
 * for EF Design time operations like migrations. Does not impact runtime spec
 * or configurations that are made for deployment
 * */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CartoLogger.Persistence;

public class CartoLoggerDbContextFactory : IDesignTimeDbContextFactory<CartoLoggerDbContext>
{
    private readonly string MySqlDevelopmentConnectionString =
        "server=localhost; database=CartoLoggerDev; user=CartoLoggerAdmin; password=admin";

    public CartoLoggerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CartoLoggerDbContext>();
        optionsBuilder.UseMySql(
            MySqlDevelopmentConnectionString,
            ServerVersion.AutoDetect(MySqlDevelopmentConnectionString)
        );
        return new CartoLoggerDbContext(optionsBuilder.Options);
    }
}
