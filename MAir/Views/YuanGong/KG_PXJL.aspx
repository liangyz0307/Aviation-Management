<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_PXJL.aspx.cs" Inherits="CUST.WKG.KG_PXJL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }

        .auto-style1 {
            width: 9%;
        }

        .auto-style2 {
            width: 7%;
        }

        .auto-style3 {
            width: 5%;
        }

        .auto-style4 {
            width: 14%;
        }

        .auto-style5 {
            width: 6%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                <%--                事件类型：
           <asp:DropDownList ID="ddlt_type" runat="server" class="select-box" Style="width: 80px;">
           </asp:DropDownList>--%>
                <td style="width: 6%;" align="left">部门：
             <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px; height: 28px;">
             </asp:DropDownList></td>
                <%--                级别：
           <asp:DropDownList ID="ddlt_jb" runat="server" class="select-box" Style="width: 80px;">
           </asp:DropDownList>--%>
                日期：
          <asp:TextBox ID="p_rqsj_ks" runat="server" class="input-text" onclick="lhgcalendar({format:'yyyy-MM-dd'} )" Width="100px" MaxLength="10"></asp:TextBox>
                <asp:TextBox ID="p_rqsj_js" runat="server" class="input-text" onclick="lhgcalendar({format:'yyyy-MM-dd'})"
                    Width="100px" MaxLength="10" Enabled="True"></asp:TextBox>
                状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px">
              </asp:DropDownList>
                <%--培训师编号：
           <asp:TextBox ID="tbx_pxs" runat="server" class="select-box" Style="width: 100px;">
           </asp:TextBox>
                受教育者编号：
           <asp:TextBox ID="tbx_sjyz" runat="server" class="select-box" Style="width: 100px;">
           </asp:TextBox>--%>
                <%--     <br />--%>
                考核结果：
           <asp:DropDownList ID="ddlt_khjg" runat="server" class="select-box" Style="width: 110px;">
           </asp:DropDownList>
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
                <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" Visible="true" OnClick="btn_add_Click" />
                <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7" OnClick="btn_dc_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">培训记录管理
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="6%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">受教育者
                                    </th>

                                    <th width="6%" style="text-align: center; vertical-align: middle;">类型
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">部门
                                    </th>

                                    <th width="6%" style="text-align: center; vertical-align: middle;">考核方式
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">考核结果
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">培训师
                                    </th>
                                    </th>
                                  <th width="6%" style="text-align: center; vertical-align: middle;">初审人
                                  </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">日期
                                    </th>
                                    </th>
                                <th width="6%" style="text-align: center; vertical-align: middle;">录入人
                                </th>
                                    <th width="6%" style="text-align: left;">状态
                                    </th>
                                    <th width="12%" style="text-align: center; vertical-align: middle;">操作
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_SJYZ" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"KG_PXJL_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("SJYZ") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label ID="lbl_type" runat="server" Text='<%#Eval("typemc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lbl_khfs" runat="server" Text='<%#Eval("KHFS") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_khjgmc" runat="server" Text='<%#Eval("khjgmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_fzr" runat="server" Text='<%#Eval("PXS") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_rq" runat="server" Text='<%#Eval("rqsjmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>

                            <td class="td-manage">
                                <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server">提交</asp:LinkButton>
                                <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server">审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要编辑该信息？')">编辑</asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                        </tr>
                    </>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table>
                    <tr>
                        <td align="center" width="98%">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="HF_yc" runat="server" />
        <script type="text/javascript">
            var login_syr = document.getElementById('login_syr');  //弹出层中的登录框
            var login_wxyr = document.getElementById('login_wxry');
            var over = document.getElementById('over'); //弹出层
            function show_syr() {
                login_syr.style.display = "block";
                over.style.display = "block";
            }
            function show_wxry() {
                login_wxry.style.display = "block";
                over.style.display = "block";
            }
            function btn_bc_syr() {
                btn_syr.style.display = "block";
            }
            $("#btn_bc_syr").click(function () {
                hide();
            });
            function hide() {
                login.style.display = "none";
                over.style.display = "none";
            }
        </script>
        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
