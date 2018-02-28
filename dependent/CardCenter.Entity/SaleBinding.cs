/**  版本信息模板在安装目录下，可自行修改。
* SaleBinding.cs
*
* 功 能： N/A
* 类 名： SaleBinding
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/15 10:28:18   N/A    初版
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
	/// SaleBinding:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SaleBinding
	{
		public SaleBinding()
		{}
		#region Model
		private string _guid;
		private string _jobid;
		private string _saleid;
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
		public string JobID
		{
			set{ _jobid=value;}
			get{return _jobid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaleID
		{
			set{ _saleid=value;}
			get{return _saleid;}
		}
		#endregion Model

	}
}

