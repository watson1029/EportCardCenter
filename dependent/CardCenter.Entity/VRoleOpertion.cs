/**  版本信息模板在安装目录下，可自行修改。
* VRoleOpertion.cs
*
* 功 能： N/A
* 类 名： VRoleOpertion
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/4 17:31:20   N/A    初版
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
	/// VRoleOpertion:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="VRoleOpertion")]
	public partial class VRoleOpertion
	{
		public VRoleOpertion()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private Guid _operationid;
		private string _memuname;
		private string _operationcode;
		private string _memucode;
		private string _operationname;
		private string _operationtype;
		private int? _operationnumber;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="RoleID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="RoleName", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationId", ColunmType="Guid", CanEmpty=false, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public Guid OperationId
		{
			set{ _operationid=value;}
			get{return _operationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="MemuName", ColunmType="string", CanEmpty=true, Length=100, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string MemuName
		{
			set{ _memuname=value;}
			get{return _memuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationCode", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationCode
		{
			set{ _operationcode=value;}
			get{return _operationcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="MemuCode", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string MemuCode
		{
			set{ _memucode=value;}
			get{return _memucode;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationName", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationName
		{
			set{ _operationname=value;}
			get{return _operationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationType", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationType
		{
			set{ _operationtype=value;}
			get{return _operationtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationNumber", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? OperationNumber
		{
			set{ _operationnumber=value;}
			get{return _operationnumber;}
		}
		#endregion Model

	}
}

