<%@ WebHandler Language="C#" Class="fileDelete" %>

using System;
using System.Web;
using System.IO;

public class fileDelete : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string strRoot = context.Server.MapPath("upload");
        string[] filePath = Directory.GetFiles(strRoot);
        //    int length = filePath.Length;
        //    int i = 0;
        //    if (length > 0)
        //    {
        //        for (i = 0; i < length; i++) 
        //        {
        //            File.Delete(filePath[i]);
        //            if (!File.Exists(filePath[i]))
        //                context.Response.Write("文件删除成功:" + Path.GetFileName(filePath[i]) + "<br>");

        //        }

        //    }
        //    else

        //    { context.Response.Write("没有找到要删除的文件"); }

        if (filePath.Length == 0)
            context.Response.Write("对应文件夹里没有要删除的文件");
        else
           
            foreach (string strFile in filePath)
            {
                //FileInfo fi = new FileInfo(strFile);
               //context.Response.Write(fi.Length+"<br/>");
                File.Delete(strFile);
                if (!File.Exists(strFile))
                    context.Response.Write("文件删除成功："+Path.GetFileName(strFile) + "<br/>");
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