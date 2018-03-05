using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class ReIssue : UserVerifyPage
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

            if (!string.IsNullOrEmpty(jobID))
            {
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet ds = run.JobView(jobID, "ReIssueList");
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
                    GetFileType(ds);
                    repeater1.DataSource = ds.Tables[1];
                    repeater1.DataBind();
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
            }
        }

        private void GetFileType(DataSet viewDs)
        {
            DataAccess.RunProcedure procedure = new DataAccess.RunProcedure();
            DataSet ds = procedure.SelectFileTypeByJobType("RI");

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
            }
            catch
            {
                return;
            }
        }
    }
}