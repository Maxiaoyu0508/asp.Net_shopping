using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace shopping
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Class1 user_login = new Class1();
            //SHA1CryptoServiceProvider sha1csp = new SHA1CryptoServiceProvider();
            // byte[] src = System.Text.Encoding.UTF8.GetBytes(TextBox2.Text);
            //byte[] des = sha1csp.ComputeHash(src);
            md5 obj = new md5();
            obj.jiami(TextBox2.Text);
            bool flag = user_login.login_check(TextBox1.Text, obj.Result);
            int i = user_login.Multiple(TextBox1.Text);
            //Response.Write(TextBox1.Text+"<br>");
            //Response.Write(obj.Result); 
            if (Session["CheckCode"] != null)
            {
                if (Session["CheckCode"].ToString().ToUpper() == TextBox5.Text.Trim().ToString().ToUpper())
                //这样写可以不能区分大小写
                {
                    //Response.Write("Session is right");
                    if (flag&&i==0)
                    {
                        if (TextBox1.Text == "admin")
                        {
                            Session["name"] = TextBox1.Text;
                            user_login.Multiple_u(TextBox1.Text);
                            Response.Redirect("Management.aspx");
                           
                        }
                            
                        else
                        {
                            Session["name"] = TextBox1.Text;
                            user_login.Multiple_u(TextBox1.Text);
                            Response.Redirect("shoppings.aspx");
                            
                        }
                        

                    }
                    else
                    {
                        if (i==1)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该用户已经在线！！\");", true);
                        }
                        else
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"密码或者用户名错误！！\");", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"验证码错误！！\");", true);
                    
                }
 
            }
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"请输入验证码！！\");", true);
        }

       
    }
}