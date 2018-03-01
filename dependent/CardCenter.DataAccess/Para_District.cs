/**  版本信息模板在安装目录下，可自行修改。
* Para_District.cs
*
* 功 能： N/A
* 类 名： Para_District
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/18 11:22:43   N/A    初版
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
	/// 数据访问类:Para_District
	/// </summary>
    public partial class Para_District : BaseDA
	{
		public Para_District()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string District_Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Para_District");
			strSql.Append(" where District_Code=@District_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@District_Code", SqlDbType.NVarChar,5)			};
			parameters[0].Value = District_Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Para_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Para_District(");
			strSql.Append("District_Code,District_Name)");
			strSql.Append(" values (");
			strSql.Append("@District_Code,@District_Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@District_Code", SqlDbType.NVarChar,5),
					new SqlParameter("@District_Name", SqlDbType.NVarChar,32)};
			parameters[0].Value = model.District_Code;
			parameters[1].Value = model.District_Name;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Para_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Para_District set ");
			strSql.Append("District_Name=@District_Name,");
			strSql.Append(" where District_Code=@District_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@District_Name", SqlDbType.NVarChar,32),
					new SqlParameter("@District_Code", SqlDbType.NVarChar,5)};
			parameters[0].Value = model.District_Name;
			parameters[2].Value = model.District_Code;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string District_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_District ");
			strSql.Append(" where District_Code=@District_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@District_Code", SqlDbType.NVarChar,5)			};
			parameters[0].Value = District_Code;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string District_Codelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_District ");
			strSql.Append(" where District_Code in ("+District_Codelist + ")  ");
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
		public CardCenter.Entity.Para_District GetModel(string District_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 District_Code,District_Name from Para_District ");
			strSql.Append(" where District_Code=@District_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@District_Code", SqlDbType.NVarChar,5)			};
			parameters[0].Value = District_Code;

			CardCenter.Entity.Para_District model=new CardCenter.Entity.Para_District();
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
		public CardCenter.Entity.Para_District DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Para_District model=new CardCenter.Entity.Para_District();
			if (row != null)
			{
				if(row["District_Code"]!=null)
				{
					model.District_Code=row["District_Code"].ToString();
				}
				if(row["District_Name"]!=null)
				{
					model.District_Name=row["District_Name"].ToString();
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
			strSql.Append("select District_Code,District_Name ");
			strSql.Append(" FROM Para_District ");
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
			strSql.Append(" District_Code,District_Name ");
			strSql.Append(" FROM Para_District ");
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
			strSql.Append("select count(1) FROM Para_District ");
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
				strSql.Append("order by T.District_Code desc");
			}
			strSql.Append(")AS Row, T.*  from Para_District T ");
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
			parameters[0].Value = "Para_District";
			parameters[1].Value = "District_Code";
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

