using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DbHelperSQL
    {
        public static string ConnectionString { get; set; }
        public static DataSet Query(string strSql)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSql, connection);
                    sqlDataAdapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        //选择一行数据
        public static DataRow GetDataRow(string tableName, string fieldSelect, string strWhere)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 ");
                strSql.Append("" + fieldSelect + " ");
                strSql.Append("from " + tableName + " ");
                if (strWhere != "")
                {
                    strSql.Append("where " + strWhere + "");
                }
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(strSql.ToString(), connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    return dt.Rows[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }


            }
        }

        public static DataTable GetDataTable(string tableName, string fieldSelect, string strWhere)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                strSql.Append("" + fieldSelect + " ");
                strSql.Append("from " + tableName + " ");
                if (strWhere != "")
                {
                    strSql.Append("where " + strWhere + " ");
                }
                try
                {
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSql.ToString(), connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
