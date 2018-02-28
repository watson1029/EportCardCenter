using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace CardCenter.PageBase
{
    public class WebHelper
    {
        public static string _Text = "text";
        public static string _Value = "value";

        public static DataTable ListEnum(Type enumType)
        {
            DataTable table = new DataTable();
            table.Columns.Add(_Text);
            table.Columns.Add(_Value);
            foreach (Enum enum2 in Enum.GetValues(enumType))
            {
                DataRow row = table.NewRow();
                row[_Text] = enum2.ToString();
                row[_Value] = (int)Enum.Parse(enumType, enum2.ToString());
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ListDictionary(Dictionary<string,string> dic)
        {
            DataTable table = new DataTable();
            table.Columns.Add(_Text);
            table.Columns.Add(_Value);
            foreach (KeyValuePair<string, string> pair in dic)
            {
                DataRow row = table.NewRow();
                row[_Text] = pair.Value;
                row[_Value] = pair.Key;
                table.Rows.Add(row);
            }
            return table;
        }

        const string KEY_64 = "EObusine";//注意了，是8个字符，64位
        const string IV_64 = "EObusine";
        public static string Encode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string Decode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            string returnStr = sr.ReadToEnd();
            sr.Close();
            return returnStr;
        }

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /**/
        /**/
        /**/
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(KEY_64.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(KEY_64);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                return null;
            }
        }

        public static string EncodeMD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] by = System.Text.Encoding.Unicode.GetBytes(input.ToCharArray());//将字符数组转化成字节数组
            byte[] bt = md5.ComputeHash(by);//将字节数组加入到MD5中进行加密
            string bs = System.Text.Encoding.Unicode.GetString(bt);
            return bs;
            // return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5").ToLower();
        }

        public static object GetAppSettingsValue(string key)
        {
            try
            {
                return WebConfigurationManager.AppSettings[key];
            }
            catch
            {
                return null;
            }
        } 

        public static bool IsNumber(object obj)
        {
            if (obj == null)
                return false;

            int i = 0;
            return int.TryParse(obj.ToString(), out i);
        }
        public static int TryNumber(object obj)
        {
            if (IsNumber(obj))
                return Convert.ToInt32(obj);
            return 0;

        }


        private static bool IsDataTime(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            DateTime dt = new DateTime();
            return DateTime.TryParse(str, out dt);
        }

        public static bool IsDecimal(object str)
        {
            if (str == null)
                return false;
            decimal d = 0;
            return decimal.TryParse(str.ToString(), out d);
        }

        public static decimal TryDecimal(object str)
        {
            if (IsDecimal(str))
                return Convert.ToDecimal(str);
            return 0;
        }

        public static string TryPrice(object str)
        {
            return TryDecimal(str) > 0 ? decimal.Round(Convert.ToDecimal(str), 2).ToString() : "";
        }

        public static DataTable GetSubTable(DataTable sourTable, string condition)
        {
            if (sourTable == null)
                return null;

            DataTable dt = sourTable.Clone();
            foreach (DataRow dr in sourTable.Select(condition))
            {
                dt.Rows.Add(dr.ItemArray);
            }
            return dt;
        }

        public static DataTable GetSubTable(DataTable sourTable, int rowCount)
        {
            if (sourTable == null)
                return null;

            if (rowCount >= sourTable.Rows.Count)
                rowCount = sourTable.Rows.Count;

            DataTable dt = sourTable.Clone();
            for (int i = 0; i < rowCount; i++)
            {
                dt.Rows.Add(sourTable.Rows[i].ItemArray);
            }
            return dt;
        }

        public static DataTable GetSubTable(DataTable sourTable, int index, int lastIndex)
        {
            if (sourTable == null)
                return null;
            if (sourTable.Rows.Count < index)
                return null;

            DataTable dt = sourTable.Clone();
            int last = index;
            if (sourTable.Rows.Count - 1 <= lastIndex)
            {
                last = sourTable.Rows.Count - 1;
            }
            else
            {
                last = lastIndex;
            }
            for (int i = index; i <= last; i++)
            {
                dt.Rows.Add(sourTable.Rows[i].ItemArray);
            }
            return dt;
        }

        public static decimal GetUserExperience(decimal integrityValue, decimal abilityValue, decimal serviceValue)
        {
            return integrityValue + abilityValue + serviceValue;
        }

        public static bool IsBool(object obj)
        {
            if (obj == null)
                return false;
            if (obj.ToString().Trim().ToLower() == "true")
                return true;
            if (WebHelper.IsNumber(obj.ToString()) && Convert.ToInt32(obj) == 1)
                return true;
            return false;
        }

        public static bool TryBool(object p)
        {
            if (IsBool(p))
                return true;
            return false;
        }

        public static bool IsDateTime(object p)
        {
            if (p == null)
                return false;
            if (IsDataTime(p.ToString()))
                return true;
            return false;
        }

        public static string TryDateTime(object obj)
        {
            return IsDateTime(obj) ? Convert.ToDateTime(obj).ToString("yyyy-MM-dd") : "";
        }

         
        public static bool IsEmail(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return Regex.IsMatch(str, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        } 

        /// <summary>
        /// 查看两个集合是否有交集
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CheckTwoListHaveSame<T>(List<T> list1, List<T> list2)
        {
            bool result = false;
            foreach (var item in list1)
            {
                if (list2.Contains(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool IsMobile(string str)
        {
            return Regex.IsMatch(str, @"^(13|14|15|16|18|19)\d{9}$");
        }

        public static object GetWebConfitAppsettingValue(string key)
        {
            object obj;
            try
            {
                obj= WebConfigurationManager.AppSettings[key];
            }
            catch
            {
                obj= null;
            }

            return obj;
        }
    }
}
