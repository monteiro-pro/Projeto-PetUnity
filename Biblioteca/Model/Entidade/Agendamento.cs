using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Entidade
{
    public class Agendamento
    {
        public virtual int Agendamento_ID { get; set; }
        public virtual DateTime Agendamento_Data { get; set; }
        public virtual string Agendamento_Unidade { get; set; }
        public virtual Cliente Agendamento_Cliente { get; set; }
    }
}
