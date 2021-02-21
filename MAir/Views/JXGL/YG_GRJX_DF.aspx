<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YG_GRJX_DF.aspx.cs" Inherits="MAir.Views.JXGL.YG_GRJX_DF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>员工个人绩效打分</title>
    <%--根据ygbh查询该员工名下的评测方案，给每个评测方案下的评测项打分--%>
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
    <form id="form1" runat="server">
        <div class="mt-20">
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <tr>
                    <td>员工编号：
                            <asp:Label ID="lbl_ygbh" runat="server" Text="员工编号"></asp:Label>
                    </td>
                    <td>姓名：
                            <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue" Font-Underline="true" Text="姓名"
                                NavigateUrl='<%#"GRJX_YGXX.aspx?bh=" + Eval("YGBH")+"&"+ "pcfabh="+Eval("PCFABH")+"&"+"bmdm="+bm+"&"+"gwdm="+gw%>'>
                            </asp:HyperLink>
                    </td>
                    <td>部门：
                            <asp:Label ID="lbl_bmdm" runat="server" Text="部门"></asp:Label>
                    </td>
                    <td>岗位：
                            <asp:Label ID="lbl_gwdm" runat="server" Text="岗位"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="mt-20">
            <strong class="icon-reorder">选择总方案：
                  <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_zfa_SelectedIndexChanged">
                  </asp:DropDownList>
            </strong>
        </div>
        <div id="div">
            <asp:DataList ID="dlt_pcfa" runat="server" DataKeyField="pcfabh">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <thead>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号(已打分)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称(已打分)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案权重(%)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">该方案得分</th>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" style="text-align: center; vertical-align: middle;"><%#(Container.ItemIndex + 1)%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_dfadf" runat="server" Text='<%#Eval("pcfazf") %>'></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <div class="mt-20">
                <strong class="icon-reorder">选择评测方案进行打分：
                  <asp:DropDownList ID="ddlt_pcfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_pcfa_SelectedIndexChanged">
                  </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label1" runat="server" Text="该评测方案权重："></asp:Label>
                    <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                    %
                </strong>
            </div>
            <asp:DataList ID="dlt_pcx" runat="server" DataKeyField="ygbh" OnCancelCommand="dlt_pcx_CancelCommand" OnEditCommand="dlt_pcx_EditCommand" OnUpdateCommand="dlt_pcx_UpdateCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <thead>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项打分(0~100之间)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">绩效指标描述</th>
                                <th width="10%">操作
                                </th>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxdf" runat="server" Text='<%#Eval("GRDF") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_jxzbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" ForeColor="Blue" Font-Underline="true" runat="server">编辑</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
                <EditItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_pcxdf" runat="server" Text='<%#Eval("GRDF") %>' CommandName="tbx" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                        onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}">
                                    </asp:TextBox>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_jxzbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:TextBox>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:LinkButton ID="lbt_update" CommandName="Update" ForeColor="Blue" Font-Underline="true" runat="server">保存</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_delete" CommandName="Cancel" runat="server" Text="取消" CssClass="command"></asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EditItemTemplate>
                <FooterTemplate>
                    <table></table>
                </FooterTemplate>
            </asp:DataList>
        </div>

        <div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="添加总方案" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="Button2" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div> 
    </form>
</body>
</html>
