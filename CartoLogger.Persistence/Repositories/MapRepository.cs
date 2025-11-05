using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartoLogger.Persistence.Repositories;

public class MapRepository(CartoLoggerDbContext context)
    : Repository<Map>(context), IMapRepository
{

    public Task<List<Feature>> GetFeaturesById(int id) {
        return _context.Features.Where(f => f.MapId == id).ToListAsync();
    }

    public Task LoadFeatures(Map map)
    {
        return _context.Entry(map).Collection(u => u.Features).LoadAsync();
    }

}
