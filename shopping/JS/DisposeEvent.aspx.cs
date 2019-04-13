using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DisposeEvent : System.Web.UI.Page
{
    CheckUser cu = new CheckUser();

    AddUser au = new AddUser();

    logon go = new logon();

    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.QueryString["Event"])
        {
            case "Reg":
                if (au.AddUserS(Request.QueryString["Name"].ToString(), Request.QueryString["Pass"].ToString()))
                {
                    Response.Write("true");

                    Response.End();
                }
                else
                {
                    Response.Write("false");

                    Response.End();
                }
                break;

            case "Check":
                if (cu.CheckUsers(Request.QueryString["Name"].ToString()))
                {
                    Response.Write("false");

                    Response.End();
                }
                else
                {
                    Response.Write("true");

                    Response.End();
                }
                break;


            case "login":
                if (go.chklogon(Request.QueryString["Name"], Request.QueryString["Pass"]))
                {
                    Response.Write("true");

                    Response.End();
                }
                else
                {
                    Response.Write("false");

                    Response.End();
                }
                break;
        }
    }
}
