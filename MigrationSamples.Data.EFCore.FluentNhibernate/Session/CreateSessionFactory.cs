using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MigrationSamples.Data.EFCore.FluentNhibernate.Session
{
    public static class CreateSessionFactory
    {
        private static ISessionFactory _factory;

        static CreateSessionFactory()
        {
            _factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(""))
                .Cache(c =>
                {
                    c.UseQueryCache()
                    .UseSecondLevelCache()
                    .ProviderClass<NHibernate.Caches.RtMemoryCache.RtMemoryCacheProvider>();
                })
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
            _factory.Statistics.IsStatisticsEnabled = true;
        }

        public static ISessionFactory GetFactory()
        {
            return _factory;
        }
    }
}
