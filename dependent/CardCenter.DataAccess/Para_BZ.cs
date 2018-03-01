/**  版本信息模板在安装目录下，可自行修改。
* Para_BZ.cs
*
* 功 能： N/A
* 类 名： Para_BZ
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/30 10:38:02   N/A    初版
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
	/// 数据访问类:Para_BZ
	/// </summary>
    public partial class Para_BZ : BaseDA
	{
		public Para_BZ()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BZ_Value)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Para_BZ");
			strSql.Append(" where BZ_Value=@BZ_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@BZ_Value", SqlDbType.NVarChar,3)			};
			parameters[0].Value = BZ_Value;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Para_BZ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Para_BZ(");
			strSql.Append("BZ_Value,BZ_Name)");
			strSql.Append(" values (");
			strSql.Append("@BZ_Value,@BZ_Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@BZ_Value", SqlDbType.NVarChar,3),
					new SqlParameter("@BZ_Name", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.BZ_Value;
			parameters[1].Value = model.BZ_Name;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Para_BZ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Para_BZ set ");
			strSql.Append("BZ_Name=@BZ_Name");
			strSql.Append(" where BZ_Value=@BZ_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@BZ_Name", SqlDbType.NVarChar,64),
					new SqlParameter("@BZ_Value", SqlDbType.NVarChar,3)};
			parameters[0].Value = model.BZ_Name;
			parameters[1].Value = model.BZ_Value;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string BZ_Value)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_BZ ");
			strSql.Append(" where BZ_Value=@BZ_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@BZ_Value", SqlDbType.NVarChar,3)			};
			parameters[0].Value = BZ_Value;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string BZ_Valuelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_BZ ");
			strSql.Append(" where BZ_Value in ("+BZ_Valuelist + ")  ");
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
		public CardCenter.Entity.Para_BZ GetModel(string BZ_Value)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BZ_Value,BZ_Name from Para_BZ ");
			strSql.Append(" where BZ_Value=@BZ_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@BZ_Value", SqlDbType.NVarChar,3)			};
			parameters[0].Value = BZ_Value;

			CardCenter.Entity.Para_BZ model=new CardCenter.Entity.Para_BZ();
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
		public CardCenter.Entity.Para_BZ DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Para_BZ model=new CardCenter.Entity.Para_BZ();
			if (row != null)
			{
				if(row["BZ_Value"]!=null)
				{
					model.BZ_Value=row["BZ_Value"].ToString();
				}
				if(row["BZ_Name"]!=null)
				{
					model.BZ_Name=row["BZ_Name"].ToString();
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
			strSql.Append("select BZ_Value,BZ_Name ");
			strSql.Append(" FROM Para_BZ ");
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
			strSql.Append(" BZ_Value,BZ_Name ");
			strSql.Append(" FROM Para_BZ ");
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
			strSql.Append("select count(1) FROM Para_BZ ");
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
				strSql.Append("order by T.BZ_Value desc");
			}
			strSql.Append(")AS Row, T.*  from Para_BZ T ");
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
			parameters[0].Value = "Para_BZ";
			parameters[1].Value = "BZ_Value";
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

