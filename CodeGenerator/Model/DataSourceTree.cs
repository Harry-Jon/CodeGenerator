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

    public class DepartmentModel
    {
        public List<DepartmentModel> Nodes { get; set; }
        public DepartmentModel()
        {
            this.Nodes = new List<DepartmentModel>();
            this.ParentId = 0;//主节点的父id默认为0
        }
        public int id { get; set; }//id
        public string deptName { get; set; }//部门名称
        public int ParentId { get; set; }//父类id
    }
}
