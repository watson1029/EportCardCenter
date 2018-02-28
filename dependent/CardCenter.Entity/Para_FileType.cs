/**  版本信息模板在安装目录下，可自行修改。
* Para_FileType.cs
*
* 功 能： N/A
* 类 名： Para_FileType
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
	/// 文件类型信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_FileType")]
	public partial class Para_FileType
	{
		public Para_FileType()
		{}
		#region Model
		private string _filetypeid;
		private string _filetypename;
		/// <summary>
		/// 文件类型标识
		/// </summary>
		[DBRowEntityProperty(ColunmName="FileTypeID", ColunmType="string", CanEmpty=false, Length=8, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string FileTypeID
		{
			set{ _filetypeid=value;}
			get{return _filetypeid;}
		}
		/// <summary>
		/// 文件类型名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="FileTypeName", ColunmType="string", CanEmpty=true, Length=128, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FileTypeName
		{
			set{ _filetypename=value;}
			get{return _filetypename;}
		}
		#endregion Model

	}
}

