using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace App.UI.WebForm
{
    public class Global : HttpApplication
    {
        private ILog _logger = LogManager.GetLogger(typeof(Global));

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Aplicando la configuración para el componente log4net
            //establecido en el archivo webconfig
            log4net.Config.XmlConfigurator.Configure();
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            _logger.Error(ex);
        }
    }
}