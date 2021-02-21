<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="GHGLShow.aspx.cs" Inherits="CUST.WKG.GHGLShow" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>党员在线</title>
     <!--[if lt IE 9]> 
     <script type="text/javascript" src="../lib/html5.js"></script>
     <script type="text/javascript" src="../lib/respond.min.js"></script>
     <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
     <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
       <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <%--<link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />--%>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div >
        <div>
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
          标题：
            <asp:TextBox ID="tbx_wjm" runat="server"  class="Wdate"  Width="80px"   Height="20px" ></asp:TextBox>
          上传时间：
                <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="开始时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="截止时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
                     <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#ab2025" ForeColor="White" OnClick="btn_select_Click" 
                />
         <%-- <td style="text-align:left">
                     <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius"  BackColor="#ab2025" ForeColor="White"  Width="60px" OnClick="btn_fh_Click" >
                     </asp:Button>
                </td>--%>
           
             </div>
       <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="21">
                                    工会管理
                                </th>
                            </tr>
                            <tr>
                                <th width="30"  style="text-align:center;">
                                    序号
                                </th>
                                 <th width="80"  style="text-align:center;">
                                    文件名
                                </th>
                                <th width="80"  style="text-align:center;">
                                    上传时间
                                </th>
                                <th width="80"  style="text-align:center;">
                                    上传人
                                </th>                   
                                
                               
                             </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                               <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>                                    
                                      <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Underline="true" CommandName="down" CommandArgument='<%#Eval("wjm")+"&"+ Eval("sclj") %>' Text='<%# Eval("wjm") %>'></asp:LinkButton>
                                </td>
                           <td>
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("scsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label3"  runat="server" Text='<%#Eval("scr") %>'></asp:Label>
                            </td>                  
                            
                             
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <table>
                <tr>
                    <td align="center" class="auto-style1" >
                        <cc1:pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
            <asp:HiddenField ID="HF_yc" runat="server" />
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
<script type="text/javascript">

    //单个按钮驳回
    function rec() {
        var excuse;
        excuse = prompt("请输入驳回原因：");
        if (excuse == null)
        { return false; }
        else {
            document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
        }

    }

</script>
    </form>
</asp:Content>
