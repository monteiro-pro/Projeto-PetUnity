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
    public class RegraAgendamento : IRegraNegocio<Agendamento>
    {
        public bool Insert(Agendamento entidade)
        {
            Validar(entidade);

            return new AgendaRepositorio().Insert(entidade);
        }

        public IList<Agendamento> List()
        {
            return new AgendaRepositorio().List();
        }

        public void Remove(Agendamento entidade)
        {
            Validar(entidade);

            new AgendaRepositorio().Remove(entidade);
        }

        public Agendamento Select(int id)
        {
            return new AgendaRepositorio().Select(id);
        }

        public IList<Agendamento> Select(DateTime data)
        {
            string tabela = BaseDeDados.Agenda.tabelaAgendamento;
            string coluna = BaseDeDados.Agenda.colunaUnidadeAgendamento;

            return new AgendaRepositorio().Select(data, tabela, coluna);
        }

        public void Update(Agendamento entidade)
        {
            Validar(entidade);

            new AgendaRepositorio().Update(entidade);
        }

        public void Validar(Agendamento entidade)
        {
            if (entidade == null)
            {
                throw new Exception("Entidade nula!");
            }

            if (String.IsNullOrEmpty(Convert.ToString(entidade.Agendamento_Data)))
            {
                throw new Exception("Data de Agendamento não informada!");
            }

            if (String.IsNullOrEmpty(entidade.Agendamento_Unidade))
            {
                throw new Exception("Unidade não informada!");
            }

            if (entidade.Agendamento_Cliente == null)
            {
                throw new Exception("A propiedade cliente não pode ser nula!");
            }
        }
    }
}
