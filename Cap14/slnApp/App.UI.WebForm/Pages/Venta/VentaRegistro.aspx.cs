using App.Data.Repository;
using App.Data.Repository.Interface;
using App.UI.WebForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Pages.Venta
{
    public partial class VentaRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                LoadInit();
            }
        }


        private void LoadInit()
        {
            IAppUnitOfWork uw = new AppUnitOfWork();

            Helpers.ConfigurarCombo(ddlTrack, "Name", "TrackId", uw.TrackRepository.GetAll());
            uw.Dispose();

        }

    }
}