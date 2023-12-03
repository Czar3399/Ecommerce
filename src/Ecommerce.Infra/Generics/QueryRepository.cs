using NHibernate;
using System.Linq.Expressions;
using Vault.Base.Entities;
using Vault.Base.Repositories;

namespace SGTC.Infra.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ISession _session;

        public QueryRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Query<T>() where T : EntityBase
        {
            return _session.Query<T>();
        }

        public T Get<T>(long? id) where T : EntityBase
        {
            return Query<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Get<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return Query<T>().FirstOrDefault(expression);
        }

        public T GetReference<T>(long? id) where T : EntityBase
        {
            if (!id.HasValue) throw new Exception("Não existe id neste caralho");
            bool exist = Query<T>().Where(x => x.Id == id).Select(x => x.Id).Any();
            if (!exist) throw new Exception("Não existe este caralho");
            var entity = (T)Activator.CreateInstance(typeof(T), true);
            entity.SetId(id.Value);
            return entity;
        }

        public T GetReference<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            long? id = Query<T>().Where(expression).Select(x => x.Id).FirstOrDefault();
            if (id == null) throw new Exception(typeof(T).Name);
            var entity = (T)Activator.CreateInstance(typeof(T), true);
            entity.SetId(id.Value);
            return entity;
        }
    }
}
