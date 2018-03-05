using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace CardCenter.Management.Manager
{
    public partial class View : PageBase.UserVerifyPageManager
    {
        public DataSet viewDt;
        public DataTable handleDt = new DataAccess.RunProcedure().GetHandleListByJobID(ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobID")).Tables[0];
        public string jobID
        {
            get { return ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobID"); }
        }

        public string jobType
        {
            get { return ZWL.ObjectOperation.QueryStringHelper.GetQuery("JobType"); }
        }

        public string type
        {
            get { return ZWL.ObjectOperation.QueryStringHelper.GetQuery("type"); }
        }

        public string xmlFR
        {
            get;
            set;
        }

        public string xmlInvoice
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (jobID == null || jobType == null || type == null)
                    Response.Redirect("/Manager/JobList.aspx", false);
                else
                {
                    DataInit(jobID);
                }
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
                repeater1.DataSource = run.GetHandleListByJobID(jobID).Tables[0];
                repeater1.DataBind();
                if (viewDt.Tables[0].Rows[0]["JobType"].ToString().Equals("SL"))
                {
                    if (type.Equals("view"))
                    {
                        thCheck.Visible = false;
                        repeater.DataSource = run.SaleJobListView(jobID).Tables[0];
                        repeater.DataBind();
                    }
                    else
                    {
                        statusRepeater.DataSource = viewDt.Tables[1];
                        statusRepeater.DataBind();
                        repeater.DataSource = run.SaleJobList(viewDt.Tables[0].Rows[0]["CreateUser"].ToString()).Tables[0];
                        repeater.DataBind();
                    }
                    showStatusRepeater.DataSource = viewDt.Tables[1];
                    showStatusRepeater.DataBind();
                }
            }
            InitInvoiceMsg(viewDt.Tables[0]);
            InitFRMsg(viewDt.Tables[1]);
        }

        protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.HtmlControls.HtmlSelect select = (e.Item.FindControl("selectOperation") as System.Web.UI.HtmlControls.HtmlSelect);
                select.Value = ((DataRowView)e.Item.DataItem).Row["OperationSign"].ToString();
                System.Web.UI.HtmlControls.HtmlGenericControl span = (System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("remark"));
                if (jobType == "SL")
                    span.InnerText = "（产品类型：" + ((DataRowView)e.Item.DataItem).Row["ProductType"].ToString() + "，产品数量：" + ((DataRowView)e.Item.DataItem).Row["Num"].ToString() + "）";
                else
                    span.InnerText = "（持卡人姓名：" + ((DataRowView)e.Item.DataItem).Row["CardholderName"].ToString() + "）";
            }
        }

        private void InitFRMsg(DataTable dt)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["JobTypeID"].ToString() == "NA001")
                    {
                        Entity.NewlyAddedListFR entity = new DataAccess.NewlyAddedListFR().GetModel(dr["ListID"].ToString());
                        XmlSerializer xs = new XmlSerializer(entity.GetType());
                        MemoryStream ms = new MemoryStream();
                        XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
                        xs.Serialize(writer, entity);
                        writer.Close();
                        xmlFR = Encoding.UTF8.GetString(ms.ToArray()).Replace("\'", "\\'");
                        break;
                    }
                }
            }
            catch
            {
                xmlFR = null;
                return;
            }
        }

        private void InitInvoiceMsg(DataTable dt)
        {
            try
            {
                Entity.InvoiceData entity = new Entity.InvoiceData();
                entity.InvoiceName = dt.Rows[0]["InvoiceName"].ToString();
                entity.InvoicePhone = dt.Rows[0]["InvoicePhone"].ToString();
                entity.InvoiceAddress = dt.Rows[0]["InvoiceAddress"].ToString();
                entity.InvoicePostCode = dt.Rows[0]["InvoicePostCode"].ToString();
                entity.InvoiceCode = dt.Rows[0]["InvoiceCode"].ToString();
                entity.InvoiceEmail = dt.Rows[0]["InvoiceEmail"].ToString();
                entity.InvoiceEnterpriseName = dt.Rows[0]["EnterpriseName"].ToString();
                entity.InvoiceEnterpriseCode = dt.Rows[0]["EnterpriseCode"].ToString();

                XmlSerializer xs = new XmlSerializer(entity.GetType());
                MemoryStream ms = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
                xs.Serialize(writer, entity);
                writer.Close();
                xmlInvoice = Encoding.UTF8.GetString(ms.ToArray()).Replace("\'", "\\'");
            }
            catch
            {
                xmlInvoice = null;
                return;
            }
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

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (type.Equals("view"))
                {
                    HtmlTableCell td = e.Item.FindControl("tdCheck") as HtmlTableCell;
                    td.Visible = false;
                }
                else if (type.Equals("edit"))
                {
                    DataRowView drv = (DataRowView)e.Item.DataItem;
                    string jobid = drv.Row.ItemArray[0].ToString();
                    DataTable dt = new DataAccess.SaleBinding().GetList(string.Format("SaleID='{0}' and JobID like '%{1}%'", jobID, jobid)).Tables[0];
                    HtmlInputCheckBox cb = e.Item.FindControl("cbIsBind") as HtmlInputCheckBox;
                    if (dt.Rows.Count > 0)
                        cb.Checked = true;
                }
            }
        }

        protected void statusRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                string flag = drv.Row.ItemArray[6].ToString();
                HtmlSelect sl = e.Item.FindControl("statusSelect") as HtmlSelect;
                sl.Value = flag;
                //if (type.Equals("view"))
                //{
                //    HtmlTableCell td = e.Item.FindControl("tdCheck") as HtmlTableCell;
                //    td.Visible = false;
                //}
                //else if (type.Equals("edit"))
                //{
                //    DataRowView drv = (DataRowView)e.Item.DataItem;
                //    string jobid = drv.Row.ItemArray[0].ToString();
                //    DataTable dt = new CardPrinting.DataAccess.SaleBinding().GetList(string.Format("SaleID='{0}' and JobID like '%{1}%'", jobID, jobid)).Tables[0];
                //    HtmlInputCheckBox cb = e.Item.FindControl("cbIsBind") as HtmlInputCheckBox;
                //    if (dt.Rows.Count > 0)
                //        cb.Checked = true;
                //}
            }
        }

        protected void showStatusRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                string flag = drv.Row.ItemArray[6].ToString();
                HtmlSelect sl = e.Item.FindControl("statusSelect") as HtmlSelect;
                sl.Value = flag;
                //sl.Disabled = true;
            }
        }

        public string AuthorizeJudge(string setting, string functionId)
        {
            bool IsAuthorize = false;
            string[] roles = PageBase.CommonObject.ManagerUserInfo.role.Split('#');
            if (setting == "False")
            {
                if (PageBase.CommonObject.ManagerUserInfo.isSuperUser)
                    IsAuthorize = true;
                else
                {
                    foreach (string roleid in roles)
                    {
                        if (!string.IsNullOrEmpty(roleid))
                        {
                            Entity.Sys_Role role = new DataAccess.Sys_Role().GetModel(int.Parse(roleid));
                            if (role.FunctionAuthorize.IndexOf(functionId) >= 0)
                            {
                                IsAuthorize = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (IsAuthorize)
                return string.Empty;
            else
                return "disabled = 'disabled'";
        }

        public string SetCheckStatus(string IsChecked)
        {
            if (IsChecked == "True")
                return "checked='checked'";
            else
                return string.Empty;
        }
    }
}