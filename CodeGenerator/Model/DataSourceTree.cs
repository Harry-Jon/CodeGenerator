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
        public DataSourceTree() 
        {
            Children = new List<DataSourceTree>();
        }
        public string Name { get; set; }
        public List<DataSourceTree> Children { get; set; }
        public void Add(DataSourceTree node)
        {
            this.Children.Add(node);
        }
    }
}
