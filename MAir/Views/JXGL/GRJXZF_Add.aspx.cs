using CUST;
using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class GRJXZF_Add : System.Web.UI.Page
    {
        private UserState _us;
        private PCFA pcfa;
        private GRJX grjx;
        protected DataTable dtpcfa;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pcfa = new PCFA(_us);
            grjx = new GRJX(_us);
            dtpcfa = new DataTable();
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            //调用查询评测方案表的存储过程，列出所有评测方案待选
            dtpcfa = pcfa.Select_PCFA().Tables[0];
            //绑定数据源  
            this.dlt_pcfa_add.DataSource = dtpcfa;
            this.dlt_pcfa_add.DataBind();
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            double pcfaqz = 0;//评测方案权重
            string zfabh = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);

            foreach (DataListItem li in dlt_pcfa_add.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                CheckBox cbx_pcfa = (CheckBox)li.FindControl("cbx_pcfa");
                TextBox tbx_pcfaqz = (TextBox)li.FindControl("tbx_pcfaqz");
                if (cbx_pcfa.Checked == true)
                {
                    if ((tbx_pcfaqz.Text.ToString() == ""))//检查选中的CheckBox的权重是否为空
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"权重不能为空！\")</script>");
                        return;
                    }
                    else
                    {
                        pcfaqz = pcfaqz + Convert.ToInt32(tbx_pcfaqz.Text.ToString());//类型转换,选中权重加和
                    }
                }
            }
            if (pcfaqz != 100)//检查权重之和是否为100
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"权重之和不为100！\")</script>");
                return;
            }
            else//当权重符合条件时，执行插入操作
            {
                foreach (DataListItem li in dlt_pcfa_add.Items)
                {
                    CheckBox cbx_pcfa = (CheckBox)li.FindControl("cbx_pcfa");
                    TextBox tbx_pcfaqz = (TextBox)li.FindControl("tbx_pcfaqz");
                    Label lbl_pcfabh = (Label)li.FindControl("lbl_pcfabh");
                    TextBox tbx_pczamc = (TextBox)li.FindControl("tbx_pczamc");

                    if (cbx_pcfa.Checked == true)//前面校验通过，一次插入每一个选中行
                    {
                        Struct_GRJX struct_grjx = new Struct_GRJX();
                        struct_grjx.p_zfabh = zfabh;//总案编号
                        struct_grjx.p_zfamc = tbx_zfamc.Text.Trim();//总案名称，
                        struct_grjx.p_pcfabh = lbl_pcfabh.Text.Trim();//评测方案编号
                        struct_grjx.p_pcfaqz = tbx_pcfaqz.Text.ToString();//评测方案权重
                        grjx.Insert_GRJX_PCFAZA(struct_grjx);
                    }
                }
                Response.Write("<script language='javascript'>alert('添加成功！'); location=' ../JXGL/ZFA.aspx';</script>");
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/ZFA.aspx");
        }

    }
}