using System.Linq.Expressions;
using Vault.Base.Entities;

namespace Vault.Base.Repositories
{
    public interface IManipulationRepository
    {
        T Insert<T>(T entity) where T : EntityBase;
        T Update<T>(T entity) where T : EntityBase;
        void Delete<T>(T entity) where T : EntityBase;
    }
}
