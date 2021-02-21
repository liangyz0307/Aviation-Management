using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CUST.WKG.SheBei.main
{
    public partial class SBGZ_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private WHWX wh;
        private Struct_SBGZ struct_sbgz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wh = new WHWX(_usState);
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_SB_GZ;
            psize = _usState.C_SB_GZ;
            if (!IsPostBack)
            {
                bind_drop();
                bind_select();
                show();
            }
        }

        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "140802") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }

        private void bind_select()
        {
            struct_sbgz.p_sbbh = tbx_sbbh.Text.ToString();
            struct_sbgz.p_sblx = ddlt_sblx.SelectedValue.ToString();
            struct_sbgz.p_sbzl = ddlt_sbzl.SelectedValue.ToString();
            struct_sbgz.p_wxr = tbx_wxr.Text.ToString();
            struct_sbgz.p_wxrbm = ddlt_wxrbm.SelectedValue.ToString();
            struct_sbgz.p_wxrgw = ddlt_wxrgw.SelectedValue.ToString();
            struct_sbgz.p_sblx = ddlt_sblx.SelectedValue.ToString();
        //    struct_sbgz.p_zxdm = _usState.userSS;
            struct_sbgz.p_userid = _usState.userID;


            int count = wh.Select_SBGZ_Count(struct_sbgz);
            pg_fy.TotalRecord = count;
            struct_sbgz.p_currentpage = pg_fy.CurrentPage;
            struct_sbgz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = wh.Select_SBGZ_Pro(struct_sbgz).Tables[0];

            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sblxmc");
            //dt.Columns.Add("whztmc");
            dt.Columns.Add("wxrbmmc");
            dt.Columns.Add("wxrgwmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bm");
          //  dt.Columns.Add("bm");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                //dr["whztmc"] = SysData.WHZTByKey(dr["whzt"].ToString()).mc;
                dr["wxrbmmc"] = SysData.BMByKey(dr["WXRBM"].ToString()).mc;
                dr["wxrgwmc"] = SysData.GWByKey(dr["WXRGW"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
            //    dr["rqmc"] = DateTime.Parse(dr["rq"].ToString()).ToString("yyyy-MM-dd");
            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        private void bind_drop()
        {


            ////设备种类
            //DataTable dt = new DataTable();
            //ddlt_sbzl.DataSource = dt;
            //ddlt_sbzl.DataBind();
            //ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));

            //设备种类

            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));


            //维修人部门
            ddlt_wxrbm.DataTextField = "mc";
            ddlt_wxrbm.DataValueField = "bm";
            ddlt_wxrbm.DataSource = SysData.BM().Copy();
            ddlt_wxrbm.DataBind();
            ddlt_wxrbm.Items.Insert(0, new ListItem("全部", "-1"));
            //维修人岗位

            DataTable dt_whrgw = new DataTable();
            ddlt_wxrgw.DataSource = dt_whrgw;
            ddlt_wxrgw.DataBind();
            ddlt_wxrgw.Items.Insert(0, new ListItem("全部", "-1"));


            //设备类型

            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string zt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识

            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140803"))
                    {
                        Server.Transfer("SBGZ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("SBGZ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_sbgz = new Struct_SBGZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->设备故障管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Delete_SBGZ(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140804"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->设备故障管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Delete_SBGZ(id, p_czfs, p_czxx);
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
                struct_sbgz = new Struct_SBGZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_sbgz.p_id = id;
                        struct_sbgz.p_zt = "1";
                        struct_sbgz.p_bhyy = HF_yc.Value;
                        struct_sbgz.p_czfs = "08";
                        struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBGZZT(struct_sbgz);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1408", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_sbgz.p_id = id;
                        struct_sbgz.p_zt = "2";
                        struct_sbgz.p_bhyy = HF_yc.Value;
                        struct_sbgz.p_czfs = "06";
                        struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBGZZT(struct_sbgz);
                        SysData.Delete_TSR(csr, "14", "1408", id);
                        SysData.Insert_TSR(zsr, "14", "1408", id);
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
                        struct_sbgz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_sbgz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_sbgz.p_bhyy = HF_yc.Value;
                            struct_sbgz.p_czfs = "06";
                            struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBGZ_SJBS_ZT(struct_sbgz);
                            SysData.Delete_TSR(zsr, "14", "1408", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_sbgz.p_sjc = sjc;
                            struct_sbgz.p_bhyy = HF_yc.Value;
                            struct_sbgz.p_czfs = "06";
                            struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBGZ_SJBS_LSSJ_ZT(struct_sbgz);

                            //将副本数据变为最终数据
                            struct_sbgz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_sbgz.p_bhyy = HF_yc.Value;
                            struct_sbgz.p_czfs = "06";
                            struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBGZ_SJBS_FBSJ_ZT(struct_sbgz);
                            SysData.Delete_TSR(zsr, "14", "1408", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该设备故障信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_sbgz.p_id = id;
                        struct_sbgz.p_zt = "4";
                        struct_sbgz.p_bhyy = HF_yc.Value;
                        struct_sbgz.p_czfs = "08";
                        struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBGZZT(struct_sbgz);
                        SysData.Delete_TSR(csr, "14", "1408", id);
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
                        struct_sbgz.p_id = id;
                        struct_sbgz.p_zt = "4";
                        struct_sbgz.p_bhyy = HF_yc.Value;
                        struct_sbgz.p_czfs = "08";
                        struct_sbgz.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBGZZT(struct_sbgz);
                        SysData.Delete_TSR(zsr, "14", "1408", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备故障信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_select();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx");
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBGZ_Add.aspx");

        }

        protected void ddlt_sblx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lx = ddlt_sblx.SelectedValue.ToString();
            if (lx == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_sbzl.DataSource = dt;
                ddlt_sbzl.DataBind();
                ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_sbzl.DataSource = SysData.SBZL(lx).Copy();
                ddlt_sbzl.DataTextField = "mc";
                ddlt_sbzl.DataValueField = "bm";
                ddlt_sbzl.DataBind();
                ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));
            }

        }

        protected void ddlt_whrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_wxrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_wxrgw.DataSource = dt;
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_wxrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_wxrgw.DataTextField = "mc";
                ddlt_wxrgw.DataValueField = "bm";
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        //导出
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = wh.Select_SBGZ_DC(_usState.userID);
            dt_dc.Columns.Add("gzqssj_z");//毕业时间
            dt_dc.Columns.Add("gzjssj_z");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["sblx"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                dr["wxrbm"] = SysData.BMByKey(dr["wxrbm"].ToString()).mc;
                dr["wxrgw"] = SysData.GWByKey(dr["wxrgw"].ToString()).mc;
                dr["sbzl"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["gzqssj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["gzqssj_z"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);


                dt_csrq = Convert.ToDateTime(dr["gzjssj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["gzjssj_z"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            dt_dc.Columns.Remove("bmdm");
            dt_dc.Columns.Remove("ZT");
            dt_dc.Columns.Remove("sfxf");
            dt_dc.Columns.Remove("sfghbj");
            dt_dc.Columns.Remove("ghbjmc");
            dt_dc.Columns.Remove("cllc");
            dt_dc.Columns.Remove("sfdjsb");
            dt_dc.Columns.Remove("bzzdqssj");
            dt_dc.Columns.Remove("bzzdjssj");
            dt_dc.Columns.Remove("blid");
            dt_dc.Columns.Remove("sbmc");
            dt_dc.Columns.Remove("sbszd");
            dt_dc.Columns.Remove("lcwjscyh");
            dt_dc.Columns.Remove("sfyxyx");
            dt_dc.Columns.Remove("sbmcbz");
            dt_dc.Columns.Remove("zxdm");
            dt_dc.Columns.Remove("wxwjsc");

            dt_dc.Columns.Remove("gzqssj");
            dt_dc.Columns.Remove("gzjssj");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "设备编号";
 
            dr_Insert[1] = "累计时长";
            dr_Insert[2] = "维修人";
            dr_Insert[3] = "故障现象";
            dr_Insert[4] = "造成影响";
            dr_Insert[5] = "处置过程";
            dr_Insert[6] = "故障原因分析";
            dr_Insert[7] = "故障板件处理结果";
            dr_Insert[8] = "同类故障排除方法";
            dr_Insert[9] = "处理步骤";
            dr_Insert[10] = "建议措施";
            dr_Insert[10] = "备注";
            dr_Insert[10] = "设备类型";
            dr_Insert[10] = "维修人部门";
            dr_Insert[10] = "维修人岗位";


            dr_Insert[11] = "故障起始时间";
            dr_Insert[12] = "故障结束时间";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "设备故障" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../Shebei/SBGZ.xls");
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
    }
}