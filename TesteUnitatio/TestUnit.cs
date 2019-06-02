using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca.Model.Entidade;
using Biblioteca.Controller.Fachada;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Biblioteca.Controller.Regra;
using Biblioteca.Model.Repositorio;

namespace TesteUnitatio
{
    [TestClass]
    public class TestUnit
    {
        //## VARIÁVEIS GLOBAIS DE TESTE
        Fachada fachada_test = new Fachada();
        Animal animal_test = new Animal();
        Cliente cliente_teste = new Cliente();
        RegraAnimal regra_animal_teste = new RegraAnimal();
        RegraCliente regra_cliente_teste = new RegraCliente();
        string textoCorreto = string.Empty;
        string textoErrado = string.Empty;

        //## SELENIUM
        //private Selenium selenium = new ISelenium();

        [TestInitialize]
        public void IniciarTeste()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://localhost:53627/");

            // ANIMAL
            animal_test.Animal_Nome = "Dog Dog";
            animal_test.Animal_Idade = 5;
            animal_test.Animal_Raca = "PitBull";
            animal_test.Animal_Especie = "Cachorro";
            animal_test.Animal_Peso = 30;

            // CLIENTE
            cliente_teste.Cliente_Nome = "Márcio Alvaro";
            cliente_teste.Cliente_RG = "12345128";
            cliente_teste.Cliente_CPF = "12345678901";
            cliente_teste.Cliente_Endereco = "Lugar Tal - Rua tal";
            cliente_teste.Cliente_Email = "teste.teste@teste.com";
            cliente_teste.Cliente_Senha = "123abc";
            cliente_teste.Cliente_Telefone = 12345678;
        }

        //## TESTE UNITÁRIO

