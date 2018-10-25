using Biblioteca.Model.Mapeamento;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repositorio
{
    public static class NHibernateConecao
    {
        private static ISessionFactory session;

        private static ISessionFactory CriarSessao()
        {
            if (session != null)
                return session;

            FluentConfiguration _configuration = Fluently.Configure()
                                                            .Database(
                                                                MySQLConfiguration.Standard.ConnectionString("Server=localhost;Port=3306;Database=petunity;Username=root;Password=;SslMode=none"))
                                                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ClienteMap>())
                                                                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false));
            session = _configuration.BuildSessionFactory();
            return session;
        }

        public static ISession AbrirConexao()
        {
            return CriarSessao().OpenSession();
        }
    }
}
