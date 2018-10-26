using Biblioteca.Model.Entidade;
using Biblioteca.Model.Implementacao;
using Biblioteca.Model.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controller.Regra
{
    public class RegraDoacao : IRegraNegocio<Doacao>
    {
        public void Insert(Doacao entidade)
        {
            Validar(entidade);

            new DoacaoRepositorio().Insert(entidade);
        }

        public IList<Doacao> List()
        {
            return new DoacaoRepositorio().List();
        }

        public void Remove(Doacao entidade)
        {
            Validar(entidade);

            new DoacaoRepositorio().Remove(entidade);
        }

        public Doacao Select(int id)
        {
            return new DoacaoRepositorio().Select(id);
        }

        public IList<Doacao> Select(DateTime data)
        {
            string tabela = BaseDeDados.tabelaDoacao;
            string coluna = BaseDeDados.colunaDataDoacao;

            return new DoacaoRepositorio().Select(data, tabela, coluna);
        }

        public void Update(Doacao entidade)
        {
            Validar(entidade);

            new DoacaoRepositorio().Update(entidade);
        }

        public void Validar(Doacao entidade)
        {
            if (entidade == null)
            {
                throw new Exception("Entidade nula!");
            }

            if (String.IsNullOrEmpty(Convert.ToString(entidade.Doacao_Data)))
            {
                throw new Exception("Data não informada!");
            }

            if (entidade.Doacao_Valor == 0)
            {
                throw new Exception("Valor não informado!");
            }

            if (entidade.Doacao_Cliente == null)
            {
                throw new Exception("Cliente não informado!");
            }
        }
    }
}
