/**  版本信息模板在安装目录下，可自行修改。
* Sys_Department.cs
*
* 功 能： N/A
* 类 名： Sys_Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/2/9 11:15:15   N/A    初版
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
	/// 数据访问类:Sys_Department
	/// </summary>
	public partial class Sys_Department : BaseDA
	{
		public Sys_Department()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DepartmentID", "Sys_Department"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DepartmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Department");
			strSql.Append(" where DepartmentID=@DepartmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartmentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CardCenter.Entity.Sys_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Department(");
			strSql.Append("DepartmentName,IsDelete,DepartmentAddress)");
			strSql.Append(" values (");
			strSql.Append("@DepartmentName,@IsDelete,@DepartmentAddress)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@DepartmentAddress", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.DepartmentName;
			parameters[1].Value = model.IsDelete;
			parameters[2].Value = model.DepartmentAddress;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(CardCenter.Entity.Sys_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Department set ");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("DepartmentAddress=@DepartmentAddress");
			strSql.Append(" where DepartmentID=@DepartmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@DepartmentAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)};
			parameters[0].Value = model.DepartmentName;
			parameters[1].Value = model.IsDelete;
			parameters[2].Value = model.DepartmentAddress;
			parameters[3].Value = model.DepartmentID;

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
		public bool Delete(int DepartmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Department ");
			strSql.Append(" where DepartmentID=@DepartmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartmentID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string DepartmentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Department ");
			strSql.Append(" where DepartmentID in ("+DepartmentIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public CardCenter.Entity.Sys_Department GetModel(int DepartmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepartmentID,DepartmentName,IsDelete,DepartmentAddress from Sys_Department ");
			strSql.Append(" where DepartmentID=@DepartmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
			parameters[0].Value = DepartmentID;

			CardCenter.Entity.Sys_Department model=new CardCenter.Entity.Sys_Department();
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
		public CardCenter.Entity.Sys_Department DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Sys_Department model=new CardCenter.Entity.Sys_Department();
			if (row != null)
			{
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					if((row["IsDelete"].ToString()=="1")||(row["IsDelete"].ToString().ToLower()=="true"))
					{
						model.IsDelete=true;
					}
					else
					{
						model.IsDelete=false;
					}
				}
				if(row["DepartmentAddress"]!=null)
				{
					model.DepartmentAddress=row["DepartmentAddress"].ToString();
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
			strSql.Append("select DepartmentID,DepartmentName,IsDelete,DepartmentAddress ");
			strSql.Append(" FROM Sys_Department ");
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
			strSql.Append(" DepartmentID,DepartmentName,IsDelete,DepartmentAddress ");
			strSql.Append(" FROM Sys_Department ");
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
			strSql.Append("select count(1) FROM Sys_Department ");
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
				strSql.Append("order by T.DepartmentID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Department T ");
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
			parameters[0].Value = "Sys_Department";
			parameters[1].Value = "DepartmentID";
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

