/**  版本信息模板在安装目录下，可自行修改。
* Flow.cs
*
* 功 能： N/A
* 类 名： Flow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/30 16:50:28   N/A    初版
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
	/// 流程信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Flow")]
	public partial class Flow
	{
		public Flow()
		{}
		#region Model
		private int _id;
		private string _jobtype;
		private int? _floworder;
		private int? _flowstatus;
		private bool _issend;
		private string _sendtxt;
		/// <summary>
		/// 自编ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=true,HaveDefaultValue=false)]
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 工单类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobType", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobType
		{
			set{ _jobtype=value;}
			get{return _jobtype;}
		}
		/// <summary>
		/// 流程顺序
		/// </summary>
		[DBRowEntityProperty(ColunmName="FlowOrder", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? FlowOrder
		{
			set{ _floworder=value;}
			get{return _floworder;}
		}
		/// <summary>
		/// 流程状态
		/// </summary>
		[DBRowEntityProperty(ColunmName="FlowStatus", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? FlowStatus
		{
			set{ _flowstatus=value;}
			get{return _flowstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="IsSend", ColunmType="bool", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public bool IsSend
		{
			set{ _issend=value;}
			get{return _issend;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="SendTxt", ColunmType="string", CanEmpty=true, Length=1024, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SendTxt
		{
			set{ _sendtxt=value;}
			get{return _sendtxt;}
		}
		#endregion Model

	}
}

