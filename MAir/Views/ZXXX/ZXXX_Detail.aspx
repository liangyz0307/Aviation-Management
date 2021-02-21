<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZXXX_Detail.aspx.cs" Inherits="CUST.WKG.ZXXX_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <%--   UEdit--%>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>


<style type="text/css">
#video {
margin:auto;
width:700px;
height:400px;
}
#tab_xx {
margin:auto;
width:700px;
height:180px;
}
</style>
</head>

<body>
    <p align="center" runat="server">
        <div class="row cl" >
		    <div style="border:1px solid black" id="video">
                <video width="100%" height="400"  autoplay="autoplay" controls="controls" id="video-active">
                    <source src=<%=viedo%> type="video/mp4" >
                </video>             
		    </div>                      
	    </div> 
    </p>
     <table  id="tab_xx">           
           <tr style="vertical-align: top;  width:100%;height:8%;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     员工编号：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_jlzl" runat="server" Text="201010001"></asp:Label>
                    </td>             
            </tr>
            <tr style="vertical-align: top;  width:100%;height:8%;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     员工姓名：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="Label1" runat="server" Text="付晗"></asp:Label>
                    </td>             
            </tr>
            <tr style="vertical-align: top;  width:100%;height:8%;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     学习时间：
              </td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <div id="current">0:00</div>
                </td>             
           </tr>
 </table>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#video-active").on(
              "timeupdate", 
              function(event){
                  onTrackedVideoFrame(this.currentTime, this.duration);
              });
        })
    </script>
    <script type="text/javascript">
        function onTrackedVideoFrame(currentTime, duration){
            $("#current").text(currentTime);
            $("#duration").text(duration);
        }
    </script>


</body>
</html>