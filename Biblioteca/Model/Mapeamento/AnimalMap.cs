using Biblioteca.Model.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Mapeamento
{
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
            Table("tbl_Animal");
            Id(x => x.Animal_ID).GeneratedBy.Identity();
            Map(x => x.Animal_Nome);
            Map(x => x.Animal_Raca).Not.Nullable();
            Map(x => x.Animal_Especie).Not.Nullable();
            Map(x => x.Animal_Idade);
            Map(x => x.Animal_Peso);
        }
    }
}
