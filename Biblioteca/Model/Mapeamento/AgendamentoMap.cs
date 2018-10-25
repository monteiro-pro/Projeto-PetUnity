using Biblioteca.Model.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Mapeamento
{
    class AgendamentoMap : ClassMap<Agendamento>
    {
        public AgendamentoMap()
        {
            Table("tbl_Agendamento");
            Id(x => x.Agendamento_ID).GeneratedBy.Identity();
            Map(x => x.Agendamento_Data).Not.Nullable();
            Map(x => x.Agendamento_Hora).Not.Nullable();
            Map(x => x.Agendamento_Unidade).Not.Nullable();

            References(x => x.Agendamento_Cliente).Not.Nullable();
        }
    }
}
