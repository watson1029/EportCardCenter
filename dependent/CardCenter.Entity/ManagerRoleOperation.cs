/**  版本信息模板在安装目录下，可自行修改。
* ManagerRoleOpertion.cs
*
* 功 能： N/A
* 类 名： ManagerRoleOpertion
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/4 17:31:19   N/A    初版
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
	/// ManagerRoleOpertion:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="ManagerRoleOpertion")]
	public partial class ManagerRoleOperation
	{
		public ManagerRoleOperation()
		{}
		#region Model
		private Guid _operationid;
		private int? _roleid;
		private string _memuname;
		private string _memucode;
		private string _operationcode;
		private string _operationname;
		private string _operationtype;
		private int? _operationnumber;
		/// <summary>
		/// 操作ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationId", ColunmType="Guid", CanEmpty=false, Length=16, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=true)]
		public Guid OperationId
		{
			set{ _operationid=value;}
			get{return _operationid;}
		}
		/// <summary>
		/// 权限ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="RoleId", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="MemuName", ColunmType="string", CanEmpty=true, Length=100, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string MemuName
		{
			set{ _memuname=value;}
			get{return _memuname;}
		}
		/// <summary>
		/// 模块编号
		/// </summary>
		[DBRowEntityProperty(ColunmName="MemuCode", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string MemuCode
		{
			set{ _memucode=value;}
			get{return _memucode;}
		}
		/// <summary>
		/// 操作编号
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationCode", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationCode
		{
			set{ _operationcode=value;}
			get{return _operationcode;}
		}
		/// <summary>
		/// 操作名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationName", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationName
		{
			set{ _operationname=value;}
			get{return _operationname;}
		}
		/// <summary>
		/// 类别
		/// </summary>
		[DBRowEntityProperty(ColunmName="OperationType", ColunmType="string", CanEmpty=true, Length=50, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OperationType
		{
			set{ _operationtype=value;}
			get{return _operationtype;}
		}
		/// <summary>
		/// 序号
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

