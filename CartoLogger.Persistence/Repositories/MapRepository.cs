using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Persistence.Repositories;

public class MapRepository(CartoLoggerDbContext context)
    : Repository<Map>(context), IMapRepository
{
}
