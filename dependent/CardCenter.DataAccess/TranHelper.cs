using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using ZWL;

namespace CardCenter.DataAccess
{
    public class TranHelper
    {
        private static SortHashTable tranSql
        {
            get
            {
                try
                {
                    SortHashTable tranSql = HttpContext.Current.Session["tranSql"] as SortHashTable;
                    return tranSql == null ? new SortHashTable() : tranSql;
                }
                catch
                {
                    return new SortHashTable();
                }
            }
            set
            {
                HttpContext.Current.Session["tranSql"] = value;
            }
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public static void BeginTran()
        {
            SortHashTable tran = tranSql;
            tran.Clear();
            tranSql = tran;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public static void CommitTran()
        {
            try
            {
                DataBase.DbHelperSQL DbHelperSQL;
                if (ZWL.GeneralHelper.GetSettingByKey("IsHash") == "YES")
                    DbHelperSQL = new DataBase.DbHelperSQL(new Encrypt.DESHelper("Card", "DES").DesDecrypt(ZWL.GeneralHelper.GetSettingByKey("ConnectionString")));
                else
                    DbHelperSQL = new DataBase.DbHelperSQL();
                if (DbHelperSQL.ExecuteSqlTran(tranSql))
                    DestoryTran();
                else
                    throw new Exception("提交失败!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        public static void AddTran(StringBuilder sql, SqlParameter[] param)
        {
            SortHashTable tran = tranSql;
            tran.Add(sql, param);
            tranSql = tran;
        }

        /// <summary>
        /// 销毁事务
        /// </summary>
        private static void DestoryTran()
        {
            SortHashTable tran = tranSql;
            tran.Clear();
            tranSql = tran;
        }
    }
}
