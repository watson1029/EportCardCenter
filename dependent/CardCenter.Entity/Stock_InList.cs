/**  版本信息模板在安装目录下，可自行修改。
* Stock_InList.cs
*
* 功 能： N/A
* 类 名： Stock_InList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/8 10:25:20   N/A    初版
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
	/// Stock_InList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Stock_InList
	{
		public Stock_InList()
		{}
		#region Model
		private string _guid;
		private string _commodityguid;
		private int? _before;
		private int? _after;
		private int? _num;
		private string _submituser;
		private DateTime? _submittime;
		private string _remark;
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
		public string CommodityGuid
		{
			set{ _commodityguid=value;}
			get{return _commodityguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Before
		{
			set{ _before=value;}
			get{return _before;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? After
		{
			set{ _after=value;}
			get{return _after;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubmitUser
		{
			set{ _submituser=value;}
			get{return _submituser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SubmitTime
		{
			set{ _submittime=value;}
			get{return _submittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

