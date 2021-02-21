<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YG_GJJS.aspx.cs" Inherits="CUST.WKG.YG_GJJS" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
        <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
 
</head>
<body>
     <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
        <table><tr>
           <td style="width:15%; " align="right">
             员工编号：
             <asp:TextBox ID="tbx_bh" runat="server" style="width:80px; height:24px"></asp:TextBox></td>
               <td style="width:17%; " align="right">
                 
            员工姓名：
             <asp:TextBox ID="tbx_ygxm" runat="server" style="width:80px;height:24px;"></asp:TextBox></td>
           <td style="width:12%; " align="right">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      部门：
              <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged" >
            </asp:DropDownList>
                  </ContentTemplate>
               </asp:UpdatePanel>    
               </td>
           <td style="width:12%; " align="right">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
          
                      岗位：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 80px"  >
            </asp:DropDownList>
                    </ContentTemplate>
               </asp:UpdatePanel>
               </td>
             <td style="width:12%; " align="right">
             
                     状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"  >
            </asp:DropDownList>
                       
               </td>
            <td  align="center">
            <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
           
             <asp:Button ID="btn_tj" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
                 

            </td></tr>
            <tr>
                
                <td style="width:18%; " align="right">           
                     政治面貌：
                    <asp:DropDownList ID="ddlt_zzmm" runat="server" class="select-box" Style="width: 100px"  >
                    </asp:DropDownList>                      
               </td>
               <td style="width:10%; " align="right">           
                     合同类型：
                    <asp:DropDownList ID="ddlt_htlx" runat="server" class="select-box" Style="width: 80px"  >
                    </asp:DropDownList>                      
               </td>
               <td style="width:20%; " align="right">  
                     出生年份：
                    <asp:TextBox ID="tbx_csnf" runat="server" class="input-text" placeholder="" onclick="lhgcalendar({format:'yyyy'})" Width="60px">
                    </asp:TextBox>
                </td>
                <td style="width:15%; " align="right">           
                     性别：
                    <asp:DropDownList ID="ddlt_xb" runat="server" class="select-box" Style="width: 80px" >
                    </asp:DropDownList>                      
               </td>
               <td style="width:15%; " align="right">           
                     民族：
                    <asp:DropDownList ID="ddlt_mz" runat="server" class="select-box" Style="width: 80px" >
                    </asp:DropDownList>                      
               </td>
               <td  align="center">      
                <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
               </td>
            </tr>

        </table> 
      
        <div class="mt-20">
<!--GridView中必须写的几个事件：onrowediting、onrowupdating、onrowcancelingedit、onrowdeleting--->
   <div class="col-md-6">
            <asp:GridView ID="gvTest" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="true" OnRowDataBound="gvTest_RowDataBound">
            </asp:GridView>
    </div>
        <br />
        </div>
    </div>
 <asp:HiddenField ID="HF_yc" runat="server"/>
  
  <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
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

  

    </form>
</body>
</html>
