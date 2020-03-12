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
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    apPaterno = cliente.APPATERNO,
                                    apMaterno = cliente.APMATERNO,
                                    Email = cliente.EMAIL,
                                    Direccion = cliente.DIRECCION,
                                    Iidsexo = cliente.IIDSEXO,
                                    TelefonoFijo = cliente.TELEFONOFIJO,
                                    Telefonocelular = cliente.TELEFONOCELULAR


                                }).ToList();
                return View(ListaCliente);
            }
         
        }

        public ActionResult Agregar()
        {
            SelectSexo();
            ViewBag.lista=listaSexo;

            return View();
        }


        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                SelectSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }           
                using (var db = new BDPasajeEntities())
                {
                    Cliente ocliente = new Cliente();
                    ocliente.NOMBRE = oClienteCLS.nombre;
                    ocliente.APPATERNO = oClienteCLS.apPaterno;
                    ocliente.APMATERNO = oClienteCLS.apMaterno;
                    ocliente.EMAIL = oClienteCLS.Email;
                    ocliente.DIRECCION = oClienteCLS.Direccion;
                    ocliente.IIDSEXO = oClienteCLS.Iidsexo;
                    ocliente.TELEFONOFIJO = oClienteCLS.TelefonoFijo;
                    ocliente.TELEFONOCELULAR = oClienteCLS.Telefonocelular;
                    ocliente.BHABILITADO = 1;
                    db.Cliente.Add(ocliente);
                    db.SaveChanges();

                }            
            return RedirectToAction("Index");
        }


        List<SelectListItem> listaSexo;
        private void SelectSexo()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaSexo = (from Sexo in bd.Sexo
                             where Sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = Sexo.NOMBRE,
                                 Value = Sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }    

       
        public ActionResult Editar(int id)
        {
            ClienteCLS oClienteCLS = new ClienteCLS();
            using (var db = new BDPasajeEntities())
            {

                SelectSexo();
                ViewBag.lista = listaSexo;
                Cliente oCliente = db.Cliente.Where(p => p.IIDCLIENTE.Equals(id)).First();
                oClienteCLS.iidcliente = oCliente.IIDCLIENTE;
                oClienteCLS.nombre = oCliente.NOMBRE;
                oClienteCLS.apPaterno = oCliente.APPATERNO;
                oClienteCLS.apMaterno = oCliente.APMATERNO;
                oClienteCLS.Direccion = oCliente.DIRECCION;
                oClienteCLS.Email = oCliente.EMAIL;
                oClienteCLS.Iidsexo = oCliente.IIDSEXO;
                oClienteCLS.Telefonocelular = oCliente.TELEFONOCELULAR;
                oClienteCLS.TelefonoFijo = oCliente.TELEFONOFIJO;

            }

            return View(oClienteCLS);
        }
    }
}