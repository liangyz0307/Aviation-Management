<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBIndex.aspx.cs" Inherits="CUST.WKG.SBIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML .0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>设备管理系统</title>
    <link rel="stylesheet" href="../../Content/css/pintuer.css" />
    <link rel="stylesheet" href="../../Content/css/admin.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
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
    <form runat="server">

    <header>
        <div class="header bg-main" style="background-image:url(../../Content/images/sbglxt.jpg);height:150px;background-size:cover;" >
            <div class="logo margin-big-left fadein-top">        
            </div>  
        </div>
    </header>
   <div>
     <main>   
    <div class="leftnav"style="top:150px;" >
       <h2 ><asp:Label  runat="server" ID="title" Text="长春航务保障部"></asp:Label></h2>
           
            <ul style="display: block">
                   <li><a id="dhsb" href="DHSB_GL.aspx" target="right"  runat="server">导航设备</a></li>
                   <li><a id="txsh" href="TXSB_GL.aspx" target="right" runat="server" >通信设备</a></li>                 
                   <li><a id="qxsb" href="QXSB_GL.aspx" target="right"  runat="server">气象设备</a></li>
                   <li><a id="A1" href="JSSB_GL.aspx" target="right"  runat="server">监视设备</a></li>
            </ul>
            <h2><span class="icon-user"></span>台站管理</h2>
            <ul style="display: block">
               <li><a id="tzsb" href="SBTZ.aspx" target="right">台站管理</a></li>
            </ul>
        <h2><span class="icon-user"></span>备件管理</h2>
            <ul style="display: block">
                   <li><a id="bjgl" href="BJ_GL.aspx" target="right">备件管理</a></li>
<%--                   <li><a href="SBBJ_CK.aspx" target="right">备件出库</a></li>--%>
                   <li><a id="bjrk" href="SBBJ_RK.aspx" target="right">备件出入库</a></li>
            </ul>
           <h2><span class="icon-user"></span>故障管理</h2>
            <ul style="display: block">
                  <li><a id="sbgz" href="SBGZ_GL.aspx" target="right">设备故障</a></li>
            </ul>
           <h2><span class="icon-user"></span>维护管理</h2>
            <ul style="display: block">
                  <li><a id="sbwh" href="SBWH_GL.aspx" target="right">设备维护</a></li>
            </ul>
    </div>
    <ul class="bread" style=" width:100%; margin-left:0px;">
        <li  style="margin-left:180px;">
            <a href="../MenHu/Sys_Index.aspx">首页</a>
           
        </li>
      
        <div align="right" style=" font-size:medium">
        <span style="float:right">
        <a>用户名:  </a><asp:Label ID="lbl_yhm"  runat="server"></asp:Label>
           <asp:Button ID="btn_tc" runat="server" Text="退出登录" OnClick="btn_tc_Click" class="btn  radius"    BorderStyle="None" Width="100px"></asp:Button>
        </span>
        </div>
        <li style="float:left">
        
        </li>
    </ul>
    <div class="admin" style="margin-top:85px;">
         <iframe id="myFrame" rameborder="0"  style=" overflow-y:visible;" scrolling="visible"  name="right" width="100%" height="100%" runat="server">
           
        </iframe>
      </div>
    </main>
        </div>
    </form>
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

            if (trans == "dhsb")
            {
                $("#dhsb").click();
                $("iframe").attr("src", "DHSB_GL.aspx");
            }

            if (trans == "txsb")
            {
                $("#txsh").click();
                $("iframe").attr("src", "TXSB_GL.aspx");
            }

            if (trans == "qxsb")
            {
                $("#qxsb").click();
                $("iframe").attr("src", "QXSB_GL.aspx");
            }

            if (trans == "tzsb")
            {
                $("#tzsb").click();
                $("iframe").attr("src", "SBTZ.aspx");
            }

            if (trans == "bjgl")
            {
                $("#bjgl").click();
                $("iframe").attr("src", "BJ_GL.aspx");
            }

            if (trans == "bjrk")
            {
                $("#bjrk").click();
                $("iframe").attr("src", "SBBJ_RK.aspx");
            }

            if (trans == "sbgz")
            {
                $("#sbgz").click();
                $("iframe").attr("src", "SBGZ_GL.aspx");
            }

            if (trans == "sbwh")
            {
                $("#sbwh").click();
                $("iframe").attr("src", "SBWH_GL.aspx");
            }

            if (trans == "jssb")
            {
                $("#A1").click();
                $("iframe").attr("src", "JSSB_GL.aspx");
            }
        });
</script>
</body>
</html>
