<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRJX_YGXX.aspx.cs" Inherits="MAir.Views.JXGL.GRJX_YGXX" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                <strong class="icon-reorder">员工详情</strong>
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
                <%--   <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td colspan="4" style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                 </td>  
            </tr>--%>
                <%-- <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    执 照 文 件 号 码：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_zzwjhm" runat="server" ></asp:Label></td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    执 照 编 号：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_zzbh" runat="server" ></asp:Label></td>             
            </tr>        
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    颁 发 日 期：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_bfrq" runat="server" ></asp:Label></td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    执 照 签 注 类 别：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_zzqzlb" runat="server" ></asp:Label></td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    注 册 类 别 有 效 期：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_zclbyxq" runat="server" ></asp:Label></td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    异 地 签 注：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_ydqz" runat="server" ></asp:Label></td>               
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    异 地 签 注 类 别：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_ydqzlb" runat="server" ></asp:Label></td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    异 地 签 注 有 效 期：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:Label ID="lbl_ydqzyxq" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                  <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    英 语 等 级：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_yydj" runat="server" ></asp:Label>
                    </td>
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    英 语 有 效 期：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_yyyxq" runat="server" ></asp:Label></td>             
            </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    体 检 等 级：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_tjdj" runat="server" ></asp:Label></td>
                  <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                 体 检 有 效 期：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_tjyxq" runat="server" ></asp:Label></td>
            </tr>--%>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合 同 关 系：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htgx" runat="server"></asp:Label></td>
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合 同 类 型：</td>
                    <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htlx" runat="server"></asp:Label></td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：</td>
                    <td colspan="3" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
            <div>
                <div id="div">
                    <strong class="icon-reorder">英语资质列表</strong><br />
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort">
                                <thead>
                                    <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                                    <tr class="text-c">
                                        <th width="40" style="text-align: center; vertical-align: middle;">序号
                                        </th>
                                        <th width="90" style="text-align: center; vertical-align: middle;">英语等级
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">英语有效期
                                        </th>
                                        <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="text-c">
                                    <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                                    <td>
                                        <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>                      
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("yydjmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("yyyxqmc") %>'></asp:Label>
                                    </td>
                                    <%--   <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <strong class="icon-reorder">执照资质列表</strong>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort">
                                <thead>
                                    <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                                    <tr class="text-c">
                                        <th width="40" style="text-align: center; vertical-align: middle;">序号
                                        </th>
                                        <th width="90" style="text-align: center; vertical-align: middle;">执照文件号码
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">执照编号
                                        </th>
                                        <th width="90" style="text-align: center; vertical-align: middle;">执照颁发日期
                                        </th>
                                        <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="text-c">
                                    <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                                    <td>
                                        <%#(cpage2-1)*psize2+(Container.ItemIndex + 1)%>
                             
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("zzwjhm") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("zzbh") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("bfrq") %>'></asp:Label>
                                    </td>

                                    <%-- <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <strong class="icon-reorder">签注资质列表</strong>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort">
                                <thead>
                                    <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                                    <tr class="text-c">
                                        <th width="40" style="text-align: center; vertical-align: middle;">序号
                                        </th>
                                        <th width="90" style="text-align: center; vertical-align: middle;">签注专业
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">签注类别
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">签注项
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">签注有效期
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">签注地
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">异地签注
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">异地签注项
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">异地签注有效期
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">异地签注地
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">体检等级
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">体检有效期
                                        </th>
                                        <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="text-c">
                                    <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                                   </td>--%>
                                    <td>
                                        <%#(cpage3-1)*psize3+(Container.ItemIndex + 1)%> 
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("qzzymc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("qzlbmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("qzxmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("qzyxqmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("qzd") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("ydqzmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("ydqzxmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("ydqzyxqmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("ydqzd") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("tjdjmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("tjyxqmc") %>'></asp:Label>
                                    </td>
                                    <%--  <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <div id="div_ll">
                    <strong class="icon-reorder">员工履历详情</strong>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort">
                                <thead>
                                    <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                                    <tr class="text-c">
                                        <th width="40" style="text-align: center; vertical-align: middle;">序号
                                        </th>
                                        <th width="90" style="text-align: center; vertical-align: middle;">工作单位
                                        </th>
                                        <th width="60" style="text-align: center; vertical-align: middle;">工作部门
                                        </th>
                                        <th width="50" style="text-align: center; vertical-align: middle;">工作岗位
                                        </th>
                                        <th width="50" style="text-align: center; vertical-align: middle;">工作地点
                                        </th>
                                        <th width="50" style="text-align: center; vertical-align: middle;">起止日期
                                        </th>
                                        <th width="50" style="text-align: center; vertical-align: middle;">截止日期
                                        </th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="text-c">
                                    <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                                    <td>
                                        <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>                           
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("gzdw") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("gzbm") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("gzgw") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gzdd") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_gzdd" runat="server" Text='<%#Eval("qzrq") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("jzrq") %>'></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <div style="text-align: center">
                    &nbsp;  
              <asp:Button ID="btn_fh" runat="server"
                  Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                  Width="199px" OnClick="btn_fh_Click"></asp:Button>
                </div>
            </div>
        </form>
    </article>
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //英语有效期
            $("#tbx_yyyxq").blur(function () {
                if ($("#tbx_yyyxq").val() != "") {
                    $("#lbl_yyyxq").text("正确");
                    $("#lbl_yyyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_yyyxq").text("错误");
                    $("#lbl_yyyxq").css("color", "#ff0000");
                }
            });
            //执照文件号码
            $("#tbx_zzwjhm").blur(function () {
                if ($("#tbx_zzwjhm").val() != "") {
                    $("#lbl_zzwjhm").text("正确");
                    $("#lbl_zzwjhm").css("color", "#00ff00");
                } else {
                    $("#lbl_zzwjhm").text("错误");
                    $("#lbl_zzwjhm").css("color", "#ff0000");
                }
            });
            //执照编号
            $("#tbx_zzbh").blur(function () {
                if ($("#tbx_zzbh").val() != "") {
                    $("#lbl_zzbh").text("正确");
                    $("#lbl_zzbh").css("color", "#00ff00");
                } else {
                    $("#lbl_zzbh").text("错误");
                    $("#lbl_zzbh").css("color", "#ff0000");
                }
            });
            //颁发日期
            $("#tbx_bfrq").blur(function () {
                if ($("#tbx_bfrq").val() != "") {
                    $("#lbl_bfrq").text("正确");
                    $("#lbl_bfrq").css("color", "#00ff00");
                } else {
                    $("#lbl_bfrq").text("错误");
                    $("#lbl_bfrq").css("color", "#ff0000");
                }
            });
            //注册类别有效期
            $("#tbx_zclbyxq").blur(function () {
                if ($("#tbx_zclbyxq").val() != "") {
                    $("#lbl_zclbyxq").text("正确");
                    $("#lbl_zclbyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_zclbyxq").text("错误");
                    $("#lbl_zclbyxq").css("color", "#ff0000");
                }
            });
            //异地签注有效期
            $("#tbx_ydqzyxq").blur(function () {
                if ($("#tbx_ydqzyxq").val() != "") {
                    $("#lbl_ydqzyxq").text("正确");
                    $("#lbl_ydqzyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_ydqzyxq").text("错误");
                    $("#lbl_ydqzyxq").css("color", "#ff0000");
                }
            });
            //体检有效期
            $("#tbx_tjyxq").blur(function () {
                if ($("#tbx_tjyxq").val() != "") {
                    $("#lbl_tjyxq").text("正确");
                    $("#lbl_tjyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_tjyxq").text("错误");
                    $("#lbl_tjyxq").css("color", "#ff0000");
                }
            });
            $("#btn_save").click(function () {

                if ($("#tbx_mc").val() == "") {
                    $("#lbl_mc").text("错误：名称不能为空！");
                    $("#lbl_mc").css("color", "#ff0000");
                    return false;
                }

            });

        });
    </script>
</body>
</html>
