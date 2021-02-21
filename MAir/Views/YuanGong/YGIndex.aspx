<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YGIndex.aspx.cs" Inherits="CUST.WKG.YGIndex" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理系统</title>
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
     <form id="Form1" runat="server">
<header>
   
    <div class="header bg-main"  style="background-image:url(../../Content/images/ygglxt.jpg);height:150px;background-size:cover;">
        <div class="logo margin-big-left fadein-top">
          
        </div> 
    </div>
    </header>
<div>
<main>   
<div class="leftnav" style="top:150px;">
      <h2><span class="icon-user"></span>员工管理</h2>
        <ul style="display: block">
         <li id="ygxx" runat="server">
        <a href="YGGL.aspx" target="right" id="yg_ygxx">
        <span ></span>员工信息
        </a>
        </li>
        <li id="ygzz" runat="server">
          <a href="ZZGL.aspx" target="right" id="yg_ygzz">
           <span ></span>员工资质
           </a>
        </li>
            <li id="ygll" runat="server">
              <a href="LLGL.aspx" target="right" id="yg_ygll">
             <span ></span>员工履历
             </a>
           </li>
           <li id="ygcf" runat="server">
              <a href="CFGL.aspx" target="right" id="yg_ygcf">
             <span ></span>员工惩罚
             </a>
           </li>
             <li id="ygjl" runat="server">
              <a href="JLGL.aspx" target="right" id="yg_ygjl">
             <span ></span>员工奖励
             </a>
           </li>
            <li id="Li1" runat="server">
              <a href="KG_PXJL.aspx" target="right" id="yg_ygpx">
                 <span ></span>员工培训
              </a>
           </li>
           <li id="Li2" runat="server">
              <a href="ZCGL.aspx" target="right" id="yg_ygzc">
                 <span ></span>员工职称
              </a>
           </li>
<%--           <li id="Li3" runat="server">
              <a href="YG_GJJS.aspx" target="right">
                 <span ></span>员工高级检索
              </a>
           </li>--%>
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

            var start = location.href.indexOf("?")+1;
            var str = location.href.substring(start);
            var para = str.split("&");
            var dict = {};
            for (var i = 0; i < para.length; i++)
            {
                var temp = new Array();
                temp = para[i].split("=");
                if (temp[0] == "trans")
                {
                    dict["trans"] = temp[1];
                }
            }
            var trans = dict["trans"];

            if (trans == "yggl")
            {
                $("#yg_yggl").click();
                $("iframe").attr("src", "YGGL.aspx");
            }

            if (trans == "ygzz")
            {
                $("#yg_ygzz").click();
                $("iframe").attr("src", "ZZGL.aspx");
            }

            if (trans == "ygll")
            {
                $("#yg_ygll").click();
                $("iframe").attr("src", "LLGL.aspx");
            }

            if (trans == "ygcf")
            {
                $("#yg_ygcf").click();
                $("iframe").attr("src", "CFGL.aspx");
            }

            if (trans == "ygjl")
            {
                $("#yg_ygjl").click();
                $("iframe").attr("src", "JLGL.aspx");
            }

            if (trans == "ygpx")
            {
                $("#yg_ygpx").click();
                $("iframe").attr("src", "KG_PXJL.aspx");
            }

            if (trans == "ygzc")
            {
                $("#yg_ygzc").click();
                $("iframe").attr("src", "ZCGL.aspx");
            }
        });
</script>
    <ul class="bread" style=" width:100%; margin-left:0px;">
        <li  style="margin-left:180px;"><a href="../MenHu/Sys_Index.aspx">首页</a></li>
  
        <div align="right" style=" font-size:medium">
        <span style="float:right">
        <a>用户名:  </a><asp:Label ID="lbl_yhm"  runat="server"></asp:Label>
        &nbsp&nbsp 
<asp:Button ID="btn_tc" runat="server" Text="退出登录" OnClick="btn_tc_Click"  class="btn   radius" BorderStyle="None" Width="100px"></asp:Button>
         
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
