<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQJG_JCRW_Detail.aspx.cs" Inherits="CUST.WKG.AQJG_JCRW_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>检查任务详情</title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }

        #login, #login_1 {
            display: none;
            border: 1em solid #e4e5e6;
            height: 202px;
            width: 326px;
            position: absolute; /*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/
            top: 5%; /*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/
            left: 65%;
            z-index: 2; /*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/
            background: white;
        }

        #over, #over_1 {
            width: 100%;
            height: 100%;
            opacity: 0.5; /*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/
            filter: alpha(opacity=80);
            display: none;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 1;
            background: silver;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <div class="panel-head">
                <strong class="icon-reorder">检查任务</strong>
            </div>
            
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 50%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查人：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcr" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查时间：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcsj" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">被检查人：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_bjcr" runat="server"></asp:Label>
                    </td>

                </tr>



                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查单：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查内容：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcxm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">任务简要说明：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_rwsm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="21">检查记录
                                    </th>
                                </tr>
                                <tr>
                                    <th width="30" style="text-align: left;">序号
                                    </th>
                                    <th width="80" style="text-align: left;">责任人
                                    </th>
                                    <th width="80" style="text-align: left;">检查时间
                                    </th>
                                    <th width="80" style="text-align: left;">被检单位
                                    </th>
                                    <th width="80" style="text-align: left;">填报单位
                                    </th>
                                    <th width="80" style="text-align: left;">检查内容
                                    </th>
                                    <th width="80" style="text-align: left;">检查结果
                                    </th>
                                    <th width="80" style="text-align: left;">整改意见
                                    </th>
                                    <th width="80" style="text-align: left;">落实情况反馈
                                    </th>
                                    <th width="80" style="text-align: left;">检查人  
                                    </th>
                                    <%--<th width="80"  style="text-align:left;"> 
                                    操作     --%>
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
                                    <asp:HyperLink ID="hlnk_tzzrry" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JCJL_Detail.aspx?rwid=" + Eval("rwid")%>' Text='<%# Eval("tzzrry") %>'></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("jcsjmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("bjdwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("jcdmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("jcxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("jcjgmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("zgyj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("lsqkfk") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("jcr") %>'></asp:Label>
                                </td>
                                <%--<td class="td-manage">
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("RWID") %>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server">编辑</asp:LinkButton>
                                 <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("RWID") %>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server">删除</asp:LinkButton>
                            </td>--%>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table>
                    <tr>
                        <td align="center" class="auto-style1">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row cl">
                <div style="text-align: center">
                    <asp:Button ID="btn_fh" runat="server"
                        Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                        Width="199px" OnClick="btn_fh_Click"></asp:Button>
                </div>
                <input id="ChangeFlag" runat="server" type="hidden" />
            </div>
        </form>
        <script type="text/javascript" src="../css/js/jquery.js"></script>
        <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
        <script type="text/javascript" src="../css/js/H-ui.js"></script>
    </article>

</body>
<script src="../../Content/js/jquery.js" type="text/javascript"></script>
<script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<%--        <asp:HiddenField ID="HF_yc" runat="server" />

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

        </script>--%>
<script src="../css/js/jquery.js" type="text/javascript"></script>
</html>
