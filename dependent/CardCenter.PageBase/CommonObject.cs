using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace CardCenter.PageBase
{
    public class CommonObject
    {
        public static string _Port
        {
            get
            {
                if (HttpContext.Current.Request.Url.Port == 80)
                    return string.Empty;
                return ":" + HttpContext.Current.Request.Url.Port;
            }
        }
        public static String UrlSuffix
        {
            get
            {
                return HttpContext.Current.Request.Url.Host + _Port + (HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath);
            }
        }
        public static string UrlBase
        {
            get
            {
                return @"http://" + UrlSuffix;
            }
        }
        public static string strUrlBase
        {
            get
            {
                return "http://" + HttpContext.Current.Request.Url.Host + _Port + HttpContext.Current.Request.ApplicationPath;
            }
        }

        public static string CurrentUrl
        {
            get
            {
                return HttpContext.Current.Request.RawUrl;
            }
        }

        public static string PageName
        {
            get
            {
                string path = HttpContext.Current.Request.Path;
                return path.IndexOf('/') == -1 ? path : path.Substring(path.LastIndexOf('/') + 1);
            }
        }

        public static void BindDropDownList(DropDownList drop, Type en)
        {
            drop.DataSource = WebHelper.ListEnum(en);
            drop.DataTextField = WebHelper._Text;
            drop.DataValueField = WebHelper._Value;
            drop.DataBind();

            drop.Items.Insert(0, new ListItem("--请选择--", string.Empty));
        }

        public static ManagerUserEntity ManagerUserInfo
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["ManagerUserEntity"] as ManagerUserEntity;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["ManagerUserEntity"] = value;
            }
        }

        public static UserInfoEntity LoginUserInfo
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["UserInfoEntity"] as UserInfoEntity;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["UserInfoEntity"] = value;
            }
        }

        public static CompanyAllData LoginCompanyInfo
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["CompanyAllData"] as CompanyAllData;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["CompanyAllData"] = value;
            }
        }

        public static string AllowUploadFileType
        {
            get
            {
                return "*.doc;*.docx;*.xls;*.xlsx;*.txt;*.pdf;*.rar;*.zip;*.jpg;*.jpge;*.gif;*.png;*.bmp";
            }
        }
    }
}
