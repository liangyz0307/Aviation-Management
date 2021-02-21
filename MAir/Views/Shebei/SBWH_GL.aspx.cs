using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System.Globalization;
using System.IO;

namespace CUST.WKG.SheBei.main
{
    public partial class SBWH_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private WHWX wh;
        private Struct_SBWH struct_sbwh;
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
            pg_fy.NumPerPage = _usState.C_SB_WH;
            psize = _usState.C_SB_WH;

            if (!IsPostBack)
            {
                bind_drop();
                bind_select();
            }
        }
        private void bind_select()
        {
            struct_sbwh.p_sbbh=tbx_sbbh.Text.ToString();
            struct_sbwh.p_sbzl=ddlt_sbzl.SelectedValue.ToString();
            struct_sbwh.p_whr=tbx_whr.Text.ToString();
            struct_sbwh.p_whrbm=ddlt_whrbm.SelectedValue.ToString();
            struct_sbwh.p_whrgw=ddlt_whrgw.SelectedValue.ToString();
            struct_sbwh.p_whzt=ddlt_whzt.SelectedValue.ToString();
          
            struct_sbwh.p_sblx=ddlt_sblx.SelectedValue.ToString();
            struct_sbwh.p_userid = _usState.userID;

            int count = wh.Select_SBWH_Count(struct_sbwh);
            pg_fy.TotalRecord = count;
            struct_sbwh.p_currentpage=pg_fy.CurrentPage;
            struct_sbwh.p_pagesize = pg_fy.NumPerPage;
            DataTable dt=wh.Select_SBWH_Pro(struct_sbwh).Tables[0];

            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("whztmc");
            dt.Columns.Add("whrbmmc");
            dt.Columns.Add("whrgwmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bm");
            dt.Columns.Add("whsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblxdm"].ToString()).mc;
                dr["whztmc"] = SysData.WHZTByKey(dr["whzt"].ToString()).mc;
                dr["whrbmmc"] = SysData.BMByKey(dr["whrbm"].ToString()).mc;
                dr["whrgwmc"] = SysData.GWByKey(dr["whrgw"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["whsjmc"] = DateTime.Parse(dr["whsj"].ToString()).ToString("yyyy-MM-dd");

            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        private void bind_drop()
        {


            //设备种类

            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));

            //DataTable dt = new DataTable();
            //ddlt_sbzl.DataSource = dt;
            //ddlt_sbzl.DataBind();
            //ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));


            //维护人部门
            ddlt_whrbm.DataTextField = "mc";
            ddlt_whrbm.DataValueField = "bm";
            ddlt_whrbm.DataSource = SysData.BM().Copy();
            ddlt_whrbm.DataBind();
            ddlt_whrbm.Items.Insert(0, new ListItem("全部", "-1"));
            //维护人岗位

            DataTable dt_whrgw = new DataTable();
            ddlt_whrgw.DataSource = dt_whrgw;
            ddlt_whrgw.DataBind();
            ddlt_whrgw.Items.Insert(0, new ListItem("全部", "-1"));

         
            //设备类型
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            //维护状态
            ddlt_whzt.DataTextField = "mc";
            ddlt_whzt.DataValueField = "bm";
            ddlt_whzt.DataSource = SysData.WHZT().Copy();
            ddlt_whzt.DataBind();
            ddlt_whzt.Items.Insert(0, new ListItem("全部", "-1"));

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140903"))
                    {
                        Server.Transfer("SBWH_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("SBWH_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_sbwh = new Struct_SBWH();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->设备维护管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Delete_SBWH(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140904"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->设备维护管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Delete_SBWH(id, p_czfs, p_czxx);
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
                struct_sbwh = new Struct_SBWH();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_sbwh.p_id = id;
                        struct_sbwh.p_zt = "1";
                        struct_sbwh.p_bhyy = HF_yc.Value;
                        struct_sbwh.p_czfs = "08";
                        struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBWHZT(struct_sbwh);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1409", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_sbwh.p_id = id;
                        struct_sbwh.p_zt = "2";
                        struct_sbwh.p_bhyy = HF_yc.Value;
                        struct_sbwh.p_czfs = "06";
                        struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBWHZT(struct_sbwh);
                        SysData.Delete_TSR(csr, "14", "1409", id);
                        SysData.Insert_TSR(zsr, "14", "1409", id);
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
                        struct_sbwh.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_sbwh.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_sbwh.p_bhyy = HF_yc.Value;
                            struct_sbwh.p_czfs = "06";
                            struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBWH_SJBS_ZT(struct_sbwh);
                            SysData.Delete_TSR(zsr, "14", "1409", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_sbwh.p_sjc = sjc;
                            struct_sbwh.p_bhyy = HF_yc.Value;
                            struct_sbwh.p_czfs = "06";
                            struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBWH_SJBS_LSSJ_ZT(struct_sbwh);

                            //将副本数据变为最终数据
                            struct_sbwh.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_sbwh.p_bhyy = HF_yc.Value;
                            struct_sbwh.p_czfs = "06";
                            struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            wh.Update_SBWH_SJBS_FBSJ_ZT(struct_sbwh);
                            SysData.Delete_TSR(zsr, "14", "1409", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该设备维护信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_sbwh.p_id = id;
                        struct_sbwh.p_zt = "4";
                        struct_sbwh.p_bhyy = HF_yc.Value;
                        struct_sbwh.p_czfs = "08";
                        struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBWHZT(struct_sbwh);
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
                        struct_sbwh.p_id = id;
                        struct_sbwh.p_zt = "4";
                        struct_sbwh.p_bhyy = HF_yc.Value;
                        struct_sbwh.p_czfs = "08";
                        struct_sbwh.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wh.Update_SBWHZT(struct_sbwh);
                        SysData.Delete_TSR(zsr, "14", "1409", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备维护信息已驳回，不可重复驳回！\")</script>");
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
            Response.Redirect("../SheBei/SBWH_Add.aspx");
        }

        protected void ddlt_whrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_whrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_whrgw.DataSource = dt;
                ddlt_whrgw.DataBind();
                ddlt_whrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_whrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_whrgw.DataTextField = "mc";
                ddlt_whrgw.DataValueField = "bm";
                ddlt_whrgw.DataBind();
                ddlt_whrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
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

        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = wh.Select_SBWH_DC(_usState.userID);
            dt_dc.Columns.Add("whsj_z");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["sblxdm"] = SysData.SBLXByKey(dr["sblxdm"].ToString()).mc;
                dr["whrbm"] = SysData.BMByKey(dr["whrbm"].ToString()).mc;
                dr["whrgw"] = SysData.GWByKey(dr["whrgw"].ToString()).mc;
                dr["whzt"] = SysData.WHZTByKey(dr["whzt"].ToString()).mc;
                dr["sbzl"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["whsj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["whsj_z"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            dt_dc.Columns.Remove("WHWJSC");
            dt_dc.Columns.Remove("whsj");
            dt_dc.Columns.Remove("scsj");

            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "设备编号";
            dr_Insert[1] = "维护人";
            dr_Insert[2] = "设备状态详细信息";
            dr_Insert[3] = "维护记录";
            dr_Insert[4] = "场地环境和电磁环境巡视记录";
            dr_Insert[5] = "维护状态";
            dr_Insert[6] = "备注";
            dr_Insert[7] = "设备类型";
            dr_Insert[8] = "设备种类";
            dr_Insert[9] = "维护人部门";
            dr_Insert[10] = "维护人岗位";
            dr_Insert[11] = "维护时间";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "设备维护" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../Shebei/SBWH.xls");
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