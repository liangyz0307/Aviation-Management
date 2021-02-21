using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class LL_Edit : System.Web.UI.Page

    {

        private UserState _usState;
        public int cpage;
        public int psize;
        private string ygbh;
        //private string bmdm;
        private YGLL ygll;
        private Struct_YGLL struct_ygll;
        //private DataTable dt_detail;
       public string  filepath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            struct_ygll = new Struct_YGLL();
            ygll = new YGLL(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["ygbh"].ToString();
                //bmdm = Request.Params["bmdm"].ToString();
                bind_Main();
                show();

            }
        }
        public void show()
        {
            Boolean flag_add = false;
            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "110302") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }
        }
        private void bind_Main()
        
        
        {


            DataTable dt = ygll.Select_YGLL_BYBH(Request.Params["ygbh"].ToString(), _usState.userID);
            dt.Columns.Add("bm");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
               
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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
            Response.Redirect("LLGL.aspx");
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110303"))
                    {
                        Server.Transfer("LL_Edit_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&ygbh="+ygbh + "&sjc=" + sjc);
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
                        Server.Transfer("LL_Edit_Edit.aspx?id=" + id + "&sjbs=" + sjbs +"&ygbh="+ygbh +"&sjc=" +sjc);
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
                struct_ygll = new Struct_YGLL();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工履历->员工履历管理->履历    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Delete_YGLL_byID(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110304"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工履历->员工履历管理->履历    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Delete_YGLL_byID(id, p_czfs, p_czxx);
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
                struct_ygll = new Struct_YGLL();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ygll.p_id = id;
                        struct_ygll.p_zt = "1";
                        struct_ygll.p_bhyy = HF_yc.Value;
                        struct_ygll.p_czfs = "05";
                        struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Update_ygll_ZT(struct_ygll.p_id, struct_ygll.p_zt, struct_ygll.p_bhyy);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1103", Convert.ToInt32(id));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_ygll.p_id = id;
                        struct_ygll.p_zt = "2";
                        struct_ygll.p_bhyy = HF_yc.Value;
                        struct_ygll.p_czfs = "06";
                        struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Update_ygll_ZT(struct_ygll.p_id, struct_ygll.p_zt, struct_ygll.p_bhyy);
                        SysData.Delete_TSR(csr, "11", "1103", Convert.ToInt32(id));
                        SysData.Insert_TSR(zsr, "11", "1103", Convert.ToInt32(id));
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
                        struct_ygll.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ygll.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygll.p_bhyy = HF_yc.Value;
                            struct_ygll.p_czfs = "06";
                            struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygll.Update_YGLL_SJBS_ZT(struct_ygll);
                            SysData.Delete_TSR(zsr, "11", "1103", Convert.ToInt32(id));
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ygll.p_sjc = sjc;
                            struct_ygll.p_bhyy = HF_yc.Value;
                            struct_ygll.p_czfs = "06";
                            struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygll.Update_YGLL_SJBS_LSSJ_ZT(struct_ygll);

                            //将副本数据变为最终数据
                            struct_ygll.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygll.p_bhyy = HF_yc.Value;
                            struct_ygll.p_czfs = "06";
                            struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygll.Update_YGLL_SJBS_FBSJ_ZT(struct_ygll);
                            SysData.Delete_TSR(zsr, "11", "1103", Convert.ToInt32(id));
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工履历信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_ygll.p_id = id;
                        struct_ygll.p_zt = "4";
                        struct_ygll.p_bhyy = HF_yc.Value;
                        struct_ygll.p_czfs = "07";
                        struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Update_ygll_ZT(struct_ygll.p_id, struct_ygll.p_zt, struct_ygll.p_bhyy);
                        SysData.Delete_TSR(csr, "11", "1103", Convert.ToInt32(id));
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
                        struct_ygll.p_id = id;
                        struct_ygll.p_zt = "4";
                        struct_ygll.p_bhyy = HF_yc.Value;
                        struct_ygll.p_czfs = "07";
                        struct_ygll.p_czxx = "位置：员工履历->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygll.Update_ygll_ZT(struct_ygll.p_id, struct_ygll.p_zt, struct_ygll.p_bhyy);
                        SysData.Delete_TSR(zsr, "11", "1103", Convert.ToInt32(id));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工履历信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //Server.Transfer("LL_Add.aspx" );
            //  Response.Redirect("LL_Add.aspx", false);
            Server.Transfer("LL_Add.aspx?ygbh=" + Request.Params["ygbh"].ToString());
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
    }
}