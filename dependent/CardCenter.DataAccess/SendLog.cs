/**  版本信息模板在安装目录下，可自行修改。
* SendLog.cs
*
* 功 能： N/A
* 类 名： SendLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/6 10:21:52   N/A    初版
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
	/// 数据访问类:SendLog
	/// </summary>
	public partial class SendLog : BaseDA
	{
		public SendLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SendLog");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.SendLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SendLog(");
			strSql.Append("Guid,IsSend,Error,SendPhone,SendContext)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@IsSend,@Error,@SendPhone,@SendContext)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@IsSend", SqlDbType.Bit,1),
					new SqlParameter("@Error", SqlDbType.NVarChar,512),
					new SqlParameter("@SendPhone", SqlDbType.NVarChar,32),
					new SqlParameter("@SendContext", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.IsSend;
			parameters[2].Value = model.Error;
			parameters[3].Value = model.SendPhone;
			parameters[4].Value = model.SendContext;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.SendLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SendLog set ");
			strSql.Append("IsSend=@IsSend,");
			strSql.Append("Error=@Error,");
			strSql.Append("SendPhone=@SendPhone,");
			strSql.Append("SendContext=@SendContext");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@IsSend", SqlDbType.Bit,1),
					new SqlParameter("@Error", SqlDbType.NVarChar,512),
					new SqlParameter("@SendPhone", SqlDbType.NVarChar,32),
					new SqlParameter("@SendContext", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.IsSend;
			parameters[1].Value = model.Error;
			parameters[2].Value = model.SendPhone;
			parameters[3].Value = model.SendContext;
			parameters[4].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SendLog ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SendLog ");
			strSql.Append(" where Guid in ("+Guidlist + ")  ");
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
		public CardCenter.Entity.SendLog GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,IsSend,Error,SendPhone,SendContext from SendLog ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.SendLog model=new CardCenter.Entity.SendLog();
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
		public CardCenter.Entity.SendLog DataRowToModel(DataRow row)
		{
			CardCenter.Entity.SendLog model=new CardCenter.Entity.SendLog();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["IsSend"]!=null && row["IsSend"].ToString()!="")
				{
					if((row["IsSend"].ToString()=="1")||(row["IsSend"].ToString().ToLower()=="true"))
					{
						model.IsSend=true;
					}
					else
					{
						model.IsSend=false;
					}
				}
				if(row["Error"]!=null)
				{
					model.Error=row["Error"].ToString();
				}
				if(row["SendPhone"]!=null)
				{
					model.SendPhone=row["SendPhone"].ToString();
				}
				if(row["SendContext"]!=null)
				{
					model.SendContext=row["SendContext"].ToString();
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
			strSql.Append("select Guid,IsSend,Error,SendPhone,SendContext ");
			strSql.Append(" FROM SendLog ");
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
			strSql.Append(" Guid,IsSend,Error,SendPhone,SendContext ");
			strSql.Append(" FROM SendLog ");
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
			strSql.Append("select count(1) FROM SendLog ");
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
				strSql.Append("order by T.Guid desc");
			}
			strSql.Append(")AS Row, T.*  from SendLog T ");
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
			parameters[0].Value = "SendLog";
			parameters[1].Value = "Guid";
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

