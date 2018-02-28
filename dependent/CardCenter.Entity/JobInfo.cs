/**  版本信息模板在安装目录下，可自行修改。
* JobInfo.cs
*
* 功 能： N/A
* 类 名： JobInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:48   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using Job.Entity;
namespace CardCenter.Entity
{
	/// <summary>
	/// 工单数据表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="JobInfo")]
	public partial class JobInfo
	{
		public JobInfo()
		{}
		#region Model
		private string _jobid;
		private string _jobtype;
		private DateTime? _createtime;
		private string _createuser;
		private bool _isdelete;
		private string _enterprisename;
		private string _enterpriseaddress;
		private string _enterprisecode;
		private string _agentname;
		private int? _agentidentificationtype;
		private string _agentidentificationnum;
		private string _agentphone;
		private string _consigneename;
		private string _consigneeaddress;
		private string _consigneephone;
		private string _remark;
        private bool? _expressflat;
        private string _feeflat;
        private string _customscode;
        private string _approvalfile;
        private bool _isonline;
        private string _invoicename;
        private string _invoicephone;
        private string _invoiceaddress;
        private string _invoicepostcode;
        private string _invoiceemail;
        private string _invoicecode;
        private decimal? _fee;
		/// <summary>
		/// 工单号
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobID", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string JobID
		{
			set{ _jobid=value;}
			get{return _jobid;}
		}
		/// <summary>
		/// 工单类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobType", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobType
		{
			set{ _jobtype=value;}
			get{return _jobtype;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		[DBRowEntityProperty(ColunmName="CreateTime", ColunmType="DateTime", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		[DBRowEntityProperty(ColunmName="CreateUser", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		[DBRowEntityProperty(ColunmName="IsDelete", ColunmType="bool", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 企业名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="EnterpriseName", ColunmType="string", CanEmpty=true, Length=128, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string EnterpriseName
		{
			set{ _enterprisename=value;}
			get{return _enterprisename;}
		}
		/// <summary>
		/// 企业地址
		/// </summary>
		[DBRowEntityProperty(ColunmName="EnterpriseAddress", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string EnterpriseAddress
		{
			set{ _enterpriseaddress=value;}
			get{return _enterpriseaddress;}
		}
		/// <summary>
		/// 企业编号/统一社会信用代码
		/// </summary>
		[DBRowEntityProperty(ColunmName="EnterpriseCode", ColunmType="string", CanEmpty=true, Length=18, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string EnterpriseCode
		{
			set{ _enterprisecode=value;}
			get{return _enterprisecode;}
		}
		/// <summary>
		/// 经办人姓名
		/// </summary>
		[DBRowEntityProperty(ColunmName="AgentName", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string AgentName
		{
			set{ _agentname=value;}
			get{return _agentname;}
		}
		/// <summary>
		/// 经办人证件类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="AgentIdentificationType", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? AgentIdentificationType
		{
			set{ _agentidentificationtype=value;}
			get{return _agentidentificationtype;}
		}
		/// <summary>
		/// 经办人证件号
		/// </summary>
		[DBRowEntityProperty(ColunmName="AgentIdentificationNum", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string AgentIdentificationNum
		{
			set{ _agentidentificationnum=value;}
			get{return _agentidentificationnum;}
		}
		/// <summary>
		/// 经办人手机
		/// </summary>
		[DBRowEntityProperty(ColunmName="AgentPhone", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string AgentPhone
		{
			set{ _agentphone=value;}
			get{return _agentphone;}
		}
		/// <summary>
		/// 收货人姓名
		/// </summary>
		[DBRowEntityProperty(ColunmName="ConsigneeName", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ConsigneeName
		{
			set{ _consigneename=value;}
			get{return _consigneename;}
		}
		/// <summary>
		/// 收货人地址
		/// </summary>
		[DBRowEntityProperty(ColunmName="ConsigneeAddress", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ConsigneeAddress
		{
			set{ _consigneeaddress=value;}
			get{return _consigneeaddress;}
		}
		/// <summary>
		/// 收货人手机
		/// </summary>
		[DBRowEntityProperty(ColunmName="ConsigneePhone", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ConsigneePhone
		{
			set{ _consigneephone=value;}
			get{return _consigneephone;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		[DBRowEntityProperty(ColunmName="Remark", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        /// <summary>
        /// 快递标识
        /// </summary>
        [DBRowEntityProperty(ColunmName = "ExpressFlat", ColunmType = "bool", CanEmpty = true, Length = 1, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public bool? ExpressFlat
        {
            set { _expressflat = value; }
            get { return _expressflat; }
        }
        /// <summary>
        /// 缴费标识
        /// </summary>
        [DBRowEntityProperty(ColunmName = "FeeFlat", ColunmType = "string", CanEmpty = true, Length = 32, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string FeeFlat
        {
            set { _feeflat = value; }
            get { return _feeflat; }
        }
        /// <summary>
        /// 海关代码
        /// </summary>
        [DBRowEntityProperty(ColunmName = "CustomsCode", ColunmType = "string", CanEmpty = true, Length = 10, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string CustomsCode
        {
            set { _customscode = value; }
            get { return _customscode; }
        }
        /// <summary>
        /// 审批文件
        /// </summary>
        [DBRowEntityProperty(ColunmName = "ApprovalFile", ColunmType = "string", CanEmpty = true, Length = 64, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string ApprovalFile
        {
            set { _approvalfile = value; }
            get { return _approvalfile; }
        }
        /// <summary>
        /// 网上办理标识
        /// </summary>
        [DBRowEntityProperty(ColunmName = "IsOnline", ColunmType = "bool", CanEmpty = true, Length = 1, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public bool IsOnline
        {
            set { _isonline = value; }
            get { return _isonline; }
        }
        /// <summary>
        /// 发票收件人
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceName", ColunmType = "string", CanEmpty = true, Length = 32, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceName
        {
            set { _invoicename = value; }
            get { return _invoicename; }
        }
        /// <summary>
        /// 发票收件人手机
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoicePhone", ColunmType = "string", CanEmpty = true, Length = 16, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoicePhone
        {
            set { _invoicephone = value; }
            get { return _invoicephone; }
        }
        /// <summary>
        /// 发票收件人地址
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceAddress", ColunmType = "string", CanEmpty = true, Length = 512, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceAddress
        {
            set { _invoiceaddress = value; }
            get { return _invoiceaddress; }
        }
        /// <summary>
        /// 发票邮编
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoicePostCode", ColunmType = "string", CanEmpty = true, Length = 6, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoicePostCode
        {
            set { _invoicepostcode = value; }
            get { return _invoicepostcode; }
        }
        /// <summary>
        /// 发票电子邮箱
        /// </summary>
        [DBRowEntityProperty(ColunmName ="InvoiceEmail", ColunmType = "string", CanEmpty = true, Length = 64, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceEmail
        {
            set { _invoiceemail = value; }
            get { return _invoiceemail; }
        }
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceCode", ColunmType = "string", CanEmpty = true, Length = 18, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceCode
        {
            set { _invoicecode = value; }
            get { return _invoicecode; }
        }
        /// <summary>
        /// 费用
        /// </summary>
        [DBRowEntityProperty(ColunmName = "Fee", ColunmType = "decimal", CanEmpty = true, Length = 8, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public decimal? Fee
        {
            set { _fee = value; }
            get { return _fee; }
        }
		#endregion Model

	}

    [Serializable]
    public class InvoiceData
    {
        private string _invoicename;
        private string _invoicephone;
        private string _invoiceaddress;
        private string _invoicepostcode;
        private string _invoicecode;
        private string _invoiceemail;
        private string _invoiceenterprisename;
        private string _invoiceenterprisecode;
        /// <summary>
        /// 发票收件人
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceName", ColunmType = "string", CanEmpty = true, Length = 32, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceName
        {
            set { _invoicename = value; }
            get { return _invoicename; }
        }
        /// <summary>
        /// 发票收件人手机
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoicePhone", ColunmType = "string", CanEmpty = true, Length = 16, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoicePhone
        {
            set { _invoicephone = value; }
            get { return _invoicephone; }
        }
        /// <summary>
        /// 发票收件人地址
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceAddress", ColunmType = "string", CanEmpty = true, Length = 512, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceAddress
        {
            set { _invoiceaddress = value; }
            get { return _invoiceaddress; }
        }
        /// <summary>
        /// 发票邮编
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoicePostCode", ColunmType = "string", CanEmpty = true, Length = 256, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoicePostCode
        {
            set { _invoicepostcode = value; }
            get { return _invoicepostcode; }
        }
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceCode", ColunmType = "string", CanEmpty = true, Length = 18, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceCode
        {
            set { _invoicecode = value; }
            get { return _invoicecode; }
        }
        /// <summary>
        /// 发票电子邮箱
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceEmail", ColunmType = "string", CanEmpty = true, Length = 64, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceEmail
        {
            set { _invoiceemail = value; }
            get { return _invoiceemail; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceEnterpriseName", ColunmType = "string", CanEmpty = true, Length = 18, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceEnterpriseName
        {
            set { _invoiceenterprisename = value; }
            get { return _invoiceenterprisename; }
        }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [DBRowEntityProperty(ColunmName = "InvoiceEnterpriseCode", ColunmType = "string", CanEmpty = true, Length = 6, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string InvoiceEnterpriseCode
        {
            set { _invoiceenterprisecode = value; }
            get { return _invoiceenterprisecode; }
        }
    }
}

