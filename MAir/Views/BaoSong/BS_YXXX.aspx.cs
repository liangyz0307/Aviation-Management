
using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class BS_YXXX : System.Web.UI.Page
    {
        private UserState _usState;
        private YXXX yxxx;
        private Struct_Bs_YXXX struct_bs_yxxx;
        public int cpage;
        public int psize;
        static DataTable dt;
        public string wjm;
        public string bsbh;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yxxx = new YXXX(_usState);
            struct_bs_yxxx = new Struct_Bs_YXXX();
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {

                Bind();
                bind_Main();
               // show();
            }
        }
        protected void show()
        {
            
        }

        public void link_visitDetail(object sender, CommandEventArgs e)

        {
            //OnClick="btnWord_Click"

            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string sbzt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识
            string bsbh = content[8];//报送编号
            string bswj = content[9];//报送文件
            string outputDirPath = Server.MapPath("../BaoSong/YXXX/") + bswj;
            string filePath = Server.MapPath("../BaoSong/YXXX/") + bswj;
            // Server.MapPath("~") + @"\DemoFiles\Test.docx";
            WordPreview.Priview(this, filePath, outputDirPath);

        }
        protected void btnWord_Click(object sender, EventArgs e)
        {
            
            string outputDirPath = Server.MapPath("../BaoSong//YXXX/")+wjm;
            string filePath = Server.MapPath("../BaoSong//YXXX/")+wjm;
            // Server.MapPath("~") + @"\DemoFiles\Test.docx";
            WordPreview.Priview(this, filePath, outputDirPath);
        }
        private void bind_Main()
        {
            struct_bs_yxxx.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态
            struct_bs_yxxx.p_bswj= tbx_bswj.Text.Trim().ToString();//报送文件
            if (tbx_bsrq_qs.Text.Trim().ToString() == "")
            {
                struct_bs_yxxx.p_bsrq_qs = Convert.ToDateTime("0001-1-20");
            }
            else
            {
                struct_bs_yxxx.p_bsrq_qs = DateTime.Parse(tbx_bsrq_qs.Text.Trim().ToString());//报送日期_起始
            }
            if (tbx_bsrq_jz.Text.Trim().ToString() == "")
            {
                struct_bs_yxxx.p_bsrq_jz = Convert.ToDateTime("9999-12-20");
            }
            else
            {
                struct_bs_yxxx.p_bsrq_jz = DateTime.Parse(tbx_bsrq_jz.Text.Trim().ToString());//报送日期_起始
            }
            struct_bs_yxxx.p_bsbm = ddlt_bmdm.SelectedValue.Trim().ToString();//部门;
            struct_bs_yxxx.p_userid = _usState.userID;
            struct_bs_yxxx.p_currentpage = pg_fy.CurrentPage;
            struct_bs_yxxx.p_pagesize = pg_fy.NumPerPage;
            int count = yxxx.Select_Bs_Yxxx_Count(struct_bs_yxxx);
            pg_fy.TotalRecord = count;
            dt = yxxx.Select_Bs_YXXX(struct_bs_yxxx);
            dt.Columns.Add("bm");
            dt.Columns.Add("yslxmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("sbnfs");
            dt.Columns.Add("wcsjs");

            foreach (DataRow dr in dt.Rows)
            {
                dr["bsrq"] = Convert.ToDateTime(dr["bsrq"]).ToString("yyyy-MM-dd");
                dr["bsbm"] = SysData.BMByKey((dr["bsbm"]).ToString()).mc;
                dr["zt"] = SysData.ZTDMByKey((dr["zt"]).ToString()).mc;
            }
            //绑定分页数据源  
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("BS_YXXX_Add.aspx");
        }
        #endregion
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Bind()
        {
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

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
            string sbzt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识
            string bsbh = content[8];//报送编号
            string bswj = content[9];//报送文件

            if (e.CommandName == "Delete"){
                string path = Server.MapPath("../BaoSong/YXXX/") + bswj;
                // 1、首先判断文件或者文件路径是否存在
                if (File.Exists(path))
                {
                    // 3.2、删除文件
                    File.Delete(path);
                }
                string p_czfs = "04";
                string p_czxx = "位置：航务综合->运行信息报送管理    描述：员工编号：[" + _usState.userLoginName + "]";
                yxxx.Delete_Bs_Yxxx(id, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            else if (e.CommandName == "Download") {
                //导出Excel保存的路径！
                string path = Server.MapPath("../BaoSong/YXXX/")+bswj;
                string fileName = bswj;//客户端保存的文件名 
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


                //if (e.CommandName == "Edit")
                //{
                //    if (sbzt == "1" || sbzt == "2")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报待审核，不能编辑！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "3")
                //    {
                //        //查询是否有权限编辑
                //        if (SysData.HasThisBMQX(_usState.userID, bmdm, "130403"))
                //        {
                //            Server.Transfer("BS_YSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该申报预算信息的编辑权限，不能编辑！\")</script>");
                //            return;
                //        }
                //    }

                //    else if (sbzt == "0" || sbzt == "4")
                //    {
                //        //如果是本人录入的信息
                //        if (lrr.Equals(_usState.userLoginName))
                //        {
                //            Server.Transfer("BS_YSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该申报预算信息的编辑权限，不能编辑！\")</script>");
                //            return;
                //        }
                //    }
                //}
                //else if (e.CommandName == "Delete")
                //{
                //    struct_bs_yssb_update = new Struct_Bs_Yssb_Update();
                //    if (sbzt == "0" || sbzt == "4")
                //    {
                //        //如果是本人录入的信息
                //        if (lrr.Equals(_usState.userLoginName))
                //        {
                //            string p_czfs = "04";
                //            string p_czxx = "位置：航务综合->申报预算管理    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Delete_Bs_Yssb(id, p_czfs, p_czxx);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                //            return;
                //        }
                //    }
                //    else if (sbzt == "1" || sbzt == "2")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该申报预算信息待审核，不可删除！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "3")
                //    {
                //        if (SysData.HasThisBMQX(_usState.userID, bmdm, "130404"))
                //        {
                //            string p_czfs = "04";
                //            string p_czxx = "位置：航务综合->申报预算管理    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Delete_Bs_Yssb(id, p_czfs, p_czxx); ;
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该预算申报信息的删除权限，不可删除！\")</script>");
                //            return;
                //        }
                //    }
                //}
                //else if (e.CommandName == "Update_TJ")
                //{
                //    struct_bs_yssb_update = new Struct_Bs_Yssb_Update();
                //    if (sbzt == "0")
                //    {
                //        //如果是本人录入的信息
                //        if (lrr.Equals(_usState.userLoginName))
                //        {
                //            struct_bs_yssb_update.p_id = id;
                //            struct_bs_yssb_update.p_sbzt = "1";
                //            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //            struct_bs_yssb_update.p_czfs = "05";
                //            struct_bs_yssb_update.p_czxx = "位置：航务综合->预算申报->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                //            return;
                //        }
                //    }
                //    if (sbzt == "1" || sbzt == "2")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报待审核，不可提交！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "3")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不可提交！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "4")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，请先编辑再提交！\")</script>");
                //        return;
                //    }
                //}
                //else if (e.CommandName == "Update_SH")
                //{
                //    if (sbzt == "1")
                //    {
                //        //如果是初审人
                //        if (csr.Equals(_usState.userLoginName))
                //        {
                //            struct_bs_yssb_update.p_id = id;
                //            struct_bs_yssb_update.p_sbzt = "2";
                //            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //            struct_bs_yssb_update.p_czfs = "06";
                //            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                //            return;
                //        }
                //    }
                //    else if (sbzt == "2")
                //    {
                //        //如果是终审人
                //        if (zsr.Equals(_usState.userLoginName))
                //        {
                //            struct_bs_yssb_update.p_sjc = sjc;
                //            if (sjbs.Equals("0"))
                //            {
                //                struct_bs_yssb_update.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                //                struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //                struct_bs_yssb_update.p_czfs = "06";
                //                struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                //                yssb.Update_YSSB_SJBS_ZT(struct_bs_yssb_update);
                //            }
                //            else if (sjbs.Equals("2"))
                //            {
                //                //在这之前，先把原始数据改为历史数据。
                //                struct_bs_yssb_update.p_sjc = sjc;
                //                struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //                struct_bs_yssb_update.p_czfs = "06";
                //                struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                //                yssb.Update_YSSB_SJBS_LSSJ_ZT(struct_bs_yssb_update);

                //                //将副本数据变为最终数据
                //                struct_bs_yssb_update.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                //                struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //                struct_bs_yssb_update.p_czfs = "06";
                //                struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                //                yssb.Update_YSSB_SJBS_FBSJ_ZT(struct_bs_yssb_update);
                //            }
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能审核！\")</script>");
                //            return;
                //        }
                //    }
                //    else if (sbzt == "0")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该预算申报，不能审核！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "3")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不能重复审核！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "4")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，请先编辑信息后再提交才能审核！\")</script>");
                //        return;
                //    }
                //}
                //else if (e.CommandName == "Update_BH")
                //{
                //    if (sbzt == "1")
                //    {
                //        //如果是初审人
                //        if (csr.Equals(_usState.userLoginName))
                //        {
                //            //执行update改变状态（驳回）
                //            struct_bs_yssb_update.p_id = id;
                //            struct_bs_yssb_update.p_sbzt = "4";
                //            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //            struct_bs_yssb_update.p_czfs = "07";
                //            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能驳回！\")</script>");
                //            return;
                //        }
                //    }
                //    else if (sbzt == "2")
                //    {
                //        //如果是终审人
                //        if (zsr.Equals(_usState.userLoginName))
                //        {
                //            //执行update改变状态（驳回）
                //            struct_bs_yssb_update.p_id = id;
                //            struct_bs_yssb_update.p_sbzt = "4";
                //            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                //            struct_bs_yssb_update.p_czfs = "07";
                //            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                //            yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                //        }
                //        else
                //        {
                //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                //            return;
                //        }
                //    }

                //    if (sbzt == "0")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报未提交，不能驳回！\")</script>");

                //        return;
                //    }
                //    else if (sbzt == "3")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不能驳回！\")</script>");
                //        return;
                //    }
                //    else if (sbzt == "4")
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，不可重复驳回！\")</script>");
                //        return;
                //    }
                //}
                //bind_Main();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_ztmc");
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

    }
}