using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;


namespace CUST.WKG
{
    public partial class KG_ZLGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZLGL zlgl;
        private string p_czfs;
        private string p_czxx;
        public string filepath;
        private Struct_ZL struct_zl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)//session 浏览器服务器的一次对话，session【name】判断是否登录
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            zlgl = new ZLGL(_usState);
            struct_zl = new Struct_ZL();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                show();
            }
        }
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "160102") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

            



        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        private void ddltBind()
        { //资料类型一
            ddlt_zllx1.DataTextField = "mc";
            ddlt_zllx1.DataValueField = "bm";
            ddlt_zllx1.DataSource = SysData.ZLLX1().Copy();
            ddlt_zllx1.DataBind();
            ddlt_zllx1.Items.Insert(0, new ListItem("全部", "-1"));

            //资料类型二
            ddlt_zllx2.DataTextField = "mc";
            ddlt_zllx2.DataValueField = "bm";
            ddlt_zllx2.DataSource = SysData.ZLLX2(ddlt_zllx1.SelectedValue.ToString()).Copy();
            ddlt_zllx2.DataBind();
            ddlt_zllx2.Items.Insert(0, new ListItem("全部", "-1"));
            
        }
        protected void ddlt_zllx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_zllx2.DataTextField = "mc";
            ddlt_zllx2.DataValueField = "bm";
            ddlt_zllx2.DataSource = SysData.ZLLX2(ddlt_zllx1.SelectedValue.ToString()).Copy();
            ddlt_zllx2.DataBind();
            ddlt_zllx2.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {   
            
            struct_zl.p_zllx1 = ddlt_zllx1.SelectedValue.ToString().Trim();//文档类型一
            struct_zl.p_zllx2 = ddlt_zllx2.SelectedValue.ToString().Trim();//文档类型二
            
            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                DateTime dt_kssj = new DateTime();
                struct_zl.p_kssj = dt_kssj;
            }
            else
            {
                struct_zl.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                // DateTime dt_jssj = new DateTime();
                struct_zl.p_jssj = DateTime.Now;
            }
            else
            {
                struct_zl.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束时间
            }

            struct_zl.p_userid = _usState.userID;
            int count = zlgl.Select_ZL_Count(struct_zl);
            pg_fy.TotalRecord = count;
            struct_zl.p_currentpage = pg_fy.CurrentPage;
            struct_zl.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = zlgl.Select_ZL_Pro(struct_zl).Tables[0];
            dt.Columns.Add("bmmc");
            dt.Columns.Add("sjssbm");
            dt.Columns.Add("gwmc");
            dt.Columns.Add("zllx1mc");
            dt.Columns.Add("zllx2mc");
            dt.Columns.Add("scsjmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("yhxm");
            string[] Array_yh = null;
            foreach (DataRow dr in dt.Rows)
            {
                Array_yh = dr["yh"].ToString().Split(',');
                
                foreach (string yhxm_dm in Array_yh)
                {
                    dr["yhxm"] += zlgl.Select_YGXMbyBH(yhxm_dm.ToString()).Rows[0][0].ToString();
                }
                dr["bmmc"] = SysData.BMByKey(dr["bm"].ToString()).mc;
                dr["gwmc"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                dr["zllx1mc"] = SysData.ZLLX1ByKey(dr["zllx1"].ToString()).mc;
                dr["zllx2mc"] = SysData.ZLLX2ByKey(dr["zllx2"].ToString()).mc; 
                DateTime dt_scsj = new DateTime();
                dt_scsj = Convert.ToDateTime(dr["sj"].ToString());
                dr["scsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_scsj);
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["sjssbm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[5];
            content = e.CommandArgument.ToString().Split('&');
          
            string zt = content[0];
            int id = Convert.ToInt32(content[1]);
            string zlm = content[2];
            string wjlj = content[3];
            string bmdm = content[4];
            

            if (e.CommandName == "Delete")
            {
                if (zt == "1"||zt=="2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已提交，不能删除！\")</script>");
                    return;
                }
                

                else 
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160104"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：空管->资料管理->删除 资料编号：" + id;
                        zlgl.Struct_Delete_Pro(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('删除成功！');</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {

                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160105")) {
                        zlgl.Update_ZLGLZT(id, "2", "");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"提交成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该资料信息的提交权限，不能提交！\")</script>");
                        return;
                    }

                }

            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0"||zt=="4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息未提交，不能审核！\")</script>");

                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160106")) {
                        zlgl.Update_ZLGLZT(id, "3", "");
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('审核成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该资料信息的审核权限，不能审核！\")</script>");
                        return;
                    }
                }

            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息未提交，不能驳回！\")</script>");

                    return;
                }
                else
                if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160107"))
                    {
                        string bhyy = HF_yc.Value;
                        zlgl.Update_ZLGLZT(id, "0", bhyy);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('驳回成功！');</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该信息的驳回权限，不能驳回！\")</script>");
                        return;
                    }
                       
                }
            }
            else if (e.CommandName == "down")
            {
                try
                {
                    filepath = "UpLoads/" + struct_zl.p_zlbh + "/";
                    string path = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string[] content_new = new string[5];
                    content = e.CommandArgument.ToString().Split('&');
                     zlm = content[2];
                     wjlj = content[3];
                    string DownloadFileName = path + e.CommandArgument.ToString();//文件路径
                    string filename = e.CommandArgument.ToString();//文件名
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);

                    
                        // string filePath = path + filename;
                        if (File.Exists(wjlj))
                        {
                            FileInfo fileInfo = new FileInfo(wjlj);
                            Response.Clear();
                            Response.ClearContent();
                            Response.ClearHeaders();
                            Response.AddHeader("Content-Disposition", "attachment;filename=" + zlm);
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
                            Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                            Response.Redirect("~/Views/ZiLiao/KG_ZLGL.aspx");
                            Response.End();
                        }
                    }
                    
                
                catch { }
                
            }
            bind_Main();
    }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZiLiao/KG_ZLGL_Add.aspx", false);
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










