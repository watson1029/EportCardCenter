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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL;//Please add references
namespace CardCenter.DataAccess
{
	/// <summary>
	/// 数据访问类:VRoleOpertion
	/// </summary>
	public partial class VRoleOpertion : BaseDA
	{
		public VRoleOpertion()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CardCenter.Entity.VRoleOpertion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VRoleOpertion(");
			strSql.Append("RoleID,RoleName,OperationId,MemuName,OperationCode,MemuCode,OperationName,OperationType,OperationNumber)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@RoleName,@OperationId,@MemuName,@OperationCode,@MemuCode,@OperationName,@OperationType,@OperationNumber)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@OperationId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MemuName", SqlDbType.NVarChar,100),
					new SqlParameter("@OperationCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MemuCode", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationNumber", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = Guid.NewGuid();
			parameters[3].Value = model.MemuName;
			parameters[4].Value = model.OperationCode;
			parameters[5].Value = model.MemuCode;
			parameters[6].Value = model.OperationName;
			parameters[7].Value = model.OperationType;
			parameters[8].Value = model.OperationNumber;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CardCenter.Entity.VRoleOpertion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VRoleOpertion set ");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("OperationId=@OperationId,");
			strSql.Append("MemuName=@MemuName,");
			strSql.Append("OperationCode=@OperationCode,");
			strSql.Append("MemuCode=@MemuCode,");
			strSql.Append("OperationName=@OperationName,");
			strSql.Append("OperationType=@OperationType,");
			strSql.Append("OperationNumber=@OperationNumber");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@OperationId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MemuName", SqlDbType.NVarChar,100),
					new SqlParameter("@OperationCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MemuCode", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationNumber", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.OperationId;
			parameters[3].Value = model.MemuName;
			parameters[4].Value = model.OperationCode;
			parameters[5].Value = model.MemuCode;
			parameters[6].Value = model.OperationName;
			parameters[7].Value = model.OperationType;
			parameters[8].Value = model.OperationNumber;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VRoleOpertion ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardCenter.Entity.VRoleOpertion GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,RoleName,OperationId,MemuName,OperationCode,MemuCode,OperationName,OperationType,OperationNumber from VRoleOpertion ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			CardCenter.Entity.VRoleOpertion model=new CardCenter.Entity.VRoleOpertion();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardCenter.Entity.VRoleOpertion DataRowToModel(DataRow row)
		{
			CardCenter.Entity.VRoleOpertion model=new CardCenter.Entity.VRoleOpertion();
			if (row != null)
			{
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["OperationId"]!=null && row["OperationId"].ToString()!="")
				{
					model.OperationId= new Guid(row["OperationId"].ToString());
				}
				if(row["MemuName"]!=null)
				{
					model.MemuName=row["MemuName"].ToString();
				}
				if(row["OperationCode"]!=null)
				{
					model.OperationCode=row["OperationCode"].ToString();
				}
				if(row["MemuCode"]!=null)
				{
					model.MemuCode=row["MemuCode"].ToString();
				}
				if(row["OperationName"]!=null)
				{
					model.OperationName=row["OperationName"].ToString();
				}
				if(row["OperationType"]!=null)
				{
					model.OperationType=row["OperationType"].ToString();
				}
				if(row["OperationNumber"]!=null && row["OperationNumber"].ToString()!="")
				{
					model.OperationNumber=int.Parse(row["OperationNumber"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RoleID,RoleName,OperationId,MemuName,OperationCode,MemuCode,OperationName,OperationType,OperationNumber ");
			strSql.Append(" FROM VRoleOpertion ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RoleID,RoleName,OperationId,MemuName,OperationCode,MemuCode,OperationName,OperationType,OperationNumber ");
			strSql.Append(" FROM VRoleOpertion ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM VRoleOpertion ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.OperationId desc");
			}
			strSql.Append(")AS Row, T.*  from VRoleOpertion T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "VRoleOpertion";
			parameters[1].Value = "OperationId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

