using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

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

        private StreamReader _sr
        {
            get
            {
                return new StreamReader(_csvPath);
            }
        }

        public CsvToDataTable()
        {
        }

        public CsvToDataTable(string csvPath)
        {
            this._csvPath = csvPath;            
        }

        private void streamReaderToDataTable()
        {
            string[] headers = _sr.ReadLine().Split(';');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
        }

        public DataTable dataTableExample()
        {
            this._csvPath = "IECMotorFrameSize.csv";
            streamReaderToDataTable();
            return dataTable;
        }
    }
}
