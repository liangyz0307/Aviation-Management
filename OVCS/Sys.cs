using CUST;
using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace OVCS
{
    class Sys
    {
        #region  =====系统参数初始化=======
        private static string _connectionString = StrConvert.DecodeBase64(ReadXMLConfig("connectionString"));
        protected string _userLoginName;          //用户账号
        protected string _userPassword;           //用户密码
        #endregion

        public Sys()
        { }
        #region  =====系统属性=======
        public static string connectionString
        {
            get
            {
                return _connectionString;
            }
        }
        #endregion

        public static void ReSetValue()
        {
            lock (typeof(Sys))
            {
                #region  =====系统参数重置=======
                _connectionString = StrConvert.DecodeBase64(ReadXMLConfig("connectionString"));
                #endregion
            }
        }
        private static string ReadXMLConfig(string sKey)
        {
            XmlDocument oXmlDocument = new XmlDocument();
            string _strFileName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "#Sys.config";
            string strReturn = "";
            try
            {
                oXmlDocument.Load(_strFileName);
                XmlNodeList oXmlNodeList = oXmlDocument.DocumentElement.ChildNodes;
                foreach (XmlElement oXmlElement in oXmlNodeList)
                {
                    if (oXmlElement.Name.ToLower() == "appsettings")
                    {
                        XmlNodeList _node = oXmlElement.ChildNodes;
                        if (_node.Count > 0)
                        {
                            foreach (XmlElement _el in _node)
                            {
                                if (_el.Attributes["key"].InnerXml.ToLower() == sKey.ToLower())
                                {
                                    strReturn = _el.Attributes["value"].Value;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            return strReturn;
        }

        ////校验用户密码
        //private bool checkusermm(string loginname, string pwd)
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras = {
        //                    new OracleParameter("p_zh", OracleType.VarChar),
        //                    new OracleParameter("p_mm", OracleType.VarChar),
        //                    new OracleParameter("p_cur", OracleType.Cursor)
        //                };
        //        paras[0].Value = loginname;
        //        paras[1].Value = CUST.Tools.StrConvert.GetMD5(pwd);//密码MD5加密
        //        paras[2].Direction = ParameterDirection.Output;

        //        DataSet ds = db.RunProcedure("PACK_WEB_SYS.YH_Check", paras, "YHCheck");
        //        if (ds.Tables["YHCheck"].Rows.Count > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}


    }
}
