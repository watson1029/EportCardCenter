using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardCenter.PageBase
{
    public class CommonControlBase : System.Web.UI.UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        public void Alert(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "msgscript", "<script>alert('" + message + "')</script>");
        }
        public void Alert(string message, string Url)
        {
            if (string.IsNullOrEmpty(message))
                return;
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "Alert_" + Guid.NewGuid().ToString(), "<script>alert('" + message + "');window.location.href='" + Url + "';</script>");
        }

        protected string UrlBase
        {
            get
            {
                return CommonObject.UrlBase;
            }
        }

        protected UserInfoEntity LoginUserInfo
        {
            get
            {
                return CommonObject.LoginUserInfo;
            }
            set
            {
                CommonObject.LoginUserInfo = value;
            }
        }

        protected CompanyAllData LoginCompanyInfo
        {
            get
            {
                return CommonObject.LoginCompanyInfo;
            }
            set
            {
                CommonObject.LoginCompanyInfo = value;
            }
        }

        protected string AllowUploadFileType
        {
            get
            {
                return CommonObject.AllowUploadFileType;
            }
        }

        protected string PageName
        {
            get
            {
                return CommonObject.PageName;
            }
        }

    }
}
