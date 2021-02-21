<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true"  CodeBehind="DYGL_Detail.aspx.cs" Inherits="CUST.WKG.DYGL_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>党员管理详情</title>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
     <table>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 员工编号：
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                    </td>
 
                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 姓名：
  <asp:Label ID="lbl_xm" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">身份证号：
                    <asp:Label ID="lbl_sfzh" runat="server" ></asp:Label>
                    </td>
                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 性别：
                    <asp:Label ID="lbl_xbdm" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   出生日期：
                    <asp:Label ID="lbl_csrq" runat="server" ></asp:Label></td>
          

        
                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    学历：
                  
                    <asp:Label ID="lbl_xldm" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    联系电话：
                    <asp:Label ID="lbl_lxdh" runat="server" ></asp:Label>
                    </td>

                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    党组织名称：
                    <asp:Label ID="lbl_dzzmc" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    基层党支部名称：
                    <asp:Label ID="lbl_jcdzbmc" runat="server" ></asp:Label>
                    </td>

                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    党小组名称：
                    <asp:Label ID="lbl_dxzmc" runat="server" ></asp:Label>
                    </td>
            </tr>
       

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    党内职务：
                    <asp:Label ID="lbl_dnzw" runat="server" ></asp:Label>
                    </td>
          
     
                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    用工形式：
                    <asp:Label ID="lbl_ygxs" runat="server" ></asp:Label>
                    </td>
            </tr>
        

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   党员类型：
                    <asp:Label ID="lbl_dylx" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   递交入党申请书时间：
                    <asp:Label ID="lbl_djrdsqssj" runat="server" ></asp:Label></td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   列为入党积极分子时间：
                    <asp:Label ID="lbl_lwrdjjfzsj" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第一培养人：
                    <asp:Label ID="lbl_pyr1" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第二培养人：
                    <asp:Label ID="lbl_pyr2" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   积极分子培训班毕业时间：
                    <asp:Label ID="lbl_jjfzpxbbysj" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   确定为发展对象时间：
                    <asp:Label ID="lbl_qdwfzdxsj" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第一介绍人：
                    <asp:Label ID="lbl_jsr1" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第二介绍人：
                    <asp:Label ID="lbl_jsr2" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   转正情况：
                    <asp:Label ID="lbl_zzqk" runat="server" ></asp:Label></td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   发展为预备党员时间：
                    <asp:Label ID="lbl_jrdzzsj" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   转为正式党员时间：
                    <asp:Label ID="lbl_zwzsdyrq" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   党费金额：
                    <asp:Label ID="lbl_dfje" runat="server" ></asp:Label></td>
            <td style=" width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   党费交至日期：
                    <asp:Label ID="lbl_dfjzrq" runat="server" ></asp:Label></td>
            </tr>


         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   备注：
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                    </td>
             <td style="width:45%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">
                 </td>
           </tr>

       
<%--                <td style="width:20%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

 class="td_sjsc"> 状态：<asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                    </td>--%>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <%--<td style="width:30%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   驳回原因：</td>--%>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                  
                    <asp:Label ID="lbl_bhyy" runat="server" ></asp:Label>
                    </td>
            </tr>
    </table>
     <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>      
                <td style="text-align:center"> &nbsp;&nbsp;
                     <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius"  BackColor="#990000" ForeColor="White"  Width="199px" OnClick="btn_fh_Click"  >
                     </asp:Button>
                </td>
            </tr>
        </table>
   </div>
        </form>
</asp:Content>
