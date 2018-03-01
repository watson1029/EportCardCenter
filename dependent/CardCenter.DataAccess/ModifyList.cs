/**  版本信息模板在安装目录下，可自行修改。
* UpdateUnlockList.cs
*
* 功 能： N/A
* 类 名： UpdateUnlockList
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
    /// 数据访问类:ModifyList
    /// </summary>
    public partial class ModifyList : BaseDA
    {
        public ModifyList()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ListID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ModifyList");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = ListID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CardCenter.Entity.ModifyList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ModifyList(");
            strSql.Append("ListID,JobID,JobType,CardType,CardholderNameEx,CardNum,CardholderName,IsChangeName,IsDelete,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ListID,@JobID,@JobType,@CardType,@CardholderNameEx,@CardNum,@CardholderName,@IsChangeName,@IsDelete,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@CardType", SqlDbType.NVarChar,64),
                    new SqlParameter("@CardholderNameEx", SqlDbType.NVarChar,32),
                    new SqlParameter("@CardNum", SqlDbType.NVarChar,32),
					new SqlParameter("@CardholderName", SqlDbType.NVarChar,32),
                    new SqlParameter("@IsChangeName", SqlDbType.Bit,1),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.ListID;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.JobType;
            parameters[3].Value = model.CardType;
            parameters[4].Value = model.CardholderNameEx;
            parameters[5].Value = model.CardNum;
            parameters[6].Value = model.CardholderName;
            parameters[7].Value = model.IsChangeName;
            parameters[8].Value = model.IsDelete;
            parameters[9].Value = model.Remark;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(CardCenter.Entity.ModifyList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ModifyList set ");
            strSql.Append("JobID=@JobID,");
            strSql.Append("JobType=@JobType,");
            strSql.Append("CardType=@CardType,");
            strSql.Append("CardholderNameEx=@CardholderNameEx,");
            strSql.Append("CardNum=@CardNum,");
            strSql.Append("CardholderName=@CardholderName,");
            strSql.Append("IsChangeName=@IsChangeName,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@CardType", SqlDbType.NVarChar,64),
                    new SqlParameter("@CardholderNameEx", SqlDbType.NVarChar,32),
                    new SqlParameter("@CardNum", SqlDbType.NVarChar,32),
					new SqlParameter("@CardholderName", SqlDbType.NVarChar,32),
					new SqlParameter("@IsChangeName", SqlDbType.Bit,1),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.JobID;
            parameters[1].Value = model.JobType;
            parameters[2].Value = model.CardType;
            parameters[3].Value = model.CardholderNameEx;
            parameters[4].Value = model.CardNum;
            parameters[5].Value = model.CardholderName;
            parameters[6].Value = model.IsChangeName;
            parameters[7].Value = model.IsDelete;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.ListID;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ListID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ModifyList ");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = ListID;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ListIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ModifyList ");
            strSql.Append(" where ListID in (" + ListIDlist + ")  ");
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
        public CardCenter.Entity.ModifyList GetModel(string ListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ListID,JobID,JobType,CardType,CardholderNameEx,CardNum,CardholderName,IsChangeName,IsDelete,Remark from ModifyList ");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = ListID;

            CardCenter.Entity.ModifyList model = new CardCenter.Entity.ModifyList();
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
        public CardCenter.Entity.ModifyList DataRowToModel(DataRow row)
        {
            CardCenter.Entity.ModifyList model = new CardCenter.Entity.ModifyList();
            if (row != null)
            {
                if (row["ListID"] != null)
                {
                    model.ListID = row["ListID"].ToString();
                }
                if (row["JobID"] != null)
                {
                    model.JobID = row["JobID"].ToString();
                }
                if (row["JobType"] != null)
                {
                    model.JobType = row["JobType"].ToString();
                }
                if (row["CardType"] != null && row["CardType"].ToString() != "")
                {
                    model.CardType = row["CardType"].ToString();
                }
                if (row["CardholderNameEx"] != null)
                {
                    model.CardholderNameEx = row["CardholderNameEx"].ToString();
                }
                if (row["CardNum"] != null)
                {
                    model.CardNum = row["CardNum"].ToString();
                }
                if (row["CardholderName"] != null)
                {
                    model.CardholderName = row["CardholderName"].ToString();
                }
                if (row["IsChangeName"] != null && row["IsChangeName"].ToString() != "")
                {
                    if ((row["IsChangeName"].ToString() == "1") || (row["IsChangeName"].ToString().ToLower() == "true"))
                    {
                        model.IsChangeName = true;
                    }
                    else
                    {
                        model.IsChangeName = false;
                    }
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    if ((row["IsDelete"].ToString() == "1") || (row["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select ListID,JobID,JobType,CardType,CardholderNameEx,CardNum,CardholderName,IsChangeName,IsDelete,Remark ");
            strSql.Append(" FROM ModifyList ");
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
            strSql.Append(" ListID,JobID,JobType,CardType,CardholderNameEx,CardNum,CardholderName,IsChangeName,IsDelete,Remark ");
            strSql.Append(" FROM ModifyList ");
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
            strSql.Append("select count(1) FROM ModifyList ");
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
                strSql.Append("order by T.ListID desc");
            }
            strSql.Append(")AS Row, T.*  from ModifyList T ");
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
            parameters[0].Value = "UpdateUnlockList";
            parameters[1].Value = "ListID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        //public string GetInsertSql(CardCenter.Entity.ModifyList model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into ModifyList(");
        //    strSql.Append("ListID,JobID,JobType,CardType,CardholderNameEx,CardNum,CardholderName,IsChangeName,IsDelete,Remark)");
        //    strSql.Append(" values (");
        //    strSql.AppendFormat("'{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7},{8},'{9}')"
        //        , model.ListID
        //        , model.JobID
        //        , model.JobType
        //        , model.CardType
        //        , "null"
        //        , model.CardNum
        //        , model.CardholderName
        //        , Convert.ToInt32(model.IsChangeName)
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.Remark);
        //    return strSql.ToString();
        //}

        //public string GetUpdateSql(CardCenter.Entity.ModifyList model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update ModifyList set ");
        //    strSql.AppendFormat("JobID='{0}',JobType='{1}',CardType='{2}',CardholderNameEx=null,CardNum='{4}',CardholderName='{5}',IsChangeName={6},IsDelete={7},Remark='{8}' where ListID='{9}' "
        //        , model.JobID
        //        , model.JobType
        //        , model.CardType
        //        , "null"
        //        , model.CardNum
        //        , model.CardholderName
        //        , Convert.ToInt32(model.IsChangeName)
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.Remark
        //        , model.ListID);
        //    return strSql.ToString();
        //}
        #endregion  ExtensionMethod
    }
}
