using Biblioteca.Controller.Fachada;
using Biblioteca.Controller.Regra;
using Biblioteca.Model.Entidade;
using Biblioteca.Model.Implementacao;
using Biblioteca.Model.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Teste
    {
        static void Main(string[] args)
        {
            DoacaoRepositorio reD = new DoacaoRepositorio();

            Cliente cliente = new Cliente
            {
                Cliente_ID = 1,
                Cliente_Nome = "Pedro",
                Cliente_Senha = "Teste",
                Cliente_CPF = "1244",
                Cliente_RG = "1344",
                Cliente_Endereco = "Teste2",
                Cliente_Email = "Testepepep2",
                Cliente_Telefone = 34566
            };

            Cliente cliente2 = new Cliente
            {
                Cliente_ID = 1,
                Cliente_Nome = "Monteiro",
                Cliente_CPF = "456",
                Cliente_RG = "777",
                Cliente_Endereco = "Teste",
                Cliente_Email = "Teste",
                Cliente_Senha = "Teste",
                Cliente_Telefone = 1111
            };

            Doacao doacao = new Doacao
            {
                Doacao_ID = 1,
                Doacao_Data = DateTime.Now,
                Doacao_Valor = 20,
                Doacao_Cliente = cliente
            };

            Agendamento agenda = new Agendamento
            {
                Agendamento_Data = DateTime.Now,
                Agendamento_Unidade = "Recife",
                Agendamento_Cliente = cliente2
            };

            //Fachada<RegraCliente> f = new Fachada<RegraCliente>();

            //RegraCliente f = new RegraCliente();

            Fachada Fachada = new Fachada();

            RepositorioBase<Cliente> teste = new RepositorioBase<Cliente>();

            //Console.WriteLine(Fachada.Select(cliente).Cliente_Nome);

            //Fachada.Agenda.Insert(cliente2);


            //ClienteRepositorio reC = new ClienteRepositorio();


            //Fachada.InsertCliente(cliente);
            //Fachada.Select(cliente2);
            //reC.Update(cliente);
            //reC.Remove(cliente2);

            //reD.Insert(doacao);
            //reD.Update(doacao);

            //Fachada.InsertDoacao(doacao);

            //Fachada.SelectCliente("Monteiro");

            //string datas = "2018/10/24";

            DateTime data = new DateTime(2018,10,24);

            //data.ToString();
            //data.ToString("yyyy/dd/MM");

            //Fachada.SelectAgendamento("Recife");

            //Fachada.SelectDoacao(data);

            //IList<Cliente> lista = Fachada.ListCliente();

            //foreach (Cliente lista in Fachada.ListCliente())
            //{
            //    Console.WriteLine(lista.Cliente_Nome);
            //}

            Animal animal = new Animal
            {
                Animal_ID = 2,
            };

            Cliente cliente_teste = new Cliente();

            cliente_teste.Cliente_Nome = "Márcio Alvaro";
            cliente_teste.Cliente_RG = "12345128";
            cliente_teste.Cliente_CPF = "12345678901";
            cliente_teste.Cliente_Endereco = "Lugar Tal - Rua tal";
            cliente_teste.Cliente_Email = "teste.teste@teste.com";
            cliente_teste.Cliente_Senha = "123abc";
            cliente_teste.Cliente_Telefone = 12345678;

            Fachada.RemoveCliente(cliente_teste);
             
            //Fachada.ListDoacao();

            //teste.List(teste.GetType);

            //Console.WriteLine(Fachada.SelectDoacao(2).Doacao_Data.TimeOfDay);
            Console.ReadKey();

            //Testando o Commit!
        }
    }
}
