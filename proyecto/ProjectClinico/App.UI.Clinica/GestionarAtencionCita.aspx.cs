using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.Clinica
{
    public partial class GestionarAtencionCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdCita = int.Parse(Request.QueryString["idcita"]);

                LlenarDatosPaciente(IdCita);
            }
        }

        private void LlenarDatosPaciente(int IdCita)
        {
            // llenar la informacion
            
            IAppUnitOfWork uw = new AppUnitOfWork();
            PacienteQuery objPaciente = uw.CitaRepository.BuscarPacienteIdCita(IdCita);
            hfIdPaciente.Value = objPaciente.idPaciente.ToString();
            lblNombres.Text = objPaciente.nombres;
            lblApellidos.Text = objPaciente.apPaterno + " " + objPaciente.apMaterno;
            lblEdad.Text = objPaciente.edad.ToString();
            var sex = Convert.ToChar(objPaciente.sexo);
            lblSexo.Text = (sex=='F') ? "Femenino" : "Masculino";
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            DiagnosticoQuery objDiagnostico = new DiagnosticoQuery();
            objDiagnostico.idPaciente = Convert.ToInt32(hfIdPaciente.Value);
            objDiagnostico.observacion = txtObservaciones.Text;

            IAppUnitOfWork uw = new AppUnitOfWork();

            bool ok = uw.DiagnosticoRepository.RegistrarDiagnostico(objDiagnostico);

            if (ok)
            {
                Response.Write("<script>alert('Diagnóstico registrado correctamente.')</script>");
                //Response.Redirect("PanelGeneral.aspx");
                btnRegistrar.Enabled = false;
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el diagnóstico.')</script>");
            }
        }
    }
}