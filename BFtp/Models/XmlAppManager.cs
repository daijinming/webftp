using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BFtp.Models
{
    public class XmlAppManager
    {


        public static AppList GetApps()
        {
            AppList result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(AppList));
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Apps.xml");

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                result = (AppList)serializer.Deserialize(fileStream);
            }

            return result;
        }

    }


    [XmlRoot("AppList")]
    public class AppList
    {
        [XmlElement("App")]
        public List<App> Apps { get; set; }

    }
    [XmlRoot("Apps")]
    public class App
    {
        [XmlElement("User")]
        public string User { get; set; }
        

        [XmlElement("Code")]
        public string Code { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Path")]
        public string Path { get; set; }


    }


}