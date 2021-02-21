<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YG_Add.aspx.cs" Inherits="CUST.WKG.YG_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="pragma" content="no-cache" />

    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate" />

    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT" />

    <meta http-equiv="expires" content="0" />
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
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
            <div class="panel-head">
                <strong class="icon-reorder">员工添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 姓 名：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xm" runat="server" class="input-text" placeholder="员工姓名" MaxLength="32"></asp:TextBox></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xm" runat="server"></asp:Label></td>


                    <td rowspan="6" style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 照 片：<span class="c-red">*</span></td>
                    <td rowspan="6" style="width: 10%; text-align: center; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Image ID="img_ygzp" runat="server" />

                        <div id="preview"></div>
                    </td>
                    <td rowspan="6" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">&nbsp;</td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">身 份 证 号：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sfzh" runat="server" class="input-text" placeholder="身份证号" MaxLength="18" OnTextChanged="tbx_sfzh_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_sfzh" runat="server"></asp:Label></td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 性 别：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xb" runat="server"></asp:Label>

                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"></td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">出 生 日 期：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_csrq" runat="server"></asp:Label>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"></td>

                </tr>
                <%-- <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
               
           
            <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   入 职 年 份：<span class="c-red">*</span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                  
                    <select id="myYear" runat="server"></select>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_rznf" runat="server" ></asp:Label></td>
            
         
         </tr>--%>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">民 族：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_mz" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_mz" runat="server"></asp:Label></td>


                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">部 门：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlt_bm" runat="server" OnSelectedIndexChanged="ddlt_bm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lbl_bm" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">岗 位：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlt_gw" runat="server" OnSelectedIndexChanged="ddlt_gw_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">上 传 照 片：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:FileUpload ID="ImageUpload" runat="server" onchange="chgImg(this)" />


                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_sc" runat="server"></asp:Label></td>


                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工 作 地：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_gzd" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_gzd" runat="server"></asp:Label></td>
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">联 系 电 话：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_lxdh" runat="server" class="input-text" placeholder="联系电话" MaxLength="15"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_lxdh" runat="server"></asp:Label></td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">详 细 地 址：</td>
                    <td colspan="4" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xxdz" runat="server" class="input-text" placeholder="详细地址" MaxLength="200"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xxdz" runat="server"></asp:Label></td>



                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">籍 贯：<span class="c-red">*</span></td>
                    <td colspan="4" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jg" runat="server" class="input-text" placeholder="籍贯" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_jg" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6" style="width: 10%; height: 30px; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"></td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">毕 业 院 校：</td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_byyx" runat="server" class="input-text" placeholder="毕业院校" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_byyx" runat="server"></asp:Label></td>


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">专 业：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zy" runat="server" class="input-text" placeholder="专业" MaxLength="100"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zy" runat="server"></asp:Label></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">学 历：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_xl" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xl" runat="server"></asp:Label></td>


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">毕 业 时 间：</td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bysj" runat="server" class="input-text" placeholder="毕业时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bysj" runat="server"></asp:Label></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">入 职 时 间：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_rzsj" runat="server" class="input-text" placeholder="入职时间(保存后不可更改！)" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_rzsj" runat="server"></asp:Label></td>


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">政 治 面 貌：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zzmm" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zzmm" runat="server"></asp:Label></td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合同关系所属：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_htgx" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htgx" runat="server"></asp:Label></td>

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">合 同 类 型：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_htlx" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_htlx" runat="server"></asp:Label></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">用工性质：</td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_ygxz" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="Label1" runat="server"></asp:Label></td>

                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">&nbsp;</td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">&nbsp;</td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">&nbsp;</td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：</td>
                    <td colspan="4" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text" placeholder="备注" MaxLength="200"></asp:TextBox>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6" style="width: 10%; height: 30px; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"></td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">


                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">初 审 人：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_csr" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_csr" runat="server"></asp:Label></td>
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">终 审 人：<span class="c-red">*</span></td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zsr" runat="server"></asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zsr" runat="server"></asp:Label></td>
                </tr>

                <%--    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              
              
             

               <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
               </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="Label2" runat="server" ></asp:Label></td>                           
            </tr>--%>
            </table>


            <div class="row cl">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                    <br />
                    <asp:Button ID="btn_save" runat="server"
                        Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                        Width="199px" OnClick="btn_save_Click"></asp:Button>
                    &nbsp; 
            <asp:Button ID="btn_fh" runat="server"
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                </div>
            </div>
            <asp:HiddenField ID="HF_lj" runat="server" />
        </form>
    </article>
</body>
<script src="../../Content/js/jquery.js" type="text/javascript"></script>
<script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>

