/**  版本信息模板在安装目录下，可自行修改。
* NewlyAddedListFR.cs
*
* 功 能： N/A
* 类 名： NewlyAddedListFR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/7 17:02:33   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using Job.Entity;
namespace CardCenter.Entity
{
	/// <summary>
	/// 新增法人卡信息
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="NewlyAddedListFR")]
	public partial class NewlyAddedListFR
	{
		public NewlyAddedListFR()
		{}
		#region Model
		private string _listid;
		private string _shtyxydm_qs;
		private string _ztsbm_qs;
		private string _xzqyhm_qs;
		private string _qyzwmc_qs;
		private string _qyywmc_qs;
		private string _qydz_qs;
		private string _fddbr_qs;
		private string _frdh_qs;
		private string _qylx_qs;
		private decimal? _zczj_qs;
		private string _zczjbz_qs;
		private string _yyqx_qs;
		private int? _zjlx_qs_qs;
		private string _zjhm_qs;
		private string _cz_qs;
		private string _yzbm_qs;
		private string _fkjgdm_qs;
		private string _fzjgmc_qs;
		private DateTime? _fzrq_qs;
		private DateTime? _clrq_qs;
		private string _frlx_qs;
		private string _gsspdwdm_qs;
		private string _zjspdwdm_qs;
		private string _swspdwdm_qs;
		private string _jyfw_qs;
		private string _zzjgdm_hg;
		private string _hgzch_hg;
		private string _zghg_hg;
		private string _bahg_hg;
		private DateTime? _zcrq_hg;
		private DateTime? _yxrq_hg;
		private string _gszcqc_hg;
		private string _hgzcmc_hg;
		private string _dwmc_hg;
		private string _gszcdz_hg;
		private string _dwdz_hg;
		private string _yyzzzch_hg;
		private string _yzbm_hg;
		private string _frdb_hg;
		private string _frdh_hg;
		private string _bglb_hg;
		private int? _zjlx_hg;
		private string _frzjhm_hg;
		private string _jckqpzjg_hg;
		private string _pzwh_hg;
		private string _zczbbz_hg;
		private decimal? _zczb_hg;
		private string _zjl_hg;
		private string _dh_hg;
		private string _khyh_hg;
		private string _yhzh_hg;
		private string _swdjh_hg;
		private string _hyzl_hg;
		private decimal? _mse_hg;
		private string _zycp_hg;
		private string _jyfwjbz_hg;
		private string _jckqydm_hg;
		private string _qysclx_hg;
		private string _bz_hg;
		private decimal? _tzze_hg;
		private decimal? _dwzbze_hg;
		private decimal? _nxbl_hg;
		private DateTime? _zcyxrq_hg;
		private string _zzjgdm_wjm;
		private string _pzwh_wjm;
		private string _jckqydm_wjm;
		private DateTime? _pzrq_wjm;
		private DateTime? _fzrq_wjm;
		private string _fzjg_wjm;
		private string _zgwjm_wjm;
		private string _qyzwmc_wjm;
		private string _ywdz_wjm;
		private string _qydz_wjm;
		private string _jycs_wjm;
		private string _zgbm_wjm;
		private string _fddbr_wjm;
		private string _zs_wjm;
		private string _lxdh_wjm;
		private string _lxcz_wjm;
		private string _yzbm_wjm;
		private string _dzyx_wjm;
		private DateTime? _gsdjzcrq_wjm;
		private string _gsdjzch_wjm;
		private string _qyjylx_wjm;
		private int? _jynx_wjm;
		private decimal? _tzze_wjm;
		private string _tzbz_wjm;
		private decimal? _zczb_wjm;
		private string _zczbbz_wjm;
		private string _badjbbh_wjm;
		private decimal? _zczj_wjm;
		private string _jyfw_wjm;
		private string _jckspml_wjm;
		private string _bz_wjm;
		private string _zzjgdm_wh;
		private string _gszch_wh;
		private string _hgzch_wh;
		private DateTime? _hgzcyxq_wh;
		private string _zgwhj_wh;
		private string _qyzwmc_wh;
		private string _qydz_wh;
		private string _cz_wh;
		private string _dh_wh;
		private string _dzyx_wh;
		private string _fddbr_wh;
		private string _hxlxr_wh;
		private string _jyfw_wh;
		private string _hydm_wh;
		private string _qyyb_wh;
		private string _qyxz_wh;
		private decimal? _rmbzczj_wh;
		private string _wbzcbz_wh;
		private decimal? _wbzczj_wh;
		private DateTime? _zcslrq_wh;
		private DateTime? _jzyxrq_wh;
		private string _wmzsh_wh;
		private DateTime? _wmzspzrq_wh;
		private string _wmjyfw_wh;
		private DateTime? _hxkhrq_wh;
		private string _qylxmc_wh;
        private int? _nwflat;
		/// <summary>
		/// 工单项ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="ListID", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string ListID
		{
			set{ _listid=value;}
			get{return _listid;}
		}
		/// <summary>
		/// 统一社会信用代码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="SHTYXYDM_QS", ColunmType="string", CanEmpty=true, Length=18, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SHTYXYDM_QS
		{
			set{ _shtyxydm_qs=value;}
			get{return _shtyxydm_qs;}
		}
		/// <summary>
		/// 主体识别码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZTSBM_QS", ColunmType="string", CanEmpty=true, Length=10, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZTSBM_QS
		{
			set{ _ztsbm_qs=value;}
			get{return _ztsbm_qs;}
		}
		/// <summary>
		/// 登记管理机关行政区域划码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="XZQYHM_QS", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string XZQYHM_QS
		{
			set{ _xzqyhm_qs=value;}
			get{return _xzqyhm_qs;}
		}
		/// <summary>
		/// 企业中文名称_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYZWMC_QS", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYZWMC_QS
		{
			set{ _qyzwmc_qs=value;}
			get{return _qyzwmc_qs;}
		}
		/// <summary>
        /// 企业英文名称_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYYWMC_QS", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYYWMC_QS
		{
			set{ _qyywmc_qs=value;}
			get{return _qyywmc_qs;}
		}
		/// <summary>
		/// 企业地址_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYDZ_QS", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYDZ_QS
		{
			set{ _qydz_qs=value;}
			get{return _qydz_qs;}
		}
		/// <summary>
		/// 法定代表人_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="FDDBR_QS", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FDDBR_QS
		{
			set{ _fddbr_qs=value;}
			get{return _fddbr_qs;}
		}
		/// <summary>
		/// 法人电话_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRDH_QS", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRDH_QS
		{
			set{ _frdh_qs=value;}
			get{return _frdh_qs;}
		}
		/// <summary>
		/// 企业类型_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYLX_QS", ColunmType="string", CanEmpty=true, Length=2, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYLX_QS
		{
			set{ _qylx_qs=value;}
			get{return _qylx_qs;}
		}
		/// <summary>
		/// 注册资金单位_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZJ_QS", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? ZCZJ_QS
		{
			set{ _zczj_qs=value;}
			get{return _zczj_qs;}
		}
		/// <summary>
		/// 注册资金币值_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZJBZ_QS", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZCZJBZ_QS
		{
			set{ _zczjbz_qs=value;}
			get{return _zczjbz_qs;}
		}
		/// <summary>
		/// 营业期限_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="YYQX_QS", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YYQX_QS
		{
			set{ _yyqx_qs=value;}
			get{return _yyqx_qs;}
		}
		/// <summary>
		/// 证件类型_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJLX_QS_QS", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? ZJLX_QS_QS
		{
			set{ _zjlx_qs_qs=value;}
			get{return _zjlx_qs_qs;}
		}
		/// <summary>
		/// 证件号码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJHM_QS", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZJHM_QS
		{
			set{ _zjhm_qs=value;}
			get{return _zjhm_qs;}
		}
		/// <summary>
        /// 传真_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="CZ_QS", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CZ_QS
		{
			set{ _cz_qs=value;}
			get{return _cz_qs;}
		}
		/// <summary>
        /// 邮政编码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="YZBM_QS", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YZBM_QS
		{
			set{ _yzbm_qs=value;}
			get{return _yzbm_qs;}
		}
		/// <summary>
		/// 发卡机构代码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="FKJGDM_QS", ColunmType="string", CanEmpty=true, Length=2, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FKJGDM_QS
		{
			set{ _fkjgdm_qs=value;}
			get{return _fkjgdm_qs;}
		}
		/// <summary>
        /// 发证机构名称_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="FZJGMC_QS", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FZJGMC_QS
		{
			set{ _fzjgmc_qs=value;}
			get{return _fzjgmc_qs;}
		}
		/// <summary>
		/// 发证日期
		/// </summary>
        [DBRowEntityProperty(ColunmName = "FZRQ_QS", ColunmType = "DateTime", CanEmpty = true, Length = 3, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public DateTime? FZRQ_QS
		{
			set{ _fzrq_qs=value;}
			get{return _fzrq_qs;}
		}
		/// <summary>
		/// 成立日期
		/// </summary>
        [DBRowEntityProperty(ColunmName = "CLRQ_QS", ColunmType = "DateTime", CanEmpty = true, Length = 3, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public DateTime? CLRQ_QS
		{
			set{ _clrq_qs=value;}
			get{return _clrq_qs;}
		}
		/// <summary>
		/// 法人类型_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRLX_QS", ColunmType="string", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRLX_QS
		{
			set{ _frlx_qs=value;}
			get{return _frlx_qs;}
		}
		/// <summary>
		/// 工商审核单位代码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSSPDWDM_QS", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GSSPDWDM_QS
		{
			set{ _gsspdwdm_qs=value;}
			get{return _gsspdwdm_qs;}
		}
		/// <summary>
		/// 技监审核单位代码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJSPDWDM_QS", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZJSPDWDM_QS
		{
			set{ _zjspdwdm_qs=value;}
			get{return _zjspdwdm_qs;}
		}
		/// <summary>
		/// 税务审核单位代码_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="SWSPDWDM_QS", ColunmType="string", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SWSPDWDM_QS
		{
			set{ _swspdwdm_qs=value;}
			get{return _swspdwdm_qs;}
		}
		/// <summary>
		/// 经营范围_前三
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYFW_QS", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JYFW_QS
		{
			set{ _jyfw_qs=value;}
			get{return _jyfw_qs;}
		}
		/// <summary>
		/// 组织机构代码_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZZJGDM_HG", ColunmType="string", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZZJGDM_HG
		{
			set{ _zzjgdm_hg=value;}
			get{return _zzjgdm_hg;}
		}
		/// <summary>
		/// 海关注册号_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="HGZCH_HG", ColunmType="string", CanEmpty=true, Length=10, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HGZCH_HG
		{
			set{ _hgzch_hg=value;}
			get{return _hgzch_hg;}
		}
		/// <summary>
		/// 主管海关_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZGHG_HG", ColunmType="string", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZGHG_HG
		{
			set{ _zghg_hg=value;}
			get{return _zghg_hg;}
		}
		/// <summary>
		/// 备案海关_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="BAHG_HG", ColunmType="string", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string BAHG_HG
		{
			set{ _bahg_hg=value;}
			get{return _bahg_hg;}
		}
		/// <summary>
		/// 注册日期_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCRQ_HG", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? ZCRQ_HG
		{
			set{ _zcrq_hg=value;}
			get{return _zcrq_hg;}
		}
		/// <summary>
		/// 企业注册有效日期_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="YXRQ_HG", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? YXRQ_HG
		{
			set{ _yxrq_hg=value;}
			get{return _yxrq_hg;}
		}
		/// <summary>
		/// 工商注册全称_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSZCQC_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GSZCQC_HG
		{
			set{ _gszcqc_hg=value;}
			get{return _gszcqc_hg;}
		}
		/// <summary>
		/// 海关注册名称_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="HGZCMC_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HGZCMC_HG
		{
			set{ _hgzcmc_hg=value;}
			get{return _hgzcmc_hg;}
		}
		/// <summary>
		/// 对外(英文)名称_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="DWMC_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DWMC_HG
		{
			set{ _dwmc_hg=value;}
			get{return _dwmc_hg;}
		}
		/// <summary>
		/// 工商注册地址_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSZCDZ_HG", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GSZCDZ_HG
		{
			set{ _gszcdz_hg=value;}
			get{return _gszcdz_hg;}
		}
		/// <summary>
		/// 对外(英文)地址_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="DWDZ_HG", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DWDZ_HG
		{
			set{ _dwdz_hg=value;}
			get{return _dwdz_hg;}
		}
		/// <summary>
		/// 营业执照注册号_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="YYZZZCH_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YYZZZCH_HG
		{
			set{ _yyzzzch_hg=value;}
			get{return _yyzzzch_hg;}
		}
		/// <summary>
		/// 邮政编码_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="YZBM_HG", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YZBM_HG
		{
			set{ _yzbm_hg=value;}
			get{return _yzbm_hg;}
		}
		/// <summary>
		/// 法人代表_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRDB_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRDB_HG
		{
			set{ _frdb_hg=value;}
			get{return _frdb_hg;}
		}
		/// <summary>
		/// 法人电话_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRDH_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRDH_HG
		{
			set{ _frdh_hg=value;}
			get{return _frdh_hg;}
		}
		/// <summary>
		/// 报关类别_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="BGLB_HG", ColunmType="string", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string BGLB_HG
		{
			set{ _bglb_hg=value;}
			get{return _bglb_hg;}
		}
		/// <summary>
		/// 证件类别_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJLX_HG", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? ZJLX_HG
		{
			set{ _zjlx_hg=value;}
			get{return _zjlx_hg;}
		}
		/// <summary>
		/// 法人证件号码_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRZJHM_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRZJHM_HG
		{
			set{ _frzjhm_hg=value;}
			get{return _frzjhm_hg;}
		}
		/// <summary>
		/// 进出口权批准机关_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="JCKQPZJG_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JCKQPZJG_HG
		{
			set{ _jckqpzjg_hg=value;}
			get{return _jckqpzjg_hg;}
		}
		/// <summary>
		/// 批准文号_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="PZWH_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string PZWH_HG
		{
			set{ _pzwh_hg=value;}
			get{return _pzwh_hg;}
		}
		/// <summary>
		/// 注册资本币制_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZBBZ_HG", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZCZBBZ_HG
		{
			set{ _zczbbz_hg=value;}
			get{return _zczbbz_hg;}
		}
		/// <summary>
		/// 注册资本(万)_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZB_HG", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? ZCZB_HG
		{
			set{ _zczb_hg=value;}
			get{return _zczb_hg;}
		}
		/// <summary>
		/// 总经理_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJL_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZJL_HG
		{
			set{ _zjl_hg=value;}
			get{return _zjl_hg;}
		}
		/// <summary>
		/// 电话_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="DH_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DH_HG
		{
			set{ _dh_hg=value;}
			get{return _dh_hg;}
		}
		/// <summary>
		/// 开户银行_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="KHYH_HG", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string KHYH_HG
		{
			set{ _khyh_hg=value;}
			get{return _khyh_hg;}
		}
		/// <summary>
		/// 银行帐号_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="YHZH_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YHZH_HG
		{
			set{ _yhzh_hg=value;}
			get{return _yhzh_hg;}
		}
		/// <summary>
		/// 税务登记号_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="SWDJH_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SWDJH_HG
		{
			set{ _swdjh_hg=value;}
			get{return _swdjh_hg;}
		}
		/// <summary>
		/// 行业种类_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="HYZL_HG", ColunmType="string", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HYZL_HG
		{
			set{ _hyzl_hg=value;}
			get{return _hyzl_hg;}
		}
		/// <summary>
		/// 免税额_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="MSE_HG", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? MSE_HG
		{
			set{ _mse_hg=value;}
			get{return _mse_hg;}
		}
		/// <summary>
		/// 主要产品_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZYCP_HG", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZYCP_HG
		{
			set{ _zycp_hg=value;}
			get{return _zycp_hg;}
		}
		/// <summary>
		/// 经营范围及备注_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYFWJBZ_HG", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JYFWJBZ_HG
		{
			set{ _jyfwjbz_hg=value;}
			get{return _jyfwjbz_hg;}
		}
		/// <summary>
		/// 进出口企业代码_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="JCKQYDM_HG", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JCKQYDM_HG
		{
			set{ _jckqydm_hg=value;}
			get{return _jckqydm_hg;}
		}
		/// <summary>
		/// 企业生产类型_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYSCLX_HG", ColunmType="string", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYSCLX_HG
		{
			set{ _qysclx_hg=value;}
			get{return _qysclx_hg;}
		}
		/// <summary>
		/// 币制_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="BZ_HG", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string BZ_HG
		{
			set{ _bz_hg=value;}
			get{return _bz_hg;}
		}
		/// <summary>
		/// 投资总额(万)_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="TZZE_HG", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? TZZE_HG
		{
			set{ _tzze_hg=value;}
			get{return _tzze_hg;}
		}
		/// <summary>
		/// 到位资本总额(万)_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="DWZBZE_HG", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? DWZBZE_HG
		{
			set{ _dwzbze_hg=value;}
			get{return _dwzbze_hg;}
		}
		/// <summary>
		/// 内销比率(%)_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="NXBL_HG", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? NXBL_HG
		{
			set{ _nxbl_hg=value;}
			get{return _nxbl_hg;}
		}
		/// <summary>
		/// 注册有效日期_海关
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCYXRQ_HG", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? ZCYXRQ_HG
		{
			set{ _zcyxrq_hg=value;}
			get{return _zcyxrq_hg;}
		}
		/// <summary>
		/// 组织机构代码_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZZJGDM_WJM", ColunmType="string", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZZJGDM_WJM
		{
			set{ _zzjgdm_wjm=value;}
			get{return _zzjgdm_wjm;}
		}
		/// <summary>
		/// 批准文号_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="PZWH_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string PZWH_WJM
		{
			set{ _pzwh_wjm=value;}
			get{return _pzwh_wjm;}
		}
		/// <summary>
		/// 进出口企业代码_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="JCKQYDM_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JCKQYDM_WJM
		{
			set{ _jckqydm_wjm=value;}
			get{return _jckqydm_wjm;}
		}
		/// <summary>
		/// 批准日期_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="PZRQ_WJM", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? PZRQ_WJM
		{
			set{ _pzrq_wjm=value;}
			get{return _pzrq_wjm;}
		}
		/// <summary>
		/// 发证（备案）日期_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="FZRQ_WJM", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? FZRQ_WJM
		{
			set{ _fzrq_wjm=value;}
			get{return _fzrq_wjm;}
		}
		/// <summary>
		/// 发证（备案）机关_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="FZJG_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FZJG_WJM
		{
			set{ _fzjg_wjm=value;}
			get{return _fzjg_wjm;}
		}
		/// <summary>
		/// 主管外经委_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZGWJM_WJM", ColunmType="string", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZGWJM_WJM
		{
			set{ _zgwjm_wjm=value;}
			get{return _zgwjm_wjm;}
		}
		/// <summary>
		/// 企业（经营者）中文名称_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYZWMC_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYZWMC_WJM
		{
			set{ _qyzwmc_wjm=value;}
			get{return _qyzwmc_wjm;}
		}
		/// <summary>
		/// 英文对照（经营者英文名称）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="YWDZ_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YWDZ_WJM
		{
			set{ _ywdz_wjm=value;}
			get{return _ywdz_wjm;}
		}
		/// <summary>
		/// 企业地址（经营场所）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYDZ_WJM", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYDZ_WJM
		{
			set{ _qydz_wjm=value;}
			get{return _qydz_wjm;}
		}
		/// <summary>
		/// 经营场所（英文）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYCS_WJM", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JYCS_WJM
		{
			set{ _jycs_wjm=value;}
			get{return _jycs_wjm;}
		}
		/// <summary>
		/// 主管部门_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZGBM_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZGBM_WJM
		{
			set{ _zgbm_wjm=value;}
			get{return _zgbm_wjm;}
		}
		/// <summary>
		/// 法定代表人（个体工商负责人）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="FDDBR_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FDDBR_WJM
		{
			set{ _fddbr_wjm=value;}
			get{return _fddbr_wjm;}
		}
		/// <summary>
		/// 住所_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZS_WJM", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZS_WJM
		{
			set{ _zs_wjm=value;}
			get{return _zs_wjm;}
		}
		/// <summary>
		/// 联系电话_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="LXDH_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string LXDH_WJM
		{
			set{ _lxdh_wjm=value;}
			get{return _lxdh_wjm;}
		}
		/// <summary>
		/// 联系传真_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="LXCZ_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string LXCZ_WJM
		{
			set{ _lxcz_wjm=value;}
			get{return _lxcz_wjm;}
		}
		/// <summary>
		/// 邮政编码_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="YZBM_WJM", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string YZBM_WJM
		{
			set{ _yzbm_wjm=value;}
			get{return _yzbm_wjm;}
		}
		/// <summary>
		/// 电子邮箱_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="DZYX_WJM", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DZYX_WJM
		{
			set{ _dzyx_wjm=value;}
			get{return _dzyx_wjm;}
		}
		/// <summary>
		/// 工商登记注册日期_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSDJZCRQ_WJM", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? GSDJZCRQ_WJM
		{
			set{ _gsdjzcrq_wjm=value;}
			get{return _gsdjzcrq_wjm;}
		}
		/// <summary>
		/// 工商登记注册号_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSDJZCH_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GSDJZCH_WJM
		{
			set{ _gsdjzch_wjm=value;}
			get{return _gsdjzch_wjm;}
		}
		/// <summary>
		/// 企业（经营者）类型_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYJYLX_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYJYLX_WJM
		{
			set{ _qyjylx_wjm=value;}
			get{return _qyjylx_wjm;}
		}
		/// <summary>
		/// 经营年限_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYNX_WJM", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? JYNX_WJM
		{
			set{ _jynx_wjm=value;}
			get{return _jynx_wjm;}
		}
		/// <summary>
		/// 投资总额（万）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="TZZE_WJM", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? TZZE_WJM
		{
			set{ _tzze_wjm=value;}
			get{return _tzze_wjm;}
		}
		/// <summary>
		/// 投资币制_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="TZBZ_WJM", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string TZBZ_WJM
		{
			set{ _tzbz_wjm=value;}
			get{return _tzbz_wjm;}
		}
		/// <summary>
		/// 注册资本（万）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZB_WJM", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? ZCZB_WJM
		{
			set{ _zczb_wjm=value;}
			get{return _zczb_wjm;}
		}
		/// <summary>
		/// 注册资本币制_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZBBZ_WJM", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZCZBBZ_WJM
		{
			set{ _zczbbz_wjm=value;}
			get{return _zczbbz_wjm;}
		}
		/// <summary>
		/// 备案登记表编号_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="BADJBBH_WJM", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string BADJBBH_WJM
		{
			set{ _badjbbh_wjm=value;}
			get{return _badjbbh_wjm;}
		}
		/// <summary>
		/// 注册资金（折美元）_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCZJ_WJM", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? ZCZJ_WJM
		{
			set{ _zczj_wjm=value;}
			get{return _zczj_wjm;}
		}
		/// <summary>
		/// 经营范围_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYFW_WJM", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JYFW_WJM
		{
			set{ _jyfw_wjm=value;}
			get{return _jyfw_wjm;}
		}
		/// <summary>
		/// 进出口商品目录_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="JCKSPML_WJM", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JCKSPML_WJM
		{
			set{ _jckspml_wjm=value;}
			get{return _jckspml_wjm;}
		}
		/// <summary>
		/// 备注_外经贸
		/// </summary>
		[DBRowEntityProperty(ColunmName="BZ_WJM", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string BZ_WJM
		{
			set{ _bz_wjm=value;}
			get{return _bz_wjm;}
		}
		/// <summary>
		/// 组织机构代码_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZZJGDM_WH", ColunmType="string", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZZJGDM_WH
		{
			set{ _zzjgdm_wh=value;}
			get{return _zzjgdm_wh;}
		}
		/// <summary>
		/// 工商注册号_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="GSZCH_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GSZCH_WH
		{
			set{ _gszch_wh=value;}
			get{return _gszch_wh;}
		}
		/// <summary>
		/// 海关注册号_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="HGZCH_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HGZCH_WH
		{
			set{ _hgzch_wh=value;}
			get{return _hgzch_wh;}
		}
		/// <summary>
		/// 海关注册有效期_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="HGZCYXQ_WH", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? HGZCYXQ_WH
		{
			set{ _hgzcyxq_wh=value;}
			get{return _hgzcyxq_wh;}
		}
		/// <summary>
		/// 主管外汇局_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZGWHJ_WH", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZGWHJ_WH
		{
			set{ _zgwhj_wh=value;}
			get{return _zgwhj_wh;}
		}
		/// <summary>
		/// 企业中文全称_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYZWMC_WH", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYZWMC_WH
		{
			set{ _qyzwmc_wh=value;}
			get{return _qyzwmc_wh;}
		}
		/// <summary>
		/// 企业地址_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYDZ_WH", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYDZ_WH
		{
			set{ _qydz_wh=value;}
			get{return _qydz_wh;}
		}
		/// <summary>
		/// 传真_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="CZ_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string CZ_WH
		{
			set{ _cz_wh=value;}
			get{return _cz_wh;}
		}
		/// <summary>
		/// 电话_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="DH_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DH_WH
		{
			set{ _dh_wh=value;}
			get{return _dh_wh;}
		}
		/// <summary>
		/// 电子信箱_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="DZYX_WH", ColunmType="string", CanEmpty=true, Length=256, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DZYX_WH
		{
			set{ _dzyx_wh=value;}
			get{return _dzyx_wh;}
		}
		/// <summary>
		/// 法定代表人_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="FDDBR_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FDDBR_WH
		{
			set{ _fddbr_wh=value;}
			get{return _fddbr_wh;}
		}
		/// <summary>
		/// 核销联系人_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="HXLXR_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HXLXR_WH
		{
			set{ _hxlxr_wh=value;}
			get{return _hxlxr_wh;}
		}
		/// <summary>
		/// 经营范围_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="JYFW_WH", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JYFW_WH
		{
			set{ _jyfw_wh=value;}
			get{return _jyfw_wh;}
		}
		/// <summary>
		/// 行业代码_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="HYDM_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HYDM_WH
		{
			set{ _hydm_wh=value;}
			get{return _hydm_wh;}
		}
		/// <summary>
		/// 企业邮编_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYYB_WH", ColunmType="string", CanEmpty=true, Length=6, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYYB_WH
		{
			set{ _qyyb_wh=value;}
			get{return _qyyb_wh;}
		}
		/// <summary>
		/// 企业性质_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYXZ_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYXZ_WH
		{
			set{ _qyxz_wh=value;}
			get{return _qyxz_wh;}
		}
		/// <summary>
		/// 人民币注册资金_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="RMBZCZJ_WH", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? RMBZCZJ_WH
		{
			set{ _rmbzczj_wh=value;}
			get{return _rmbzczj_wh;}
		}
		/// <summary>
		/// 外币注册币种_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="WBZCBZ_WH", ColunmType="string", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WBZCBZ_WH
		{
			set{ _wbzcbz_wh=value;}
			get{return _wbzcbz_wh;}
		}
		/// <summary>
		/// 外币注册资金（万）_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="WBZCZJ_WH", ColunmType="decimal", CanEmpty=true, Length=9, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public decimal? WBZCZJ_WH
		{
			set{ _wbzczj_wh=value;}
			get{return _wbzczj_wh;}
		}
		/// <summary>
		/// 最初设立日期_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZCSLRQ_WH", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? ZCSLRQ_WH
		{
			set{ _zcslrq_wh=value;}
			get{return _zcslrq_wh;}
		}
		/// <summary>
		/// 截止有效日期_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="JZYXRQ_WH", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? JZYXRQ_WH
		{
			set{ _jzyxrq_wh=value;}
			get{return _jzyxrq_wh;}
		}
		/// <summary>
		/// 外贸证书号_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="WMZSH_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WMZSH_WH
		{
			set{ _wmzsh_wh=value;}
			get{return _wmzsh_wh;}
		}
		/// <summary>
		/// 外贸证书批准日期_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="WMZSPZRQ_WH", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? WMZSPZRQ_WH
		{
			set{ _wmzspzrq_wh=value;}
			get{return _wmzspzrq_wh;}
		}
		/// <summary>
		/// 外贸经营范围_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="WMJYFW_WH", ColunmType="string", CanEmpty=true, Length=4000, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WMJYFW_WH
		{
			set{ _wmjyfw_wh=value;}
			get{return _wmjyfw_wh;}
		}
		/// <summary>
		/// 核销开户日期_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="HXKHRQ_WH", ColunmType="DateTime", CanEmpty=true, Length=3, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? HXKHRQ_WH
		{
			set{ _hxkhrq_wh=value;}
			get{return _hxkhrq_wh;}
		}
		/// <summary>
		/// 企业类型名称_外汇
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYLXMC_WH", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYLXMC_WH
		{
			set{ _qylxmc_wh=value;}
			get{return _qylxmc_wh;}
		}
        /// <summary>
        /// 内资或外资标记
        /// </summary>
        [DBRowEntityProperty(ColunmName = "NWFlat", ColunmType = "int", CanEmpty = true, Length = 4, IsDataTableRow = true, IsPrimarykey = false, IsIncrement = false, HaveDefaultValue = false)]
        public int? NWFlat
        {
            set { _nwflat = value; }
            get { return _nwflat; }
        }
		#endregion Model

	}
}