        //** ENTIDADE
        [TestMethod]
        public void TUnit_01_Entidade_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarEntidade(cliente_teste), "ENTIDADE NÃO PODE SER NULA!");
        }

        [TestMethod]
        public void TUnit_01_Entidade_02()
        {
            cliente_teste = null;
            Assert.IsTrue(regra_cliente_teste.VerificarEntidade(cliente_teste), "ENTIDADE DEVE SER NULA!");
        }

        //** NOME
        [TestMethod]
        public void TUnit_02_Nome_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarNome(cliente_teste.Cliente_Nome), "NOME NÃO PODE SER NULO!");
        }

        [TestMethod]
        public void TUnit_02_Nome_02()
        {
            cliente_teste.Cliente_Nome = null;
            Assert.IsTrue(regra_cliente_teste.VerificarNome(cliente_teste.Cliente_Nome), "NOME DEVE SER NULO!");
        }

        [TestMethod]
        public void TUnit_02_Nome_03()
        {
            cliente_teste.Cliente_Nome = "Carlos 123";
            Assert.IsTrue(regra_cliente_teste.VerificarNome(cliente_teste.Cliente_Nome), "NOME NÃO PODE CONTER APENAS LETRAS E ESPAÇO!");
        }

        [TestMethod]
        public void TUnit_02_Nome_04()
        {
            cliente_teste.Cliente_Nome = "Marcos .";
            Assert.IsTrue(regra_cliente_teste.VerificarNome(cliente_teste.Cliente_Nome), "NOME NÃO PODE CONTER APENAS LETRAS E ESPAÇO!");
        }

        //** RG
        [TestMethod]
        public void TUnit_03_RG_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE SER NULO, DEVE TER EXATOS 8 DIGITOS E CONTER APENAS NÚMEROD PARA PODER PASSAR NO TESTE!");
        }

        [TestMethod]
        public void TUnit_03_RG_02()
        {
            cliente_teste.Cliente_RG = null; //** RG NULO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG DEVE SER NULO!");
        }

        [TestMethod]
        public void TUnit_03_RG_03()
        {
            cliente_teste.Cliente_RG = "123456"; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE TER EXATOS 8 DIGITOS!");
        }

        [TestMethod]
        public void TUnit_03_RG_04()
        {
            cliente_teste.Cliente_RG = "123456AB"; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_RG_05()
        {
            cliente_teste.Cliente_RG = "ABCDEFGH"; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_RG_06()
        {
            cliente_teste.Cliente_RG = "ABCDEFG."; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_RG_07()
        {
            cliente_teste.Cliente_RG = "ABCDEFG/"; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_RG_08()
        {
            cliente_teste.Cliente_RG = "ABCDEFG "; //** RG ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_RG), "RG NÃO PODE CONTER APENAS NÚMEROS!");
        }

        //** CPF
        [TestMethod]
        public void TUnit_04_CPF_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarCPF(cliente_teste.Cliente_CPF), "CPF NÃO PODE SER NULO, DEVE TER EXATOS 11 DIGITOS E DEVE CONTER APENAS NÚMEROS PARA PODER PASSAR NO TESTE!");
        }

        [TestMethod]
        public void TUnit_03_cpf_02()
        {
            cliente_teste.Cliente_CPF = null; //** CPF NULO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF DEVE SER NULO!");
        }

        [TestMethod]
        public void TUnit_03_cpf_03()
        {
            cliente_teste.Cliente_CPF = "123456789"; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER EXATOS 11 DIGITOS!");
        }

        [TestMethod]
        public void TUnit_03_cpf_04()
        {
            cliente_teste.Cliente_CPF = "123456789AB"; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_cpf_05()
        {
            cliente_teste.Cliente_CPF = "ABCDEFGHIJL"; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_cpf_06()
        {
            cliente_teste.Cliente_CPF = "ABCDEFGHIJ."; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_cpf_07()
        {
            cliente_teste.Cliente_CPF = "ABCDEFGHIJ/"; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER APENAS NÚMEROS!");
        }

        [TestMethod]
        public void TUnit_03_cpf_08()
        {
            cliente_teste.Cliente_CPF = "ABCDEFGHIJ "; //** CPF ERRADO
            Assert.IsTrue(regra_cliente_teste.VerificarRG(cliente_teste.Cliente_CPF), "CPF NÃO PODE CONTER APENAS NÚMEROS!");
        }

        //** E-MAIL
        [TestMethod]
        public void TUnit_05_Email_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL VÁLIDO!");
        }

        [TestMethod]
        public void TUnit_05_Email_02()
        {
            cliente_teste.Cliente_Email = "teste_teste.com";
            Assert.IsTrue(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL VÁLIDO!");
        }

        [TestMethod]
        public void TUnit_05_Email_03()
        {
            cliente_teste.Cliente_Email = "teste//teste@teste.com";
            Assert.IsTrue(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL INVÁLIDO!");
        }

        [TestMethod]
        public void TUnit_05_Email_04()
        {
            cliente_teste.Cliente_Email = ".teste@teste.com";
            Assert.IsTrue(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL INVÁLIDO!");
        }

        [TestMethod]
        public void TUnit_05_Email_05()
        {
            cliente_teste.Cliente_Email = "teste@teste@teste.com";
            Assert.IsTrue(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL INVÁLIDO!");
        }
        [TestMethod]
        public void TUnit_05_Email_06()
        {
            cliente_teste.Cliente_Email = "@teste.com";
            Assert.IsTrue(regra_cliente_teste.VerificarEmail(cliente_teste.Cliente_Email), "DEVE SER UM E-MAIL INVÁLIDO!");
        }

        //** SENHA
        [TestMethod]
        public void TUnit_06_Senha_01()
        {
            Assert.IsFalse(regra_cliente_teste.VerificarSenha(cliente_teste.Cliente_Senha), "SENHA NÃO PODE SER NULA!");
        }

        [TestMethod]
        public void TUnit_06_Senha_02()
        {
            cliente_teste.Cliente_Senha = "123ABC7891H";
            Assert.IsTrue(regra_cliente_teste.VerificarSenha(cliente_teste.Cliente_Senha), "SENHA DEVE CONTER MENOS DE 10 DIGITOS!");
        }

        //** MÉTODO VALIDAR
        [TestMethod]
        public void TUnit_07_Validar_01()
        {
            regra_cliente_teste.Validar(cliente_teste);
        }


        //## TESTES DE INTEGRAÇÃO
        //** Testes das Entidades
        #region Teste da Entidade
        [TestMethod]
        public void CrearEntidade()
        {
            // Animal
            animal_test.Animal_Nome = "Dog Dog";
            animal_test.Animal_Idade = 5;
            animal_test.Animal_Raca = "PitBull";
            animal_test.Animal_Especie = "Cachorro";
            animal_test.Animal_Peso = 30;

            fachada_test.InsertAnimal(animal_test);
        }

        [TestMethod]
        public void SelecionarEntidade()
        {
            // Animal
            animal_test.Animal_Nome = "Dog Dog";
            animal_test.Animal_Idade = 5;
            animal_test.Animal_Raca = "PitBull";
            animal_test.Animal_Especie = "Cachorro";
            animal_test.Animal_Peso = 30;

            fachada_test.SelectAnimal(animal_test.Animal_Nome);
        }

        [TestMethod]
        public void ListarEntidade()
        {
            fachada_test.ListAnimla();
        }


        //[TestMethod]
        //public void EdicaoEntidade()
        //{
        //    // Animal
        //    animal_test.Animal_ID = 1;
        //    animal_test.Animal_Nome = "Dog Dog";
        //    animal_test.Animal_Idade = 5;
        //    animal_test.Animal_Raca = "PitBull";
        //    animal_test.Animal_Especie = "Cachorro";
        //    animal_test.Animal_Peso = 30;

        //    fachada_test.UpdateAnimal(animal_test);
        //}

        //[TestMethod]
        //public void DeletarEntidade()
        //{
        //    // Animal
        //    animal_test.Animal_ID = 1;
        //    animal_test.Animal_Nome = "Dog Dog";
        //    animal_test.Animal_Idade = 5;
        //    animal_test.Animal_Raca = "PitBull";
        //    animal_test.Animal_Especie = "Cachorro";
        //    animal_test.Animal_Peso = 30;

        //    fachada_test.RemoveAnimal(animal_test);
        //}
        #endregion

        [TestCleanup]
        public void TerminarTeste()
        {
            fachada_test.RemoveAnimal(animal_test);
        }
    }
}
