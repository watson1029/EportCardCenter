using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;


namespace CardCenter.Management.Ajax
{
	/// <summary>
	/// 处理授权逻辑
	/// </summary>
	public class RoleOperation : IHttpHandler, IRequiresSessionState
	{

		/// <summary>
		/// 提交
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest(HttpContext context)
		{
			try
			{

				string strAction=context.Request.QueryString["Action"];
				switch ( strAction )
				{
					case "UpdateData":
						UpdateData(context);
						break;
					case "LoadData":
						LoadData(context);
						break;
					case "DeleteRoleById":
						DeleteRoleById(context);
						break;
					case "AddRole":
						AddRole(context);
						break;
					case "EditRole":
						EditRole(context);
						break;
					default:
						break;
				}
			
			}
			catch ( Exception ex)
			{

				context.Response.Write("保存失败"+ex.Message);
			}
			


		}
/// <summary>
		/// 更新
		/// </summary>
		/// <param name="context"></param>
		private static void EditRole(HttpContext context)
		{
			string roleId = context.Request["roleId"];
			string roleName = context.Request["roleName"];
			DataAccess.ManagerRole runProc = new DataAccess.ManagerRole();
			Entity.ManagerRole entity = new Entity.ManagerRole()
			{
				RoleID = int.Parse(roleId),
				 IsDelete=false,
				  IsSuperRole=false,
				   Remark="",
				 RoleName = roleName
			};
			if ( runProc.Update(entity) )
			{
				context.Response.Write("保存成功");
			}
			else
			{
				context.Response.Write("更新失败");
			}

			
		}
		/// <summary
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="context"></param>
		private static void AddRole(HttpContext context)
		{
			string roleName = context.Request["roleName"];
			DataAccess.ManagerRole runProc = new DataAccess.ManagerRole();
			Entity.ManagerRole entity = new Entity.ManagerRole()
			{
				 IsDelete=false,
				 IsSuperRole=false,
				 Remark="",
				 RoleName = roleName
			};
			if ( runProc.Add(entity)>0 )
			{
				context.Response.Write("保存成功");
			}
			else
			{
				context.Response.Write("新增失败");
			}

			
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="context"></param>
		private static void DeleteRoleById(HttpContext context)
		{
			string strRoleId = context.Request["RoleId"];
			DataAccess.ManagerRole runProc = new DataAccess.ManagerRole();
			if ( runProc.Delete(int.Parse(strRoleId)) )
			{
				context.Response.Write("删除成功");
			}
			else
			{
				context.Response.Write("删除失败");
			}

			
		}
			/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="context"></param>
		private static void LoadData(HttpContext context)
		{
			string strRoleId = context.Request["RoleId"];
			DataAccess.RunProcedure runProc = new DataAccess.RunProcedure();
			DataSet ds= runProc.GetRoleOperationByRoleId(int.Parse(strRoleId));
		 
			context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
		}
		/// <summary>
		/// 更新数据
		/// </summary>
		/// <param name="context"></param>
		private static void UpdateData(HttpContext context)
		{
			string strRowType = context.Request["RowType"];
			string strRoleId = context.Request["RoleId"];
			string strMemuName = context.Request["MemuName"];
			string strMemuCode = context.Request["MemuCode"];
			string strOperationName = context.Request["OperationName"];
			string strOperationCode = context.Request["OperationCode"];
			string strOperationType = context.Request["OperationType"];
			string strOperationNumber = context.Request["OperationNumber"];
			Entity.ManagerRoleOperation entity = new Entity.ManagerRoleOperation()
			{
				MemuCode = strMemuCode,
				MemuName = strMemuName,
				OperationCode = strOperationCode,
				OperationId = Guid.NewGuid(),
				OperationName = strOperationName,
				OperationNumber = int.Parse(strOperationNumber),
				OperationType = strOperationType,
				RoleId = int.Parse(strRoleId)
			};
			DataAccess.RunProcedure runProc = new DataAccess.RunProcedure();
			if ( runProc.RoleOperationAdd(int.Parse(strRowType), entity) )
			{
				context.Response.Write("保存成功");
			}
			else
			{
				context.Response.Write("保存失败");
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}