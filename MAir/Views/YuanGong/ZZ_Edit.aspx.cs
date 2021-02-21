using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class ZZ_Edit : System.Web.UI.Page

    {

        private UserState _usState;
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        public int cpage3;
        public int psize3;
        private string ygbh;
        private string bmdm;
        private YGZZ ygzz;
        private Struct_YGZZ struct_ygzz;
        private DataTable dt_detail;
       public string  filepath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygzz = new YGZZ(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["ygbh"].ToString();
               
                bind_Main();
                show();

            }
        }
        public void show()
        {
            Boolean flag_add_yy = false;
            Boolean flag_add_zz = false;
            Boolean flag_add_qz = false;
            btn_add_yy.Visible = false;
            btn_add_zz.Visible = false;
            btn_add_qz.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "110202") == true)
            {
                flag_add_yy = true;
                flag_add_zz = true;
                flag_add_qz = true;
            }
            if (flag_add_yy) { btn_add_yy.Visible = true; }
            if (flag_add_zz) { btn_add_zz.Visible = true; }
            if (flag_add_qz) { btn_add_qz.Visible = true; }
        }
        private void bind_Main()
        {

            #region 英语列表

            DateTime dt = new DateTime();
            DataTable dt_yy = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(), _usState.userID).Tables[0];
            dt_yy.Columns.Add("ztmc");
            dt_yy.Columns.Add("yydjmc");
            dt_yy.Columns.Add("yyyxqmc", typeof(string));
            foreach (DataRow dr in dt_yy.Rows)
            {
               
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["yydjmc"] = SysData.YYDJLBByKey(dr["yydj"].ToString()).mc;//英语等级
                if (dr["yyyxq"].ToString() == dt.ToString())
                {
                    dr["yyyxqmc"] = "";
                }
                else {
                    DateTime dt_sj = Convert.ToDateTime(dr["yyyxq"].ToString().Trim());
                    dr["yyyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_sj);
                }
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt_yy.DefaultView;
            this.Repeater1.DataBind();
            #endregion
            #region 执照列表


            DataTable dt_zz = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(), _usState.userID).Tables[1];
            dt_zz.Columns.Add("ztmc");
            dt_zz.Columns.Add("bfrq", typeof(string));
            foreach (DataRow dr in dt_zz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                if (dr["zzbfrq"].ToString() == dt.ToString())
                {
                    dr["bfrq"] = "";
                }
                else {
                    DateTime dt_bfsj = Convert.ToDateTime(dr["zzbfrq"].ToString().Trim());
                    dr["bfrq"] = string.Format("{0:yyyy-MM-dd}", dt_bfsj);
                    //dr["bfrq"] = dr["zzbfrq"];
                }
            }


            //绑定分页数据源  
            this.Repeater2.DataSource = dt_zz.DefaultView;
            this.Repeater2.DataBind();
            #endregion
            #region 签注列表


            DataTable dt_qz = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(), _usState.userID).Tables[2];
            dt_qz.Columns.Add("ztmc");
            dt_qz.Columns.Add("qzzymc");
            dt_qz.Columns.Add("qzlbmc");
            dt_qz.Columns.Add("qzxmc");
            dt_qz.Columns.Add("tjdjmc");
            dt_qz.Columns.Add("qzyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzyxqmc", typeof(string));
            dt_qz.Columns.Add("tjyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzxmc");
            dt_qz.Columns.Add("ydqzmc");
          
            foreach (DataRow dr in dt_qz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["qzzymc"] = SysData.QZZYByKey(dr["qzzy"].ToString()).mc;//签注专业
                dr["qzlbmc"] = SysData.ZZQZLBDMByKey(dr["qzlb"].ToString()).mc;//签注类别
                dr["qzxmc"] = SysData.ZZQZXDMByKey(dr["qzx"].ToString()).mc;//签注项
                dr["tjdjmc"] = SysData.TJDJBByKey(dr["tjdj"].ToString()).mc;//体检等级
                dr["ydqzxmc"] = SysData.ZZQZXDMByKey(dr["ydqzx"].ToString()).mc;//异地签注项
                dr["ydqzmc"] = SysData.YDQZByKey(dr["ydqz"].ToString()).mc;//异地签注项
                if (dr["qzyxq"].ToString() == dt.ToString())
                {
                    dr["qzyxqmc"] = "";
                }
                else {
                    DateTime dt_qzsj = Convert.ToDateTime(dr["qzyxq"].ToString().Trim());
                    dr["qzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_qzsj);
                   // dr["qzyxqmc"] = dr["qzyxq"].ToString();
                }
                if (dr["ydqzyxq"].ToString() == dt.ToString())
                {
                    dr["ydqzyxqmc"] = "";
                }
                else {
                    DateTime dt_ydsj = Convert.ToDateTime(dr["ydqzyxq"].ToString().Trim());
                    dr["ydqzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_ydsj);
                   // dr["ydqzyxqmc"] = dr["ydqzyxq"].ToString();
                }
                if (dr["tjyxq"].ToString() == dt.ToString())
                {
                    dr["tjyxqmc"] = "";
                }
                else {
                    DateTime dt_tjsj = Convert.ToDateTime(dr["tjyxq"].ToString().Trim());
                    dr["tjyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_tjsj);
                   // dr["tjyxqmc"] = dr["tjyxq"].ToString();
                }
            }


            //绑定分页数据源  
            this.Repeater3.DataSource = dt_qz.DefaultView;
            this.Repeater3.DataBind();
            #endregion
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZZGL.aspx");
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
                // ygbh = Request.Params["ygbh"].ToString();
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110203"))
                    {
                        Server.Transfer("ZZ_Edit_YY.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                        Server.Transfer("ZZ_Edit_YY.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工英语资质->员工英语资质管理->英语资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工英语资质->员工英语资质管理->英语资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "1";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "05";
                        struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1102", Convert.ToInt32(id));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "2";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "06";
                        struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                        SysData.Delete_TSR(csr, "11", "1102", Convert.ToInt32(id));
                        SysData.Insert_TSR(zsr, "11", "1102", Convert.ToInt32(id));
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
                        struct_ygzz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_ZT(struct_ygzz);
                            SysData.Delete_TSR(zsr, "11", "1102", Convert.ToInt32(id));
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ygzz.p_sjc = sjc;
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                            //将副本数据变为最终数据
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_FBSJ_ZT(struct_ygzz);
                            SysData.Delete_TSR(zsr, "11", "1102", Convert.ToInt32(id));
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工英语资质信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                        SysData.Delete_TSR(csr, "11", "1102", Convert.ToInt32(id));
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                        SysData.Delete_TSR(zsr, "11", "1102", Convert.ToInt32(id));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工英语资质信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx1");
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
        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater2.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx2");
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

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater3.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx3");
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


        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                // ygbh = Request.Params["ygbh"].ToString();
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110203"))
                    {
                        Server.Transfer("ZZ_Edit_ZZ.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                        Server.Transfer("ZZ_Edit_ZZ.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工执照资质->员工执照资质管理->执照资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工执照资质->员工执照资质管理->执照资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "1";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "05";
                        struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "2";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "06";
                        struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
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
                        struct_ygzz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_ZT(struct_ygzz);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ygzz.p_sjc = sjc;
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                            //将副本数据变为最终数据
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_FBSJ_ZT(struct_ygzz);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工执照资质信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工执照资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工执照资质信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

       
        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                // ygbh = Request.Params["ygbh"].ToString();
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110203"))
                    {
                        Server.Transfer("ZZ_Edit_QZ.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                        Server.Transfer("ZZ_Edit_QZ.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh=" + ygbh + "&sjc=" + sjc);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工签注资质->员工签注资质管理->签注资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工签注资质->员工签注资质管理->签注资质    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Delete_YGZZ_byID(id, p_czfs, p_czxx);
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
                struct_ygzz = new Struct_YGZZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "1";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "05";
                        struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "2";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "06";
                        struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
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
                        struct_ygzz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工英语资质->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_ZT(struct_ygzz);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ygzz.p_sjc = sjc;
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                            //将副本数据变为最终数据
                            struct_ygzz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygzz.p_bhyy = HF_yc.Value;
                            struct_ygzz.p_czfs = "06";
                            struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygzz.Update_YGZZ_SJBS_FBSJ_ZT(struct_ygzz);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工签注资质信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
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
                        struct_ygzz.p_id = id;
                        struct_ygzz.p_zt = "4";
                        struct_ygzz.p_bhyy = HF_yc.Value;
                        struct_ygzz.p_czfs = "07";
                        struct_ygzz.p_czxx = "位置：员工签注资质->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygzz.Update_ygzz_ZT(struct_ygzz.p_id, struct_ygzz.p_zt, struct_ygzz.p_bhyy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工签注资质信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void btn_add_yy_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZZ_Add_YY.aspx?ygbh=" + Request.Params["ygbh"].ToString());
        }

        protected void btn_add_zz_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZZ_Add_ZZ.aspx?ygbh=" + Request.Params["ygbh"].ToString());
        }

        protected void btn_add_qz_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZZ_Add_QZ.aspx?ygbh=" + Request.Params["ygbh"].ToString());
        }

       
    }
}