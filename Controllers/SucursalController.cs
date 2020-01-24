using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
    
        public ActionResult Index()
        {
            List<SucursalCLS> ListaSucursal = null;
            using (var db = new BDPasajeEntities())
            {
                ListaSucursal = (from sucursal in db.Sucursal
                                 where sucursal.BHABILITADO==1
                                 select new SucursalCLS
                                 {
                                     iidSucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     direccion = sucursal.DIRECCION,
                                     email = sucursal.EMAIL
                                 }).ToList();
            }

            return View(ListaSucursal);
        }
    }
}