﻿using System;
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
    }
}