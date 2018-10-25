using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controller.Regra
{
    public interface IRegraNegocio<T>
    {
        void Insert(T entidade);
        void Update(T entidade);
        void Remove(T entidade);
        T Select(int id);
        List<T> List();
        void Validar(T entidade);
    }
}
