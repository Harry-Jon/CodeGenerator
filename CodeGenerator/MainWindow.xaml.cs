using CodeGenerator.Model;
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
            dataSourceTreeView.ItemsSource = dataSourceTreeList;
        }
        public List<DataSourceTree> dataSourceTreeList = new List<DataSourceTree>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.ConnectionModal.SQLConnectionModal connectionModal = new View.ConnectionModal.SQLConnectionModal();
            connectionModal.ShowDialog();

        }
    }
}
