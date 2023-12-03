using System;
using System.Linq;
using System.Linq.Expressions;
using Vault.Base.Entities;

namespace Vault.Base.Repositories
{
    public interface IQueryRepository
    {
        T Get<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        T Get<T>(long? id) where T : EntityBase;
        T GetReference<T>(long? id) where T : EntityBase;
        T GetReference<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
        IQueryable<T> Query<T>() where T : EntityBase;
    }
}