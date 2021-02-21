<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ALGL.aspx.cs" Inherits="CUST.WKG.ALGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
        .auto-style9 {
            width: 11%;
        }
        .auto-style11 {
            width: 12%;
        }
        .auto-style12 {
            width: 18%
        }
    </style>


    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
          <%--  <nav class="breadcrumb"> <span class="c-gray en">&gt;</span> 员工信息管理 <span class="c-gray en">&gt;</span> 员工信息
        </nav>--%>
    <div >
         <table><tr>
            
           <td align="left" class="auto-style9">
               案例名：
             <asp:TextBox ID="tbx_alm" runat="server" Width="57px"></asp:TextBox></td>

                <td align="left" class="col-5-1">
               案例类型：
             <asp:DropDownList ID="ddlt_allx1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlt_allx1_SelectedIndexChanged" Width="80px" class="select-box"></asp:DropDownList>
                    <asp:DropDownList ID="ddlt_allx2" runat="server" class="select-box" Width="89px" >
            </asp:DropDownList>
               </td>
             <td align="left" class="auto-style11">
                   案例来源：
             <asp:DropDownList ID="ddlt_ally" runat="server" class="select-box" Width="67px" >
            </asp:DropDownList></td>
             <td align="left" class="auto-style11">
                   案例等级：
             <asp:DropDownList ID="ddlt_aldj" runat="server" class="select-box" Width="65px" >
            </asp:DropDownList></td>
          <td  align="left" class="auto-style12">
               上传时间：
             <asp:TextBox ID="tbx_kssj" runat="server" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="65px"></asp:TextBox>- <asp:TextBox ID="tbx_jssj" runat="server" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="65px" Height="18px"></asp:TextBox></td>
              
           <td  style="width:12%"  align="left">
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" Width="55px" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7" Width="57px"/>
                  </td>
              </tr>
           
         </table> 
         
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    资料管理列表
                                </th>
                            </tr>
                            <tr class="text-c">
                               <%-- <th width="20">
                                  <asp:CheckBox ID="cbx_qx" runat="server" />
                                </th>--%>
                                <%--<th width=40"  style="text-align:center;vertical-align:middle;">
                                   选择
                                </th>--%>
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    案例名
                                </th>
                                    <th width="50"  style="text-align:center;vertical-align:middle;">
                                    案例大类
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    案例小类
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    案例等级
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    案例来源
                                </th>
                                  <th width="50"  style="text-align:center;vertical-align:middle;">
                                    案例发生时间
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    上传时间
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    上传用户
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    上传用户部门
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                
                                <th width="100">
                                    操作
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
                                      <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Underline="true" CommandName="down" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+ Eval("alm")+"&"+ Eval("sclj")+"&"+Eval("bmdm") %>' Text='<%# Eval("alm") %>'></asp:LinkButton>
                                </td>
                            <td>
                                <asp:Label ID="Label_allx1" runat="server" Text='<%#Eval("allx1mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label_allx2" runat="server" Text='<%#Eval("allx2mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("allymc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("aldjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("scsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("fssjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("scyh") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gw") %>'></asp:Label>
                            </td>
                        <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("sjssbm") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                             </td>
                                <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+ Eval("alm")+"&"+ Eval("sclj")+"&"+Eval("bmdm") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+ Eval("alm")+"&"+ Eval("sclj")+"&"+Eval("bmdm") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+ Eval("alm")+"&"+ Eval("sclj")+"&"+Eval("bmdm") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <%--<asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("albh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>--%>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+ Eval("alm")+"&"+ Eval("sclj")+"&"+Eval("bmdm") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该案例信息？')">删除</asp:LinkButton>

                           </td>
                            
            
                      
                            <%--  <td class="td-manage">
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("albh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("albh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该案例信息？')">删除</asp:LinkButton>


                              <%--  &nbsp;
                                <asp:LinkButton ID="lbtTjtz" CommandName="EditZT" CommandArgument='<%#Eval("id") %>'
                                    runat="server" OnClientClick="return confirm('您确定要提交该员工信息，提交之后将不可更改？')"><i class="Hui-iconfont">&#xe631;</i>提交</asp:LinkButton>--%>
                           
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
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
    <asp:HiddenField ID="HF_yc" runat="server"/>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
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
    </script>
    <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
</form>
</body>
</html>