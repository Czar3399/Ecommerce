using Ecommerce.Infra.Repositories.Products.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SGTC.Infra.Repositories;
using Vault.Base.Repositories;

namespace SGTC.Infra.Configurations
{
    public static class NhibernateConfiguration
    {
        private static ISessionFactory CreateSession<T>(IPersistenceConfigurer configurer) where T : class
        {
            return Fluently.Configure()
                .Database(configurer)
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                })
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }
        private static IPersistenceConfigurer PersistenceConfiguration(string connectionString)
        {
            return SQLiteConfiguration.Standard
                .ShowSql()
                .FormatSql()
                .UsingFile(connectionString);


        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            IPersistenceConfigurer persistenceConfiguration = PersistenceConfiguration(connectionString);
            services.AddSingleton(factory => CreateSession<ProductMap>(persistenceConfiguration));
            services.AddScoped(factory => factory.GetService<ISessionFactory>().OpenSession());

            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManipulationRepository, ManipulationRepository>();
            return services;
        }

    }
}

