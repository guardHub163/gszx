using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Xml.Linq;

namespace CZZD.GSZX.P.UI
{
    public class XmlHelp
    {
        public static string gszxSalesInterval = ReadXmlFiles("GSZX_PRINT_INTERVAL_TIME");

        public static XmlDocument doc = new XmlDocument();

        /// <summary>
        /// read xml files 
        /// </summary>
        public static string ReadXmlFiles(string notename)
        {
            string strNoteValue = "";
            try
            {
                if (File.Exists("GSZX.xml"))
                {
                    if (doc == null || doc.ChildNodes.Count == 0)
                    {
                        doc = new XmlDocument();
                        Module myModal = typeof(XmlHelp).Module; ;
                        doc.Load(myModal.FullyQualifiedName.Replace(myModal.Name, "GSZX.xml"));
                    }
                    XmlNodeList nodelist = doc.GetElementsByTagName(notename);
                    strNoteValue = nodelist[0].InnerText;
                }
                else
                {


                }
            }
            catch (Exception ex)
            {
            }
            return strNoteValue;
        }

        /// <summary>
        /// read curretn xml files 
        /// </summary>
        public static string ReadCurrentXmlFiles(string notename)
        {
            string strNoteValue = "";
            try
            {
                if (File.Exists("GSZX.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    Module myModal = typeof(XmlHelp).Module; ;
                    doc.Load(myModal.FullyQualifiedName.Replace(myModal.Name, "GSZX.xml"));
                    XmlNodeList nodelist = doc.GetElementsByTagName(notename);
                    strNoteValue = nodelist[0].InnerText;
                }
                else
                {


                }
            }
            catch (Exception ex)
            {
                
            }
            return strNoteValue;
        }

        /// <summary>
        ///  update curretn xml files 
        /// </summary>
        public static void UpdateCurrentXmlFiles(string xmlNode, string value)
        {
            try
            {
                if (File.Exists("GSZX.xml"))
                {
                    FileInfo fi = new FileInfo("GSZX.xml");
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    XDocument doc = XDocument.Load("GSZX.xml");
                    doc.Element("CsvSetting").Element(xmlNode).SetValue(value);
                    doc.Save("GSZX.xml");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }//end class
}
