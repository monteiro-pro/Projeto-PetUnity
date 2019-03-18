using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca.Model.Entidade;
using Biblioteca.Controller.Fachada;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteUnitatio
{
    [TestClass]
    public class TestUnit
    {
        Fachada fachada_test = new Fachada();
        Animal animal_test = new Animal();
        //private Selenium selenium = new ISelenium();

        [TestInitialize]
        public void IniciarTeste()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53627/");
        }

        // # Teste da Entidade
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

        //[TestMethod]
        //public void EdicaoEntidade()
        //{

        //}

        [TestMethod]
        public void DeletarEntidade()
        {
        }
        #endregion

        [TestCleanup]
        public void TerminarTeste()
        {
            fachada_test.RemoveAnimal(animal_test);
        }
    }
}
