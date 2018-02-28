using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardCenter.Entity
{
    public class Enum
    {
        public enum OperationSign
        {
            未操作 = 1,
            操作成功 = 2,
            操作失败 = 3,
        }

        public enum CardType
        {
            法人卡 = 1,
            操作员IC卡 = 2,
            操作员IKEY = 3,
            报关员卡 = 4,
        }

        public enum ProductType
        {
            读卡器 = 1,
            软件 = 2,
        }
    }
}
