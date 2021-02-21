<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RZGL.aspx.cs" Inherits="CUST.WKG.RZGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
 
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
 
</head>
<body>
     <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
        <table><tr>
           <td style="width:15%; " align="right">
             员工编号：
             <asp:TextBox ID="tbx_bh" runat="server" style="width:100px;height:24px;"></asp:TextBox></td>
           <td style="width:15%; " align="right">
            姓名：
             <asp:TextBox ID="tbx_xm" runat="server" style="width:100px;height:24px;"></asp:TextBox></td>
           <td style="width:18%; " align="right">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      部门代码：
              <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 120px" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"  AutoPostBack="true">
            </asp:DropDownList>
                       </ContentTemplate>
               </asp:UpdatePanel>
               </td>
           <td style="width:18%; " align="right">
             
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
                      岗位代码：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 120px"  AutoPostBack="true">
            </asp:DropDownList>
                        </ContentTemplate>
               </asp:UpdatePanel>
               </td>
            <td style="width:18%; " align="right">
             操作方式：
             <asp:DropDownList ID="ddlt_czfs" runat="server" class="select-box" Style="width: 120px" >
            </asp:DropDownList></td>
            <td style="width:13%; " align="center">
            <asp:Button ID="btn_select" runat="server" class="btn   radius" Text="查询"  ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
                  </td>
           
               </tr></table> 
          
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    日志列表
                                </th>
                            </tr>
                            <tr class="text-c">
                              
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    员工编号
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>
                                  <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    操作方式
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    操作IP
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    操作时间
                                </th>
                                  <th width=""  style="text-align:center;vertical-align:middle;">
                                    操作信息
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                          
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                              <%--  <%#Container.ItemIndex + 1%>--%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zdm" runat="server" Text='<%#Eval("bh") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("xm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_mc" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("gw") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("fs") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("ip") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("czsjmc") %>'></asp:Label>
                            </td>
                           
                       <td style="text-align:left">
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("czxx") %>'></asp:Label>
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
                    <td align="center" width="100%" background="../images/menuFunction.gif">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/laypage/1.2/laypage.js"></script>

    <script type="text/javascript" src="../lib/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" src="../lib/datatables/1.10.0/jquery.dataTables.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

    <script type="text/javascript">
       
        /*用户-查看*/
        function member_show(title, url, id, w, h) {
            layer_show(title, url, w, h);
        }
</script>

    </form>
</body>
</html>
