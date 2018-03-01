/**  版本信息模板在安装目录下，可自行修改。
* Sys_User.cs
*
* 功 能： N/A
* 类 名： Sys_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/2/9 10:37:27   N/A    初版
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
	/// 数据访问类:Sys_User
	/// </summary>
	public partial class Sys_User : BaseDA
	{
		public Sys_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CardCenter.Entity.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User(");
			strSql.Append("Guid,UserName,Name,Password,Phone,RoleAuthorize,Department,IsDelete,IsSuperUser,Pic,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@UserName,@Name,@Password,@Phone,@RoleAuthorize,@Department,@IsDelete,@IsSuperUser,@Pic,@CreateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@UserName", SqlDbType.NVarChar,64),
					new SqlParameter("@Name", SqlDbType.NVarChar,64),
					new SqlParameter("@Password", SqlDbType.NVarChar,64),
					new SqlParameter("@Phone", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleAuthorize", SqlDbType.NVarChar,1024),
					new SqlParameter("@Department", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsSuperUser", SqlDbType.Bit,1),
					new SqlParameter("@Pic", SqlDbType.NVarChar,512),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.RoleAuthorize;
			parameters[6].Value = model.Department;
			parameters[7].Value = model.IsDelete;
			parameters[8].Value = model.IsSuperUser;
			parameters[9].Value = model.Pic;
			parameters[10].Value = model.CreateTime;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(CardCenter.Entity.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Name=@Name,");
			strSql.Append("Password=@Password,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("RoleAuthorize=@RoleAuthorize,");
			strSql.Append("Department=@Department,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("IsSuperUser=@IsSuperUser,");
			strSql.Append("Pic=@Pic,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,64),
					new SqlParameter("@Name", SqlDbType.NVarChar,64),
					new SqlParameter("@Password", SqlDbType.NVarChar,64),
					new SqlParameter("@Phone", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleAuthorize", SqlDbType.NVarChar,1024),
					new SqlParameter("@Department", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsSuperUser", SqlDbType.Bit,1),
					new SqlParameter("@Pic", SqlDbType.NVarChar,512),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.RoleAuthorize;
			parameters[5].Value = model.Department;
			parameters[6].Value = model.IsDelete;
			parameters[7].Value = model.IsSuperUser;
			parameters[8].Value = model.Pic;
			parameters[9].Value = model.CreateTime;
			parameters[10].Value = model.Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
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
		public CardCenter.Entity.Sys_User GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,UserName,Name,Password,Phone,RoleAuthorize,Department,IsDelete,IsSuperUser,Pic,CreateTime from Sys_User ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.Sys_User model=new CardCenter.Entity.Sys_User();
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
		public CardCenter.Entity.Sys_User DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Sys_User model=new CardCenter.Entity.Sys_User();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["RoleAuthorize"]!=null)
				{
					model.RoleAuthorize=row["RoleAuthorize"].ToString();
				}
				if(row["Department"]!=null && row["Department"].ToString()!="")
				{
					model.Department=int.Parse(row["Department"].ToString());
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
				if(row["IsSuperUser"]!=null && row["IsSuperUser"].ToString()!="")
				{
					if((row["IsSuperUser"].ToString()=="1")||(row["IsSuperUser"].ToString().ToLower()=="true"))
					{
						model.IsSuperUser=true;
					}
					else
					{
						model.IsSuperUser=false;
					}
				}
				if(row["Pic"]!=null)
				{
					model.Pic=row["Pic"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select Guid,UserName,Name,Password,Phone,RoleAuthorize,Department,IsDelete,IsSuperUser,Pic,CreateTime ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append(" Guid,UserName,Name,Password,Phone,RoleAuthorize,Department,IsDelete,IsSuperUser,Pic,CreateTime ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append("select count(1) FROM Sys_User ");
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
			strSql.Append(")AS Row, T.*  from Sys_User T ");
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
			parameters[0].Value = "Sys_User";
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
        public string RndPwd(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = "";
            int temp = -1;

            Random rand = new Random();

            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return RndPwd(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
        #endregion  ExtensionMethod
    }
}

