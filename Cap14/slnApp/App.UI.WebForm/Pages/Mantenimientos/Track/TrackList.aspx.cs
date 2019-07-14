using App.Data.Repository;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Pages.Mantenimientos.Track
{
    public partial class TrackList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            string filterByName =  $"%{txtFiltroPorNombre.Text.Trim()}%";

            IAppUnitOfWork uw = new AppUnitOfWork();
            var data = uw.TrackRepository.ReporteTracks(filterByName);

            //Asignando la información al control DataGrid
            grvListado.DataSource = data;
            grvListado.DataBind();

            //Liberando la conexión a la base de datos
            uw.Dispose();

        }
    }
}