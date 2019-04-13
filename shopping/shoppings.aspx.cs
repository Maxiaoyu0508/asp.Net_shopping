using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



namespace shopping
{
    public partial class shoppings : System.Web.UI.Page
    {
        public int oid = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text="3";
            //Response.SelectCommand = "SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] ";
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] WHERE [CategoryID]='3'";


        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] WHERE [CategoryID]='1'";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] WHERE [CategoryID]='2'";

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] WHERE [CategoryID]='4'";

        }


        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            //if(Session["name"]=)
            if (e.CommandName == "Bt_c")
            {
                //
                
                string user_name = Convert.ToString(Session["name"]);
                int userLoginNameOfTopic = Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                int num =Convert.ToInt32(( GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("CallInIdSelControl") as DropDownList).SelectedValue.ToString());
                //(this.GridView1.Rows[i].Cells[列索引].FindControl("下拉列表的ID") as DropDownList).SelectedValue.ToString();
                //Class1 res = new Class1();
                Object obj=new Object();
                Object order_obj;
                order_obj=obj.product(userLoginNameOfTopic);
                //obj.product(userLoginNameOfTopic);
                //int a = obj.product(1).id;
                //Response.Write(userLoginNameOfTopic);
                Class1 res = new Class1();
                //SqlConnection con = res.GetConnection();
                if (num > 0)
                {
                    res.Insert_c(oid, oid, order_obj.id, order_obj.price, num, user_name, order_obj.name,0);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"商品无货！！\");", true);

                }
                //Response.Write(user_name);

            }            

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("shoppings.aspx");
        }



        protected void Button7_Click(object sender, EventArgs e)//测试session名字
        {
            Object obj = new Object();
            int a=obj.product(1).id;
            Response.Write(a);
            string user_name = Convert.ToString(Session["name"]);
            Response.Write(user_name);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gwc.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Class1 res = new Class1();
            string user_name = Convert.ToString(Session["name"]);
            res.Multiple_N(user_name);
            Response.Redirect("Login.aspx");

        }
    }
}