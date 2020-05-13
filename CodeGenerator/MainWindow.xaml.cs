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
        public MainWindow()
        {
            InitializeComponent();

            List<Model.Table> tables = new List<Model.Table>()
            {
                new Model.Table{ TableName="表1"},
                new Model.Table{ TableName="表2"}
            };
            List<Model.DataBase> dataBases = new List<Model.DataBase>()
            {
                new Model.DataBase{ DataBaseName="数据库1", TableList=tables},
                new Model.DataBase{ DataBaseName="数据库2", TableList=tables}
            };
            List<Model.DataSourceTree> dataSourceTrees = new List<Model.DataSourceTree>()
            {
                new Model.DataSourceTree{ DataSourceName="服务器1", DatabaseList=dataBases},
                new Model.DataSourceTree{ DataSourceName="服务器2", DatabaseList=dataBases}
            };
            //DataSourceTreeView.ItemsSource = dataSourceTrees;

            List<Model.TreeObject> list = new List<Model.TreeObject>()
            {
                new Model.TreeObject{ Name="服务器1", Children=new List<Model.TreeObject>()
                {
                    new Model.TreeObject{ Name="数据库1",Children=new List<Model.TreeObject>()
                    {
                        new Model.TreeObject{ Name="表1",Children=null}
                    } },
                    new Model.TreeObject{ Name="数据库2",Children=new List<Model.TreeObject>()
                    {
                        new Model.TreeObject(){ Name="表2",Children=null}
                    } }
                } },

            };
            DataSourceTreeView.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.ConnectionModal.SQLConnectionModal connectionModal = new View.ConnectionModal.SQLConnectionModal();
            connectionModal.Show();

        }
    }
}
