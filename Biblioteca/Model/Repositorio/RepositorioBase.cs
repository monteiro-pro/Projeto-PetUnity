﻿using Biblioteca.ExtensionMethods;
using Biblioteca.Model.Entidade;
using Biblioteca.Model.Mapeamento;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repositorio
{
    public class RepositorioBase<T> : ICrudDal<T> where T : class
    {
        public void Insert(T entidade)
        {
            using(ISession _session = NHibernateConecao.AbrirConexao())
            {
                using(ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entidade);

                        _transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Salvar: " + ex.Message);
                    }
                }
            }
        }

        public void Remove(T entidade)
        {
            using(ISession _session = NHibernateConecao.AbrirConexao())
            {
                using(ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entidade);

                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Remover: " + ex.Message);
                    }
                }
            }
        }

        public void Update(T entidade)
        {
            using(ISession _session = NHibernateConecao.AbrirConexao())
            {
                using(ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entidade);

                        _transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Atualizar: " + ex.Message);
                    }
                }
            }
        }

        public T Select(int id)
        {
            T entidade;

            using (ISession _session = NHibernateConecao.AbrirConexao())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        entidade = _session.Get<T>(id);
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Selecionar: " + ex.Message);
                    }
                }
            }
            return entidade;
        }

        public List<T> Select(string nome, string tabela, string coluna)
        {
            List<T> entidade;

            string query = $"SELECT * FROM {tabela} WHERE {coluna} = '{nome.AddSlashes()}';";
            
            using (ISession _session = NHibernateConecao.AbrirConexao())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        ISQLQuery result = _session.CreateSQLQuery(query);

                        result.AddEntity(typeof(T));
                        IList<T> lista = result.List<T>();
                        entidade = (List<T>)lista;
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Selecionar: " + ex.Message);
                    }
                }
            }
            return entidade;
        }

        public List<T> Select(DateTime data, string tabela, string coluna)
        {
            List<T> entidade;

            string query = $"SELECT * FROM {tabela} WHERE {coluna} = '{(data.ToString("yyyy/MM/dd")).AddSlashes()}';";

            using (ISession _session = NHibernateConecao.AbrirConexao())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        //var result = _session.CreateSQLQuery(query).List();

                        //entidade = (List<T>)result;

                        ISQLQuery result = _session.CreateSQLQuery(query);

                        result.AddEntity(typeof(T));
                        IList<T> lista = result.List<T>();
                        entidade = (List<T>)lista;
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Selecionar: " + ex.Message);
                    }
                }
            }
            return entidade;
        }

        public List<T> List()
        {
            List<T> entidade;

            using (ISession _session = NHibernateConecao.AbrirConexao())
             {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        var result = _session.QueryOver<T>().List();

                        entidade = (List<T>)result;
                    }
                    catch (Exception ex)
                    {
                        if (_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Erro ao tentar Listar: " + ex.Message);
                    }
                }
            }
            return entidade;
        }

        //public List<T> List(T entidade)
        //{
        //    using (ISession _session = NHibernateConecao.AbrirConexao())
        //    {
        //        using (ITransaction _transaction = _session.BeginTransaction())
        //        {
        //            try
        //            {

        //            }
        //            catch (Exception ex)
        //            {
        //                if (_transaction.WasCommitted)
        //                    _transaction.Rollback();
        //                throw new Exception("Erro ao tentar Listar: " + ex.Message);
        //            }
        //        }
        //    }
        //    return List<entidade>;
        //}
    }
}