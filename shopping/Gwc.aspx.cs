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
    public partial class Gwc : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        { 
             Class1 res = new Class1();
            string Name = Convert.ToString(Session["name"]);
            string id = Convert.ToString(Session["name"]);
            decimal num = res.P_sum(Name);
            Label2.Text = Convert.ToString(num);
            // SqlConnection con= res.GetConnection();
            //  SqlCommand com = new SqlCommand("SELECT [ID], [ProductID], [Price], [pname], [Quantity] FROM [OrderDetail] WHERE name=@name_aa AND Done=0",con);
            //  com.Parameters.AddWithValue("@name_aa",Name);
            //SqlDataSource1.DataSourceMode=com.ExecuteNonQuery();
            // SqlDataSource1.SelectCommand = "SELECT [ID], [ProductID], [Price], [pname], [Quantity] FROM [OrderDetail] WHERE name=Name AND Done=0";
            if (!IsPostBack)
            {
                Show(Name);
            }
            

        }

        protected void Show(string a)
        {
            Class1 res = new Class1();
            SqlConnection con;
            con = res.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand com = new SqlCommand("select ID,ProductID,Price,pname,Quantity from [OrderDetail] where name=@name_u and Done=0", con);
            com.Parameters.AddWithValue("@name_u",a);
            da.SelectCommand = com;
            DataSet ds = new DataSet();
            da.Fill(ds, "product");
            GridView2.DataSource = ds.Tables["product"].DefaultView;
            GridView2.DataBind();
            res.close(con);
            com = null;

        }
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if(Session["name"]=)

            Class1 res = new Class1();
            if (e.CommandName == "Bt_c")
            {
                //string user_name = Convert.ToString(Session["name"]);
                int userLoginNameOfTopic = Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
                //int num = Convert.ToInt32((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("CallInIdSelControl") as DropDownList).SelectedValue.ToString());
                SqlConnection con = res.GetConnection();
                //SqlCommand com = new SqlCommand();
                res.Delete(userLoginNameOfTopic,con);
                GridView1.DataBind();
                //Response.Write(userLoginNameOfTopic);

            }
            //Class1 res = new Class1();
            string name = Convert.ToString(Session["name"]);
            decimal num = res.P_sum(name);
            Label2.Text = Convert.ToString(num);

        }


        protected void GridView_OnRowCommand1(object sender, GridViewCommandEventArgs e)
        {
            //if(Session["name"]=)
            string Name = Convert.ToString(Session["name"]);
            Class1 res = new Class1();
            if (e.CommandName == "Bt_c")
            {
                //string user_name = Convert.ToString(Session["name"]);
                int userLoginNameOfTopic = Convert.ToInt32(GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
                //int num = Convert.ToInt32((GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("CallInIdSelControl") as DropDownList).SelectedValue.ToString());
                SqlConnection con = res.GetConnection();
                //SqlCommand com = new SqlCommand();
                res.Delete(userLoginNameOfTopic, con);
                //GridView2.DataBind();
                Show(Name);
                //Response.Write(userLoginNameOfTopic);

            }
            //Class1 res = new Class1();
            string name = Convert.ToString(Session["name"]);
            decimal num = res.P_sum(name);
            Label2.Text = Convert.ToString(num);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("shoppings.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Class1 res = new Class1();
            string name = Convert.ToString(Session["name"]);
            decimal num = res.P_sum(name);
            Label2.Text = Convert.ToString(num);
        }

        protected void Button2_Click(object sender, EventArgs e)
        { 
           
            string s_url; 
            s_url = "Pay.aspx?sum=" + Label2.Text;
            if (Label2.Text != "0")
            {
            Response.Redirect(s_url);
            //int userLoginNameOfTopic = Convert.ToInt32(GridView1.Rows[].Cells[1].Text);
            }
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"购物车为空！！\");", true);
        }
    }
}