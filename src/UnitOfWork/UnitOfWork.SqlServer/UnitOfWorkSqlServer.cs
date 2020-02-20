using Microsoft.Extensions.Configuration;
using Persistence.SqlServer;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UnitOfWorkSqlServer(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkSqlServerAdapter(_context);
        }
    }
}
