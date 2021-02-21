 <%@ Page Title="" Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="GongGao.aspx.cs" Inherits="CUST.Web.MengHu.main.GongGao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server">
    <form runat="server">

    <div id="content">
	<table class="table">
		<tbody><tr>
			<td id="content-left"></td>
			<td id="content-right">
             <table id="porletsLayout" class="table">
               <tbody>
                   <tr>
                     <td id="col1">
			              <div class="portlet" id="pf316">
			              <div class="portletFrame">
			                  <div class="portletHeader clearFix">
			                      <div class="portletHeaderFrame clearFix">
			                          <div class="title">
			      	                    <a name="anchorf316"></a>
			      	                    <span>公告浏览</span>&nbsp;
			                          </div>								
			                      </div>
			                  </div>
			                  <div class="portletContent" >
                                 
                                      <span style="display:inline-block;float:right;padding-right:0px;">
                                     		 <asp:Label ID="lbl_sj" runat="server" ></asp:Label>
                                      </span>
                                      <span style="display:inline-block;float:left;">
                                            <asp:Label ID="lbl_gg" runat="server"  ></asp:Label>
                                       </span>
                                
                             </div>
                              
                        </div>
                     </div>
                   </td>
                </tr>
             </tbody>
            </table>
         </td>
        </tr>
     </tbody>
</table>
</div>
    </form>
</asp:Content>
