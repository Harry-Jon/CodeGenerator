using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModel
{
    public class SQLConnection : INotifyPropertyChanged
    {
        Model.SQLConnection model;
        public SQLConnection()
        {
            model = new Model.SQLConnection();
        }
        public string ConnectionString { get; set; }

        public string DataSource //数据库
        {
            get { return model.DataSource; }
            set
            {
                model.DataSource = value;
                NotifyPropertyChanged("DataSource");
            }
        }
        public int AuthenticationType //认证类型
        {
            get { return model.AuthenticationType; }
            set
            {
                model.AuthenticationType = value;
                NotifyPropertyChanged("AuthenticationType");
            }
        }
        public string Uid //用户名
        {
            get { return model.Uid; }
            set
            {
                model.Uid = value;
                NotifyPropertyChanged("Uid");
            }
        }
        public string Pwd //用户密码
        {
            get { return model.Pwd; }
            set
            {
                model.Pwd = value;
                NotifyPropertyChanged("Pwd");
            }
        }
        public string DataBase //数据库
        {
            get { return model.DataBase; }
            set
            {
                model.DataBase = value;
                NotifyPropertyChanged("DataBase");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
