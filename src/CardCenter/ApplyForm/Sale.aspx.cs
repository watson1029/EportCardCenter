using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class Sale : UserVerifyPage
    {
        public string fileHtml
        {
            get;
            set;
        }

        public string jobID
        {
            set;
            get;
        }

        public string type
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

        public void DataInit()
        {
            jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("jobID");
            type = ZWL.ObjectOperation.QueryStringHelper.GetQuery("type");
            hJobID.Value = jobID;

            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            repeater.DataSource = run.SaleJobList(CommonObject.LoginUserInfo.companyId).Tables[0];
            repeater.DataBind();
            if (!string.IsNullOrEmpty(jobID))
            {
                DataSet ds = run.JobView(jobID, "SaleList");
                if (ds.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    //2016-4-5
                    companyName.Value = ds.Tables[0].Rows[0]["EnterpriseName"].ToString();
                    companyAddress.Value = ds.Tables[0].Rows[0]["EnterpriseAddress"].ToString();
                    companyCode.Value = ds.Tables[0].Rows[0]["EnterpriseCode"].ToString();
                    if (companyCode.Value.Length == 18)
                        typeSelect.SelectedIndex = 1;
                    agentName.Value = ds.Tables[0].Rows[0]["AgentName"].ToString();
                    agentPhone.Value = ds.Tables[0].Rows[0]["AgentPhone"].ToString();
                    if (bool.Parse(ds.Tables[0].Rows[0]["ExpressFlat"].ToString()))
                    {
                        expressTrue.Checked = true;
                        expresssFalse.Checked = false;
                    }
                    else
                    {
                        expressTrue.Checked = false;
                        expresssFalse.Checked = true;
                    }
                    consigneeName.Value = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                    consigneePhone.Value = ds.Tables[0].Rows[0]["ConsigneePhone"].ToString();
                    consigneeAddress.Value = ds.Tables[0].Rows[0]["ConsigneeAddress"].ToString();
                    txtInvoiceName.Value = ds.Tables[0].Rows[0]["InvoiceName"].ToString();
                    txtInvoicePhone.Value = ds.Tables[0].Rows[0]["InvoicePhone"].ToString();
                    txtInvoiceAddress.Value = ds.Tables[0].Rows[0]["InvoiceAddress"].ToString();
                    txtInvoicePostCode.Value = ds.Tables[0].Rows[0]["InvoicePostCode"].ToString();
                    txtInvoiceEmail.Value = ds.Tables[0].Rows[0]["InvoiceEmail"].ToString();
                    txtInvoiceCode.Value = ds.Tables[0].Rows[0]["InvoiceCode"].ToString();
                    GetFileType(ds);
                    repeater1.DataSource = ds.Tables[1];
                    repeater1.DataBind();
                    DataTable jobDs = new DataAccess.SaleBinding().GetList("SaleID='" + jobID + "'").Tables[0];
                    if (jobDs.Rows.Count > 0)
                        hJobList.Value = jobDs.Rows[0]["JobID"].ToString();
                }
                else
                {
                    Response.Redirect("../Manager/JobList.aspx");
                }
            }
            else
            {
                GetFileType(null);
                ETGData();
                hJobList.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("bindid");
                agentName.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("name");
                agentPhone.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("phone");
                consigneeName.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("name");
                consigneePhone.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("phone");
                txtInvoiceName.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("name");
                txtInvoicePhone.Value = ZWL.ObjectOperation.QueryStringHelper.GetQuery("phone");
            }
        }

        private void GetFileType(DataSet viewDs)
        {
            DataAccess.RunProcedure procedure = new DataAccess.RunProcedure();
            DataSet ds = procedure.SelectFileTypeByJobType("SL");

            if (ds.Tables[0].Rows.Count > 0)
            {
                fileHtml = "<table class='table'><tr><td class='title' colspan='2'>工单随附资料</td></tr>";
                //表头附件
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string guid = string.Empty;
                    string fileName = string.Empty;
                    if (viewDs != null)
                    {
                        DataRow[] fileDr = viewDs.Tables[2].Select("ListID = ''");
                        foreach (DataRow file in fileDr)
                        {
                            if (file["FileTypeName"].ToString() == dr["FileTypeName"].ToString())
                            {
                                guid = file["Guid"].ToString();
                                fileName = file["FileName"].ToString();
                                break;
                            }
                        }
                    }
                    fileHtml += string.Format("<tr><td class='title'>{0}</td><td class='content'><span><input type='file' id='{1}' name='{1}' runat='server'/><input type='hidden' id='txt{1}' name='txt{1}' value='{2}' runat='server'/><input type='hidden' runat='server' id='h{1}' name='h{1}' value='{3}'/></span></td></tr>", dr["FileTypeName"], dr["FileTypeID"], fileName, guid);
                }
                fileHtml += "</table>";
            }

            //表体附件
            if (viewDs != null)
            {
                foreach (DataRow list in viewDs.Tables[1].Rows)
                {
                    DataSet listFile = procedure.SelectFileTypeByJobType(list["JobTypeID"].ToString());
                    if (listFile.Tables[0].Rows.Count > 0)
                    {
                        fileHtml += "<br clear='all' /><table class='table' id='file" + list["ListID"] + "'><tr><td class='title' colspan='2'>工单项随附资料【业务类型：" + list["JobName"] + "，持卡人姓名：" + list["CardholderName"] + "】</td></tr>";
                        DataRow[] listDr = viewDs.Tables[2].Select("ListID = '" + list["ListID"] + "'");
                        foreach (DataRow dr in listFile.Tables[0].Rows)
                        {
                            string guid = string.Empty;
                            string fileName = string.Empty;
                            foreach (DataRow file in listDr)
                            {
                                if (file["FileTypeName"].ToString() == dr["FileTypeName"].ToString())
                                {
                                    guid = file["Guid"].ToString();
                                    fileName = file["FileName"].ToString();
                                    break;
                                }
                            }
                            fileHtml += string.Format("<tr><td class='title'>{0}</td><td class='content'><span><input type='file' id='{1}{4}' name='{1}{4}' runat='server'/><input type='hidden' id='txt{1}{4}' name='txt{1}{4}' value='{2}' runat='server'/><input type='hidden' runat='server' id='h{1}{4}' name='h{1}{4}' value='{3}'/></span></td></tr>", dr["FileTypeName"], dr["FileTypeID"], fileName, guid, list["ListID"]);
                        }
                        fileHtml += "</table>";
                    }
                }
            }
        }

        private void ETGData()
        {
            try
            {
                CompanyAllData data = CommonObject.LoginCompanyInfo;
                companyName.Value = data.FULL_NAME;
                companyAddress.Value = data.ADDR_CO;
                typeSelect.Value = "1";
                companyCode.Value = data.COP_GB_CODE;
                consigneeAddress.Value = data.ADDR_CO;
                txtInvoiceAddress.Value = data.ADDR_CO;
            }
            catch
            {
                return;
            }
        }

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                string jobid = drv.Row.ItemArray[0].ToString();
                HtmlInputCheckBox cb = e.Item.FindControl("cbIsBind") as HtmlInputCheckBox;
                DataTable dt = new DataAccess.SaleBinding().GetList(string.Format("SaleID='{0}' and JobID like '%{1}%'", jobID, jobid)).Tables[0];
                if (dt.Rows.Count > 0)
                    cb.Checked = true;
                else
                {
                    if (jobid == ZWL.ObjectOperation.QueryStringHelper.GetQuery("bindid"))
                        cb.Checked = true;
                }
            }
        }
    }
}