using Sys;
using System;
using CUST.MKG;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST.Tools;
using System.Globalization;
using System.IO;

namespace CUST.WKG
{
    public partial class ZCGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YGZC ygzc;
        private Struct_YGZC struct_YGZC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            ygzc = new YGZC(_usState);
            struct_YGZC = new Struct_YGZC();
            if (!IsPostBack)
            {
                tbx_prsjks.Attributes.Add("readonly", "readonly");
                tbx_prsjjs.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
                show();
            }
        }

        #region 判断用户是否有添加权限
        public void show()
        {

            Boolean flag_add = false;

            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "110702") == true)
            {
                flag_add = true;
            }

            if (flag_add) { btn_add.Visible = true; }

        }
        #endregion
        private void ddltBind()
        {
            //类别
            ddlt_lb.DataSource = SysData.QZZY().Copy();
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            ////级别
            //ddlt_jb.DataSource = SysData.ZCJB().Copy();
            //ddlt_jb.DataTextField = "mc";
            //ddlt_jb.DataValueField = "bm";
            //ddlt_jb.DataBind();
            //ddlt_jb.Items.Insert(0,new ListItem("全部","-1"));
            ////资格
            //ddlt_zg.DataSource = SysData.ZG().Copy();
            //ddlt_zg.DataTextField = "mc";
            //ddlt_zg.DataValueField = "bm";
            //ddlt_zg.DataBind();
            //ddlt_zg.Items.Insert(0,new ListItem("全部","-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private void bind_Main()
        {
            struct_YGZC.p_spr = "";//受聘人
            struct_YGZC.p_bmdm = ddlt_bmdm.SelectedValue.Trim().ToString();
            struct_YGZC.p_lb = ddlt_lb.SelectedValue.Trim().ToString();//类别
            struct_YGZC.p_jb = "-1";//级别
            struct_YGZC.p_zg = "-1";//资格
            struct_YGZC.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态

            if (tbx_prsjks.Text == "")
            {

                struct_YGZC.p_prsjks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_YGZC.p_prsjks = DateTime.Parse(tbx_prsjks.Text.Trim().ToString());//聘任时间开始
            }
            if (tbx_prsjjs.Text == "")
            {
                struct_YGZC.p_prsjjs = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_YGZC.p_prsjjs = DateTime.Parse(tbx_prsjjs.Text.Trim().ToString());//聘任时间结束
            }
            struct_YGZC.p_userid = _usState.userID;
            DataTable dt = new DataTable();

            int count = ygzc.Select_YGZC_Count(struct_YGZC);
            pg_fy.TotalRecord = count;
            struct_YGZC.p_currentpage = pg_fy.CurrentPage;
            struct_YGZC.p_pagesize = pg_fy.NumPerPage;
            dt = ygzc.Select_YGZC_Pro(struct_YGZC);



            dt.Columns.Add("bm");
            dt.Columns.Add("qzzydmmc");
            dt.Columns.Add("jbmc");
            dt.Columns.Add("zgmc");
            dt.Columns.Add("prmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("hdsjmc");
            dt.Columns.Add("dqsjmc");
            dt.Columns.Add("prsjmc");
            DateTime dt_hdsj = new DateTime();
            DateTime dt_dqsj = new DateTime();
            DateTime dt_prsj = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["qzzydmmc"] = SysData.QZZYByKey(dr["lb"].ToString()).mc;
                dr["jbmc"] = SysData.ZCJBByKey(dr["jb"].ToString()).mc;
                dr["zgmc"] = SysData.ZGByKey(dr["zg"].ToString()).mc;
                dr["prmc"] = SysData.PRByKey(dr["pr"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dt_hdsj = Convert.ToDateTime(dr["hdsj"].ToString());
                dr["hdsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_hdsj);
                dt_dqsj = Convert.ToDateTime(dr["dqsj"].ToString());
                dr["dqsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_dqsj);
                dt_prsj = Convert.ToDateTime(dr["prsj"].ToString());
                dr["prsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_prsj);
            }
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110703"))
                    {
                        Server.Transfer("ZCGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("ZCGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_YGZC = new Struct_YGZC();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工职称->员工职称管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Delete_YGZC(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110704"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工职称->员工职称管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Delete_YGZC(id, p_czfs, p_czxx);
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
                struct_YGZC = new Struct_YGZC();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_YGZC.p_id = id;
                        struct_YGZC.p_zt = "1";
                        struct_YGZC.p_bhyy = HF_yc.Value;
                        struct_YGZC.p_czfs = "05";
                        struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Update_YGZCZT(struct_YGZC);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1107", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_YGZC.p_id = id;
                        struct_YGZC.p_zt = "2";
                        struct_YGZC.p_bhyy = HF_yc.Value;
                        struct_YGZC.p_czfs = "06";
                        struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Update_YGZCZT(struct_YGZC);
                        SysData.Delete_TSR(csr, "11", "1107", id);
                        SysData.Insert_TSR(zsr, "11", "1107", id);
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
                        struct_YGZC.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_YGZC.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_YGZC.p_bhyy = HF_yc.Value;
                            struct_YGZC.p_czfs = "06";
                            struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzc.Update_YGZC_SJBS_ZT(struct_YGZC);
                            SysData.Delete_TSR(zsr, "11", "1107", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_YGZC.p_sjc = sjc;
                            struct_YGZC.p_bhyy = HF_yc.Value;
                            struct_YGZC.p_czfs = "06";
                            struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzc.Update_YGZC_SJBS_LSSJ_ZT(struct_YGZC);

                            //将副本数据变为最终数据
                            struct_YGZC.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_YGZC.p_bhyy = HF_yc.Value;
                            struct_YGZC.p_czfs = "06";
                            struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzc.Update_YGZC_SJBS_FBSJ_ZT(struct_YGZC);
                            SysData.Delete_TSR(zsr, "11", "1107", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工职称信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_YGZC.p_id = id;
                        struct_YGZC.p_zt = "4";
                        struct_YGZC.p_bhyy = HF_yc.Value;
                        struct_YGZC.p_czfs = "07";
                        struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Update_YGZCZT(struct_YGZC);
                        SysData.Delete_TSR(csr, "11", "1107", id);
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
                        struct_YGZC.p_id = id;
                        struct_YGZC.p_zt = "4";
                        struct_YGZC.p_bhyy = HF_yc.Value;
                        struct_YGZC.p_czfs = "07";
                        struct_YGZC.p_czxx = "位置：员工职称->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzc.Update_YGZCZT(struct_YGZC);
                        SysData.Delete_TSR(zsr, "11", "1107", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工职称信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../YuanGong/ZCGL_Add.aspx", false);
        }

        protected void btn_dc_Click(object sender, EventArgs e)
        {
            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = ygzc.Select_YGZC_DC(_usState.userID);
            if (dt_dc.Rows.Count==0) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"暂无数据，请先录入数据再导出！\")</script>");
                return;
            }

            //dt_dc.Columns.Add("rq");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["lb"] = SysData.QZZYByKey(dr["lb"].ToString()).mc;//类别
                dr["jb"] = SysData.JBByKey(dr["jb"].ToString()).mc;//级别
                dr["zg"] = SysData.ZGByKey(dr["zg"].ToString()).mc;//资格
                dr["pr"] = SysData.PRByKey(dr["pr"].ToString()).mc;//是否聘任
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态

                //DateTime dt_csq = new DateTime();
                //dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                //dr["rq"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
            }
            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");//id
            dt_dc.Columns.Remove("zt");//状态
            dt_dc.Columns.Remove("BHYY");//驳回原因
            dt_dc.Columns.Remove("SPR");//受聘人
            dt_dc.Columns.Remove("bm");//部门
            dt_dc.Columns.Remove("SJC"); //时间戳
            dt_dc.Columns.Remove("SHSJ"); //审核时间
            dt_dc.Columns.Remove("LRR"); //录入人
            dt_dc.Columns.Remove("CSR");//初审人
            dt_dc.Columns.Remove("ZSR");//终审人
            dt_dc.Columns.Remove("SJBS");//数据标识

            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "类别";
            dr_Insert[1] = "级别";
            dr_Insert[2] = "资格";
            dr_Insert[3] = "是否聘任";
            dr_Insert[4] = "资格审权单位";
            dr_Insert[5] = "获得时间";
            dr_Insert[6] = "聘任时间";
            dr_Insert[7] = "到期时间";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "员工职称_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../YuanGong/YGZC.xls");
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