using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> ListaCliente = null;
            using (var db = new BDPasajeEntities())
            {
                ListaCliente = (from cliente in db.Cliente
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    apPaterno = cliente.APPATERNO,
                                    apMaterno = cliente.APMATERNO,
                                    telefonoFijo = cliente.TELEFONOFIJO
                                }).ToList();
                return View(ListaCliente);
            }
        }
    }
}