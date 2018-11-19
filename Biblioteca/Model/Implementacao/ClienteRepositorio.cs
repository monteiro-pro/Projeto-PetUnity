using Biblioteca.Model.Entidade;
using Biblioteca.Model.Repositorio;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Implementacao
{
    public class ClienteRepositorio : RepositorioBase<Cliente>
    {
        public Cliente Select(string email, string senha)
        {
            using (ISession _session = NHibernateConecao.AbrirConexao())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        Cliente result = new Cliente();
                        result = (Cliente)_session.QueryOver<Cliente>().Where(x => x.Cliente_Email == email).And(x => x.Cliente_Senha == senha).SingleOrDefault();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Selecionar: " + ex.Message);
                    }
                }
            }
        }

        public Cliente Select(string email)
        {
            using (ISession _session = NHibernateConecao.AbrirConexao())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        Cliente result = new Cliente();
                        result = (Cliente)_session.QueryOver<Cliente>().Where(x => x.Cliente_Email == email).SingleOrDefault();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Selecionar: " + ex.Message);
                    }
                }
            }
        }
    }
}
