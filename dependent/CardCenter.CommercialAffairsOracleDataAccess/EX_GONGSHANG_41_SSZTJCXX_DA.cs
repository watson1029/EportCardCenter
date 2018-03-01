
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CardCenter.CommercialAffairsOracleDataAccess
{
    public class EX_GONGSHANG_41_SSZTJCXX_DA
    {
        const string TableName = "EX_GONGSHANG_41_SSZTJCXX";
        public string TableUser;
        public ZWL.DataBase.DbHelperOra dbOra;
        public EX_GONGSHANG_41_SSZTJCXX_DA()
        {
            this.TableUser = ZWL.GeneralHelper.GetSettingByKey("TableUser");
            this.dbOra = new ZWL.DataBase.DbHelperOra(ZWL.GeneralHelper.GetSettingByKey("DBConnectionString"));
        }
        //        public DataTable List_EX_GONGSHANG_41_SSZTJCXX()
        //        {
        //            string sql = string.Format(@"select t.*
        //                              from (select t.*,
        //                                           ROW_NUMBER() OVER(PARTITION BY t.zch order by t.dtupdate desc, t.sflag asc) rn
        //                                      from {0}.EX_GONGSHANG_41_SSZTJCXX t ) t
        //                             where t.rn = 1 ", TableUser);

        //            DataTable dt = ListDataTable(sql);
        //            dt.TableName = TableName;

        //            return dt;
        //        }

        //public DataTable ListAllData()
        //{
        //    string sql = string.Format("select * from {0}.EX_GONGSHANG_41_SSZTJCXX ", TableUser);

        //    DataTable dt = ListDataTable(sql);

        //    return dt;
        //}


        /// <summary>
        /// 根据注册号获取商事主体基础信息
        /// </summary>
        /// <param name="uniscid">注册号--社会信用代码</param>
        /// <returns></returns>
        public DataTable GET_EX_GONGSHANG_41_SSZTJCXX_BYUNISCIDTest(string uniscid)
        {
            string sql = string.Format(@" 
                               select t.*  from {0}.{2} t where t.UNISCID='{1}' order by S_LAST_UPDATED desc 
                                 ", TableUser, uniscid, "EX_GONGSHANG_41_SSZTJCXX_BAK");



            DataTable dt = dbOra.Query(sql).Tables[0];
            if (dt != null)
            {
                dt.TableName = TableName;
            }

            return dt;
        }


        /// <summary>
        /// 根据注册号获取商事主体基础信息
        /// </summary>
        /// <param name="uniscid">注册号--社会信用代码</param>
        /// <returns></returns>
        public DataTable GET_EX_GONGSHANG_41_SSZTJCXX_BYUNISCID(string uniscid)
        {
            string sql = string.Format(@"select t.*
                              from (select t.*,substr(RJZCZB,0,instr(RJZCZB,'万',1,1)-1) RJZCZBVALUE,substr(RJZCZB,instr(RJZCZB,'万',1,1)+1) RJZCZBTYPE,
                                           ROW_NUMBER() OVER(PARTITION BY t.zch order by t.dtupdate desc, t.sflag asc) rn
                                      from {0}.{2} t where t.UNISCID='{1}' order by S_LAST_UPDATED desc) t
                               where t.rn = 1  and rownum=1 ", TableUser, uniscid, "EX_GONGSHANG_41_SSZTJCXX_BAK");

            DataTable dt = dbOra.Query(sql).Tables[0];
            if (dt != null)
            {
                dt.TableName = TableName;
            }

            return dt;
        }
        /// <summary>
        /// 根据注册号获取商事主体基础信息
        /// </summary>
        /// <param name="name">企业名称</param>
        /// <returns></returns>
        public DataTable GET_EX_GONGSHANG_41_SSZTJCXX_NAME(string name)
        {
            string sql = string.Format(@"select t.*
                              from (select t.*,substr(RJZCZB,0,instr(RJZCZB,'万',1,1)-1) RJZCZBVALUE,substr(RJZCZB,instr(RJZCZB,'万',1,1)+1) RJZCZBTYPE,
                                           ROW_NUMBER() OVER(PARTITION BY t.zch order by t.dtupdate desc, t.sflag asc) rn
                                      from {0}.{2} t where t.MC='{1}' order by S_LAST_UPDATED desc) t
                               where t.rn = 1  and rownum=1 ", TableUser, name, "EX_GONGSHANG_41_SSZTJCXX_BAK");

            DataTable dt = dbOra.Query(sql).Tables[0];
            if (dt != null)
            {
                dt.TableName = TableName;
            }

            return dt;
        }


        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="zch">注册号--社会信用代码</param>
        /// <returns></returns>
        public DataTable GET_EX_GONGSHANG_43_SSZTJYCX_BYZCH(string zch)
        {
            string sql = string.Format(@"select t.*
                              from (select t.*,
                                           ROW_NUMBER() OVER(PARTITION BY t.zch order by t.dtupdate desc, t.sflag asc) rn
                                      from {0}.{2} t where t.ZCH='{1}' order by S_LAST_UPDATED desc) t
                               where t.rn = 1  and rownum=1 ", TableUser, zch, "EX_GONGSHANG_43_SSZTJYCS_BAK");

            DataTable dt = dbOra.Query(sql).Tables[0];
            if (dt != null)
            {
                dt.TableName = TableName;
            }

            return dt;
        }


    }
}
