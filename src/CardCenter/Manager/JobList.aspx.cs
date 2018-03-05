using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class JobList : PageBase.UserVerifyPage
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
            repeater.DataSource = pro.ManagerList(LoginUserInfo.companyId);
            repeater.DataBind();
        }

        public string BindEdit(string jobID, string jobType)
        {
            string url = string.Empty;
            switch (jobType)
            {
                case "UU":
                    url = "../ApplyForm/UpdateUnlock.aspx?jobID=" + jobID + "&type=update";
                    break;
                case "MD":
                    url = "../ApplyForm/Modify.aspx?jobID=" + jobID + "&type=update";
                    break;
                case "NA":
                    url = "../ApplyForm/NewlyAdded.aspx?jobID=" + jobID + "&type=update";
                    break;
                case "RI":
                    url = "../ApplyForm/ReIssue.aspx?jobID=" + jobID + "&type=update";
                    break;
                case "RM":
                    url = "../ApplyForm/ReMake.aspx?jobID=" + jobID + "&type=update";
                    break;
                case "SL":
                    url = "../ApplyForm/Sale.aspx?jobID=" + jobID + "&type=update";
                    break;
                default:
                    url = "#";
                    break;
            }
            return "&nbsp;&nbsp;<a href='" + url + "'>修改</a>";
        }

        public string BindDelete()
        {
            return "&nbsp;&nbsp;<a href='#' onclick='deleteClick(this)'>删除</a>";
        }

        public string BindCompleteApproval()
        {
            return "&nbsp;&nbsp;<a href='#' onclick='completeClick(this)'>完成审批</a>";
        }

        public string BindFeeButton(string jobID)
        {
            return "&nbsp;&nbsp;<a target='_blank' href='Pay.aspx?jobID=" + jobID + "'>网上支付</a>";
        }
    }
}