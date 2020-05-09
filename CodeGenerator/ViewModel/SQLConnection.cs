using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModel
{
    public class SQLConnection: INotifyPropertyChanged
    {
        public string ConnectionString { get; set; }

        private string _dataSource;
        private int _authenticationType;
        private string _uid;
        private string _pwd;
        private string _dataBase;
        public string DataSource //数据库
        {
            get => _dataSource;
            set => NotifyPropertyChanged("DataSource");
        }
        public int AuthenticationType //认证类型
        {
            get => _authenticationType;
            set => NotifyPropertyChanged("AuthenticationType");
        }
        public string Uid //用户名
        {
            get => _uid;
            set => NotifyPropertyChanged("Uid");
        }
        public string Pwd //用户密码
        {
            get => _pwd;
            set => NotifyPropertyChanged("Pwd");
        }
        public string DataBase //数据库
        {
            get => _dataBase;
            set => NotifyPropertyChanged("DataBase");
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
