/**  版本信息模板在安装目录下，可自行修改。
* NoticeList.cs
*
* 功 能： N/A
* 类 名： NoticeList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/8/15 15:02:47   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace CardCenter.Entity
{
	/// <summary>
	/// NoticeList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NoticeList
	{
		public NoticeList()
		{}
		#region Model
		private string _guid;
		private string _filename;
		private string _fileextension;
		private int? _filesize;
		private int? _noticetype;
		private string _savepath;
		private DateTime? _createtime;
		private string _createuser;
		private bool _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileExtension
		{
			set{ _fileextension=value;}
			get{return _fileextension;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NoticeType
		{
			set{ _noticetype=value;}
			get{return _noticetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SavePath
		{
			set{ _savepath=value;}
			get{return _savepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

