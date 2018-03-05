using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CardCenter.PageBase;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;

namespace CardCenter
{
    public partial class Default : UserVerifyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string txt = new ZWL.Encrypt.DESHelper("Card", "DES").DesEncrypt("Data Source=.;Initial Catalog=CardPrinting;Persist Security Info=True;User ID=fzxadmin_sa;Password=qwer*1234;Pooling=False");
        }
    }
}