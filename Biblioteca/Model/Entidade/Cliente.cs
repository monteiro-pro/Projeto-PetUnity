using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Entidade
{
    public class Cliente
    {
        public virtual int Cliente_ID { get; set; }
        public virtual string Cliente_Nome { get; set; }
        public virtual string Cliente_RG { get; set; }
        public virtual string Cliente_CPF { get; set; }
        public virtual string Cliente_Endereco { get; set; }
        public virtual string Cliente_Email { get; set; }
        public virtual string Cliente_Senha { get; set; }
        public virtual int Cliente_Telefone { get; set; }
    }
}
