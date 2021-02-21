﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using Sys;
using CUST.Tools;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;


namespace CUST.WKG
{
    public partial class KG_PXJL : System.Web.UI.Page
    {
        private UserState _us;
        private Struct_PXJL struct_pxjl;
        private string id;
        public int cpage;
        public int psize;
        private PXJL pxjl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            pxjl = new PXJL(_us);
            struct_pxjl = new Struct_PXJL();
            if (!IsPostBack)
            {
                p_rqsj_ks.Attributes.Add("readonly", "readonly");
                p_rqsj_js.Attributes.Add("readonly", "readonly");
                Bind();
                bind_Main();
                show();
            }
        }
        //权限判断是否显示添加按钮
        protected void show()
        {
            Boolean flag_add = false;
          
            btn_add.Visible = false;
            if (SysData.HasThisBMQX( _us.userID, "110602"))
            {
                btn_add.Visible = true;
            }
            if (flag_add) { btn_add.Visible = true; }
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
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
        private void bind_Main()
        {
            if (p_rqsj_ks.Text == "")
            {
                struct_pxjl.p_rqsj_ks = Convert.ToDateTime("0001-1-1 00:00:00");

            }
            else
            {
                struct_pxjl.p_rqsj_ks = DateTime.Parse(p_rqsj_ks.Text.ToString().Trim());
            }
            if (p_rqsj_js.Text == "")
            {
                struct_pxjl.p_rqsj_js = Convert.ToDateTime("9999-12-30 23:59:59");

            }
            else
            {
                struct_pxjl.p_rqsj_js = DateTime.Parse(p_rqsj_js.Text.ToString().Trim());
            }
            struct_pxjl.p_type = "-1";
            struct_pxjl.p_bmdm = ddlt_bmdm.SelectedValue.Trim().ToString();
            struct_pxjl.p_jb = "-1";
            struct_pxjl.p_khjg = ddlt_khjg.Text.ToString().Trim();
            struct_pxjl.p_pxs = "";
            struct_pxjl.p_sjyz = "";
            struct_pxjl.p_zt = ddlt_zt.SelectedValue.Trim().ToString();
            struct_pxjl.p_userid = _us.userID;
            DataTable dt = new DataTable();

            int count = pxjl.Select_PXJL_Count(struct_pxjl);
            pg_fy.TotalRecord = count;
            struct_pxjl.p_CurrentPage = pg_fy.CurrentPage;
            struct_pxjl.p_pagesize = pg_fy.NumPerPage;
            dt = pxjl.Select_PXJL_Pro(struct_pxjl);
            
            dt.Columns.Add("bm");
            dt.Columns.Add("typemc");
            dt.Columns.Add("jbmc");
            dt.Columns.Add("khjgmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rqsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["rqsjmc"] = DateTime.Parse(dr["rqsj"].ToString()).ToString("yyyy-MM-dd");
                dr["typemc"] = SysData.typeByKey(dr["type"].ToString()).mc;
          
                dr["jbmc"] = SysData.JBByKey(dr["jb"].ToString()).mc;
        
                dr["khjgmc"] = SysData.khjgByKey(dr["khjg"].ToString()).mc;
          
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("KG_PXJL_ADD.aspx", true);
        }
        private void Bind()
        {
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            ////事件类型
            //ddlt_type.DataSource = SysData.TYPE().Copy();
            //ddlt_type.DataTextField = "mc";
            //ddlt_type.DataValueField = "bm";
            //ddlt_type.DataBind();
            //ddlt_type.Items.Insert(0, new ListItem("全部", "-1"));
            ////级别
            //ddlt_jb.DataSource = SysData.JB().Copy();
            //ddlt_jb.DataTextField = "mc";
            //ddlt_jb.DataValueField = "bm";
            //ddlt_jb.DataBind();
            //ddlt_jb.Items.Insert(0, new ListItem("全部", "-1"));
            //考核结果
            ddlt_khjg.DataSource = SysData.KHJG().Copy();
            ddlt_khjg.DataTextField = "mc";
            ddlt_khjg.DataValueField = "bm";
            ddlt_khjg.DataBind();
            ddlt_khjg.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "110603"))
                    {
                        Server.Transfer("KG_PXJL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                    if (lrr.Equals(_us.userLoginName))
                    {
                        Server.Transfer("KG_PXJL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_pxjl = new Struct_PXJL();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工培训->员工培训管理->删除    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Delete_PXJL_Pro(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "110604"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工培训->员工培训管理->删除    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Delete_PXJL_Pro(id, p_czfs, p_czxx);
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
                struct_pxjl = new Struct_PXJL();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        struct_pxjl.p_id = id;
                        struct_pxjl.p_zt = "1";
                        struct_pxjl.p_bhyy = HF_yc.Value;
                        struct_pxjl.p_czfs = "05";
                        struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（提交）    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Update_PXJLZT(struct_pxjl);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1106", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_us.userLoginName))
                    {
                        struct_pxjl.p_id = id;
                        struct_pxjl.p_zt = "2";
                        struct_pxjl.p_bhyy = HF_yc.Value;
                        struct_pxjl.p_czfs = "06";
                        struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Update_PXJLZT(struct_pxjl);
                        SysData.Delete_TSR(csr, "11", "1106", id);
                        SysData.Insert_TSR(zsr, "11", "1106", id);
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
                    if (zsr.Equals(_us.userLoginName))
                    {
                        struct_pxjl.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_pxjl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_pxjl.p_bhyy = HF_yc.Value;
                            struct_pxjl.p_czfs = "06";
                            struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                            pxjl.Update_PXJL_SJBS_ZT(struct_pxjl);
                            SysData.Delete_TSR(zsr, "11", "1106", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_pxjl.p_sjc = sjc;
                            struct_pxjl.p_bhyy = HF_yc.Value;
                            struct_pxjl.p_czfs = "06";
                            struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _us.userLoginName + "]";
                            pxjl.Update_PXJL_SJBS_LSSJ_ZT(struct_pxjl);

                            //将副本数据变为最终数据
                            struct_pxjl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_pxjl.p_bhyy = HF_yc.Value;
                            struct_pxjl.p_czfs = "06";
                            struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _us.userLoginName + "]";
                            pxjl.Update_PXJL_SJBS_FBSJ_ZT(struct_pxjl);
                            SysData.Delete_TSR(zsr, "11", "1106", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工培训信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_us.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_pxjl.p_id = id;
                        struct_pxjl.p_zt = "4";
                        struct_pxjl.p_bhyy = HF_yc.Value;
                        struct_pxjl.p_czfs = "07";
                        struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Update_PXJLZT(struct_pxjl);
                        SysData.Delete_TSR(csr, "11", "1106", id);
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
                    if (zsr.Equals(_us.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_pxjl.p_id = id;
                        struct_pxjl.p_zt = "4";
                        struct_pxjl.p_bhyy = HF_yc.Value;
                        struct_pxjl.p_czfs = "07";
                        struct_pxjl.p_czxx = "位置：员工培训->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        pxjl.Update_PXJLZT(struct_pxjl);
                        SysData.Delete_TSR(zsr, "11", "1106", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已驳回，不可重复驳回！\")</script>");
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

        protected void btn_dc_Click(object sender, EventArgs e)
        {
            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = pxjl.Select_YGPX_DC(_us.userID);
            if (dt_dc.Rows.Count==0) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"暂无数据，请先录入数据再导出！\")</script>");
                return;
            }

            //dt_dc.Columns.Add("sjssbmmc");
            foreach (DataRow dr in dt_dc.Rows)
            {
                string[] Array_pxs = dr["pxs"].ToString().Split(',');//培训师
                string[] Array_sjyz = dr["sjyz"].ToString().Split(',');//受教育者
                foreach (string pxs_bh in Array_pxs)
                {
                    dr["pxs"] = pxjl.Select_YGXMbyBH(pxs_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string sjyz_bh in Array_sjyz)
                {
                    dr["sjyz"] = pxjl.Select_YGXMbyBH(sjyz_bh.ToString()).Rows[0][0].ToString();
                }
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["type"] = SysData.typeByKey(dr["type"].ToString()).mc;
                dr["jb"] = SysData.JBByKey(dr["jb"].ToString()).mc;
                dr["khjg"] = SysData.khjgByKey(dr["khjg"].ToString()).mc;
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;

                DateTime dt_rq = new DateTime();
                dt_rq = Convert.ToDateTime(dr["RQ"].ToString());//日期
                dr["RQ"] = string.Format("{0:yyyy-MM-dd}", dt_rq);
            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");//id
            dt_dc.Columns.Remove("zt");//状态
            dt_dc.Columns.Remove("BHYY");//驳回原因
            dt_dc.Columns.Remove("JXNR");//教学内容
            dt_dc.Columns.Remove("bm");//部门
            dt_dc.Columns.Remove("CSR");// 初审人
            dt_dc.Columns.Remove("ZSR");//终审人
            dt_dc.Columns.Remove("LRR");//录入人
             dt_dc.Columns.Remove("SJBS");//时间标识
             dt_dc.Columns.Remove("SJC");// 时间戳
            dt_dc.Columns.Remove("SHSJ");// 审核时间
           
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            //dr_Insert[0] = "编号";
            dr_Insert[0] = "事件类型";
            dr_Insert[1] = "日期";
            dr_Insert[2] = "学时";
            dr_Insert[3] = "课时";
            dr_Insert[4] = "级别";
            dr_Insert[5] = "培训师";
            dr_Insert[6] = "考核方式";
            dr_Insert[7] = "考核结果";
            dr_Insert[8] = "受教育者";
            dr_Insert[9] = "负责人";
    
            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "员工培训_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../YuanGong/YGPX.xls");
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












