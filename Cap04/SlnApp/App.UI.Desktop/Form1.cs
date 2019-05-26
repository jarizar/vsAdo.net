
using App.Data.DataAccess;
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
    public partial class frmTracks : Form
    {
        public frmTracks()
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
            var trackDA = new TackDA();
            var listado = trackDA.ConsultarTracksQ(
                txtNombre.Text.Trim(),(int) cboGeneros.SelectedValue, (int)cboFormato.SelectedValue
                );
            gvListado.DataSource = listado;
            gvListado.Refresh();
        }
        #endregion


        private void Inicializarvalores()
        {
            //Obtener información de géneros
            var genreDA = new GenreDA();
            var genrelistado = genreDA.GetAll().ToList();
            genrelistado.Insert(0, new Genre()
            {
                GenreId = 0,
                Name = "Todos"
            });
            cboGeneros.DataSource = genrelistado;
            cboGeneros.Refresh(); 
        }

        private void InicializarvaloresMediaType()
        {
            //Obtener información de géneros
            var mediatypeDA = new MediaTypeDA();
            var medialistado = mediatypeDA.GetAll().ToList();
            medialistado.Insert(0, new MediaType()
            {
                MediaTypeId = 0,
                Name = "Todos"
            });
            cboFormato.DataSource = medialistado;
            cboFormato.Refresh();
        }



    }
}
