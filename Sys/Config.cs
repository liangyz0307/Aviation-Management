using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sys
{
    public class Config
    {
        #region  =====系统参数初始化=======
        private static string _connectionString = StrConvert.DecodeBase64(ReadXMLConfig("connectionString"));

        #endregion

        public Config()
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
            lock (typeof(Config))
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
    }
}
