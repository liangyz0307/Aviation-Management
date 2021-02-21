<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KS_KS.aspx.cs" Inherits="CUST.WKG.KS_KS" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
    <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }

        .b {
            margin: 0px;
            padding: 0px;
            overflow: auto;
        }

        .w {
            position: fixed;
            right: 10px;
            top: 10px;
            width: auto;
            height: auto;
            overflow: hidden;
            border: 2px groove #281;
            cursor: default;
            -moz-user-select: none;
            font-size: 20px;
        }

        .t {
            line-height: 20px;
            height: 25px;
            width: 200px;
            overflow: hidden;
            background-color: #27C;
            color: white;
            font-weight: bold;
            border-bottom: 1px outset blue;
            text-align: center;
        }

        .winBody {
            height: auto;
            width: auto;
            overflow-x: hidden;
            overflow-y: auto;
            border-top: 1px inset blue;
            padding: 10px;
            text-indent: 10px;
            background-color: white;
            color: red;
        }
    </style>
    <script type="text/javascript">
        var timestamp = Date.parse(new Date()) / 1000;  //获取当前时间戳，秒为单位
        var SS_Sum = '<%=JSSJ%>' - timestamp;
        var end_Interval_id;//setInterval的返回值，用来传递给 Window.clearInterval() 从而取消对 code 的周期性执行的值。
        var left_15_flag = 0;//0表示尚未提示，1表示已经提示
        function CalculateTime() {
            SS_Sum--;
            if (SS_Sum <= 0) {//考试最终结束时间到，结束考试，自动交卷
                clearInterval(end_Interval_id);
                document.getElementById("btn_tj").click();
                document.getElementById("time-left").innerHTML = "考试结束！";
                alert("考试结束，自动交卷！");
            }
            else if (SS_Sum <= 60 * 15 && left_15_flag == 0) {//剩余时间小于15分钟，给予提示
                alert("离考试结束已不足15分钟，请抓紧时间答题！");
                left_15_flag = 1;
            } else if (SS_Sum % 60 == 0) {//每60秒，自动保存一次
                document.getElementById("btn_bc").click();
            }
            var hh = parseInt(SS_Sum / 60 / 60, 10);//小时
            var mm = parseInt(SS_Sum / 60 % 60, 10);//分钟
            var ss = parseInt(SS_Sum % 60, 10);//秒数
            document.getElementById("time-left").innerHTML = hh + "小时" + mm + "分钟" + ss + "秒";
        }
        end_Interval_id = setInterval(CalculateTime, 1000);
        function maxWin() {
            window.top.moveTo(0, 0);
            window.top.resizeTo(screen.availWidth, screen.availHeight);
        }
    </script>
</head>
<body onresize='maxWin()'>
    <div class="w">
        <div class="t">距离考试结束还有：</div>
        <div class="winBody" id="time-left">0小时0分钟0秒</div>
    </div>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="panel-head" style="text-align: center;">
                <strong class="icon-reorder">
                    <asp:Label ID="lbl_mc" runat="server" Font-Size="30px"></asp:Label>
                </strong>
            </div>
            <table>
                <tbody>
                    <tr id="tr_xz" runat="server" style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 7%; text-align: right; vertical-align: top; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">单选题：</td>
                        <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc" id="tbx_mc">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="ph_xz" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="tr_dx" runat="server" style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 7%; text-align: right; vertical-align: top; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">多选题：</td>
                        <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc" id="Td1">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="ph_dx" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="tr_pd" runat="server" style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 7%; text-align: right; vertical-align: top; border: 1px solid #C0D9D9;" class="td_sjsc">判断题：</td>
                        <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="ph_pd" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="tr_tk" runat="server" style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 7%; text-align: right; vertical-align: top; border: 1px solid #C0D9D9;" class="td_sjsc">填空题：</td>
                        <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="ph_tk" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="row cl" style="text-align: center;">
                <div style="text-align: center;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div style="text-align: center;">
                                <strong class="icon-reorder">
                                    <asp:Label ID="lbl_bc" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </strong>
                            </div>
                            <br />
                            <br />
                            <asp:Button ID="btn_bc" runat="server" Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                Width="152px" OnClick="btn_bc_Click" Height="50px" Font-Size="Medium"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btn_tj" runat="server" Text="交卷" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                             Width="152px" OnClick="btn_tj_Click" Height="50px" Font-Size="Medium"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />  <br />  <br />  <br />
        </form>
    </article>
</body>
</html>
