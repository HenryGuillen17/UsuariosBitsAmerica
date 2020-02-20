using System.Data.SqlClient;
using Persistence.Interfaces.Repositories;
using Persistence.SqlServer;
using Persistence.SqlServer.Repositories;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        // Adapters Base de datos
        private readonly ApplicationDbContext _context;


        // Repositorios privados
        private UsuarioRepository _usuarioRepository;


        // Repositorios Públicos
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? (_usuarioRepository = new UsuarioRepository(_context));


        public UnitOfWorkSqlServerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
