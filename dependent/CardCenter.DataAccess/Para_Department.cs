﻿/**  版本信息模板在安装目录下，可自行修改。
* Para_Department.cs
*
* 功 能： N/A
* 类 名： Para_Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 9:24:57   N/A    初版
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
	/// 数据访问类:Para_Department
	/// </summary>
	public partial class Para_Department : BaseDA
	{
		public Para_Department()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Para_Department");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,6)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Para_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Para_Department(");
			strSql.Append("ID,City,Area,GS,ZJ,SW,HG,WJ,WH)");
			strSql.Append(" values (");
			strSql.Append("@ID,@City,@Area,@GS,@ZJ,@SW,@HG,@WJ,@WH)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,6),
					new SqlParameter("@City", SqlDbType.NVarChar,64),
					new SqlParameter("@Area", SqlDbType.NVarChar,64),
					new SqlParameter("@GS", SqlDbType.NVarChar,16),
					new SqlParameter("@ZJ", SqlDbType.NVarChar,16),
					new SqlParameter("@SW", SqlDbType.NVarChar,16),
					new SqlParameter("@HG", SqlDbType.NVarChar,16),
					new SqlParameter("@WJ", SqlDbType.NVarChar,16),
					new SqlParameter("@WH", SqlDbType.NVarChar,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.City;
			parameters[2].Value = model.Area;
			parameters[3].Value = model.GS;
			parameters[4].Value = model.ZJ;
			parameters[5].Value = model.SW;
			parameters[6].Value = model.HG;
			parameters[7].Value = model.WJ;
			parameters[8].Value = model.WH;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Para_Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Para_Department set ");
			strSql.Append("City=@City,");
			strSql.Append("Area=@Area,");
			strSql.Append("GS=@GS,");
			strSql.Append("ZJ=@ZJ,");
			strSql.Append("SW=@SW,");
			strSql.Append("HG=@HG,");
			strSql.Append("WJ=@WJ,");
			strSql.Append("WH=@WH");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@City", SqlDbType.NVarChar,64),
					new SqlParameter("@Area", SqlDbType.NVarChar,64),
					new SqlParameter("@GS", SqlDbType.NVarChar,16),
					new SqlParameter("@ZJ", SqlDbType.NVarChar,16),
					new SqlParameter("@SW", SqlDbType.NVarChar,16),
					new SqlParameter("@HG", SqlDbType.NVarChar,16),
					new SqlParameter("@WJ", SqlDbType.NVarChar,16),
					new SqlParameter("@WH", SqlDbType.NVarChar,16),
					new SqlParameter("@ID", SqlDbType.NVarChar,6)};
			parameters[0].Value = model.City;
			parameters[1].Value = model.Area;
			parameters[2].Value = model.GS;
			parameters[3].Value = model.ZJ;
			parameters[4].Value = model.SW;
			parameters[5].Value = model.HG;
			parameters[6].Value = model.WJ;
			parameters[7].Value = model.WH;
			parameters[8].Value = model.ID;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_Department ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,6)			};
			parameters[0].Value = ID;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_Department ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public CardCenter.Entity.Para_Department GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,City,Area,GS,ZJ,SW,HG,WJ,WH from Para_Department ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,6)			};
			parameters[0].Value = ID;

			CardCenter.Entity.Para_Department model=new CardCenter.Entity.Para_Department();
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
		public CardCenter.Entity.Para_Department DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Para_Department model=new CardCenter.Entity.Para_Department();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["City"]!=null)
				{
					model.City=row["City"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["GS"]!=null)
				{
					model.GS=row["GS"].ToString();
				}
				if(row["ZJ"]!=null)
				{
					model.ZJ=row["ZJ"].ToString();
				}
				if(row["SW"]!=null)
				{
					model.SW=row["SW"].ToString();
				}
				if(row["HG"]!=null)
				{
					model.HG=row["HG"].ToString();
				}
				if(row["WJ"]!=null)
				{
					model.WJ=row["WJ"].ToString();
				}
				if(row["WH"]!=null)
				{
					model.WH=row["WH"].ToString();
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
			strSql.Append("select ID,City,Area,GS,ZJ,SW,HG,WJ,WH ");
			strSql.Append(" FROM Para_Department ");
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
			strSql.Append(" ID,City,Area,GS,ZJ,SW,HG,WJ,WH ");
			strSql.Append(" FROM Para_Department ");
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
			strSql.Append("select count(1) FROM Para_Department ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Para_Department T ");
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
			parameters[0].Value = "Para_Department";
			parameters[1].Value = "ID";
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

