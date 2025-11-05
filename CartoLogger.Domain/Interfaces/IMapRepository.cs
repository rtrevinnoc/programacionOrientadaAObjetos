using CartoLogger.Domain.Entities;

namespace CartoLogger.Domain.Interfaces;

public interface IMapRepository : IRepository<Map>
{
    public Task<List<Feature>> GetFeaturesById(int id);
    public Task LoadFeatures(Map map); 
}
