using System;
using System.Web;
using System.Web.UI.WebControls; 

namespace CardCenter.PageBase
{
    public class CommonPageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 
        }

        public void Alert(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            this.ClientScript.RegisterStartupScript(this.GetType(), "msgscript", "<script>jAlert('" + message + "', '提示')</script>");
        }

        public void ExcuteJSFuntion(string fun)
        {
            if (string.IsNullOrEmpty(fun))
                return;
            this.ClientScript.RegisterStartupScript(this.GetType(), "msgscript", "<script>" + fun + "</script>");
        }

        public void Alert(string message, string Url)
        {
            if (string.IsNullOrEmpty(message))
                return;
            ClientScript.RegisterStartupScript(typeof(string), "Alert_" + Guid.NewGuid().ToString(), "<script>jAlert('" + message + "', '提示');window.location.href='" + Url + "';</script>");
        }

        protected string GetEndTime(object endTime)
        {
            if (!WebHelper.IsDateTime(endTime))
                return string.Empty;

            DateTime endDateTime = Convert.ToDateTime(endTime);
            TimeSpan ts = new TimeSpan(endDateTime.Ticks);
            int days = (new TimeSpan(DateTime.Now.Ticks)).Subtract(ts).Duration().Days;

            if (days < 0)
            {
                return "-" + days + "天";
            }
            if (days == 0)
            {
                return "今天";
            }
            else
            {
                return days + "天";
            }
        }

        public string UrlBase
        {
            get
            {
                return CommonObject.UrlBase;
            }
        }

        protected string CurrentUrl
        {
            get
            {
                return CommonObject.CurrentUrl;
            }
        }

        protected ManagerUserEntity ManagerUserInfo
        {
            get
            {
                return CommonObject.ManagerUserInfo;
            }
            set
            {
                CommonObject.ManagerUserInfo = value;
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
