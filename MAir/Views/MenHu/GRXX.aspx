<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRXX.aspx.cs" Inherits="CUST.WKG.GRXX" %>


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
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server">
            <div class="panel-head" style="text-align: center">
                <strong class="icon-reorder">基本信息</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 编 号：</td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_ygbh" runat="server"></asp:Label>
                    </td>
                    <td rowspan="5" style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 照 片：<span class="c-red">*</span></td>
                    <td rowspan="5" style="width: 30%; text-align: center; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Image ID="img_ygzp" Style="width: 150px; height: 200px" runat="server" />

                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 姓 名：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xm" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">性 别：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xb" runat="server"></asp:Label>
                    </td>



                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">身 份 证 号：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_sfzh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">出 生 日 期：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_csrq" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">民 族：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_mz" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">联 系 电 话：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_lxdh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">部 门：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bm" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">岗 位：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">

                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工 作 地：</td>
                    <td colspan="3" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_gzd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">详 细 地 址：</td>
                    <td colspan="3" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xxdz" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">籍 贯：</td>
                    <td colspan="3" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_jg" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td colspan="4" style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"></td>


                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">毕 业 院 校：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_byyx" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">专 业：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zy" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">学 历：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xl" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">毕 业 时 间：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bysj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">入 职 时 间：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_rzsj" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">政 治 面 貌：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zzmm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合 同 关 系 所 属：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htgx" runat="server"></asp:Label></td>

                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合 同 类 型：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htlx" runat="server"></asp:Label></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">用 工 性 质：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_ygxz" runat="server"></asp:Label></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：</td>
                    <td colspan="3" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label></td>

                </tr>
            </table>
            <br />

            <%-- 返回--%>
            <div style="text-align: center">
                &nbsp;  
              <asp:Button ID="btn_fh" runat="server"
                  Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                  Width="199px" OnClick="btn_fh_Click"></asp:Button>
            </div>
        </form>
    </article>
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>

    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
</body>


</html>
