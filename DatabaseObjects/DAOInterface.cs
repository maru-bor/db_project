using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{

    /// <summary>
    /// Interface for implementing the DAO design pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface DAOInterface<T> 
    {
        T GetByValueName(params string[] names);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Update(T previousElement, T updatedElement);
        void Delete(T element);
    }
}
