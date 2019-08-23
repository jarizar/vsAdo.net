using MD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MD_MVC.Controllers
{
    public class HomeController : Controller
    {
         Modelos.MD_MVCEntities contexto = null;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        private void P_Excepcion(object sender, RepositorioGenerico.ExceptionEvenArgs e)
        {
            if (e.EntityValidationErrors != null)
            {
                throw new DbEntityValidationException(e.Message, e.EntityValidationErrors, e.InnerException) { };

            }
            else
                throw new Exception(e.Message, e.InnerException) { Source = e.Source };
        }

        private string Select2(List<GrupoSelect2> grupos)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{'results':[");

            foreach (var grupo in grupos)
            {
                sb.Append("{" + string.Format("'text':'{0}',", grupo.text));
                sb.Append("'children':[");
                foreach (var child in grupo.children)
                    sb.Append("{" + string.Format("'id':'{0}', 'text':'{1}',", child.id, child.text) + "},");
                sb.Append("]},");
            }

            sb.Append("]}");

            return sb.ToString();
        }

        private string Select2(List<Select2> datos)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach (var item in datos)
                sb.Append("{" + string.Format("id:'{0}', text:'{1}'", item.id, item.text) + "},");
            sb.Append("]");

            return sb.ToString();
        }

        [ChildActionOnly]
        public string PersonasSelect2()
        {
            List<GrupoSelect2> grupoSelect2 = new List<GrupoSelect2>();
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.v_Persona> p =
                new RepositorioGenerico.Repositorio<Modelos.v_Persona>(contexto))
            {
                p.Excepcion += P_Excepcion; ; ;
                var grupos = p.All().GroupBy(x => x.Tipo_Persona);
                foreach (var grupo in grupos)
                {
                    var grupoOrganizado = grupo.OrderBy(x => x.Nombre_Completo).ToList();
                    List<children> hijos = new List<children>();
                    foreach (var g in grupoOrganizado)
                        hijos.Add(new children() { id = g.Id, text = g.Nombre_Completo });

                    grupoSelect2.Add(new GrupoSelect2() { text = grupo.Key, children = hijos });
                }
            }
            return Select2(grupoSelect2);
        }

        [ChildActionOnly]
        public string ProductosSelect2Descripcion()
        {
            List<GrupoSelect2> grupoSelect2 = new List<GrupoSelect2>();
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.v_Producto> p =
                new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
            {
                p.Excepcion += P_Excepcion;

                var grupos = p.All().GroupBy(x => x.Tipo_Descripcion);
                foreach (var grupo in grupos)
                {
                    var grupoOrganizado = grupo.OrderBy(x => x.Descripcion).ToList();
                    List<children> hijos = new List<children>();
                    foreach (var g in grupoOrganizado)
                        hijos.Add(new children() { id = g.Id, text = g.Descripcion });

                    grupoSelect2.Add(new GrupoSelect2() { text = grupo.Key, children = hijos });
                }
            }
            return Select2(grupoSelect2);
        }

        [ChildActionOnly]
        public string ProductosSelect2Codigo()
        {
            List<GrupoSelect2> grupoSelect2 = new List<GrupoSelect2>();
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.v_Producto> p = new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
            {
                p.Excepcion += P_Excepcion;

                var grupos = p.All().GroupBy(x => x.Tipo_Descripcion);
                foreach (var grupo in grupos)
                {
                    List<children> hijos = new List<children>();
                    foreach (var g in grupo)
                        hijos.Add(new children() { id = g.Id, text = g.Codigo });

                    grupoSelect2.Add(new GrupoSelect2() { text = grupo.Key, children = hijos });
                }
            }
            return Select2(grupoSelect2);
        }

        [ChildActionOnly]
        public string TiposDeOrden()
        {
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.Orden_Tipo> p = new RepositorioGenerico.Repositorio<Modelos.Orden_Tipo>(contexto))
            {
                p.Excepcion += P_Excepcion;
                var datos = p.All().OrderBy(x => x.Descripcion);
                List<Select2> list = new List<Select2>();
                foreach (var item in datos)
                    list.Add(new Select2() { id = item.Id, text = item.Descripcion });
                return Select2(list);
            }
        }

        [ChildActionOnly]
        public string Condiciones()
        {
            contexto = new Modelos.MD_MVCEntities();
            using (RepositorioGenerico.Repositorio<Modelos.Condiciones> p = new RepositorioGenerico.Repositorio<Modelos.Condiciones>(contexto))
            {
                p.Excepcion += P_Excepcion;
                var datos = p.All().OrderBy(x => x.Descripcion);
                List<Select2> list = new List<Select2>();
                foreach (var item in datos)
                    list.Add(new Select2() { id = item.Id, text = item.Descripcion });
                return Select2(list);
            }
        }


    }
}