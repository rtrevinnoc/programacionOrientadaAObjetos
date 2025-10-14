using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Persistence.Repositories;

public class FeatureRepository(CartoLoggerDbContext context)
    : Repository<Feature>(context), IFeatureRepository
{
}
