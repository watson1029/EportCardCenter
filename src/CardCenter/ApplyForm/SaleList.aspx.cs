using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class SaleList : PageBase.UserVerifyPage
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

        public Entity.Stock_Commodity cObj
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cObj = new Entity.Stock_Commodity();
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
                Entity.SaleList sl = new DataAccess.SaleList().GetModel(listID);
                cObj = new DataAccess.Stock_Commodity().GetEntity(sl.ProductType);
                txtNum.Value = sl.Num.ToString();
            }
        }
    }
}