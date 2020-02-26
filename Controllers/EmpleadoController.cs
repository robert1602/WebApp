using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> ListEmployee = null;
            using (var bd = new BDPasajeEntities())
            {
                ListEmployee = (from empl in bd.Empleado
                                join tipoUsuario in bd.TipoUsuario
                                on empl.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                join tipoContrato in bd.TipoContrato
                                on empl.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                select new EmpleadoCLS
                                {
                                    Iiempleado = empl.IIDEMPLEADO,
                                    nombreEmpleado = empl.NOMBRE,
                                    aPaterno = empl.APPATERNO,
                                    //sueldo   = empl.SUELDO,
                                    nombreTipoUsuario = tipoUsuario.NOMBRE,
                                    nombreTipoContrato = tipoContrato.NOMBRE
                                }).ToList();
            }
            return View(ListEmployee);
        }


        public void listarComboSexo()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- seleccione--", Value = "" });
                ViewBag.listaSexo = lista;
            }

        }

        public void listarTipoContrato()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from tipocontr in bd.TipoContrato
                         where tipocontr.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipocontr.NOMBRE,
                             Value = tipocontr.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- seleccione--", Value = "" });
                ViewBag.listaTipoContrato = lista;
            }
        }

        public void listarTipoUsuario()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from tipousuario in bd.TipoUsuario
                         where tipousuario.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = tipousuario.NOMBRE,
                             Value = tipousuario.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "-- seleccione--", Value = "" });
                ViewBag.listaTipoUsuario = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoUsuario();
            listarTipoContrato();
            listarComboSexo();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            if (!ModelState.IsValid)
            {
                listarCombos(); 
                return View(oEmpleadoCLS);
            }
            using (var db = new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.IIDEMPLEADO = oEmpleadoCLS.Iiempleado;
                oEmpleado.NOMBRE = oEmpleadoCLS.nombreEmpleado;
                oEmpleado.APPATERNO = oEmpleadoCLS.aPaterno;
                oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.Iidtipousuario;
                oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.Iidtipocontrato;
                oEmpleado.IIDSEXO = oEmpleadoCLS.Iidsexo;
                oEmpleado.BHABILITADO = 1;
                db.Empleado.Add(oEmpleado);
                db.SaveChanges();
                    
            }

            return RedirectToAction("Index");
        }
    }
}