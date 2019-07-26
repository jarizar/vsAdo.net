using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class GestionarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = null;
            try
            {              

                IAppUnitOfWork uw = new AppUnitOfWork();
                Lista = uw.PacienteRepository.ListarPacientes();
                uw.Dispose();

            }
            catch (Exception ex)
            {
                Lista = new List<Paciente>();
            }
            return Lista;
           
        }

        [WebMethod]
        public static bool ActualizarDatosPaciente(String id, String direccion)
        {
            Paciente objPaciente = new Paciente()
            {
                idPaciente = Convert.ToInt32(id),
                direccion = direccion
            };

            IAppUnitOfWork uw = new AppUnitOfWork();

            bool ok = uw.PacienteRepository.ActualizarPaciente(objPaciente);         
            uw.Dispose();
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosPaciente(String id)
        {

            Paciente objPaciente = new Paciente()
            {
                idPaciente = Convert.ToInt32(id),
                estado = false
            };

            IAppUnitOfWork uw = new AppUnitOfWork();
            bool ok = uw.PacienteRepository.EliminarPaciente(objPaciente);
         
            uw.Dispose();

            return ok;

            
        }


        private Paciente GetEntity()
        {
            var sexo=(ddlSexo.SelectedValue == "Femenino") ? 'F' : 'M'; // Masculino , Femenino

            Paciente objPaciente = new Paciente();

            if (txtNroDocumento.Text != "" && txtEdad.Text != null)
            {
               
                objPaciente.idPaciente = 0;
                objPaciente.nombres = txtNombres.Text;
                objPaciente.apPaterno = txtApPaterno.Text;
                objPaciente.apMaterno = txtApMaterno.Text;
                objPaciente.edad = Convert.ToInt32(txtEdad.Text);
                objPaciente.sexo = sexo.ToString();
                objPaciente.nroDocumento = txtNroDocumento.Text;
                objPaciente.direccion = txtDireccion.Text;
                objPaciente.telefono = txtTelefono.Text;
                objPaciente.estado = true;                
            }
            else {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "Swal.fire({ type: 'error',  title: 'Debe completa todos los campos!',  showConfirmButton: false,  timer: 1500})", true);
            }
            return objPaciente;

        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Paciente objPaciente = GetEntity();
            // enviar a la capa de logica de negocio
            if (objPaciente.Equals(null))
            {
                ListarPacientes();
            }
            else
            {
                IAppUnitOfWork uw = new AppUnitOfWork();
                bool response = uw.PacienteRepository.Add(objPaciente);
                uw.Complete();
                uw.Dispose();

                if (response)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "Swal.fire({ type: 'success',  title: 'Se registro correctamente!',  showConfirmButton: false,  timer: 1500})", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "Swal.fire({ type: 'error',  title: 'No se registro correctamente!',  showConfirmButton: false,  timer: 1500})", true);
                }
            }
        }

    }
}