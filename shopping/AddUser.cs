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
//该源码下载自www.51aspx.com(５1ａｓｐｘ．ｃｏｍ)

/// <summary>
/// AddUser 的摘要说明
/// </summary>

namespace shopping
{
    public class AddUser
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shop"].ConnectionString);

        public AddUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public bool AddUserS(String name, String pass)
        {
            String T_name = name;

            String T_pass = pass;

            String sql = "insert into info values('" + T_name + "','" + T_pass + "')";

            SqlCommand cmd = new SqlCommand(sql, con);

            int Result = -1;

            try
            {
                con.Open();

                Result = cmd.ExecuteNonQuery();

                if (Result != -1)
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
            return false;
        }
    }
}
