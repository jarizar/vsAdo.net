using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UI.WebForm.Common
{
    public class ManageSession
    {
        public static List<SaleDetail> SaleDetails
        {
            get
            {
                var sales = new List<SaleDetail>();

                if (HttpContext.Current.Session["sale"] != null)
                {
                    sales = HttpContext.Current.Session["sale"] as List<SaleDetail>;
                }

                return sales;
            }
            set
            {
               HttpContext.Current.Session["sale"] = value;
            }
        }

    }
}