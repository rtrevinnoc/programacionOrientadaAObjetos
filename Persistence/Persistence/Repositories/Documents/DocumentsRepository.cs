using System.Data.Entity;
using Core.Domain.Documents;
using Core.Repositories.Documents;

namespace Persistence.Persistence.Repositories.Documents;

public class DocumentsRepository : Repository<Document>, IDocumentsRepository
{
    public DocumentsRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}