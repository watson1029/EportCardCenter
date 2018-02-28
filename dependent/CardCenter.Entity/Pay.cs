using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardCenter.Entity
{
    [Serializable]
    public class PayResult
    {
        public string OrderId { set; get; }
        public string Status { set; get; }
        public string ErrorCode { set; get; }
        public string NonceStr { set; get; }
        public string Signature { set; get; }
        public string LastUpdated { set; get; }
    }

    [Serializable]
    public class PayOrder
    {
        public string OrderId { set; get; }
        public int Amount { set; get; }
        public string Description { set; get; }
        public string ApplicantName { set; get; }
        public string AppId { set; get; }
        public string CallbackUrl { set; get; }
        public string NotifyUrl { set; get; }
        public string Account { set; get; }
        public string Note { set; get; }
    }
}
