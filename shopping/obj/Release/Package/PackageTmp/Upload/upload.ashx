<%@ WebHandler Language="C#" Class="upload" %>

using System;
using System.Web;



/// <summary>
/// 文件上传处理页面
/// </summary>
public class upload : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{


    public void ProcessRequest(HttpContext context)
    {
        DateTime startTime = DateTime.Now;

        HttpPostedFile f = context.Request.Files["attachment"];

        string path = context.Server.MapPath("upload/");
        //context.Response.Write(path);
        if (f != null && f.FileName != "")
        {

            //context.Response.Write(1);
            // f.SaveAs(f.FileName);
            DateTime uploadEndTime = DateTime.Now;
            TimeSpan uploadTime = uploadEndTime - startTime;
            f.SaveAs(path + f.FileName);
            context.Response.Write(f.FileName);
            DateTime endTime = DateTime.Now;
            TimeSpan saveTime = endTime - uploadEndTime;
            //TimeSpan passTime = uploadTime + saveTime;
            TimeSpan passTime = endTime - startTime;
            string uploadPass = formatTime(uploadTime);
            string savePass = formatTime(saveTime);
            // string strPass = passTime.TotalMilliseconds.ToString()
            string strPass = formatTime(passTime);
            string pass = formatTime(passTime);

            //double ss=passTime.TotalSeconds;




            context.Response.Write("-->上传用时：" + uploadPass + "，保存用时：" + savePass + "，总共用时：" + strPass);
        }
        else context.Response.Write(f == null);
    }
    string formatTime(TimeSpan t)
    {
        if (t.Hours > 0)
            return t.Hours.ToString() + "小时" + t.Minutes.ToString() + "分" + t.Seconds.ToString() + "秒";
        else if (t.Minutes > 0)
            return t.Minutes.ToString() + "分" + t.Seconds.ToString() + "秒";
        else if (t.Seconds > 0)
            return Math.Round(t.TotalSeconds, 2).ToString() + "秒";
        else
        {
            if (t.Milliseconds < 10)
                return Math.Round(t.TotalSeconds, 3).ToString() + "秒";
            else
                return Math.Round(t.TotalSeconds, 2).ToString() + "秒";
        }


    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}

