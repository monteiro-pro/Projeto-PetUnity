using Biblioteca.Controller.Regra;
using Biblioteca.Model.Entidade;
using Biblioteca.Model.Implementacao;
using Biblioteca.Model.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteca.Controller.Regra
{
    public class RegraCliente : IRegraNegocio<Cliente>
    {
        string erroMsg = string.Empty;
        Regex regexNumero = new Regex(@"^[0-9]+$");
        Regex regexNome = new Regex(@"^[\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+((\s[\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$");
        Regex regexEmail = new Regex(@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$");

        public void Insert(Cliente entidade)
        {
            VerificarDuplicidade(entidade);

            Validar(entidade);

            new ClienteRepositorio().Insert(entidade);
        }

        public IList<Cliente> List()
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

        public Cliente SelectEmail(string email)
        {
            return new ClienteRepositorio().Select(email);
        }

        public Cliente Select(string email, string senha)
        {
            return new ClienteRepositorio().Select(email, senha);
        }

        public void Update(Cliente entidade)
        {
            Validar(entidade);

            new ClienteRepositorio().Update(entidade);
        }

        public void Validar(Cliente entidade)
        {
            if (VerificarEntidade(entidade))
            {
                throw new Exception(erroMsg);
            }
            else if (VerificarNome(entidade.Cliente_Nome))
            {
                throw new Exception(erroMsg);
            }
            else if (VerificarRG(entidade.Cliente_RG))
            {
                throw new Exception(erroMsg);
            }
            else if (VerificarCPF(entidade.Cliente_CPF))
            {
                throw new Exception(erroMsg);
            }
            else if (VerificarEmail(entidade.Cliente_Email))
            {
                throw new Exception(erroMsg);
            }
            else if (VerificarSenha(entidade.Cliente_Senha))
            {
                throw new Exception(erroMsg);
            }
        }

        // ## MÉTODOS DE VALIDAÇÃO
        public bool VerificarEntidade(Cliente entidade)
        {
            if (entidade == null)
            {
                erroMsg = "A entidade não pode ser nula!";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarNome(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                erroMsg = "O nome não pode ser nulo!";
                return true;
            }
            else if(!regexNome.IsMatch(nome))
            {
                erroMsg = $"Nome {nome} inválido!";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarRG(string rg)
        {
            if (String.IsNullOrEmpty(rg))
            {
                erroMsg = "RG não pode ser nulo!";
                return true;
            }
            else if (rg.Length != 8)
            {
                erroMsg = "O RG deve ter exatos 8 caracteres!";
                return true;
            }
            else if (!regexNumero.IsMatch(rg))
            {
                erroMsg = "O RG deve conter apenas números!";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCPF(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                erroMsg = "CPF não pode ser nulo!";
                return true;
            }
            else if (cpf.Length != 11)
            {
                erroMsg = "O CPF deve ter exatos 11 caracteres!";
                return true;
            }
            else if (!regexNumero.IsMatch(cpf))
            {
                erroMsg = "O CPF deve conter apenas números!";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                erroMsg = "E-Mail não pode ser nulo!";
                return true;
            }
            else if (!regexEmail.IsMatch(email))
            {
                erroMsg = $"E-mail {email} inválido!";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarSenha(string senha)
        {
            if (String.IsNullOrEmpty(senha))
            {
                erroMsg = "Senha não pode ser nulo!";
                return true;
            }
            else if (senha.Length > 10)
            {
                erroMsg = "A senha não pode conter mais de 10 caracteres!";
                return true;
            }
            else
            {
                return false;
            }
        }

        private void VerificarDuplicidade(Cliente cliente)
        {

        }
    }
}
