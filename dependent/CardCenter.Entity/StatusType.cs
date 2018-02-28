/**  版本信息模板在安装目录下，可自行修改。
* StatusType.cs
*
* 功 能： N/A
* 类 名： StatusType
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
	/// 状态信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="StatusType")]
	public partial class StatusType
	{
		public StatusType()
		{}
		#region Model
		private int _statusid;
		private string _statusname;
		/// <summary>
		/// 自编ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="StatusID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=true,HaveDefaultValue=false)]
		public int StatusID
		{
			set{ _statusid=value;}
			get{return _statusid;}
		}
		/// <summary>
		/// 状态名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="StatusName", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string StatusName
		{
			set{ _statusname=value;}
			get{return _statusname;}
		}
		#endregion Model

	}
}

