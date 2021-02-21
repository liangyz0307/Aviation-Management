using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class FBGG_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private GG fbgg;
        private CUST.MKG.OGG.Struct_GG_Pro struct_gg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            fbgg = new GG(_usState);
            if (!IsPostBack)
            {
                Bind();
                ddlt_gglx.Enabled = false;
                ddlt_sfdb.Enabled = false;
                tbx_blsx.Enabled = false;
                tbx_bt.Enabled = false;
                cbxl_jsbm.Enabled = false;
                ChangeFlag.Value = "false";
            }
        }
        private void ddltBind()
        {
            //绑定公告类型ddlt_gglx
            DataTable dt_gglx = SysData.GGLX().Copy();
            ddlt_gglx.DataSource = dt_gglx;
            ddlt_gglx.DataTextField = "mc";
            ddlt_gglx.DataValueField = "bm";
            ddlt_gglx.DataBind();

            //绑定部门代码
            DataTable dt_bmdm = SysData.BM().Copy();
            for (int i = 0; i < dt_bmdm.Rows.Count; i++)
            {
                cbxl_jsbm.Items.Add(dt_bmdm.Rows[i]["mc"].ToString());
            }

            ddlt_sfdb.DataSource = SysData.SFDB().Copy();
            ddlt_sfdb.DataTextField = "mc";
            ddlt_sfdb.DataValueField = "bm";
            ddlt_sfdb.DataBind();
        }
        private void Bind()
        {
            ddltBind();
            DataTable dt_detail = new DataTable();
            string id = Request.QueryString["id"];
            dt_detail = fbgg.Select_GG(Convert.ToInt32(id));
            ddlt_gglx.Text = dt_detail.Rows[0]["lx"].ToString().Trim();
            ddlt_sfdb.SelectedValue = dt_detail.Rows[0]["sfdb"].ToString().Trim();
            tbx_bt.Text = dt_detail.Rows[0]["bt"].ToString().Trim();
            DateTime time = new DateTime();
            
            if (Convert.ToDateTime(dt_detail.Rows[0]["blsx"].ToString().Trim()) == time)
            {
                tbx_blsx.Text = "";
            }
            else
            {
                tbx_blsx.Text = dt_detail.Rows[0]["blsx"].ToString().Trim();
            }
            txtEditorContents.Text = dt_detail.Rows[0]["lr"].ToString().Trim();
            //接受部门
            string bm= dt_detail.Rows[0]["jsbm"].ToString().Trim();
            string[] sArray = bm.Split(',');
         
            foreach (string jsbm_dm in sArray)
            {
                for (int j = 0; j < cbxl_jsbm.Items.Count; j++)
                {
                    if (cbxl_jsbm.Items[j].Value ==SysData.BMByKey(jsbm_dm).mc)
                    {
                        cbxl_jsbm.Items[j].Selected = true;
                    }
                }
            }
           
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
            string bt = tbx_bt.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bt))
            {
                lbl_bt.Text = "<span style=\"color:#ff0000\">" + "该项不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            } 
            if (flag == 1)
            {
                return;
            }
            string jsbm = "";
            DataTable dt_bmdm = SysData.BM().Copy();
            foreach (ListItem li in cbxl_jsbm.Items)
            {
                if (li.Selected)
                {
                    for (int i = 0; i < dt_bmdm.Rows.Count; i++)
                    {
                        if (li.Value == dt_bmdm.Rows[i]["mc"].ToString())
                        {
                            jsbm += dt_bmdm.Rows[i]["bm"].ToString() + ",";
                        }

                    };
                }
            }

            #endregion
            struct_gg.p_id= Convert.ToInt32(Request.QueryString["id"]);
            struct_gg.p_lx = ddlt_gglx.Text.ToString().Trim();
            struct_gg.p_bt = tbx_bt.Text.ToString().Trim();
            struct_gg.p_lr = txtEditorContents.Text.ToString().Trim();
            struct_gg.p_xgsj = System.DateTime.Now;
            struct_gg.p_xgr = _usState.userID.ToString();
            struct_gg.p_czfs = "02";
            struct_gg.p_sfdb = ddlt_sfdb.SelectedValue.ToString().Trim();
            struct_gg.p_jsbm = jsbm;
            DateTime date_blsx = new DateTime();
            if (tbx_blsx.Text.Trim()=="")
            {
                struct_gg.p_blsx = date_blsx;
            }
            else
            {
                struct_gg.p_blsx = Convert.ToDateTime(tbx_blsx.Text.Trim());
            }
             struct_gg.p_czxx = "位置：后台管理->发布公告->编辑 描述：公告类型：【" + struct_gg.p_lx + "】    " + "公告标题：【" + struct_gg.p_bt + "】  "
                  + " 修改人：【" + _usState.userID.ToString() + "】" + " 接受部门：【" + struct_gg.p_jsbm + "】";
             fbgg.GG_update(struct_gg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            btn_bj.Visible = true;
            btn_bc.Visible = false;
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/FBGG.aspx");
        }

        protected void btn_bj_Command(object sender, CommandEventArgs e)
        {
            btn_bj.Visible = false;
            btn_bc.Visible = true;
            ddlt_gglx.Enabled = true;
            ddlt_sfdb.Enabled = true;
            tbx_blsx.Enabled = true;
            tbx_bt.Enabled = true;
            cbxl_jsbm.Enabled = true;
            ChangeFlag.Value = "true";
        }

     
    }
}