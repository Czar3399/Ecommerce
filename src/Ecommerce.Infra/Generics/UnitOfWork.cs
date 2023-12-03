using NHibernate;
using Vault.Base.Repositories;

namespace SGTC.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        ///     Iniciar uma transação no banco de dados
        /// </summary>
        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        /// <summary>
        ///     Desfazer as alterações realizadas em uma transação
        /// </summary>
        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Rollback();
        }

        /// <summary>
        ///     Aplicar as alterações realizadas em uma transação
        /// </summary>
        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Commit();
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (session.IsOpen)
            {
                session.Close();
                session = null;
            }
        }
    }
}