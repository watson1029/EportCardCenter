/**  版本信息模板在安装目录下，可自行修改。
* Stock_Commodity.cs
*
* 功 能： N/A
* 类 名： Stock_Commodity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/8 10:25:18   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace CardCenter.Entity
{
	/// <summary>
	/// Stock_Commodity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Stock_Commodity
	{
		public Stock_Commodity()
		{}
		#region Model
		private string _guid;
		private string _commodityname;
		private string _commoditytype;
        private string _additionalattributes;
		private decimal? _sellingprice;
		private decimal? _costprice;
		private int? _stockdesplay;
		private int? _stockactual;
		/// <summary>
		/// 
		/// </summary>
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommodityName
		{
			set{ _commodityname=value;}
			get{return _commodityname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommodityType
		{
			set{ _commoditytype=value;}
			get{return _commoditytype;}
		}
        /// <summary>
		/// 
		/// </summary>
        public string AdditionalAttributes
        {
            set { _additionalattributes = value; }
            get { return _additionalattributes; }
        }
		/// <summary>
		/// 
		/// </summary>
		public decimal? SellingPrice
		{
			set{ _sellingprice=value;}
			get{return _sellingprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StockDesplay
		{
			set{ _stockdesplay=value;}
			get{return _stockdesplay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StockActual
		{
			set{ _stockactual=value;}
			get{return _stockactual;}
		}
		#endregion Model

	}
}

