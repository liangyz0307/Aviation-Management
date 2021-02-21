using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JSQX_PZ : System.Web.UI.Page
    {

        public int cpage;
        public int psize;
        private UserState userstate;

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
            //int i=1 ,j= 1;
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                #region 未使用checkboxlist
                //地区
                HtmlInputCheckBox cbx_cc = (HtmlInputCheckBox)rpItem.FindControl("cbx_cc");
                HtmlInputCheckBox cbx_cbs = (HtmlInputCheckBox)rpItem.FindControl("cbx_cbs");
                HtmlInputCheckBox cbx_yj = (HtmlInputCheckBox)rpItem.FindControl("cbx_yj");
                HtmlInputCheckBox cbx_th = (HtmlInputCheckBox)rpItem.FindControl("cbx_th");
                HtmlInputCheckBox cbx_bc = (HtmlInputCheckBox)rpItem.FindControl("cbx_bc");
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

                //判断该角色在长春地区下的权限
                dt = js.Selete_QXByJS_DQ(jsdm, cbx_cc.Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_select.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_add.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_edit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_delete.Checked = true;
                        }

                        if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sumbit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_bh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_upload.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_download.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dr.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dc.Checked = true;
                        }


                    }
                }

                //判断该角色在长白山地区下的权限
                dt = js.Selete_QXByJS_DQ(jsdm, cbx_cbs.Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                        {
                            cbx_cbs.Checked = true;
                            cbx_select.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                        {
                            cbx_cbs.Checked = true;
                            cbx_add.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                        {
                            cbx_cbs.Checked = true;
                            cbx_edit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                        {
                            cbx_cbs.Checked = true;
                            cbx_delete.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sumbit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_bh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_upload.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_download.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dr.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dc.Checked = true;
                        }
                    }

                }
                //判断该角色在延吉地区下的权限
                dt = js.Selete_QXByJS_DQ(jsdm, cbx_yj.Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                        {
                            cbx_yj.Checked = true;
                            cbx_select.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                        {
                            cbx_yj.Checked = true;
                            cbx_add.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                        {
                            cbx_yj.Checked = true;
                            cbx_edit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                        {
                            cbx_yj.Checked = true;
                            cbx_delete.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sumbit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_bh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_upload.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_download.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dr.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dc.Checked = true;
                        }
                    }
                }
                //判断该角色在通化地区下的权限
                dt = js.Selete_QXByJS_DQ(jsdm, cbx_th.Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                        {
                            cbx_th.Checked = true;
                            cbx_select.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                        {
                            cbx_th.Checked = true;
                            cbx_add.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                        {
                            cbx_th.Checked = true;
                            cbx_edit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                        {
                            cbx_th.Checked = true;
                            cbx_delete.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sumbit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_bh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_upload.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_download.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dr.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dc.Checked = true;
                        }
                    }
                }
                //判断该角色在白城地区下的权限
                dt = js.Selete_QXByJS_DQ(jsdm, cbx_bc.Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["qxdm"].ToString() == cbx_select.Value.ToString())
                        {
                            cbx_bc.Checked = true;
                            cbx_select.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_add.Value.ToString())
                        {
                            cbx_bc.Checked = true;
                            cbx_add.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_edit.Value.ToString())
                        {
                            cbx_bc.Checked = true;
                            cbx_edit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_delete.Value.ToString())
                        {
                            cbx_bc.Checked = true;
                            cbx_delete.Checked = true;
                        }

                        if (dr["qxdm"].ToString() == cbx_sumbit.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sumbit.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_bh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_bh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_sh.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_sh.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_upload.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_upload.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_download.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_download.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dr.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dr.Checked = true;
                        }
                        if (dr["qxdm"].ToString() == cbx_dc.Value.ToString())
                        {
                            cbx_cc.Checked = true;
                            cbx_dc.Checked = true;
                        }
                    }
                }
                #endregion
            }
        }
        private DataTable changeTable(DataTable dt)
        {
            DataTable dt_qx = new DataTable();
            dt_qx.Columns.Add("cc", typeof(string));
            dt_qx.Columns.Add("cbs", typeof(string));
            dt_qx.Columns.Add("yj", typeof(string));
            dt_qx.Columns.Add("th", typeof(string));
            dt_qx.Columns.Add("bc", typeof(string));
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
                    //dt_qx.Rows[i]["ms"] = dr["zxtmc"].ToString() + "-" + dr["mkmc"].ToString();
                    mk = dr["mk"].ToString();
                    dt_qx.Rows[i]["cc"] = "01";
                    dt_qx.Rows[i]["yj"] = "02";
                    dt_qx.Rows[i]["cbs"] = "03";
                    dt_qx.Rows[i]["th"] = "04";
                    dt_qx.Rows[i]["bc"] = "05";

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
            bool flag_succeed = true;
            foreach (RepeaterItem rpItem in rp_qxpz.Items)
            {
                //地区
                HtmlInputCheckBox cbx_cc = (HtmlInputCheckBox)rpItem.FindControl("cbx_cc");
                HtmlInputCheckBox cbx_cbs = (HtmlInputCheckBox)rpItem.FindControl("cbx_cbs");
                HtmlInputCheckBox cbx_yj = (HtmlInputCheckBox)rpItem.FindControl("cbx_yj");
                HtmlInputCheckBox cbx_th = (HtmlInputCheckBox)rpItem.FindControl("cbx_th");
                HtmlInputCheckBox cbx_bc = (HtmlInputCheckBox)rpItem.FindControl("cbx_bc");
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

                //查询权限
                if (cbx_select.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_select.Value.ToString());
                }
                if (cbx_select.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_select.Value.ToString());
                }
                if (cbx_select.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_select.Value.ToString());
                }
                if (cbx_select.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_select.Value.ToString());
                }
                if (cbx_select.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_select.Value.ToString());
                }


                //添加权限
                if (cbx_add.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_add.Value.ToString());
                }
                if (cbx_add.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_add.Value.ToString());
                }
                if (cbx_add.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_add.Value.ToString());
                }
                if (cbx_add.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_add.Value.ToString());
                }
                if (cbx_add.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_add.Value.ToString());
                }

                //编辑权限
                if (cbx_edit.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_edit.Value.ToString());
                }
                if (cbx_edit.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_edit.Value.ToString());
                }
                if (cbx_edit.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_edit.Value.ToString());
                }
                if (cbx_edit.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_edit.Value.ToString());
                }
                if (cbx_edit.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_edit.Value.ToString());
                }


                //删除权限
                if (cbx_delete.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_delete.Value.ToString());
                }
                if (cbx_delete.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_delete.Value.ToString());
                }
                if (cbx_delete.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_delete.Value.ToString());
                }
                if (cbx_delete.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_delete.Value.ToString());
                }
                if (cbx_delete.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_delete.Value.ToString());
                }

                //提交权限
                if (cbx_sumbit.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_sumbit.Value.ToString());
                }
                if (cbx_sumbit.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_sumbit.Value.ToString());
                }
                if (cbx_sumbit.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_sumbit.Value.ToString());
                }
                if (cbx_sumbit.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_sumbit.Value.ToString());
                }
                if (cbx_sumbit.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_sumbit.Value.ToString());
                }

                //审核权限
                if (cbx_sh.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_sh.Value.ToString());
                }
                if (cbx_sh.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_sh.Value.ToString());
                }
                if (cbx_sh.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_sh.Value.ToString());
                }
                if (cbx_sh.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_sh.Value.ToString());
                }
                if (cbx_sh.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_sh.Value.ToString());
                }

                //驳回权限
                if (cbx_bh.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_bh.Value.ToString());
                }
                if (cbx_bh.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_sumbit.Value.ToString());
                }
                if (cbx_bh.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_bh.Value.ToString());
                }
                if (cbx_bh.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_bh.Value.ToString());
                }
                if (cbx_bh.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_bh.Value.ToString());
                }



                //上传权限
                if (cbx_upload.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_upload.Value.ToString());
                }
                if (cbx_upload.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_upload.Value.ToString());
                }
                if (cbx_upload.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_upload.Value.ToString());
                }
                if (cbx_upload.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_upload.Value.ToString());
                }
                if (cbx_upload.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_upload.Value.ToString());
                }

                //下载权限
                if (cbx_download.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_download.Value.ToString());
                }
                if (cbx_download.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_download.Value.ToString());
                }
                if (cbx_download.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_download.Value.ToString());
                }
                if (cbx_download.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_download.Value.ToString());
                }
                if (cbx_download.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_download.Value.ToString());
                }

                //导入权限
                if (cbx_dr.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_dr.Value.ToString());
                }
                if (cbx_dr.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_dr.Value.ToString());
                }
                if (cbx_dr.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_dr.Value.ToString());
                }
                if (cbx_dr.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_dr.Value.ToString());
                }
                if (cbx_dr.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_dr.Value.ToString());
                }

                //导入权限
                if (cbx_dc.Checked == true && cbx_cc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cc.Value.ToString(), cbx_dc.Value.ToString());
                }
                if (cbx_dc.Checked == true && cbx_cbs.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_cbs.Value.ToString(), cbx_dc.Value.ToString());
                }
                if (cbx_dc.Checked == true && cbx_yj.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_yj.Value.ToString(), cbx_dc.Value.ToString());
                }
                if (cbx_dc.Checked == true && cbx_th.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_th.Value.ToString(), cbx_dc.Value.ToString());
                }
                if (cbx_dc.Checked == true && cbx_bc.Checked == true)
                {
                    flag = true;
                    js.Insert_JS_QX(jsdm, cbx_bc.Value.ToString(), cbx_dc.Value.ToString());
                }



                if (cbx_select.Checked == false && (cbx_add.Checked == true || cbx_edit.Checked == true || cbx_delete.Checked == true || cbx_sumbit.Checked == true || cbx_sh.Checked == true || cbx_bh.Checked == true || cbx_upload.Checked == true || cbx_download.Checked == true || cbx_dr.Checked == true || cbx_dc.Checked == true
                      || cbx_cc.Checked == true || cbx_cbs.Checked == true || cbx_yj.Checked == true || cbx_th.Checked == true || cbx_bc.Checked == true))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请选择查询权限！\")</script>");
                    return;
                }
                if (flag == true)
                {
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"分配权限成功！\")</script>");
                }
                else
                {
                    if (cbx_select.Checked == false && cbx_add.Checked == false && cbx_edit.Checked == false && cbx_delete.Checked == false && cbx_sumbit.Checked == false && cbx_sh.Checked == false && cbx_bh.Checked == false && cbx_upload.Checked == false && cbx_download.Checked == false && cbx_dr.Checked == false && cbx_dc.Checked == false
                        && cbx_cc.Checked == false && cbx_cbs.Checked == false && cbx_yj.Checked == false && cbx_th.Checked == false && cbx_bc.Checked == false)
                    { }
                    else
                    {
                        flag_succeed = false;
                        Label lbl_mc = (Label)rpItem.FindControl("lbl_mc");
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请选择权限或地区！\")</script>");
                        string ms = "请选择:" + lbl_mc.Text + "--相应的地区和权限";
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "提示", "<script>alert(" + "\"" + ms + "\"" + ")</script>");
                        break;
                    }


                }
            }
            if (flag_succeed == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"分配权限成功！\")</script>");
            }



        }
        //清除权限
        public void Delete_QXbyJS()
        {
            DataTable dt = js.Select_JSbyJSDM(jsdm);
            if (dt.Rows.Count > 0)
            {
                js.Delete_QXByJS(jsdm);
            }
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            Delete_QXbyJS();
            try
            {
                Add_QX();
                //SysData.ReSetJS_QX();

            }
            catch (Exception em)
            {
                throw em;
            }
        }

        #region 全选
        //长春全选\不选
        protected void btn_CC_Click(object sender, EventArgs e)
        {
            if (btn_CC.Text == "长春全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_cc = (HtmlInputCheckBox)rpItem.FindControl("cbx_cc");
                    cbx_cc.Checked = true;
                }
                btn_CC.Text = "长春全不选";
            }
            else if (btn_CC.Text == "长春全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_cc = (HtmlInputCheckBox)rpItem.FindControl("cbx_cc");
                    cbx_cc.Checked = false;
                }
                btn_CC.Text = "长春全选";
            }
        }

        //延吉全选\不选
        protected void btn_YJ_Click(object sender, EventArgs e)
        {
            if (btn_YJ.Text == "延吉全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_yj = (HtmlInputCheckBox)rpItem.FindControl("cbx_yj");
                    cbx_yj.Checked = true;
                }
                btn_YJ.Text = "延吉全不选";
            }
            else if (btn_YJ.Text == "延吉全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_yj = (HtmlInputCheckBox)rpItem.FindControl("cbx_yj");
                    cbx_yj.Checked = false;
                }
                btn_YJ.Text = "延吉全选";
            }
        }

        //长白山全选\不选
        protected void btn_CBS_Click(object sender, EventArgs e)
        {
            if (btn_CBS.Text == "长白山全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_cbs = (HtmlInputCheckBox)rpItem.FindControl("cbx_cbs");
                    cbx_cbs.Checked = true;
                }
                btn_CBS.Text = "长白山全不选";
            }
            else if (btn_CBS.Text == "长白山全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_cbs = (HtmlInputCheckBox)rpItem.FindControl("cbx_cbs");
                    cbx_cbs.Checked = false;
                }
                btn_CBS.Text = "长白山全选";
            }
        }

        //通化全选\不选
        protected void btn_TH_Click(object sender, EventArgs e)
        {
            if (btn_TH.Text == "通化全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_th = (HtmlInputCheckBox)rpItem.FindControl("cbx_th");
                    cbx_th.Checked = true;
                }
                btn_TH.Text = "通化全不选";
            }
            else if (btn_TH.Text == "通化全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_th = (HtmlInputCheckBox)rpItem.FindControl("cbx_th");
                    cbx_th.Checked = false;
                }
                btn_TH.Text = "通化全选";
            }
        }

        //白城全选\不选
        protected void btn_BCqx_Click(object sender, EventArgs e)
        {
            if (btn_BCqx.Text == "白城全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_bc = (HtmlInputCheckBox)rpItem.FindControl("cbx_bc");
                    cbx_bc.Checked = true;
                }
                btn_BCqx.Text = "白城全不选";
            }
            else if (btn_BCqx.Text == "白城全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_bc = (HtmlInputCheckBox)rpItem.FindControl("cbx_bc");
                    cbx_bc.Checked = false;
                }
                btn_BCqx.Text = "白城全选";
            }
        }

        //查询全选\不选
        protected void btn_CXquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_CXquanxuan.Text == "查询全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                    cbx_select.Checked = true;
                }
                btn_CXquanxuan.Text = "查询全不选";
            }
            else if (btn_CXquanxuan.Text == "查询全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_select = (HtmlInputCheckBox)rpItem.FindControl("cbx_select");
                    cbx_select.Checked = false;
                }
                btn_CXquanxuan.Text = "查询全选";
            }
        }

        //添加全选\不选
        protected void btn_TJquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_TJquanxuan.Text == "添加全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                    cbx_add.Checked = true;
                }
                btn_TJquanxuan.Text = "添加全不选";
            }
            else if (btn_TJquanxuan.Text == "添加全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_add = (HtmlInputCheckBox)rpItem.FindControl("cbx_add");
                    cbx_add.Checked = false;
                }
                btn_TJquanxuan.Text = "添加全选";
            }
        }

        //编辑全选\不选
        protected void btn_BJquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_BJquanxuan.Text == "编辑全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                    cbx_edit.Checked = true;
                }
                btn_BJquanxuan.Text = "编辑全不选";
            }
            else if (btn_BJquanxuan.Text == "编辑全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_edit = (HtmlInputCheckBox)rpItem.FindControl("cbx_edit");
                    cbx_edit.Checked = false;
                }
                btn_BJquanxuan.Text = "编辑全选";
            }
        }

        //删除全选\不选
        protected void btn_SCquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_SCquanxuan.Text == "删除全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                    cbx_delete.Checked = true;
                }
                btn_SCquanxuan.Text = "删除全不选";
            }
            else if (btn_SCquanxuan.Text == "删除全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_delete = (HtmlInputCheckBox)rpItem.FindControl("cbx_delete");
                    cbx_delete.Checked = false;
                }
                btn_SCquanxuan.Text = "删除全选";
            }
        }

        //提交全选\不选
        protected void btn_Submitqx_Click(object sender, EventArgs e)
        {
            if (btn_Submitqx.Text == "提交全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_sumbit = (HtmlInputCheckBox)rpItem.FindControl("cbx_sumbit");
                    cbx_sumbit.Checked = true;
                }
                btn_Submitqx.Text = "提交全不选";
            }
            else if (btn_Submitqx.Text == "提交全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_sumbit = (HtmlInputCheckBox)rpItem.FindControl("cbx_sumbit");
                    cbx_sumbit.Checked = false;
                }
                btn_Submitqx.Text = "提交全选";
            }
        }

        //审核全选\不选
        protected void btn_SHquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_SHquanxuan.Text == "审核全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_sh = (HtmlInputCheckBox)rpItem.FindControl("cbx_sh");
                    cbx_sh.Checked = true;
                }
                btn_SHquanxuan.Text = "审核全不选";
            }
            else if (btn_SHquanxuan.Text == "审核全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_sh = (HtmlInputCheckBox)rpItem.FindControl("cbx_sh");
                    cbx_sh.Checked = false;
                }
                btn_SHquanxuan.Text = "审核全选";
            }
        }

        //驳回全选\不选
        protected void btn_BHquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_BHquanxuan.Text == "驳回全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_bh = (HtmlInputCheckBox)rpItem.FindControl("cbx_bh");
                    cbx_bh.Checked = true;
                }
                btn_BHquanxuan.Text = "驳回全不选";
            }
            else if (btn_BHquanxuan.Text == "驳回全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_bh = (HtmlInputCheckBox)rpItem.FindControl("cbx_bh");
                    cbx_bh.Checked = false;
                }
                btn_BHquanxuan.Text = "驳回全选";
            }
        }

        //上传全选\不选
        protected void btn_Uploadqx_Click(object sender, EventArgs e)
        {
            if (btn_Uploadqx.Text == "上传全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_upload = (HtmlInputCheckBox)rpItem.FindControl("cbx_upload");
                    cbx_upload.Checked = true;
                }
                btn_Uploadqx.Text = "上传全不选";
            }
            else if (btn_Uploadqx.Text == "上传全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_upload = (HtmlInputCheckBox)rpItem.FindControl("cbx_upload");
                    cbx_upload.Checked = false;
                }
                btn_Uploadqx.Text = "上传全选";
            }
        }

        //下载全选\不选
        protected void btn_Downloadqx_Click(object sender, EventArgs e)
        {
            if (btn_Downloadqx.Text == "下载全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_download = (HtmlInputCheckBox)rpItem.FindControl("cbx_download");
                    cbx_download.Checked = true;
                }
                btn_Downloadqx.Text = "下载全不选";
            }
            else if (btn_Downloadqx.Text == "下载全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_download = (HtmlInputCheckBox)rpItem.FindControl("cbx_download");
                    cbx_download.Checked = false;
                }
                btn_Downloadqx.Text = "下载全选";
            }
        }

        //导入全选\不选
        protected void btn_DRquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_DRquanxuan.Text == "导入全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_dr = (HtmlInputCheckBox)rpItem.FindControl("cbx_dr");
                    cbx_dr.Checked = true;
                }
                btn_DRquanxuan.Text = "导入全不选";
            }
            else if (btn_DRquanxuan.Text == "导入全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_dr = (HtmlInputCheckBox)rpItem.FindControl("cbx_dr");
                    cbx_dr.Checked = false;
                }
                btn_DRquanxuan.Text = "导入全选";
            }
        }

        //导出全选\不选
        protected void btn_DCquanxuan_Click(object sender, EventArgs e)
        {
            if (btn_DCquanxuan.Text == "导出全选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_dc = (HtmlInputCheckBox)rpItem.FindControl("cbx_dc");
                    cbx_dc.Checked = true;
                }
                btn_DCquanxuan.Text = "导出全不选";
            }
            else if (btn_DCquanxuan.Text == "导出全不选")
            {
                foreach (RepeaterItem rpItem in rp_qxpz.Items)
                {
                    HtmlInputCheckBox cbx_dc = (HtmlInputCheckBox)rpItem.FindControl("cbx_dc");
                    cbx_dc.Checked = false;
                }
                btn_DCquanxuan.Text = "导出全选";
            }
        }
        #endregion
    }

}