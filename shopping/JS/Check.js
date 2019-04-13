//首先我们创建一个XMLHttpRequest对象
//源码下载及讨论地址：http://www.51aspx.com/CV/AjaxCheckUser

    var xmlHttp;
    
    function createXmlHttpRequest()
    {
        if(window.XMLHttpRequest)
        {
            xmlHttp=new XMLHttpRequest();
        
            if(xmlHttp.overrideMimeType)
                {
                    xmlHttp.overrideMimeType("text/xml");
                }
        }
        else if(window.ActiveXObject)
        {
            try
            {
                xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");   
            }
            catch(e)
            {
                xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");   
            }
        }
        if(!xmlHttp)
        {
            window.alert("你的浏览器不支持创建XMLhttpRequest对象");
        }
        return xmlHttp;
    }

//创建CheckUserName
    
function CheckUserName(name)
{
   
        createXmlHttpRequest();
    
        var url="DisposeEvent.aspx?Name="+name+"&Event=Check";;
    
        xmlHttp.open("post",url,true);
    
        xmlHttp.onreadystatechange=CheckUserNameResult;
    
        xmlHttp.send(null);

}

//创建用户检测的回调函数

function CheckUserNameResult()
{
    if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
            if(xmlHttp.responseText=="true")
            {
                document.getElementById("imgflag").src="image/true.GIF";
                
                document.getElementById("btnReg").disabled=false;
                
                document.getElementById("btnlogin").disabled=true;
                
                document.getElementById("Password1").disabled=false;
                
            }
            else
            {
                document.getElementById("imgflag").src="image/false.GIF";
                
                document.getElementById("btnReg").disabled=true;
                
                document.getElementById("btnlogin").disabled=false;
                
                document.getElementById("Password1").disabled=true;
            }
        }
    }
}


//注册新的用户
function RegUser(Name,Pass)
{
    if(document.getElementById("UserName").value=="")
    {
        window.alert("用户名不能为空");
        
        document.getElementById("UserName").focus();
        
        return false;
    }
        if(document.getElementById("Password").value=="")
    {
        window.alert("密码不能为空");
        
        document.getElementById("Password").focus();
        
        return false;
    }
    if(document.getElementById("Password").value!=document.getElementById("Password1").value)
    {
        window.alert("确认密码错误");
        
        document.getElementById("Password1").focus();
        
        return false;
    }
    
        createXmlHttpRequest();
        
        var url="DisposeEvent.aspx?Name="+document.getElementById("UserName").value+"&Pass="+document.getElementById("Password").value+"&Event=Reg";
    
        xmlHttp.open("GET",url,true);
    
        xmlHttp.onreadystatechange=RegUserInfo;
    
        xmlHttp.send(null);
    
}
//创建注册用户的回调函数
function RegUserInfo()
{
        if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
            if(xmlHttp.responseText=="true")
            {
                window.alert("恭喜，新用户注册成功!");
                
                document.getElementById("UserName").value="";
                
                document.getElementById("Password").value="";
                
                document.getElementById("Password1").value="";
            }
            else
            {
               window.alert("对不起,你注册失败");
                
                document.getElementById("UserName").value="";
                
                document.getElementById("Password").value="";
                
                document.getElementById("Password1").value="";
            }
        }
    }
}

function Set()
{
    document.getElementById("imgflag").src="image/load.GIF";
    
    document.getElementById("btnReg").disabled=false;
    
    document.getElementById("Password1").disabled=false;
    
    document.getElementById("btnlogin").disabled=false;
}
function loginResult()
{
          if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
            if(xmlHttp.responseText=="true")
            {   
                location="http://www.51aspx.com/CV/AjaxCheckUser";
            }
            else
            {
               window.alert("对不起,你登录失败");
                
                document.getElementById("UserName").value="";
                
                document.getElementById("Password").value="";
                
                document.getElementById("Password1").value="";
            }
        }
    }

}
function login()
{

    if(document.getElementById("UserName").value=="")
    {
        window.alert("用户名不能为空");
        
        document.getElementById("UserName").focus();
        
        return false;
    }
        if(document.getElementById("Password").value=="")
    {
        window.alert("密码不能为空");
        
        document.getElementById("Password").focus();
        
        return false;
    }    
        createXmlHttpRequest();
        
        var url="DisposeEvent.aspx?Name="+document.getElementById("UserName").value+"&Pass="+document.getElementById("Password").value+"&Event=login";
    
        xmlHttp.open("GET",url,true);
    
        xmlHttp.onreadystatechange=loginResult;
    
        xmlHttp.send(null);
    
}
   
