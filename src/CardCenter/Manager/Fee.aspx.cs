using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class Fee : PageBase.UserVerifyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobID");
                if (jobID == null)
                    Response.Redirect("/Manager/JobList.aspx", false);
                else
                {
                    DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                    DataSet ds = null;
                    string dbName = run.GetListDbName(jobID);
                    if (string.IsNullOrEmpty(dbName))
                        Alert("获取数据失败!");
                    else
                        ds = run.JobView(jobID, dbName);
                    //根据实际情况调用
                    LoadPage(ds.Tables[0]);
                }
            }
        }
        private DataSet DataInit(string jobID)
        {
            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            string dbName = run.GetListDbName(jobID);
            if (string.IsNullOrEmpty(dbName))
            {
                Alert("获取数据失败!");
                return null;
            }
            else
                return run.JobView(jobID, dbName);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="dt"></param>
        private void LoadPage(DataTable dt)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        DataRow dr = dt.Rows[0];
                       // this.lblHandlingFee2.Text = dr["HandlingFee"].ToString();
                       // this.lblHandlingFee.Text = dr["HandlingFee"].ToString();
                        this.lblJobID.Text = dr["JobID"].ToString();
                       // this.lblJobID0.Text = dr["JobID"].ToString();
                        this.lblCostFee.Text = dr["Fee"].ToString();
                        this.lblCostFee2.Text = dr["Fee"].ToString();
                    }
                    catch (Exception ex)
                    {

                        lblMsg.Text = ex.Message;
                    }

                }
            }
        }
    }
}