<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CL_Select.aspx.cs" Inherits="CUST.WKG.ZXPX.main.CL_Select" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <style type="text/css">
        td.td_zxks {
            background: #F6FAFD;
            border: 1px dotted;
        }

        table.tab_zxks {
            background: #F6FAFD;
        }
        .auto-style1 {
            width: 8%;
        }
        .auto-style2 {
            width: 14%;
        }
        .auto-style3 {
            width: 25%;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <div class="panel-head">
                <strong class="icon-reorder">考试选择</strong>
            </div>
            <table style="width: 100%" class="tab_zxks">
                <tr>
                    <td style="width: 12%;" align="right"></td>
                    <td style="width: 12%;" align="right">难度：
                         <asp:DropDownList ID="ddlt_stnd" runat="server" class="select-box" Width="122px"></asp:DropDownList>
                    </td>
                    <td style="width: 12%;" align="right">科目：
                        <asp:DropDownList ID="ddlt_km" runat="server" class="select-box" Width="122px"></asp:DropDownList>
                    </td>
                    
                    <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位：
                        <asp:DropDownList ID="ddlt_gw" runat="server" class="select-box" Width="70%"></asp:DropDownList>
                    </td>
                    <td style="width: 25%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btn_cx_ks" runat="server" class="btn  radius" Text="查询考试" ForeColor="White" BackColor="#60B1D7" OnClick="btn_cx_ks_Click" />
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table style="width: 100%" class="tab_zxks">
                <tr>
                    <td style="width: 38%;" align="right">可选考试：
                         <asp:DropDownList ID="ddlt_zj_cl" runat="server" class="select-box" Width="300px" OnSelectedIndexChanged="ddlt_zj_cl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td style="width: 25%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btn_cx_ks_detail" runat="server" class="btn  radius" Text="查看考试详情" ForeColor="White" BackColor="#60B1D7" OnClick="btn_cx_ks_detail_Click" />
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 40%; margin: auto; vertical-align: middle; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                <tbody>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;">
                        <th scope="col" colspan="16"><strong>试卷详情</strong></th>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="auto-style1">试卷名称：</td>
                        <td colspan="3" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_mc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">试卷总分：</td>
                        <td colspan="3" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_zf" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">选择题数量：</td>
                        <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="auto-style1">
                            <asp:Label ID="lbl_xz_sl" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="auto-style1">单个选择题分值：</td>
                        <td style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="auto-style2">
                            <asp:Label ID="lbl_xz_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">判断题数量：</td>
                        <td style="width: 8%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_pd_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">单个判断题分值：</td>
                        <td style="width: 14%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_pd_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr1" style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks" runat="server">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">填空题数量：</td>
                        <td style="width: 8%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_tk_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">单个填空题分值：</td>
                        <td style="width: 14%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_tk_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr3" style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks" runat="server">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">时长(分钟)：</td>
                        <td style="width: 8%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_sc" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">试题难度：</td>
                        <td style="width: 14%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">适用科目：</td>
                        <td style="width: 8%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_km" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">适用岗位：</td>
                        <td style="width: 14%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_zxks">
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">出题人：</td>
                        <td style="width: 8%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_ctr" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">出题时间：</td>
                        <td style="width: 14%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_zxks">
                            <asp:Label ID="lbl_ctsj" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <table width="100%" id="tab_cz" runat="server">
                <tr align="center" style="width: 100%">
                    <td style="width: 10%"></td>
                    <td style="width: 30%" class="td_zxks"><strong style="font-size: 200%">成绩查询</strong></td>
                    <td style="width: 20%"></td>
                    <td style="width: 30%" class="td_zxks"><strong style="font-size: 200%">进入考试</strong></td>
                    <td style="width: 10%"></td>
                </tr>
                <tr align="center">
                    <td style="width: 10%"></td>
                    <td style="width: 30%" class="td_zxks"><strong style="font-size: 150%">考生号</strong>&nbsp;
                        <asp:TextBox ID="tbx_ksh" runat="server" Width="30%" Height="24px" MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_cjcx" runat="server" class="btn  radius" Text="查询成绩" ForeColor="White" BackColor="#60B1D7" Height="59px" Width="30%" OnClick="btn_cjcx_Click" />
                    </td>
                    <td style="width: 20%"></td>
                    <td style="width: 30%" class="td_zxks">
                        <asp:Button ID="btn_ksks" runat="server" class="btn  radius" Text="开始考试" ForeColor="White" BackColor="#60B1D7" Height="59px" Width="200px" OnClick="btn_ksks_Click" />
                        <br />
                    </td>
                    <td style="width: 10%"></td>
                </tr>
            </table>
            <br />
                <asp:DataList ID="dlt_djk" runat="server" DataKeyField="id">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 50%;  border: 1px solid #C0D9D9; background-color: #F6FAFD">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16"><strong style="font-size: 150%">成绩列表</strong></th>
                                </tr>
                                <tr class="text-c">
                                    <th width="10%" style="text-align: center; vertical-align: middle;">总分</th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">选择题</th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">判断题</th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">填空题</th>
                                    <th width="20%" style="text-align: center; vertical-align: middle;">交卷时间</th>
                                </tr>
                            </thead>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 50%;  border: 1px solid #C0D9D9; background-color: #F6FAFD">
                            <tbody>
                                <tr class="text-c">
                                    <td width="10%" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_zf" runat="server" Text='<%#Eval("zf") %>'></asp:Label></td>
                                    <td width="10%" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_xzt" runat="server" Text='<%#Eval("xzt") %>'></asp:Label></td>
                                    <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_pdt" runat="server" Text='<%#Eval("pdt") %>'></asp:Label></td>
                                    <td width="10%" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_tkt" runat="server" Text='<%#Eval("tkt") %>'></asp:Label></td>
                                    <td width="20%" class="class_td" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_kssj_jssj" runat="server" Text='<%#Eval("jssj") %>'></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            <br />
            <br />
            <br />
            <br />
            <table style="width: 50%; margin: auto;">
                <asp:HiddenField ID="HF_cl_id" runat="server" />
            </table>
        </form>
    </article>
</body>
</html>
