using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace AHCBL.Component.Common
{
    public static class Form
    {
        //public static void SetAlertMessage(this Page page, string msg)
        //{
        //    msg = string.Format("alert('{0}')", msg);
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "InformationSave", msg, true);
        //}
        public static void SetAlertMessage(this Page page, string msg)
        {
            msg = string.Format("alert('{0}')", msg);
            page.ClientScript.RegisterStartupScript(page.GetType(), "InformationSave", msg, true);
        }

    }
}