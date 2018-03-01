/**  版本信息模板在安装目录下，可自行修改。
* FlowInfo.cs
*
* 功 能： N/A
* 类 名： FlowInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:48   N/A    初版
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
	/// 数据访问类:FlowInfo
	/// </summary>
    public partial class FlowInfo : BaseDA
	{
		public FlowInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FlowInfo");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.FlowInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FlowInfo(");
			strSql.Append("Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@JobID,@FlowID,@SubmitDate,@SubmitUser,@Content,@IsDelete,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@FlowID", SqlDbType.Int,4),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@SubmitUser", SqlDbType.NVarChar,64),
					new SqlParameter("@Content", SqlDbType.NVarChar,512),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.JobID;
			parameters[2].Value = model.FlowID;
			parameters[3].Value = model.SubmitDate;
			parameters[4].Value = model.SubmitUser;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.Remark;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddEx(CardCenter.Entity.FlowInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FlowInfo(");
            strSql.Append("Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@JobID,@FlowID,@SubmitDate,@SubmitUser,@Content,@IsDelete,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid", SqlDbType.NVarChar,64),
                    new SqlParameter("@JobID", SqlDbType.NVarChar,64),
                    new SqlParameter("@FlowID", SqlDbType.Int,4),
                    new SqlParameter("@SubmitDate", SqlDbType.DateTime),
                    new SqlParameter("@SubmitUser", SqlDbType.NVarChar,64),
                    new SqlParameter("@Content", SqlDbType.NVarChar,512),
                    new SqlParameter("@IsDelete", SqlDbType.Bit,1),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.Guid;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.FlowID;
            parameters[3].Value = model.SubmitDate;
            parameters[4].Value = model.SubmitUser;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.Remark;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public void Update(CardCenter.Entity.FlowInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FlowInfo set ");
			strSql.Append("JobID=@JobID,");
			strSql.Append("FlowID=@FlowID,");
			strSql.Append("SubmitDate=@SubmitDate,");
			strSql.Append("SubmitUser=@SubmitUser,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@FlowID", SqlDbType.Int,4),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@SubmitUser", SqlDbType.NVarChar,64),
					new SqlParameter("@Content", SqlDbType.NVarChar,512),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.JobID;
			parameters[1].Value = model.FlowID;
			parameters[2].Value = model.SubmitDate;
			parameters[3].Value = model.SubmitUser;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.IsDelete;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FlowInfo ");
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
			strSql.Append("delete from FlowInfo ");
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
		public CardCenter.Entity.FlowInfo GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark from FlowInfo ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.FlowInfo model=new CardCenter.Entity.FlowInfo();
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
		public CardCenter.Entity.FlowInfo DataRowToModel(DataRow row)
		{
			CardCenter.Entity.FlowInfo model=new CardCenter.Entity.FlowInfo();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["FlowID"]!=null && row["FlowID"].ToString()!="")
				{
					model.FlowID=int.Parse(row["FlowID"].ToString());
				}
				if(row["SubmitDate"]!=null && row["SubmitDate"].ToString()!="")
				{
					model.SubmitDate=DateTime.Parse(row["SubmitDate"].ToString());
				}
				if(row["SubmitUser"]!=null)
				{
					model.SubmitUser=row["SubmitUser"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
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
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark ");
			strSql.Append(" FROM FlowInfo ");
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
			strSql.Append(" Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark ");
			strSql.Append(" FROM FlowInfo ");
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
			strSql.Append("select count(1) FROM FlowInfo ");
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
			strSql.Append(")AS Row, T.*  from FlowInfo T ");
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
			parameters[0].Value = "FlowInfo";
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
        //public string GetInsertSql(Entity.FlowInfo model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into FlowInfo(");
        //    strSql.Append("Guid,JobID,FlowID,SubmitDate,SubmitUser,Content,IsDelete,Remark)");
        //    strSql.Append(" values (");
        //    strSql.AppendFormat("'{0}','{1}',{2},'{3}','{4}','{5}',{6},'{7}')"
        //        , model.Guid
        //        , model.JobID
        //        , model.FlowID
        //        , model.SubmitDate
        //        , model.SubmitUser
        //        , model.Content
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.Remark);
        //    return strSql.ToString();
        //}

        /// <summary>
        /// 判断是否已经提交工单
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        //public bool IsComplete(string jobID)
        //{
        //    DataTable dt = this.GetList("IsDelete=0 and JobID='" + jobID + "' order by FlowID desc").Tables[0];
        //    if (dt.Rows.Count == 0)
        //        return false;
        //    else
        //    {
        //        if (int.Parse(dt.Rows[0]["FlowID"].ToString()) > 1)
        //            return true;
        //        else
        //            return false;
        //    }
        //}
		#endregion  ExtensionMethod
	}
}

