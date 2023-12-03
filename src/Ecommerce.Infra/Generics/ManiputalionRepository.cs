using NHibernate;
using Vault.Base.Entities;
using Vault.Base.Repositories;

namespace SGTC.Infra.Repositories
{
    public class ManipulationRepository : IManipulationRepository
    {
        private readonly ISession _session;
        public bool _log { get; set; } = true;
        public ManipulationRepository(ISession session)
        {
            _session = session;
        }

        public virtual T Insert<T>(T entity) where T : EntityBase
        {
            var id = (long)_session.Save(entity);
            entity.SetId(id);
            return entity;
        }
        public virtual T Update<T>(T entity) where T : EntityBase
        {
            _session.Update(entity);
            return entity;
        }

        public virtual void Delete<T>(T entity) where T : EntityBase
        {
            _session.Delete(entity);
        }
    }
}
