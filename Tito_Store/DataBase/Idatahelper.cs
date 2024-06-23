using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.DataBase
{
    public interface Idatahelper <T>
    {
        void Add(T item);
        void Delete(int? Id);
        List<T> GetAll();   
    }
}
