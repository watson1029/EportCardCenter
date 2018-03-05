using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// GetCopyTxt 的摘要说明
    /// </summary>
    public class GetCopyTxt : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string ListID = context.Request.Form["ListID"];
                Entity.NewlyAddedList entity = new DataAccess.NewlyAddedList().GetModel(ListID);
                XmlSerializer xs = new XmlSerializer(entity.GetType());
                MemoryStream ms = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
                xs.Serialize(writer, entity);
                writer.Close();
                context.Response.Write(Encoding.UTF8.GetString(ms.ToArray()));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}