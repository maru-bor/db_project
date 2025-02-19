using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    /// <summary>
    /// Ińterface for implementing import of JSON files
    /// </summary>
    internal interface JSONFileInterface
    {
        /// <summary>
        /// Reads JSON data from a file
        /// </summary>
        /// <param name="fileName"></param>
        void ImportFromJSONFileToDataTable(string fileName);
    }
}
