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
//该源码下载自www.51aspx.com(５１ａｓpｘ．ｃｏｍ)

/// <summary>
/// CheckUser 的摘要说明
/// </summary>
namespace shopping
{
    public class CheckUser
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shop"].ConnectionString);

        public CheckUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public bool CheckUsers(String name)
        {
            String T_name = name;

            String sql = "select * from users where name='" + T_name + "'";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();

                SqlDataReader MyReader = cmd.ExecuteReader();

                if (MyReader.Read())
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
