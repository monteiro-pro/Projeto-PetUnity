using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Entidade
{
    public class Transacao
    {
        public virtual int Transacao_ID { get; set; }
        public virtual DateTime Transacao_Data { get; set; }
        public virtual string Transacao_Processo { get; set; }
        public virtual string Transacao_Motivo { get; set; }
        public virtual string Transacao_Reserva { get; set; }
        public virtual string Transacao_Raca_Reserva { get; set; }
        public virtual Animal Transacao_Animal { get; set; }
    }
}
