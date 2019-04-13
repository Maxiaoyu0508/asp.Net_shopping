<%
dim oUpFileStream
'----------------------------------------------------------------------
Class UpFile_Class
Dim Form,File,Version,MyErr

Private Sub Class_Initialize
 Version = "无惧上传类 Version V1.2"
 MyErr = -1
End Sub

Private Sub Class_Terminate  
  '清除变量及对像
  If Err < 0 Then
    Form.RemoveAll
    Set Form = Nothing
    File.RemoveAll
    Set File = Nothing
    oUpFileStream.Close
    Set oUpFileStream = Nothing
  End If
End Sub
   
Public Sub GetData (MaxSize)
   '定义变量
  Dim RequestBinData,sSpace,bCrLf,sInfo,iInfoStart,iInfoEnd,tStream,iStart,oFileInfo
  Dim iFileSize,sFilePath,sFileType,sFormValue,sFileName
  Dim iFindStart,iFindEnd
  Dim iFormStart,iFormEnd,sFormName
   '代码开始
  If Request.TotalBytes<=0 Then  '如果没有数据上传
    MyErr = 0
    Exit Sub
  End If
  'on error resume next
  Set Form = Server.CreateObject ("Scripting.Dictionary")
  Form.CompareMode = 1
  Set File = Server.CreateObject ("Scripting.Dictionary")
  File.CompareMode = 1
  Set tStream = Server.CreateObject ("ADODB.Stream")
  Set oUpFileStream = Server.CreateObject ("ADODB.Stream")
  oUpFileStream.Type = 1
  oUpFileStream.Mode = 3
  oUpFileStream.Open 
  'on error resume next
  oUpFileStream.Write Request.BinaryRead (Request.TotalBytes)
  
  if err<>0 then
    MyErr=0'the file size over the iis max size defined
    Err.Clear
    exit sub
  end if
  on error goto 0
  oUpFileStream.Position = 0
  RequestBinData = oUpFileStream.Read 
  iFormEnd = oUpFileStream.Size
  bCrLf = ChrB (13) & ChrB (10)
  '取得每个项目之间的分隔符
  sSpace = MidB (RequestBinData,1, InStrB (1,RequestBinData,bCrLf)-1)
  iStart = LenB  (sSpace)
  iFormStart = iStart+2
  '分解项目
  Do
    iInfoEnd = InStrB (iFormStart,RequestBinData,bCrLf & bCrLf)+3
    tStream.Type = 1
    tStream.Mode = 3
    tStream.Open
    oUpFileStream.Position = iFormStart
    oUpFileStream.CopyTo tStream,iInfoEnd-iFormStart
    tStream.Position = 0
    tStream.Type = 2
    tStream.CharSet = "gb2312"
    sInfo = tStream.ReadText      
    '取得表单项目名称
    iFormStart = InStrB (iInfoEnd,RequestBinData,sSpace)-1
    iFindStart = InStr (22,sInfo,"name=""",1)+6
    iFindEnd = InStr (iFindStart,sInfo,"""",1)
    sFormName = Mid  (sinfo,iFindStart,iFindEnd-iFindStart)
    '如果是文件
    If InStr  (45,sInfo,"filename=""",1) > 0 Then
      Set oFileInfo = new FileInfo_Class
      '取得文件属性
      iFindStart = InStr (iFindEnd,sInfo,"filename=""",1)+10
      iFindEnd = InStr (iFindStart,sInfo,"""",1)
      sFileName = Mid  (sinfo,iFindStart,iFindEnd-iFindStart)
      oFileInfo.FileName = Mid (sFileName,InStrRev (sFileName, "\")+1)
      oFileInfo.FilePath = Left (sFileName,InStrRev (sFileName, "\"))
      oFileInfo.FileExt = lcase(Mid (sFileName,InStrRev (sFileName, ".")+1))
      iFindStart = InStr (iFindEnd,sInfo,"Content-Type: ",1)+14
      iFindEnd = InStr (iFindStart,sInfo,vbCr)
      oFileInfo.FileType = Mid  (sinfo,iFindStart,iFindEnd-iFindStart)
      oFileInfo.FileStart = iInfoEnd
      oFileInfo.FileSize = iFormStart -iInfoEnd -2
      oFileInfo.FormName = sFormName
      file.add sFormName,oFileInfo
    Else
    '如果是表单项目
      tStream.Close
      tStream.Type = 1
      tStream.Mode = 3
      tStream.Open
      oUpFileStream.Position = iInfoEnd 
      oUpFileStream.CopyTo tStream,iFormStart-iInfoEnd-2
      tStream.Position = 0
      tStream.Type = 2
      tStream.CharSet = "gb2312"
      sFormValue = tStream.ReadText
      If Form.Exists (sFormName) Then
        Form (sFormName) = Form (sFormName) & ", " & sFormValue
        else
        form.Add sFormName,sFormValue
      End If
    End If
    tStream.Close
    iFormStart = iFormStart+iStart+2
    '如果到文件尾了就退出
  Loop Until  (iFormStart+2) >= iFormEnd 
  RequestBinData = ""
  Set tStream = Nothing
  for each fn in file
    set fl=file(fn)
    If MaxSize<>-1 and fl.FileSize > MaxSize*1024 Then
      MyErr = 2	'如果上传的数据超出限制
      Exit Sub
    elseif fl.FileSize<=0 then
      MyErr = 1	'没有上传文件
      Exit Sub
    elseif CheckExt(fl.FileExt)=false then
      MyErr = 3	'文件扩展名不允许
      Exit Sub
    End If
  next
End Sub
function CheckExt(ext)
  Arr=split("gif,jpg,png,bmp,doc,pdf,zip,rar",",")
  for each ar in arr
    if ext=ar then
      checkext=true
      exit function
    end if
  next
  checkext=false
end function
End Class

'----------------------------------------------------------------------------------------------------
'文件属性类
Class FileInfo_Class
Dim FormName,FileName,FilePath,FileSize,FileType,FileStart,FileExt
'保存文件方法
Public Function SaveToFile (Path)
  'On Error Resume Next
  Dim oFileStream
  Set oFileStream = CreateObject ("ADODB.Stream")
  oFileStream.Type = 1
  oFileStream.Mode = 3
  oFileStream.Open
  oUpFileStream.Position = FileStart
 
  oUpFileStream.CopyTo oFileStream,FileSize
  
  oFileStream.SaveToFile Path,2
  oFileStream.Close
  Set oFileStream = Nothing 
End Function
 
'取得文件数据
Public Function FileData
  oUpFileStream.Position = FileStart
  FileData = oUpFileStream.Read (FileSize)
End Function

End Class
%>