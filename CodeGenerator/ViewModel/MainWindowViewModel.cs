using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
        }


        public List<DataSourceTree> _dataSourceTreeList;
        public List<DataSourceTree> dataSourceTreeList 
        {
            get 
            {
                return _dataSourceTreeList;
            }
            set 
            {
                _dataSourceTreeList = value;
                NotifyPropertyChanged("dataSourceTreeList");
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
