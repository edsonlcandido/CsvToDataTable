using System;
using System.Data;
using System.IO;

namespace CsvToDataTable
{
    public class CSV2DT
    {
        private DataTable dataTable = new DataTable("table");
        private string _csvPath;
        private string csvPath
        {
            get
            {
                if (_csvPath != null)
                {
                    return _csvPath;
                }
                else
                {
                    return "IECMotorFrameSize.csv";
                }                
            }
        }

        private string csvContent
        {
            get
            {
                return File.ReadAllText(csvPath);
            }
        }

        public CSV2DT()
        {
        }

        public CSV2DT(string csvPath)
        {
            this._csvPath = csvPath;            
        }

        public CSV2DT(string csvPath, char[] delimiter)
        {
            this._csvPath = csvPath;
        }

        private void streamReaderToDataTable(string csvContent)
        {
            string[] allLines = csvContent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (allLines.Length >= 2)
            {
                int i = 0;
                foreach (string line in allLines)
                {
                    if (i == 0)
                    {
                        string[] headers = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }
                    }
                    else
                    {
                        string[] dataCells = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        dataTable.Rows.Add(dataCells);
                    }
                    i++;
                }
            }
        }

        public DataTable dataTableExample()
        {
            streamReaderToDataTable(csvContent);
            return dataTable;
        }
    }
}
