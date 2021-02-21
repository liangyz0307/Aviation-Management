<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQIndex.aspx.cs" Inherits="CUST.WKG.AQIndex" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <title>航务综合信息报送系统</title>
    <link rel="stylesheet" href="../../Content/css/pintuer.css" />
    <link rel="stylesheet" href="../../Content/css/admin.css"  />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <style type="text/css">
        html{height:100%;}
    body{min-height:100%;margin:0;padding:0;position:relative;}
    main{padding-bottom:100px;}/* main的padding-bottom值要等于或大于footer的height值 */
    footer{position:absolute;bottom:0;width:100%;height:20px; background-color:#F2F9FD;}
    </style>
</head>
<style type="text/css">
  footer{ 
  display:block; 
  }                
  </style> 
  <script type="text/javascript">
      document.createElement("footer");
  </script>
<body style="background-color: #f2f9fd;">
    <form runat ="server">
<header>
    <div class="header bg-main" style="background-image:url(../../Content/images/aqjgxt.jpg);height:150px;background-size:cover;"  >
        <div class="logo margin-big-left fadein-top">
         
        </div>
        
    </div>
    </header>
    <div>
    <main >       
    <div class="leftnav" style="width:220px;top:150px;">

       <h2><span class="icon-user"></span>安全信息管理系统</h2>
        <ul style="display: block">
      

        <li>
        <a href="AQXX.aspx" target="right">
         安全运行信息
        </a>
        </li> 
        <li>
        <a href="BS_SG.aspx" target="right">
         安全事件报送
        </a>
        </li>
             
         <%--<li>
        <a href="BS_TQCZ.aspx" target="right">
         特情处置
        </a>
        </li> --%>
         <%--<li>
        <a href="" target="right">
         值班管理还没做
        </a>
        </li> --%>
        
        <li>
        <a href="ZYBSGL.aspx" target="right">
         自愿报送
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
        <li  style="margin-left:215px;" ><a href="../MenHu/Sys_Index.aspx"><span  title="首页" >首页</span></a></li>
        <div align="right" style=" font-size:medium">
        <span style="float:right">
        <a>用户名:  </a><asp:Label ID="lbl_yhm"  runat="server"></asp:Label>
         <asp:Button ID="btn_tc" runat="server"  Text="退出"  Width="100px"      OnClick="btn_tc_Click"  BorderStyle="None"></asp:Button>
      
        </span>
        </div>
        <li style="float:left">
        
        </li>
    </ul>
    <div class="admin" style="left:220px;top:190px;">
       <iframe id="myFrame" rameborder="0"  style=" overflow-y:visible;" scrolling="visible"  name="right" width="100%" height="100%" runat="server">
           
        </iframe>
    </div>
    
    </main>
    </div>
 </form>
</body>
</html>
