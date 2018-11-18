using Biblioteca.Controller.Regra;
using Biblioteca.Model.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controller.Fachada
{
    public class Fachada
    {
        private RegraAgendamento Agendamento;
        private RegraTransacao Transacao;
        private RegraCliente Cliente;
        private RegraAnimal Animal;
        private RegraDoacao Doacao;

        public Fachada()
        {
            Agendamento = new RegraAgendamento();
            Transacao = new RegraTransacao();
            Cliente = new RegraCliente();
            Animal = new RegraAnimal();
            Doacao = new RegraDoacao();
        }

        #region Cliente
        public void InsertCliente(Cliente cliente)
        {
            Cliente.Insert(cliente);
        }

        public void RemoveCliente(Cliente cliente)
        {
            Cliente.Remove(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente.Update(cliente);
        }

        public Cliente SelectCliente(int id)
        {
            return Cliente.Select(id);
        }

        public IList<Cliente> SelectCliente(string nome)
        {
            return Cliente.Select(nome);
        }

        public Cliente SelectCliente(string email, string senha)
        {
            return Cliente.Select(email, senha);
        }

        public IList<Cliente> ListCliente()
        {
            return Cliente.List();
        }
        #endregion

        #region Animal
        public void InsertAnimal(Animal animal)
        {
            Animal.Insert(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            Animal.Remove(animal);
        }

        public void UpdateAnimal(Animal animal)
        {
            Animal.Update(animal);
        }

        public Animal SelectAnimal(int id)
        {
            return Animal.Select(id);
        }

        public IList<Animal> SelectAnimal(string nome)
        {
            return Animal.Select(nome);
        }

        public IList<Animal> ListAnimla()
        {
            return Animal.List();
        }
        #endregion

        #region Agenda
        public void InsertAgenda(Agendamento agenda)
        {
            Agendamento.Insert(agenda);
        }

        public void RemoveAgenda(Agendamento agenda)
        {
            Agendamento.Remove(agenda);
        }

        public void UpdateAgenda(Agendamento agenda)
        {
            Agendamento.Update(agenda);
        }

        public Agendamento SelectAgendamento(int id)
        {
            return Agendamento.Select(id);
        }

        public IList<Agendamento> SelectAgendamento(DateTime data)
        {
            return Agendamento.Select(data);
        }

        public IList<Agendamento> List()
        {
            return Agendamento.List();
        }
        #endregion

        #region Transacao
        public void InserTrasacao(Transacao transacao)
        {
            Transacao.Insert(transacao);
        }

        public void RemoveTransacao(Transacao transacao)
        {
            Transacao.Remove(transacao);
        }

        public void UpdateTransacao(Transacao transacao)
        {
            Transacao.Update(transacao);
        }

        public Transacao SelectTransacao(int id)
        {
            return Transacao.Select(id);
        }

        public IList<Transacao> SelectTransacao(DateTime data)
        {
            return Transacao.Select(data);
        }

        public IList<Transacao> ListTransacao()
        {
            return Transacao.List();
        }
        #endregion

        #region Doacao
        public void InsertDoacao(Doacao doacao)
        {
            Doacao.Insert(doacao);
        }

        public void RemoveDoacao(Doacao doacao)
        {
            Doacao.Remove(doacao);
        }

        public void UpdateDoacao(Doacao doacao)
        {
            Doacao.Update(doacao);
        }

        public Doacao SelectDoacao(int id)
        {
            return Doacao.Select(id);
        }

        public IList<Doacao> SelectDoacao(DateTime data)
        {
            return Doacao.Select(data);
        }

        public IList<Doacao> ListDoacao()
        {
            return Doacao.List();
        }
        #endregion
    }
}
