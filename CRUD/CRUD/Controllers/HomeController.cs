using App.Data.DataAccess;
using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {       
       

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTipoComprobante() {

            using (IAppUnitOfWork uw = new AppUnitOfWork())
            {

                var list = uw.Tipo_ComprobanteRepository.All().OrderBy(x => x.Descripcion);
                var result = list.Select(x => new Select2
                {
                    id = x.Id_TipoComprobante,
                    descripcion = x.Descripcion
                });

                uw.Dispose();

                return Json(new { Data = result },JsonRequestBehavior.AllowGet);
            }

            
        }

    }
}