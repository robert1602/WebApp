using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd= new BDPasajeEntities())
            {
              listaMarca = (from marca in bd.Marca
                            where marca.BHABILITADO==1
                            select new MarcaCLS
                            {
                                iidMarca = marca.IIDMARCA,
                                nombre = marca.NOMBRE,
                                descripcion = marca.DESCRIPCION
                            }).ToList();
            }

            return View(listaMarca);
        }


       

        [HttpPost]
        public ActionResult Agregar(MarcaCLS omarcaCLS)
        {

            if (!ModelState.IsValid)
            {
                return View(omarcaCLS);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Marca marca = new Marca();
                    marca.NOMBRE = omarcaCLS.nombre;
                    marca.DESCRIPCION = omarcaCLS.descripcion;
                    marca.BHABILITADO=1;
                    bd.Marca.Add(marca);
                    bd.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult Agregar()
        {
            return View();
        }


        public ActionResult Editar(int id) {

            MarcaCLS oMarcaCLS = new MarcaCLS();
            using (var db = new BDPasajeEntities())
            {
                Marca oMarca = db.Marca.Where(p => p.IIDMARCA.Equals(id)).First();
                oMarcaCLS.iidMarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;
            }

             return View(oMarcaCLS);    
        }
    }
}