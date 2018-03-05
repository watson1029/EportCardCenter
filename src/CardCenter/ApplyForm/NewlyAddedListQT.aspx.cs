using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class NewlyAddedListQT : PageBase.UserVerifyPage
    {
        public string listID
        {
            set;
            get;
        }

        public string jobID
        {
            set;
            get;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitSelect();
                DataInit();
            }
        }

        private void DataInit()
        {
            listID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("listID");
            jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("jobID");
            hJobID.Value = jobID;
            hListID.Value = listID;

            if (!string.IsNullOrEmpty(listID))
            {
                Entity.NewlyAddedList na = new DataAccess.NewlyAddedList().GetModel(listID);
                businessType.Value = na.JobType == "NA003" || na.JobType == "NA005" || na.JobType == "NA007" ? "1" : "0";
                cardType.Value = Convert.ToInt32((Entity.Enum.CardType)Enum.Parse(typeof(Entity.Enum.CardType), na.CardType)).ToString();
                holdName.Value = na.CardholderName;
                txtCardholderPhone.Value = na.CardholderPhone;
                holdIDType.Value = na.CardholderIdentificationType.ToString();
                holdID.Value = na.CardholderIdentificationNum;
            }
        }

        private void InitSelect()
        {
            DataTable dt = new DataAccess.Para_IdentificationType().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                holdIDType.Items.Add(new ListItem(dr["ID"].ToString() + dr["Name"].ToString(), dr["ID"].ToString()));
            }
        }
    }
}