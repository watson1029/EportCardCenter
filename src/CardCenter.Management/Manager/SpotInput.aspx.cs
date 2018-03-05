using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
    public partial class SpotInput : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataAccess.Para_JobType().GetList("JobTypeParent is NULL");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    jobSelect.Items.Add(new ListItem(dr["JobName"].ToString(), dr["JobTypeID"].ToString()));
                }
            }
        }
    }
}