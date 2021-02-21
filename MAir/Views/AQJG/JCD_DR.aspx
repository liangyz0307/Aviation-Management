<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JCD_DR.aspx.cs" Inherits="CUST.WKG.JCD_DR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>检查单导入</title>

    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
      #login ,#login_1
     {  
        display:none; 
        border:1em solid #e4e5e6;  
        height:202px;  
        width:326px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:5%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:65%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }   
   
    #over  ,#over_1
    {  
        width: 100%;  
        height: 100%;  
        opacity:0.5;/*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/  
        filter:alpha(opacity=80);  
        display: none;  
        position:absolute;  
        top:0;  
        left:0;  
        z-index:1;  
        background: silver;  
    }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
     <table >
 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
      <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
        Excel模板下载：</td>
     <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9; width: 50%;" class="td_sjsc">
      <asp:Button ID="btn_mbxz" runat="server" Text="模板下载"
       CssClass="button1" Width="150px"  Height ="30px"  ForeColor="White" BackColor="#60B1D7" OnClick="btn_mbxz_Click"/>
    </td>
 </tr>
 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
      <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
        填报单位：</td>
     <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 50%;" class="td_sjsc">
         <asp:DropDownList ID="ddlt_tbdw" runat="server" Width="200px"></asp:DropDownList>
         <asp:Label ID="lbl_tbdw" runat="server"></asp:Label>
     </td>
 </tr>
  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
      <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
      Excel位置：</td> 
       <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9; width: 50%;" class="td_sjsc">             
      <asp:FileUpload ID="FileUpload1" runat="server"   Width="200px"  />
       <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click" Text="上传Excel"
                    CssClass="button1" Width="150px"  Height ="30px"  ForeColor="White" BackColor="#60B1D7"/>
      </td>
 </tr>
      </table>
    </form>
</body>
</html>
