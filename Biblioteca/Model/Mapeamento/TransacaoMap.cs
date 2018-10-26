using Biblioteca.Model.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Mapeamento
{
    public class TransacaoMap : ClassMap<Transacao>
    {
        public TransacaoMap()
        {
            Table("tbl_Transacao");
            Id(x => x.Transacao_ID).GeneratedBy.Identity();
            Map(x => x.Transacao_Data).Not.Nullable();
            Map(x => x.Transacao_Processo).Not.Nullable();
            Map(x => x.Transacao_Motivo);
            Map(x => x.Transacao_Reserva).Not.Nullable();
            Map(x => x.Transacao_Raca_Reserva);

            References(x => x.Transacao_Animal).Not.Nullable();
        }
    }
}
