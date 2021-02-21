using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sys;
using CUST.Tools;
using CUST.Sys;
using CUST;
using CUST.MKG;


namespace CUST.WKG
{
    public partial class JCJL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        private UserState _usState;
        private JCGL jcjl;
        private Struct_jcgl struct_jcgl;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            jcjl = new JCGL(_usState);
            struct_jcgl = new Struct_jcgl();
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            if (!IsPostBack)
            {
                tbx_jcsjs.Attributes.Add("readonly", "readonly");
                tbx_jcsje.Attributes.Add("readonly", "readonly");
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
            btn_adda.Visible = false;
            //有检查记录添加权限
            if (SysData.HasThisBMQX(_usState.userID, "170102") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_adda.Visible = true; }

        }  
        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();
            int count = 0;
            //查询权限
            //字典项的绑定
            //被检单位
            ddlt_bjdw.DataTextField = "mc";
            ddlt_bjdw.DataValueField = "bm";
            ddlt_bjdw.DataSource = dt_bmdm;
            ddlt_bjdw.DataBind();
            if (count != 0)
            {
                ddlt_bjdw.Items.Insert(0, new ListItem("请选择", "-2"));
            }
            if (count == 0)
            {
                ddlt_bjdw.Items.Insert(0, new ListItem("全部", "-1"));
            }
            //检查单
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataBind();
            ddlt_jcd.Items.Insert(0, new ListItem("全部", "-1"));

            //检查项目
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            DataTable dt_jcxm = new DataTable();
            dt_jcxm = jcjl.Select_JCRW(tbdw);
            ddlt_jcxm.DataSource = dt_jcxm;
            ddlt_jcxm.DataTextField = "jcxm";
            ddlt_jcxm.DataValueField = "jcxm";
            ddlt_jcxm.DataBind();
            ddlt_jcxm.Items.Insert(0, new ListItem("全部", "-1"));

            //检查结果
            ddlt_jcjg.DataTextField = "mc";
            ddlt_jcjg.DataValueField = "bm";
            ddlt_jcjg.DataSource = SysData.JCJG().Copy();
            ddlt_jcjg.DataBind();
            ddlt_jcjg.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void ddlt_jcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            string jcxm = ddlt_jcxm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcjl.Select_JCRW(tbdw);
            ddlt_jcxm.DataSource = dt;
            ddlt_jcxm.DataTextField = "jcxm";
            ddlt_jcxm.DataValueField = "jcxm";
            ddlt_jcxm.DataBind();

        }
       private void bind_Main()
        {

            if (tbx_jcsjs.Text == "")
            {
                struct_jcgl.jcsjs = Convert.ToDateTime("0001-1-1 00:00:00");                
            }
            else
            {
                struct_jcgl.jcsjs = DateTime.Parse(tbx_jcsjs.Text.Trim().ToString());//开始日期       
            }
            if (tbx_jcsje.Text == "")
            {
                struct_jcgl.jcsje = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_jcgl.jcsje = DateTime.Parse(tbx_jcsje.Text.Trim().ToString());//开始日期               
            }
            struct_jcgl.bjdw = ddlt_bjdw.SelectedValue.ToString();
            struct_jcgl.jcd = ddlt_jcd.SelectedValue.ToString();
            struct_jcgl.jcxm = ddlt_jcxm.SelectedValue.ToString();
            struct_jcgl.jcjg = ddlt_jcjg.SelectedValue.ToString();
            struct_jcgl.p_userid = _usState.userID;
            int count = jcjl.Select_KG_JCGL_Count(struct_jcgl);
            pg_fy.TotalRecord = count;
            struct_jcgl.p_currentpage = pg_fy.CurrentPage;
            struct_jcgl.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = jcjl.Select_JCJL(struct_jcgl).Tables[0];
            dt.Columns.Add("bjdwmc");
            dt.Columns.Add("jcjgmc");
            dt.Columns.Add("jcsjmc");
            dt.Columns.Add("jcdmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjdwmc"] = SysData.BMByKey(dr["bjdw"].ToString()).mc;                       //被检单位
                dr["jcjgmc"] = SysData.JCJGByKey(dr["jcjg"].ToString()).mc;                     //检查结果
                dr["jcsjmc"] = DateTime.Parse(dr["jcsj"].ToString()).ToString("yyyy-MM-dd");    //检查时间
                dr["jcdmc"] = SysData.TBDWByKey(dr["jcd"].ToString()).mc;                       //检查单

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
            string rwid = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                if (SysData.HasThisBMQX(_usState.userID, "170203"))
                {
                    Server.Transfer("JCJL_Edit.aspx?rwid=" + rwid);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能编辑！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_jcgl = new Struct_jcgl();
                if (SysData.HasThisBMQX(_usState.userID, "170104"))
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：记录管理->检查记录管理->删除  描述：检查记录：[" + rwid + "]";
                    jcjl.Delete_JCJL(rwid);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能删除！\")</script>");
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有相应权限，请联系管理员！\")</script>");
                return;
            }
           bind_Main();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            if (ddlt_bjdw.SelectedValue == "-2")
            {
                Response.Write("<script>alert('请选择部门！')</script>");
                return;
            }
            bind_Main();
        }
        protected void btn_adda_Click(object sender, EventArgs e)
        {
            Response.Redirect("JCJL.Add.aspx");
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
                foreach (RepeaterItem li in Repeater1.Items)//首先遍历查询出的检查结果，合格为绿，不合格为红
                {
                    Label lbl_jcjg = (Label)li.FindControl("Label5");
                    if (lbl_jcjg.Text == "合格")//3
                    {
                        lbl_jcjg.ForeColor = System.Drawing.Color.Green;
                    }
                    if (lbl_jcjg.Text == "不合格")//4
                    {
                        lbl_jcjg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 删除按钮
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "170104") == true)
                //if (SysData.HasThisQX("170104", _usState.userID, "01"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                //if (SysData.HasThisQX("170104", _usState.userID, "02"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("170104", _usState.userID, "03"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("170104", _usState.userID, "04"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("170204", _usState.userID, "05"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                #endregion
                #region 修改按钮
                ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "170103") == true)
                //if (SysData.HasThisQX("170103", _usState.userID, "01"))
                {
                    //修改
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                //if (SysData.HasThisQX("170103", _usState.userID, "02"))
                //{
                //    //修改
                //    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                //}
                //if (SysData.HasThisQX("170103", _usState.userID, "03"))
                //{
                //    //修改
                //    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                //}
                //if (SysData.HasThisQX("170103", _usState.userID, "04"))
                //{
                //    //修改
                //    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                //}
                //if (SysData.HasThisQX("170103", _usState.userID, "05"))
                //{
                //    //修改
                //    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                //}
                #endregion
            }
        }
    }
}
