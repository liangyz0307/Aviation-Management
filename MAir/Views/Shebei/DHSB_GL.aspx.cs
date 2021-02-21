using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using Sys;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace CUST.WKG
{
    public partial class DHSB_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private DHSB dhsb;
        private Struct_DHSB struct_dhsb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dhsb = new DHSB(_usState);

            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_SB_DH;
            psize = _usState.C_SB_TX;
            if (!IsPostBack)
            {
                bind_drop();
                bind_select();
                show();
                tbx_jfdqrq.Attributes.Add("readonly", "readonly");
            }
        }
        //判断用户有没有添加权限
        public void show()
        {
            //添加的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID,"140102") == true)
            {
                flag_add = true;
            }
            if (flag_add)
            {
                btn_add.Visible = true;
            }

        }
        private  void bind_drop()
        {

            //设备类型
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX("02").Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            //所属机场
            ddlt_yssjc.DataTextField = "mc";
            ddlt_yssjc.DataValueField = "bm";
            ddlt_yssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_yssjc.DataBind();
            ddlt_yssjc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 台站名称
            ddlt_tzmczl_tzmc.DataTextField = "mc";
            ddlt_tzmczl_tzmc.DataValueField = "bm";
            ddlt_tzmczl_tzmc.DataSource = SysData.ZXDM().Copy();
            ddlt_tzmczl_tzmc.DataBind();
            ddlt_tzmczl_tzmc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 绑定设备位置
            ddlt_tzmczl_wz.DataSource = SysData.SBWZ().Copy();
            ddlt_tzmczl_wz.DataTextField = "mc";
            ddlt_tzmczl_wz.DataValueField = "bm";
            ddlt_tzmczl_wz.DataBind();
            ddlt_tzmczl_wz.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 设备类型
            ddlt_tzmczl_sblx.DataTextField = "mc";
            ddlt_tzmczl_sblx.DataValueField = "bm";
            ddlt_tzmczl_sblx.DataSource = SysData.SBLX("02").Copy();
            ddlt_tzmczl_sblx.DataBind();
            ddlt_tzmczl_sblx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_select()
        {
            int jfdqrqbs = 0;
            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            if (tbx_jfdqrq.Text == "")
            {
                jfdqrqbs = 1;
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "" + "</span>";
            }
            if (jfdqrqbs==0 && !Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
            {
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
            }
            struct_dhsb.p_sbxh= tbx_sbxh.Text.ToString();
            struct_dhsb.p_sblx= ddlt_sblx.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_tzmc = ddlt_tzmczl_tzmc.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_wz = ddlt_tzmczl_wz.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_sblx = ddlt_tzmczl_sblx.SelectedValue.ToString();
            struct_dhsb.p_jfdqrq = tbx_jfdqrq.Text.ToString();
            struct_dhsb.p_yssjc = ddlt_yssjc.SelectedValue.ToString();
            struct_dhsb.p_userid = _usState.userID;
            int count = dhsb.Select_DHSB_Count(struct_dhsb); 
            pg_fy.TotalRecord = count;
            struct_dhsb.p_currentpage=pg_fy.CurrentPage;
            struct_dhsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt=dhsb.Select_DHSB(struct_dhsb).Tables[0];

            dt.Columns.Add("yssjc_mc");
            dt.Columns.Add("sstz_mc");
            dt.Columns.Add("plmc");
            dt.Columns.Add("jfdqrqz");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sblxmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["yssjc_mc"] = SysData.ZXDMByKey(dr["yssjc"].ToString()).mc;
                dr["sstz_mc"] =Convert.ToString ( SysData.ZXDMByKey(dr["TZMCZL_TZMC"].ToString()).mc+" " + SysData.SBWZByKey(dr["TZMCZL_WZ"].ToString()).mc + " "+SysData.SBLXByKey(dr["TZMCZL_SBLX"].ToString()).mc);
                dr["plmc"] = Convert.ToString(dr["pl"].ToString() + SysData.PLDWByKey(dr["pldw"].ToString()).mc );
                dr["jfdqrqz"]= DateTime.Parse(dr["jfdqrq"].ToString()).ToString("yyyy-MM-dd") ;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
            }
            ////绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("../SheBei/DHSB_Add.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string zt = content[1];         //状态
            string bmdm = content[2];       //部门代码
            string lrr = content[3];        //录入人
            string csr = content[4];        //初审人
            string zsr = content[5];        //终审人
            string sjc = content[6];        //时间戳
            string sjbs = content[7];       //数据标识
            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140103"))
                    {
                        Server.Transfer("DHSB_Edit.aspx?id=" + e.CommandArgument.ToString() + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
                else if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("DHSB_Edit.aspx?id=" + e.CommandArgument.ToString() + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
                Server.Transfer("DHSB_Edit.aspx?id=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Delete")
            {
                struct_dhsb = new Struct_DHSB();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->导航设备管理->删除 设备编号：" + struct_dhsb.p_id;
                        string p_id = id.ToString();
                        dhsb.Delete_DHSB(p_id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140104"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->导航设备管理->删除 设备编号：" + struct_dhsb.p_sbbh;
                        string p_id = id.ToString();
                        dhsb.Delete_DHSB(p_id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_dhsb = new Struct_DHSB();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_dhsb.p_id = id;
                        struct_dhsb.p_zt = "1";
                        struct_dhsb.p_bhyy = HF_yc.Value;
                        struct_dhsb.p_czfs = "05";
                        struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（提交）    设备编号：" + struct_dhsb.p_id;
                        dhsb.Update_DHSBZT(struct_dhsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        struct_dhsb.p_id = id;
                        struct_dhsb.p_zt = "2";
                        struct_dhsb.p_bhyy = HF_yc.Value;
                        struct_dhsb.p_czfs = "06";
                        struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（审核）    设备编号：" + struct_dhsb.p_id;
                        dhsb.Update_DHSB(struct_dhsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        struct_dhsb.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_dhsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_dhsb.p_bhyy = HF_yc.Value;
                            struct_dhsb.p_czfs = "06";
                            struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（审核）    设备编号：" + struct_dhsb.p_id;
                            dhsb.Update_DHSB_SJBS_ZT(struct_dhsb);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_dhsb.p_sjc = sjc;
                            struct_dhsb.p_bhyy = HF_yc.Value;
                            struct_dhsb.p_czfs = "06";
                            struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（审核） 将原最终数据变为历史数据   设备编号：" + struct_dhsb.p_id;
                            dhsb.Update_DHSJ_SJBS_LSSJ_ZT(struct_dhsb);

                            //将副本数据变为最终数据
                            struct_dhsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_dhsb.p_bhyy = HF_yc.Value;
                            struct_dhsb.p_czfs = "06";
                            struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（审核）将原副本数据变为最终数据    设备编号：" + struct_dhsb.p_id;
                            dhsb.Update_DHSB_SJBS_FBSJ_ZT(struct_dhsb);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该导航设备信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_dhsb.p_id = id;
                        struct_dhsb.p_zt = "4";
                        struct_dhsb.p_bhyy = HF_yc.Value;
                        struct_dhsb.p_czfs = "07";
                        struct_dhsb.p_czxx = "位置：导航设备>状态->改变状态（驳回）   设备编号：" + struct_dhsb.p_id;
                        dhsb.Update_DHSBZT(struct_dhsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能驳回！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_dhsb.p_id = id;
                        struct_dhsb.p_zt = "4";
                        struct_dhsb.p_bhyy = HF_yc.Value;
                        struct_dhsb.p_czfs = "07";
                        struct_dhsb.p_czxx = "位置：导航设备->状态->改变状态（驳回）    设备编号：" + struct_dhsb.p_id;
                        dhsb.Update_DHSBZT(struct_dhsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该导航设备信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
               
            }
            bind_select();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)
            {
                Label lbl_zt = (Label)li.FindControl("ztmc");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "待初审")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待终审")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "审核未通过")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
        }


        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = dhsb.Select_DHSB_DC(_usState.userID);
            dt_dc.Columns.Add("xtsj_new");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["sbzt"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["sblx"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                dr["yssjc"] = SysData.ZXDMByKey(dr["yssjc"].ToString()).mc;
                dr["tzmczl_tzmc"] = SysData.SBZLByKey(dr["tzmczl_tzmc"].ToString()).mc;
                dr["tzmczl_sblx"] = SysData.SBLXByKey(dr["tzmczl_sblx"].ToString()).mc;   
                
                DateTime dt1 = new DateTime();
                dt1 = Convert.ToDateTime(dr["xt" +
                    "sj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["xtsj_new"] = string.Format("{0:yyyy-MM-dd}", dt1);
            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");
            dt_dc.Columns.Remove("BHYY");
            dt_dc.Columns.Remove("CSR");
            dt_dc.Columns.Remove("ZSR");
            dt_dc.Columns.Remove("LRR");
            dt_dc.Columns.Remove("SHSJ");
            dt_dc.Columns.Remove("SJC");
            dt_dc.Columns.Remove("SJBS");
            dt_dc.Columns.Remove("BMDM");
            //dt_dc.Columns.Remove("ZPLJ");
            dt_dc.Columns.Remove("xtsj");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "导航设备编号";
            dr_Insert[1] = "导航设备型号";
            dr_Insert[2] = "导航设备类型";
            dr_Insert[3] = "导航设备 台站名称种类";
            dr_Insert[4] = "导航设备 台站名称位置";
            dr_Insert[5] = "导航设备 台站名称设备类型";
            dr_Insert[6] = "导航设备 原所属机场";
            dr_Insert[7] = "频率";
            dr_Insert[8] = "频率单位";
            dr_Insert[9] = "呼号";
            dr_Insert[10] = "天线中心地面高程";
            dr_Insert[11] = "天线";
            dr_Insert[12] = "校飞周期";
            dr_Insert[13] = "校飞到期日期";
            dr_Insert[14] = "投产开放时间";
            dr_Insert[15] = "投产校飞时间";
            dr_Insert[16] = "投产是否限用";
            dr_Insert[17] = "投产说明";
            dr_Insert[18] = "末次飞行校验日期";
            dr_Insert[19] = "末次飞行校验结果";
            dr_Insert[20] = "末次飞行校验结果说明";
            dr_Insert[21] = "大地坐标（北京54）经度";
            dr_Insert[22] = "大地坐标（北京54）纬度";
            dr_Insert[23] = "大地坐标（wgs84）经度";
            dr_Insert[24] = "大地坐标（wgs84）纬度";
            dr_Insert[25] = "末次校飞报告";
            dr_Insert[26] = "频率呼号文件";
            dr_Insert[27] = "设备许可证";
            dr_Insert[28] = "台址批复文件路径";
            dr_Insert[29] = "无线电设备发射核准证件";
            dr_Insert[30] = "设备厂家";
            dr_Insert[31] = "输出功率";
            dr_Insert[32] = "输出功率单位";
            dr_Insert[33] = "设备出厂编号";
            dr_Insert[34] = "覆盖范围";
            dr_Insert[35] = "覆盖范围单位";
            dr_Insert[36] = "设备状态";
            dr_Insert[37] = "数量";
            dr_Insert[38] = "距跑道中心距离";
            dr_Insert[39] = "跑道长度";
            dr_Insert[40] = "使用年限";
            dr_Insert[41] = "卫星导航地面设备——天线类型";
            dr_Insert[42] = "航向设备（仪表着陆系统）类别 I II 选择";
            dr_Insert[43] = "航向设备（仪表着陆系统）跑道号";
            dr_Insert[44] = "航向设备（仪表着陆系统）天线阵类型 单频 双频";
            dr_Insert[45] = "航向设备（仪表着陆系统）天线阵子数";
            dr_Insert[46] = "航向设备（仪表着陆系统）天线阵距跑道末端距离 两位小数";
            dr_Insert[47] = "航向设备（仪表着陆系统）天线阵距跑道入口端距离";
            dr_Insert[48] = "航向设备（仪表着陆系统）天线阵距跑道中心垂直距离";
            dr_Insert[49] = "下滑设备（仪表着陆系统GP）设计下滑角";
            dr_Insert[50] = "下滑设备（仪表着陆系统GP）设计入口高度";
            dr_Insert[51] = "下滑设备（仪表着陆系统GP）天线阵类型";
            dr_Insert[52] = "下滑设备（仪表着陆系统GP）投产下天线高度";
            dr_Insert[53] = "下滑设备（仪表着陆系统GP）目前下天线高度";
            dr_Insert[54] = "下滑设备（仪表着陆系统GP）投产上天线高度";
            dr_Insert[55] = "下滑设备（仪表着陆系统GP）目前上天线高度";
            dr_Insert[56] = "下滑设备（仪表着陆系统GP）天线塔高度";
            dr_Insert[57] = "下滑设备（仪表着陆系统GP）距跑道入口内撤距离  米";
            dr_Insert[58] = "下滑设备（仪表着陆系统GP）距跑道中线垂距    米";
            dr_Insert[59] = "下滑设备（仪表着陆系统GP）位于跑道中心线";
            dr_Insert[60] = "下滑设备（仪表着陆系统GP）天线阵型号";
            dr_Insert[60] = "下滑设备（仪表着陆系统GP）盲降基准高RDH";
            dr_Insert[61] = "测距仪（DME）磁偏差";
            dr_Insert[62] = "测距仪（DME）跑道号";
            dr_Insert[63] = "测距仪（DME）端距";
            dr_Insert[64] = "测距仪（DME）波道号";
            dr_Insert[65] = "测距仪（DME）配套设备";
            dr_Insert[66] = "测距仪（DME）接收频率";
            dr_Insert[67] = "测距仪（DME）系统延迟";
            dr_Insert[68] = "全向信标（vo2）磁偏差";
            dr_Insert[69] = "全向信标（vo2）地网高度";
            dr_Insert[70] = "全向信标（vo2）监控器方位";
            dr_Insert[71] = "全向信标（vo2）地网直径";
            dr_Insert[72] = "全向信标（vo2）地网类型";
            dr_Insert[73] = "全向信标（vo2）跑道号";
            dr_Insert[74] = "全向信标（vo2）端距";
            dr_Insert[75] = "无方向信标（NDB）磁偏差";
            dr_Insert[76] = "无方向信标（NDB）地网高度";
            dr_Insert[77] = "无方向信标（NDB）监控器方位";
            dr_Insert[78] = "无方向信标（NDB）地网直径";
            dr_Insert[79] = "无方向信标（NDB）地网类型";
            dr_Insert[80] = "无方向信标（NDB）跑道号";
            dr_Insert[81] = "无方向信标（NDB）端距";
            dr_Insert[82] = "指点信标 跑道号";
            dr_Insert[83] = "指点信标 端距";
            dr_Insert[84] = "指点信标 类型选择";
            dr_Insert[85] = "设备履历";
            dr_Insert[86] = "交流供电";
            dr_Insert[87] = "交流供电大小";
            dr_Insert[89] = "交流供电数量";
            dr_Insert[90] = "直流供电";
            dr_Insert[91] = "直流供电大小";
            dr_Insert[92] = "直流供电数量";
            dr_Insert[93] = "保护区范围";
            dr_Insert[94] = "设备传输情况";
            dr_Insert[95] = "设备防雷配置";
            dr_Insert[96] = "现所属机场";
            dr_Insert[97] = "调拨时间";
            dr_Insert[98] = "设备保管人";
            dr_Insert[99] = "航向设备（仪表着陆系统）天线阵型号";
            dr_Insert[100] = "系统时间";
            dr_Insert[101] = "测距仪（DME）脉冲间隔";
            dr_Insert[102] = "无线电设备发射核准证件路径";
            dr_Insert[103] = "末次校飞报告路径";
            dr_Insert[104] = "频率呼号文件路径";
            dr_Insert[105] = "设备许可证路径";
            dr_Insert[106] = "台址批复文件路径";
            dr_Insert[107] = "保护区范围路径";
            dr_Insert[108] = "上传IP";
            dr_Insert[109] = "上传文件时间戳";
       
            dt_dc.Rows.InsertAt(dr_Insert, 0);
        
            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);

            //时间戳后缀
            string hz = "导航设备_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/DHSB.xls");
            // 1、首先判断文件或者文件路径是否存在
            if (File.Exists(path))
            {
                // 3.2、删除文件
                File.Delete(path);
            }

            ex.OutputFilePath = path;
            ex.OutputExcelFile();

            string fileName = hz;//客户端保存的文件名 
            string filePath = path;//目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }
        }


        #region 错误信息
        protected void Page_Error(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Write(EMException.ShowErrorScript(Server.GetLastError()));
                Response.Write(StrConvert.ShowScript("history.back();"));
                Response.End();
            }
            finally
            {
                Server.ClearError();
            }
        }
        #endregion
    }
}
