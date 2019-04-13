using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

    public partial class none : System.Web.UI.Page
    {
        string sjklj = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";//设置输出类型
            if (Request.QueryString["chuandi"] != null)
            {
                string name = Request.QueryString["chuandi"].ToString().Trim();
                if (name.Length > 0)
                {
                    if (shifou(name))
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
                else
                {
                    Response.Write("false");
                }
            }
            else
            {
                Response.Write("false");
            }
        }

        protected bool shifou(string name)
        {
            string sql = "select * from users where name=@name";
            using (SqlConnection conn = new SqlConnection(sjklj))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@name", name) });
                if (cmd.ExecuteScalar() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }