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
            throw new DbEntityValidationException(e.Message, e.EntityValidationErrors, e.InnerException) { };
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
            p.Excepcion += P_Excepcion; ;
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

    public ActionResult GuardarPersona(
        string documento, string nombres, string apellidos, byte tipo, int Estatus)
    {
        contexto = new Modelos.MD_MVCEntities();
        bool resultado = false;
        using (RepositorioGenerico.Repositorio<Modelos.Persona> p = new RepositorioGenerico.Repositorio<Modelos.Persona>(contexto))
        {
            p.Excepcion += P_Excepcion;
            p.Create(new Modelos.Persona() { Documento = documento, Nombres = nombres, Apellidos = apellidos, Id_Tipo_Persona = tipo, Id_Estatus = Estatus, Balance = 0, Limite_Credito = 0 });
            resultado = true;
        }
        return Json(new { resultado });
    }

    public ActionResult DatosDePersona(int? id)
    {
        contexto = new Modelos.MD_MVCEntities();
        object persona = null;
        using (RepositorioGenerico.Repositorio<Modelos.v_Persona> p =
            new RepositorioGenerico.Repositorio<Modelos.v_Persona>(contexto))
        {
            persona = p.Retrieve(x => x.Id == id);
        }

        return Json(new { persona });
    }

    public ActionResult GuardarTipoDeOrden(string descripcion)
    {
        contexto = new Modelos.MD_MVCEntities();
        bool resultado = false;
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Tipo> p =
            new RepositorioGenerico.Repositorio<Modelos.Orden_Tipo>(contexto))
        {
            p.Excepcion += P_Excepcion;
            p.Create(new Modelos.Orden_Tipo() { Descripcion = descripcion, Secuencia = "" });
            resultado = true;
        }
        return Json(new { resultado });
    }

    public ActionResult ActualizarTipoDeOrden(int id, string PropertyName, string value)
    {
        bool status = false; string mensaje = "Valor no establecido";

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Tipo> obj = new RepositorioGenerico.Repositorio<Modelos.Orden_Tipo>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            obj.Update(x => x.Id == id, PropertyName, value);
        }

        status = true;
        mensaje = "Valor establecido";

        return Json(new { value, status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GuardarCondicion(string descripcion)
    {
        contexto = new Modelos.MD_MVCEntities();
        bool resultado = false;
        using (RepositorioGenerico.Repositorio<Modelos.Condiciones> p =
            new RepositorioGenerico.Repositorio<Modelos.Condiciones>(contexto))
        {
            p.Excepcion += P_Excepcion;
            p.Create(new Modelos.Condiciones { Descripcion = descripcion });
            resultado = true;
        }
        return Json(new { resultado });
    }

    public ActionResult ActualizarCondiciones(int id, string PropertyName, string value)
    {
        bool status = false; string mensaje = "Valor no establecido";

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Condiciones> obj =
            new RepositorioGenerico.Repositorio<Modelos.Condiciones>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            obj.Update(x => x.Id == id, PropertyName, value);
        }

        status = true;
        mensaje = "Valor establecido";

        return Json(new { value, status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GuardarProducto(
        byte tipo, string codigo, string descripcion, string precio, string cantidad,
        string costo, byte tasa)
    {
        contexto = new Modelos.MD_MVCEntities();
        bool resultado = false;
        using (RepositorioGenerico.Repositorio<Modelos.Producto> p =
            new RepositorioGenerico.Repositorio<Modelos.Producto>(contexto))
        {
            p.Excepcion += P_Excepcion;
            p.Create(new Modelos.Producto() { Id_Tipo = tipo, Codigo = codigo, Descripcion = descripcion, Precio = decimal.Parse(precio), Cantidad = decimal.Parse(cantidad), Costo = decimal.Parse(costo), Id_Impuesto = tasa, Id_Estatus = 1 });
            resultado = true;
        }
        return Json(new { resultado });
    }

    public ActionResult ActualizarProducto(int id, string PropertyName, string value)
    {
        bool status = false; string mensaje = "Valor no establecido";

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Producto> obj =
            new RepositorioGenerico.Repositorio<Modelos.Producto>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            switch (PropertyName)
            {
                case "Cantidad":
                case "Precio":
                    obj.Update(x => x.Id == id, PropertyName, decimal.Parse(value));
                    break;
                case "Id_Impuesto":
                case "Id_Tipo":
                    obj.Update(x => x.Id == id, PropertyName, byte.Parse(value));
                    break;
                default:
                    obj.Update(x => x.Id == id, PropertyName, value);
                    break;
            }
        }
        //Establecemos el valor a su descripcion de tipo
        contexto = new Modelos.MD_MVCEntities();
        switch (PropertyName)//Para establecer el valor enviado a editar
        {
            case "Id_Impuesto":
                using (RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto> tipo = new RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = string.Format("{0:N2}", tipo.Retrieve(x => x.Id == idValor).Tasa);
                }
                break;
            case "Id_Tipo":
                using (RepositorioGenerico.Repositorio<Modelos.Producto_Tipo> tipo = new RepositorioGenerico.Repositorio<Modelos.Producto_Tipo>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
        }

        status = true;
        mensaje = "Valor establecido";

        return Json(new { value, status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult DatosDeProducto(int? id)
    {
        contexto = new Modelos.MD_MVCEntities();
        object producto = null;
        using (RepositorioGenerico.Repositorio<Modelos.v_Producto> p =
            new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
        {
            producto = p.Retrieve(x => x.Id == id);
        }
        return Json(new { producto });
    }

    public ActionResult GuardarOrden()
    {
        //Prepramos la respuesta
        string mensaje = "Error al insertar registro";
        bool status = false;
        int idOrden = 0;

        //Consultamos la colección Form que contiene los datos de la factura actual
        var idPersona = Request.Form["persona"];
        var tipo = Request.Form["tipo_de_orden"];
        var fecha = Request.Form["fecha"];
        var subTotal = Request.Form["subTotal"];
        var impuestos = Request.Form["impuestos"];
        var total = Request.Form["total"];
        var comentarios = Request.Form["comentarios"];
        var Condiciones = Request.Form["Condiciones"];

        Modelos.Orden orden = new Modelos.Orden() { Id_Persona = int.Parse(idPersona), Descuento = 0, Id_Condiciones = byte.Parse(Condiciones), Id_Estatus = 1, Id_Tipo = int.Parse(tipo), Impuestos = decimal.Parse(impuestos), Recargo = 0, IdEditable = "", SecuenciaEditable = "", Secuencia_Gobierno = "", Subtotal = decimal.Parse(subTotal), Total = decimal.Parse(total), Comentario = comentarios, Fecha = DateTime.Parse(fecha) };
        orden.Orden_Detalle = new List<Modelos.Orden_Detalle>();

        #region Detalles de la factura
        for (int i = 0; i < Request.Form.AllKeys.Length; i++)
        {
            var id = Request.Form["Detalles[" + i + "][id]"];
            if (id != null)
            {
                var codigo = Request.Form["Detalles[" + i + "][Código]"];
                contexto = new Modelos.MD_MVCEntities();
                Modelos.v_Producto producto = null;
                using (RepositorioGenerico.Repositorio<Modelos.v_Producto> p = new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
                {
                    producto = p.Retrieve(x => x.Codigo == codigo);
                }
                var descripcion = Request.Form["Detalles[" + i + "][Descripción]"];
                var cantidad = Request.Form["Detalles[" + i + "][Cantidad]"];
                var precio = Request.Form["Detalles[" + i + "][Precio]"];
                var impuesto = Request.Form["Detalles[" + i + "][Impuesto]"];
                var monto = Request.Form["Detalles[" + i + "][Monto]"];
                orden.Orden_Detalle.Add(new Modelos.Orden_Detalle() { Cantidad = decimal.Parse(cantidad), Descripcion = descripcion, Impuesto = decimal.Parse(impuesto), Monto = decimal.Parse(monto), Precio = decimal.Parse(precio), Id_Producto = producto.Id });
            }
        }
        #endregion

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden> ord =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            idOrden = ord.Create(orden).Id;
            status = true;
            mensaje = "Registro creado correctamente!";
        }

        return Json(new { mensaje, status, idOrden }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult ActualizarOrden(int id, string PropertyName, string value)
    {
        bool status = false; string mensaje = "Valor no establecido";

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden> obj =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            switch (PropertyName)
            {
                case "Fecha":
                    obj.Update(x => x.Id == id, PropertyName, DateTime.Parse(value));
                    break;
                case "Id_Condiciones":
                    obj.Update(x => x.Id == id, PropertyName, byte.Parse(value));
                    break;
                case "Id_Estatus":
                    obj.Update(x => x.Id == id, PropertyName, int.Parse(value));
                    break;
                default:
                    obj.Update(x => x.Id == id, PropertyName, int.Parse(value));
                    break;
            }
        }
        //Establecemos el valor a su descripcion de tipo
        contexto = new Modelos.MD_MVCEntities();
        switch (PropertyName)
        {
            case "Id_Tipo":
                using (RepositorioGenerico.Repositorio<Modelos.Orden_Tipo> tipo = new RepositorioGenerico.Repositorio<Modelos.Orden_Tipo>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
            case "Id_Condiciones":
                using (RepositorioGenerico.Repositorio<Modelos.Condiciones> tipo = new RepositorioGenerico.Repositorio<Modelos.Condiciones>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
            case "Id_Estatus":
                using (RepositorioGenerico.Repositorio<Modelos.Estatus> tipo = new RepositorioGenerico.Repositorio<Modelos.Estatus>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
        }

        status = true;
        mensaje = "Valor establecido";

        return Json(new { value, status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult ConsultarUltimoRegistro()
    {
        contexto = new Modelos.MD_MVCEntities();
        Modelos.Orden encabezado = null;
        List<Modelos.Orden_Detalle> detalles = null;
        bool status = false;
        using (RepositorioGenerico.Repositorio<Modelos.Orden> orden = new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            encabezado = orden.All().LastOrDefault();
        }
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Detalle> orden = new RepositorioGenerico.Repositorio<Modelos.Orden_Detalle>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            detalles = orden.Filter(x => x.Id_Orden == encabezado.Id);
            status = true;
        }
        return Json(new { status, encabezado, detalles }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult ConsultarOrden(int Id)
    {
        contexto = new Modelos.MD_MVCEntities();
        Modelos.Orden encabezado = null;
        List<Modelos.Orden_Detalle> detalles = null;
        bool status = false;
        using (RepositorioGenerico.Repositorio<Modelos.Orden> orden =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            encabezado = orden.Retrieve(x => x.Id == Id);
        }
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Detalle> orden =
            new RepositorioGenerico.Repositorio<Modelos.Orden_Detalle>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            detalles = orden.Filter(x => x.Id_Orden == encabezado.Id);
            status = true;
        }
        return Json(new { status, encabezado, detalles }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult ConsultarPrimerRegistro()
    {
        contexto = new Modelos.MD_MVCEntities();
        Modelos.Orden encabezado = null;
        List<Modelos.Orden_Detalle> detalles = null;
        bool status = false;
        using (RepositorioGenerico.Repositorio<Modelos.Orden> orden =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            encabezado = orden.All().FirstOrDefault();
        }
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Detalle> orden =
            new RepositorioGenerico.Repositorio<Modelos.Orden_Detalle>(contexto))
        {
            orden.Excepcion += P_Excepcion;
            detalles = orden.Filter(x => x.Id_Orden == encabezado.Id);
            status = true;
        }
        return Json(new { status, encabezado, detalles }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult CancelarOrden(int idOrden)
    {
        string mensaje = "Error al cancelar registro";
        bool status = false;

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden> ord =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            ord.Update(x => x.Id == idOrden, "Subtotal", 0m);
            ord.Update(x => x.Id == idOrden, "Impuestos", 0m);
            ord.Update(x => x.Id == idOrden, "Total", 0m);
            ord.Update(x => x.Id == idOrden, "Id_Estatus", 5);
            status = true;
            mensaje = "Registro cancelado correctamente!";
        }
        return Json(new { status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult EliminarOrden(int idOrden)
    {
        string mensaje = "Error al eliminar registro";
        bool status = false;

        //Eliminamos los detalles 
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Detalle> ord =
            new RepositorioGenerico.Repositorio<Modelos.Orden_Detalle>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var detalles = ord.Filter(x => x.Id_Orden == idOrden);
            foreach (var detalle in detalles)
                ord.Delete(detalle);
        }
        //Eliminamos la orden
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden> ord =
            new RepositorioGenerico.Repositorio<Modelos.Orden>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            ord.Delete(ord.Retrieve(x => x.Id == idOrden));
            status = true;
            mensaje = "Registro eliminado correctamente!";
        }
        return Json(new { status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    [ChildActionOnly]
    public string TipoDeProducto()
    {
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Producto_Tipo> p =
            new RepositorioGenerico.Repositorio<Modelos.Producto_Tipo>(contexto))
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
    public string TipoDeImpuesto()
    {
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto> p =
            new RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto>(contexto))
        {
            p.Excepcion += P_Excepcion;
            var datos = p.All().OrderBy(x => x.Tasa);
            List<Select2> list = new List<Select2>();
            foreach (var item in datos)
                list.Add(new Select2() { id = item.Id, text = item.Tasa });
            return Select2(list);
        }
    }

    [ChildActionOnly]
    public string Producto_Tipo_OrdenJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Producto_Tipo> obj =
            new RepositorioGenerico.Repositorio<Modelos.Producto_Tipo>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Descripcion));
        }
        return "{" + sb.ToString() + "}";
    }

    [ChildActionOnly]
    public string Impuestos_OrdenJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto> obj =
            new RepositorioGenerico.Repositorio<Modelos.Tasa_Impuesto>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Tasa));
        }
        return "{" + sb.ToString() + "}";
    }

    [ChildActionOnly]
    public string TipoDePersona()
    {
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Persona_Tipo> p = new RepositorioGenerico.Repositorio<Modelos.Persona_Tipo>(contexto))
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
    public string Estatus()
    {
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Estatus> p = new RepositorioGenerico.Repositorio<Modelos.Estatus>(contexto))
        {
            p.Excepcion += P_Excepcion;
            var datos = p.All().OrderBy(x => x.Descripcion);
            List<Select2> list = new List<Select2>();
            foreach (var item in datos)
                list.Add(new Select2() { id = item.Id, text = item.Descripcion });
            return Select2(list);
        }
    }

    public ActionResult ActualizarPersona(int id, string PropertyName, string value)
    {
        bool status = false; string mensaje = "Valor no establecido";

        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Persona> obj = new RepositorioGenerico.Repositorio<Modelos.Persona>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            switch (PropertyName)
            {
                case "Id_Persona_Tipo":
                    obj.Update(x => x.Id == id, "Id_Tipo_Persona", byte.Parse(value));
                    break;
                case "Id_Estatus":
                    obj.Update(x => x.Id == id, PropertyName, int.Parse(value));
                    break;
                case "Balance":
                    obj.Update(x => x.Id == id, PropertyName, decimal.Parse(value));
                    break;
                default:
                    obj.Update(x => x.Id == id, PropertyName, value);
                    break;
            }
        }
        //Establecemos el valor a su descripcion de tipo
        contexto = new Modelos.MD_MVCEntities();
        switch (PropertyName)//Para establecer el valor enviado a editar
        {
            case "Id_Estatus":
                using (RepositorioGenerico.Repositorio<Modelos.Estatus> tipo = new RepositorioGenerico.Repositorio<Modelos.Estatus>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
            case "Id_Persona_Tipo":
                using (RepositorioGenerico.Repositorio<Modelos.Persona_Tipo> tipo = new RepositorioGenerico.Repositorio<Modelos.Persona_Tipo>(contexto))
                {
                    int idValor = int.Parse(value);
                    value = tipo.Retrieve(x => x.Id == idValor).Descripcion;
                }
                break;
        }

        status = true;
        mensaje = "Valor establecido";

        return Json(new { value, status, mensaje }, JsonRequestBehavior.AllowGet);
    }

    [ChildActionOnly]
    public string Tipos_PersonaJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Persona_Tipo> obj = new RepositorioGenerico.Repositorio<Modelos.Persona_Tipo>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Descripcion));
        }
        return "{" + sb.ToString() + "}";
    }

    [ChildActionOnly]
    public string EstatusJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Estatus> obj = new RepositorioGenerico.Repositorio<Modelos.Estatus>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Descripcion));
        }
        return "{" + sb.ToString() + "}";
    }

    [ChildActionOnly]
    public string Tipos_OrdenJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Orden_Tipo> obj =
            new RepositorioGenerico.Repositorio<Modelos.Orden_Tipo>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Descripcion));
        }
        return "{" + sb.ToString() + "}";
    }

    [ChildActionOnly]
    public string CondicionesJSON()
    {
        StringBuilder sb = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.Condiciones> obj =
            new RepositorioGenerico.Repositorio<Modelos.Condiciones>(contexto))
        {
            obj.Excepcion += P_Excepcion;
            var datos = obj.Filter(x => true);
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.Id, item.Descripcion));
        }
        return "{" + sb.ToString() + "}";
    }

    #region Uso de google chart
    [ChildActionOnly]
    public string TiposDePersonasRegistradas()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Persona> ord =
            new RepositorioGenerico.Repositorio<Modelos.v_Persona>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Tipo_Persona).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Tipo_Persona.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }

    [ChildActionOnly]
    public string EstatusDePersonas()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Persona> ord = new RepositorioGenerico.Repositorio<Modelos.v_Persona>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Estatus_Descripcion).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Estatus_Descripcion.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }

    [ChildActionOnly]
    public string TiposDeProductos()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Producto> ord = new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Tipo_Descripcion).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Tipo_Descripcion.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }

    [ChildActionOnly]
    public string ImpuestosDeProductos()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Producto> ord = new RepositorioGenerico.Repositorio<Modelos.v_Producto>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Descripcion_Impuesto).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Descripcion_Impuesto.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }

    [ChildActionOnly]
    public string OrdenesPorTipo()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Orden> ord = new RepositorioGenerico.Repositorio<Modelos.v_Orden>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Tipo_de_orden_descripcion).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Tipo_de_orden_descripcion.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }

    [ChildActionOnly]
    public string CondicionesDeOrdenes()
    {
        StringBuilder Resultado = new StringBuilder();
        contexto = new Modelos.MD_MVCEntities();
        using (RepositorioGenerico.Repositorio<Modelos.v_Orden> ord = new RepositorioGenerico.Repositorio<Modelos.v_Orden>(contexto))
        {
            ord.Excepcion += P_Excepcion;
            var datos = ord.Filter(x => true);
            var grupos = datos.GroupBy(x => x.Condiciones_Descripcion).ToList();
            Resultado.Append(string.Format("['{0}', '{1}'],", "Tipo", "Cantidad"));
            foreach (var grupo in grupos)
                Resultado.Append(string.Format("['{0}', {1}],",
                    grupo.FirstOrDefault().Condiciones_Descripcion.Trim(), grupo.Count()));
        }
        return "[" + Resultado.ToString() + "]";
    }
    #endregion
}
}