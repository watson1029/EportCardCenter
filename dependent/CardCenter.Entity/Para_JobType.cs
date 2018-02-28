/**  版本信息模板在安装目录下，可自行修改。
* Para_JobType.cs
*
* 功 能： N/A
* 类 名： Para_JobType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:49   N/A    初版
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
	/// 工单类型信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_JobType")]
	public partial class Para_JobType
	{
		public Para_JobType()
		{}
		#region Model
		private string _jobtypeid;
		private string _jobtypeparent;
		private string _jobname;
		private string _jobdbname;
		private int? _workday;
        private decimal? _handlingfee;
        private decimal? _costfee;
        private string _cardtype;
		/// <summary>
		/// 工单类型标识
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobTypeID", ColunmType="string", CanEmpty=false, Length=8, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string JobTypeID
		{
			set{ _jobtypeid=value;}
			get{return _jobtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobTypeParent", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobTypeParent
		{
			set{ _jobtypeparent=value;}
			get{return _jobtypeparent;}
		}
		/// <summary>
		/// 工单类型名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobName", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobName
		{
			set{ _jobname=value;}
			get{return _jobname;}
		}
		/// <summary>
		/// 工单数据表名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobDbName", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobDbName
		{
			set{ _jobdbname=value;}
			get{return _jobdbname;}
		}
		/// <summary>
		/// 工单所需工作日
		/// </summary>
		[DBRowEntityProperty(ColunmName="WorkDay", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? WorkDay
		{
			set{ _workday=value;}
			get{return _workday;}
		}
        /// <summary>
        /// 信息处理费
        /// </summary>
        [DBRowEntityProperty(ColunmName = "HandlingFee", ColunmType = "decimal", CanEmpty = true, Length = 8, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public decimal? HandlingFee
        {
            set { _handlingfee = value; }
            get { return _handlingfee; }
        }
        /// <summary>
        /// 工本费
        /// </summary>
        [DBRowEntityProperty(ColunmName = "CostFee", ColunmType = "decimal", CanEmpty = true, Length = 8, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public decimal? CostFee
        {
            set { _costfee = value; }
            get { return _costfee; }
        }
        /// <summary>
        /// 工本费
        /// </summary>
        [DBRowEntityProperty(ColunmName = "CardType", ColunmType = "string", CanEmpty = true, Length = 64, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public string CardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }
        #endregion Model

    }
}

