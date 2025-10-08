using System;
using Core.Domain;
using Core.Repositories;
using Core;
using System.Threading.Tasks;
using Core.Domain.Employees;
using Persistence.Persistence.Repositories.Employees;
using Core.Repositories.Employees;
using Core.Repositories.Documents;
using System.Reflection.Metadata;
using Persistence.Persistence.Repositories.Documents;

namespace Persistence.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgramacionOrientadaAObjetosContext _context;

        public UnitOfWork(ProgramacionOrientadaAObjetosContext context)
        {
            _context = context;
            Employees = new EmployeesRepository(_context);
            Teachers = new TeachersRepository(_context);
            Documents = new DocumentsRepository(_context);
        }

        #region Entities
        public IEmployeesRepository Employees { get; set; }
        public ITeachersRepository Teachers { get; set; }
        public IDocumentsRepository Documents { get; set; }

        #endregion

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}