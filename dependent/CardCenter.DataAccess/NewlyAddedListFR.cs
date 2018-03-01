/**  版本信息模板在安装目录下，可自行修改。
* NewlyAddedListFR.cs
*
* 功 能： N/A
* 类 名： NewlyAddedListFR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/29 10:45:31   N/A    初版
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
	/// 数据访问类:NewlyAddedListFR
	/// </summary>
    public partial class NewlyAddedListFR : BaseDA
	{
		public NewlyAddedListFR()
		{}

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ListID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewlyAddedListFR");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = ListID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CardCenter.Entity.NewlyAddedListFR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewlyAddedListFR(");
            strSql.Append("ListID,SHTYXYDM_QS,ZTSBM_QS,XZQYHM_QS,QYZWMC_QS,QYYWMC_QS,QYDZ_QS,FDDBR_QS,FRDH_QS,QYLX_QS,ZCZJ_QS,ZCZJBZ_QS,YYQX_QS,ZJLX_QS_QS,ZJHM_QS,CZ_QS,YZBM_QS,FKJGDM_QS,FZJGMC_QS,FZRQ_QS,CLRQ_QS,FRLX_QS,GSSPDWDM_QS,ZJSPDWDM_QS,SWSPDWDM_QS,JYFW_QS,ZZJGDM_HG,HGZCH_HG,ZGHG_HG,BAHG_HG,ZCRQ_HG,YXRQ_HG,GSZCQC_HG,HGZCMC_HG,DWMC_HG,GSZCDZ_HG,DWDZ_HG,YYZZZCH_HG,YZBM_HG,FRDB_HG,FRDH_HG,BGLB_HG,ZJLX_HG,FRZJHM_HG,JCKQPZJG_HG,PZWH_HG,ZCZBBZ_HG,ZCZB_HG,ZJL_HG,DH_HG,KHYH_HG,YHZH_HG,SWDJH_HG,HYZL_HG,MSE_HG,ZYCP_HG,JYFWJBZ_HG,JCKQYDM_HG,QYSCLX_HG,BZ_HG,TZZE_HG,DWZBZE_HG,NXBL_HG,ZCYXRQ_HG,ZZJGDM_WJM,PZWH_WJM,JCKQYDM_WJM,PZRQ_WJM,FZRQ_WJM,FZJG_WJM,ZGWJM_WJM,QYZWMC_WJM,YWDZ_WJM,QYDZ_WJM,JYCS_WJM,ZGBM_WJM,FDDBR_WJM,ZS_WJM,LXDH_WJM,LXCZ_WJM,YZBM_WJM,DZYX_WJM,GSDJZCRQ_WJM,GSDJZCH_WJM,QYJYLX_WJM,JYNX_WJM,TZZE_WJM,TZBZ_WJM,ZCZB_WJM,ZCZBBZ_WJM,BADJBBH_WJM,ZCZJ_WJM,JYFW_WJM,JCKSPML_WJM,BZ_WJM,ZZJGDM_WH,GSZCH_WH,HGZCH_WH,HGZCYXQ_WH,ZGWHJ_WH,QYZWMC_WH,QYDZ_WH,CZ_WH,DH_WH,DZYX_WH,FDDBR_WH,HXLXR_WH,JYFW_WH,HYDM_WH,QYYB_WH,QYXZ_WH,RMBZCZJ_WH,WBZCBZ_WH,WBZCZJ_WH,ZCSLRQ_WH,JZYXRQ_WH,WMZSH_WH,WMZSPZRQ_WH,WMJYFW_WH,HXKHRQ_WH,QYLXMC_WH,NWFlat)");
            strSql.Append(" values (");
            strSql.Append("@ListID,@SHTYXYDM_QS,@ZTSBM_QS,@XZQYHM_QS,@QYZWMC_QS,@QYYWMC_QS,@QYDZ_QS,@FDDBR_QS,@FRDH_QS,@QYLX_QS,@ZCZJ_QS,@ZCZJBZ_QS,@YYQX_QS,@ZJLX_QS_QS,@ZJHM_QS,@CZ_QS,@YZBM_QS,@FKJGDM_QS,@FZJGMC_QS,@FZRQ_QS,@CLRQ_QS,@FRLX_QS,@GSSPDWDM_QS,@ZJSPDWDM_QS,@SWSPDWDM_QS,@JYFW_QS,@ZZJGDM_HG,@HGZCH_HG,@ZGHG_HG,@BAHG_HG,@ZCRQ_HG,@YXRQ_HG,@GSZCQC_HG,@HGZCMC_HG,@DWMC_HG,@GSZCDZ_HG,@DWDZ_HG,@YYZZZCH_HG,@YZBM_HG,@FRDB_HG,@FRDH_HG,@BGLB_HG,@ZJLX_HG,@FRZJHM_HG,@JCKQPZJG_HG,@PZWH_HG,@ZCZBBZ_HG,@ZCZB_HG,@ZJL_HG,@DH_HG,@KHYH_HG,@YHZH_HG,@SWDJH_HG,@HYZL_HG,@MSE_HG,@ZYCP_HG,@JYFWJBZ_HG,@JCKQYDM_HG,@QYSCLX_HG,@BZ_HG,@TZZE_HG,@DWZBZE_HG,@NXBL_HG,@ZCYXRQ_HG,@ZZJGDM_WJM,@PZWH_WJM,@JCKQYDM_WJM,@PZRQ_WJM,@FZRQ_WJM,@FZJG_WJM,@ZGWJM_WJM,@QYZWMC_WJM,@YWDZ_WJM,@QYDZ_WJM,@JYCS_WJM,@ZGBM_WJM,@FDDBR_WJM,@ZS_WJM,@LXDH_WJM,@LXCZ_WJM,@YZBM_WJM,@DZYX_WJM,@GSDJZCRQ_WJM,@GSDJZCH_WJM,@QYJYLX_WJM,@JYNX_WJM,@TZZE_WJM,@TZBZ_WJM,@ZCZB_WJM,@ZCZBBZ_WJM,@BADJBBH_WJM,@ZCZJ_WJM,@JYFW_WJM,@JCKSPML_WJM,@BZ_WJM,@ZZJGDM_WH,@GSZCH_WH,@HGZCH_WH,@HGZCYXQ_WH,@ZGWHJ_WH,@QYZWMC_WH,@QYDZ_WH,@CZ_WH,@DH_WH,@DZYX_WH,@FDDBR_WH,@HXLXR_WH,@JYFW_WH,@HYDM_WH,@QYYB_WH,@QYXZ_WH,@RMBZCZJ_WH,@WBZCBZ_WH,@WBZCZJ_WH,@ZCSLRQ_WH,@JZYXRQ_WH,@WMZSH_WH,@WMZSPZRQ_WH,@WMJYFW_WH,@HXKHRQ_WH,@QYLXMC_WH,@NWFlat)");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64),
					new SqlParameter("@SHTYXYDM_QS", SqlDbType.NVarChar,18),
					new SqlParameter("@ZTSBM_QS", SqlDbType.NVarChar,10),
					new SqlParameter("@XZQYHM_QS", SqlDbType.NVarChar,8),
					new SqlParameter("@QYZWMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@QYYWMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_QS", SqlDbType.NVarChar,512),
					new SqlParameter("@FDDBR_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@FRDH_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@QYLX_QS", SqlDbType.NVarChar,2),
					new SqlParameter("@ZCZJ_QS", SqlDbType.Decimal,9),
					new SqlParameter("@ZCZJBZ_QS", SqlDbType.NVarChar,3),
					new SqlParameter("@YYQX_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@ZJLX_QS_QS", SqlDbType.Int,4),
					new SqlParameter("@ZJHM_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@CZ_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@FKJGDM_QS", SqlDbType.NVarChar,2),
					new SqlParameter("@FZJGMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@FZRQ_QS", SqlDbType.Date,3),
					new SqlParameter("@CLRQ_QS", SqlDbType.Date,3),
					new SqlParameter("@FRLX_QS", SqlDbType.NVarChar,1),
					new SqlParameter("@GSSPDWDM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@ZJSPDWDM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@SWSPDWDM_QS", SqlDbType.NVarChar,9),
					new SqlParameter("@JYFW_QS", SqlDbType.NVarChar,4000),
					new SqlParameter("@ZZJGDM_HG", SqlDbType.NVarChar,9),
					new SqlParameter("@HGZCH_HG", SqlDbType.NVarChar,10),
					new SqlParameter("@ZGHG_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@BAHG_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@ZCRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@YXRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@GSZCQC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@HGZCMC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@DWMC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@GSZCDZ_HG", SqlDbType.NVarChar,512),
					new SqlParameter("@DWDZ_HG", SqlDbType.NVarChar,512),
					new SqlParameter("@YYZZZCH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_HG", SqlDbType.NVarChar,6),
					new SqlParameter("@FRDB_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@FRDH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@BGLB_HG", SqlDbType.NVarChar,1),
					new SqlParameter("@ZJLX_HG", SqlDbType.Int,4),
					new SqlParameter("@FRZJHM_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@JCKQPZJG_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@PZWH_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@ZCZBBZ_HG", SqlDbType.NVarChar,3),
					new SqlParameter("@ZCZB_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZJL_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@DH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@KHYH_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@YHZH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@SWDJH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@HYZL_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@MSE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZYCP_HG", SqlDbType.NVarChar,4000),
					new SqlParameter("@JYFWJBZ_HG", SqlDbType.NVarChar,4000),
					new SqlParameter("@JCKQYDM_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@QYSCLX_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@BZ_HG", SqlDbType.NVarChar,3),
					new SqlParameter("@TZZE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@DWZBZE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@NXBL_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZCYXRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@ZZJGDM_WJM", SqlDbType.NVarChar,9),
					new SqlParameter("@PZWH_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@JCKQYDM_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@PZRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@FZRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@FZJG_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@ZGWJM_WJM", SqlDbType.NVarChar,4),
					new SqlParameter("@QYZWMC_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@YWDZ_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@JYCS_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@ZGBM_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@FDDBR_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@ZS_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@LXDH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@LXCZ_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_WJM", SqlDbType.NVarChar,6),
					new SqlParameter("@DZYX_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@GSDJZCRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@GSDJZCH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@QYJYLX_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@JYNX_WJM", SqlDbType.Int,4),
					new SqlParameter("@TZZE_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@TZBZ_WJM", SqlDbType.NVarChar,3),
					new SqlParameter("@ZCZB_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@ZCZBBZ_WJM", SqlDbType.NVarChar,3),
					new SqlParameter("@BADJBBH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@ZCZJ_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@JYFW_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@JCKSPML_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@BZ_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@ZZJGDM_WH", SqlDbType.NVarChar,9),
					new SqlParameter("@GSZCH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HGZCH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HGZCYXQ_WH", SqlDbType.Date,3),
					new SqlParameter("@ZGWHJ_WH", SqlDbType.NVarChar,6),
					new SqlParameter("@QYZWMC_WH", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_WH", SqlDbType.NVarChar,512),
					new SqlParameter("@CZ_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@DH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@DZYX_WH", SqlDbType.NVarChar,256),
					new SqlParameter("@FDDBR_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HXLXR_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@JYFW_WH", SqlDbType.NVarChar,4000),
					new SqlParameter("@HYDM_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@QYYB_WH", SqlDbType.NVarChar,6),
					new SqlParameter("@QYXZ_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@RMBZCZJ_WH", SqlDbType.Decimal,9),
					new SqlParameter("@WBZCBZ_WH", SqlDbType.NVarChar,3),
					new SqlParameter("@WBZCZJ_WH", SqlDbType.Decimal,9),
					new SqlParameter("@ZCSLRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@JZYXRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@WMZSH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@WMZSPZRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@WMJYFW_WH", SqlDbType.NVarChar,4000),
					new SqlParameter("@HXKHRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@QYLXMC_WH", SqlDbType.NVarChar,32),
                    new SqlParameter("@NWFlat", SqlDbType.Int,4)};
            parameters[0].Value = model.ListID;
            parameters[1].Value = model.SHTYXYDM_QS;
            parameters[2].Value = model.ZTSBM_QS;
            parameters[3].Value = model.XZQYHM_QS;
            parameters[4].Value = model.QYZWMC_QS;
            parameters[5].Value = model.QYYWMC_QS;
            parameters[6].Value = model.QYDZ_QS;
            parameters[7].Value = model.FDDBR_QS;
            parameters[8].Value = model.FRDH_QS;
            parameters[9].Value = model.QYLX_QS;
            parameters[10].Value = model.ZCZJ_QS;
            parameters[11].Value = model.ZCZJBZ_QS;
            parameters[12].Value = model.YYQX_QS;
            parameters[13].Value = model.ZJLX_QS_QS;
            parameters[14].Value = model.ZJHM_QS;
            parameters[15].Value = model.CZ_QS;
            parameters[16].Value = model.YZBM_QS;
            parameters[17].Value = model.FKJGDM_QS;
            parameters[18].Value = model.FZJGMC_QS;
            parameters[19].Value = model.FZRQ_QS;
            parameters[20].Value = model.CLRQ_QS;
            parameters[21].Value = model.FRLX_QS;
            parameters[22].Value = model.GSSPDWDM_QS;
            parameters[23].Value = model.ZJSPDWDM_QS;
            parameters[24].Value = model.SWSPDWDM_QS;
            parameters[25].Value = model.JYFW_QS;
            parameters[26].Value = model.ZZJGDM_HG;
            parameters[27].Value = model.HGZCH_HG;
            parameters[28].Value = model.ZGHG_HG;
            parameters[29].Value = model.BAHG_HG;
            parameters[30].Value = model.ZCRQ_HG;
            parameters[31].Value = model.YXRQ_HG;
            parameters[32].Value = model.GSZCQC_HG;
            parameters[33].Value = model.HGZCMC_HG;
            parameters[34].Value = model.DWMC_HG;
            parameters[35].Value = model.GSZCDZ_HG;
            parameters[36].Value = model.DWDZ_HG;
            parameters[37].Value = model.YYZZZCH_HG;
            parameters[38].Value = model.YZBM_HG;
            parameters[39].Value = model.FRDB_HG;
            parameters[40].Value = model.FRDH_HG;
            parameters[41].Value = model.BGLB_HG;
            parameters[42].Value = model.ZJLX_HG;
            parameters[43].Value = model.FRZJHM_HG;
            parameters[44].Value = model.JCKQPZJG_HG;
            parameters[45].Value = model.PZWH_HG;
            parameters[46].Value = model.ZCZBBZ_HG;
            parameters[47].Value = model.ZCZB_HG;
            parameters[48].Value = model.ZJL_HG;
            parameters[49].Value = model.DH_HG;
            parameters[50].Value = model.KHYH_HG;
            parameters[51].Value = model.YHZH_HG;
            parameters[52].Value = model.SWDJH_HG;
            parameters[53].Value = model.HYZL_HG;
            parameters[54].Value = model.MSE_HG;
            parameters[55].Value = model.ZYCP_HG;
            parameters[56].Value = model.JYFWJBZ_HG;
            parameters[57].Value = model.JCKQYDM_HG;
            parameters[58].Value = model.QYSCLX_HG;
            parameters[59].Value = model.BZ_HG;
            parameters[60].Value = model.TZZE_HG;
            parameters[61].Value = model.DWZBZE_HG;
            parameters[62].Value = model.NXBL_HG;
            parameters[63].Value = model.ZCYXRQ_HG;
            parameters[64].Value = model.ZZJGDM_WJM;
            parameters[65].Value = model.PZWH_WJM;
            parameters[66].Value = model.JCKQYDM_WJM;
            parameters[67].Value = model.PZRQ_WJM;
            parameters[68].Value = model.FZRQ_WJM;
            parameters[69].Value = model.FZJG_WJM;
            parameters[70].Value = model.ZGWJM_WJM;
            parameters[71].Value = model.QYZWMC_WJM;
            parameters[72].Value = model.YWDZ_WJM;
            parameters[73].Value = model.QYDZ_WJM;
            parameters[74].Value = model.JYCS_WJM;
            parameters[75].Value = model.ZGBM_WJM;
            parameters[76].Value = model.FDDBR_WJM;
            parameters[77].Value = model.ZS_WJM;
            parameters[78].Value = model.LXDH_WJM;
            parameters[79].Value = model.LXCZ_WJM;
            parameters[80].Value = model.YZBM_WJM;
            parameters[81].Value = model.DZYX_WJM;
            parameters[82].Value = model.GSDJZCRQ_WJM;
            parameters[83].Value = model.GSDJZCH_WJM;
            parameters[84].Value = model.QYJYLX_WJM;
            parameters[85].Value = model.JYNX_WJM;
            parameters[86].Value = model.TZZE_WJM;
            parameters[87].Value = model.TZBZ_WJM;
            parameters[88].Value = model.ZCZB_WJM;
            parameters[89].Value = model.ZCZBBZ_WJM;
            parameters[90].Value = model.BADJBBH_WJM;
            parameters[91].Value = model.ZCZJ_WJM;
            parameters[92].Value = model.JYFW_WJM;
            parameters[93].Value = model.JCKSPML_WJM;
            parameters[94].Value = model.BZ_WJM;
            parameters[95].Value = model.ZZJGDM_WH;
            parameters[96].Value = model.GSZCH_WH;
            parameters[97].Value = model.HGZCH_WH;
            parameters[98].Value = model.HGZCYXQ_WH;
            parameters[99].Value = model.ZGWHJ_WH;
            parameters[100].Value = model.QYZWMC_WH;
            parameters[101].Value = model.QYDZ_WH;
            parameters[102].Value = model.CZ_WH;
            parameters[103].Value = model.DH_WH;
            parameters[104].Value = model.DZYX_WH;
            parameters[105].Value = model.FDDBR_WH;
            parameters[106].Value = model.HXLXR_WH;
            parameters[107].Value = model.JYFW_WH;
            parameters[108].Value = model.HYDM_WH;
            parameters[109].Value = model.QYYB_WH;
            parameters[110].Value = model.QYXZ_WH;
            parameters[111].Value = model.RMBZCZJ_WH;
            parameters[112].Value = model.WBZCBZ_WH;
            parameters[113].Value = model.WBZCZJ_WH;
            parameters[114].Value = model.ZCSLRQ_WH;
            parameters[115].Value = model.JZYXRQ_WH;
            parameters[116].Value = model.WMZSH_WH;
            parameters[117].Value = model.WMZSPZRQ_WH;
            parameters[118].Value = model.WMJYFW_WH;
            parameters[119].Value = model.HXKHRQ_WH;
            parameters[120].Value = model.QYLXMC_WH;
            parameters[121].Value = model.NWFlat;

            TranHelper.AddTran(strSql, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(CardCenter.Entity.NewlyAddedListFR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewlyAddedListFR set ");
            strSql.Append("SHTYXYDM_QS=@SHTYXYDM_QS,");
            strSql.Append("ZTSBM_QS=@ZTSBM_QS,");
            strSql.Append("XZQYHM_QS=@XZQYHM_QS,");
            strSql.Append("QYZWMC_QS=@QYZWMC_QS,");
            strSql.Append("QYYWMC_QS=@QYYWMC_QS,");
            strSql.Append("QYDZ_QS=@QYDZ_QS,");
            strSql.Append("FDDBR_QS=@FDDBR_QS,");
            strSql.Append("FRDH_QS=@FRDH_QS,");
            strSql.Append("QYLX_QS=@QYLX_QS,");
            strSql.Append("ZCZJ_QS=@ZCZJ_QS,");
            strSql.Append("ZCZJBZ_QS=@ZCZJBZ_QS,");
            strSql.Append("YYQX_QS=@YYQX_QS,");
            strSql.Append("ZJLX_QS_QS=@ZJLX_QS_QS,");
            strSql.Append("ZJHM_QS=@ZJHM_QS,");
            strSql.Append("CZ_QS=@CZ_QS,");
            strSql.Append("YZBM_QS=@YZBM_QS,");
            strSql.Append("FKJGDM_QS=@FKJGDM_QS,");
            strSql.Append("FZJGMC_QS=@FZJGMC_QS,");
            strSql.Append("FZRQ_QS=@FZRQ_QS,");
            strSql.Append("CLRQ_QS=@CLRQ_QS,");
            strSql.Append("FRLX_QS=@FRLX_QS,");
            strSql.Append("GSSPDWDM_QS=@GSSPDWDM_QS,");
            strSql.Append("ZJSPDWDM_QS=@ZJSPDWDM_QS,");
            strSql.Append("SWSPDWDM_QS=@SWSPDWDM_QS,");
            strSql.Append("JYFW_QS=@JYFW_QS,");
            strSql.Append("ZZJGDM_HG=@ZZJGDM_HG,");
            strSql.Append("HGZCH_HG=@HGZCH_HG,");
            strSql.Append("ZGHG_HG=@ZGHG_HG,");
            strSql.Append("BAHG_HG=@BAHG_HG,");
            strSql.Append("ZCRQ_HG=@ZCRQ_HG,");
            strSql.Append("YXRQ_HG=@YXRQ_HG,");
            strSql.Append("GSZCQC_HG=@GSZCQC_HG,");
            strSql.Append("HGZCMC_HG=@HGZCMC_HG,");
            strSql.Append("DWMC_HG=@DWMC_HG,");
            strSql.Append("GSZCDZ_HG=@GSZCDZ_HG,");
            strSql.Append("DWDZ_HG=@DWDZ_HG,");
            strSql.Append("YYZZZCH_HG=@YYZZZCH_HG,");
            strSql.Append("YZBM_HG=@YZBM_HG,");
            strSql.Append("FRDB_HG=@FRDB_HG,");
            strSql.Append("FRDH_HG=@FRDH_HG,");
            strSql.Append("BGLB_HG=@BGLB_HG,");
            strSql.Append("ZJLX_HG=@ZJLX_HG,");
            strSql.Append("FRZJHM_HG=@FRZJHM_HG,");
            strSql.Append("JCKQPZJG_HG=@JCKQPZJG_HG,");
            strSql.Append("PZWH_HG=@PZWH_HG,");
            strSql.Append("ZCZBBZ_HG=@ZCZBBZ_HG,");
            strSql.Append("ZCZB_HG=@ZCZB_HG,");
            strSql.Append("ZJL_HG=@ZJL_HG,");
            strSql.Append("DH_HG=@DH_HG,");
            strSql.Append("KHYH_HG=@KHYH_HG,");
            strSql.Append("YHZH_HG=@YHZH_HG,");
            strSql.Append("SWDJH_HG=@SWDJH_HG,");
            strSql.Append("HYZL_HG=@HYZL_HG,");
            strSql.Append("MSE_HG=@MSE_HG,");
            strSql.Append("ZYCP_HG=@ZYCP_HG,");
            strSql.Append("JYFWJBZ_HG=@JYFWJBZ_HG,");
            strSql.Append("JCKQYDM_HG=@JCKQYDM_HG,");
            strSql.Append("QYSCLX_HG=@QYSCLX_HG,");
            strSql.Append("BZ_HG=@BZ_HG,");
            strSql.Append("TZZE_HG=@TZZE_HG,");
            strSql.Append("DWZBZE_HG=@DWZBZE_HG,");
            strSql.Append("NXBL_HG=@NXBL_HG,");
            strSql.Append("ZCYXRQ_HG=@ZCYXRQ_HG,");
            strSql.Append("ZZJGDM_WJM=@ZZJGDM_WJM,");
            strSql.Append("PZWH_WJM=@PZWH_WJM,");
            strSql.Append("JCKQYDM_WJM=@JCKQYDM_WJM,");
            strSql.Append("PZRQ_WJM=@PZRQ_WJM,");
            strSql.Append("FZRQ_WJM=@FZRQ_WJM,");
            strSql.Append("FZJG_WJM=@FZJG_WJM,");
            strSql.Append("ZGWJM_WJM=@ZGWJM_WJM,");
            strSql.Append("QYZWMC_WJM=@QYZWMC_WJM,");
            strSql.Append("YWDZ_WJM=@YWDZ_WJM,");
            strSql.Append("QYDZ_WJM=@QYDZ_WJM,");
            strSql.Append("JYCS_WJM=@JYCS_WJM,");
            strSql.Append("ZGBM_WJM=@ZGBM_WJM,");
            strSql.Append("FDDBR_WJM=@FDDBR_WJM,");
            strSql.Append("ZS_WJM=@ZS_WJM,");
            strSql.Append("LXDH_WJM=@LXDH_WJM,");
            strSql.Append("LXCZ_WJM=@LXCZ_WJM,");
            strSql.Append("YZBM_WJM=@YZBM_WJM,");
            strSql.Append("DZYX_WJM=@DZYX_WJM,");
            strSql.Append("GSDJZCRQ_WJM=@GSDJZCRQ_WJM,");
            strSql.Append("GSDJZCH_WJM=@GSDJZCH_WJM,");
            strSql.Append("QYJYLX_WJM=@QYJYLX_WJM,");
            strSql.Append("JYNX_WJM=@JYNX_WJM,");
            strSql.Append("TZZE_WJM=@TZZE_WJM,");
            strSql.Append("TZBZ_WJM=@TZBZ_WJM,");
            strSql.Append("ZCZB_WJM=@ZCZB_WJM,");
            strSql.Append("ZCZBBZ_WJM=@ZCZBBZ_WJM,");
            strSql.Append("BADJBBH_WJM=@BADJBBH_WJM,");
            strSql.Append("ZCZJ_WJM=@ZCZJ_WJM,");
            strSql.Append("JYFW_WJM=@JYFW_WJM,");
            strSql.Append("JCKSPML_WJM=@JCKSPML_WJM,");
            strSql.Append("BZ_WJM=@BZ_WJM,");
            strSql.Append("ZZJGDM_WH=@ZZJGDM_WH,");
            strSql.Append("GSZCH_WH=@GSZCH_WH,");
            strSql.Append("HGZCH_WH=@HGZCH_WH,");
            strSql.Append("HGZCYXQ_WH=@HGZCYXQ_WH,");
            strSql.Append("ZGWHJ_WH=@ZGWHJ_WH,");
            strSql.Append("QYZWMC_WH=@QYZWMC_WH,");
            strSql.Append("QYDZ_WH=@QYDZ_WH,");
            strSql.Append("CZ_WH=@CZ_WH,");
            strSql.Append("DH_WH=@DH_WH,");
            strSql.Append("DZYX_WH=@DZYX_WH,");
            strSql.Append("FDDBR_WH=@FDDBR_WH,");
            strSql.Append("HXLXR_WH=@HXLXR_WH,");
            strSql.Append("JYFW_WH=@JYFW_WH,");
            strSql.Append("HYDM_WH=@HYDM_WH,");
            strSql.Append("QYYB_WH=@QYYB_WH,");
            strSql.Append("QYXZ_WH=@QYXZ_WH,");
            strSql.Append("RMBZCZJ_WH=@RMBZCZJ_WH,");
            strSql.Append("WBZCBZ_WH=@WBZCBZ_WH,");
            strSql.Append("WBZCZJ_WH=@WBZCZJ_WH,");
            strSql.Append("ZCSLRQ_WH=@ZCSLRQ_WH,");
            strSql.Append("JZYXRQ_WH=@JZYXRQ_WH,");
            strSql.Append("WMZSH_WH=@WMZSH_WH,");
            strSql.Append("WMZSPZRQ_WH=@WMZSPZRQ_WH,");
            strSql.Append("WMJYFW_WH=@WMJYFW_WH,");
            strSql.Append("HXKHRQ_WH=@HXKHRQ_WH,");
            strSql.Append("QYLXMC_WH=@QYLXMC_WH,");
            strSql.Append("NWFlat=@NWFlat");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SHTYXYDM_QS", SqlDbType.NVarChar,18),
					new SqlParameter("@ZTSBM_QS", SqlDbType.NVarChar,10),
					new SqlParameter("@XZQYHM_QS", SqlDbType.NVarChar,8),
					new SqlParameter("@QYZWMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@QYYWMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_QS", SqlDbType.NVarChar,512),
					new SqlParameter("@FDDBR_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@FRDH_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@QYLX_QS", SqlDbType.NVarChar,2),
					new SqlParameter("@ZCZJ_QS", SqlDbType.Decimal,9),
					new SqlParameter("@ZCZJBZ_QS", SqlDbType.NVarChar,3),
					new SqlParameter("@YYQX_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@ZJLX_QS_QS", SqlDbType.Int,4),
					new SqlParameter("@ZJHM_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@CZ_QS", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@FKJGDM_QS", SqlDbType.NVarChar,2),
					new SqlParameter("@FZJGMC_QS", SqlDbType.NVarChar,256),
					new SqlParameter("@FZRQ_QS", SqlDbType.Date,3),
					new SqlParameter("@CLRQ_QS", SqlDbType.Date,3),
					new SqlParameter("@FRLX_QS", SqlDbType.NVarChar,1),
					new SqlParameter("@GSSPDWDM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@ZJSPDWDM_QS", SqlDbType.NVarChar,6),
					new SqlParameter("@SWSPDWDM_QS", SqlDbType.NVarChar,9),
					new SqlParameter("@JYFW_QS", SqlDbType.NVarChar,4000),
					new SqlParameter("@ZZJGDM_HG", SqlDbType.NVarChar,9),
					new SqlParameter("@HGZCH_HG", SqlDbType.NVarChar,10),
					new SqlParameter("@ZGHG_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@BAHG_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@ZCRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@YXRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@GSZCQC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@HGZCMC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@DWMC_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@GSZCDZ_HG", SqlDbType.NVarChar,512),
					new SqlParameter("@DWDZ_HG", SqlDbType.NVarChar,512),
					new SqlParameter("@YYZZZCH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_HG", SqlDbType.NVarChar,6),
					new SqlParameter("@FRDB_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@FRDH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@BGLB_HG", SqlDbType.NVarChar,1),
					new SqlParameter("@ZJLX_HG", SqlDbType.Int,4),
					new SqlParameter("@FRZJHM_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@JCKQPZJG_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@PZWH_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@ZCZBBZ_HG", SqlDbType.NVarChar,3),
					new SqlParameter("@ZCZB_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZJL_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@DH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@KHYH_HG", SqlDbType.NVarChar,256),
					new SqlParameter("@YHZH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@SWDJH_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@HYZL_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@MSE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZYCP_HG", SqlDbType.NVarChar,4000),
					new SqlParameter("@JYFWJBZ_HG", SqlDbType.NVarChar,4000),
					new SqlParameter("@JCKQYDM_HG", SqlDbType.NVarChar,32),
					new SqlParameter("@QYSCLX_HG", SqlDbType.NVarChar,4),
					new SqlParameter("@BZ_HG", SqlDbType.NVarChar,3),
					new SqlParameter("@TZZE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@DWZBZE_HG", SqlDbType.Decimal,9),
					new SqlParameter("@NXBL_HG", SqlDbType.Decimal,9),
					new SqlParameter("@ZCYXRQ_HG", SqlDbType.Date,3),
					new SqlParameter("@ZZJGDM_WJM", SqlDbType.NVarChar,9),
					new SqlParameter("@PZWH_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@JCKQYDM_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@PZRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@FZRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@FZJG_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@ZGWJM_WJM", SqlDbType.NVarChar,4),
					new SqlParameter("@QYZWMC_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@YWDZ_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@JYCS_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@ZGBM_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@FDDBR_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@ZS_WJM", SqlDbType.NVarChar,512),
					new SqlParameter("@LXDH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@LXCZ_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@YZBM_WJM", SqlDbType.NVarChar,6),
					new SqlParameter("@DZYX_WJM", SqlDbType.NVarChar,256),
					new SqlParameter("@GSDJZCRQ_WJM", SqlDbType.Date,3),
					new SqlParameter("@GSDJZCH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@QYJYLX_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@JYNX_WJM", SqlDbType.Int,4),
					new SqlParameter("@TZZE_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@TZBZ_WJM", SqlDbType.NVarChar,3),
					new SqlParameter("@ZCZB_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@ZCZBBZ_WJM", SqlDbType.NVarChar,3),
					new SqlParameter("@BADJBBH_WJM", SqlDbType.NVarChar,32),
					new SqlParameter("@ZCZJ_WJM", SqlDbType.Decimal,9),
					new SqlParameter("@JYFW_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@JCKSPML_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@BZ_WJM", SqlDbType.NVarChar,4000),
					new SqlParameter("@ZZJGDM_WH", SqlDbType.NVarChar,9),
					new SqlParameter("@GSZCH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HGZCH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HGZCYXQ_WH", SqlDbType.Date,3),
					new SqlParameter("@ZGWHJ_WH", SqlDbType.NVarChar,6),
					new SqlParameter("@QYZWMC_WH", SqlDbType.NVarChar,256),
					new SqlParameter("@QYDZ_WH", SqlDbType.NVarChar,512),
					new SqlParameter("@CZ_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@DH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@DZYX_WH", SqlDbType.NVarChar,256),
					new SqlParameter("@FDDBR_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@HXLXR_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@JYFW_WH", SqlDbType.NVarChar,4000),
					new SqlParameter("@HYDM_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@QYYB_WH", SqlDbType.NVarChar,6),
					new SqlParameter("@QYXZ_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@RMBZCZJ_WH", SqlDbType.Decimal,9),
					new SqlParameter("@WBZCBZ_WH", SqlDbType.NVarChar,3),
					new SqlParameter("@WBZCZJ_WH", SqlDbType.Decimal,9),
					new SqlParameter("@ZCSLRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@JZYXRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@WMZSH_WH", SqlDbType.NVarChar,32),
					new SqlParameter("@WMZSPZRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@WMJYFW_WH", SqlDbType.NVarChar,4000),
					new SqlParameter("@HXKHRQ_WH", SqlDbType.Date,3),
					new SqlParameter("@QYLXMC_WH", SqlDbType.NVarChar,32),
                    new SqlParameter("@NWFlat", SqlDbType.Int,4),
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.SHTYXYDM_QS;
            parameters[1].Value = model.ZTSBM_QS;
            parameters[2].Value = model.XZQYHM_QS;
            parameters[3].Value = model.QYZWMC_QS;
            parameters[4].Value = model.QYYWMC_QS;
            parameters[5].Value = model.QYDZ_QS;
            parameters[6].Value = model.FDDBR_QS;
            parameters[7].Value = model.FRDH_QS;
            parameters[8].Value = model.QYLX_QS;
            parameters[9].Value = model.ZCZJ_QS;
            parameters[10].Value = model.ZCZJBZ_QS;
            parameters[11].Value = model.YYQX_QS;
            parameters[12].Value = model.ZJLX_QS_QS;
            parameters[13].Value = model.ZJHM_QS;
            parameters[14].Value = model.CZ_QS;
            parameters[15].Value = model.YZBM_QS;
            parameters[16].Value = model.FKJGDM_QS;
            parameters[17].Value = model.FZJGMC_QS;
            parameters[18].Value = model.FZRQ_QS;
            parameters[19].Value = model.CLRQ_QS;
            parameters[20].Value = model.FRLX_QS;
            parameters[21].Value = model.GSSPDWDM_QS;
            parameters[22].Value = model.ZJSPDWDM_QS;
            parameters[23].Value = model.SWSPDWDM_QS;
            parameters[24].Value = model.JYFW_QS;
            parameters[25].Value = model.ZZJGDM_HG;
            parameters[26].Value = model.HGZCH_HG;
            parameters[27].Value = model.ZGHG_HG;
            parameters[28].Value = model.BAHG_HG;
            parameters[29].Value = model.ZCRQ_HG;
            parameters[30].Value = model.YXRQ_HG;
            parameters[31].Value = model.GSZCQC_HG;
            parameters[32].Value = model.HGZCMC_HG;
            parameters[33].Value = model.DWMC_HG;
            parameters[34].Value = model.GSZCDZ_HG;
            parameters[35].Value = model.DWDZ_HG;
            parameters[36].Value = model.YYZZZCH_HG;
            parameters[37].Value = model.YZBM_HG;
            parameters[38].Value = model.FRDB_HG;
            parameters[39].Value = model.FRDH_HG;
            parameters[40].Value = model.BGLB_HG;
            parameters[41].Value = model.ZJLX_HG;
            parameters[42].Value = model.FRZJHM_HG;
            parameters[43].Value = model.JCKQPZJG_HG;
            parameters[44].Value = model.PZWH_HG;
            parameters[45].Value = model.ZCZBBZ_HG;
            parameters[46].Value = model.ZCZB_HG;
            parameters[47].Value = model.ZJL_HG;
            parameters[48].Value = model.DH_HG;
            parameters[49].Value = model.KHYH_HG;
            parameters[50].Value = model.YHZH_HG;
            parameters[51].Value = model.SWDJH_HG;
            parameters[52].Value = model.HYZL_HG;
            parameters[53].Value = model.MSE_HG;
            parameters[54].Value = model.ZYCP_HG;
            parameters[55].Value = model.JYFWJBZ_HG;
            parameters[56].Value = model.JCKQYDM_HG;
            parameters[57].Value = model.QYSCLX_HG;
            parameters[58].Value = model.BZ_HG;
            parameters[59].Value = model.TZZE_HG;
            parameters[60].Value = model.DWZBZE_HG;
            parameters[61].Value = model.NXBL_HG;
            parameters[62].Value = model.ZCYXRQ_HG;
            parameters[63].Value = model.ZZJGDM_WJM;
            parameters[64].Value = model.PZWH_WJM;
            parameters[65].Value = model.JCKQYDM_WJM;
            parameters[66].Value = model.PZRQ_WJM;
            parameters[67].Value = model.FZRQ_WJM;
            parameters[68].Value = model.FZJG_WJM;
            parameters[69].Value = model.ZGWJM_WJM;
            parameters[70].Value = model.QYZWMC_WJM;
            parameters[71].Value = model.YWDZ_WJM;
            parameters[72].Value = model.QYDZ_WJM;
            parameters[73].Value = model.JYCS_WJM;
            parameters[74].Value = model.ZGBM_WJM;
            parameters[75].Value = model.FDDBR_WJM;
            parameters[76].Value = model.ZS_WJM;
            parameters[77].Value = model.LXDH_WJM;
            parameters[78].Value = model.LXCZ_WJM;
            parameters[79].Value = model.YZBM_WJM;
            parameters[80].Value = model.DZYX_WJM;
            parameters[81].Value = model.GSDJZCRQ_WJM;
            parameters[82].Value = model.GSDJZCH_WJM;
            parameters[83].Value = model.QYJYLX_WJM;
            parameters[84].Value = model.JYNX_WJM;
            parameters[85].Value = model.TZZE_WJM;
            parameters[86].Value = model.TZBZ_WJM;
            parameters[87].Value = model.ZCZB_WJM;
            parameters[88].Value = model.ZCZBBZ_WJM;
            parameters[89].Value = model.BADJBBH_WJM;
            parameters[90].Value = model.ZCZJ_WJM;
            parameters[91].Value = model.JYFW_WJM;
            parameters[92].Value = model.JCKSPML_WJM;
            parameters[93].Value = model.BZ_WJM;
            parameters[94].Value = model.ZZJGDM_WH;
            parameters[95].Value = model.GSZCH_WH;
            parameters[96].Value = model.HGZCH_WH;
            parameters[97].Value = model.HGZCYXQ_WH;
            parameters[98].Value = model.ZGWHJ_WH;
            parameters[99].Value = model.QYZWMC_WH;
            parameters[100].Value = model.QYDZ_WH;
            parameters[101].Value = model.CZ_WH;
            parameters[102].Value = model.DH_WH;
            parameters[103].Value = model.DZYX_WH;
            parameters[104].Value = model.FDDBR_WH;
            parameters[105].Value = model.HXLXR_WH;
            parameters[106].Value = model.JYFW_WH;
            parameters[107].Value = model.HYDM_WH;
            parameters[108].Value = model.QYYB_WH;
            parameters[109].Value = model.QYXZ_WH;
            parameters[110].Value = model.RMBZCZJ_WH;
            parameters[111].Value = model.WBZCBZ_WH;
            parameters[112].Value = model.WBZCZJ_WH;
            parameters[113].Value = model.ZCSLRQ_WH;
            parameters[114].Value = model.JZYXRQ_WH;
            parameters[115].Value = model.WMZSH_WH;
            parameters[116].Value = model.WMZSPZRQ_WH;
            parameters[117].Value = model.WMJYFW_WH;
            parameters[118].Value = model.HXKHRQ_WH;
            parameters[119].Value = model.QYLXMC_WH;
            parameters[120].Value = model.NWFlat;
            parameters[121].Value = model.ListID;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewlyAddedListFR ");
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
            strSql.Append("delete from NewlyAddedListFR ");
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
        public CardCenter.Entity.NewlyAddedListFR GetModel(string ListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ListID,SHTYXYDM_QS,ZTSBM_QS,XZQYHM_QS,QYZWMC_QS,QYYWMC_QS,QYDZ_QS,FDDBR_QS,FRDH_QS,QYLX_QS,ZCZJ_QS,ZCZJBZ_QS,YYQX_QS,ZJLX_QS_QS,ZJHM_QS,CZ_QS,YZBM_QS,FKJGDM_QS,FZJGMC_QS,FZRQ_QS,CLRQ_QS,FRLX_QS,GSSPDWDM_QS,ZJSPDWDM_QS,SWSPDWDM_QS,JYFW_QS,ZZJGDM_HG,HGZCH_HG,ZGHG_HG,BAHG_HG,ZCRQ_HG,YXRQ_HG,GSZCQC_HG,HGZCMC_HG,DWMC_HG,GSZCDZ_HG,DWDZ_HG,YYZZZCH_HG,YZBM_HG,FRDB_HG,FRDH_HG,BGLB_HG,ZJLX_HG,FRZJHM_HG,JCKQPZJG_HG,PZWH_HG,ZCZBBZ_HG,ZCZB_HG,ZJL_HG,DH_HG,KHYH_HG,YHZH_HG,SWDJH_HG,HYZL_HG,MSE_HG,ZYCP_HG,JYFWJBZ_HG,JCKQYDM_HG,QYSCLX_HG,BZ_HG,TZZE_HG,DWZBZE_HG,NXBL_HG,ZCYXRQ_HG,ZZJGDM_WJM,PZWH_WJM,JCKQYDM_WJM,PZRQ_WJM,FZRQ_WJM,FZJG_WJM,ZGWJM_WJM,QYZWMC_WJM,YWDZ_WJM,QYDZ_WJM,JYCS_WJM,ZGBM_WJM,FDDBR_WJM,ZS_WJM,LXDH_WJM,LXCZ_WJM,YZBM_WJM,DZYX_WJM,GSDJZCRQ_WJM,GSDJZCH_WJM,QYJYLX_WJM,JYNX_WJM,TZZE_WJM,TZBZ_WJM,ZCZB_WJM,ZCZBBZ_WJM,BADJBBH_WJM,ZCZJ_WJM,JYFW_WJM,JCKSPML_WJM,BZ_WJM,ZZJGDM_WH,GSZCH_WH,HGZCH_WH,HGZCYXQ_WH,ZGWHJ_WH,QYZWMC_WH,QYDZ_WH,CZ_WH,DH_WH,DZYX_WH,FDDBR_WH,HXLXR_WH,JYFW_WH,HYDM_WH,QYYB_WH,QYXZ_WH,RMBZCZJ_WH,WBZCBZ_WH,WBZCZJ_WH,ZCSLRQ_WH,JZYXRQ_WH,WMZSH_WH,WMZSPZRQ_WH,WMJYFW_WH,HXKHRQ_WH,QYLXMC_WH,NWFlat from NewlyAddedListFR ");
            strSql.Append(" where ListID=@ListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
            parameters[0].Value = ListID;

            CardCenter.Entity.NewlyAddedListFR model = new CardCenter.Entity.NewlyAddedListFR();
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
        public CardCenter.Entity.NewlyAddedListFR DataRowToModel(DataRow row)
        {
            CardCenter.Entity.NewlyAddedListFR model = new CardCenter.Entity.NewlyAddedListFR();
            if (row != null)
            {
                if (row["ListID"] != null)
                {
                    model.ListID = row["ListID"].ToString();
                }
                if (row["SHTYXYDM_QS"] != null)
                {
                    model.SHTYXYDM_QS = row["SHTYXYDM_QS"].ToString();
                }
                if (row["ZTSBM_QS"] != null)
                {
                    model.ZTSBM_QS = row["ZTSBM_QS"].ToString();
                }
                if (row["XZQYHM_QS"] != null)
                {
                    model.XZQYHM_QS = row["XZQYHM_QS"].ToString();
                }
                if (row["QYZWMC_QS"] != null)
                {
                    model.QYZWMC_QS = row["QYZWMC_QS"].ToString();
                }
                if (row["QYYWMC_QS"] != null)
                {
                    model.QYYWMC_QS = row["QYYWMC_QS"].ToString();
                }
                if (row["QYDZ_QS"] != null)
                {
                    model.QYDZ_QS = row["QYDZ_QS"].ToString();
                }
                if (row["FDDBR_QS"] != null)
                {
                    model.FDDBR_QS = row["FDDBR_QS"].ToString();
                }
                if (row["FRDH_QS"] != null)
                {
                    model.FRDH_QS = row["FRDH_QS"].ToString();
                }
                if (row["QYLX_QS"] != null)
                {
                    model.QYLX_QS = row["QYLX_QS"].ToString();
                }
                if (row["ZCZJ_QS"] != null && row["ZCZJ_QS"].ToString() != "")
                {
                    model.ZCZJ_QS = decimal.Parse(row["ZCZJ_QS"].ToString());
                }
                if (row["ZCZJBZ_QS"] != null)
                {
                    model.ZCZJBZ_QS = row["ZCZJBZ_QS"].ToString();
                }
                if (row["YYQX_QS"] != null)
                {
                    model.YYQX_QS = row["YYQX_QS"].ToString();
                }
                if (row["ZJLX_QS_QS"] != null && row["ZJLX_QS_QS"].ToString() != "")
                {
                    model.ZJLX_QS_QS = int.Parse(row["ZJLX_QS_QS"].ToString());
                }
                if (row["ZJHM_QS"] != null)
                {
                    model.ZJHM_QS = row["ZJHM_QS"].ToString();
                }
                if (row["CZ_QS"] != null)
                {
                    model.CZ_QS = row["CZ_QS"].ToString();
                }
                if (row["YZBM_QS"] != null)
                {
                    model.YZBM_QS = row["YZBM_QS"].ToString();
                }
                if (row["FKJGDM_QS"] != null)
                {
                    model.FKJGDM_QS = row["FKJGDM_QS"].ToString();
                }
                if (row["FZJGMC_QS"] != null)
                {
                    model.FZJGMC_QS = row["FZJGMC_QS"].ToString();
                }
                if (row["FZRQ_QS"] != null && row["FZRQ_QS"].ToString() != "")
                {
                    model.FZRQ_QS = DateTime.Parse(row["FZRQ_QS"].ToString());
                }
                if (row["CLRQ_QS"] != null && row["CLRQ_QS"].ToString() != "")
                {
                    model.CLRQ_QS = DateTime.Parse(row["CLRQ_QS"].ToString());
                }
                if (row["FRLX_QS"] != null)
                {
                    model.FRLX_QS = row["FRLX_QS"].ToString();
                }
                if (row["GSSPDWDM_QS"] != null)
                {
                    model.GSSPDWDM_QS = row["GSSPDWDM_QS"].ToString();
                }
                if (row["ZJSPDWDM_QS"] != null)
                {
                    model.ZJSPDWDM_QS = row["ZJSPDWDM_QS"].ToString();
                }
                if (row["SWSPDWDM_QS"] != null)
                {
                    model.SWSPDWDM_QS = row["SWSPDWDM_QS"].ToString();
                }
                if (row["JYFW_QS"] != null)
                {
                    model.JYFW_QS = row["JYFW_QS"].ToString();
                }
                if (row["ZZJGDM_HG"] != null)
                {
                    model.ZZJGDM_HG = row["ZZJGDM_HG"].ToString();
                }
                if (row["HGZCH_HG"] != null)
                {
                    model.HGZCH_HG = row["HGZCH_HG"].ToString();
                }
                if (row["ZGHG_HG"] != null)
                {
                    model.ZGHG_HG = row["ZGHG_HG"].ToString();
                }
                if (row["BAHG_HG"] != null)
                {
                    model.BAHG_HG = row["BAHG_HG"].ToString();
                }
                if (row["ZCRQ_HG"] != null && row["ZCRQ_HG"].ToString() != "")
                {
                    model.ZCRQ_HG = DateTime.Parse(row["ZCRQ_HG"].ToString());
                }
                if (row["YXRQ_HG"] != null && row["YXRQ_HG"].ToString() != "")
                {
                    model.YXRQ_HG = DateTime.Parse(row["YXRQ_HG"].ToString());
                }
                if (row["GSZCQC_HG"] != null)
                {
                    model.GSZCQC_HG = row["GSZCQC_HG"].ToString();
                }
                if (row["HGZCMC_HG"] != null)
                {
                    model.HGZCMC_HG = row["HGZCMC_HG"].ToString();
                }
                if (row["DWMC_HG"] != null)
                {
                    model.DWMC_HG = row["DWMC_HG"].ToString();
                }
                if (row["GSZCDZ_HG"] != null)
                {
                    model.GSZCDZ_HG = row["GSZCDZ_HG"].ToString();
                }
                if (row["DWDZ_HG"] != null)
                {
                    model.DWDZ_HG = row["DWDZ_HG"].ToString();
                }
                if (row["YYZZZCH_HG"] != null)
                {
                    model.YYZZZCH_HG = row["YYZZZCH_HG"].ToString();
                }
                if (row["YZBM_HG"] != null)
                {
                    model.YZBM_HG = row["YZBM_HG"].ToString();
                }
                if (row["FRDB_HG"] != null)
                {
                    model.FRDB_HG = row["FRDB_HG"].ToString();
                }
                if (row["FRDH_HG"] != null)
                {
                    model.FRDH_HG = row["FRDH_HG"].ToString();
                }
                if (row["BGLB_HG"] != null)
                {
                    model.BGLB_HG = row["BGLB_HG"].ToString();
                }
                if (row["ZJLX_HG"] != null && row["ZJLX_HG"].ToString() != "")
                {
                    model.ZJLX_HG = int.Parse(row["ZJLX_HG"].ToString());
                }
                if (row["FRZJHM_HG"] != null)
                {
                    model.FRZJHM_HG = row["FRZJHM_HG"].ToString();
                }
                if (row["JCKQPZJG_HG"] != null)
                {
                    model.JCKQPZJG_HG = row["JCKQPZJG_HG"].ToString();
                }
                if (row["PZWH_HG"] != null)
                {
                    model.PZWH_HG = row["PZWH_HG"].ToString();
                }
                if (row["ZCZBBZ_HG"] != null)
                {
                    model.ZCZBBZ_HG = row["ZCZBBZ_HG"].ToString();
                }
                if (row["ZCZB_HG"] != null && row["ZCZB_HG"].ToString() != "")
                {
                    model.ZCZB_HG = decimal.Parse(row["ZCZB_HG"].ToString());
                }
                if (row["ZJL_HG"] != null)
                {
                    model.ZJL_HG = row["ZJL_HG"].ToString();
                }
                if (row["DH_HG"] != null)
                {
                    model.DH_HG = row["DH_HG"].ToString();
                }
                if (row["KHYH_HG"] != null)
                {
                    model.KHYH_HG = row["KHYH_HG"].ToString();
                }
                if (row["YHZH_HG"] != null)
                {
                    model.YHZH_HG = row["YHZH_HG"].ToString();
                }
                if (row["SWDJH_HG"] != null)
                {
                    model.SWDJH_HG = row["SWDJH_HG"].ToString();
                }
                if (row["HYZL_HG"] != null)
                {
                    model.HYZL_HG = row["HYZL_HG"].ToString();
                }
                if (row["MSE_HG"] != null && row["MSE_HG"].ToString() != "")
                {
                    model.MSE_HG = decimal.Parse(row["MSE_HG"].ToString());
                }
                if (row["ZYCP_HG"] != null)
                {
                    model.ZYCP_HG = row["ZYCP_HG"].ToString();
                }
                if (row["JYFWJBZ_HG"] != null)
                {
                    model.JYFWJBZ_HG = row["JYFWJBZ_HG"].ToString();
                }
                if (row["JCKQYDM_HG"] != null)
                {
                    model.JCKQYDM_HG = row["JCKQYDM_HG"].ToString();
                }
                if (row["QYSCLX_HG"] != null)
                {
                    model.QYSCLX_HG = row["QYSCLX_HG"].ToString();
                }
                if (row["BZ_HG"] != null)
                {
                    model.BZ_HG = row["BZ_HG"].ToString();
                }
                if (row["TZZE_HG"] != null && row["TZZE_HG"].ToString() != "")
                {
                    model.TZZE_HG = decimal.Parse(row["TZZE_HG"].ToString());
                }
                if (row["DWZBZE_HG"] != null && row["DWZBZE_HG"].ToString() != "")
                {
                    model.DWZBZE_HG = decimal.Parse(row["DWZBZE_HG"].ToString());
                }
                if (row["NXBL_HG"] != null && row["NXBL_HG"].ToString() != "")
                {
                    model.NXBL_HG = decimal.Parse(row["NXBL_HG"].ToString());
                }
                if (row["ZCYXRQ_HG"] != null && row["ZCYXRQ_HG"].ToString() != "")
                {
                    model.ZCYXRQ_HG = DateTime.Parse(row["ZCYXRQ_HG"].ToString());
                }
                if (row["ZZJGDM_WJM"] != null)
                {
                    model.ZZJGDM_WJM = row["ZZJGDM_WJM"].ToString();
                }
                if (row["PZWH_WJM"] != null)
                {
                    model.PZWH_WJM = row["PZWH_WJM"].ToString();
                }
                if (row["JCKQYDM_WJM"] != null)
                {
                    model.JCKQYDM_WJM = row["JCKQYDM_WJM"].ToString();
                }
                if (row["PZRQ_WJM"] != null && row["PZRQ_WJM"].ToString() != "")
                {
                    model.PZRQ_WJM = DateTime.Parse(row["PZRQ_WJM"].ToString());
                }
                if (row["FZRQ_WJM"] != null && row["FZRQ_WJM"].ToString() != "")
                {
                    model.FZRQ_WJM = DateTime.Parse(row["FZRQ_WJM"].ToString());
                }
                if (row["FZJG_WJM"] != null)
                {
                    model.FZJG_WJM = row["FZJG_WJM"].ToString();
                }
                if (row["ZGWJM_WJM"] != null)
                {
                    model.ZGWJM_WJM = row["ZGWJM_WJM"].ToString();
                }
                if (row["QYZWMC_WJM"] != null)
                {
                    model.QYZWMC_WJM = row["QYZWMC_WJM"].ToString();
                }
                if (row["YWDZ_WJM"] != null)
                {
                    model.YWDZ_WJM = row["YWDZ_WJM"].ToString();
                }
                if (row["QYDZ_WJM"] != null)
                {
                    model.QYDZ_WJM = row["QYDZ_WJM"].ToString();
                }
                if (row["JYCS_WJM"] != null)
                {
                    model.JYCS_WJM = row["JYCS_WJM"].ToString();
                }
                if (row["ZGBM_WJM"] != null)
                {
                    model.ZGBM_WJM = row["ZGBM_WJM"].ToString();
                }
                if (row["FDDBR_WJM"] != null)
                {
                    model.FDDBR_WJM = row["FDDBR_WJM"].ToString();
                }
                if (row["ZS_WJM"] != null)
                {
                    model.ZS_WJM = row["ZS_WJM"].ToString();
                }
                if (row["LXDH_WJM"] != null)
                {
                    model.LXDH_WJM = row["LXDH_WJM"].ToString();
                }
                if (row["LXCZ_WJM"] != null)
                {
                    model.LXCZ_WJM = row["LXCZ_WJM"].ToString();
                }
                if (row["YZBM_WJM"] != null)
                {
                    model.YZBM_WJM = row["YZBM_WJM"].ToString();
                }
                if (row["DZYX_WJM"] != null)
                {
                    model.DZYX_WJM = row["DZYX_WJM"].ToString();
                }
                if (row["GSDJZCRQ_WJM"] != null && row["GSDJZCRQ_WJM"].ToString() != "")
                {
                    model.GSDJZCRQ_WJM = DateTime.Parse(row["GSDJZCRQ_WJM"].ToString());
                }
                if (row["GSDJZCH_WJM"] != null)
                {
                    model.GSDJZCH_WJM = row["GSDJZCH_WJM"].ToString();
                }
                if (row["QYJYLX_WJM"] != null)
                {
                    model.QYJYLX_WJM = row["QYJYLX_WJM"].ToString();
                }
                if (row["JYNX_WJM"] != null && row["JYNX_WJM"].ToString() != "")
                {
                    model.JYNX_WJM = int.Parse(row["JYNX_WJM"].ToString());
                }
                if (row["TZZE_WJM"] != null && row["TZZE_WJM"].ToString() != "")
                {
                    model.TZZE_WJM = decimal.Parse(row["TZZE_WJM"].ToString());
                }
                if (row["TZBZ_WJM"] != null)
                {
                    model.TZBZ_WJM = row["TZBZ_WJM"].ToString();
                }
                if (row["ZCZB_WJM"] != null && row["ZCZB_WJM"].ToString() != "")
                {
                    model.ZCZB_WJM = decimal.Parse(row["ZCZB_WJM"].ToString());
                }
                if (row["ZCZBBZ_WJM"] != null)
                {
                    model.ZCZBBZ_WJM = row["ZCZBBZ_WJM"].ToString();
                }
                if (row["BADJBBH_WJM"] != null)
                {
                    model.BADJBBH_WJM = row["BADJBBH_WJM"].ToString();
                }
                if (row["ZCZJ_WJM"] != null && row["ZCZJ_WJM"].ToString() != "")
                {
                    model.ZCZJ_WJM = decimal.Parse(row["ZCZJ_WJM"].ToString());
                }
                if (row["JYFW_WJM"] != null)
                {
                    model.JYFW_WJM = row["JYFW_WJM"].ToString();
                }
                if (row["JCKSPML_WJM"] != null)
                {
                    model.JCKSPML_WJM = row["JCKSPML_WJM"].ToString();
                }
                if (row["BZ_WJM"] != null)
                {
                    model.BZ_WJM = row["BZ_WJM"].ToString();
                }
                if (row["ZZJGDM_WH"] != null)
                {
                    model.ZZJGDM_WH = row["ZZJGDM_WH"].ToString();
                }
                if (row["GSZCH_WH"] != null)
                {
                    model.GSZCH_WH = row["GSZCH_WH"].ToString();
                }
                if (row["HGZCH_WH"] != null)
                {
                    model.HGZCH_WH = row["HGZCH_WH"].ToString();
                }
                if (row["HGZCYXQ_WH"] != null && row["HGZCYXQ_WH"].ToString() != "")
                {
                    model.HGZCYXQ_WH = DateTime.Parse(row["HGZCYXQ_WH"].ToString());
                }
                if (row["ZGWHJ_WH"] != null)
                {
                    model.ZGWHJ_WH = row["ZGWHJ_WH"].ToString();
                }
                if (row["QYZWMC_WH"] != null)
                {
                    model.QYZWMC_WH = row["QYZWMC_WH"].ToString();
                }
                if (row["QYDZ_WH"] != null)
                {
                    model.QYDZ_WH = row["QYDZ_WH"].ToString();
                }
                if (row["CZ_WH"] != null)
                {
                    model.CZ_WH = row["CZ_WH"].ToString();
                }
                if (row["DH_WH"] != null)
                {
                    model.DH_WH = row["DH_WH"].ToString();
                }
                if (row["DZYX_WH"] != null)
                {
                    model.DZYX_WH = row["DZYX_WH"].ToString();
                }
                if (row["FDDBR_WH"] != null)
                {
                    model.FDDBR_WH = row["FDDBR_WH"].ToString();
                }
                if (row["HXLXR_WH"] != null)
                {
                    model.HXLXR_WH = row["HXLXR_WH"].ToString();
                }
                if (row["JYFW_WH"] != null)
                {
                    model.JYFW_WH = row["JYFW_WH"].ToString();
                }
                if (row["HYDM_WH"] != null)
                {
                    model.HYDM_WH = row["HYDM_WH"].ToString();
                }
                if (row["QYYB_WH"] != null)
                {
                    model.QYYB_WH = row["QYYB_WH"].ToString();
                }
                if (row["QYXZ_WH"] != null)
                {
                    model.QYXZ_WH = row["QYXZ_WH"].ToString();
                }
                if (row["RMBZCZJ_WH"] != null && row["RMBZCZJ_WH"].ToString() != "")
                {
                    model.RMBZCZJ_WH = decimal.Parse(row["RMBZCZJ_WH"].ToString());
                }
                if (row["WBZCBZ_WH"] != null)
                {
                    model.WBZCBZ_WH = row["WBZCBZ_WH"].ToString();
                }
                if (row["WBZCZJ_WH"] != null && row["WBZCZJ_WH"].ToString() != "")
                {
                    model.WBZCZJ_WH = decimal.Parse(row["WBZCZJ_WH"].ToString());
                }
                if (row["ZCSLRQ_WH"] != null && row["ZCSLRQ_WH"].ToString() != "")
                {
                    model.ZCSLRQ_WH = DateTime.Parse(row["ZCSLRQ_WH"].ToString());
                }
                if (row["JZYXRQ_WH"] != null && row["JZYXRQ_WH"].ToString() != "")
                {
                    model.JZYXRQ_WH = DateTime.Parse(row["JZYXRQ_WH"].ToString());
                }
                if (row["WMZSH_WH"] != null)
                {
                    model.WMZSH_WH = row["WMZSH_WH"].ToString();
                }
                if (row["WMZSPZRQ_WH"] != null && row["WMZSPZRQ_WH"].ToString() != "")
                {
                    model.WMZSPZRQ_WH = DateTime.Parse(row["WMZSPZRQ_WH"].ToString());
                }
                if (row["WMJYFW_WH"] != null)
                {
                    model.WMJYFW_WH = row["WMJYFW_WH"].ToString();
                }
                if (row["HXKHRQ_WH"] != null && row["HXKHRQ_WH"].ToString() != "")
                {
                    model.HXKHRQ_WH = DateTime.Parse(row["HXKHRQ_WH"].ToString());
                }
                if (row["QYLXMC_WH"] != null)
                {
                    model.QYLXMC_WH = row["QYLXMC_WH"].ToString();
                }
                if (row["NWFlat"] != null && row["NWFlat"].ToString() != "")
                {
                    model.NWFlat = int.Parse(row["NWFlat"].ToString());
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
            strSql.Append("select ListID,SHTYXYDM_QS,ZTSBM_QS,XZQYHM_QS,QYZWMC_QS,QYYWMC_QS,QYDZ_QS,FDDBR_QS,FRDH_QS,QYLX_QS,ZCZJ_QS,ZCZJBZ_QS,YYQX_QS,ZJLX_QS_QS,ZJHM_QS,CZ_QS,YZBM_QS,FKJGDM_QS,FZJGMC_QS,FZRQ_QS,CLRQ_QS,FRLX_QS,GSSPDWDM_QS,ZJSPDWDM_QS,SWSPDWDM_QS,JYFW_QS,ZZJGDM_HG,HGZCH_HG,ZGHG_HG,BAHG_HG,ZCRQ_HG,YXRQ_HG,GSZCQC_HG,HGZCMC_HG,DWMC_HG,GSZCDZ_HG,DWDZ_HG,YYZZZCH_HG,YZBM_HG,FRDB_HG,FRDH_HG,BGLB_HG,ZJLX_HG,FRZJHM_HG,JCKQPZJG_HG,PZWH_HG,ZCZBBZ_HG,ZCZB_HG,ZJL_HG,DH_HG,KHYH_HG,YHZH_HG,SWDJH_HG,HYZL_HG,MSE_HG,ZYCP_HG,JYFWJBZ_HG,JCKQYDM_HG,QYSCLX_HG,BZ_HG,TZZE_HG,DWZBZE_HG,NXBL_HG,ZCYXRQ_HG,ZZJGDM_WJM,PZWH_WJM,JCKQYDM_WJM,PZRQ_WJM,FZRQ_WJM,FZJG_WJM,ZGWJM_WJM,QYZWMC_WJM,YWDZ_WJM,QYDZ_WJM,JYCS_WJM,ZGBM_WJM,FDDBR_WJM,ZS_WJM,LXDH_WJM,LXCZ_WJM,YZBM_WJM,DZYX_WJM,GSDJZCRQ_WJM,GSDJZCH_WJM,QYJYLX_WJM,JYNX_WJM,TZZE_WJM,TZBZ_WJM,ZCZB_WJM,ZCZBBZ_WJM,BADJBBH_WJM,ZCZJ_WJM,JYFW_WJM,JCKSPML_WJM,BZ_WJM,ZZJGDM_WH,GSZCH_WH,HGZCH_WH,HGZCYXQ_WH,ZGWHJ_WH,QYZWMC_WH,QYDZ_WH,CZ_WH,DH_WH,DZYX_WH,FDDBR_WH,HXLXR_WH,JYFW_WH,HYDM_WH,QYYB_WH,QYXZ_WH,RMBZCZJ_WH,WBZCBZ_WH,WBZCZJ_WH,ZCSLRQ_WH,JZYXRQ_WH,WMZSH_WH,WMZSPZRQ_WH,WMJYFW_WH,HXKHRQ_WH,QYLXMC_WH,NWFlat ");
            strSql.Append(" FROM NewlyAddedListFR ");
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
            strSql.Append(" ListID,SHTYXYDM_QS,ZTSBM_QS,XZQYHM_QS,QYZWMC_QS,QYYWMC_QS,QYDZ_QS,FDDBR_QS,FRDH_QS,QYLX_QS,ZCZJ_QS,ZCZJBZ_QS,YYQX_QS,ZJLX_QS_QS,ZJHM_QS,CZ_QS,YZBM_QS,FKJGDM_QS,FZJGMC_QS,FZRQ_QS,CLRQ_QS,FRLX_QS,GSSPDWDM_QS,ZJSPDWDM_QS,SWSPDWDM_QS,JYFW_QS,ZZJGDM_HG,HGZCH_HG,ZGHG_HG,BAHG_HG,ZCRQ_HG,YXRQ_HG,GSZCQC_HG,HGZCMC_HG,DWMC_HG,GSZCDZ_HG,DWDZ_HG,YYZZZCH_HG,YZBM_HG,FRDB_HG,FRDH_HG,BGLB_HG,ZJLX_HG,FRZJHM_HG,JCKQPZJG_HG,PZWH_HG,ZCZBBZ_HG,ZCZB_HG,ZJL_HG,DH_HG,KHYH_HG,YHZH_HG,SWDJH_HG,HYZL_HG,MSE_HG,ZYCP_HG,JYFWJBZ_HG,JCKQYDM_HG,QYSCLX_HG,BZ_HG,TZZE_HG,DWZBZE_HG,NXBL_HG,ZCYXRQ_HG,ZZJGDM_WJM,PZWH_WJM,JCKQYDM_WJM,PZRQ_WJM,FZRQ_WJM,FZJG_WJM,ZGWJM_WJM,QYZWMC_WJM,YWDZ_WJM,QYDZ_WJM,JYCS_WJM,ZGBM_WJM,FDDBR_WJM,ZS_WJM,LXDH_WJM,LXCZ_WJM,YZBM_WJM,DZYX_WJM,GSDJZCRQ_WJM,GSDJZCH_WJM,QYJYLX_WJM,JYNX_WJM,TZZE_WJM,TZBZ_WJM,ZCZB_WJM,ZCZBBZ_WJM,BADJBBH_WJM,ZCZJ_WJM,JYFW_WJM,JCKSPML_WJM,BZ_WJM,ZZJGDM_WH,GSZCH_WH,HGZCH_WH,HGZCYXQ_WH,ZGWHJ_WH,QYZWMC_WH,QYDZ_WH,CZ_WH,DH_WH,DZYX_WH,FDDBR_WH,HXLXR_WH,JYFW_WH,HYDM_WH,QYYB_WH,QYXZ_WH,RMBZCZJ_WH,WBZCBZ_WH,WBZCZJ_WH,ZCSLRQ_WH,JZYXRQ_WH,WMZSH_WH,WMZSPZRQ_WH,WMJYFW_WH,HXKHRQ_WH,QYLXMC_WH,NWFlat ");
            strSql.Append(" FROM NewlyAddedListFR ");
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
            strSql.Append("select count(1) FROM NewlyAddedListFR ");
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
            strSql.Append(")AS Row, T.*  from NewlyAddedListFR T ");
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
            parameters[0].Value = "NewlyAddedListFR";
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
        //public string GetInsertSql(CardCenter.Entity.NewlyAddedListFR Entity)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into NewlyAddedListFR(");
        //    strSql.Append("ListID,SHTYXYDM_QS,ZTSBM_QS,XZQYHM_QS,QYZWMC_QS,QYDZ_QS,FDDBR_QS,FRDH_QS,");
        //    strSql.Append("QYLX_QS,ZCZJ_QS,ZCZJBZ_QS,YYQX_QS,ZJLX_QS_QS,FKJGDM_QS,FRLX_QS,GSSPDWDM_QS,ZJSPDWDM_QS,SWSPDWDM_QS,");
        //    strSql.Append("JYFW_QS,ZZJGDM_HG,HGZCH_HG,ZGHG_HG,BAHG_HG,ZCRQ_HG,YXRQ_HG,GSZCQC_HG,HGZCMC_HG,DWMC_HG,GSZCDZ_HG,DWDZ_HG,");
        //    strSql.Append("YYZZZCH_HG,YZBM_HG,FRDB_HG,FRDH_HG,BGLB_HG,ZJLX_HG,FRZJHM_HG,JCKQPZJG_HG,PZWH_HG,ZCZBBZ_HG,ZCZB_HG,ZJL_HG,DH_HG,");
        //    strSql.Append("KHYH_HG,YHZH_HG,SWDJH_HG,HYZL_HG,MSE_HG,ZYCP_HG,JYFWJBZ_HG,JCKQYDM_HG,QYSCLX_HG,BZ_HG,TZZE_HG,DWZBZE_HG,NXBL_HG,");
        //    strSql.Append("ZCYXRQ_HG,ZZJGDM_WJM,PZWH_WJM,JCKQYDM_WJM,PZRQ_WJM,FZRQ_WJM,FZJG_WJM,ZGWJM_WJM,QYZWMC_WJM,YWDZ_WJM,QYDZ_WJM,JYCS_WJM,");
        //    strSql.Append("ZGBM_WJM,FDDBR_WJM,ZS_WJM,LXDH_WJM,LXCZ_WJM,YZBM_WJM,DZYX_WJM,GSDJZCRQ_WJM,GSDJZCH_WJM,QYJYLX_WJM,JYNX_WJM,TZZE_WJM,TZBZ_WJM,");
        //    strSql.Append("ZCZB_WJM,ZCZBBZ_WJM,BADJBBH_WJM,ZCZJ_WJM,JYFW_WJM,JCKSPML_WJM,BZ_WJM,ZZJGDM_WH,GSZCH_WH,HGZCH_WH,HGZCYXQ_WH,ZGWHJ_WH,QYZWMC_WH,");
        //    strSql.Append("QYDZ_WH,CZ_WH,DH_WH,DZYX_WH,FDDBR_WH,HXLXR_WH,JYFW_WH,HYDM_WH,QYYB_WH,QYXZ_WH,RMBZCZJ_WH,WBZCBZ_WH,WBZCZJ_WH,ZCSLRQ_WH,JZYXRQ_WH,");
        //    strSql.Append("WMZSH_WH,WMZSPZRQ_WH,WMJYFW_WH,HXKHRQ_WH,QYLXMC_WH,ZJHM_QS,CZ_QS,YZBM_QS,QYYWMC_QS,FZJGMC_QS,FZRQ_QS,CLRQ_QS,NWFlat)");
        //    strSql.Append(" values (");
        //    strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',{23},{24},'{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}',{35},'{36}','{37}','{38}','{39}',{40},'{41}','{42}','{43}','{44}','{45}','{46}',{47},'{48}','{49}','{50}','{51}','{52}',{53},{54},{55},{56},'{57}','{58}','{59}',{60},{61},'{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}','{74}',{75},'{76}','{77}',{78},{79},'{80}',{81},'{82}','{83}',{84},'{85}','{86}','{87}','{88}','{89}','{90}',{91},'{92}','{93}','{94}','{95}','{96}','{97}','{98}','{99}','{100}','{101}','{102}','{103}',{104},'{105}',{106},{107},{108},'{109}',{110},'{111}',{112},'{113}','{114}','{115}','{116}','{117}','{118}',{119},{120},{121});"
        //        , Entity.ListID//0
        //        , Entity.SHTYXYDM_QS//1
        //        , Entity.ZTSBM_QS//2
        //        , Entity.XZQYHM_QS//3
        //        , Entity.QYZWMC_QS//4
        //        , Entity.QYDZ_QS//5
        //        , Entity.FDDBR_QS//6
        //        , Entity.FRDH_QS//7
        //        , Entity.QYLX_QS //8
        //        , Entity.ZCZJ_QS == null ? "null" : Entity.ZCZJ_QS.ToString()//9注册资金可空
        //        , Entity.ZCZJBZ_QS//10
        //        , Entity.YYQX_QS//11
        //        , Entity.ZJLX_QS_QS == null ? "null" : Entity.ZJLX_QS_QS.ToString()//12证件类型可空
        //        , Entity.FKJGDM_QS//13
        //        , Entity.FRLX_QS//14
        //        , Entity.GSSPDWDM_QS//15
        //        , Entity.ZJSPDWDM_QS//16
        //        , Entity.SWSPDWDM_QS//17
        //        , Entity.JYFW_QS//18
        //        , Entity.ZZJGDM_HG//19
        //        , Entity.HGZCH_HG//20
        //        , Entity.ZGHG_HG//21
        //        , Entity.BAHG_HG//22
        //        , Entity.ZCRQ_HG == null ? "null" : "'" + Entity.ZCRQ_HG.ToString() + "'"//23注册海关日期可空
        //        , Entity.YXRQ_HG == null ? "null" : "'" + Entity.YXRQ_HG.ToString() + "'"//24有效日期可空
        //        , Entity.GSZCQC_HG//25
        //        , Entity.HGZCMC_HG//26
        //        , Entity.DWMC_HG//27
        //        , Entity.GSZCDZ_HG//28
        //        , Entity.DWDZ_HG//29
        //        , Entity.YYZZZCH_HG//30
        //        , Entity.YZBM_HG//31
        //        , Entity.FRDB_HG//32
        //        , Entity.FRDH_HG//33
        //        , Entity.BGLB_HG//34
        //        , Entity.ZJLX_HG == null ? "null" : Entity.ZJLX_HG.ToString()//35证件类型可空
        //        , Entity.FRZJHM_HG//36
        //        , Entity.JCKQPZJG_HG//37
        //        , Entity.PZWH_HG//38
        //        , Entity.ZCZBBZ_HG//39
        //        , Entity.ZCZB_HG == null ? "null" : Entity.ZCZB_HG.ToString()//40注册资本可空
        //        , Entity.ZJL_HG//41
        //        , Entity.DH_HG//42
        //        , Entity.KHYH_HG//43
        //        , Entity.YHZH_HG//44
        //        , Entity.SWDJH_HG//45
        //        , Entity.HYZL_HG//46
        //        , Entity.MSE_HG == null ? "null" : Entity.MSE_HG.ToString()//47免税额可空
        //        , Entity.ZYCP_HG//48
        //        , Entity.JYFWJBZ_HG//49
        //        , Entity.JCKQYDM_HG//50
        //        , Entity.QYSCLX_HG//51
        //        , Entity.BZ_HG//52
        //        , Entity.TZZE_HG == null ? "null" : Entity.TZZE_HG.ToString()//53投资总额可空
        //        , Entity.DWZBZE_HG == null ? "null" : Entity.DWZBZE_HG.ToString()//54到位资本总额可空
        //        , Entity.NXBL_HG == null ? "null" : Entity.NXBL_HG.ToString()//55内销比率可空
        //        , Entity.ZCYXRQ_HG == null ? "null" : "'" + Entity.ZCYXRQ_HG.ToString() + "'"//56注册有效日期可空
        //        , Entity.ZZJGDM_WJM//57
        //        , Entity.PZWH_WJM//58
        //        , Entity.JCKQYDM_WJM//59
        //        , Entity.PZRQ_WJM == null ? "null" : "'" + Entity.PZRQ_WJM.ToString() + "'"//60批准日期可空
        //        , Entity.FZRQ_WJM == null ? "null" : "'" + Entity.FZRQ_WJM.ToString() + "'"//61发证日期可空
        //        , Entity.FZJG_WJM//62
        //        , Entity.ZGWJM_WJM//63
        //        , Entity.QYZWMC_WJM//64
        //        , Entity.YWDZ_WJM//65
        //        , Entity.QYDZ_WJM//66
        //        , Entity.JYCS_WJM//67
        //        , Entity.ZGBM_WJM//68
        //        , Entity.FDDBR_WJM//69
        //        , Entity.ZS_WJM//70
        //        , Entity.LXDH_WJM//71
        //        , Entity.LXCZ_WJM//72
        //        , Entity.YZBM_WJM//73
        //        , Entity.DZYX_WJM//74
        //        , Entity.GSDJZCRQ_WJM == null ? "null" : "'" + Entity.GSDJZCRQ_WJM.ToString() + "'"//75工商登记日期可空
        //        , Entity.GSDJZCH_WJM//76
        //        , Entity.QYJYLX_WJM//77
        //        , Entity.JYNX_WJM == null ? "null" : Entity.JYNX_WJM.ToString()//78经营年限可空
        //        , Entity.TZZE_WJM == null ? "null" : Entity.TZZE_WJM.ToString()//79投资总额可空
        //        , Entity.TZBZ_WJM//80
        //        , Entity.ZCZB_WJM == null ? "null" : Entity.ZCZB_WJM.ToString()//81注册资本可空
        //        , Entity.ZCZBBZ_WJM//82
        //        , Entity.BADJBBH_WJM//83
        //        , Entity.ZCZJ_WJM == null ? "null" : Entity.ZCZJ_WJM.ToString()//84注册资金可空
        //        , Entity.JYFW_WJM//85
        //        , Entity.JCKSPML_WJM//86
        //        , Entity.BZ_WJM//87
        //        , Entity.ZZJGDM_WH//88
        //        , Entity.GSZCH_WH//89
        //        , Entity.HGZCH_WH//90
        //        , Entity.HGZCYXQ_WH == null ? "null" : "'" + Entity.HGZCYXQ_WH.ToString() + "'"//91海关注册有效期可空
        //        , Entity.ZGWHJ_WH//92
        //        , Entity.QYZWMC_WH//93
        //        , Entity.QYDZ_WH//94
        //        , Entity.CZ_WH//95
        //        , Entity.DH_WH//96
        //        , Entity.DZYX_WH//97
        //        , Entity.FDDBR_WH//98
        //        , Entity.HXLXR_WH//99
        //        , Entity.JYFW_WH//100
        //        , Entity.HYDM_WH//101
        //        , Entity.QYYB_WH//102
        //        , Entity.QYXZ_WH//103
        //        , Entity.RMBZCZJ_WH == null ? "null" : Entity.RMBZCZJ_WH.ToString()//104人民币注册资金可空
        //        , Entity.WBZCBZ_WH//105
        //        , Entity.WBZCZJ_WH == null ? "null" : Entity.WBZCZJ_WH.ToString()//106外币注册资金可空
        //        , Entity.ZCSLRQ_WH == null ? "null" : "'" + Entity.ZCSLRQ_WH.ToString() + "'"//107最初设立日期可空
        //        , Entity.JZYXRQ_WH == null ? "null" : "'" + Entity.JZYXRQ_WH.ToString() + "'"//108截至有效日期可空
        //        , Entity.WMZSH_WH//109
        //        , Entity.WMZSPZRQ_WH == null ? "null" : "'" + Entity.WMZSPZRQ_WH.ToString() + "'"//110外贸证书批准日期可空
        //        , Entity.WMJYFW_WH//111
        //        , Entity.HXKHRQ_WH == null ? "null" : "'" + Entity.HXKHRQ_WH.ToString() + "'"//112核销开户日期可空
        //        , Entity.QYLXMC_WH//113
        //        , Entity.ZJHM_QS//114
        //        , Entity.CZ_QS//115
        //        , Entity.YZBM_QS//116
        //        , Entity.QYYWMC_QS//117
        //        , Entity.FZJGMC_QS//118
        //        , Entity.FZRQ_QS == null ? "null" : "'" + Entity.FZRQ_QS.ToString() + "'"//119发证日期可空
        //        , Entity.CLRQ_QS == null ? "null" : "'" + Entity.CLRQ_QS.ToString() + "'"//120成立日期可空
        //        , Entity.NWFlat == null ? "null" : Entity.NWFlat.ToString());//内资或外资标识
        //    return strSql.ToString();
        //}

        //public string GetUpdateSql(CardCenter.Entity.NewlyAddedListFR Entity)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update NewlyAddedListFR set ");
        //    strSql.AppendFormat("SHTYXYDM_QS='{0}',ZTSBM_QS='{1}',XZQYHM_QS='{2}',QYZWMC_QS='{3}',QYDZ_QS='{4}',FDDBR_QS='{5}',FRDH_QS='{6}',QYLX_QS='{7}',ZCZJ_QS={8},ZCZJBZ_QS='{9}',YYQX_QS='{10}',ZJLX_QS_QS={11},FKJGDM_QS='{12}',FRLX_QS='{13}',GSSPDWDM_QS='{14}',ZJSPDWDM_QS='{15}',SWSPDWDM_QS='{16}',JYFW_QS='{17}',ZZJGDM_HG='{18}',HGZCH_HG='{19}',ZGHG_HG='{20}',BAHG_HG='{21}',ZCRQ_HG={22},YXRQ_HG={23},GSZCQC_HG='{24}',HGZCMC_HG='{25}',DWMC_HG='{26}',GSZCDZ_HG='{27}',DWDZ_HG='{28}',YYZZZCH_HG='{29}',YZBM_HG='{30}',FRDB_HG='{31}',FRDH_HG='{32}',BGLB_HG='{33}',ZJLX_HG={34},FRZJHM_HG='{35}',JCKQPZJG_HG='{36}',PZWH_HG='{37}',ZCZBBZ_HG='{38}',ZCZB_HG={39},ZJL_HG='{40}',DH_HG='{41}',KHYH_HG='{42}',YHZH_HG='{43}',SWDJH_HG='{44}',HYZL_HG='{45}',MSE_HG={46},ZYCP_HG='{47}',JYFWJBZ_HG='{48}',JCKQYDM_HG='{49}',QYSCLX_HG='{50}',BZ_HG='{51}',TZZE_HG={52},DWZBZE_HG={53},NXBL_HG={54},ZCYXRQ_HG={55},ZZJGDM_WJM='{56}',PZWH_WJM='{57}',JCKQYDM_WJM='{58}',PZRQ_WJM={59},FZRQ_WJM={60},FZJG_WJM='{61}',ZGWJM_WJM='{62}',QYZWMC_WJM='{63}',YWDZ_WJM='{64}',QYDZ_WJM='{65}',JYCS_WJM='{66}',ZGBM_WJM='{67}',FDDBR_WJM='{68}',ZS_WJM='{69}',LXDH_WJM='{70}',LXCZ_WJM='{71}',YZBM_WJM='{72}',DZYX_WJM='{73}',GSDJZCRQ_WJM={74},GSDJZCH_WJM='{75}',QYJYLX_WJM='{76}',JYNX_WJM={77},TZZE_WJM={78},TZBZ_WJM='{79}',ZCZB_WJM={80},ZCZBBZ_WJM='{81}',BADJBBH_WJM='{82}',ZCZJ_WJM={83},JYFW_WJM='{84}',JCKSPML_WJM='{85}',BZ_WJM='{86}',ZZJGDM_WH='{87}',GSZCH_WH='{88}',HGZCH_WH='{89}',HGZCYXQ_WH={90},ZGWHJ_WH='{91}',QYZWMC_WH='{92}',QYDZ_WH='{93}',CZ_WH='{94}',DH_WH='{95}',DZYX_WH='{96}',FDDBR_WH='{97}',HXLXR_WH='{98}',JYFW_WH='{99}',HYDM_WH='{100}',QYYB_WH='{101}',QYXZ_WH='{102}',RMBZCZJ_WH={103},WBZCBZ_WH='{104}',WBZCZJ_WH={105},ZCSLRQ_WH={106},JZYXRQ_WH={107},WMZSH_WH='{108}',WMZSPZRQ_WH={109},WMJYFW_WH='{110}',HXKHRQ_WH={111},QYLXMC_WH='{112}',ZJHM_QS='{113}',CZ_QS='{114}',YZBM_QS='{115}',QYYWMC_QS='{116}',FZJGMC_QS='{117}',FZRQ_QS={118},CLRQ_QS={119},NWFlat={120} where ListID='{121}'; "
        //        , Entity.SHTYXYDM_QS //1
        //        , Entity.ZTSBM_QS//2
        //        , Entity.XZQYHM_QS//3
        //        , Entity.QYZWMC_QS//4
        //        , Entity.QYDZ_QS//5
        //        , Entity.FDDBR_QS//6
        //        , Entity.FRDH_QS//7
        //        , Entity.QYLX_QS//8
        //        , Entity.ZCZJ_QS == null ? "null" : Entity.ZCZJ_QS.ToString()//9注册资金可空
        //        , Entity.ZCZJBZ_QS//10
        //        , Entity.YYQX_QS//11
        //        , Entity.ZJLX_QS_QS == null ? "null" : Entity.ZJLX_QS_QS.ToString()//12证件类型可空
        //        , Entity.FKJGDM_QS//13
        //        , Entity.FRLX_QS//14
        //        , Entity.GSSPDWDM_QS//15
        //        , Entity.ZJSPDWDM_QS//16
        //        , Entity.SWSPDWDM_QS//17
        //        , Entity.JYFW_QS//18
        //        , Entity.ZZJGDM_HG//19
        //        , Entity.HGZCH_HG//20
        //        , Entity.ZGHG_HG//21
        //        , Entity.BAHG_HG//22
        //        , Entity.ZCRQ_HG == null ? "null" : "'" + Entity.ZCRQ_HG.ToString() + "'"//23注册海关日期可空
        //        , Entity.YXRQ_HG == null ? "null" : "'" + Entity.YXRQ_HG.ToString() + "'"//24有效日期可空
        //        , Entity.GSZCQC_HG//25
        //        , Entity.HGZCMC_HG//26
        //        , Entity.DWMC_HG//27
        //        , Entity.GSZCDZ_HG//28
        //        , Entity.DWDZ_HG//29
        //        , Entity.YYZZZCH_HG//30
        //        , Entity.YZBM_HG//31
        //        , Entity.FRDB_HG//32
        //        , Entity.FRDH_HG//33
        //        , Entity.BGLB_HG//34
        //        , Entity.ZJLX_HG == null ? "null" : Entity.ZJLX_HG.ToString()//35证件类型可空
        //        , Entity.FRZJHM_HG//36
        //        , Entity.JCKQPZJG_HG//37
        //        , Entity.PZWH_HG//38
        //        , Entity.ZCZBBZ_HG//39
        //        , Entity.ZCZB_HG == null ? "null" : Entity.ZCZB_HG.ToString()//40注册资本可空
        //        , Entity.ZJL_HG//41
        //        , Entity.DH_HG//42
        //        , Entity.KHYH_HG//43
        //        , Entity.YHZH_HG//44
        //        , Entity.SWDJH_HG//45
        //        , Entity.HYZL_HG//46
        //        , Entity.MSE_HG == null ? "null" : Entity.MSE_HG.ToString()//47免税额可空
        //        , Entity.ZYCP_HG//48
        //        , Entity.JYFWJBZ_HG//49
        //        , Entity.JCKQYDM_HG//50
        //        , Entity.QYSCLX_HG//51
        //        , Entity.BZ_HG//52
        //        , Entity.TZZE_HG == null ? "null" : Entity.TZZE_HG.ToString()//53投资总额可空
        //        , Entity.DWZBZE_HG == null ? "null" : Entity.DWZBZE_HG.ToString()//54到位资本总额可空
        //        , Entity.NXBL_HG == null ? "null" : Entity.NXBL_HG.ToString()//55内销比率可空
        //        , Entity.ZCYXRQ_HG == null ? "null" : "'" + Entity.ZCYXRQ_HG.ToString() + "'"//56注册有效日期可空
        //        , Entity.ZZJGDM_WJM//57
        //        , Entity.PZWH_WJM//58
        //        , Entity.JCKQYDM_WJM//59
        //        , Entity.PZRQ_WJM == null ? "null" : "'" + Entity.PZRQ_WJM.ToString() + "'"//60批准日期可空
        //        , Entity.FZRQ_WJM == null ? "null" : "'" + Entity.FZRQ_WJM.ToString() + "'"//61发证日期可空
        //        , Entity.FZJG_WJM//62
        //        , Entity.ZGWJM_WJM//63
        //        , Entity.QYZWMC_WJM//64
        //        , Entity.YWDZ_WJM//65
        //        , Entity.QYDZ_WJM//66
        //        , Entity.JYCS_WJM//67
        //        , Entity.ZGBM_WJM//68
        //        , Entity.FDDBR_WJM//69
        //        , Entity.ZS_WJM//70
        //        , Entity.LXDH_WJM//71
        //        , Entity.LXCZ_WJM//72
        //        , Entity.YZBM_WJM//73
        //        , Entity.DZYX_WJM//74
        //        , Entity.GSDJZCRQ_WJM == null ? "null" : "'" + Entity.GSDJZCRQ_WJM.ToString() + "'"//75工商登记日期可空
        //        , Entity.GSDJZCH_WJM//76
        //        , Entity.QYJYLX_WJM//77
        //        , Entity.JYNX_WJM == null ? "null" : Entity.JYNX_WJM.ToString()//78经营年限可空
        //        , Entity.TZZE_WJM == null ? "null" : Entity.TZZE_WJM.ToString()//79投资总额可空
        //        , Entity.TZBZ_WJM//80
        //        , Entity.ZCZB_WJM == null ? "null" : Entity.ZCZB_WJM.ToString()//81注册资本可空
        //        , Entity.ZCZBBZ_WJM//82
        //        , Entity.BADJBBH_WJM//83
        //        , Entity.ZCZJ_WJM == null ? "null" : Entity.ZCZJ_WJM.ToString()//84注册资金可空
        //        , Entity.JYFW_WJM//85
        //        , Entity.JCKSPML_WJM//86
        //        , Entity.BZ_WJM//87
        //        , Entity.ZZJGDM_WH//88
        //        , Entity.GSZCH_WH//89
        //        , Entity.HGZCH_WH//90
        //        , Entity.HGZCYXQ_WH == null ? "null" : "'" + Entity.HGZCYXQ_WH.ToString() + "'"//91海关注册有效期可空
        //        , Entity.ZGWHJ_WH//92
        //        , Entity.QYZWMC_WH//93
        //        , Entity.QYDZ_WH//94
        //        , Entity.CZ_WH//95
        //        , Entity.DH_WH//96
        //        , Entity.DZYX_WH//97
        //        , Entity.FDDBR_WH//98
        //        , Entity.HXLXR_WH//99
        //        , Entity.JYFW_WH//100
        //        , Entity.HYDM_WH//101
        //        , Entity.QYYB_WH//102
        //        , Entity.QYXZ_WH//103
        //        , Entity.RMBZCZJ_WH == null ? "null" : Entity.RMBZCZJ_WH.ToString()//104人民币注册资金可空
        //        , Entity.WBZCBZ_WH//105
        //        , Entity.WBZCZJ_WH == null ? "null" : Entity.WBZCZJ_WH.ToString()//106外币注册资金可空
        //        , Entity.ZCSLRQ_WH == null ? "null" : "'" + Entity.ZCSLRQ_WH.ToString() + "'"//107最初设立日期可空
        //        , Entity.JZYXRQ_WH == null ? "null" : "'" + Entity.JZYXRQ_WH.ToString() + "'"//108截至有效日期可空
        //        , Entity.WMZSH_WH//109
        //        , Entity.WMZSPZRQ_WH == null ? "null" : "'" + Entity.WMZSPZRQ_WH.ToString() + "'"//110外贸证书批准日期可空
        //        , Entity.WMJYFW_WH//111
        //        , Entity.HXKHRQ_WH == null ? "null" : "'" + Entity.HXKHRQ_WH.ToString() + "'"//112核销开户日期可空
        //        , Entity.QYLXMC_WH//113
        //        , Entity.ZJHM_QS//114
        //        , Entity.CZ_QS//115
        //        , Entity.YZBM_QS//116
        //        , Entity.QYYWMC_QS//117
        //        , Entity.FZJGMC_QS//118
        //        , Entity.FZRQ_QS == null ? "null" : "'" + Entity.FZRQ_QS.ToString() + "'"//119发证日期可空
        //        , Entity.CLRQ_QS == null ? "null" : "'" + Entity.CLRQ_QS.ToString() + "'"//120成立日期可空
        //        , Entity.NWFlat == null ? "null" : Entity.NWFlat.ToString()
        //        , Entity.ListID); //121
        //    return strSql.ToString();
        //}
		#endregion  ExtensionMethod
	}
}

