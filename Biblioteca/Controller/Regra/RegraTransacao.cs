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
    public class RegraTransacao : IRegraNegocio<Transacao>
    {
        public void Insert(Transacao entidade)
        {
            Validar(entidade);

            new TransacaoRepositorio().Insert(entidade);
        }

        public IList<Transacao> List()
        {
            return new TransacaoRepositorio().List();
        }

        public void Remove(Transacao entidade)
        {
            Validar(entidade);

            new TransacaoRepositorio().Remove(entidade);
        }

        public Transacao Select(int id)
        {
            return new TransacaoRepositorio().Select(id);
        }

        public IList<Transacao> Select(DateTime data)
        {
            string tabela = BaseDeDados.tabelaTransacao;
            string coluna = BaseDeDados.colunaDataTransacao;

            return new TransacaoRepositorio().Select(data, tabela, coluna);
        }

        public void Update(Transacao entidade)
        {
            Validar(entidade);

            new TransacaoRepositorio().Update(entidade);
        }

        public void Validar(Transacao entidade)
        {
            if (String.IsNullOrEmpty(Convert.ToString(entidade.Transacao_Data)))
            {
                throw new Exception("Data de transação não informada!");
            }

            if (String.IsNullOrEmpty(entidade.Transacao_Processo))
            {
                throw new Exception("Processo não informado!");
            }

            if (String.IsNullOrEmpty(entidade.Transacao_Reserva))
            {
                throw new Exception("Campo reserva não poderá ser nulo!");
            }

            if (entidade.Transacao_Animal == null)
            {
                throw new Exception("A propiedade animal não pode ser nula!");
            }
        }
    }
}
