using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

/// <summary>
/// logon 的摘要说明
/// </summary>
namespace shopping
{
    public class logon
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString);
        public logon()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public bool chklogon(string uername, string password)
        {
            //    string name = uername;
            //    string pwd = password;
            //    String str = "select top 1 password from info where username='"+name+"'";
            //    SqlCommand cmd = new SqlCommand(str, con);
            //    try
            //    {
            //        con.Open();

            //        SqlDataReader resu = cmd.ExecuteReader();

            //        if (resu.Read())
            //        {
            //            if (resu.GetValue(0).ToString() == pwd)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //51-A-s-p-x.com           
            //    }
            //    catch (Exception ex)
            //    {
            //        throw (ex);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }

            //    return false;
            //    //if(name.Equals(str))
            String T_name = uername;

            String T_pass = password;

            String sql = "select * from info where UserName='" + T_name + "' and Password='" + T_pass + "'";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();

                SqlDataReader da = cmd.ExecuteReader();

                if (da.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
