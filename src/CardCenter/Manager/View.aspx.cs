using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class View : UserVerifyPage
    {
        public DataSet viewDt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobID");
                if (jobID == null)
                    Response.Redirect("/Manager/JobList.aspx", false);
                else
                    DataInit(jobID);
            }
        }

        private void DataInit(string jobID)
        {
            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            string dbName = run.GetListDbName(jobID);
            if (string.IsNullOrEmpty(dbName))
                Alert("获取数据失败!");
            else
            {
                viewDt = run.JobView(jobID, dbName);
                if (viewDt.Tables[0].Rows[0]["JobType"].ToString() == "SL")
                {
                    repeater.DataSource = run.SaleJobListView(jobID).Tables[0];
                    repeater.DataBind();
                }
            }
        }
    }
}