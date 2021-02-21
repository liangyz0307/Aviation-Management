using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BMQX_PZ : System.Web.UI.Page
    {

        public int cpage;
        public int psize;
        private UserState userstate;
        DataTable dt_bm;
        private YHJS js;
        private string jsdm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new YHJS(userstate);
            jsdm = Request.QueryString.Get("jsdm");
            if (!IsPostBack)
            {
                dt_bm = new DataTable();
                dt_bm = js.Select_BM();
                bind_select();
            }
        }
        private void bind_select()
        {
            //根据角色编号查询角色名称
            DataTable dt_jsmc = js.Select_JSbyJSDM(jsdm);
            lbl_jsmc.Text = dt_jsmc.Rows[0]["jsmc"].ToString();
            DataTable dt_qx = js.Select_QX_ALL();
            dt_qx = changeTable(dt_qx);
            rp_qxpz.DataSource = dt_qx;
            rp_qxpz.DataBind();
            Select_jsqx();
        }
        //查询对应角色的权限并显示
        private void Select_jsqx()
        {
            DataTable dt = new DataTable();

            DataTable dt_czfs = new DataTable();
            dt_czfs = SysData.CZFS();
            dt_czfs.Rows.RemoveAt(0);

            DataTable dt_dq = new DataTable();
            dt_dq = SysData.ZXDM();

            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                #region 使用checkboxlist

                //地区
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                cbxl_bmlb.DataSource = dt_bm;
                cbxl_bmlb.DataTextField = "bmmc";
                cbxl_bmlb.DataValueField = "bmdm";
                cbxl_bmlb.DataBind();


                //权限
                HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                HtmlInputCheckBox cbx_sumbit = (HtmlInputCheckBox)rpItem.FindControl("cbx_sumbit");
                HtmlInputCheckBox cbx_bh = (HtmlInputCheckBox)rpItem.FindControl("cbx_bh");
                HtmlInputCheckBox cbx_sh = (HtmlInputCheckBox)rpItem.FindControl("cbx_sh");
                HtmlInputCheckBox cbx_upload = (HtmlInputCheckBox)rpItem.FindControl("cbx_upload");
                HtmlInputCheckBox cbx_download = (HtmlInputCheckBox)rpItem.FindControl("cbx_download");
                HtmlInputCheckBox cbx_dr = (HtmlInputCheckBox)rpItem.FindControl("cbx_dr");
                HtmlInputCheckBox cbx_dc = (HtmlInputCheckBox)rpItem.FindControl("cbx_dc");
                HtmlInputCheckBox cbx_qx = (HtmlInputCheckBox)rpItem.FindControl("btn_qx");//全选
                //获取所有的部门
                for (int k = 0; k < dt_bm.Rows.Count; k++)
                {
                    //通过角色代码，部门代码获取操作权限
                    dt = js.Selete_QXByJS_BM(jsdm, dt_bm.Rows[k]["bmdm"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_select.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_add.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_edit.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_delete.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_sumbit.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_bh.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_sh.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_upload.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_download.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_dr.Checked = true;
                            }
                            if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                            {
                                cbxl_bmlb.Items[k].Selected = true;
                                cbx_dc.Checked = true;
                            }
                        }
                    }
                }
                #endregion
            }
        }
        private DataTable changeTable(DataTable dt)
        {
            DataTable dt_qx = new DataTable();
            dt_qx.Columns.Add("zxtmc", typeof(string));
            dt_qx.Columns.Add("mkmc", typeof(string));
            dt_qx.Columns.Add("select_qxdm", typeof(string));
            dt_qx.Columns.Add("add_qxdm", typeof(string));
            dt_qx.Columns.Add("edit_qxdm", typeof(string));
            dt_qx.Columns.Add("delete_qxdm", typeof(string));
            dt_qx.Columns.Add("submit_qxdm", typeof(string));
            dt_qx.Columns.Add("sh_qxdm", typeof(string));
            dt_qx.Columns.Add("bh_qxdm", typeof(string));
            dt_qx.Columns.Add("upload_qxdm", typeof(string));
            dt_qx.Columns.Add("download_qxdm", typeof(string));
            dt_qx.Columns.Add("dr_qxdm", typeof(string));
            dt_qx.Columns.Add("dc_qxdm", typeof(string));
            string mk = "";
            int i = -1;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["mk"].ToString() != mk)
                {
                    i++;
                    DataRow dr_qx = dt_qx.NewRow();
                    dt_qx.ImportRow(dr);
                    dt_qx.Rows[i]["zxtmc"] = dr["zxtmc"].ToString();
                    dt_qx.Rows[i]["mkmc"] = dr["mkmc"].ToString();
                    mk = dr["mk"].ToString();
                    if (dr["gn"].ToString() == "01")
                    {
                        dt_qx.Rows[i]["select_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "02")
                    {
                        dt_qx.Rows[i]["add_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "03")
                    {
                        dt_qx.Rows[i]["edit_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "04")
                    {
                        dt_qx.Rows[i]["delete_qxdm"] = dr["qxdm"];
                    }

                    if (dr["gn"].ToString() == "05")
                    {
                        dt_qx.Rows[i]["submit_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "07")
                    {
                        dt_qx.Rows[i]["bh_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "06")
                    {
                        dt_qx.Rows[i]["sh_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "08")
                    {
                        dt_qx.Rows[i]["upload_qxdm"] = dr["qxdm"];
                    }

                    if (dr["gn"].ToString() == "09")
                    {
                        dt_qx.Rows[i]["download_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "10")
                    {
                        dt_qx.Rows[i]["dr_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "11")
                    {
                        dt_qx.Rows[i]["dc_qxdm"] = dr["qxdm"];
                    }
                }
                else
                {
                    if (dr["gn"].ToString() == "01")
                    {
                        dt_qx.Rows[i]["select_qxdm"] = dr["qxdm"];

                    }
                    if (dr["gn"].ToString() == "02")
                    {
                        dt_qx.Rows[i]["add_qxdm"] = dr["qxdm"];

                    }
                    if (dr["gn"].ToString() == "03")
                    {
                        dt_qx.Rows[i]["edit_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "04")
                    {
                        dt_qx.Rows[i]["delete_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "05")
                    {
                        dt_qx.Rows[i]["submit_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "07")
                    {
                        dt_qx.Rows[i]["bh_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "06")
                    {
                        dt_qx.Rows[i]["sh_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "08")
                    {
                        dt_qx.Rows[i]["upload_qxdm"] = dr["qxdm"];
                    }

                    if (dr["gn"].ToString() == "09")
                    {
                        dt_qx.Rows[i]["download_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "10")
                    {
                        dt_qx.Rows[i]["dr_qxdm"] = dr["qxdm"];
                    }
                    if (dr["gn"].ToString() == "11")
                    {
                        dt_qx.Rows[i]["dc_qxdm"] = dr["qxdm"];
                    }
                }
            }
            return dt_qx;
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("JS_GL.aspx");
        }
        private void Add_QX()
        {
            dt_bm = js.Select_BM();
            bool flag_succeed = true;
            bool flag_bm = false;
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                //地区
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                //权限
                HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                HtmlInputCheckBox cbx_sumbit = (HtmlInputCheckBox)rpItem.FindControl("cbx_sumbit");
                HtmlInputCheckBox cbx_sh = (HtmlInputCheckBox)rpItem.FindControl("cbx_sh");
                HtmlInputCheckBox cbx_bh = (HtmlInputCheckBox)rpItem.FindControl("cbx_bh");
                HtmlInputCheckBox cbx_upload = (HtmlInputCheckBox)rpItem.FindControl("cbx_upload");
                HtmlInputCheckBox cbx_download = (HtmlInputCheckBox)rpItem.FindControl("cbx_download");
                HtmlInputCheckBox cbx_dr = (HtmlInputCheckBox)rpItem.FindControl("cbx_dr");
                HtmlInputCheckBox cbx_dc = (HtmlInputCheckBox)rpItem.FindControl("cbx_dc");
                bool flag = false;
                flag_bm = false;
                //获取所有的部门
                for (int k = 0; k < dt_bm.Rows.Count; k++)
                {
                    //循环部门，插入对应部门的权限
                    #region 循环十个功能 添加到表中
                    //查询权限
                    if (cbx_select.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_select.Value.ToString());
                    }
                    if (cbx_select.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_select.Value.ToString());
                    }
                    if (cbx_select.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_select.Value.ToString());
                    }
                    if (cbx_select.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_select.Value.ToString());
                    }
                    if (cbx_select.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_select.Value.ToString());
                    }


                    //添加权限
                    if (cbx_add.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_add.Value.ToString());
                    }
                    if (cbx_add.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_add.Value.ToString());
                    }
                    if (cbx_add.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_add.Value.ToString());
                    }
                    if (cbx_add.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_add.Value.ToString());
                    }
                    if (cbx_add.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_add.Value.ToString());
                    }

                    //编辑权限
                    if (cbx_edit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_edit.Value.ToString());
                    }
                    if (cbx_edit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_edit.Value.ToString());
                    }
                    if (cbx_edit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_edit.Value.ToString());
                    }
                    if (cbx_edit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_edit.Value.ToString());
                    }
                    if (cbx_edit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_edit.Value.ToString());
                    }


                    //删除权限
                    if (cbx_delete.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_delete.Value.ToString());
                    }
                    if (cbx_delete.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_delete.Value.ToString());
                    }
                    if (cbx_delete.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_delete.Value.ToString());
                    }
                    if (cbx_delete.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_delete.Value.ToString());
                    }
                    if (cbx_delete.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_delete.Value.ToString());
                    }

                    //提交权限
                    if (cbx_sumbit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }
                    if (cbx_sumbit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }
                    if (cbx_sumbit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }
                    if (cbx_sumbit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }
                    if (cbx_sumbit.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }

                    //审核权限
                    if (cbx_sh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sh.Value.ToString());
                    }
                    if (cbx_sh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sh.Value.ToString());
                    }
                    if (cbx_sh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sh.Value.ToString());
                    }
                    if (cbx_sh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sh.Value.ToString());
                    }
                    if (cbx_sh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sh.Value.ToString());
                    }

                    //驳回权限
                    if (cbx_bh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_bh.Value.ToString());
                    }
                    if (cbx_bh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_sumbit.Value.ToString());
                    }
                    if (cbx_bh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_bh.Value.ToString());
                    }
                    if (cbx_bh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_bh.Value.ToString());
                    }
                    if (cbx_bh.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_bh.Value.ToString());
                    }



                    //上传权限
                    if (cbx_upload.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_upload.Value.ToString());
                    }
                    if (cbx_upload.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_upload.Value.ToString());
                    }
                    if (cbx_upload.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_upload.Value.ToString());
                    }
                    if (cbx_upload.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_upload.Value.ToString());
                    }
                    if (cbx_upload.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_upload.Value.ToString());
                    }

                    //下载权限
                    if (cbx_download.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_download.Value.ToString());
                    }
                    if (cbx_download.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_download.Value.ToString());
                    }
                    if (cbx_download.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_download.Value.ToString());
                    }
                    if (cbx_download.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_download.Value.ToString());
                    }
                    if (cbx_download.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_download.Value.ToString());
                    }

                    //导入权限
                    if (cbx_dr.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dr.Value.ToString());
                    }
                    if (cbx_dr.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dr.Value.ToString());
                    }
                    if (cbx_dr.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dr.Value.ToString());
                    }
                    if (cbx_dr.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dr.Value.ToString());
                    }
                    if (cbx_dr.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dr.Value.ToString());
                    }

                    //导出权限
                    if (cbx_dc.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dc.Value.ToString());
                    }
                    if (cbx_dc.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dc.Value.ToString());
                    }
                    if (cbx_dc.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dc.Value.ToString());
                    }
                    if (cbx_dc.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dc.Value.ToString());
                    }
                    if (cbx_dc.Checked == true && cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag = true;
                        js.Insert_JSQX_BM(jsdm, cbxl_bmlb.Items[k].Value.ToString(), cbx_dc.Value.ToString());
                    }
                    if (cbxl_bmlb.Items[k].Selected == true)
                    {
                        flag_bm = true;
                    }
                    #endregion
                }
                if (flag == true)
                {
                }
                else
                {
                    if (cbx_select.Checked == false && cbx_add.Checked == false && cbx_edit.Checked == false && cbx_delete.Checked == false && cbx_sumbit.Checked == false && cbx_sh.Checked == false && cbx_bh.Checked == false && cbx_upload.Checked == false && cbx_download.Checked == false && cbx_dr.Checked == false && cbx_dc.Checked == false
                    && flag_bm == false)
                    {
                    }
                    else
                    {
                        flag_succeed = false;
                        Label lbl_mc = (Label)rpItem.FindControl("lbl_mc");
                        string ms = "请选择:" + lbl_mc.Text + "--相应的部门和权限";
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "提示", "<script>alert(" + "\"" + ms + "\"" + ")</script>");
                        break;
                    }
                }
            }
            if (flag_succeed == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"部门授权成功！\")</script>");
            }

        }
        //清除权限
        public void Delete_BMQXbyJS()
        {
            DataTable dt = js.Select_JSbyJSDM(jsdm);
            if (dt.Rows.Count > 0)
            {
                js.Delete_BMQXByJS(jsdm);
            }
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            Delete_BMQXbyJS();
            try
            {
                Add_QX();
            }
            catch (Exception em)
            {
                throw em;
            }
        }

        #region//全选反选取消按钮
        //长春导航保障部
        protected void btn_ccdhbzb_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals( "01"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;              
                    }        
                }
            }
        }
        protected void btn_ccdhbzb_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("01"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //延吉航务保障部
        protected void btn_yjhwbzb_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("02"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_yjhwbzb_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("02"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        } 
        //长白山航务保障部
        protected void btn_cbshwbzb_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("03"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_cbshwbzb_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("03"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //通化航务保障部
        protected void btn_thhwbzb_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("04"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_thhwbzb_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("04"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //白城航务保障部
        protected void btn_bchwbzb_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("05"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_bchwbzb_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("05"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //综合办公室
        protected void btn_zhbgs_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("06"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_zhbgs_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("06"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //航务管理部-部门领导
        protected void btn_hwglb_bmld_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("07"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_hwglb_bmld_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("07"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //气象
        protected void btn_qx_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("08"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_qx_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("08"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //通导
        protected void btn_td_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("09"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_td_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("09"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //航管
        protected void btn_hg_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("10"))
                    {
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        protected void btn_hg_cancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Value.Equals("10"))
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }
                }
            }
        }
        //反选
        protected void btn_fanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    if (cbxl_bmlb.Items[i].Selected == true)
                    {
                        cbxl_bmlb.Items[i].Selected = false;
                    }else{
                        cbxl_bmlb.Items[i].Selected = true;
                    }
                }
            }
        }
        //全选
        protected void btn_quanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    cbxl_bmlb.Items[i].Selected = true;
                }
            }
        }
        //取消
        protected void btn_quxiao_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                CheckBoxList cbxl_bmlb = (CheckBoxList)rpItem.FindControl("cbxl_bmlb");
                for (int i = 0; i < cbxl_bmlb.Items.Count; i++)
                {
                    cbxl_bmlb.Items[i].Selected = false;
                }
            }
        }
        //查询全选
        protected void btn_CXquanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                cbx_select.Checked = true;
            }
        }
        //查询取消
        protected void btn_CXquxiao_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                cbx_select.Checked = false;
            }
        }
        //添加全选
        protected void btn_TJquanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                cbx_add.Checked = true;
            }
        }
        //添加取消
        protected void btn_TJquxiao_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                cbx_add.Checked = false;
            }
        }       
        //编辑全选
        protected void btn_BJquanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                cbx_edit.Checked = true;
            }
        }
        //编辑取消
        protected void btn_BJquxiao_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                cbx_edit.Checked = false;
            }
        }
        //删除全选
        protected void btn_SCquanxuan_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                cbx_delete.Checked = true;
            }
        }
        //删除取消
        protected void btn_SCquxiao_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                cbx_delete.Checked = false;
            }
        }
        #endregion
    }
}