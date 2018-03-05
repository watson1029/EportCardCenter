using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class UpdateUnlockList : PageBase.UserVerifyPage
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
                Entity.UpdateUnlockList uu = new DataAccess.UpdateUnlockList().GetModel(listID);
                businessType.Value = uu.JobType == "UU001" || uu.JobType == "UU002" || uu.JobType == "UU003" || uu.JobType == "UU004" ? "0" : "1";
                cardType.Value = Convert.ToInt32((Entity.Enum.CardType)Enum.Parse(typeof(Entity.Enum.CardType), uu.CardType)).ToString();
                txtCardNum.Value = uu.CardNum;
                holdName.Value = uu.CardholderName;
            }
        }
    }
}