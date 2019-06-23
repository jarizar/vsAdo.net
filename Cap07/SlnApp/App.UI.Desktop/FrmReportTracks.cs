
using App.Data.DataAccess;
using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class frmReportTracks : Form
    {
        public frmReportTracks()
        {
            InitializeComponent();
            Inicializarvalores();
            InicializarvaloresMediaType();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        #region "Procedimientos propios"        
        private void Buscar()
        {
            IAppUnitOfWork uw = new AppUnitOfWork();

            var listado = uw.TrackRepository.ReporteTracks(txtNombre.Text.Trim());
            //Libera los recursos
            uw.Dispose();

            gvListado.DataSource = listado;
            gvListado.Refresh();
        }
        #endregion


        private void Inicializarvalores()
        {
            //Obtener información de géneros
            IAppUnitOfWork uw = new AppUnitOfWork();

            var genrelistado = uw.GenreRepository.GetAll().ToList();
           
            genrelistado.Insert(0, new Genre()
            {
                GenreId = 0,
                Name = "Todos"
            });

            //Libera los recursos
            uw.Dispose();
            cboGeneros.DataSource = genrelistado;
            cboGeneros.Refresh(); 
        }

        private void InicializarvaloresMediaType()
        {
            //Obtener información de géneros

            IAppUnitOfWork uw = new AppUnitOfWork();

            var medialistado = uw.MediaTypeRepository.GetAll().ToList();        
            medialistado.Insert(0, new MediaType()
            {
                MediaTypeId = 0,
                Name = "Todos"
            });
            //Libera los recursos
            uw.Dispose(); 

            cboFormato.DataSource = medialistado;
            cboFormato.Refresh();
        }



    }
}
