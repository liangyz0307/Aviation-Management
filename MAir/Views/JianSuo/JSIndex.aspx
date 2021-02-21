<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSIndex.aspx.cs" Inherits="CUST.WKG.JSIndex" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="renderer" content="webkit" />
    <title>检索管理系统</title>
    <link rel="stylesheet" href="../../Content/css/admin.css"  />
    <link rel="stylesheet" href="../../Content/css/pintuer.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <style type="text/css">
        html{height:100%;}
        body{min-height:100%;margin:0;padding:0;position:relative;}
        header{background-color: #ffe4c4;}
        main{padding-bottom:100px;}/* main的padding-bottom值要等于或大于footer的height值 */
        footer{position:absolute;bottom:0;width:100%;height:20px; background-color:#F2F9FD;}
    </style>
</head>
     <style type="text/css">
           footer
          {
             display:block;
          }
    </style>
 <script type="text/javascript">
        document.createElement("footer");
 </script>
 
<body style="background-color: #f2f9fd;"  class="panel">
<form runat="server">
         <header>
   
    <div class="header bg-main" style="background-image:url(../../Content/images/jsglxt.jpg);height:150px;background-size:cover;" >
        <div class="logo margin-big-left fadein-top">
          
        </div>
        
    </div>
    </header> 
   <div>
    <main>
    <div class="leftnav"style="top:150px;" >
   
        
   <h2><span class="icon-user"></span>长春导航保障部</h2>
    <ul style="display: block">
       
          <li class="l22">
             <a href="JS_YG.aspx" id="f138" target="right">
                   <span></span>员工管理系统
             </a>
         </li>
         <li class="l22">
             <a href="JS_SBGL.aspx" id="f140" target="right">
                   <span></span>设备管理系统
             </a>
         </li>
         <li class="l22">
             <a href="JS_SKJS.aspx" id="f139" target="right">
                   <span></span>五库建设系统
             </a>
         </li>
                 <li class="l22">
             <a href="JS_YJGL.aspx" id="f140" target="right">
                   <span></span>应急管理
             </a>
         </li>
          
    </ul>
    
         
    </div>
        <ul class="bread" style=" width:100%; margin-left:0px;">
        <li  style="margin-left:180px;"><a href="../MenHu/Sys_Index.aspx">首页</a></li>
    
        <div align="right" style=" font-size:medium">
            <span style="float:right">
            <a>用户名:  </a>
              <asp:Label ID="lbl_yhm"  runat="server"></asp:Label>
               <asp:Button ID="btn_tc" runat="server" Text="退出登录" OnClick="btn_tc_Click" class="btn  radius"    BorderStyle="None" Width="100px"></asp:Button> </span>
        </div>
        <li style="float:left">
        
        </li>
    </ul>   

        <div class="admin" style="margin-top:85px;">
            <iframe id="myFrame" rameborder="0" style=" overflow-y:visible;" scrolling="visible"  name="right" width="100%" height="100%" runat="server"></iframe>
          
        </div>
    </main>
  </div>
</form> 
</body>
</html>
