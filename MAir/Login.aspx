<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MAir.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <title>吉林省民航机场集团公司航务管理部</title>
    <link href="Content/css/h-ui/css/H-ui.min.css" rel="stylesheet" />
    <link href="Content/css/h-ui.admin/css/H-ui.login.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/h-ui.admin/css/style.css" rel="stylesheet" type="text/css" />
   </head>
    <body>
        <input type="hidden" id="TenantId" name="TenantId" value="" />
        <div class="header">
        </div>
        <div class="loginWraper">
       <img  src="Content/css/h-ui.admin/images/tiank.jpg"  class="ima" alt="飞机"/>
            <div id="loginform" class="loginBox">
              
               <div class="div2" style="font-size:20px;text-align:center; border-bottom-color:azure; border-bottom-style:ridge; height: 29px;">
                <img src="Content/images/user.png" alt="Login" width="20" height="20"  style="text-align:center" />用户登录
              </div>
                <form id="form1" runat="server" class="form form-horizontal">
                  <div class="div3 ">
                       <br />
                        <div  style="height:30px;width:500px;text-align:center">
                      <span style="width:500px;height:30px; display:block;">
                          <asp:Label ID="Label1" runat="server" Text="账户" Width="60px"></asp:Label>
                          <asp:TextBox ID="tbx_zh" runat="server" MaxLength="9" style="width:200px;height:30px;border-style:hidden;"> </asp:TextBox>
                      </span>
                        </div>
                      <br />
                         <div  style="height:30px;width:500px;text-align:center">
                      <span style="width:500px;height:30px;display:block;">
                            <asp:Label ID="Label2" runat="server" Text="密码" Width="60px"></asp:Label>
                            <asp:TextBox ID="tbx_mm" runat="server" style="width:200px;height:30px;border-style:hidden;" TextMode="Password"> </asp:TextBox> 
                      </span>
                      </div>
                       <br />
                      <div class=" formControls" style="height:30px;width:500px;text-align:center">
                           <asp:Label ID="Label3" runat="server" Text="验证码" Width="60px" Height="30px"></asp:Label>
                           <asp:TextBox ID="tbx_yzm" runat="server" style="width:100px;height:30px;border-style:hidden;"> </asp:TextBox>
                            <img width="95" height="30" alt="看不清，换一张" title="看不清，换一张" src="../ValidateCode.aspx"style="cursor: pointer;" onclick="this.src=this.src+'?r='+Math.random()" />
                     </div>
                      <br />
                      <div  style="height:30px;width:500px;text-align:center">
                    <asp:Button ID="btn_login" runat="server" Text="登   录" Font-Size="Larger" Width="150px" Height="30px" BorderStyle="None" BackColor="#ff9900" OnClick="btn_login_Click" />
                          </div>
                       <br />
                 </div>
                </form>
            </div>
        </div>
        <div class="footer">
            Copyright&copy;吉林省民航机场集团公司
        </div>
        <script type="text/javascript" src="Content/js/jquery.min.js"></script>
        <script type="text/javascript" src="Content/js/jquery.min.js"></script>
    </body>

</html>