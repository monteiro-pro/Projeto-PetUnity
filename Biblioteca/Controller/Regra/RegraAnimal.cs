using Biblioteca.Model.Entidade;
using System;
using Biblioteca.Model.Implementacao;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Model.Repositorio;

namespace Biblioteca.Controller.Regra
{
    public class RegraAnimal : IRegraNegocio<Animal>
    {
        public void Insert(Animal entidade)
        {
            Validar(entidade);

            new AnimalRepositorio().Insert(entidade);
        }

        public List<Animal> List()
        {
            return new AnimalRepositorio().List();
        }

        public void Remove(Animal entidade)
        {
            Validar(entidade);

            new AnimalRepositorio().Remove(entidade);
        }

        public Animal Select(int id)
        {
            return new AnimalRepositorio().Select(id);
        }

        public List<Animal> Select(string nome)
        {
            string tabela = BaseDeDados.tabelaAninal;
            string coluna = BaseDeDados.colunaNomeAnimal;

            return new List<Animal>();/*new AnimalRepositorio().Select(nome, tabela, coluna);*/
        }

        public void Update(Animal entidade)
        {
            Validar(entidade);

            new AnimalRepositorio().Update(entidade);
        }

        public void Validar(Animal entidade)
        {
            if (entidade == null)
            {
                throw new Exception("Entidade nula!");
            }

            if (String.IsNullOrEmpty(entidade.Animal_Raca))
            {
                throw new Exception("Raça não informada!");
            }

            if (String.IsNullOrEmpty(entidade.Animal_Especie))
            {
                throw new Exception("Espécie não informada!");
            }
        }
    }
}
