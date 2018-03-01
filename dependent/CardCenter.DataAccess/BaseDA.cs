using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZWL;

namespace CardCenter.DataAccess
{
    public class BaseDA
    {
        protected ZWL.DataBase.DbHelperSQL DbHelperSQL;
        protected BaseDA()
        {
            if (ZWL.GeneralHelper.GetSettingByKey("IsHash") == "YES")
                DbHelperSQL = new DataBase.DbHelperSQL(new Encrypt.DESHelper("Card","DES").DesDecrypt(ZWL.GeneralHelper.GetSettingByKey("ConnectionString")));
            else
                DbHelperSQL = new DataBase.DbHelperSQL();
        }
    }
}
