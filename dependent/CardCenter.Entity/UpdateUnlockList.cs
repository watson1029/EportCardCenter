/**  版本信息模板在安装目录下，可自行修改。
* UpdateUnlockList.cs
*
* 功 能： N/A
* 类 名： UpdateUnlockList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:50   N/A    初版
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
	/// 更新解锁业务数据表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="UpdateUnlockList")]
	public partial class UpdateUnlockList
	{
		public UpdateUnlockList()
		{}
		#region Model
		private string _listid;
		private string _jobid;
		private string _jobtype;
		private string _cardtype;
        private string _cardnum;
		private string _cardholdername;
		private int? _cardholderidentificationtype;
		private string _cardholderidentificationnum;
		private bool _isdelete;
		private string _remark;
		/// <summary>
		/// 工单项ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="ListID", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string ListID
		{
			set{ _listid=value;}
			get{return _listid;}
		}
		/// <summary>
		/// 工单号
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobID", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
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
		/// 卡类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="CardType", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
        /// <summary>
        /// 卡号
        /// </summary>
        [DBRowEntityProperty(ColunmName = "CardNum", ColunmType = "string", CanEmpty = true, Length = 32, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string CardNum
        {
            set { _cardnum = value; }
            get { return _cardnum; }
        }
		/// <summary>
		/// 持卡人姓名
		/// </summary>
		[DBRowEntityProperty(ColunmName="CardholderName", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CardholderName
		{
			set{ _cardholdername=value;}
			get{return _cardholdername;}
		}
		/// <summary>
		/// 持卡人证件类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="CardholderIdentificationType", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? CardholderIdentificationType
		{
			set{ _cardholderidentificationtype=value;}
			get{return _cardholderidentificationtype;}
		}
		/// <summary>
		/// 持卡人证件号
		/// </summary>
		[DBRowEntityProperty(ColunmName="CardholderIdentificationNum", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CardholderIdentificationNum
		{
			set{ _cardholderidentificationnum=value;}
			get{return _cardholderidentificationnum;}
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
		/// 备注
		/// </summary>
		[DBRowEntityProperty(ColunmName="Remark", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

