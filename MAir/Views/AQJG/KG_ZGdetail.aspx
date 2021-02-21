<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_ZGdetail.aspx.cs" Inherits="CUST.WKG.KG_ZGdetail" %>

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
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
           
         <div class="panel-head">
            <strong class="icon-reorder">整改详情</strong>
        </div>
    <table >          
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     责任人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zrr" runat="server" ></asp:Label>
                    </td>
              
            </tr>
 
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     整改时限：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zgsx" runat="server" ></asp:Label>
                    </td>
              
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     整改项目：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zgxm" runat="server" ></asp:Label>
                    </td>
              
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     整改方案：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zgfa" runat="server" ></asp:Label>
                    </td>
              
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     整改进度：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zgjd" runat="server" ></asp:Label>
                    </td>            
            </tr>


           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     风险控制措施：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_fxkzcs" runat="server" ></asp:Label>
                    </td>
              
            </tr>


           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     问题来源：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_wtly" runat="server" ></asp:Label>
                    </td>
              
            </tr>
                
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     问题类别：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_wtlb" runat="server" ></asp:Label>
                    </td>            
            </tr>
            
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     状态：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                    </td>             
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     查看资料：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                  <asp:Button ID="btn_xz" runat="server" 
                Text="下载文件" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="80px" OnClick="btn_xz_Click"   ></asp:Button> 
                    </td>             
            </tr>

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
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div>  
	</form>
        
</article>
    
</body>
</html>