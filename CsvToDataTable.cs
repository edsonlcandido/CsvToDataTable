using System;
using System.Data;
using System.IO;

namespace CsvToDataTable
{
    public class CSV2DT
    {
        private DataTable _dataTable;
        private string _csvPath;
        public string csvPath
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
            set
            {
                _csvPath = value;
            }
        }
        public DataTable dataTable
        {
            get
            {
                return stringToDataTable(csvContent, true);
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

        private void stringToDataTable(string csvContent)
        {
            _dataTable = new DataTable("table");
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
                            _dataTable.Columns.Add(header);
                        }
                    }
                    else
                    {
                        string[] dataCells = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        _dataTable.Rows.Add(dataCells);
                    }
                    i++;
                }
            }
        }

        private DataTable stringToDataTable(string csvContent, bool dataTable)
        {
            _dataTable = new DataTable("table");
            string[] allLines = csvContent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (allLines.Length >= 2 && dataTable)
            {
                int i = 0;
                foreach (string line in allLines)
                {
                    if (i == 0)
                    {
                        string[] headers = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string header in headers)
                        {
                            _dataTable.Columns.Add(header);
                        }
                    }
                    else
                    {
                        string[] dataCells = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        _dataTable.Rows.Add(dataCells);
                    }
                    i++;
                }
                return _dataTable;
            }
            else
            {
                throw new Exception();
            }
        }

        public DataTable dataTableExample()
        {
            stringToDataTable(csvContent);
            return _dataTable;
        }
    }
}
