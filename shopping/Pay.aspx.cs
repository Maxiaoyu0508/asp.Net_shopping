using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace shopping
{
    public partial class Pay : System.Web.UI.Page
    {
        int RandKey;
        string Sum;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Class1 res = new Class1();
            string name = Convert.ToString( Session["name"]);
            SqlConnection con = res.GetConnection();
            SqlCommand cmd = new SqlCommand("select * from [OrderBase] where name=@name_o",con);
            cmd.Parameters.AddWithValue("@name_o",name);
            DataSet ds=new DataSet();
            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand=cmd;
            data.Fill(ds,"订单明细");
            GridView1.DataSource = ds.Tables["订单明细"].DefaultView;
            res.close(con);
            cmd = null;*/
            Random ran = new Random();
            RandKey = ran.Next(100000, 999999);
            Label2.Text = Convert.ToString(RandKey);
            Label3.Text = DateTime.Now.ToShortDateString();
            Sum = Request.QueryString["sum"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Class1 user_login = new Class1();
            md5 obj = new md5();
            obj.jiami(TextBox1.Text);
            bool flag = user_login.pay_check(TextBox1.Text, obj.Result);
            if (flag)
            {
                string name =Convert.ToString( Session["name"]);
                SqlConnection con = user_login.GetConnection();
                decimal money = Convert.ToDecimal(Sum);
                string data = DateTime.Now.ToShortDateString();
                Response.Write(data);
                user_login.Insert_o(RandKey, data, TextBox2.Text,TextBox3.Text,TextBox5.Text,TextBox4.Text,money);
                user_login.Check_p(name);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"支付成功！！，返回购物界面。\");window.location='shoppings.aspx'", true);
                user_login.Edit_do(name);

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"支付失败，密码错误！！请重新输入。\");", true);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("shoppings.aspx");
        }
    }
}