using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class ModifyList : PageBase.UserVerifyPage
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
                Entity.ModifyList md = new DataAccess.ModifyList().GetModel(listID);
                businessType.Value = md.JobType == "MD001" || md.JobType == "MD003" || md.JobType == "MD005" ? "1" : "0";
                cardType.Value = Convert.ToInt32((Entity.Enum.CardType)Enum.Parse(typeof(Entity.Enum.CardType), md.CardType)).ToString();
                txtCardNum.Value = md.CardNum;
                holdName.Value = md.CardholderName;
                changeName.Checked = md.IsChangeName;
            }
        }
    }
}