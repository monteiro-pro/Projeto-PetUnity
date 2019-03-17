using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca.Model.Entidade;
using Biblioteca.Controller.Fachada;

namespace TesteUnitatio
{
    [TestClass]
    public class TestUnit
    {
        Fachada fachada_test = new Fachada();
        Animal animal_test = new Animal();

        [TestInitialize]
        public void IniciarTeste()
        {

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

        [TestMethod]
        public void EdicaoEntidade()
        {

        }

        [TestMethod]
        public void DeletarEntidade()
        {
            fachada_test.RemoveAnimal(animal_test);
        }
        #endregion

        [TestCleanup]
        public void TerminarTeste()
        {

        }
    }
}
