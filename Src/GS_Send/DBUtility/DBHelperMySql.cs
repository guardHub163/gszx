using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CZZD.GSZX.S.DBUtility
{
    public class DBHelperMySql
    {
        //引导数据库连接数据库调用Web.Config文件      
        private static MySqlConnection connection;
        //"server=localhost;userid=root;password=czzd;database=vtigercrm540;CharSet=utf8;port=33307;"
        public static string connectionString = PubConstant.GetMySqlConnectionString();
        //创建连接  
        public static MySqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new MySqlConnection(connectionString);
                    //打开连接  
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        //（无参）返回执行的行数(删除修改更新)  
        public static int ExecuteCommand(string safeSql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(safeSql, conn);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //（无参事务处理）返回执行的行数(删除修改更新)  
        public static int ExecuteCommandTrans(List<string> sqlList)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int result = 0;
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    MySqlTransaction t = Connection.BeginTransaction();
                    try
                    {
                        foreach (string sql in sqlList)
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        t.Commit();
                        result = 1;
                    }
                    catch (Exception ex)
                    {
                        t.Rollback();
                        throw ex;
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //（有参）  
        public static int ExecuteCommand(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddRange(values);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //（有参事务处理）  
        public static int ExecuteCommandTrans(List<MySqlCommandInfo> sqlList)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int result = 0;
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    MySqlTransaction t = Connection.BeginTransaction();
                    try
                    {
                        foreach (MySqlCommandInfo cmdInfo in sqlList)
                        {
                            cmd.CommandText = cmdInfo.CommandText;
                            cmd.Parameters.AddRange(cmdInfo.Parameters);
                            cmd.ExecuteNonQuery();
                        }
                        t.Commit();
                        result = 1;
                    }
                    catch (Exception ex)
                    {
                        t.Rollback();
                        throw ex;
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //（无参）返回第一行第一列(删除修改更新)  
        public static int GetScalar(string safeSql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(safeSql, conn);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //（有参）  
        public static int GetScalar(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddRange(values);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //返回一个DataReader（查询）  
        public static MySqlDataReader GetReader(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static MySqlDataReader GetReader(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        //返回一个DataTable  
        public static DataTable GetDataSet(string safeSql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    MySqlCommand cmd = new MySqlCommand(safeSql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 返回一个DataTable  
        /// </summary>
        public static DataTable GetDataSet(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddRange(values);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        /// <summary>
        /// 返回第一行每一列
        /// </summary>
        public static object GetSingle(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.Parameters.AddRange(values);
                        Object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 返回第一行每一列
        /// </summary>
        public static object GetSingle(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        Object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }//end class

}
