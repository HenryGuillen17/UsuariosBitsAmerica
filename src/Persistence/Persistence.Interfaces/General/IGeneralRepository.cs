using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Interfaces.General
{
    public interface IGeneralRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Create(TEntity t);
        void Update(TEntity t);
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey id);
        void Remove(TKey id);
    }

}
