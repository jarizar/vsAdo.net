using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(App.UI.WebForm.Startup))]

namespace App.UI.WebForm
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                LoginPath = new PathString("/Login.aspx"),
                ExpireTimeSpan = TimeSpan.FromMinutes(60)
            });
        }
    }
}
