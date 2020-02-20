using Models.Dao;
using Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Persistence.SqlServer.Repositories
{
    public class UsuarioRepository : RepositorySqlServer<Usuario, int>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
