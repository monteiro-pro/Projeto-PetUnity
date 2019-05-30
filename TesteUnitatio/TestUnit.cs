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
        }

        //## TESTE UNITÁRIO

        [TestMethod]
        public void UsuarioNome()
        {
            //RepositorioBase teste = new RepositorioBase();

            teste.Select(cliente_teste);
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


        [TestMethod]
        public void EdicaoEntidade()
        {
            // Animal
            animal_test.Animal_ID = 1;
            animal_test.Animal_Nome = "Dog Dog";
            animal_test.Animal_Idade = 5;
            animal_test.Animal_Raca = "PitBull";
            animal_test.Animal_Especie = "Cachorro";
            animal_test.Animal_Peso = 30;

            fachada_test.UpdateAnimal(animal_test);
        }

        [TestMethod]
        public void DeletarEntidade()
        {
            // Animal
            animal_test.Animal_ID = 1;
            animal_test.Animal_Nome = "Dog Dog";
            animal_test.Animal_Idade = 5;
            animal_test.Animal_Raca = "PitBull";
            animal_test.Animal_Especie = "Cachorro";
            animal_test.Animal_Peso = 30;

            fachada_test.RemoveAnimal(animal_test);
        }
        #endregion

        [TestCleanup]
        public void TerminarTeste()
        {
            fachada_test.RemoveAnimal(animal_test);
        }
    }
}
