using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shopping
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {

            protected void Page_Load(object sender, EventArgs e)
            {

            }

            public void name_ch(object sender, EventArgs e)
            {
                Class1 res = new Class1();
                if (TextBox1.Text != "")
                {
                    string name = TextBox1.Text;
                    bool flag = !res.doCheck(name, "name", "shop", "users");
                    if (flag)
                    Label1.Text = "用户名已被占用";
                    else
                        Label1.Text = "";
            }
                else
                    Label1.Text = "用户名不能为空";
            }


            protected void Button2_Click(object sender, EventArgs e)
            {
                //if (!Page.IsValid)
                //   Button2.Enabled = false;
                //else
                //{
                Class1 res = new Class1();
                if (!res.doCheck(TextBox1.Text, "name", "shop", "users"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该用户名已存在\");", true);
                    return;
                }
                if (!res.doCheck(TextBox6.Text, "mail", "shop", "users"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"邮箱已被注册\");", true);
                    return;
                }



                int i = res.Insert(TextBox1.Text, TextBox2.Text, TextBox8.Text, TextBox7.Text, TextBox5.Text, TextBox6.Text);
                if (i == 1)
                {

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"恭喜你，注册成功！！\");window.location='Login.aspx'", true);

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"注册失败\");", true);
                }


            }
        }
    }
