using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;

namespace Inmobiliaria.Net.Controllers
{
    public class PagosController : Controller
    {
        public readonly BdPagos bdPagos = new BdPagos();
        // GET: Inmuebles
        public ActionResult Index(int id)
        {   
            
            var pagos = bdPagos.GetPagos(id);
            return View(pagos);
        }

   
     

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
           
                 ViewBag.inmuebles = bdInmu.Getinmuebles();
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                 
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            try
            {
                // TODO: Add insert logic here
                int res = bdPagos.Alta(pago);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                 
                return View();
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            var contrato = bdPagos.GetPago(id);
           
            
            return View(contrato);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pagar(Pago pago)
        {
            try
            {
                
                bdPagos.Pagar(pago);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
           
                return View();
            }
        }

         
    }
}
