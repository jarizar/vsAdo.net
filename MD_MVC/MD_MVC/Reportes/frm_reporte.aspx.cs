using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;

namespace MD_MVC.Reportes
{
    public partial class frm_reporte : System.Web.UI.Page
    {
        Modelos.MD_MVCEntities contexto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request.QueryString["id"]);
            var tipo = byte.Parse(Request.QueryString["tipo"]);
            if (!IsPostBack)
            {
                //Es la primera ejecución
                ImprimirOrden(id, tipo);
            }
        }

        private void ImprimirOrden(int id, byte tipo)
        {
            List<Modelos.v_Orden_Completa> OrdenCompleta = null;
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.v_Orden_Completa> 
                ord = new RepositorioGenerico.Repositorio<Modelos.v_Orden_Completa>(contexto))
            {
                OrdenCompleta = ord.Filter(x => x.Orden_Id == id);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new 
                    ReportDataSource("v_Orden_Completa", OrdenCompleta));

                switch (tipo)
                {
                    case 1:
                        ReportViewer1.LocalReport.ReportPath = "Reportes/rpt_orden_carta.rdlc";
                        break;
                    case 2:
                        ReportViewer1.LocalReport.ReportPath = "Reportes/rpt_orden_media_carta.rdlc";
                        break;
                    case 3:
                        ReportViewer1.LocalReport.ReportPath = "Reportes/rpt_orden_pos.rdlc";
                        break;
                    default:
                        ReportViewer1.LocalReport.ReportPath = "Reportes/rpt_orden_carta.rdlc";
                        break;
                }

                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}