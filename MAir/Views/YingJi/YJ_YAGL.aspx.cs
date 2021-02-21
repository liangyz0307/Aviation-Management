using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class YJ_YAGL : System.Web.UI.Page
    {
        private UserState _usState;
        private YAGL yagl;
        private Struct_YAGL struct_yagl;//结构体
        public int cpage;
        public int psize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
           
            yagl = new YAGL (_usState);
            if (!IsPostBack)
            {
                Bind();
                show();
                bind_Main();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "180102") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_Main()
        {
               struct_yagl.p_mc = ddlt_mc.SelectedValue.Trim().ToString();//名称
               struct_yagl.p_dq = ddlt_dq.SelectedValue.Trim().ToString();//地区
               struct_yagl.p_zy = ddlt_zy.SelectedValue.Trim().ToString(); //专业
               struct_yagl.p_zt = ddlt_zt.SelectedValue.Trim().ToString(); //状态
               struct_yagl.p_currentpage = pg_fy.CurrentPage;
               struct_yagl.p_pagesize = pg_fy.NumPerPage;
               struct_yagl.p_userid = _usState.userID;
               int count =yagl.Select_Yj_Yagl_Count_Proc(struct_yagl);
               pg_fy.TotalRecord = count;
               DataTable dt = yagl.Select_YJ_YAGL_Proc(struct_yagl);
               dt.Columns.Add("zxdm");
               dt.Columns.Add("zylx");
               dt.Columns.Add("ztmc");
             
         
            foreach (DataRow dr in dt.Rows)
           {
               dr["zxdm"] = SysData.ZXDMByKey(dr["dq"].ToString()).mc;
               dr["zylx"] =SysData.ZYLXByKey(dr["zy"].ToString()).mc;
               dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
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
            Response.Redirect("YAGL_Add.aspx");
        }
     

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Bind()
        {
            //绑定名称
            DataTable dt_mc = yagl.Select_Yj_Yagl_Mc_Proc().Copy();
            ddlt_mc.DataTextField = "mc";
            ddlt_mc.DataSource = dt_mc;
            ddlt_mc.DataBind();
            ddlt_mc.Items.Insert(0, new ListItem("全部","-1"));
            //绑定地区
            DataTable dt_dq = SysData.ZXDM().Copy();
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataSource = dt_dq;
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定专业
            DataTable dt_zy = SysData.ZYLX().Copy();
            ddlt_zy.DataTextField = "mc";
            ddlt_zy.DataValueField = "bm";
            ddlt_zy.DataSource = dt_zy;
            ddlt_zy.DataBind();
            ddlt_zy.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }
        #region 截取字符串(如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串)
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">规定该字符串显示的长度</param>
        /// <returns>结果字符串</returns>
        public string GetCut(string str, int len)
        {
            //如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";
               
            }
            else
            {
                return str;
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "180103"))
                    {
                        Server.Transfer("YAGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("YAGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_yagl = new Struct_YAGL();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：应急管理->应急管理管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        yagl.Delete_Yj_Yagl_Proc(sjc, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "180104"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：应急管理->应急管理管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        yagl.Delete_Yj_Yagl_Proc(sjc, p_czfs, p_czxx);
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
                struct_yagl = new Struct_YAGL();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_yagl.p_id = id;
                        struct_yagl.p_zt = "1";
                        struct_yagl.p_bhyy = HF_yc.Value;
                        struct_yagl.p_czfs = "05";
                        struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yagl.Update_YAGLZT(struct_yagl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_yagl.p_id = id;
                        struct_yagl.p_zt = "2";
                        struct_yagl.p_bhyy = HF_yc.Value;
                        struct_yagl.p_czfs = "06";
                        struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yagl.Update_YAGLZT(struct_yagl);
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
                        struct_yagl.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_yagl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_yagl.p_bhyy = HF_yc.Value;
                            struct_yagl.p_czfs = "06";
                            struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                           yagl.Update_YAGL_SJBS_ZT(struct_yagl);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_yagl.p_sjc = sjc;
                            struct_yagl.p_bhyy = HF_yc.Value;
                            struct_yagl.p_czfs = "06";
                            struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                         yagl.Update_YAGL_SJBS_LSSJ_ZT(struct_yagl);

                            //将副本数据变为最终数据
                            struct_yagl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_yagl.p_bhyy = HF_yc.Value;
                            struct_yagl.p_czfs = "06";
                            struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                           yagl.Update_YAGL_SJBS_FBSJ_ZT(struct_yagl);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该预案信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_yagl.p_id = id;
                        struct_yagl.p_zt = "4";
                        struct_yagl.p_bhyy = HF_yc.Value;
                        struct_yagl.p_czfs = "07";
                        struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yagl.Update_YAGLZT(struct_yagl);
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
                        struct_yagl.p_id = id;
                        struct_yagl.p_zt = "4";
                        struct_yagl.p_bhyy = HF_yc.Value;
                        struct_yagl.p_czfs = "07";
                        struct_yagl.p_czxx = "位置：应急管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                       yagl.Update_YAGLZT(struct_yagl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
            Bind();
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
    }
}