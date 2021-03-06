﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca.Model.Entidade;
using Biblioteca.Controller.Fachada;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Biblioteca.Controller.Regra;
using Biblioteca.Model.Repositorio;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Moq;

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

        [TestInitialize]
        public void IniciarTeste()
        {
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
            cliente_teste.Cliente_Senha = "123-aBC";
            cliente_teste.Cliente_Telefone = 12345678;
        }

        //## TESTE UNITÁRIO
        //** Regra de Negócio
        #region Teste Unitário
        #region Regra de Negócio
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

        //** REGRA DE NEGÓCIO (MOCK).
        //[TestMethod]
        //public void TUnit_08_Select_01()
        //{
        //    cliente_teste.Cliente_ID = 4;
        //    cliente_teste.Cliente_Nome = "Márcio Alvaro";
        //    cliente_teste.Cliente_RG = "22346128";
        //    cliente_teste.Cliente_CPF = "22345678901";
        //    cliente_teste.Cliente_Endereco = "Lugar Tal - Rua tal";
        //    cliente_teste.Cliente_Email = "teste@teste.com";
        //    cliente_teste.Cliente_Senha = "123-bBC";
        //    cliente_teste.Cliente_Telefone = 12345678;

        //    RegraCliente verif = new RegraCliente();

        //    Mock<IRegraNegocio<Cliente>> mock = new Mock<IRegraNegocio<Cliente>>();
        //    mock.Setup(m => m.Select(4)).Returns(verif.Select(4));

        //    // act
        //    Cliente resultadoEsperado = verif.Select(4);
        //    Cliente resultado = verif.Select(4);

        //    bool teste = Equals(resultadoEsperado, resultado);

        //    // assert
        //    Assert.AreEqual(resultado, resultadoEsperado);
        //}


        [TestMethod]
        public void TUnit_08_Select_01()
        {
            Mock<IRegraNegocio<Cliente>> mock = new Mock<IRegraNegocio<Cliente>>();
            mock.Setup(m => m.Insert(cliente_teste)).Returns(true);
            RegraCliente verif = new RegraCliente();

            // act
            var resultadoEsperado = mock.Object.Insert(cliente_teste);
            var resultado = verif.Insert(cliente_teste);

            // assert
            Assert.AreEqual(resultado, resultadoEsperado);

            verif.Remove(cliente_teste);
        }

        #endregion
        #endregion


        //## TESTES DE INTEGRAÇÃO
        //** Edidade Animal
        #region Teste de Integração
        #region Animal
        [TestMethod]
        public void TI_01_CrearEntidadeAnimal()
        {
            fachada_test.InsertAnimal(animal_test);
        }

        [TestMethod]
        public void TI_02_SelecionarAnimal()
        {
            fachada_test.SelectAnimal(animal_test.Animal_Nome);
        }

        [TestMethod]
        public void TI_03_SelecionarUltimoAnimal()
        {
            fachada_test.SelectAnimal(animal_test.Animal_Nome);
        }

        [TestMethod]
        public void TI_04_ListarAnimal()
        {
            fachada_test.ListAnimla();
        }

        [TestMethod]
        public void TI_05_EdicaoAnimal()
        {
            Animal animal_test_update = fachada_test.SelectLastAnimal();

            animal_test_update.Animal_Nome = "Chana";
            animal_test_update.Animal_Idade = 2;
            animal_test_update.Animal_Raca = "Sianes";
            animal_test_update.Animal_Especie = "Gato";
            animal_test_update.Animal_Peso = 20;

            fachada_test.UpdateAnimal(animal_test_update);
        }

        [TestMethod]
        public void TI_06_DeletarAnimal()
        {
            fachada_test.RemoveAnimal(fachada_test.SelectLastAnimal());
        }
        #endregion

        #region Cliente
        [TestMethod]
        public void TI_07_CrearEntidadeCliente()
        {
            fachada_test.InsertCliente(cliente_teste);
        }

        [TestMethod]
        public void TI_08_SelectCliente()
        {
            fachada_test.SelectCliente(cliente_teste.Cliente_Nome);
        }

        [TestMethod]
        public void TI_09_SelectCliente()
        {
            fachada_test.SelectCliente(cliente_teste.Cliente_Nome);
        }

        [TestMethod]
        public void TI_10_SelectCliente()
        {
            fachada_test.SelectCliente(cliente_teste.Cliente_Email);
        }

        [TestMethod]
        public void TI_11_SelectCliente()
        {
            fachada_test.SelectCliente(cliente_teste.Cliente_Email, cliente_teste.Cliente_Senha);
        }

        [TestMethod]
        public void TI_12_SelectCliente()
        {
            fachada_test.SelectLastCliente();
        }

        [TestMethod]
        public void TI_13_ListCliente()
        {
            fachada_test.ListCliente();
        }

        [TestMethod]
        public void TI_14_EditarCliente()
        {
            Cliente test_cliente_update = fachada_test.SelectLastCliente();

            test_cliente_update.Cliente_Nome = "Paulo Ângela";
            test_cliente_update.Cliente_Email = "update.teste@update.com.br";
            test_cliente_update.Cliente_Endereco = "Algum Lugar";
            test_cliente_update.Cliente_Telefone = 222333444;

            fachada_test.UpdateCliente(test_cliente_update);
        }

        [TestMethod]
        public void TI_15_DeleteCliente()
        {
            fachada_test.RemoveCliente(fachada_test.SelectLastCliente());
        }
        #endregion
        #endregion

        //## TESTES DE FUNCIONALIDADE 
        //** Tela
        #region Teste de Fincionalidade
        public void Selenium()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://localhost:53627/Account/Register");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IniciarTeste();

            driver.FindElement(By.Id("Nome")).SendKeys(cliente_teste.Cliente_Nome);
            driver.FindElement(By.Id("RG")).SendKeys(cliente_teste.Cliente_RG);
            driver.FindElement(By.Id("CPF")).SendKeys(cliente_teste.Cliente_CPF);
            driver.FindElement(By.Id("Endereco")).SendKeys(cliente_teste.Cliente_Endereco);
            driver.FindElement(By.Id("Email")).SendKeys(cliente_teste.Cliente_Email);
            driver.FindElement(By.Id("Senha")).SendKeys(cliente_teste.Cliente_Senha);
            driver.FindElement(By.Id("ConfirmSenha")).SendKeys(cliente_teste.Cliente_Senha);
            driver.FindElement(By.Id("Telefone")).SendKeys(cliente_teste.Cliente_Telefone.ToString());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("Register")).Click();

            fachada_test.RemoveCliente(fachada_test.SelectLastCliente());
        }
        #endregion

        [TestCleanup]
        public void TerminarTeste()
        {
            //fachada_test.RemoveAnimal(animal_test);
        }
    }
}
