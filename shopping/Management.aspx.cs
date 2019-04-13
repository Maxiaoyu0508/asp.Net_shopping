using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace shopping
{
    public partial class Management : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

        }
      


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {    
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }
        //删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Class1 res = new Class1();
            int userLoginNameOfTopic = Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Text);
            SqlConnection con = res.GetConnection();
            //SqlCommand com = new SqlCommand();
            //btnDelRow.Attributes.Add("onclick", "return confirm('确定要删吗?');");
            res.Delete_M(userLoginNameOfTopic, con);
            GridView1.DataBind();
            con.Close();
            bind();
           // SqlConnection sqlcon;
            //Page_Load();
            //Response.Write(GridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Text);
        }
        //更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            //string sqlstr = "update [Product] set Title='"
            //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',Price='"
            //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',Num='"
            //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where ID='"
            //    + Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[1].Text) + "'";
            try
            {
                Class1 res = new Class1();
                int userLoginNameOfTopic = Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Text);
                string name = Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text);
                decimal mon = Convert.ToDecimal(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
                int num = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text);
                
           
            

            int i = res.Edit1(name, mon, num, userLoginNameOfTopic);
            if (i > 0)
            {
                Response.Write("<script language=javascript>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
            GridView1.EditIndex = -1;
            bind();
            }
            catch (Exception error)
            {
                Response.Write("<script language=javascript>alert('数据类型错误！')</script>");
            }
            //cmd.CommandText = "update [Product] set Title=@bb,Price=@aa,Num=@cc where ID=@dd";

            /*string str = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string name = "huawei";
            decimal mon = Convert.ToDecimal(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            int num = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text);
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Personal"].ConnectionString);
            SqlCommand comm = new SqlCommand("update [Product] set Price='" + mon + "' , Num='" + num + "' where ID='" + Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Text) + "'", conn);
            try
            {
                int i = Convert.ToInt32(comm.ExecuteNonQuery());
                if (i > 0)
                {
                    Response.Write("<script language=javascript>alert('保存成功！')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('保存失败！')</script>");
                }
               
                GridView1.EditIndex = -1;
                //e.Cancel = true;
                 bind();
            }
            catch (Exception erro)
            {
                Response.Write("错误信息:" + erro.Message);
            }
            finally
            {
                conn.Close();
            }*/
        }
        //取消
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
        //绑定
        public void bind()
        {
            Class1 res = new Class1();
            SqlConnection con;
            con = res.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select ID,Title,Price,Num from [product]", con);
            da.SelectCommand = com;
            DataSet ds = new DataSet();
            da.Fill(ds, "product");
            GridView1.DataSource = ds;
            //GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
            res.close(con);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 res = new Class1();
                int userLoginNameOfTopic = Convert.ToInt32(TextBox1.Text);
                string name = Convert.ToString(TextBox2.Text);
                decimal mon = Convert.ToDecimal(TextBox3.Text);
                int num = Convert.ToInt32(TextBox4.Text);
                int i = res.Insert_p(name, mon, num, userLoginNameOfTopic);
                if (i > 0)
                {
                    Response.Write("<script language=javascript>alert('添加成功！')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('添加失败！')</script>");
                }
                bind();
            }
            catch (Exception error)
            {
                Response.Write("<script language=javascript>alert('数据类型错误！')</script>");
            }
        }

        protected void ID_ch(object sender, EventArgs e)
        {
            try
            {
                Class1 res = new Class1();
                int id = Convert.ToInt32(TextBox1.Text);
                bool flag = res.procheck(id);
                if (flag)
                {
                    Label1.Text = "该ID产品已存在！！！";
                    
                }
                else
                    Label1.Text = "";
            }
            catch (Exception error)
            {
                if (TextBox1.Text != "")
                {
                    Label1.Text = "数据类型不正确！！";
                }
                else
                {
                    Label1.Text = "商品ID不能为空！！";
                }
                
            }

            
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Class1 res = new Class1();
            string user_name = Convert.ToString(Session["name"]);
            res.Multiple_N(user_name);
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Upload/index.html");
        }
    }
}