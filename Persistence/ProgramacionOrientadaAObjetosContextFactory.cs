using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Persistence;
namespace Persistence
{
    public class ProgramacionOrientadaAObjetosContextFactory : IDesignTimeDbContextFactory<ProgramacionOrientadaAObjetosContext>
    {
        private const string ConnectionStringDevelopmentMySql =
            "server=localhost; database=ProgramacionOrientadaAObjetos; user=root; password=Drongo123";

        public ProgramacionOrientadaAObjetosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProgramacionOrientadaAObjetosContext>();
            optionsBuilder.UseMySql(ConnectionStringDevelopmentMySql,
                ServerVersion.AutoDetect(ConnectionStringDevelopmentMySql));
            return new ProgramacionOrientadaAObjetosContext(optionsBuilder.Options);
        }
    }
}