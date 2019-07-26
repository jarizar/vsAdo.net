using App.Data.Repository;
using App.Entities.Base;
using App.Entities.Queries;
using App.UI.Clinica.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSessionId"] = null;
               
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
            using (var uw = new AppUnitOfWork())
            {

                var objEmpleado = uw.EmpleadoRepository.LoginEmpleado(LoginUser.UserName, LoginUser.Password);

                if (objEmpleado != null)
                {
                    SessionManager _SessionManager = new SessionManager(Session);                    
                    _SessionManager.UserSessionEmpleado = objEmpleado;
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                    uw.Dispose();
                 
                }
                else
                {                    
                    
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "Swal.fire({  type: 'error',  title: 'Usuario o Contraseña incorrecto!',  showConfirmButton: false,  timer: 1500})", true);
                }


            }



        }


    }
}