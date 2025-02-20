using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    /// <summary>
    /// Ińterface for implementing the importing of JSON files
    /// </summary>
    internal interface JSONFileInterface
    {
        void ImportFromJSONFileToDataTable(string fileName);
    }
}
