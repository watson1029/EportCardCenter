/**  版本信息模板在安装目录下，可自行修改。
* Para_JobNeedFileType.cs
*
* 功 能： N/A
* 类 名： Para_JobNeedFileType
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
	/// 工单所需文件类型信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_JobNeedFileType")]
	public partial class Para_JobNeedFileType
	{
		public Para_JobNeedFileType()
		{}
		#region Model
		private int _id;
		private string _jobtype;
		private string _filetype;
		/// <summary>
		/// 自编ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=true,HaveDefaultValue=false)]
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 文件类型
		/// </summary>
		[DBRowEntityProperty(ColunmName="FileType", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		#endregion Model

	}
}

