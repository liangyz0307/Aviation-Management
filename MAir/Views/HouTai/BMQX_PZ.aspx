<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMQX_PZ.aspx.cs" Inherits="CUST.WKG.BMQX_PZ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                <table id="tb_bm">
                                    角色名称：
              <asp:Label ID="lbl_jsmc" runat="server" Text="Label"></asp:Label>
                
                    <tr>
                        <tr>具体部门授权：</tr>
                        <td>
                            长春导航保障部:
                            <asp:Button ID="btn_ccdhbzb" runat="server" Text="全选" OnClick="btn_ccdhbzb_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_ccdhbzb_cancel" runat="server" Text="取消" OnClick="btn_ccdhbzb_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            延吉航务保障部：
                            <asp:Button ID="btn_yjhwbzb" runat="server" Text="全选" OnClick="btn_yjhwbzb_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_yjhwbzb_cancel" runat="server" Text="取消" OnClick="btn_yjhwbzb_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            长白山航务保障部：
                            <asp:Button ID="btn_cbshwbzb" runat="server" Text="全选" OnClick="btn_cbshwbzb_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_cbshwbzb_cancel" runat="server" Text="取消" OnClick="btn_cbshwbzb_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            通化航务保障部：
                            <asp:Button ID="btn_thhwbzb" runat="server" Text="全选" OnClick="btn_thhwbzb_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_thhwbzb_cancel" runat="server" Text="取消" OnClick="btn_thhwbzb_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            白城航务保障部：
                            <asp:Button ID="btn_bchwbzb" runat="server" Text="全选" OnClick="btn_bchwbzb_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_bchwbzb_cancel" runat="server" Text="取消" OnClick="btn_bchwbzb_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            综合办公室：
                            <asp:Button ID="btn_zhbgs" runat="server" Text="全选" OnClick="btn_zhbgs_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_zhbgs_cancel" runat="server" Text="取消" OnClick="btn_zhbgs_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            航务管理部-部门领导：
                            <asp:Button ID="btn_hwglb_bmld" runat="server" Text="全选" OnClick="btn_hwglb_bmld_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_hwglb_bmld_cancel" runat="server" Text="取消" OnClick="btn_hwglb_bmld_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                             气象：
                            <asp:Button ID="btn_qx" runat="server" Text="全选" OnClick="btn_qx_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_qx_cancel" runat="server" Text="取消" OnClick="btn_qx_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             通导：
                            <asp:Button ID="btn_td" runat="server" Text="全选" OnClick="btn_td_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_td_cancel" runat="server" Text="取消" OnClick="btn_td_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                        <td>
                            航管：
                            <asp:Button ID="btn_hg" runat="server" Text="全选" OnClick="btn_hg_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                            <asp:Button ID="btn_hg_cancel" runat="server" Text="取消" OnClick="btn_hg_cancel_Click" class="btn radius" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mt-20">
            <asp:Repeater ID="rp_qxpz" runat="server">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="2">部门授权(全选)：
                                    <asp:Button ID="btn_quanxuan" runat="server" Text="全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_quanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_fanxuan" runat="server" Text="反选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_quxiao" runat="server" Text="全选取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_quxiao_Click"></asp:Button>
                                </th>
                                <th scope="col" colspan="14">功能：
                                    <asp:Button ID="btn_CXquanxuan" runat="server" Text="查询全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_CXquanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_CXquxiao" runat="server" Text="查询取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_CXquxiao_Click"></asp:Button>
                                    <asp:Button ID="btn_TJquanxuan" runat="server" Text="添加全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_TJquanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_TJquxiao" runat="server" Text="添加取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_TJquxiao_Click"></asp:Button>
                                    <asp:Button ID="btn_BJquanxuan" runat="server" Text="编辑全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_BJquanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_BJquxiao" runat="server" Text="编辑取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_BJquxiao_Click"></asp:Button>
                                    <asp:Button ID="btn_SCquanxuan" runat="server" Text="删除全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_SCquanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_SCquxiao" runat="server" Text="删除取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_SCquxiao_Click"></asp:Button>
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th style="text-align: center; vertical-align: middle;">子系统
                                </th>
                                <th style="text-align: center; vertical-align: middle;">模块
                                </th>
                                <th style="text-align: center; vertical-align: middle;">部门
                                </th>
                                <%--                             <th style="text-align: center; vertical-align: middle;">选择
                                </th>--%>
                                <th style="text-align: center; vertical-align: middle; width: 120px">功能
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="height: 50px">
                        <td runat="server" id="system_child">
                            <%#Eval("zxtmc")%>
                        </td>
                        <td>
                            <asp:Label ID="lbl_mc" runat="server" Text='<%#Eval("mkmc")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="cbxl_bmlb" runat="server" RepeatDirection="Horizontal" Width="800px">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <input type="checkbox" id="cbx_select" runat="server" value='<%# Eval("select_qxdm") %> ' />查询
                                <input type="checkbox" id="cbx_add" runat="server" value='<%# Eval("add_qxdm") %> ' />添加
                                <input type="checkbox" id="cbx_edit" runat="server" value='<%# Eval("edit_qxdm") %> ' />编辑
                                <input type="checkbox" id="cbx_delete" runat="server" value='<%#Eval("delete_qxdm") %> ' />删除
                                <input type="checkbox" id="cbx_sumbit" runat="server" value='<%# Eval("submit_qxdm") %> ' />提交
                                <input type="checkbox" id="cbx_sh" runat="server" value='<%# Eval("sh_qxdm") %> ' />审核
                                <input type="checkbox" id="cbx_bh" runat="server" value='<%# Eval("bh_qxdm") %> ' />驳回
                                <input type="checkbox" id="cbx_upload" runat="server" value='<%#Eval("upload_qxdm") %> ' />上传
                                <input type="checkbox" id="cbx_download" runat="server" value='<%# Eval("download_qxdm") %> ' />下载
                                <input type="checkbox" id="cbx_dr" runat="server" value='<%# Eval("dr_qxdm") %> ' />导入
                                <input type="checkbox" id="cbx_dc" runat="server" value='<%# Eval("dc_qxdm") %> ' />导出
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <table>
                <tr>
                    <td style="text-align: right">
                        <asp:Button ID="btn_bc" runat="server"
                            Text="保存" class="btn radius" BackColor="#60B1D7" ForeColor="White"
                            Width="199px" OnClick="btn_bc_Click"></asp:Button></td>
                    <td>&nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="btn_fh" runat="server"
                            Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                            Width="199px" OnClick="btn_fh_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
