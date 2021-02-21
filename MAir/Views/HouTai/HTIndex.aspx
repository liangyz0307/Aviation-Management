<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTIndex.aspx.cs" Inherits="CUST.WKG.HTIndex" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="renderer" content="webkit" />
    <title>后台管理系统</title>
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
    <div class="header bg-main" style="background-image:url(../../Content/images/htglxt.jpg);height:150px;background-size:cover;" >
        <div class="logo margin-big-left fadein-top">
          
      </div>
    </div>
    </header>
    <div>
    <main>
        
    <div id= "div_ht" class="leftnav" style="top:150px;" runat="server">
       
       <h2><span class="icon-user"></span>后台信息管理</h2>
        <ul style="display: block">
            <li id="ht_jsgl" runat="server"> 
                <a href="JS_GL.aspx" target="right">
                    <span ></span>角色管理
                </a>
            </li>
            <li id="ht_yhgl" runat="server">
                <a href="YHGL.aspx" target="right">
                    <span ></span>用户管理
                </a>
            </li>

       
            <li id="ht_bmgl" runat="server">
                <a href="BMGL.aspx" target="right">
                    <span ></span>部门管理
                </a>
            </li>
             <li id="ht_gwgl"  runat="server">
        <a href="GWGL.aspx" target="right">
        <span ></span>岗位管理
        </a>
        </li>
        <li id="ht_sprgl" runat="server">
        <a href="SPRGL.aspx" target="right">
        <span ></span>审批人管理
        </a>
        </li>
            <li id="ht_fbgg" runat="server">
        <a href="FBGG.aspx" target="right">
        <span ></span>发布公告
        </a>
        </li>
               <li id="ht_htgl" runat="server">
        <a href="HTGL.aspx" target="right">
        <span ></span>合同管理
        </a>
        </li>
        <li id="ht_cspz" runat="server">
        <a href="CSPZ.aspx" target="right">
        <span ></span>参数配置
        </a>
        </li>
                       <li id="ht_zdgl" runat="server">
       <a href="ZDGL.aspx" target="right">
        <span ></span>字典管理
        </a>
        </li>
        
      
                <li id="ht_rzgl" runat="server">
        <a href="RZGL.aspx" target="right">
        <span ></span>日志管理
        </a>
        </li>
        </ul>
     
    </div>
    <script type="text/javascript">
        $(function() {
            $(".leftnav h2").click(function() {
                $(this).next().slideToggle(200);
                $(this).toggleClass("on");
            })
            $(".leftnav ul li a").click(function() {
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
       <asp:Button ID="btn_tc" runat="server" Text="退出登录"   class="btn   radius" BorderStyle="None" Width="100px" OnClick="btn_tc_Click"></asp:Button>
      
        </span>
        </div>
        <li style="float:left">
        
        </li>
    </ul>
    <div class="admin" style="top:190px;">
  <iframe id="myFrame" rameborder="0" style=" overflow-y:visible;" scrolling="visible"  name="right" width="100%" height="100%" runat="server">
  </iframe>
    </div> 
    </main>
    </div>
 </form>
</body>
</html>
