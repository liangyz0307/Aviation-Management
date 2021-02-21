<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZYBS_Add.aspx.cs" Inherits="CUST.WKG.ZYBS_Add" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            <table>        
              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报送员工：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                     <asp:Label  Width="200px" ID="lbl_bsyg" runat="server"></asp:Label>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"></td>
   <%--<tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送员工：</td>
                    <td colspan="2" style="width: 10% ;text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">  
                        <asp:Label ID="lbl_bsyg" runat="server"  Width="200px"></asp:Label>
                    </td>
                 </tr>--%>
     <td rowspan="6" style=" width:10%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">员 工 照 片：<span class="c-red"></span></td>
     <td rowspan="6" style=" width:10%; text-align: center; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
     <asp:Image ID="Image1"   runat="server" /> 
     <div id="preview" ></div>
     </td>
    <td rowspan="6" style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">&nbsp;</td>

            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
               <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报送岗位：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                     <asp:Label  Width="200px" ID="lbl_bsgw" runat="server"></asp:Label>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"></td>
             </tr>

                <%--<tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送岗位：</td>
                    <td colspan="2" style="width: 10% ; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">  
                        <asp:Label  Width="200px" ID="lbl_bsgw" runat="server"></asp:Label>
                    </td>
                </tr>--%>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">        
                <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报送类型：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:DropDownList ID="ddlt_bslx" runat="server" ></asp:DropDownList></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"></td>               
         </tr>
               <%-- <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送类型：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                          <asp:DropDownList ID="ddlt_bslx" runat="server" Width="200px"></asp:DropDownList>
                        <asp:Label ID="lbl_bslx" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                      <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报 送 时 间：<span class="c-red"></span></td> 
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:TextBox ID="tbx_bssj" runat="server" class="input-text" placeholder="报送时间"
                            Width="200px" MaxLength="50" onclick="lhgcalendar()"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"></td>
                 </tr>
                <%--<tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="input-text" placeholder="报送时间"
                            Width="200px" MaxLength="50" onclick="lhgcalendar()"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>
                </tr>--%>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
            报送模式：<span class="c-red"></span></td>
            <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
           <asp:TextBox ID="tbx_bsms" runat="server" class="input-text" 
                            Width="446px" Multiply="true" Height="50px" ></asp:TextBox>
                <asp:Label ID="lbl_bsms" runat="server"></asp:Label>
            </td>
            <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"></td>
         </tr>
                <%--<tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送模式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                           <asp:TextBox ID="tbx_bsms" runat="server" class="input-text" placeholder="解决方案"
                            Width="446px" Multiply="true" Height="50px" ></asp:TextBox>
                        <asp:Label ID="lbl_bsms" runat="server"></asp:Label>
                    </td>
                </tr>--%>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">   
            <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   解决方案：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate> 
                     <asp:TextBox ID="tbx_jjfa" Width="446px" Multiply="true" Height="30px" runat="server" class="input-text" ></asp:TextBox>  </ContentTemplate>
               </asp:UpdatePanel>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate>
                    <asp:Label ID="lbl_jjfa" runat="server"></asp:Label>
                       </ContentTemplate>
               </asp:UpdatePanel>
                      </td> 
            </tr>
                <%--<tr style="vertical-align: top; width: 100%; height: 55px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">解决方案：<span class="c-red">*</span></td>
                    <td colspan="2" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jjfa" runat="server" class="input-text" placeholder="解决方案"
                            Width="446px" Multiply="true" Height="50px" ></asp:TextBox>
                        <asp:Label ID="lbl_jjfa" runat="server"></asp:Label>
                    </td>
                </tr>--%>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
             <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   备注：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate> 
                     <asp:TextBox ID="tbx_bz" Width="446px" Multiply="true" Height="30px" runat="server" class="input-text" ></asp:TextBox>  </ContentTemplate>
               </asp:UpdatePanel>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                  <ContentTemplate>
                    <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                       </ContentTemplate>
               </asp:UpdatePanel>
                      </td>   
             <%--<tr style="vertical-align: top; width: 100%; height: 55px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" Width="446px" Multiply="true" Height="30px" runat="server" class="input-text" ></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>--%>
            <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   上 传 照 片：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                        <asp:FileUpload ID="ImageUpload"  runat="server" onchange="chgImg(this)"  />   
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_sc" runat="server" ></asp:Label></td>
            </tr>

             
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                        </tr>
                
                
                <%--<tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送模式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                           <asp:TextBox ID="tbx_bsms" runat="server" class="input-text" placeholder="解决方案"
                            Width="446px" Multiply="true" Height="50px" ></asp:TextBox>
                        <asp:Label ID="lbl_bsms" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 55px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">解决方案：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jjfa" runat="server" class="input-text" placeholder="解决方案"
                            Width="446px" Multiply="true" Height="50px" ></asp:TextBox>
                        <asp:Label ID="lbl_jjfa" runat="server"></asp:Label>
                    </td>
                </tr>--%>

               <%-- <tr style="vertical-align: top; width: 100%; height: 55px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" Width="446px" Multiply="true" Height="50px" runat="server" class="input-text" ></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     文 档 选 择：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar1" runat='server'>
                </Upload:ProgressBar>
                </td>
            </tr>
            </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="HF_lj" runat="server" />
            </div>
        </form>
    </article>
</body>
<script src="../css/js/jquery.js" type="text/javascript"></script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript"></script>
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
</html>
