/**  版本信息模板在安装目录下，可自行修改。
* SaleList.cs
*
* 功 能： N/A
* 类 名： SaleList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/8/25 15:53:58   N/A    初版
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
	/// SaleList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SaleList
	{
		public SaleList()
		{}
		#region Model
		private string _listid;
		private string _jobid;
		private string _jobtype;
		private string _producttype;
		private int? _num;
		private bool _isdelete;
		private string _remark;
		private int? _managerflag;
		private string _manageruser;
		private DateTime? _managertime;
		/// <summary>
		/// 
		/// </summary>
		public string ListID
		{
			set{ _listid=value;}
			get{return _listid;}
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
		public string JobType
		{
			set{ _jobtype=value;}
			get{return _jobtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
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
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ManagerFlag
		{
			set{ _managerflag=value;}
			get{return _managerflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagerUser
		{
			set{ _manageruser=value;}
			get{return _manageruser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ManagerTime
		{
			set{ _managertime=value;}
			get{return _managertime;}
		}
		#endregion Model

	}
}

