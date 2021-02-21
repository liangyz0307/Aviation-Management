<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSQX_PZ.aspx.cs" Inherits="CUST.WKG.JSQX_PZ" %>

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
                角色名称：
              <asp:Label ID="lbl_jsmc" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="mt-20">
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <thead>
                    <tr>
                        <th scope="col" colspan="16">角色权限配置
                        </th>
                    </tr>
                    <!--全选-->
                    <tr>
                        <th scope="col" colspan="14">&nbsp;&nbsp;&nbsp;&nbsp;地区批量操作：
                            <asp:Button ID="btn_CC" runat="server" Text="长春全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_CC_Click"></asp:Button>
                            <asp:Button ID="btn_YJ" runat="server" Text="延吉全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_YJ_Click"></asp:Button>
                            <asp:Button ID="btn_CBS" runat="server" Text="长白山全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_CBS_Click"></asp:Button>
                            <asp:Button ID="btn_TH" runat="server" Text="通化全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_TH_Click"></asp:Button>
                            <asp:Button ID="btn_BCqx" runat="server" Text="白城全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_BCqx_Click"></asp:Button>
                            
                        </th>
                    </tr>
                    <tr>
                        <th scope="col" colspan="14">&nbsp;&nbsp;&nbsp;&nbsp;功能批量操作：
                            <asp:Button ID="btn_CXquanxuan" runat="server" Text="查询全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_CXquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_TJquanxuan" runat="server" Text="添加全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_TJquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_BJquanxuan" runat="server" Text="编辑全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_BJquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_SCquanxuan" runat="server" Text="删除全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_SCquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_Submitqx" runat="server" Text="提交全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_Submitqx_Click"></asp:Button>
                            <asp:Button ID="btn_SHquanxuan" runat="server" Text="审核全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_SHquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_BHquanxuan" runat="server" Text="驳回全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_BHquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_Uploadqx" runat="server" Text="上传全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_Uploadqx_Click"></asp:Button>
                            <asp:Button ID="btn_Downloadqx" runat="server" Text="下载全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_Downloadqx_Click"></asp:Button>
                            <asp:Button ID="btn_DRquanxuan" runat="server" Text="导入全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_DRquanxuan_Click"></asp:Button>
                            <asp:Button ID="btn_DCquanxuan" runat="server" Text="导出全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_DCquanxuan_Click"></asp:Button>

                        </th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="rp_qxpz" runat="server">
                <HeaderTemplate>

                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                    <tr class="text-c">
                        <%--<th width="30" style="text-align: center; vertical-align: middle;">序号
                                </th>--%>
                        <th style="text-align: center; vertical-align: middle;">子系统
                        </th>
                        <th style="text-align: center; vertical-align: middle;">模块
                        </th>
                        <th style="text-align: center; vertical-align: middle;">地区
                        </th>
                        <th style="text-align: center; vertical-align: middle;">功能
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

                            <%--<asp:CheckBoxList ID="cbxl_dq" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>--%>
                            <input type="checkbox" id="cbx_cc" runat="server" value='<%# Eval("cc") %> ' />长春
                                <input type="checkbox" id="cbx_yj" runat="server" value='<%# Eval("yj") %> ' />延吉
                                <input type="checkbox" id="cbx_cbs" runat="server" value='<%# Eval("cbs") %> ' />长白山
                                <input type="checkbox" id="cbx_th" runat="server" value='<%# Eval("th") %> ' />通化
                                <input type="checkbox" id="cbx_bc" runat="server" value='<%# Eval("bc") %> ' />白城
                        </td>
                        <td>
                            <%--<asp:CheckBoxList ID="cbxl_qx" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>--%>
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

            <%--  <table>
                <tr>
                    <td align="center" width="100%">
                        <cc1:pager id="pg_fy" runat="server" width="98%" onpagechanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>--%>

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

<%--  <script type="text/javascript">
                function Select()
                {
                  
                   
                    var cbx_select = document.getElementById("cbx_select");//查询
                    var cbx_add = document.getElementById("cbx_add");//添加
                    var cbx_edit = document.getElementById("cbx_edit");//编辑
                    var cbx_delete = document.getElementById("cbx_delete");
                    
                    if (cbx_add.checked==true || cbx_edit.checked==true||cbx_delete.checked==true)
                    {
                        cbx_select.checked = true;
                    }
                }
            </script>--%>
</html>
