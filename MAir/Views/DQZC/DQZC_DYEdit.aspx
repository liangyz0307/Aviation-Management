<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_DYEdit.aspx.cs" Inherits="CUST.WKG.MenHu.main.DQZC_DYEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <title>党员编辑</title>
      <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
     <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
       <script src="../css/js/jquery.js" type="text/javascript"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
       <table>     
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               员工编号：<asp:Label ID="Label1" runat="server" Text="*" ForeColor="White"></asp:Label>        
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_bh" runat="server"></asp:Label>
            </td>
        </tr>
      <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                政治面貌：  <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:DropDownList ID="ddlt_zzmm" runat="server" Width="135px" Height="26px" AutoPostBack="True"></asp:DropDownList>
                 <asp:Label ID="lbl_zzmm" runat="server"></asp:Label>
            </td>            
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               党组织名称：<asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>        
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                     <asp:DropDownList ID="ddlt_dzzmc" runat="server" Width="135px" Height="26px" AutoPostBack="True"></asp:DropDownList>                   
                 <asp:Label ID="lbl_dzzmc" runat="server"></asp:Label>
            </td>
        </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               基层党支部名称：<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>        
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:DropDownList ID="ddlt_jcdzbmc" runat="server" Width="135px" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_jcdzbmc_SelectedIndexChanged"></asp:DropDownList>                   
                 <asp:Label ID="lbl_jcdzbmc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               党小组名称：<asp:Label ID="Label6" runat="server" Text="*" ForeColor="white"></asp:Label>        
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   <asp:DropDownList ID="ddlt_dxzmc" runat="server" Width="135px" Height="26px" AutoPostBack="True"></asp:DropDownList>                   
                 <asp:Label ID="lbl_dxzmc" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               党内职务：<asp:Label ID="Label4" runat="server" Text="*" ForeColor="white"></asp:Label>        
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_dnzw" runat="server" Height="26px" ></asp:TextBox>
                 <asp:Label ID="lbl_dnzw" runat="server"></asp:Label>
            </td>
        </tr>
       
      
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               用工形式：<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_ygxs" runat="server" Width="135px" Height="26px" AutoPostBack="True"></asp:DropDownList>                   
                <asp:Label ID="lbl_ygxs" runat="server"></asp:Label>
            </td>             
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                入党时间：<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_rdsj" runat="server" class="input-text" 
                 Width="100px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                 <asp:Label ID="lbl_rdsj" runat="server"></asp:Label>
            </td>            
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                备注：<asp:Label ID="Label2" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_bz" runat="server" Height="26px" ></asp:TextBox>
             </td>
        </tr>
    </table>
    <br/>
    <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:right">
                     <asp:Button ID="btn_bc" runat="server" Text="保存" class="btn radius"   BackColor="#990000" ForeColor="White"  Width="199px" OnClick="btn_bc_Click" >
                     </asp:Button>
                </td>            
                <td style="text-align:left"> &nbsp;&nbsp;
                     <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius"  BackColor="#990000" ForeColor="White"  Width="199px" OnClick="btn_fh_Click" >
                     </asp:Button>
                </td>
            </tr>
        </table>
   </div>
        </form>
</asp:Content>
