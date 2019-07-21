﻿using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using App.UI.Clinica.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class GestionarReservaCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarEspecialidades();
            }
        }

        private void LlenarEspecialidades()
        {
           
                IAppUnitOfWork uw = new AppUnitOfWork();
                var especialidades = uw.EspecialidadRespository.GetAll();
                Helpers.ConfigurarCombo(ddlEspecialidad,"Descripcion", "IdEspecialidad", especialidades);

        }

        [WebMethod]
        public static Paciente BuscarPacienteDNI(string dni)
        {                   
           
            IAppUnitOfWork uw = new AppUnitOfWork();
            return uw.PacienteRepository.BuscarDni(dni);
            
        }

        protected void btnBuscarHorario_Click(object sender, EventArgs e)
        {
            LlenarGridViewHorariosAtencion();
        }

        protected void btnReservarCita_Click(object sender, EventArgs e)
        {
            // ejecutar el guardado de la reserva
            bool isSelected = HorarioAtencionSelccionado();

            if (!idPaciente.Value.Equals(string.Empty) && isSelected)
            {
                Cita objCita = ObtenerCitaSeleccionada();

                IAppUnitOfWork uw = new AppUnitOfWork();
                bool response = uw.CitaRepository.Add(objCita);
                uw.Complete();
                uw.Dispose();

                if (response)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "<script>alert('Cita registrada correctamente.')</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "<script>alert('Error al registrar la cita.')</script>", false);
                }
            }
        }


        private void LlenarGridViewHorariosAtencion()
        {

            if (txtFechaAtencion.Text.Equals(string.Empty))
            {
                Response.Write("<script>alert('No ha ingresado una fecha valida')</script>");
                return;
            }

            // obtenemos fecha
            String fecha = txtFechaAtencion.Text;
            DateTime fechaBusqueda = Convert.ToDateTime(fecha);

            // obtenemos el idEspecialidad
            Int32 idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);


            IAppUnitOfWork uw = new AppUnitOfWork();
            var Lista = uw.HorarioAtencionRepository.ListarHorario(idEspecialidad, fechaBusqueda);
            grdHorariosAtencion.DataSource = Lista;
            grdHorariosAtencion.DataBind();
        }


        private bool HorarioAtencionSelccionado()
        {
            foreach (GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private Cita ObtenerCitaSeleccionada()
        {
            Cita objCita = new Cita();

            foreach (GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    objCita.hora = (row.FindControl("lblHora") as Label).Text;
                    objCita.fechaReserva = DateTime.Now;                  
                    objCita.idPaciente = Convert.ToInt32(idPaciente.Value);

                    string idMedico = (row.FindControl("hfIdMedico") as HiddenField).Value;
                    objCita.idMedico = Convert.ToInt32(idMedico);
                    objCita.estado = "P";

                    break;
                }
            }
            return objCita;
        }
    }
}