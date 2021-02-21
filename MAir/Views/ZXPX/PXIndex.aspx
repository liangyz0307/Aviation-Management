<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PXIndex.aspx.cs" Inherits="CUST.WKG.PXIndex" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" id="viewport" content="width=device-width,initial-scale=1.0" />
    <meta name="renderer" content="webkit" />
    <title>在线培训系统</title>
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
        <div class="header bg-main" style="background-image: url(../../Content/images/zxksxt.jpg); height: 150px; background-size: cover;">
            <div class="logo margin-big-left fadein-top">
            </div>
        </div>
        <div class="leftnav" style="top: 150px;">
            <h2><span class="icon-user" id="sp_STGL" runat="server">题库管理</span></h2>
            <ul style="display: block" id="ul_STGL" runat="server">
                <li id="li_STGL" runat="server"><a href="STGL.aspx" target="right"><span>题库管理</span></a></li>
                <li id="li_ST_XZT_Add" runat="server"><a href="ST_XZT_Add.aspx" target="right"><span>选择题添加</span> </a></li>
                <li id="li_ST_PDT_Add" runat="server"><a href="ST_PDT_Add.aspx" target="right"><span>判断题添加</span></a> </li>
                <li id="li_ST_TKT_Add" runat="server"><a href="ST_TKT_Add.aspx" target="right"><span>填空题添加</span></a></li>
            </ul>
            <h2><span class="icon-user" id="sp_CLGL" runat="server">组卷策略管理</span></h2>
            <ul style="display: block" id="ul_CLGL" runat="server">
                <li id="li_CLGL" runat="server"><a href="CLGL.aspx" target="right"><span>策略管理</span></a></li>
                <li id="li_CL_Add" runat="server"><a href="CL_Add.aspx" target="right"><span>策略添加</span></a></li>
            </ul>
            <h2><span class="icon-user" id="sp_KSGL" runat="server">考试管理</span></h2>
            <ul style="display: block" id="ul_KSGL" runat="server">
                <li id="li_CL_Select" runat="server"><a href="CJ_GL.aspx" target="right"><span>考试管理</span></a></li>
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
        <ul class="bread" style="width: 100%; margin-left: 0px;">
            <li style="margin-left: 180px;"><a href="../MenHu/Sys_Index.aspx">首页</a></li>
            <div align="right" style="font-size: medium">
                <span style="float: right">
                    <a>用户名:  </a>
                    <asp:Label ID="lbl_yhm" runat="server"></asp:Label>
                    &nbsp&nbsp 
                    <asp:Button ID="btn_tc" runat="server" Text="退出登录" OnClick="btn_tc_Click" class="btn   radius" BorderStyle="None" Width="100px"></asp:Button>
                </span>
            </div>
            <li style="float: left"></li>
        </ul>
        <div class="admin" style="top: 190px;">
            <iframe id="myFrame" rameborder="0" style="overflow-y: visible;" scrolling="visible" name="right" width="100%" height="100%" runat="server"></iframe>
        </div>
    </form>
</body>
</html>
