using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class SearchView : System.Web.UI.Page
    {
        public DataSet viewDt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobID");
                if (jobID == null)
                    Response.Redirect("/Manager/Search.aspx", false );
                else
                    DataInit(jobID);
            }
        }

        private void DataInit(string jobID)
        {
            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            string dbName = run.GetListDbName(jobID);
            viewDt = run.JobView(jobID, dbName);
        }
    }
}