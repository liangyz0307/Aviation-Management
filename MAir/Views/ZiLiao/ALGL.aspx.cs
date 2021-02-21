using CUST;
using CUST.Sys;
using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using Sys;
using System.IO;


namespace CUST.WKG
{
    public partial class ALGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public string filepath;
        public string fpath;
        private ALK alk;

        private Struct_ALK struct_alk;

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
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            //psize = pg_fy.NumPerPage; 
            psize = _usState.C_ZL_ZJ;
            alk = new ALK(_usState);
            struct_alk = new Struct_ALK();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
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

            if (SysData.HasThisBMQX(_usState.userID, "160202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }

        private void ddltBind()
        {
            //案例来源
            ddlt_ally.DataSource = SysData.ALLY().Copy();
            ddlt_ally.DataTextField = "mc";
            ddlt_ally.DataValueField = "bm";
            ddlt_ally.DataBind();
            ddlt_ally.Items.Insert(0, new ListItem("请选择", "-1"));
            //案例类型一
            ddlt_allx1.DataTextField = "mc";
            ddlt_allx1.DataValueField = "bm";
            ddlt_allx1.DataSource = SysData.ALLX1().Copy();
            ddlt_allx1.DataBind();
            ddlt_allx1.Items.Insert(0, new ListItem("请选择", "-1"));

            //案例类型二
            ddlt_allx2.DataTextField = "mc";
            ddlt_allx2.DataValueField = "bm";
            ddlt_allx2.DataSource = SysData.ALLX2(ddlt_allx1.SelectedValue.ToString()).Copy();
            ddlt_allx2.DataBind();
            ddlt_allx2.Items.Insert(0, new ListItem("请选择", "-1"));
            //案例等级
            ddlt_aldj.DataSource = SysData.ALDJ().Copy();
            ddlt_aldj.DataTextField = "mc";
            ddlt_aldj.DataValueField = "bm";
            ddlt_aldj.DataBind();
            ddlt_aldj.Items.Insert(0, new ListItem("请选择", "-1"));


        }
        protected void ddlt_allx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_allx2.DataTextField = "mc";
            ddlt_allx2.DataValueField = "bm";
            ddlt_allx2.DataSource = SysData.ALLX2(ddlt_allx1.SelectedValue.ToString()).Copy();
            ddlt_allx2.DataBind();
            ddlt_allx2.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        private void bind_Main()
        {
            struct_alk.p_alm = tbx_alm.Text.Trim().ToString();//案例名
            struct_alk.p_allx1 = ddlt_allx1.SelectedValue.ToString().Trim();//文档类型一
            struct_alk.p_allx2 = ddlt_allx2.SelectedValue.ToString().Trim();//文档类型二
            struct_alk.p_ally = ddlt_ally.SelectedValue.ToString().Trim();//案例来源
            struct_alk.p_aldj = ddlt_aldj.SelectedValue.ToString().Trim();//案例等级



            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                struct_alk.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_alk.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                struct_alk.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_alk.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束时间
            }

            struct_alk.p_userid = _usState.userID;
            int count = alk.Select_AL_Count(struct_alk);
            pg_fy.TotalRecord = count;
            //lbl_count.Text = count.ToString();
            struct_alk.p_currentpage = pg_fy.CurrentPage;
            struct_alk.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = alk.Select_AL_Pro(struct_alk).Tables[0];
            dt.Columns.Add("bm");
            dt.Columns.Add("gw");
            dt.Columns.Add("allx1mc");
            dt.Columns.Add("allx2mc");
            dt.Columns.Add("allymc");
            dt.Columns.Add("scsjmc");
            dt.Columns.Add("fssjmc");
            dt.Columns.Add("aldjmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sjssbm");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["scbm"].ToString()).mc;
                dr["gw"] = SysData.GWByKey(dr["scgw"].ToString()).mc;
                dr["allx1mc"] = SysData.ALLX1ByKey(dr["allx1"].ToString()).mc;
                dr["allx2mc"] = SysData.ALLX2ByKey(dr["allx2"].ToString()).mc;
                dr["allymc"] = SysData.ALLYByKey(dr["ally"].ToString()).mc;
                dr["scsjmc"] = DateTime.Parse(dr["scsj"].ToString()).ToString("yyyy-MM-dd");
                dr["fssjmc"] = DateTime.Parse(dr["fssj"].ToString()).ToString("yyyy-MM-dd");
                dr["aldjmc"] = SysData.ALDJByKey(dr["aldj"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
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
            string[] content = new string[5];
            content = e.CommandArgument.ToString().Split('&');

            string zt = content[0];
            int id = Convert.ToInt32(content[1]);
            string alm = content[2];
            string sclj = content[3];
            string bmdm = content[4];

            if (e.CommandName == "down")
            {
                /* try
                 {
                   //  filepath = "UpLoads/" + struct_alk.p_albh + "/";
                   //  string path = System.Web.HttpContext.Current.Request.MapPath(filepath);
                     content = e.CommandArgument.ToString().Split('&');
                     alm = content[2];
                     sclj = content[3];
                     // string filename = e.CommandArgument.ToString();//文件名
                     // string name = filename.Substring(filename.LastIndexOf("\\") + 1);
                     string filename=sclj.Substring(sclj.LastIndexOf("\\") + 1);

                     if (File.Exists(sclj))
                     {
                         FileInfo fileInfo = new FileInfo(sclj);
                         Response.Clear();
                         Response.ClearContent();
                         Response.ClearHeaders();
                         //  Response.AddHeader("Content-Disposition", "attachment;filename=" + alm);
                         Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileInfo.Name, System.Text.Encoding.UTF8));
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
                         Response.Redirect("~/Views/ZiLiao/ALGL.aspx");
                         Response.End();
                     }
                 }
                 catch { }*/

                try
                {
                    string url = Server.MapPath("~/Views/ZiLiao/UpLoads/");
                    //filepath = "UpLoads/" + struct_alk.p_albh + "/";
                    //string path = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    content = e.CommandArgument.ToString().Split('&');
                    alm = content[2];
                    sclj = content[3];
                    //string filename = e.CommandArgument.ToString();//文件名
                    //string name = filename.Substring(filename.LastIndexOf("\\") + 1);
                    string filename = sclj.Substring(sclj.LastIndexOf("\\") + 1);
                    filepath = url + filename;

                    if (File.Exists(sclj))
                    {
                        FileInfo fileInfo = new FileInfo(sclj);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        Response.WriteFile(fileInfo.FullName);
                        Response.Flush();
                        Response.End();

                        //FileInfo fileInfo = new FileInfo(sclj);
                        //Response.Clear();
                        //Response.ClearContent();
                        //Response.ClearHeaders();
                        //Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                        //Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        //Response.AddHeader("Content-Transfer-Encoding", "binary");
                        //Response.ContentType = "application/octet-stream";
                        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        //Response.WriteFile(fileInfo.FullName);
                        //Response.Flush();
                        //Response.End();
                    }
                    else
                    {
                        Response.Write("<script languge='javascript'>alert('源文件已不存在！');</script>");

                        Response.Write("<script>window.location='ALGL.aspx'</script>");
                        //Response.Redirect("~/Views/ZiLiao/ALGL.aspx");
                        Response.End();
                    }
                }
                catch { }
            }
            //if (e.CommandName == "Edit")
            //{
            //    if (zt == "1")
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已提交，不能编辑！\")</script>");
            //        return;
            //    }
            //    else if (zt == "2")
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已审核通过，不能编辑！\")</script>");
            //        return;
            //    }

            //    else if (zt == "0" || zt == "3")
            //    {
            //        Server.Transfer("AL_Edit.aspx?albh=" + albh);
            //    }
            //}
            else if (e.CommandName == "Delete")
            {
                struct_alk = new Struct_ALK();
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已提交，不能删除！\")</script>");
                    return;
                }


                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：案例管理库；->案例管理->删除    描述：案例编号：[" + _usState.userLoginName + "]";
                        alk.Delete_AL(id, "03", p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }

            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160205"))
                    {

                        struct_alk.p_id = id;
                        struct_alk.p_zt = "2";
                        struct_alk.p_bhyy = HF_yc.Value;
                        struct_alk.p_czfs = "05";
                        struct_alk.p_czxx = "位置：案例管理库->状态->改变状态（提交）    描述：案例编号：[" + _usState.userLoginName + "]";
                        alk.Update_ALZT(struct_alk);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"提交成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该案例信息的提交权限，不能提交！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0" || zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息未提交，不能审核！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160206"))
                    {
                        //执行update改变状态（审核）
                        struct_alk.p_id = id;
                        struct_alk.p_zt = "3";
                        struct_alk.p_bhyy = HF_yc.Value;
                        struct_alk.p_czfs = "06";
                        struct_alk.p_czxx = "位置：案例信息->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        alk.Update_ALZT(struct_alk);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('审核成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该案例信息的审核权限，不能审核！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息未提交，不能驳回！\")</script>");

                    return;
                }
                else
                    if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该案例信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "160207"))
                    {
                        //执行update改变状态（驳回）
                        struct_alk.p_id = id;
                        struct_alk.p_zt = "0";
                        struct_alk.p_bhyy = HF_yc.Value;
                        struct_alk.p_czfs = "07";
                        struct_alk.p_czxx = "位置：案例管理->状态->改变状态（驳回）    描述：案例编号：[" + _usState.userLoginName + "]";
                        alk.Update_ALZT(struct_alk);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('驳回成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该信息的驳回权限，不能驳回！\")</script>");
                        return;
                    }
                }

            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZiLiao/AL_Add.aspx", false);
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