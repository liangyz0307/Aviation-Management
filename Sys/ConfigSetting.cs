using System.Xml;

namespace Sys
{
    public class ConfigSetting
    {
        string strFileName;

        public ConfigSetting(string filepath)
        {
            strFileName = filepath;
        }
        public string Set(string sKey, string sValue)
        {
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load(strFileName);
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
                                    _el.Attributes["value"].Value = sValue;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return "";
            }
            oXmlDocument.Save(strFileName);
            return sValue;
        }
    }
}
