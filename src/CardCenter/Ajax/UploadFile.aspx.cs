using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Ajax
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;
            string msg = string.Empty;
            string error = string.Empty;
            string res = null;
            if (files.Count > 0)
            {
                //文件名称
                string fileName = files[0].FileName;
                //添加一个唯一标识
                string guid = System.Guid.NewGuid().ToString();
                //根据日期新建一个文件夹的路径
                string rootUrl = Server.MapPath("~/UploadFile/");
                //获取文件的类型
                string fileExtsName = fileName.Substring(fileName.LastIndexOf("."));
                string[] fileexts = ZWL.GeneralHelper.GetSettingByKey("FileExts").Split(',');
                bool allow = false;
                foreach(string exts in fileexts)
                {
                    if (fileExtsName.ToUpper() == exts)
                    {
                        allow = true;
                        break;
                    }
                }
                if (!allow)
                    error = "文件类型只允许上传" + ZWL.GeneralHelper.GetSettingByKey("FileExts") + "格式!";
                else
                {
                    //判断文件夹是否存在,不存在的话新建一个文件夹存放当天的文件
                    if (!Directory.Exists(rootUrl))
                    {
                        Directory.CreateDirectory(rootUrl);
                    }
                    //保存文件的全路径
                    string filePath = rootUrl + guid + fileExtsName;
                    files[0].SaveAs(filePath);
                    msg = " 成功! 文件大小为:" + files[0].ContentLength;
                }
                res = "{ error:'" + error + "', msg:'" + msg + "', filename:'" + fileName + "', guid:'" + guid + fileExtsName + "'}";
                Response.Write(res);
                Response.End();
            }
        }
    }
}