using CodeGenerator.Model;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel.MainWindowViewModel();
            dataSourceTreeView.DataContext = viewModel;
        }
        //public static List<DataSourceTree> dataSourceTreeList = new List<DataSourceTree>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.ConnectionModal.SQLConnectionModal connectionModal = new View.ConnectionModal.SQLConnectionModal();
            //View.ConnectionModal.SQLConnectionModal
            connectionModal.mainModel = viewModel;
            connectionModal.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List <DataSourceTree> test = new List<DataSourceTree>()
            {
                new Model.DataSourceTree{ Name="服务器1", Children=new List<Model.DataSourceTree>()
                {
                    new Model.DataSourceTree{ Name="数据库1",Children=new List<Model.DataSourceTree>()
                    {
                        new Model.DataSourceTree{ Name="表1",Children=null}
                    } },
                    new Model.DataSourceTree{ Name="数据库2",Children=new List<Model.DataSourceTree>()
                    {
                        new Model.DataSourceTree(){ Name="表2",Children=null}
                    } }
                } },

            };
            viewModel.dataSourceTreeList = test;
        }
    }
}
