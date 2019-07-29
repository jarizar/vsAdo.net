using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static String COMMAND_REGISTER = "Registrar";
        private static String COMMAND_CANCEL = "Cancelar";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                llenarDataList();
                lblFechaAtencion.Text = DateTime.Now.ToShortDateString();
                //var objEmpleado = (CapaEntidades.Empleado)Session["UserSessionEmpleado"];
                //int ind = objEmpleado.ID;
            }
        }


        private void llenarDataList()
        {
            IAppUnitOfWork uw = new AppUnitOfWork();
            List<Cita> ListaCitas = uw.CitaRepository.GetAll();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }


        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            String IdCita = (e.Item.FindControl("hdIdCita") as HiddenField).Value;
            Cita objCita = new Cita();
            objCita.idCita = Convert.ToInt32(IdCita);

            IAppUnitOfWork uw = new AppUnitOfWork();

            if (e.CommandName == COMMAND_REGISTER)
            {
                objCita.estado = "A";
                
                // realizar el registro de la atención
                // Redirección a la página de GestionarAtencionCita.aspx

                bool response = uw.CitaRepository.ActualizarCita(objCita);

                if (response)
                {
                    Response.Redirect("GestionarAtencionCita.aspx?idcita=" + IdCita);
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE REALIZAR LA ATENCIÓN DE LA CITA.')</script>");
                }


            }
            else if (e.CommandName == COMMAND_CANCEL)
            {
                objCita.estado = "E";
                // realizar la cancelación de la reserva de cita
                bool response = uw.CitaRepository.ActualizarCita(objCita);

                if (response)
                {
                    // recargar la información
                    llenarDataList();
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE ELIMINAR LA CITA.')</script>");
                }
            }
        }
    }
}