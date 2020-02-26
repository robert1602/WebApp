using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> ListViaje = null;

            using (var db = new BDPasajeEntities())
            {

                ListViaje = (from viaje in db.Viaje
                             join lugarOrigen in db.Lugar
                             on viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR
                             join lugarDestino in db.Lugar 
                             on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                             join bus in db.Bus
                             on viaje.IIDBUS equals bus.IIDBUS
                             select new ViajeCLS
                             {

                                 Iidviaje = viaje.IIDVIAJE,
                                 nombreBus = bus.PLACA,
                                 nombreLugarOrigen = lugarOrigen.NOMBRE,
                                 nombreLugarDestino = lugarDestino.NOMBRE
                             }).ToList();
            }
            return View(ListViaje);
        }
    }
}