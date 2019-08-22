using App.Data.Repository;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar() {


            var uw = new AppUnitOfWork();
            //Obteniendo la información del usuario por el login y password
            var usuarioEncontrado = uw.UsuarioRepository.GetAll(item => item.Login == txtUsuario.Text.Trim()
            && item.Password == txtPassword.Text.Trim()).FirstOrDefault();
                        
            
            if (usuarioEncontrado!=null)
            {
                // build a list of claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, $"{usuarioEncontrado.Nombres}{usuarioEncontrado.Apellidos}"));
                claims.Add(new Claim(ClaimTypes.NameIdentifier,usuarioEncontrado.UsuarioID.ToString()));
               
                    foreach (var role in usuarioEncontrado.Roles.Split(';'))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));

                    }
                

                // create the identity
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

                Context.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = true
                },
                identity);

                Response.Redirect("~/");
            }
            else
            {
                //FailureText.Text = "The credentials are not valid!";
            }
        }



    }
}