using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    public interface DAOInterface<T> 
    {
        T GetByValueName(params string[] names);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Update(T element);
        void Delete(T element);
    }
}