<script type="text/javascript">
    window.onload = function () {
        //设置年份的选择 
        var myDate = new Date();
        var startYear = myDate.getFullYear() - 50;//起始年份 
        var endYear = myDate.getFullYear() + 50;//结束年份 
        var obj = document.getElementById('myYear')

        for (var i = startYear; i <= endYear; i++) {

            obj.options.add(new Option(i, i));
        }
        obj.options[obj.options.length - 51].selected = 1;
    }
    function chgImg(file) {
        //img控件预览图片
        var FileUpload1 = $("#ImageUpload").val();

        $("#img_ygzp").attr("src", "file:///" + FileUpload1);
        //div预览图片（兼容模式）
        var prevDiv = document.getElementById('preview');


        if (file.files && file.files[0]) {
            var reader = new FileReader();
            reader.onload = function (evt) {
                prevDiv.innerHTML = '<img src="' + evt.target.result + '" style="height:200px;width:150px" />';
            }
            reader.readAsDataURL(file.files[0]);
        }
        else {
            prevDiv.innerHTML = '<div class="img" style="height:200px;width:150px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale,src=\'' + file.value + '\')"></div>';
        }
    }



</script>
<script type="text/javascript">          
    员工身份证号4
    function tbx_sfzh_TextChanged() {
        alert(1);
        if ($("#tbx_sfzh").val() != "") {
            if ($("#tbx_sfzh").val().length != 18) {
                $("#lbl_sfzh").text("错误:身份证号必须输入18位");
                $("#lbl_sfzh").css("color", "#ff0000");
            }
            else {
                $("#lbl_sfzh").text("正确");
                $("#lbl_sfzh").css("color", "#00ff00");
                //性别
                var sfzh = $(" #tbx_sfzh").val();
                var xb = sfzh.substr(16, 1);
                if (xb % 2 == 0) {
                    $("#lbl_xb").text("女");
                } else {
                    $("#lbl_xb").text("男");
                }
                //出生日期
                var csrq = sfzh.substr(6, 8);
                $("#lbl_csrq").text(csrq);
            }
        }
        else {
            $("#lbl_sfzh").text("错误");
            $("#lbl_sfzh").css("color", "#ff0000");
        }
    };
