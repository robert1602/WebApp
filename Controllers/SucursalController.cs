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
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidSucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     direccion = sucursal.DIRECCION,
                                     email = sucursal.EMAIL,
                                     //fechaApertura = sucursal.FECHAAPERTURA
                                 }).ToList();
            }

            return View(ListaSucursal);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursalCLS);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Sucursal oSucursal = new Sucursal();                    
                    oSucursal.NOMBRE = oSucursalCLS.nombre ;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaApertura;
                    oSucursal.BHABILITADO = 1;
                    bd.Sucursal.Add(oSucursal);
                    bd.SaveChanges();
                }
            }

            return RedirectToAction("index");

        }

        public ActionResult Editar(int id)
        {
            SucursalCLS oSucursalCLS = new SucursalCLS();
            using (var db = new BDPasajeEntities())
            {
                Sucursal oSucursal = db.Sucursal.Where(p => p.IIDSUCURSAL.Equals(id)).First();
                oSucursalCLS.iidSucursal = oSucursal.IIDSUCURSAL;
                oSucursalCLS.nombre = oSucursal.NOMBRE;
                oSucursalCLS.direccion = oSucursal.DIRECCION;
                oSucursalCLS.telefono = oSucursal.TELEFONO;
                oSucursalCLS.email = oSucursal.EMAIL;
                oSucursalCLS.fechaApertura =(DateTime) oSucursal.FECHAAPERTURA;

            }
            return View(oSucursalCLS);
        }


   }
}
