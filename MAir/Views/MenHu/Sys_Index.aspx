<%@ Page Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="Sys_Index.aspx.cs" Inherits="CUST.WKG.Sys_Index" %>

<asp:Content ID="KG_head" ContentPlaceHolderID="head" runat="server">
    <%--门户主页面 --%>
<%--    <link rel="stylesheet" href="../../Content/css/jalendar.css" type="text/css" />--%>
    <link rel="stylesheet" href="../../Content/css//documentation.css" type="text/css" />
    <!--jQuery-->
<%--    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script><!--jQuery-->--%>
<%--    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>--%>
    <style type="text/css">
        .style1 {
            height: 30px;
        }
        .auto-style1 {
            width: 28%;
        }
        .auto-style2 {
            width: 31%;
        }
        .auto-style3 {
            width: 100%;
            height: 875px;
        }
        </style>
<%--    <script type="text/javascript">
        $(function () {
            $('#myId').jalendar();
            $('<audio id="chatAudio"><source src="notify.ogg" type="audio/ogg"> <source src="notify.mp3" type="audio/mpeg"> <source src="notify.wav" type="audio/wav"> </audio>').appendTo('table');//载入声音文件 
            if (document.getElementById("<%=hf_count.ClientID %>").value > 0) {
                $('#chatAudio')[0].play(); //播放声音 
              
            }
            
     });
    </script>--%>
