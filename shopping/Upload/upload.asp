<%@ language="vbscript" codepage="65001" %>
<!--#include file="upfileclass.asp"-->
<%
response.Write server.MapPath("upload/"&"123")
response.End
response.charset="utf-8"
set upload=new UpFile_Class
upload.getdata(-1)'不限制大小，如果限制大小修改-1为其他数字，单位为kb
if upload.myerr<>-1 then'发生错误
  response.Write upload.myerr'发生错误，输出错误号给flash使用，3为不允许的文件后缀，要允许其他文件，自己修改u盘fileclass.asp中后缀扩展，默认为“gif,jpg,png,bmp,doc,pdf,zip,rar”
else
  set fn=upload.file("attachment")
  randomize
  ranNum=int(900*rnd)+100
  filename=SavePath&year(now)&month(now)&day(now)&hour(now)&minute(now)&second(now)&ranNum&"."&fn.fileExt
  fn.SaveToFile server.MapPath("upload/"+filename)
  session("fns")=filename&"，"&session("fns")'用session存储文件名，在添加文章时如果要获取已经上传的文件可以从session中获取，然后添加或者修改完毕后设置session("fns")=""
  response.Write "ok"'输出ok返回给flash，客户端flash再提供给js回调函数，js回调函数中判断返回值视为为ok判断是否上传成功
end if
set upload=nothing
 %>