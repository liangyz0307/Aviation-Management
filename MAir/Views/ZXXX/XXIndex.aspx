<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XXIndex.aspx.cs" Inherits="CUST.WKG.XXIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线学习系统</title>
    <link rel="stylesheet" href="../../Content/css/pintuer.css" />
    <link rel="stylesheet" href="../../Content/css/admin.css" />
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
<body style="background-color: #f2f9fd;">
    <form runat="server">
<header>
    <div class="header bg-main"  style="background-image:url(../../Content/images/zxxxxt.jpg);height:150px;background-size:cover;">
        <div class="logo margin-big-left fadein-top">
         
     
        </div>
        
    </div>
    </header>
    <div>
    <main>
        <div class="leftnav" style="top:150px;">
    <h2><span class="icon-user"></span>在线学习系统管理</h2>
      <ul style="display: block">
         <li>
             <a href="ZXXX_WJ.aspx" target="right">
                  <span class="icon-caret-right"></span>在线学习
             </a>
         </li>
     </ul>
    <ul style="display: block">
         <li>
             <a href="ZXXX_SP.aspx" target="right">
                  <span class="icon-caret-right"></span>在线视频
             </a>
         </li>
     </ul>
</div>
    <script type="text/javascript">
        $(function () {
            $(".leftnav h2").click(function () {
                $(this).next().slideToggle(200);
                $(this).toggleClass("on");
            })
            $(".leftnav ul li a").click(function () {
                $("#a_leader_txt").text($(this).text());
                $(".leftnav ul li a").removeClass("on");
                $(this).addClass("on");
            })
        });
    </script>
    <ul class="bread" style=" width:100%; margin-left:0px;">
        <li  style="margin-left:180px;"><a href="../MenHu/Sys_Index.aspx">首页</a></li>
       
        <div align="right" style=" font-size:medium">
        <span style="float:right">
        <a>用户名:  </a><asp:Label ID="lbl_yhm"  runat="server"></asp:Label>
     <asp:Button ID="btn_tc" runat="server" Text="退出登录"    class="btn  radius" BorderStyle="None" Width="100px" OnClick="btn_tc_Click"></asp:Button>
        </span>
        </div>

    </ul>
    <div class="admin" style="top:190px;">
       <iframe id="myFrame" rameborder="0" style=" overflow-y:visible;" scrolling="visible"  name="right" width="100%" height="100%" runat="server">

         </iframe>
    </div>
   
    </div>
    </form>
</body>
</html>
