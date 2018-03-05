using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
    public partial class JobList : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        private void DataBind()
        {
            DataAccess.RunProcedure pro = new DataAccess.RunProcedure();
            //repeater.DataSource = pro.ManagerList(CardPrinting.PageBase.CommonObject.ManagerUserInfo.department.ToString());
            repeater.DataSource = pro.ManagerList("").Tables[0].Select(string.Format("CreateTime>'{0}'", DateTime.Now.AddDays(-15)));
            repeater.DataBind();
        }

        public string BindEdit(string jobID, string jobType)
        {
            string url = string.Empty;
            if (jobType != "UU" && jobType != "MD" && PageBase.CommonObject.ManagerUserInfo.department != 1)
                return "";
            else
            {
                url = "View.aspx?jobID=" + jobID + "&jobType=" + jobType + "&type=edit";
                return "&nbsp;&nbsp;<a href='" + url + "' target='_blank'>处理</a>";
            }
        }

        public string BindFeeButton(string jobID)
        {
            return "&nbsp;&nbsp;<a target='_blank' href='Pay.aspx?jobID=" + jobID + "'>网上支付</a>";
        }
    }
}