</script>
<script type="text/javascript">
    $(document).ready(function () {

        员工身份证号4
        $("#tbx_sfzh").blur(function () {
            if ($("#tbx_sfzh").val() != "") {
                if ($("#tbx_sfzh").val().length != 18) {
                    $("#lbl_sfzh").text("错误:身份证号必须输入18位");
                    $("#lbl_sfzh").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sfzh").text("正确");
                    $("#lbl_sfzh").css("color", "#00ff00");
                    //性别
                    var sfzh = $(" #tbx_sfzh").val();
                    var xb = sfzh.substr(16, 1);
                    if (xb % 2 == 0) {
                        $("#lbl_xb").text("女");
                    } else {
                        $("#lbl_xb").text("男");
                    }
                    //出生日期
                    var csrq = sfzh.substr(6, 8);
                    $("#lbl_csrq").text(csrq);
                }
            }
            else {
                $("#lbl_sfzh").text("错误");
                $("#lbl_sfzh").css("color", "#ff0000");
            }
        });


        //$("#btn_save").click(function () {
        //    var flag = true;
        //    //图片

        //        if ($("#ImageUpload").val() == "") {
        //            $("#lbl_sc").text("错误");
        //            $("#lbl_sc").css("color", "#ff0000");
        //            $("#ImageUpload").focus();
        //            flag = false;
        //        }
        //    //员工姓名2

        //            if ($("#tbx_xm").val() == "") {
        //                $("#lbl_xm").text("错误");
        //                $("#lbl_xm").css("color", "#ff0000");
        //                $("#tbx_xm").focus();
        //                flag = false;
        //            }
        //员工身份证号4

        //if ($("#tbx_sfzh").val() != "") {
        //    if ($("#tbx_sfzh").val().length != 18) {
        //        $("#lbl_sfzh").text("错误:身份证号必须输入18位");
        //        $("#lbl_sfzh").css("color", "#ff0000");
        //        $("#tbx_sfzh").focus();
        //        flag = false;
        //    }                               
        //}
        //else {
        //    $("#lbl_sfzh").text("错误");
        //    $("#lbl_sfzh").css("color", "#ff0000");
        //    $("#tbx_sfzh").focus();
        //    flag = false;
        //}
        //    //民族6

        //                    if ($("#ddlt_mz option:selected").val() == "-1") {

        //                        $("#lbl_mz").text("请选择");
        //                        $("#lbl_mz").css("color", "#ff0000");
        //                        $("#ddlt_mz").focus();
        //                        flag = false;
        //                    }
        //    //联系电话7

        //                        if ($("#tbx_lxdh").val() == "") {
        //                            $("#lbl_lxdh").text("错误");
        //                            $("#lbl_lxdh").css("color", "#ff0000");
        //                            $("#tbx_lxdh").focus();
        //                            flag = false;
        //                        }
        //                        else {
        //                            if (!$("#tbx_lxdh").val().match(/^[1][3578]\d{9}$/)) {
        //                                $("#lbl_lxdh").text("错误：格式错误！");
        //                                $("#lbl_lxdh").css("color", "#ff0000");
        //                                $("#tbx_lxdh").focus();
        //                                flag = false;
        //                            }

        //                        }
        //    //工作地10
        //                            if ($("#ddlt_gzd option:selected").val() == "-1") {
        //                                $("#lbl_gzd").text("请选择");
        //                                $("#lbl_gzd").css("color", "#ff0000");
        //                                $("#ddlt_gzd").focus();
        //                                flag = false;
        //                            }
        //    //籍贯12
        //                                if ($("#tbx_jg").val() == "") {
        //                                    $("#lbl_jg").text("错误");
        //                                    $("#lbl_jg").css("color", "#ff0000");
        //                                    $("#tbx_jg").focus();
        //                                    flag = false;
        //                                }
        //    //专业14
        //                                    if ($("#tbx_zy").val() == "") {

        //                                        $("#lbl_zy").text("错误");
        //                                        $("#lbl_zy").css("color", "#ff0000");
        //                                        $("#tbx_zy").focus();
        //                                        flag = false;
        //                                    }
        //    //入职时间
        //                                    if ($("#tbx_rzsj").val() == "") {

        //                                        $("#lbl_rzsj").text("错误");
        //                                        $("#lbl_rzsj").css("color", "#ff0000");
        //                                        $("#tbx_rzsj").focus();
        //                                        flag = false;
        //                                    }
        //    //学历15
        //                                    if ($("#ddlt_xl option:selected").val() == "-1") {

        //                                        $("#lbl_xl").text("请选择");
        //                                        $("#lbl_xl").css("color", "#ff0000");
        //                                        $("#ddlt_xl").focus();
        //                                        flag = false;
        //                                    }
        //    //政治面貌18
        //                                        if ($("#ddlt_zzmm option:selected").val() == "-1") {

        //                                            $("#lbl_zzmm").text("请选择");
        //                                            $("#lbl_zzmm").css("color", "#ff0000");
        //                                            $("#ddlt_zzmm").focus();
        //                                            flag = false;
        //                                        }
        //    //合同关系32
        //                                            if ($("#ddlt_htgx option:selected").val() == "-1") {

        //                                                $("#lbl_htgx").text("请选择");
        //                                                $("#lbl_htgx").css("color", "#ff0000");
        //                                                $("#ddlt_htgx").focus();
        //                                                flag = false;
        //                                            }

        //    //合同类型33
        //                                            if ($("#ddlt_htlx option:selected").val() == "-1") {

        //                                                $("#lbl_htlx").text("请选择");
        //                                                $("#lbl_htlx").css("color", "#ff0000");
        //                                                $("#ddlt_htlx").focus();
        //                                                flag = false;
        //                                            }
        //                                           // alert(flag);
        //            return flag;

        //});




        ////图片
        //$("#ImageUpload").blur(function () {
        //    if ($("#ImageUpload").val() != "") {
        //        $("#lbl_sc").text("正确");
        //        $("#lbl_sc").css("color", "#00ff00");

        //    } else {
        //        $("#lbl_sc").text("错误");
        //        $("#lbl_sc").css("color", "#ff0000");

        //    }

        //});

        ////员工姓名2
        //$("#tbx_xm").blur(function () {
        //    if ($("#tbx_xm").val() != "") {
        //        $("#lbl_xm").text("正确");
        //        $("#lbl_xm").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_xm").text("错误");
        //        $("#lbl_xm").css("color", "#ff0000");
        //    }
        //});

        ////入职时间
        //$("#tbx_rzsj").blur(function () {
        //    if ($("#tbx_rzsj").val() != "") {
        //        $("#lbl_rzsj").text("正确");
        //        $("#lbl_rzsj").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_rzsj").text("错误");
        //        $("#lbl_rzsj").css("color", "#ff0000");
        //    }
        //});




        ////民族6
        //$("#ddlt_mz").change(function () {
        //    if ($("#ddlt_mz option:selected").val() != "-1") {
        //        $("#lbl_mz").text("正确");
        //        $("#lbl_mz").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_mz").text("请选择");
        //        $("#lbl_mz").css("color", "#ff0000");
        //    }
        //});
        //联系电话7
        $("#tbx_lxdh").blur(function () {

            if ($("#tbx_lxdh").val() == "") {
                $("#lbl_lxdh").text("错误");
                $("#lbl_lxdh").css("color", "#ff0000");
            }
            else {
                if (!$("#tbx_lxdh").val().match(/^[1][3578]\d{9}$/)) {
                    $("#lbl_lxdh").text("错误：格式错误！");
                    $("#lbl_lxdh").css("color", "#ff0000");
                }
                else {
                    $("#lbl_lxdh").text("正确");
                    $("#lbl_lxdh").css("color", "#00ff00");
                }
            }
        });
        ////工作地10
        //$("#ddlt_gzd").change(function () {
        //    if ($("#ddlt_gzd option:selected").val() != "-1") {
        //        $("#lbl_gzd").text("正确");
        //        $("#lbl_gzd").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_gzd").text("请选择");
        //        $("#lbl_gzd").css("color", "#ff0000");
        //    }
        //});
        ////详细地址11
        //$("#tbx_xxdz").blur(function () {

        //    $("#lbl_xxdz").text("正确");
        //    $("#lbl_xxdz").css("color", "#00ff00");


        //});
        ////籍贯12
        //$("#tbx_jg").blur(function () {
        //    if ($("#tbx_jg").val() != "") {
        //        $("#lbl_jg").text("正确");
        //        $("#lbl_jg").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_jg").text("错误");
        //        $("#lbl_jg").css("color", "#ff0000");
        //    }
        //});
        ////毕业学校13
        //$("#tbx_byyx").blur(function () {

        //    $("#lbl_byyx").text("正确");
        //    $("#lbl_byyx").css("color", "#00ff00");


        //});
        ////专业14
        //$("#tbx_zy").blur(function () {
        //    if ($("#tbx_zy").val() != "") {
        //        $("#lbl_zy").text("正确");
        //        $("#lbl_zy").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_zy").text("错误");
        //        $("#lbl_zy").css("color", "#ff0000");
        //    }
        //});
        ////学历15
        //$("#ddlt_xl").change(function () {
        //    if ($("#ddlt_xl option:selected").val() != "-1") {
        //        $("#lbl_xl").text("正确");
        //        $("#lbl_xl").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_xl").text("请选择");
        //        $("#lbl_xl").css("color", "#ff0000");
        //    }
        //});
        ////毕业时间16
        //$("#tbx_bysj").blur(function () {
        //    $("#lbl_bysj").text("正确");
        //    $("#lbl_bysj").css("color", "#00ff00");

        //});
        ////入职时间17
        //$("#tbx_rzsj").blur(function () {
        //    $("#lbl_rzsj").text("正确");
        //    $("#lbl_rzsj").css("color", "#00ff00");

        //});
        ////政治面貌18
        //$("#ddlt_zzmm").change(function () {
        //    if ($("#ddlt_zzmm option:selected").val() != "-1") {
        //        $("#lbl_zzmm").text("正确");
        //        $("#lbl_zzmm").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_zzmm").text("请选择");
        //        $("#lbl_zzmm").css("color", "#ff0000");
        //    }

        //});
        ////入党时间19
        //$("#tbx_rdsj").blur(function () {
        //    $("#lbl_rdsj").text("正确");
        //    $("#lbl_rdsj").css("color", "#00ff00");

        //});

        ////合同关系32
        //$("#ddlt_htgx").change(function () {
        //    if ($("#ddlt_htgx option:selected").val() != "-1") {
        //        $("#lbl_htgx").text("正确");
        //        $("#lbl_htgx").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_htgx").text("请选择");
        //        $("#lbl_htgx").css("color", "#ff0000");
        //    }
        //});

        ////合同类型33
        //$("#ddlt_htlx").change(function () {
        //    if ($("#ddlt_htlx option:selected").val() != "-1") {
        //        $("#lbl_htlx").text("正确");
        //        $("#lbl_htlx").css("color", "#00ff00");
        //    } else {
        //        $("#lbl_htlx").text("请选择");
        //        $("#lbl_htlx").css("color", "#ff0000");
        //    }
        //});

        ////备注34
        //$("#tbx_bz").blur(function () {
        //    $("#lbl_bz").text("正确");
        //    $("#lbl_bz").css("color", "#00ff00");
        //});             
    });


</script>
</html>
