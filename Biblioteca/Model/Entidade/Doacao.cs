using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Entidade
{
    public class Doacao
    {
        public virtual int Doacao_ID { get; set; }
        public virtual DateTime Doacao_Data { get; set; }
        public virtual int Doacao_Valor { get; set; }
        public virtual Cliente Doacao_Cliente { get; set; }
    }
}
