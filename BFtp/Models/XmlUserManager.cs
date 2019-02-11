using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BFtp.Models
{
    public class XmlUserManager
    {
        public static User[] GetUsers()
        {
            UserList result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(UserList));
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                result = (UserList)serializer.Deserialize(fileStream);
            }

            return result.Users.ToArray();
        }
    }

    [XmlRoot("UserList")]
    public class UserList
    {
        [XmlElement("User")]
        public List<User> Users { get; set; }

    }

    [XmlRoot("Users")]
    public class User
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }
        [XmlElement("Password")]
        public string Password { get; set; }
        
    }

}