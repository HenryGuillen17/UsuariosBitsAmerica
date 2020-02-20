
using Persistence.Interfaces.Repositories;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        // Incluir Repositorios
        IUsuarioRepository UsuarioRepository { get; }

    }
}
