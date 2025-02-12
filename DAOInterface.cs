using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal interface DAOInterface<T>
    {
        T GetByValueName(string name);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Update(T element);
        void Delete(T element);
    }
}
