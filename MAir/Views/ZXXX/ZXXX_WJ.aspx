<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZXXX_WJ.aspx.cs" Inherits="CUST.WKG.ZXXX_WJ" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线学习文件</title>

    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
          文件名：
            <asp:TextBox ID="tbx_wjm" runat="server" Width="100px" ></asp:TextBox> 
           上传时间：
                <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="开始时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="截止时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
                    
            <td style="width:20%; " align="right">             
                     部门：
              <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 80px"  AutoPostBack="true">
            </asp:DropDownList>                       
               </td>         
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_add_Click" 
                />
       </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="21">
                                    在线学习资料
                                </th>
                            </tr>
                            <tr>
                                <th width="50"  style="text-align:left;">
                                    序号
                                </th>
                                 <th width="160"  style="text-align:left;">
                                    文件名
                                </th>
                                <th width="160"  style="text-align:left;">
                                    上传时间
                                </th>
                                <th width="160"  style="text-align:left;">
                                    上传人
                                </th>                   
                                <th width="160"  style="text-align:left;"> 
                                    操作                
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
                             <td class="td-manage">
                                 <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该条信息？')">删除</asp:LinkButton>
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

  



    </form>
</body>
</html>
