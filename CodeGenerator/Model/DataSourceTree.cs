using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Model
{
    public class DataSourceTree
    {
        public string DataSourceName { get; set; }
        public List<DataBase> DatabaseList { get; set; }
    }


    public class Table
    {
        public string TableName { get; set; }
    }
    public class DataBase
    {
        public string DataBaseName { get; set; }
        public List<Table> TableList { get; set; }
    }


    public class TreeObject
    {
        public string Name { get; set; }
        public List<TreeObject> Children { get; set; }
    }
}
