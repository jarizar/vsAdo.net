using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class GestionarHorarioAtencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static MedicoQuery BuscarMedico(String dni)
        {
            IAppUnitOfWork uw = new AppUnitOfWork();
            return uw.MedicoRepository.BuscarMedicoDni(dni);
            
        }




        [WebMethod]
        public static List<HorarioAtencionQuery> AgregarHorario(String fecha, String hora, String idmedico)
        {
            
           var Fecha = Convert.ToDateTime(fecha);           
            int idMedico = Convert.ToInt32(idmedico);
            IAppUnitOfWork uw = new AppUnitOfWork();            

            return uw.HorarioAtencionRepository.AgregarHorario(idMedico,hora,Fecha);            


        }

        [WebMethod]
        public static List<HorarioAtencionQuery> ListarHorariosAtencion(String idmedico)
        {
            Int32 idMedico = Convert.ToInt32(idmedico);

            IAppUnitOfWork uw = new AppUnitOfWork();
            return uw.HorarioAtencionRepository.ListarHorariosAtencion(idmedico);
        }

        [WebMethod]
        public static bool EliminarHorarioAtencion(String id)
        {
            var dato = true;
            return dato;
        }

        [WebMethod]
        public static bool ActualizarHorarioAtencion(String idmedico, String idhorario, String fecha, String hora)
        {
            var dato = true;
            return dato;

        }

    }
}