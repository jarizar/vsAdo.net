using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void lnbSalir_Click(object sender, EventArgs e)
        {
            //Con este código eliimina la cookie de autenticación.
            Context.GetOwinContext().Authentication.SignOut();
            Response.Redirect("~/Login.aspx");
            
        }
    }
}