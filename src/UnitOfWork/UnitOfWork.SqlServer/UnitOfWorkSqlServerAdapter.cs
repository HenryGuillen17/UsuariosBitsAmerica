using System.Data.SqlClient;
using Persistence.SqlServer;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private readonly ApplicationDbContext _context;
        private UnitOfWorkSqlServerRepository _repositories;


        public IUnitOfWorkRepository Repositories => _repositories ?? (_repositories = new UnitOfWorkSqlServerRepository(_context));


        public UnitOfWorkSqlServerAdapter(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            _context?.Dispose();

            _repositories = null;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
