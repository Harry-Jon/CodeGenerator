using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModel
{
    public class SQLConnectionViewModel : ViewModelBase
    {
        Model.SQLConnectionString model;
        public SQLConnectionViewModel()
        {
            model = new Model.SQLConnectionString();
        }
        public string ConnectionString { get; set; }

        public string DataSource //数据库
        {
            get { return model.DataSource; }
            set
            {
                model.DataSource = value;
                RaisePropertyChanged("DataSource");
            }
        }
        public int AuthenticationType //认证类型
        {
            get { return model.AuthenticationType; }
            set
            {
                model.AuthenticationType = value;
                RaisePropertyChanged("AuthenticationType");
            }
        }
        public string Uid //用户名
        {
            get { return model.Uid; }
            set
            {
                model.Uid = value;
                RaisePropertyChanged("Uid");
            }
        }
        public string Pwd //用户密码
        {
            get { return model.Pwd; }
            set
            {
                model.Pwd = value;
                RaisePropertyChanged("Pwd");
            }
        }
        public string DataBase //数据库
        {
            get { return model.DataBase; }
            set
            {
                model.DataBase = value;
                RaisePropertyChanged("DataBase");
            }
        }

    }
}
