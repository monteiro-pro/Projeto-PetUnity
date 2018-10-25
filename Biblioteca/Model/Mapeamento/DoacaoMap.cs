using Biblioteca.Model.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Mapeamento
{
    public class DoacaoMap : ClassMap<Doacao>
    {
        public DoacaoMap()
        {
            Table("tbl_Doacao");
            Id(x => x.Doacao_ID).GeneratedBy.Identity();
            Map(x => x.Doacao_Data).Not.Nullable();
            Map(x => x.Doacao_Valor).Not.Nullable();

            References(x => x.Doacao_Cliente).Not.Nullable();
        }
    }
}
