using OneOf;
using System.Threading.Tasks;

namespace Vault.Common.Functions.Interfaces
{
    public interface IFunction<TResponse, TRequest> where TResponse : IOneOf
    {

        Task<TResponse> ExecuteAsync(TRequest request);

    }
}