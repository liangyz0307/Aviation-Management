<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQXX_Detail.aspx.cs" Inherits="MAir.Views.AnQuan.AQXX_Detail" %>

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
    <div>
    <div class="panel-head">
        <strong class="icon-reorder">安全信息详情</strong>
    </div>
    <table >          
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送员工：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bsyg" runat="server" ></asp:Label>
                    </td></tr>
 
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送岗位：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bsgw" runat="server" ></asp:Label>
                    </td></tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报送时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bssj" runat="server" ></asp:Label>
                    </td></tr>

           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任部门：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zrbm" runat="server"></asp:Label>
                    </td></tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     备注：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                    </td>            
            </tr>


           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     特情处置：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_tqcz" runat="server" ></asp:Label>
                    </td></tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     管制情况：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_gzqk" runat="server" ></asp:Label>
                    </td></tr>
                
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     事件涉及航空器和机组有关情况：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_sjqk" runat="server" ></asp:Label>
                    </td>            
            </tr>
            
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     空管相关设备运行情况：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_sbyxqk" runat="server" ></asp:Label>
                    </td>             
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     事发时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_sfsj" runat="server" ></asp:Label>
                </td>            
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     责任单位：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zrdw" runat="server" ></asp:Label>
                 </td>            
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     负责人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_fzr" runat="server" ></asp:Label>
                 </td>            
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     报告时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bgsj" runat="server" ></asp:Label>
                 </td>            
            </tr>
         <%--<tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     责任人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zrr" runat="server" ></asp:Label>
                 </td>            
            </tr>--%>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     驳回原因：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bhyy" runat="server" ></asp:Label>
                 </td>            
            </tr>
        </table>
        <div class="row cl">
		    <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                <asp:Button ID="btn_fh" runat="server" 
                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                    Width="199px" OnClick="btn_fh_Click"  ></asp:Button> 
		    </div>
	   </div>  
    </div>
    </form>
</body>
</html>
