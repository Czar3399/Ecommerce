using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OneOf;
using System;
using System.Threading.Tasks;
using Vault.Base.Repositories;

namespace Vault.Application.Users.Services
{
    public abstract class AppService<T> where T : AppService<T>
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ILogger<T> _logger;

        public AppService(IServiceProvider serviceProvider, ILogger<T> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task<TResponse?> ExecuteInTransaction<TResponse>(Func<IServiceScope, Task<TResponse>> action)
            where TResponse : class, IOneOf
        {
            using var scope = _serviceProvider.CreateScope();
            using var transaction = scope.ServiceProvider.GetRequiredService<ITransaction>();
            try
            {
                var response = await action(scope); // Execute your business logic within the transaction

                transaction.Commit();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred within the transaction.");
                transaction.Rollback();
                throw;
            }
        }

        public TService? GetService<TService>() where TService : class
        {
            return _serviceProvider.GetService<TService>();
        }
        public TService? GetService<TService>(IServiceScope scope) where TService : class
        {
            return scope.ServiceProvider.GetService<TService>();
        }
    }
}