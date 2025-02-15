using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal interface JSONFileInterface
    {
        void ImportFromJSONFileToDataTable(string filePath);
    }
}
