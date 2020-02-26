using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> ListBus = null;
            using (var db = new BDPasajeEntities())
            {
                ListBus = (from bus in db.Bus
                           join sucursal in db.Sucursal
                           on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                           join tipobus in db.TipoBus
                           on bus.IIDTIPOBUS equals tipobus.IIDTIPOBUS
                           join tipomodelo in db.Modelo
                           on bus.IIDMODELO equals tipomodelo.IIDMODELO
                           where bus.BHABILITADO == 1
                           select new BusCLS
                           {
                               Iidbus = bus.IIDBUS,
                               placa = bus.PLACA,
                               nombreModelo = tipomodelo.NOMBRE,
                               nombreSucursal = sucursal.NOMBRE,
                               nombreTipoBus = tipobus.NOMBRE
                           }).ToList();
            }
            return View(ListBus);
        }
    }
}