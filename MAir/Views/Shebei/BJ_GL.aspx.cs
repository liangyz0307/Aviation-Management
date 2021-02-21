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
    public partial class BJ_GL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private BJ bj;
        private Struct_BJ struct_bj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            //cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_BJ;
            //psize = _usState.C_SB_BJ;

            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
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

            if (SysData.HasThisBMQX(_usState.userID, "140502") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {


            //绑定备件分类 ddlt_bjfl
            ddlt_bjfl.DataTextField = "mc";
            ddlt_bjfl.DataValueField = "bm";
            ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl.DataBind();
            ddlt_bjfl.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定适用 ddlt_sy
            ddlt_sy.DataTextField = "mc";
            ddlt_sy.DataValueField = "bm";
            ddlt_sy.DataSource = SysData.BJSY().Copy();
            ddlt_sy.DataBind();
            ddlt_sy.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            string sbbh = tbx_sbbh.Text.Trim().ToString().Trim();
            string bjmc = tbx_sbmc.Text.ToString().Trim();
            string sbxh = tbx_sbxh.Text.Trim().ToString().Trim();
            string bjfl = ddlt_bjfl.SelectedValue.ToString();
            string sy = ddlt_sy.SelectedValue.ToString();
            

            struct_bj.p_bjbh = sbbh;
            struct_bj.p_bjmc = bjmc;
            struct_bj.p_bjfl = bjfl;
            struct_bj.p_sy = sy;
            struct_bj.p_sbxh = sbxh;
            struct_bj.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态
            struct_bj.p_zxdm = _usState.userSS;
            struct_bj.p_userid = _usState.userID;

            int count = bj.Select_BJ_Count(struct_bj);
            pg_fy.TotalRecord = count;
            struct_bj.p_currentpage = pg_fy.CurrentPage;
            struct_bj.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = bj.Select_BJ_Pro(struct_bj).Tables[0];

            dt.Columns.Add("bm");
            dt.Columns.Add("bjflmc");
            dt.Columns.Add("symc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjflmc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;//备件分类
                dr["symc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;//备件分类
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
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
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/BJ_Add.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[9];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string zt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识
            string bjbh = content[8];//数据标识
            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140503"))
                    {
                        Server.Transfer("BJ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("BJ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_bj = new Struct_BJ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理系统->备件管理->备件    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Delete_BJ(sjc, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140504"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理系统->备件管理->备件    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Delete_BJ(sjc, p_czfs, p_czxx);
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
                struct_bj = new Struct_BJ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_bj.p_id = id;
                        struct_bj.p_zt = "1";
                        struct_bj.p_bhyy = HF_yc.Value;
                        struct_bj.p_czfs = "05";
                        struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJZT(struct_bj);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1405", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_bj.p_id = id;
                        struct_bj.p_zt = "2";
                        struct_bj.p_bhyy = HF_yc.Value;
                        struct_bj.p_czfs = "06";
                        struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJZT(struct_bj);
                        SysData.Delete_TSR(csr, "14", "1405", id);
                        SysData.Insert_TSR(zsr, "14", "1405", id);
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
                        struct_bj.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_bj.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bj.p_bhyy = HF_yc.Value;
                            struct_bj.p_czfs = "06";
                            struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJ_SJBS_ZT(struct_bj);
                            SysData.Delete_TSR(zsr, "14", "1405", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_bj.p_sjc = sjc;
                            struct_bj.p_bhyy = HF_yc.Value;
                            struct_bj.p_czfs = "06";
                            struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJ_SJBS_LSSJ_ZT(struct_bj);

                            //将副本数据变为最终数据
                            struct_bj.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bj.p_bhyy = HF_yc.Value;
                            struct_bj.p_czfs = "06";
                            struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJ_SJBS_FBSJ_ZT(struct_bj);
                            SysData.Delete_TSR(zsr, "14", "1405", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该备件信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_bj.p_id = id;
                        struct_bj.p_zt = "4";
                        struct_bj.p_bhyy = HF_yc.Value;
                        struct_bj.p_czfs = "07";
                        struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJZT(struct_bj);
                        SysData.Delete_TSR(csr, "14", "1405", id);
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
                        struct_bj.p_id = id;
                        struct_bj.p_zt = "4";
                        struct_bj.p_bhyy = HF_yc.Value;
                        struct_bj.p_czfs = "07";
                        struct_bj.p_czxx = "位置：设备管理系统->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJZT(struct_bj);
                        SysData.Delete_TSR(zsr, "14", "1405", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }

           
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
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
            dt_dc = bj.Select_BJ_DC(_usState.userID);
            //dt_dc.Columns.Add("yjsl_new");//原机数量
            //dt_dc.Columns.Add("xybjsl_new");//现有备件
           foreach (DataRow dr in dt_dc.Rows)
            {
                //dr["bmdm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                //dr["gwdm"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                //dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                //dr["xldm"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                //dr["gzddm"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地
                //dr["htgx"] = SysData.HTGXByKey(dr["htgx"].ToString()).mc;//合同关系
                //dr["htlxdm"] = SysData.HTLXByKey(dr["htlxdm"].ToString()).mc;//合同类型
                //dr["mzdm"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;//名族
                //dr["xbdm"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                //dr["zzmmdm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌代码

                //DateTime dt_csrq = new DateTime();
                //dt_csrq = Convert.ToDateTime(dr["yjsl"].ToString());
                //// dr["rq"]= dt_csrq.ToShortDateString().ToString();
                //dr["yjsl_new"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);

                //DateTime dt2 = new DateTime();
                //dt_csrq = Convert.ToDateTime(dr["xybjsl"].ToString());
                //// dr["rq"]= dt_csrq.ToShortDateString().ToString();
                //dr["xybjsl_new"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            dt_dc.Columns.Remove("BJSBH");
            dt_dc.Columns.Remove("YJSL");
            dt_dc.Columns.Remove("XYBJSL");
            //dt_dc.Columns.Remove("SJSSBM");
            //dt_dc.Columns.Remove("ZPLJ");
            //dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "备件编号	 12位（10位原设备编码 +2位流水号）";
            dr_Insert[1] = "备件名称";
            dr_Insert[2] = "设备型号 ";
            dr_Insert[3] = "备件分类";
            dr_Insert[4] = "板件中文名称";
            dr_Insert[5] = "内含组件";
            dr_Insert[6] = "内含组件名称";
            dr_Insert[7] = "英文名称";
            dr_Insert[8] = "适用 字典表（0：航向1：下滑2：VOR  3：12单元双频航向天线阵4：下滑M天线阵 ）";
            dr_Insert[9] = "存放位置";
            dr_Insert[10] = "支线代码";
            dr_Insert[11] = "备件状态";
            dr_Insert[12] = "数据所属部门";
            dr_Insert[13] = "数据标识";


           


            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "备件管理_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/BJ.xls");
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