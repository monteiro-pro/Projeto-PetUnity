using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repositorio
{
    public interface ICrudDal<T>
    {
        bool Insert(T entidade);
        void Remove(T entidade);
        void Update(T entidade);
    }
}
