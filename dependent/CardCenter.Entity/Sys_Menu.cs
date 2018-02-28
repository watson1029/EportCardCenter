/**  版本信息模板在安装目录下，可自行修改。
* Sys_Menu.cs
*
* 功 能： N/A
* 类 名： Sys_Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/2/5 10:49:46   N/A    初版
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
	/// Sys_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_Menu
	{
		public Sys_Menu()
		{}
		#region Model
		private int _id;
		private string _menuname;
		private string _menucode;
		private int? _menuhigherlevel;
		private int? _menuorder;
		private string _menuurl;
        private string _menuclass;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuCode
		{
			set{ _menucode=value;}
			get{return _menucode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuHigherLevel
		{
			set{ _menuhigherlevel=value;}
			get{return _menuhigherlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuOrder
		{
			set{ _menuorder=value;}
			get{return _menuorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string MenuClass
        {
            set { _menuclass = value; }
            get { return _menuclass; }
        }
		#endregion Model

	}
}

