/**  版本信息模板在安装目录下，可自行修改。
* HandleList.cs
*
* 功 能： N/A
* 类 名： HandleList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/7 14:41:49   N/A    初版
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
	/// 数据访问类:HandleList
	/// </summary>
	public partial class HandleList : BaseDA
	{
        public int Num = 1;
		public HandleList()
		{}
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HandleList");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
            parameters[0].Value = Guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CardCenter.Entity.HandleList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HandleList(");
            strSql.Append("Guid,JobID,No,FunctionID,OpeartionID,IsChecked,Status,OpeartionUser,OpeartionTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@JobID,@No,@FunctionID,@OpeartionID,@IsChecked,@Status,@OpeartionUser,@OpeartionTime,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@No", SqlDbType.Int,4),
					new SqlParameter("@FunctionID", SqlDbType.NVarChar,8),
					new SqlParameter("@OpeartionID", SqlDbType.Int,4),
					new SqlParameter("@IsChecked", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,32),
					new SqlParameter("@OpeartionUser", SqlDbType.NVarChar,64),
					new SqlParameter("@OpeartionTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.Guid;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.No;
            parameters[3].Value = model.FunctionID;
            parameters[4].Value = model.OpeartionID;
            parameters[5].Value = model.IsChecked;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.OpeartionUser;
            parameters[8].Value = model.OpeartionTime;
            parameters[9].Value = model.Remark;

            TranHelper.AddTran(strSql, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(CardCenter.Entity.HandleList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HandleList set ");
            strSql.Append("JobID=@JobID,");
            strSql.Append("No=@No,");
            strSql.Append("FunctionID=@FunctionID,");
            strSql.Append("OpeartionID=@OpeartionID,");
            strSql.Append("IsChecked=@IsChecked,");
            strSql.Append("Status=@Status,");
            strSql.Append("OpeartionUser=@OpeartionUser,");
            strSql.Append("OpeartionTime=@OpeartionTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@No", SqlDbType.Int,4),
					new SqlParameter("@FunctionID", SqlDbType.NVarChar,8),
					new SqlParameter("@OpeartionID", SqlDbType.Int,4),
					new SqlParameter("@IsChecked", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,32),
					new SqlParameter("@OpeartionUser", SqlDbType.NVarChar,64),
					new SqlParameter("@OpeartionTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.JobID;
            parameters[1].Value = model.No;
            parameters[2].Value = model.FunctionID;
            parameters[3].Value = model.OpeartionID;
            parameters[4].Value = model.IsChecked;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.OpeartionUser;
            parameters[7].Value = model.OpeartionTime;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(CardCenter.Entity.HandleList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HandleList set ");
            strSql.Append("JobID=@JobID,");
            strSql.Append("No=@No,");
            strSql.Append("FunctionID=@FunctionID,");
            strSql.Append("OpeartionID=@OpeartionID,");
            strSql.Append("IsChecked=@IsChecked,");
            strSql.Append("Status=@Status,");
            strSql.Append("OpeartionUser=@OpeartionUser,");
            strSql.Append("OpeartionTime=@OpeartionTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@JobID", SqlDbType.NVarChar,64),
                    new SqlParameter("@No", SqlDbType.Int,4),
                    new SqlParameter("@FunctionID", SqlDbType.NVarChar,8),
                    new SqlParameter("@OpeartionID", SqlDbType.Int,4),
                    new SqlParameter("@IsChecked", SqlDbType.Bit,1),
                    new SqlParameter("@Status", SqlDbType.NVarChar,32),
                    new SqlParameter("@OpeartionUser", SqlDbType.NVarChar,64),
                    new SqlParameter("@OpeartionTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,512),
                    new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.JobID;
            parameters[1].Value = model.No;
            parameters[2].Value = model.FunctionID;
            parameters[3].Value = model.OpeartionID;
            parameters[4].Value = model.IsChecked;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.OpeartionUser;
            parameters[7].Value = model.OpeartionTime;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Guid;

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
        /// 删除一条数据
        /// </summary>
        public void Delete(string Guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HandleList ");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
            parameters[0].Value = Guid;

            TranHelper.AddTran(strSql, parameters);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HandleList ");
            strSql.Append(" where Guid in (" + Guidlist + ")  ");
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
        public CardCenter.Entity.HandleList GetModel(string Guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Guid,JobID,No,FunctionID,OpeartionID,IsChecked,Status,OpeartionUser,OpeartionTime,Remark from HandleList ");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
            parameters[0].Value = Guid;

            CardCenter.Entity.HandleList model = new CardCenter.Entity.HandleList();
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
        public CardCenter.Entity.HandleList DataRowToModel(DataRow row)
        {
            CardCenter.Entity.HandleList model = new CardCenter.Entity.HandleList();
            if (row != null)
            {
                if (row["Guid"] != null)
                {
                    model.Guid = row["Guid"].ToString();
                }
                if (row["JobID"] != null)
                {
                    model.JobID = row["JobID"].ToString();
                }
                if (row["No"] != null && row["No"].ToString() != "")
                {
                    model.No = int.Parse(row["No"].ToString());
                }
                if (row["FunctionID"] != null)
                {
                    model.FunctionID = row["FunctionID"].ToString();
                }
                if (row["OpeartionID"] != null && row["OpeartionID"].ToString() != "")
                {
                    model.OpeartionID = int.Parse(row["OpeartionID"].ToString());
                }
                if (row["IsChecked"] != null && row["IsChecked"].ToString() != "")
                {
                    if ((row["IsChecked"].ToString() == "1") || (row["IsChecked"].ToString().ToLower() == "true"))
                    {
                        model.IsChecked = true;
                    }
                    else
                    {
                        model.IsChecked = false;
                    }
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["OpeartionUser"] != null)
                {
                    model.OpeartionUser = row["OpeartionUser"].ToString();
                }
                if (row["OpeartionTime"] != null && row["OpeartionTime"].ToString() != "")
                {
                    model.OpeartionTime = DateTime.Parse(row["OpeartionTime"].ToString());
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
            strSql.Append("select Guid,JobID,No,FunctionID,OpeartionID,IsChecked,Status,OpeartionUser,OpeartionTime,Remark ");
            strSql.Append(" FROM HandleList ");
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
            strSql.Append(" Guid,JobID,No,FunctionID,OpeartionID,IsChecked,Status,OpeartionUser,OpeartionTime,Remark ");
            strSql.Append(" FROM HandleList ");
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
            strSql.Append("select count(1) FROM HandleList ");
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
                strSql.Append("order by T.Guid desc");
            }
            strSql.Append(")AS Row, T.*  from HandleList T ");
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
            parameters[0].Value = "HandleList";
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
        /// <summary>
        /// 插入A01接单操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA01(Entity.JobInfo job)
        {
            Entity.HandleList handle = new Entity.HandleList();
            handle.Guid = Guid.NewGuid().ToString();
            handle.JobID = job.JobID;
            handle.No = Num++;
            handle.FunctionID = "A01";
            handle.OpeartionID = job.IsOnline ? 2 : 1;
            handle.IsChecked = true;
            handle.Status = "已处理";
            handle.OpeartionUser = job.IsOnline ? job.CreateUser : PageBase.CommonObject.ManagerUserInfo.guid;
            handle.OpeartionTime = job.CreateTime;
            handle.Remark = job.IsOnline ? job.EnterpriseName + ",网上提交工单." : "操作员:" + new ManagerUser().GetModel(handle.OpeartionUser).Name + ",现场收单.";
            this.Add(handle);
        }

        /// <summary>
        /// 插入A02录入操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA02(Entity.JobInfo job)
        {
            if (new NewlyAddedList().GetList("IsDelete=0 and JobType='NA001' and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0)
            {
                Entity.HandleList handleQS = new Entity.HandleList();
                handleQS.Guid = Guid.NewGuid().ToString();
                handleQS.JobID = job.JobID;
                handleQS.No = Num;
                handleQS.FunctionID = "A02";
                handleQS.OpeartionID = 3;
                handleQS.IsChecked = false;
                handleQS.Status = "待处理";
                Entity.HandleList handleHS = new Entity.HandleList();
                handleHS.Guid = Guid.NewGuid().ToString();
                handleHS.JobID = job.JobID;
                handleHS.No = Num++;
                handleHS.FunctionID = "A02";
                handleHS.OpeartionID = 4;
                handleHS.IsChecked = false;
                handleHS.Status = "待处理";
                this.Add(handleQS);
                this.Add(handleHS);
            }
        }

        /// <summary>
        /// 插入A03审批确认操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA03(Entity.JobInfo job)
        {
            DataTable dt = new NewlyAddedList().GetList("IsDelete=0 and JobType='NA001' and JobID='" + job.JobID + "'").Tables[0];
            if (dt.Rows.Count > 0 && job.IsOnline)
            {
                string shtyxydm = new NewlyAddedListFR().GetList("ListID='" + dt.Rows[0]["ListID"] + "'").Tables[0].Rows[0]["SHTYXYDM_QS"].ToString().Substring(2, 4);
                if (shtyxydm != "4401" && shtyxydm != "4400")
                {
                    Entity.HandleList handle = new Entity.HandleList();
                    handle.Guid = Guid.NewGuid().ToString();
                    handle.JobID = job.JobID;
                    handle.No = Num++;
                    handle.FunctionID = "A03";
                    handle.OpeartionID = 5;
                    handle.IsChecked = false;
                    handle.Status = "待处理";
                    this.Add(handle);
                }
            }
        }

        /// <summary>
        /// 插入A04制卡操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA04(Entity.JobInfo job)
        {
            Entity.HandleList handle = new Entity.HandleList();
            handle.Guid = Guid.NewGuid().ToString();
            handle.JobID = job.JobID;
            handle.No = Num;
            handle.FunctionID = "A04";
            handle.IsChecked = false;
            handle.Status = "待处理";
            switch (job.JobType)
            {
                case "NA":
                    DataTable dt = new NewlyAddedList().GetList("IsDelete=0 and JobID='" + job.JobID + "'").Tables[0];
                    if (dt.Select("JobType<>'NA001'").Length > 0)
                    {
                        handle.OpeartionID = 7;
                        if (dt.Select("JobType='NA001'").Length > 0)
                        {
                            Entity.HandleList handleFR = new Entity.HandleList();
                            handleFR.Guid = Guid.NewGuid().ToString();
                            handleFR.JobID = job.JobID;
                            handleFR.No = Num;
                            handleFR.FunctionID = "A04";
                            handleFR.OpeartionID = 6;
                            handleFR.IsChecked = false;
                            handleFR.Status = "待处理";
                            this.Add(handleFR);
                        }
                    }
                    else
                        handle.OpeartionID = 6;
                    break;
                case "MD":
                    if (new ModifyList().GetList("IsDelete=0 and IsChangeName=1 and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0)
                        handle.OpeartionID = 14;
                    else
                        return;
                    break;
                case "RI":
                    handle.OpeartionID = 15;
                    break;
                case "RM":
                    handle.OpeartionID = 17;
                    break;
                case "UU":
                    handle.OpeartionID = 16;
                    break;
            }
            Num++;
            this.Add(handle);
        }

        /// <summary>
        /// 插入A05财务确认操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA05(Entity.JobInfo job)
        {
            Entity.HandleList handleFee = new Entity.HandleList();
            handleFee.Guid = Guid.NewGuid().ToString();
            handleFee.JobID = job.JobID;
            handleFee.No = Num;
            handleFee.FunctionID = "A05";
            handleFee.OpeartionID = 8;
            handleFee.IsChecked = false;
            handleFee.Status = "待处理";
            Entity.HandleList handleInvoice = new Entity.HandleList();
            handleInvoice.Guid = Guid.NewGuid().ToString();
            handleInvoice.JobID = job.JobID;
            handleInvoice.No = Num++;
            handleInvoice.FunctionID = "A05";
            handleInvoice.OpeartionID = 18;
            handleInvoice.IsChecked = false;
            handleInvoice.Status = "待处理";
            this.Add(handleFee);
            this.Add(handleInvoice);
        }

        /// <summary>
        /// 插入A06发放操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA06(Entity.JobInfo job)
        {
            if (job.JobType == "MD")
                if (new ModifyList().GetList("IsDelete=0 and IsChangeName=1 and JobID='" + job.JobID + "'").Tables[0].Rows.Count == 0)
                    return;
            Entity.HandleList handle = new Entity.HandleList();
            handle.Guid = Guid.NewGuid().ToString();
            handle.JobID = job.JobID;
            handle.No = Num++;
            handle.FunctionID = "A06";
            handle.OpeartionID = (bool)job.ExpressFlat ? 10 : 9;
            handle.IsChecked = false;
            handle.Status = "待处理";
            this.Add(handle);
        }

        /// <summary>
        /// 插入A07收卡操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA07(Entity.JobInfo job)
        {
            if(job.JobType == "MD")
                if (new ModifyList().GetList("IsDelete=0 and IsChangeName=1 and JobID='" + job.JobID + "'").Tables[0].Rows.Count == 0)
                    return;
            Entity.HandleList handle = new Entity.HandleList();
            handle.Guid = Guid.NewGuid().ToString();
            handle.JobID = job.JobID;
            handle.No = Num;
            handle.FunctionID = "A07";
            handle.OpeartionID = 12;
            handle.IsChecked = false;
            handle.Status = "待处理";
            Entity.HandleList handleEx = new Entity.HandleList();
            handleEx.Guid = Guid.NewGuid().ToString();
            handleEx.JobID = job.JobID;
            handleEx.No = Num++;
            handleEx.FunctionID = "A07";
            handleEx.OpeartionID = 13;
            handleEx.IsChecked = false;
            handleEx.Status = "待处理";
            this.Add(handle);
            this.Add(handleEx);
        }

        /// <summary>
        /// 插入A08资料确认操作
        /// </summary>
        /// <param name="job">工单实体</param>
        /// <returns></returns>
        public void InsertA08(Entity.JobInfo job)
        {
            Entity.HandleList handle = new Entity.HandleList();
            handle.Guid = Guid.NewGuid().ToString();
            handle.JobID = job.JobID;
            handle.No = Num++;
            handle.FunctionID = "A08";
            handle.OpeartionID = 11;
            handle.IsChecked = false;
            handle.Status = "待处理";
            this.Add(handle);
        }

        public void DeleteJobID(string jobID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HandleList ");
            strSql.Append(" where JobID=@JobID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = jobID;

            TranHelper.AddTran(strSql, parameters);
        }

        public Entity.HandleList GetFeeData(string jobID)
        {
            DataTable dt = this.GetList("JobID='" + jobID + "' and OpeartionID=8").Tables[0];
            if (dt.Rows.Count > 0)
                return this.DataRowToModel(dt.Rows[0]);
            else
                return null;
        }
		#endregion  ExtensionMethod
	}
}

