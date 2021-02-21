<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JXIndex.aspx.cs" Inherits="CUST.WKG.JXIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>绩效管理系统</title>
    <link rel="stylesheet" href="../../Content/css/pintuer.css" />
    <link rel="stylesheet" href="../../Content/css/admin.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <style type="text/css">
        html {
            height: 100%;
        }

        body {
            min-height: 100%;
            margin: 0;
            padding: 0;
            position: relative;
        }

        header {
            background-color: #ffe4c4;
        }

        main {
            padding-bottom: 100px;
        }
        /* main的padding-bottom值要等于或大于footer的height值 */
        footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            height: 20px;
            background-color: #F2F9FD;
        }
    </style>
</head>
<style type="text/css">
    footer {
        display: block;
    }
</style>
<script type="text/javascript">
    document.createElement("footer");
</script>
<body style="background-color: #f2f9fd;">
    <form id="Form1" runat="server">
        <header>
    <div class="header bg-main"  style="background-image:url(../../Content/images/jxglxt.jpg);height:150px;background-size:cover;">
        <div class="logo margin-big-left fadein-top">
          
        </div> 
    </div>
    </header>
        <div>
            <main>   
<div class="leftnav" style="top:150px;">
      <h2><span class="icon-user"></span>绩效管理</h2>
      <h2><span class="icon-user"></span>个人绩效管理</h2>
        <ul style="display: block">
            <li id="grjx_pcx" runat="server"><a href="PCGL.aspx" target="right">评测项</a></li>
            <li id="grjx_pcfa" runat="server"><a href="FAGL.aspx" target="right">评测方案</a></li>
            <li id="jgrjx_jxzfa" runat="server"><a href="ZFA.aspx" target="right">绩效总方案</a></li>
            <li id="grjx_tjzfa" runat="server"><a href="YG_PCFA_Add.aspx" target="right">添加评测方案</a></li>
            <li id="grjx_grjxzf" runat="server"><a href="GRJXZF.aspx" target="right">个人绩效总分</a></li>
         </ul>
       <h2><span class="icon-user"></span>部门绩效管理</h2>
        <ul style="display: block">
            <li id="bmjx_pcx" runat="server"><a href="BMPCXGL.aspx" target="right">评测项</a></li>
            <li id="bmjx_pcfa" runat="server"><a href="BMPCFAGL.aspx" target="right">评测方案</a></li>
            <li id="bmjx_bmzfa" runat="server"><a href="BMZFA.aspx" target="right">部门总方案</a></li>
            <li id="bmjx_tjzfa" runat="server"><a href="BM_PCFA_ADD.aspx" target="right">添加评测方案</a></li>
            <li id="bmjx_bmjxzf" runat="server"><a href="BMJXZF.aspx" target="right">部门绩效总分</a></li>     
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
        <li  style="margin-left:180px;"><a href="../MenHu/Sys_Index.aspx">首页</a></li
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
