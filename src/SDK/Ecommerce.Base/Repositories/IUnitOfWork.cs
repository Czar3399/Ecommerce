using System;
using System.Threading.Tasks;

namespace Vault.Base.Repositories
{

    /// <summary>
    /// Unidade de trabalho que é responsável por coordenar transações de objetos em seus respectivos repositórios
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Rollback();

        void Commit();

        void BeginTransaction();
    }
}
