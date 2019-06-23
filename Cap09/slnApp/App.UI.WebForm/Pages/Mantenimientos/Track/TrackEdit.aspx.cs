using App.Data.Repository;
using App.Data.Repository.Interface;
using App.UI.WebForm.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETracks=App.Entities.Base;

namespace App.UI.WebForm.Pages.Mantenimientos.Track
{
    public partial class TrackEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitValues();

        }

        private void InitValues() {
            IAppUnitOfWork uw = new AppUnitOfWork();

            var albums = uw.AlbumRepository.GetAll();
            var medio = uw.MediaTypeRepository.GetAll();
            var genero = uw.GenreRepository.GetAll();

            Helpers.configurarcambio(ddlAlbum, "Title", "AlbumId", albums);
            Helpers.configurarcambio(ddlMedio, "Name", "MediaTypeId", medio);
            Helpers.configurarcambio(ddlGenero, "Name", "GenreId", genero);

            uw.Dispose();
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar() {

            var entity = new ETracks.Track();

            entity.Name = txtNombre.Text;
            entity.AlbumId = Convert.ToInt32(ddlAlbum.SelectedValue);
            entity.MediaTypeId = Convert.ToInt32(ddlMedio.SelectedValue);
            entity.GenreId = Convert.ToInt32(ddlGenero.SelectedValue);
            entity.Composer = txtcompositor.Text;
            entity.Milliseconds = Convert.ToInt32(txtDuracion.Text);
            entity.Bytes = Convert.ToInt32(txtPeso.Text);
            entity.UnitPrice = Convert.ToInt32(txtPrecio.Text);

            IAppUnitOfWork uw = new AppUnitOfWork();
            uw.TrackRepository.Add(entity);
            uw.Complete();
            uw.Dispose();

        }
    }
}