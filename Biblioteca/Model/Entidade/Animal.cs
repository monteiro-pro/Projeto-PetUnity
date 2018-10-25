using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Entidade
{
    public class Animal
    {
        public virtual int Animal_ID { get; set; }

        public virtual string Animal_Nome { get; set; }
        public virtual string Animal_Raca { get; set; }
        public virtual string Animal_Especie { get; set; }
        public virtual int Animal_Idade { get; set; }
        public virtual int Animal_Peso { get; set; }
    }
}
