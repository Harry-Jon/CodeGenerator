using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Model
{
    public class SQLConnection
    {
        public string ConnectionString { get; set; }


        public string DataSource { get; set; } = Environment.MachineName;//数据库
        public int AuthenticationType { get; set; }//认证类型
        public string Uid { get; set; }//用户名
        public string Pwd { get; set; }//用户密码
        public string DataBase { get; set; }//数据库


        
    }
}
