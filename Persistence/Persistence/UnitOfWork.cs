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
using Persistence.Persistence.Repositories.Schedules;
using Core.Repositories.Schedules;
using Core.Repositories.Courses;
using Persistence.Persistence.Repositories.Courses;
using Core.Repositories.Classrooms;
using Persistence.Persistence.Repositories.Classrooms;
using Core.Repositories.Llaves;
using Persistence.Persistence.Repositories.Llaves;

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
            Schedules = new SchedulesRepository(_context);
            Courses = new CoursesRepository(_context);
            Classrooms = new ClassroomsRepository(_context);
            Llaves = new LlavesRepository(_context);
            Managers = new ManagersRepository(_context);
        }

        #region Entities
        public IEmployeesRepository Employees { get; set; }
        public ITeachersRepository Teachers { get; set; }
        public IDocumentsRepository Documents { get; set; }
        public ISchedulesRepository Schedules { get; set; }
        public ICoursesRepository Courses { get; set; }
        public IClassroomsRepository Classrooms { get; set; }
        public ILlavesRepository Llaves { get; set; }
        public IManagersRepository Managers { get; set; }

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