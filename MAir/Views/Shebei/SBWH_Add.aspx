<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBWH_Add.aspx.cs" Inherits="CUST.WKG.SheBei.main.SBWH_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
           
        }
         #login  
     {  
        display:none; 
        border:1em solid #e4e5e6;  
        height:202px;  
        width:326px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:5%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:65%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }   
      jsc
            {
                background:#F6FAFD;
            }  
    #over  
    {  
        width: 100%;  
        height: 100%;  
        opacity:0.5;/*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/  
        filter:alpha(opacity=80);  
        display: none;  
        position:absolute;  
        top:0;  
        left:0;  
        z-index:1;  
        background: silver;  
    }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table>
    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">设备编号：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sbbh" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                            <%--   填写内容层  --%>
                        <div id="login">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 设备类型： 
                                  <asp:DropDownList ID="ddlt_sblx" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_sblx_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 设备编号： 
                                  <asp:DropDownList ID="ddlt_sbbh" runat="server" class="select-box"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                              </tr>
                           </table>
                            <br />
                            <div style="text-align: center">
                                <asp:Button ID="btn_bc" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
                    </td>
                </tr>
                   <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">设备状态详细信息： 
                        <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                      <asp:TextBox ID="tbx_sbztxxxx" MaxLength="14" runat="server" Width="60%" Height="25px" placeholder="设备状态详细信息"></asp:TextBox>
                         <asp:Label ID="lbl_sbztxxxx" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护状态： 
                        <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_whzt" runat="server"   Height="25px" ></asp:DropDownList>
                         <asp:Label ID="lbl_whzt" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护时间： 
                        <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                         <asp:TextBox ID="tbx_whsj" runat="server" Height="25px" placeholder="维护时间"  class="Wdate"   Width="60%"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                          <asp:Label ID="lbl_whsj" runat="server"></asp:Label>
                    </td>
                </tr>
             
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人部门： 
                        <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate> 
                      <asp:DropDownList ID="ddlt_whrbm" runat="server"   Height="25px" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                      <asp:Label ID="lbl_whrbm" runat="server"></asp:Label>
                  </ContentTemplate>
               </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人岗位： 
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate> 
                      <asp:DropDownList ID="ddlt_whrgw" runat="server" Height="25px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_whrgw_SelectedIndexChanged" ></asp:DropDownList>
                         <asp:Label ID="lbl_whrgw" runat="server"></asp:Label>
                  </ContentTemplate>
               </asp:UpdatePanel>
                    </td>
                </tr>

                   <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人： 
                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate> 
                      <asp:DropDownList ID="ddlt_whr" runat="server" Height="25px" ></asp:DropDownList>
                          <asp:Label ID="lbl_whr" runat="server"></asp:Label>
                  </ContentTemplate>
               </asp:UpdatePanel>
                    
                    </td>
                </tr>

                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护记录： 
                        <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_whjl" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none;"  placeholder="维护记录"></asp:TextBox>
                         <asp:Label ID="lbl_whjl" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">场地环境和电磁环境巡视记录： 
                        <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_xsjl" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none;"  placeholder="场地环境和电磁环境巡视记录"></asp:TextBox>
                         <asp:Label ID="lbl_xsjl" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">备注： 
                        <asp:Label ID="Label20" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_bz" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none" placeholder="备注"></asp:TextBox>
                         <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护文件上传： 
                        <asp:Label ID="Label22" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">


                        <Upload:InputFile ID="Upload" runat="server" Height="26px"  placeholder="维护文件上传" />
                        <asp:Label ID="lbl_path" runat="server"></asp:Label>
                    </td>
                </tr>

                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                设备种类： <asp:Label ID="lbl1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
                
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_sbzl" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_sbzl" runat="server"></asp:Label>
            </td>
                          </tr>
                <tr>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                数据所属部门： <asp:Label ID="lbl2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_sjszbm" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
            </td>
        </tr>
                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                初审人： <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_csr" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_csr" runat="server"></asp:Label>
            </td>
                           </tr>
                <tr>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                终审人： <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_zsr" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
            </td>
        </tr>
            </table>
            <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="Button2" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_back_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <br />

            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    文件列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    文件名
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    上传时间
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                   操作
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                             <td>
                                <asp:Label ID="Label44"  runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label26"  runat="server" Text='<%#Eval("scsj") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtDown" CommandName="down" CommandArgument='<%#Eval("path") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" >下载</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <script src="../../js/jquery-1.8.3.min.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {

                    //设备类型
                    $("#ddlt_sblx").change(function () {
                        if ($("#ddlt_sblx option:selected").val() != "-1") {
                            $("#lbl_sblx").text("正确");
                            $("#lbl_sblx").css("color", "#00ff00");
                        } else {
                            $("#lbl_sblx").text("请选择");
                            $("#lbl_sblx").css("color", "#ff0000");
                        }
                    });
                    //维护状态
                    $("#ddlt_whzt").change(function () {
                        if ($("#ddlt_whzt option:selected").val() != "-1") {
                            $("#lbl_whzt").text("正确");
                            $("#lbl_whzt").css("color", "#00ff00");
                        } else {
                            $("#lbl_whzt").text("请选择");
                            $("#lbl_whzt").css("color", "#ff0000");
                        }
                    });
                    //维护人
                    //$("#ddlt_whr").change(function () {
                    //    if ($("#ddlt_whr option:selected").val() != "-1") {
                    //        $("#lbl_whr").text("正确");
                    //        $("#lbl_whr").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whr").text("请选择");
                    //        $("#lbl_whr").css("color", "#ff0000");
                    //    }
                    //});
                    //维护人部门
                    //$("#ddlt_whrbm").change(function () {
                    //    if ($("#ddlt_whrbm option:selected").val() != "-1") {
                    //        $("#lbl_whrbm").text("正确");
                    //        $("#lbl_whrbm").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrbm").text("请选择");
                    //        $("#lbl_whrbm").css("color", "#ff0000");
                    //    }
                    //});
                 //   维护人岗位
                    //$("#ddlt_whrgw").change(function () {
                    //    if ($("#ddlt_whrgw option:selected").val() != "-1") {
                    //        $("#lbl_whrgw").text("正确");
                    //        $("#lbl_whrgw").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrgw").text("请选择");
                    //        $("#lbl_whrgw").css("color", "#ff0000");
                    //    }
                    //});
                    //设备状态详细信息
                    $("#tbx_sbztxxxx").blur(function () {
                        if ($("#tbx_sbztxxxx").val().trim() != "") {
                            $("#lbl_sbztxxxx").text("正确");
                            $("#lbl_sbztxxxx").css("color", "#00ff00");

                        } else {
                            $("#lbl_sbztxxxx").text("错误");
                            $("#lbl_sbztxxxx").css("color", "#ff0000");
                        }
                    });
                    //场地环境和电磁环境巡视记录
                    $("#tbx_xsjl").blur(function () {
                        if ($("#tbx_xsjl").val().trim() != "") {
                            $("#lbl_xsjl").text("正确");
                            $("#lbl_xsjl").css("color", "#00ff00");

                        } else {
                            $("#lbl_xsjl").text("错误");
                            $("#lbl_xsjl").css("color", "#ff0000");
                        }
                    });

                    //维护时间
                    //$("#tbx_whsj").blur(function () {
                    //    if ($("#tbx_whsj").val().trim() != "") {
                    //        $("#lbl_whsj").text("正确");
                    //        $("#lbl_whsj").css("color", "#00ff00");
                    //    }
                    //    else {
                    //        $("#lbl_whsj").text("错误");
                    //        $("#lbl_whsj").css("color", "#ff0000");
                    //    }

                    //});

                    //维护记录
                    $("#tbx_whjl").blur(function () {
                        if ($("#tbx_whjl").val().trim() != "") {
                            $("#lbl_whjl").text("正确");
                            $("#lbl_whjl").css("color", "#00ff00");
                        }
                        else {
                            $("#lbl_whjl").text("错误");
                            $("#lbl_whjl").css("color", "#ff0000");
                        }
                    });
                 });

            </script>
                 <script type="text/javascript">  
    var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show()  
    {  
        login.style.display = "block";  
        over.style.display = "block";
    }
    $("#btn_bc").click(function ()
    {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    }  
</script> 
        </form>
        </article>
</body>
</html>
