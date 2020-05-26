using CodeGenerator.Model;
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

namespace CodeGenerator.View.ConnectionModal
{
    /// <summary>
    /// SQLConnectionModal.xaml 的交互逻辑
    /// </summary>
    public partial class SQLConnectionModal : Window
    {
        ViewModel.SQLConnectionViewModel viewModel;
        
        public SQLConnectionModal()
        {
            InitializeComponent();
            
            viewModel = new ViewModel.SQLConnectionViewModel();

            gridDetail.DataContext = viewModel;

        }
        public ViewModel.MainWindowViewModel mainWindowModel { get; set; } 


        public string ConnectionString { get; set; }//连接字符串
        //public int VerificationType { get; set; }

        public static List<DataSourceTree> dataSourceTreeList = new List<DataSourceTree>();



        //连接数据库
        private void Btn_Connection_Click(object sender, RoutedEventArgs e)
        {
            int txt_verification_typeVal = int.Parse(txt_verification_type.SelectedValue.ToString());//身份验证类型   Windows 身份认证  SQL Server 身份认证
            if (txt_verification_typeVal == 0)
            {
                ConnectionString = string.Format("Data Source={0};Integrated Security=SSPI;", viewModel.DataSource);
            }
            else
            {
                ConnectionString = string.Format("Data Source={0};uid={1};pwd={2};", viewModel.DataSource, viewModel.Uid, viewModel.Pwd);
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
            
            //string getDataBaseSqlString = "SELECT name FROM  master..sysdatabases WHERE name NOT IN ( 'master', 'model', 'msdb', 'tempdb', 'northwind','pubs' )";
            //DataSet DS_DataBase = DbHelperSQL.Query(getDataBaseSqlString);

            string getTablesSqlString = "SELECT name FROM " + txt_database.SelectedValue.ToString() + "..sysobjects Where xtype='U' ORDER BY name ";
            
            DataSet DS_Tables = DbHelperSQL.Query(getTablesSqlString);

            //string sqlString = "SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE,COLUMN_DEFAULT FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME=\'" + selectedTable + "\'  ";

            //DataTable dataSource = new DataTable();
            //dataSource.Columns.Add("Name", typeof(string));
            //dataSource.Columns.Add("ParentId", typeof(int));

            List<DataSourceTree> list = new List<DataSourceTree>();
            foreach (DataRow dr in DS_Tables.Tables[0].Rows)
            {
                DataSourceTree tree = new DataSourceTree();
                tree.Name = dr["name"].ToString();
                tree.Children = null;
                list.Add(tree);
            }
            DataSourceTree dataSourceTree = new DataSourceTree();
            dataSourceTree.Name = txt_server.Text;
            //dataSourceTree.Children = list;
            dataSourceTree.Children.Add(new DataSourceTree() { Name = txt_databaseVal, Children=list });

            //string jsonData = JsonHelper.Serialize(dataSourceTree);

            dataSourceTreeList.Add(dataSourceTree);
            mainWindowModel.DataSourceTreeList = null;
            mainWindowModel.DataSourceTreeList = dataSourceTreeList;
            this.Close();
        }


    }
}
