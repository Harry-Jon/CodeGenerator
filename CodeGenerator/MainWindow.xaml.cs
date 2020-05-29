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
            ServerTreeView.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.SQLConnectionModal connectionModal = new View.SQLConnectionModal();
            connectionModal.mainWindowModel = viewModel;
            connectionModal.ShowDialog();

        }

    }
}
