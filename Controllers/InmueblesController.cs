using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;

namespace Inmobiliaria.Net.Controllers
{
    public class InmueblesController : Controller
    {
        public readonly BdInmuebles bdInmuebles = new BdInmuebles();
        // GET: Inmuebles
        public ActionResult Index()
        {   
            BdTipos bdt= new BdTipos();
            BdUsos bdu = new BdUsos();
            ViewBag.tipos = bdt.GetTipos();
            ViewBag.usos = bdu.GetUsos();
            var Inmuebles = bdInmuebles.Getinmuebles();
            return View(Inmuebles);
        }

        // GET: Inmuebles/Details/5
        public ActionResult Details(int id)
        {
            var inmu = bdInmuebles.Getinmueble(id);
             BdPropietarios bdp = new BdPropietarios();
            BdTipos bdt = new BdTipos();
            BdUsos bdu = new BdUsos();
                 ViewBag.props = bdp.Getpropietarios();
                 ViewBag.tipos = bdt.GetTipos();
                 ViewBag.usos = bdu.GetUsos();
            return View(inmu);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            BdPropietarios bdp = new BdPropietarios();
            BdTipos bdt = new BdTipos();
            BdUsos bdu = new BdUsos();
                 ViewBag.props = bdp.Getpropietarios();
                 ViewBag.tipos = bdt.GetTipos();
                 ViewBag.usos = bdu.GetUsos();
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble inmueble)
        {
            try
            {
                // TODO: Add insert logic here
                int res = bdInmuebles.Alta(inmueble);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                    BdPropietarios bdp = new BdPropietarios();
            ViewBag.props = bdp.Getpropietarios();
                return View();
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            var inmu = bdInmuebles.Getinmueble(id);
            BdPropietarios bdp = new BdPropietarios();
            BdTipos bdt = new BdTipos();
            BdUsos bdu = new BdUsos();
                 ViewBag.props = bdp.Getpropietarios();
                 ViewBag.tipos = bdt.GetTipos();
                 ViewBag.usos = bdu.GetUsos();
            return View(inmu);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble inmueble)
        {
            try
            {
                // TODO: Add update logic here
                
                bdInmuebles.Actualizar(inmueble);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
              BdPropietarios bdp = new BdPropietarios();
            BdTipos bdt = new BdTipos();
            BdUsos bdu = new BdUsos();
                 ViewBag.props = bdp.Getpropietarios();
                 ViewBag.tipos = bdt.GetTipos();
                 ViewBag.usos = bdu.GetUsos();
                return View();
            }
        }

        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int id)
        {
           var inmu =  bdInmuebles.Getinmueble(id);
            BdPropietarios bdp = new BdPropietarios();
            BdTipos bdt = new BdTipos();
            BdUsos bdu = new BdUsos();
                 ViewBag.props = bdp.Getpropietarios();
                 ViewBag.tipos = bdt.GetTipos();
                 ViewBag.usos = bdu.GetUsos();
            return View(inmu);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble inmueble)
        {
            try
            {
                // TODO: Add delete logic here
                bdInmuebles.DeleteInmueble(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
