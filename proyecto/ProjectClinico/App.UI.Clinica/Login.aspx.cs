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
                }
                else
                {
                    Response.Write("<script>alert('Usuario o Contraseña incorrecto!')</script>");
                    ////Response.Write("<script>(function(){ swal({title: 'Boton 2!', text: 'Esta es la opcion 2', type: 'warning', showConfirmButton: false, timer: 1000})  })();     </script> ");

                    //ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "alerta();", true);
                }


            }



        }


    }
}