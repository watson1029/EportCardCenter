/**  版本信息模板在安装目录下，可自行修改。
* ManagerRole.cs
*
* 功 能： N/A
* 类 名： ManagerRole
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
	/// 管理用户权限信息表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="ManagerRole")]
	public partial class ManagerRole
	{
		public ManagerRole()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private bool _issuperrole;
		private bool _isdelete;
		private string _remark;
		/// <summary>
		/// 自编ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="RoleID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=true,HaveDefaultValue=false)]
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 权限名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="RoleName", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 是否超级用户
		/// </summary>
		[DBRowEntityProperty(ColunmName="IsSuperRole", ColunmType="bool", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public bool IsSuperRole
		{
			set{ _issuperrole=value;}
			get{return _issuperrole;}
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

