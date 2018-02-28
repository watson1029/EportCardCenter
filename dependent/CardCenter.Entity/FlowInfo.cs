/**  版本信息模板在安装目录下，可自行修改。
* FlowInfo.cs
*
* 功 能： N/A
* 类 名： FlowInfo
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
	/// 流程数据表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="FlowInfo")]
	public partial class FlowInfo
	{
		public FlowInfo()
		{}
		#region Model
		private string _guid;
		private string _jobid;
		private int? _flowid;
		private DateTime? _submitdate;
		private string _submituser;
		private string _content;
		private bool _isdelete;
		private string _remark;
		/// <summary>
		/// 流程流水号
		/// </summary>
		[DBRowEntityProperty(ColunmName="Guid", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
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
		/// 流程ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="FlowID", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		/// <summary>
		/// 提交日期
		/// </summary>
		[DBRowEntityProperty(ColunmName="SubmitDate", ColunmType="DateTime", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? SubmitDate
		{
			set{ _submitdate=value;}
			get{return _submitdate;}
		}
		/// <summary>
		/// 提交用户
		/// </summary>
		[DBRowEntityProperty(ColunmName="SubmitUser", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SubmitUser
		{
			set{ _submituser=value;}
			get{return _submituser;}
		}
		/// <summary>
		/// 提交备注
		/// </summary>
		[DBRowEntityProperty(ColunmName="Content", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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

