using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Xml.Linq;

namespace CZZD.GSZX.S.Common
{
    public class XmlHelp
    {
        /// <summary>
        /// read *.xml files 
        /// </summary>
        /// <returns></returns>
        public static string ReadXmlFile(string filePath, string notename)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "config.xml";
            }

            string strNoteValue = "";
            try
            {
                if (File.Exists(filePath))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNodeList nodelist;
                    Module myModal = typeof(XmlHelp).Module; ;
                    doc.Load(myModal.FullyQualifiedName.Replace(myModal.Name, filePath));
                    nodelist = doc.GetElementsByTagName(notename);
                    strNoteValue = nodelist[0].InnerText;
                }
            }
            catch (Exception ex)
            {
            }
            return strNoteValue;
        }

        /// <summary>
        /// read config.xml files 
        /// </summary>
        /// <returns></returns>
        public static string ReadXmlFile(string noteName)
        {
            string filePath = "config.xml";
            string strNoteValue = "";
            try
            {
                if (File.Exists(filePath))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNodeList nodelist;
                    Module myModal = typeof(XmlHelp).Module; ;
                    doc.Load(myModal.FullyQualifiedName.Replace(myModal.Name, filePath));
                    nodelist = doc.GetElementsByTagName(noteName);
                    strNoteValue = nodelist[0].InnerText;
                }
            }
            catch (Exception ex)
            {
            }
            return strNoteValue;
        }

        /// <summary>
        ///  update *.xml files 
        /// </summary>
        public static void UpdateXmlFile(string filePath, string parentNode, string childNode, string grandsonNode, string value)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "config.xml";
            }

            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    XDocument doc = XDocument.Load(filePath);
                    doc.Element(parentNode).Element(childNode).Element(grandsonNode).SetValue(value);
                    doc.Save(filePath);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        ///  update *.xml files 
        /// </summary>
        public static void UpdateXmlFile(string filePath, string parentNode, string childNode, string value)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "config.xml";
            }

            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    XDocument doc = XDocument.Load(filePath);
                    doc.Element(parentNode).Element(childNode).SetValue(value);
                    doc.Save(filePath);
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        ///  update *.xml files 
        /// </summary>
        public static void UpdateXmlFile(string filePath, string parentNode, string value)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "config.xml";
            }

            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    XDocument doc = XDocument.Load(filePath);
                    doc.Element(parentNode).SetValue(value);
                    doc.Save(filePath);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }//end class
}
