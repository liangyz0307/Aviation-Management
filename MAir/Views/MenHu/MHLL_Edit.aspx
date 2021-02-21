<%@ Page Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="MHLL_Edit.aspx.cs" Inherits="CUST.WKG.MHLL_Edit" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<asp:Content ID="KG_head" ContentPlaceHolderID="head" runat="server">

    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
      <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
    </style>
</asp:Content>
 <asp:Content ID="KG_content" ContentPlaceHolderID="kg_content" runat="server" >

    <article class="page-container">
	<form id="Form1" runat="server" class="form form-horizontal">
	 <div class="panel-head">
            <strong class="icon-reorder">员工履历编辑</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 单 位：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:TextBox ID="tbx_gzdw" runat="server" class="input-text" placeholder="工作单位" 
                 Width="446px" MaxLength="50">
                    </asp:TextBox>
                    <asp:Label ID="lbl_gzdw" runat="server" ></asp:Label>
                    </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 部 门：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzbm" runat="server" class="input-text" placeholder="工作部门" 
                 Width="446px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lbl_gzbm" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 岗 位：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzgw" runat="server" class="input-text" placeholder="工作岗位" 
                 Width="446px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lbl_gzgw" runat="server" ></asp:Label>
                </td>
                
            </tr>
       

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 地 点：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzdd" runat="server" class="input-text" placeholder="工作地点" 
                 Width="446px" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lbl_gzdd" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    起 止 日 期：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_qzrq" runat="server" class="input-text" placeholder="起止日期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_qzrq" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    截 止 日 期：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_jzrq" runat="server" class="input-text" placeholder="截止日期" 
                 Width="446px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_jzrq" runat="server" ></asp:Label>
                </td>
                
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    个 人 技 术 档 案：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar1" runat='server'>
    </Upload:ProgressBar>
                </td>
                
            </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    业 务 培 训 档 案：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile_px" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar2" runat='server'>
    </Upload:ProgressBar>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    安 全 教 育 档 案：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile_jy" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar3" runat='server'>
    </Upload:ProgressBar>
                </td>
                
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    备 注：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_bz" runat="server" class="input-text" placeholder="备注" 
                 Width="446px" MaxLength="200"></asp:TextBox>
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                </td>
                
            </tr>
        </table>

	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
             <asp:Button ID="Button1" runat="server" 
                Text="编辑" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px"  onclick="btn_Edit_Click"></asp:Button> 
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_save_Click"></asp:Button>  
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
        <br />
         <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    文件列表
                                </th>
                            </tr>
                            <tr class="text-c">
                               
                                 <th width="40"  style="text-align:left;vertical-align:middle;">
                                   个人技术档案
                                </th>
                                <th width="40"  style="text-align:left;vertical-align:middle;">
                                   业务培训档案
                                </th>
                                <th width="40"  style="text-align:left;vertical-align:middle;">
                                   安全教育档案
                                </th>
                                <th width="50"  style="text-align:left;vertical-align:middle;">
                                    上传时间
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c" >
                            
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                                <asp:LinkButton ID="lbtDown"  CommandName="down" CommandArgument='<%#Eval("grjsda") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName_js") %>' ></asp:LinkButton>
                            </td>
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                                 <asp:LinkButton ID="LinkButton1"  CommandName="down" CommandArgument='<%#Eval("ywpxda") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName_px") %>' ></asp:LinkButton>
                               <%-- <asp:Label ID="Label2"  runat="server" Text='<%#Eval("FileName_px") %>'></asp:Label>--%>
                            </td>
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                                 <asp:LinkButton ID="LinkButton2"  CommandName="down" CommandArgument='<%#Eval("aqjyda") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName_jy") %>' ></asp:LinkButton>
                               <%-- <asp:Label ID="Label3"  runat="server" Text='<%#Eval("FileName_jy") %>'></asp:Label>--%>
                            </td>
                             <td style="width:19%;text-align:left;vertical-align:middle;">
                                <asp:Label ID="Label44"  runat="server" Text='<%#Eval("FileTime") %>'></asp:Label>
                            </td>
                          <%--  <td style="width:40%" class="td-manage">
                                <asp:LinkButton ID="lbtDown"  CommandName="down" CommandArgument='<%#Eval("YuanshiFileName") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" >下载</asp:LinkButton>
                           
                           
                                <asp:LinkButton ID="lbtDelete" CommandName="delete" CommandArgument='<%#Eval("YuanshiFileName") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server"   OnClientClick="return confirm('您确定要删除该文件？')">删除</asp:LinkButton>
                            </td>--%>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/icheck/jquery.icheck.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/validate-methods.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/messages_zh.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->
    <script src="../css/js/jquery.js" type="text/javascript"></script>
     <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //工作单位
            $("#tbx_gzdw").click(function () {

                $("#lbl_zzdw").text("正确");
                $("#lbl_zzdw").css("color", "#00ff00");

            });
            //工作部门
            $("#tbx_gzbm").blur(function () {
                $("#lbl_gzbm").text("正确");
                $("#lbl_gzbm").css("color", "#00ff00");

            });
            //工作岗位
            $("#tbx_gzgw").blur(function () {
                $("#lbl_gzgw").text("正确");
                $("#lbl_gzgw").css("color", "#00ff00");

            });
            //工作地点
            $("#tbx_gzdd").blur(function () {
                $("#lbl_gzdd").text("正确");
                $("#lbl_gzdd").css("color", "#00ff00");

            });
            //起止日期
            $("#tbx_qzrq").blur(function () {
                $("#lbl_qzrq").text("正确");
                $("#lbl_qzrq").css("color", "#00ff00");

            });
            //截止日期
            $("#tbx_jzrq").blur(function () {
                $("#lbl_jzrq").text("正确");
                $("#lbl_jzrq").css("color", "#00ff00");

            });

            //备注
            $("#tbx_bz").blur(function () {
                $("#lbl_bz").text("正确");
                $("#lbl_bz").css("color", "#00ff00");

            });
          
        });
    </script> 
    <script type="text/javascript">
        $(function () {
            $('.skin-minimal input').iCheck({
                checkboxClass: 'icheckbox-blue',
                radioClass: 'iradio-blue',
                increaseArea: '20%'
            });

            $("#form-admin-add").validate({
                rules: {
                    adminName: {
                        required: true,
                        minlength: 4,
                        maxlength: 16
                    },
                    password: {
                        required: true,
                    },
                    password2: {
                        required: true,
                        equalTo: "#password"
                    },
                    sex: {
                        required: true,
                    },
                    phone: {
                        required: true,
                        isPhone: true,
                    },
                    email: {
                        required: true,
                        email: true,
                    },
                    adminRole: {
                        required: true,
                    },
                },
                onkeyup: false,
                focusCleanup: true,
                success: "valid",
                submitHandler: function (form) {
                    $(form).ajaxSubmit();
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.$('.btn-refresh').click();
                    parent.layer.close(index);
                }
            });
        });
</script>

</asp:Content>
