using AutoMapper;
using OneOf;
using Vault.Base.Repositories;
using Vault.Common.Functions.Interfaces;

namespace Vault.Common.Functions
{
    public abstract class FunctionBase<TResponse, TRequest> : IFunction<TResponse, TRequest> where TResponse : IOneOf
    {
        protected readonly IMapper _mapper;
        protected readonly IQueryRepository _queryRepository;

        public FunctionBase(IMapper mapper, IQueryRepository queryRepository)
        {
            _mapper = mapper;
            _queryRepository = queryRepository;
        }
        public abstract Task<TResponse> ExecuteAsync(TRequest request);
    }
}