<%--<script type="text/javascript">
$(function () {
    $('#myId').jalendar({
        customDay: '2017/12/01',  // Format: Year/Month/Day
        color: '#ed145a', // Unlimited Colors
        lang: 'EN' // Format: English — 'EN', Türkçe — 'TR'
    });
});
</script>--%>
    <link href="../../Content/Calendar/js/Dialog/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Content/Calendar/js/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="../../Content/Calendar/js/Dialog/js/jquery-ui-1.10.4.custom.js"></script>
    <script type="text/javascript" src="../../Content/Calendar/js/jquery.contextmenu.r2.packed.js"></script>

    
    <script type="text/javascript">
        $(function () {
            $("#dialog").dialog({
                autoOpen: false,// 初始化之后，是否立即显示对话框，默认为 true
                width: 450,
                modal: true,//是否模式对话框，默认为 false
                draggable: true,//是否允许拖动，默认为 true
                resizable: true,//是否可以调整对话框的大小，默认为 true
                title: "添加日程",
                position: "center",//用来设置对话框的位置，有三种设置方法 1.  一个字符串，允许的值为  'center', 'left', 'right', 'top', 'bottom'.  此属性的默认值即为 'center'，表示对话框居中。 2.  一个数组，包含两个以像素为单位的位置，例如， var dialogOpts = { position: [100, 100] }; 3. 一个字符串组成的数组，例如， ['right','top']，表示对话框将会位于窗口的右上角。var dialogOpts = {  position: ["left", "bottom"]    };

            });
            function json2str(o) {
                var arr = [];
                var fmt = function (s) {
                    if (typeof s == 'object' && s != null) return json2str(s);
                    return /^(string|number)$/.test(typeof s) ? "'" + s + "'" : s;
                }
                for (var i in o) arr.push("'" + i + "':" + fmt(o[i]));
                return '{' + arr.join(',') + '}';
            }
            $("input").click(function () {
                var strScheduleTitle = $("#<%=txtScheduleTitle.ClientID%>").val();
                var strScheduleDescription = $("#<%=txtScheduleDescription.ClientID%>").val();
                var strhdColor = $("#<%=hdColor.ClientID%>").val();
                var strlblSchedulePlanDate = $("#<%=lblSchedulePlanDate.ClientID%>").html();
                var strScheduleID = $("#<%=hdScheduleID.ClientID%>").val();    
                //var param = { "Title": +"'" + strScheduleTitle + "'", "Description": +"'" + strScheduleDescription + "'", "Color": +"'" + strhdColor + "'", "PlanDate": +"'" + strlblSchedulePlanDate + "'", "ID": +"'" + strScheduleID+"'" };
               // var param = {"Title": "title", "Description": "description", "Color": "color", "PlanDate": "date", "ID": "id"};
                var param = { "Title": strScheduleTitle, "Description": strScheduleDescription, "Color": strhdColor, "PlanDate": strlblSchedulePlanDate, "ID": strScheduleID }
                $.ajax({
                    type: "POST",
                    url: "Sys_Index.aspx/add",
                    data: json2str(param),
                    //data: "{strScheduleTitle:'" + strScheduleTitle + "',strScheduleDescription:'" + strScheduleDescription + "',strhdColor:'" + strhdColor + "',strlblSchedulePlanDate:'" + strlblSchedulePlanDate + "',strScheduleID:'" + strScheduleID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $("#dialog").dialog("close");
                        if (data.d == 1) {
                            alert("添加成功")
                        } else if (data.d == 2) {
                            alert("添加失败,请正确填写日程");
                        } else if (data.d == 3) {
                            alert("修改成功");
                        } else {
                            alert("修改失败，请正确填写日程");
                        }
                        window.location = window.location;
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });
            });
            // 打开日程添加窗口
            $("td[date]").each(function () {
                //为每个单元格绑定右键菜单
                $(this).contextMenu('myMenu1', {
                    //绑定右键菜单，通过ul,li的ID绑定
                    bindings:
                    {
                        'add': function (e) {
                            $("#<%=lblSchedulePlanDate.ClientID%>").text($("#" + e.id).attr("date"));
                            $("#<%=txtScheduleTitle.ClientID%>").val("");
                            $("#<%=txtScheduleDescription.ClientID%>").val("");
                            $("#btnSave").val("添加");
                            $("#dialog").dialog("open");
                        },
                        'edit': function (e) {
                            var strScheduleID = $("#" + e.id).attr("scheduleId");
                            $("#<%=lblSchedulePlanDate.ClientID%>").text($("#" + e.id).attr("date"));
                            if (strScheduleID == "NO") {
                                alert("亲，该日没有日程安排，无法编辑，谢谢！");
                                return;
                            } else {
                                $("#<%=hdScheduleID.ClientID%>").val(strScheduleID);
                            }
                            $("#btnSave").val("编辑");
                            
                            $.ajax({
                                type: "POST",//
                                url: "Sys_Index.aspx/EditSchedule",
                                data: "{strScheduleID:'" + strScheduleID + "'}",
                                contentType: "application/json",
                                dataType: "json",
                                success: function (data) {
                                    $("#<%=txtScheduleTitle.ClientID%>").val(data.d[1]);
                                    $("#<%=txtScheduleDescription.ClientID%>").val(data.d[2]);
                                    $("#<%=hdColor.ClientID%>").text($("#" + e.id).css("background-color"));
                                    $("#<%=hdColor.ClientID%>").val(data.d[4]);                                   
                                    $("#" + data.d[4]).text("√");
                                    $("#" + data.d[4]).siblings().text("");
                                    $("#<%=lblSchedulePlanDate.ClientID%>").attr("visible",true);
                                    $("#<%=lblSchedulePlanDate.ClientID%>").val(data.d[5]);

                                },
                                error: function (msg) {
                                    alert(msg.status);
                                }
                            });                           
                            $("#dialog").dialog("open");
                        },
                        'delete': function (e) {
                            var strScheduleID = $("#" + e.id).attr("scheduleId");

                            if (strScheduleID == "NO") {
                                alert("亲，该日没有日程安排，无法删除，谢谢！");
                                return;
                            }

                            $.ajax({
                                type: "POST",//
                                url: "Sys_Index.aspx/DeleteSchedule",
                                //url: "ScheduleManage.aspx/DeleteSchedule",
                                data: "{strScheduleID:'" + strScheduleID + "'}",
                                contentType: "application/json",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d == 1) {
                                        $("#dialog").dialog("close");
                                        alert("删除成功");

                                    } else {
                                        alert("删除失败");
                                    }
                                    window.location = window.location;
                                },
                                error: function (msg) {
                                    alert(msg.status);
                                }
                            });
                        }
                    }
                });

            });
            $("#btn_Cancel").click(function () {
                $("#dialog").dialog("close");
            });
            $("#tbColor tr td").each(function () {
                $(this).click(function () {
                    $(this).text("√");
                    $("#<%=hdColor.ClientID%>").val($(this).css("background-color"));
                    $(this).siblings().text("");
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="KG_content" ContentPlaceHolderID="kg_content" runat="server" >
    <form id="form1" runat="server" style="width: 100%; padding: 0px">
        <asp:HiddenField ID="hf_count" runat="server" />
        <div id="content" style="width: 100%; padding: 0px">
           
            <table style="width: 100%; padding: 0px; height: 873px; margin-right: 0px;">
                <tbody>
                    <tr>
                        <td id="content-right">
                            <table id="porletsLayout" class="auto-style3" style="padding: 0px;">
                                <tbody>
                                    <tr>
                                        <td style="padding: 0px;" id="col1" class="auto-style2">
                                            <div class="portlet" id="pf141" style="margin-top: 0px;">
                                                <div class="portletFrame">
                                                    <div class="portletHeader clearFix">
                                                        <div class="portletHeaderFrame clearFix">
                                                            <div class="title">
                                                                <a name="anchorf141"></a>
                                                                <span><a href="../../Views/MenHu/GRXX.aspx?ygbh=<%#Eval("ygbh") %>" style="color: #305098;">个人信息</a>&nbsp;</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="portletContent" id="ext-gen6" style="border: 1px solid #CEF7E7">
                                                        <table class="composer_header" style="width: 99%; padding: 0px; margin-right: 0px;">
                                                            <tbody>
                                                                <tr style="height: 71px;">
                                                                    <td style="width: 140px;">
                                                                        <div class="composer" style="font-size:16px">
                                                                            <span style="display: block; margin: 5px 0 5px 0; height: 20px">
                                                                                <asp:Label ID="lbl_xm" runat="server" Font-Size="13px" Text=""></asp:Label><asp:Label ID="Label4" Font-Size="13px" runat="server" Text="，您好！"></asp:Label>
                                                                            </span>
                                                                            <span style="display: block; margin: 5px 0 5px 0; height: 20px">
                                                                                <asp:Label ID="Label15" runat="server" Font-Size="13px" Text="岗位："></asp:Label>
                                                                                <asp:Label ID="lbl_gw" runat="server" Font-Size="13px" Text=""></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                    <td style="width: 180px;">
                                                                        <div class="composer">
                                                                            <span style="display: block; margin: 5px 0 5px 0;">
                                                                                <asp:Label ID="Label1" runat="server" Font-Size="13px" Text="编号："></asp:Label>
                                                                                <asp:Label ID="lbl_gh" runat="server" Font-Size="13px" Text=""></asp:Label>
                                                                            </span>
                                                                            <span style="display: block; margin: 5px 0 5px 0;">
                                                                                <asp:Label ID="Label13" runat="server" Font-Size="13px" Text="部门："></asp:Label>
                                                                                <asp:Label ID="lbl_bm" runat="server" Font-Size="13px" Text=""></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="portlet" id="pf142" style="margin-top: 0px;">
                                                <div class="portletFrame">
                                                    <div class="portletHeader clearFix">
                                                        <div class="portletHeaderFrame clearFix">
                                                            <div class="title">
                                                                <a name="anchorf141"></a>
                                                                <span>
                                                                    待办事项&nbsp;
                                                                </span>
                                                                <span>
                                                                    未完成&nbsp;
                                                                </span>
                                                                <span>
                                                                    <img width="15" height="15" src="../../Content/images/speakerAni.gif" alt="" id="img_lb" />
                                                                </span>
                                                                <span style="margin-left: 110px;">
                                                                    <asp:ImageButton ID="more_zz" runat="server" src="../../Content/images/more.gif" OnClick="more_zz_Click" />
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="portletContent" id="ext-gen7" style="border: 1px solid #CEF7E7">
                                                        <table class="composer_header" style="width: 99%; height: 120px; padding: 0px; margin-right: 0px;">
                                                            <tbody>
                                                                <tr style="height: 170px">
                                                                    <td style="padding: 2px 2px 0 6px;">
                                                                        <asp:Label ID="lbl_zztx" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dhsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_txsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_qxsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_ybsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_ht" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygxx" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygzz" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygll" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygjl" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygcf" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygpx" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_ygzc" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_dhsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_txsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_qxsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_tzsb" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_bjgl" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_bjck" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_bjrk" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_sbgz" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_sbwh" runat="server"></asp:Label>
                                                                        <asp:Label ID="lbl_dspts_jssb" runat="server"></asp:Label>                                                                        
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="portlet" id="pf143" style="margin-top: 0px;">
                                                <div class="portletFrame">
                                                    <div class="portletHeader clearFix">
                                                        <div class="portletHeaderFrame clearFix">
                                                            <div class="title">
                                                                <a name="anchorf141"></a>
                                                                <span><a href="PersonInfo.aspx" style="color: #305098;">通知公告</a>&nbsp;</span>
                                                                <span style="margin-left: 200px;">
                                                                    <asp:ImageButton ID="more_gg" runat="server" src="../../Content/images/more.gif" OnClick="more_gg_Click" style="height: 11px" />
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="portletContent" id="ext-gen9" style="border: 1px solid #CEF7E7">
                                                        <table class="composer_header" style="width: 98%; height: 120px; padding: 0px; margin-right: 0px;">
                                                            <tbody>
                                                                <tr style="height: 120px">
                                                                    <td style="padding: 2px 2px 0 6px;">
                                                                        <span style="padding-left: 0px;">
                                                                            <asp:Label ID="lbl_gg" runat="server"></asp:Label>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- 日期控件--%>
                                            <div class="portlet">
                                                <div class="portletFrame">
                                                    <div class="portletHeader clearFix">
                                                        <div class="portletHeaderFrame clearFix">
                                                            <div class="title">
                                                                <a name="anchorf764"></a>
                                                                <span>备忘录日期</span>&nbsp;
                                      <br />
                                                                 <br />
<%--                                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" CssClass="auto-style1" Font-Size="X-Large" Height="216px" Width="340px"></asp:Calendar>--%>

    <div style="display: none" id="dialog">
        <table class="insert-tab" width="100%">
            <tbody>
                <tr>
                    <th width="120"><i class="require-red">*</i>日程标题：</th>
                    <td>
                        <asp:TextBox ID="txtScheduleTitle" CssClass="common-text required" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>日程描述：</th>
                    <td>
                        <asp:TextBox ID="txtScheduleDescription" TextMode="MultiLine" CssClass="common-textarea" cols="30" Style="width: 98%;" Rows="5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>日程创建时间：</th>
                    <td>
                        <asp:Literal  ID="ltlScheduleCreateDate" runat="server" /></td>
                </tr>
                <tr>
                    <th><i class="require-red">*</i>日程颜色标识：</th>
                    <td>
                        <table id="tbColor" width="100%" border="1" style="height: 30px;">
                            <tr align="center">
                                <td id="red" style="background-color: red" >√</td>
                                <td id="yellow" style="background-color: yellow"></td>
                                <td id="green" style="background-color: green"></td>
                                <td id="blue" style="background-color: blue"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>计划时间：</th>
                    <td>
                        <asp:Label  ID="lblSchedulePlanDate" runat="server"  Visible="true"/>
                    </td>
                </tr>
                <tr align="center">
                    <th></th>
                    <td><div id="Save_Cancel">
                        <input type="button" id="btnSave" class="btn btn-primary btn6 mr10" name="name" value="添加" runat="server" />
                        </div>

                    </td>
                </tr>

            </tbody>
        </table>
        <asp:HiddenField runat="server" ID="hdColor" Value="red" />
        <asp:HiddenField runat="server" ID="hdScheduleID" Value="NO" />



    </div>
    <div class="contextMenu" id="myMenu1" style="display:none">
        <ul>
            <li id="add">添加</li>
            <li id="edit">编辑</li>
            <li id="delete">删除</li>
        </ul>
    </div>
                                                
                                                            </div>
<asp:Calendar ID="CalendarSchedule" runat="server"
        BorderColor="#FFCC66" NextPrevStyle-Height="10px" Height="233px" Width="350px" BackColor="#FFFFCC" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="Large" ForeColor="#663399" OnDayRender="CalendarSchedule_DayRender" ShowGridLines="True" OnSelectionChanged="CalendarSchedule_SelectionChanged" OnVisibleMonthChanged="CalendarSchedule_VisibleMonthChanged">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Height="10px" Font-Size="9pt" ></NextPrevStyle>
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle Height="30px" Font-Bold="True" Font-Size="9pt" BackColor="White" />
        <TodayDayStyle BackColor="Green" ForeColor="White" />
    </asp:Calendar>
                                                        </div>
                                                    </div>
                                                </div>
<%--                                                <div>
                                                    <div id="myId" class="jalendar" >
                                                    </div>--%>
                                                </div>
                                            </td>
                                            

                                        <td style="padding: 0px;" id="col2" class="auto-style1">
                                            <div class="portletFrame">
                                                <div class="portletHeader clearFix">
                                                    <div class="portletHeaderFrame clearFix">
                                                        <div class="title">
                                                            <a name="anchorf764"></a>
                                                            <span>快捷入口</span>&nbsp;
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="portletContent" style="border: 1px solid #CEF7E7; margin-bottom: 5px; height: 75px;">
                                                    <table border="0" style="width: 600px; border: 1px; padding: 0px; margin-top: 8px;font-size:16px">
                                                        <asp:Label ID="lbl_rk" runat="server"></asp:Label>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="portletFrame">
                                                <div class="portletHeader clearFix">
                                                    <div class="portletHeaderFrame clearFix">
                                                        <div class="title">
                                                            <a name="anchorf764"></a>
                                                            <span>空管部门入口</span>&nbsp;
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="portletContent" style="border: 1px solid #CEF7E7">
                                                    <table border="0" style="margin-top: 15px; margin-bottom: 15px; margin-left: 5px; width:600px; height: 600px; border: 1px; padding: 0px;font-size:16px">
                                                        <tbody>

                                                            <tr>

                                                                <td style="text-align: center">
                                                                    <a href="../YuanGong/YGIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/yuangong1.jpg" alt="" /><br />
                                                                        员工管理系统</a>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <a href="../JXGL/JXIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/jixiao.jpg" alt="" /><br />
                                                                        绩效管理系统</a>
                                                                </td>
                                                                                                                                <td style="text-align: center">
                                                                    <a href="../BaoSong/BSIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/hangwu.png" alt="" /><br />
                                                                        航务综合信息系统</a>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td style="text-align: center">
                                                                    <a href="../SheBei/SBIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/shebei.jpg" alt="" /><br />
                                                                        设备管理系统</a>
                                                                </td>
                                                                                                                                <td  style="text-align: center">
                                                                <a href="../AnQuan/AQIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/aqxxgl.jpg" alt="" /><br />
                                                                        安全信息管理系统</a>
                                                                </td>
                                                                <td style="text-align: center">
                                                                   <%-- <a href="../HouTai/Test.aspx">--%>
                                                                    <a href="../HouTai/HTIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/houtai2.jpg" alt="" /><br />
                                                                        后台管理系统</a>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <a href="../ZiLiao/ZLIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/ziliao.png" alt="" /><br />
                                                                        资料库系统</a>
                                                                </td>

                                                                 <td  style="text-align: center">
                                                                     <a href="../YingJi/YJIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/yjgl.jpg" alt="" /><br />
                                                                        应急管理</a>
                                                                     
                                                                </td>
                                                                                                                                <td style="text-align: center">
                                                                   <a href="../ZXPX/PXIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/zxpx.jpg" alt="" /><br />
                                                                        在线考试系统</a>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                 <td  style="text-align: center">
                                                                     <a href="../SKJS/SKJSIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/skjs.jpg" alt="" /><br />
                                                                        五库建设</a>
                                                                     
                                                                </td>
                                                                <td  style="text-align: center">
                                                                     <a href="../DQZC/DQZC_DYIndex.aspx">
                                                                        <img width="100" height="100" src ="../../Content/images/dqzc.jpg" alt="" /><br />
                                                                        党群之窗
                                                                     </a>
                                                                </td>
                                                                                                                                <td  style="text-align: center">
                                                                      <a href="../AQJG/AQJGIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/aqjg.jpg" alt="" /><br />
                                                                        安全监管
                                                                     </a>
                                                                </td>
                                                            </tr>
                                                             <tr>
 
                                                                 <td  style="text-align: center">
                                                                      <a href="../ZXXX/XXIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/gjjs.jpg" alt="" /><br />
                                                                        在线学习
                                                                     </a>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <a href="http://192.168.223.101:8087/">
                                                                 <img width="100" height="100" src="../../Content/images/shipin.png" alt="" /><br />
                                                                 视频会议系统</a>
                                                                </td>
                                                                                                                                 <td style="text-align: center">
                                                                    <a href="../JianSuo/JSIndex.aspx">
                                                                        <img width="100" height="100" src="../../Content/images/jiansuo.png" alt="" /><br />
                                                                        检索管理系统</a>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                               <%-- <div class="portlet">
                                                    <div class="portletFrame">
                                                        <div class="portletHeader clearFix">
                                                            <div class="portletHeaderFrame clearFix">
                                                                <div class="title">
                                                                    <a name="anchorf764"></a>
                                                                    <span>友情链接</span>&nbsp;
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="portletContent" style="border: 1px solid #CEF7E7">
                                                            <div style="text-align: left; height: 50px;">
                                                                <span style="display: inline-block; width: 240px; text-align: right; line-height: 50px;">选择站点：</span>
                                                                <span style="display: inline-block">
                                                                    <select onchange="javascript:window.open(this.options[this.selectedIndex].value)" name="select" style="width: 200px; height: 25px">
                                                                        <option value="http://www.ccairport.cn/" selected="selected">长春龙嘉机场 &nbsp;</option>
                                                                        <option value="http://www.bcia.com.cn/">北京首都机场</option>
                                                                    </select>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
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

<%--<asp:Content ID="Content2" ContentPlaceHolderID="" runat="server">--%>


<%--</asp:Content>--%>
