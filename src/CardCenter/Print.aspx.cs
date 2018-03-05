using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter
{
    public partial class Print : PageBase.UserVerifyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dtContent.Rows[0].Cells[3].Visible = false;
                dtContent.Rows[1].Cells[3].Visible = false;
                dtContent.Rows[2].Cells[2].Visible = false;
                dtContent.Rows[3].Cells[2].Visible = false;

                //根据实际情况调用
                string jobID = string.Empty;
                string listID = string.Empty;
                string area = string.Empty;
                try
                {
                    jobID = Request.QueryString["jobID"];
                    listID = Request.QueryString["listID"];
                    area = Request.QueryString["area"];
                    DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                    string DbName = run.GetListDbName(jobID);
                    DataTable dt = run.Receipt(listID, DbName).Tables[0];
                    LoadPage(dt, area);
                }
                catch
                {
                    Alert("获取打印页面失败!");
                }
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="dt"></param>
        private void LoadPage(DataTable dt, string area)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    try
                    {

                        DataRow dr = dt.Rows[0];



                        if (dr["JobType"].ToString() == "MD001"
                           || dr["JobType"].ToString() == "MD002"
                           )
                        {
                            dtContent.Rows[0].Cells[3].Visible = true;
                            dtContent.Rows[1].Cells[3].Visible = true;
                            dtContent.Rows[2].Cells[2].Visible = true;
                            dtContent.Rows[3].Cells[2].Visible = true;
                            this.lblTblast1.Text = "1、企业备案";
                            this.lblTblast2.Text = "1、企业备案";
                            this.lblTblast3.Text = "1、企业备案";
                        }
                        if (
                             dr["JobType"].ToString() == "NA001"
                            || dr["JobType"].ToString() == "NA002")
                        {
                            dtContent.Rows[0].Cells[3].Visible = true;
                            dtContent.Rows[1].Cells[3].Visible = true;
                            dtContent.Rows[2].Cells[2].Visible = true;
                            dtContent.Rows[3].Cells[2].Visible = true;

                            this.lblTblast1.Text = "1、企业备案<br>2、企业权限";
                            this.lblTblast2.Text = "1、企业备案<br>2、企业权限";
                            this.lblTblast3.Text = "1、企业备案";
                        }


                        this.lblJobName.Text = dr["JobName"].ToString();
                        this.lblAgentName.Text = dr["AgentName"].ToString();
                        this.lblAgentPhone.Text = dr["AgentPhone"].ToString();
                        this.lblEnterpriseName.Text = dr["EnterpriseName"].ToString().Length > 15 ? dr["EnterpriseName"].ToString().Insert(15, "<br>") : dr["EnterpriseName"].ToString();
                        this.lblEnterpriseCode.Text = dr["EnterpriseCode"].ToString();
                        this.lblCardholderName.Text = dr["CardholderName"].ToString();
                        this.lblCreateTime.Text = dr["CreateTime"].ToString();
                        this.lblArea.Text = area == "1" ? "市" : "省";
                        this.lblAreaTitle.Text = area == "1" ? "市" : "省";
                        this.lblArea2.Text = area == "1" ? "市" : "省";
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