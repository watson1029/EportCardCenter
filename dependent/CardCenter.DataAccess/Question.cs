/**  版本信息模板在安装目录下，可自行修改。
* Question.cs
*
* 功 能： N/A
* 类 名： Question
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/5 11:18:21   N/A    初版
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
	/// 数据访问类:Question
	/// </summary>
	public partial class Question : BaseDA
	{
		public Question()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Question");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Question(");
			strSql.Append("Guid,CustomCode,CreateTime,Q1,Q1Content,Q2,Q2Content,Q3,Q3Content,Q4,Q4Content,Q5,Q5Content,Q6,Q6Content,Q7,Q7Content,Q8,Q8Content,Q9,Q9Content,Q10,Q10Content)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@CustomCode,@CreateTime,@Q1,@Q1Content,@Q2,@Q2Content,@Q3,@Q3Content,@Q4,@Q4Content,@Q5,@Q5Content,@Q6,@Q6Content,@Q7,@Q7Content,@Q8,@Q8Content,@Q9,@Q9Content,@Q10,@Q10Content)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@CustomCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Q1", SqlDbType.Int,4),
					new SqlParameter("@Q1Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q2", SqlDbType.Int,4),
					new SqlParameter("@Q2Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q3", SqlDbType.Int,4),
					new SqlParameter("@Q3Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q4", SqlDbType.Int,4),
					new SqlParameter("@Q4Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q5", SqlDbType.Int,4),
					new SqlParameter("@Q5Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q6", SqlDbType.Int,4),
					new SqlParameter("@Q6Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q7", SqlDbType.Int,4),
					new SqlParameter("@Q7Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q8", SqlDbType.Int,4),
					new SqlParameter("@Q8Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q9", SqlDbType.Int,4),
					new SqlParameter("@Q9Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q10", SqlDbType.Int,4),
					new SqlParameter("@Q10Content", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.CustomCode;
            parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.Q1;
			parameters[4].Value = model.Q1Content;
			parameters[5].Value = model.Q2;
			parameters[6].Value = model.Q2Content;
			parameters[7].Value = model.Q3;
			parameters[8].Value = model.Q3Content;
			parameters[9].Value = model.Q4;
			parameters[10].Value = model.Q4Content;
            parameters[11].Value = model.Q5;
            parameters[12].Value = model.Q5Content;
            parameters[13].Value = model.Q6;
            parameters[14].Value = model.Q6Content;
            parameters[15].Value = model.Q7;
            parameters[16].Value = model.Q7Content;
            parameters[17].Value = model.Q8;
            parameters[18].Value = model.Q8Content;
            parameters[19].Value = model.Q9;
            parameters[20].Value = model.Q9Content;
            parameters[21].Value = model.Q10;
			parameters[22].Value = model.Q10Content;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Question set ");
			strSql.Append("CustomCode=@CustomCode,");
            strSql.Append("CreateTime=@CreateTime");
			strSql.Append("Q1=@Q1,");
			strSql.Append("Q1Content=@Q1Content,");
			strSql.Append("Q2=@Q2,");
			strSql.Append("Q2Content=@Q2Content,");
			strSql.Append("Q3=@Q3,");
			strSql.Append("Q3Content=@Q3Content,");
			strSql.Append("Q4=@Q4,");
			strSql.Append("Q4Content=@Q4Content,");
			strSql.Append("Q5=@Q5,");
			strSql.Append("Q5Content=@Q5Content,");
			strSql.Append("Q6=@Q6,");
			strSql.Append("Q6Content=@Q6Content,");
			strSql.Append("Q7=@Q7,");
			strSql.Append("Q7Content=@Q7Content,");
			strSql.Append("Q8=@Q8,");
			strSql.Append("Q8Content=@Q8Content,");
			strSql.Append("Q9=@Q9,");
			strSql.Append("Q9Content=@Q9Content,");
			strSql.Append("Q10=@Q10,");
			strSql.Append("Q10Content=@Q10Content");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Q1", SqlDbType.Int,4),
					new SqlParameter("@Q1Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q2", SqlDbType.Int,4),
					new SqlParameter("@Q2Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q3", SqlDbType.Int,4),
					new SqlParameter("@Q3Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q4", SqlDbType.Int,4),
					new SqlParameter("@Q4Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q5", SqlDbType.Int,4),
					new SqlParameter("@Q5Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q6", SqlDbType.Int,4),
					new SqlParameter("@Q6Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q7", SqlDbType.Int,4),
					new SqlParameter("@Q7Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q8", SqlDbType.Int,4),
					new SqlParameter("@Q8Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q9", SqlDbType.Int,4),
					new SqlParameter("@Q9Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Q10", SqlDbType.Int,4),
					new SqlParameter("@Q10Content", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.CustomCode;
            parameters[1].Value = model.CreateTime;
			parameters[2].Value = model.Q1;
			parameters[3].Value = model.Q1Content;
			parameters[4].Value = model.Q2;
			parameters[5].Value = model.Q2Content;
			parameters[6].Value = model.Q3;
			parameters[7].Value = model.Q3Content;
			parameters[8].Value = model.Q4;
			parameters[9].Value = model.Q4Content;
			parameters[10].Value = model.Q5;
            parameters[11].Value = model.Q5Content;
            parameters[12].Value = model.Q6;
            parameters[13].Value = model.Q6Content;
            parameters[14].Value = model.Q7;
            parameters[15].Value = model.Q7Content;
            parameters[16].Value = model.Q8;
            parameters[17].Value = model.Q8Content;
            parameters[18].Value = model.Q9;
            parameters[19].Value = model.Q9Content;
            parameters[20].Value = model.Q10;
			parameters[21].Value = model.Q10Content;
			parameters[22].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Question ");
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
			strSql.Append("delete from Question ");
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
		public CardCenter.Entity.Question GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,CustomCode,CreateTime,Q1,Q1Content,Q2,Q2Content,Q3,Q3Content,Q4,Q4Content,Q5,Q5Content,Q6,Q6Content,Q7,Q7Content,Q8,Q8Content,Q9,Q9Content,Q10,Q10Content from Question ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.Question model=new CardCenter.Entity.Question();
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
		public CardCenter.Entity.Question DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Question model=new CardCenter.Entity.Question();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["CustomCode"]!=null)
				{
					model.CustomCode=row["CustomCode"].ToString();
				}
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
				if(row["Q1"]!=null && row["Q1"].ToString()!="")
				{
					model.Q1=int.Parse(row["Q1"].ToString());
				}
				if(row["Q1Content"]!=null)
				{
					model.Q1Content=row["Q1Content"].ToString();
				}
				if(row["Q2"]!=null && row["Q2"].ToString()!="")
				{
					model.Q2=int.Parse(row["Q2"].ToString());
				}
				if(row["Q2Content"]!=null)
				{
					model.Q2Content=row["Q2Content"].ToString();
				}
				if(row["Q3"]!=null && row["Q3"].ToString()!="")
				{
					model.Q3=int.Parse(row["Q3"].ToString());
				}
				if(row["Q3Content"]!=null)
				{
					model.Q3Content=row["Q3Content"].ToString();
				}
				if(row["Q4"]!=null && row["Q4"].ToString()!="")
				{
					model.Q4=int.Parse(row["Q4"].ToString());
				}
				if(row["Q4Content"]!=null)
				{
					model.Q4Content=row["Q4Content"].ToString();
				}
				if(row["Q5"]!=null && row["Q5"].ToString()!="")
				{
					model.Q5=int.Parse(row["Q5"].ToString());
				}
				if(row["Q5Content"]!=null)
				{
					model.Q5Content=row["Q5Content"].ToString();
				}
				if(row["Q6"]!=null && row["Q6"].ToString()!="")
				{
					model.Q6=int.Parse(row["Q6"].ToString());
				}
				if(row["Q6Content"]!=null)
				{
					model.Q6Content=row["Q6Content"].ToString();
				}
				if(row["Q7"]!=null && row["Q7"].ToString()!="")
				{
					model.Q7=int.Parse(row["Q7"].ToString());
				}
				if(row["Q7Content"]!=null)
				{
					model.Q7Content=row["Q7Content"].ToString();
				}
				if(row["Q8"]!=null && row["Q8"].ToString()!="")
				{
					model.Q8=int.Parse(row["Q8"].ToString());
				}
				if(row["Q8Content"]!=null)
				{
					model.Q8Content=row["Q8Content"].ToString();
				}
				if(row["Q9"]!=null && row["Q9"].ToString()!="")
				{
					model.Q9=int.Parse(row["Q9"].ToString());
				}
				if(row["Q9Content"]!=null)
				{
					model.Q9Content=row["Q9Content"].ToString();
				}
				if(row["Q10"]!=null && row["Q10"].ToString()!="")
				{
					model.Q10=int.Parse(row["Q10"].ToString());
				}
				if(row["Q10Content"]!=null)
				{
					model.Q10Content=row["Q10Content"].ToString();
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
			strSql.Append("select Guid,CreateTime,CustomCode,Q1,Q1Content,Q2,Q2Content,Q3,Q3Content,Q4,Q4Content,Q5,Q5Content,Q6,Q6Content,Q7,Q7Content,Q8,Q8Content,Q9,Q9Content,Q10,Q10Content ");
			strSql.Append(" FROM Question ");
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
			strSql.Append(" Guid,CustomCode,CreateTime,Q1,Q1Content,Q2,Q2Content,Q3,Q3Content,Q4,Q4Content,Q5,Q5Content,Q6,Q6Content,Q7,Q7Content,Q8,Q8Content,Q9,Q9Content,Q10,Q10Content ");
			strSql.Append(" FROM Question ");
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
			strSql.Append("select count(1) FROM Question ");
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
			strSql.Append(")AS Row, T.*  from Question T ");
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
			parameters[0].Value = "Question";
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

