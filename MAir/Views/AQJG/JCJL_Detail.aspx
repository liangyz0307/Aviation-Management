<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JCJL_Detail.aspx.cs" Inherits="MAir.Views.AQJG.JCJL_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
        <form id="form1" runat="server">
            <div class="panel-head">
                <strong class="icon-reorder">检查记录</strong>
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
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查结果：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcjg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">被检单位：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_bjdw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">填报单位：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_tbdw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检查内容：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_jcxm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改意见：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_zgyj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任单位：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_tzzrdw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任人：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_tzzrry" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">落实情况反馈：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                        <asp:Label ID="lbl_lsqkfk" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">查看文件：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; width: 67%;" class="td_sjsc">
                         <asp:Button ID="btn_ck" runat="server"
                        Text="下载" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                        Width="60px" OnClick="btn_ck_Click"></asp:Button>
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
                                <th scope="col" colspan="400">
                                                                           长春保障部自查整改表
                                </th>
                            </tr>
                            <tr class="text-c">
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    责任人
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    检查单
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    整改项目
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    整改时限
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    问题来源
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   整改进度
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   问题类别
                                </th>
                                 <th width="10%" style="text-align: center; vertical-align: middle;">
                                     状态
                                 </th>
<%--                                  <th width="15%">
                                      操作
                                </th>--%>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                                <td>
                                    <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                                </td>
                                <td>
                                    <%-- <asp:Label ID="Labe_sfr" runat="server" Text='<%#Eval("sfrxm") %>'></asp:Label>--%>
                                    <asp:HyperLink ID="hlnk_zrr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"KG_ZGdetail.aspx?id=" + Eval("id")%>' Text='<%# Eval("zrrxm") %>'></asp:HyperLink> 

                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("jcdmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_zgxm" runat="server" Text='<%#Eval("zgxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_zgsx" runat="server" Text='<%#Eval("zgsxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_wtly" runat="server" Text='<%#Eval("wtly") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zgjd" runat="server" Text='<%#Eval("zgjd") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_wtlb" runat="server" Text='<%#Eval("wtlb") %>'></asp:Label>
                                </td>
                             <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                             </td>
                               <%-- <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该惩罚信息？')">删除</asp:LinkButton>

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
                        <td align="center" width="100%">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
        </div>
            <div class="row cl">
                <div style="text-align: center">
                    <asp:Button ID="btn_fh" runat="server"
                        Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                        Width="199px" OnClick="btn_fh_Click1"></asp:Button>
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

<script src="../css/js/jquery.js" type="text/javascript"></script>
</html>
