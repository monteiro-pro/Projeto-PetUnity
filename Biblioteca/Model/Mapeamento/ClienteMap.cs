using Biblioteca.Model.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Mapeamento
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("tbl_Cliente");
            Id(x => x.Cliente_ID).GeneratedBy.Identity();
            Map(x => x.Cliente_Nome).Not.Nullable();
            Map(x => x.Cliente_RG).Not.Nullable().Unique();
            Map(x => x.Cliente_CPF).Not.Nullable().Unique();
            Map(x => x.Cliente_Endereco);
            Map(x => x.Cliente_Email).Not.Nullable().Unique();
            Map(x => x.Cliente_Senha).Not.Nullable();
            Map(x => x.Cliente_Telefone);
        }
    }
}
