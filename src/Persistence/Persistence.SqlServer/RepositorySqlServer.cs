using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Persistence.SqlServer
{
    public abstract class RepositorySqlServer<TEntity, TKey> : IGeneralRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;


        protected RepositorySqlServer(ApplicationDbContext context)
        {
            Context = context;
        }


        public TEntity Create(TEntity t)
        {
            Context.Add(t);
            return t;
        }

        public void Update(TEntity t)
        {
            Context.Update(t);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Get(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Remove(TKey id)
        {
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = Context.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name ?? throw new InvalidOperationException("Incorrect Delete " + nameof(TEntity)));
            if (property == null) return;

            var entity = Activator.CreateInstance<TEntity>();
            property.SetValue(entity, id);
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
