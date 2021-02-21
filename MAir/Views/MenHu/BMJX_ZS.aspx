<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMJX_ZS.aspx.cs" Inherits="CUST.WKG.BMJX_ZS" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style4 {
            width: 6%;
        }

        .auto-style7 {
            width: 11%;
        }

        .auto-style9 {
            width: 9%;
        }

        .auto-style10 {
            width: 5%;
        }

        .auto-style11 {
            width: 8%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">部门绩效
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">部门
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">总方案编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">总方案名称
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">绩效总分
                                    </th>
                                </tr>
                            </thead>
                             </table>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%">
                                    <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>                            
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lbl_jldj" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lbl_jlnr" runat="server" Text='<%#Eval("zfabh") %>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("zfamc") %>'></asp:Label>
                                </td>
                                <td width="5%">
                                    <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zf") %>'></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                              </table>
                    </ItemTemplate>
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
        <script type="text/javascript" src="../css/js/jquery.js"></script>
        <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
        <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
        <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    </form>
</body>
</html>
