using CodeGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
        }


        public List<DataSourceTree> _dataSourceTreeList;
        public List<DataSourceTree> DataSourceTreeList
        {
            get
            {
                return _dataSourceTreeList;
            }
            set
            {
                _dataSourceTreeList = value;
                RaisePropertyChanged("DataSourceTreeList");
            }
        }




    }
}
