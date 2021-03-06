﻿/**  版本信息模板在安装目录下，可自行修改。
* Para_JobType.cs
*
* 功 能： N/A
* 类 名： Para_JobType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:50   N/A    初版
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
	/// 数据访问类:Para_JobType
	/// </summary>
    public partial class Para_JobType : BaseDA
	{
		public Para_JobType()
		{}
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string JobTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Para_JobType");
            strSql.Append(" where JobTypeID=@JobTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobTypeID", SqlDbType.NVarChar,8)			};
            parameters[0].Value = JobTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CardCenter.Entity.Para_JobType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Para_JobType(");
            strSql.Append("JobTypeID,JobTypeParent,JobName,JobDbName,WorkDay,HandlingFee,CostFee,CardType)");
            strSql.Append(" values (");
            strSql.Append("@JobTypeID,@JobTypeParent,@JobName,@JobDbName,@WorkDay,@HandlingFee,@CostFee,@CardType)");
            SqlParameter[] parameters = {
					new SqlParameter("@JobTypeID", SqlDbType.NVarChar,8),
					new SqlParameter("@JobTypeParent", SqlDbType.NVarChar,8),
					new SqlParameter("@JobName", SqlDbType.NVarChar,64),
					new SqlParameter("@JobDbName", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkDay", SqlDbType.Int,4),
					new SqlParameter("@HandlingFee", SqlDbType.Float,8),
					new SqlParameter("@CostFee", SqlDbType.Float,8),
                    new SqlParameter("@CardType", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.JobTypeID;
            parameters[1].Value = model.JobTypeParent;
            parameters[2].Value = model.JobName;
            parameters[3].Value = model.JobDbName;
            parameters[4].Value = model.WorkDay;
            parameters[5].Value = model.HandlingFee;
            parameters[6].Value = model.CostFee;
            parameters[7].Value = model.CardType;

            TranHelper.AddTran(strSql, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(CardCenter.Entity.Para_JobType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Para_JobType set ");
            strSql.Append("JobTypeParent=@JobTypeParent,");
            strSql.Append("JobName=@JobName,");
            strSql.Append("JobDbName=@JobDbName,");
            strSql.Append("WorkDay=@WorkDay,");
            strSql.Append("HandlingFee=@HandlingFee,");
            strSql.Append("CostFee=@CostFee");
            strSql.Append("CardType=@CardType");
            strSql.Append(" where JobTypeID=@JobTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobTypeParent", SqlDbType.NVarChar,8),
					new SqlParameter("@JobName", SqlDbType.NVarChar,64),
					new SqlParameter("@JobDbName", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkDay", SqlDbType.Int,4),
					new SqlParameter("@HandlingFee", SqlDbType.Float,8),
					new SqlParameter("@CostFee", SqlDbType.Float,8),
                    new SqlParameter("@CardType", SqlDbType.NVarChar,64),
                    new SqlParameter("@JobTypeID", SqlDbType.NVarChar,8)};
            parameters[0].Value = model.JobTypeParent;
            parameters[1].Value = model.JobName;
            parameters[2].Value = model.JobDbName;
            parameters[3].Value = model.WorkDay;
            parameters[4].Value = model.HandlingFee;
            parameters[5].Value = model.CostFee;
            parameters[6].Value = model.CardType;
            parameters[7].Value = model.JobTypeID;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string JobTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Para_JobType ");
            strSql.Append(" where JobTypeID=@JobTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobTypeID", SqlDbType.NVarChar,8)			};
            parameters[0].Value = JobTypeID;

            TranHelper.AddTran(strSql, parameters);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string JobTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Para_JobType ");
            strSql.Append(" where JobTypeID in (" + JobTypeIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CardCenter.Entity.Para_JobType GetModel(string JobTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JobTypeID,JobTypeParent,JobName,JobDbName,WorkDay,HandlingFee,CostFee,CardType from Para_JobType ");
            strSql.Append(" where JobTypeID=@JobTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobTypeID", SqlDbType.NVarChar,8)			};
            parameters[0].Value = JobTypeID;

            CardCenter.Entity.Para_JobType model = new CardCenter.Entity.Para_JobType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public CardCenter.Entity.Para_JobType DataRowToModel(DataRow row)
        {
            CardCenter.Entity.Para_JobType model = new CardCenter.Entity.Para_JobType();
            if (row != null)
            {
                if (row["JobTypeID"] != null)
                {
                    model.JobTypeID = row["JobTypeID"].ToString();
                }
                if (row["JobTypeParent"] != null)
                {
                    model.JobTypeParent = row["JobTypeParent"].ToString();
                }
                if (row["JobName"] != null)
                {
                    model.JobName = row["JobName"].ToString();
                }
                if (row["JobDbName"] != null)
                {
                    model.JobDbName = row["JobDbName"].ToString();
                }
                if (row["WorkDay"] != null && row["WorkDay"].ToString() != "")
                {
                    model.WorkDay = int.Parse(row["WorkDay"].ToString());
                }
                if (row["HandlingFee"] != null && row["HandlingFee"].ToString() != "")
                {
                    model.HandlingFee = decimal.Parse(row["HandlingFee"].ToString());
                }
                if (row["CostFee"] != null && row["CostFee"].ToString() != "")
                {
                    model.CostFee = decimal.Parse(row["CostFee"].ToString());
                }
                if (row["CardType"] != null)
                {
                    model.CardType = row["CardType"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select JobTypeID,JobTypeParent,JobName,JobDbName,WorkDay,HandlingFee,CostFee,CardType ");
            strSql.Append(" FROM Para_JobType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" JobTypeID,JobTypeParent,JobName,JobDbName,WorkDay,HandlingFee,CostFee,CardType ");
            strSql.Append(" FROM Para_JobType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Para_JobType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.JobTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from Para_JobType T ");
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
            parameters[0].Value = "Para_JobType";
            parameters[1].Value = "JobTypeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public static string TypeName_CN(string typeCode)
        {
            Para_JobType da = new Para_JobType();
            Entity.Para_JobType model = da.GetModel(typeCode);
            return model == null ? null : model.JobName;

        }

        public static string TypeName_EN(string typeCode)
        {
            Para_JobType da = new Para_JobType();
            Entity.Para_JobType model = da.GetModel(typeCode);
            return model == null ? null : model.JobDbName;
        }
		#endregion  ExtensionMethod
	}
}

