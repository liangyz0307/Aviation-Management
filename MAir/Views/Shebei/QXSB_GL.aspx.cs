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
    public partial class QXSB_GL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private QXSB qxsb;
        private Struct_QXSB struct_qxsb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
           
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_SB_QX;
            psize = _usState.C_SB_QX;

            qxsb = new QXSB(_usState);
            struct_qxsb = new Struct_QXSB();
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

            if (SysData.HasThisBMQX(_usState.userID, "140302") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {

            //运行情况
            ddlt_yxqk.DataTextField = "mc";
            ddlt_yxqk.DataValueField = "bm";
            ddlt_yxqk.DataSource = SysData.YXQK().Copy();
            ddlt_yxqk.DataBind();
            ddlt_yxqk.Items.Insert(0, new ListItem("全部", "-1"));

            //设备状态 
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));

            //设备用途
            ddlt_sbyt.DataTextField = "mc";
            ddlt_sbyt.DataValueField = "bm";
            ddlt_sbyt.DataSource = SysData.SBYT().Copy();
            ddlt_sbyt.DataBind();
            ddlt_sbyt.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定所属支线 
            ddlt_sszx.DataTextField = "mc";
            ddlt_sszx.DataValueField = "bm";
            ddlt_sszx.DataSource = SysData.ZXDM().Copy();
            ddlt_sszx.DataBind();
            ddlt_sszx.Items.Insert(0, new ListItem("全部", "-1"));
            //检定方式 
            ddlt_jdfs.DataTextField = "mc";
            ddlt_jdfs.DataValueField = "bm";
            ddlt_jdfs.DataSource = SysData.JDFS().Copy();
            ddlt_jdfs.DataBind();
            ddlt_jdfs.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_qxsb.p_ccbh = tbx_ccbh.Text.Trim().ToString();
           // struct_qxsb.p_tcrq = tbx_tcrq.Text.Trim().ToString();
           // struct_qxsb.p_jgrq = tbx_jgrq.Text.Trim().ToString();
            struct_qxsb.p_yxqk = ddlt_yxqk.SelectedValue.ToString();
            struct_qxsb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
            struct_qxsb.p_sbyt = ddlt_sbyt.SelectedValue.ToString();
            struct_qxsb.p_sszx = ddlt_sszx.SelectedValue.ToString();
            struct_qxsb.p_jdfs = ddlt_jdfs.SelectedValue.ToString();
            struct_qxsb.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_qxsb.p_userid = _usState.userID;
            int count = qxsb.Select_QXSB_Count(struct_qxsb);
            pg_fy.TotalRecord = count;
            struct_qxsb.p_currentpage = pg_fy.CurrentPage;
            struct_qxsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = qxsb.Select_QXSB(struct_qxsb).Tables[0];
            dt.Columns.Add("yxqkmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("sbytmc");
            dt.Columns.Add("sszxmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["yxqkmc"] = SysData.SBYTByKey(dr["yxqk"].ToString()).mc;
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["sbytmc"] = SysData.SBYTByKey(dr["sbyt"].ToString()).mc;
                dr["sszxmc"] = SysData.SBZLByKey(dr["sszx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
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

            Response.Redirect("../SheBei/QXSB_Add.aspx");
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备管理信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140303"))
                    {
                        Server.Transfer("QXSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("QXSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_qxsb = new Struct_QXSB();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->气象设备   描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Delete_QXSB(Convert.ToString(id), p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备管理信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140304"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->气象设备    描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Delete_QXSB(Convert.ToString(id), p_czfs, p_czxx);
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
                struct_qxsb = new Struct_QXSB();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_qxsb.p_id = Convert.ToString(id);
                        struct_qxsb.p_zt = "1";
                        struct_qxsb.p_bhyy = HF_yc.Value;
                        struct_qxsb.p_czfs = "05";
                        struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Update_QXSBZT(struct_qxsb);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1403", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_qxsb.p_id = Convert.ToString(id);
                        struct_qxsb.p_zt = "2";
                        struct_qxsb.p_bhyy = HF_yc.Value;
                        struct_qxsb.p_czfs = "06";
                        struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Update_QXSBZT(struct_qxsb);
                        SysData.Delete_TSR(csr, "14", "1403", id);
                        SysData.Insert_TSR(zsr, "14", "1403", id);
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
                        struct_qxsb.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_qxsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_qxsb.p_bhyy = HF_yc.Value;
                            struct_qxsb.p_czfs = "06";
                            struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            qxsb.Update_QXSB_SJBS_ZT(struct_qxsb);
                            SysData.Delete_TSR(zsr, "14", "1403", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_qxsb.p_sjc = sjc;
                            struct_qxsb.p_bhyy = HF_yc.Value;
                            struct_qxsb.p_czfs = "06";
                            struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            qxsb.Update_QXSB_SJBS_LSSJ_ZT(struct_qxsb);

                            //将副本数据变为最终数据
                            struct_qxsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_qxsb.p_bhyy = HF_yc.Value;
                            struct_qxsb.p_czfs = "06";
                            struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            qxsb.Update_QXSB_SJBS_FBSJ_ZT(struct_qxsb);
                            SysData.Delete_TSR(zsr, "14", "1403", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该设备管理信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_qxsb.p_id = Convert.ToString(id);
                        struct_qxsb.p_zt = "4";
                        struct_qxsb.p_bhyy = HF_yc.Value;
                        struct_qxsb.p_czfs = "07";
                        struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Update_QXSBZT(struct_qxsb);
                        SysData.Delete_TSR(csr, "14", "1403", id);
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
                        struct_qxsb.p_id = Convert.ToString(id);
                        struct_qxsb.p_zt = "4";
                        struct_qxsb.p_bhyy = HF_yc.Value;
                        struct_qxsb.p_czfs = "07";
                        struct_qxsb.p_czxx = "位置：气象设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        qxsb.Update_QXSBZT(struct_qxsb);
                        SysData.Delete_TSR(zsr, "14", "1403", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该气象设备管理信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
           
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt");
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
            dt_dc = qxsb.Select_QXSB_DC(_usState.userID);
            //dt_dc.Columns.Add("scsj_new");//上传时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["sbmc"] = SysData.BMByKey(dr["sbmc"].ToString()).mc;
                dr["xh"] = SysData.BMByKey(dr["xh"].ToString()).mc;
                dr["zzcj"] = SysData.BMByKey(dr["zzcj"].ToString()).mc;
                dr["ccbh"] = SysData.BMByKey(dr["ccbh"].ToString()).mc;
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
                //dt_csrq = Convert.ToDateTime(dr["scsj"].ToString());
                //// dr["rq"]= dt_csrq.ToShortDateString().ToString();
                //dr["scsj_new"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            //dt_dc.Columns.Remove("SJSSBM");
            //dt_dc.Columns.Remove("ZPLJ");
            //dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "设备名称";
            dr_Insert[1] = "型号/规格";
            dr_Insert[2] = "制造厂家";
            dr_Insert[3] = "出厂编号";
            dr_Insert[4] = "投产日期";
            dr_Insert[5] = "竣工日期";
            dr_Insert[6] = "启用时间";
            dr_Insert[7] = "运行情况";
            dr_Insert[8] = "设备状态";
            dr_Insert[9] = "设备用途";
            dr_Insert[10] = "所属支线";
            dr_Insert[11] = "安装位置";
            dr_Insert[12] = "检定日期";
            dr_Insert[13] = "检定有效期";
            dr_Insert[14] = "检定证书编号";
            dr_Insert[15] = "上传传感器检定证书";
            dr_Insert[16] = "检定预算";
            dr_Insert[17] = "检定方式";
            dr_Insert[18] = "检定单位";
            dr_Insert[19] = "检定结论";
            dr_Insert[20] = "防雷检测日期";
            dr_Insert[21] = "防雷检测有效期";
            dr_Insert[22] = "电阻实测值";
            dr_Insert[23] = "设备故障履历";
            dr_Insert[24] = "备注";
            dr_Insert[25] = "id";
            dr_Insert[26] = "设备编号";
            

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "气象设备_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/QXSB.xls");
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