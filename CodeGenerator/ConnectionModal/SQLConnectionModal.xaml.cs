using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace CodeGenerator.ConnectionModal
{
    /// <summary>
    /// SQLConnectionModal.xaml 的交互逻辑
    /// </summary>
    public partial class SQLConnectionModal : Window
    {
        ViewModel.SQLConnection viewModel;
        public SQLConnectionModal()
        {
            InitializeComponent();
            viewModel = new ViewModel.SQLConnection();
            gridDetail.DataContext = viewModel;
        }

        public string ConnectionString { get; set; }//连接字符串
        //public int VerificationType { get; set; }

        

        //连接数据库
        private void Btn_Connection_Click(object sender, RoutedEventArgs e)
        {
            string Test = viewModel.DataBase;
            string txt_serverVal = txt_server.Text;//服务器名称
            int txt_verification_typeVal = int.Parse(txt_verification_type.SelectedValue.ToString());//身份验证类型   Windows 身份认证  SQL Server 身份认证
            string txt_accountVal = txt_account.Text;//登录名
            string txt_pwdVal = txt_pwd.Password;//登录密码
            if (txt_verification_typeVal == 0)
            {
                ConnectionString = string.Format("Data Source={0};Integrated Security=SSPI;", txt_serverVal);
            }
            else
            {
                ConnectionString = string.Format("Data Source={0};uid={1};pwd={2};", txt_serverVal, txt_accountVal, txt_pwdVal);
            }

            DbHelperSQL.ConnectionString = ConnectionString;
            string tableName = "master..sysdatabases";
            string fieldSelect = "name";
            string strWhere = fieldSelect + " NOT IN ( 'master', 'model', 'msdb', 'tempdb', 'northwind','pubs' )";
            DataTable dt = DbHelperSQL.GetDataTable(tableName, fieldSelect, strWhere);
            if (dt != null)
            {
                MessageBox.Show("连接成功！");
                txt_database.ItemsSource = dt.DefaultView;
                txt_database.SelectedValuePath = fieldSelect;
                txt_database.DisplayMemberPath = fieldSelect;
                txt_database.SelectedIndex = 0;
            }
            
        }


        private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            string txt_databaseVal = txt_database.SelectedValue.ToString();//数据库
            ConnectionString += "Initial Catalog:" + txt_databaseVal + ";";
            DbHelperSQL.ConnectionString = ConnectionString;
        }
    }
}
