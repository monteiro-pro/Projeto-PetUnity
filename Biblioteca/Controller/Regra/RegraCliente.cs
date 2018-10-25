using Biblioteca.Controller.Regra;
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
    public class RegraCliente : IRegraNegocio<Cliente>
    {
        public void Insert(Cliente entidade)
        {
            VerificarDuplicidade(entidade);

            Validar(entidade);

            new ClienteRepositorio().Insert(entidade);
        }

        public List<Cliente> List()
        {
            return new ClienteRepositorio().List();
        }

        public void Remove(Cliente entidade)
        {
            Validar(entidade);

            new ClienteRepositorio().Remove(entidade);
        }

        public Cliente Select(int id)
        {
            return new ClienteRepositorio().Select(id);
        }

        public IList<Cliente> Select(string nome)
        {
            string tabela = BaseDeDados.tabelaCliente;
            string coluna = BaseDeDados.colunaNomeCliente;

            return new ClienteRepositorio().Select(nome, tabela, coluna);
        }

        public void Update(Cliente entidade)
        {
            Validar(entidade);

            new ClienteRepositorio().Update(entidade);
        }

        public void Validar(Cliente entidade)
        {
            if(entidade == null)
            {
                throw new Exception("Entidade nula!");
            }

            if (String.IsNullOrEmpty(entidade.Cliente_Nome))
            {
                throw new Exception("Nome não informado!");
            }

            if (entidade.Cliente_RG == 0)
            {
                throw new Exception("RG não informado!");
            }

            if (entidade.Cliente_CPF == 0)
            {
                throw new Exception("CPF não informado!");
            }

            if (String.IsNullOrEmpty(entidade.Cliente_Email))
            {
                throw new Exception("E-Mail não informado!");
            }

            if (String.IsNullOrEmpty(entidade.Cliente_Senha))
            {
                throw new Exception("Senha não informada!");
            }
        }

        private void VerificarDuplicidade(Cliente cliente)
        {

        }
    }
}
