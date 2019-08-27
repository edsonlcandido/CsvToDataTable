using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CsvToDataTable
{
    public class CsvToDataTable
    {
        DataTable dataTable = new DataTable();
        private string _csvPath
        {
            get
            {

                return _csvPath;
            }
            set
            {
                _csvPath = value;
            }
        }
        public CsvToDataTable(string csvPath)
        {

        }
    }
}
