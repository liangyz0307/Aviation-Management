<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZYBS_Detail.aspx.cs" Inherits="MAir.Views.AnQuan.ZYBS_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="panel-head">
             <strong class="icon-reorder">自愿报送详情</strong>
         </div>
      <table>          
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送员工：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bsyg" runat="server" ></asp:Label>
                </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送岗位：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bsgw" runat="server" ></asp:Label>
                </td>              
           </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bssj" runat="server" ></asp:Label>
                </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送类型：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bslx" runat="server" ></asp:Label>
                </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送模式：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bsms" runat="server" ></asp:Label>
                </td>            
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     解决方案：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_jjfa" runat="server" ></asp:Label>
                </td> 
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     状态：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:55px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     驳回原因：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bhyy" runat="server"  Multiply="true" Height="50px" Width="200px"></asp:Label>
                 </td>            
            </tr>
           <tr style="vertical-align: top;  width:100%;height:55px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     备注：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bz" runat="server"  Multiply="true" Height="50px" Width="200px"></asp:Label>
                 </td>            
            </tr>
        </table>
         <div class="row cl">
		    <div style="text-align:center">
                <asp:Button ID="btn_fh" runat="server" 
                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"  ></asp:Button> 
		    </div>
	   </div>  
   
    </form>
</body>
</html>
